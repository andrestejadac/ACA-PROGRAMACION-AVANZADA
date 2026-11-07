using AcaBiblioteca.Comun;
using AcaBiblioteca.Entidades;
using Microsoft.Data.SqlClient;

namespace AcaBiblioteca.Datos
{
    /// <summary>
    /// Acceso a datos de la tabla Prestamos.
    /// Las operaciones que modifican el préstamo y las existencias del libro
    /// se ejecutan dentro de una transacción para mantener la coherencia.
    /// </summary>
    public class PrestamoDatos
    {
        private readonly Conexion conexion = new Conexion();

        private const string ConsultaBase = @"
            SELECT P.IdPrestamo, P.IdUsuario, U.Nombre + ' ' + U.Apellido AS Usuario,
                   P.ISBN, L.Titulo AS Libro, P.FechaPrestamo, P.FechaDevolucion, P.Estado
            FROM Prestamos P
            INNER JOIN Usuarios U ON U.IdUsuario = P.IdUsuario
            INNER JOIN Libros L ON L.ISBN = P.ISBN";

        /// <summary>Lista los préstamos; si se indica un estado, filtra por él.</summary>
        public List<Prestamo> Listar(string? estado = null)
        {
            var prestamos = new List<Prestamo>();

            using SqlConnection cn = conexion.ObtenerConexion();
            cn.Open();

            string sql = ConsultaBase;
            if (!string.IsNullOrWhiteSpace(estado))
                sql += " WHERE P.Estado = @Estado";
            sql += " ORDER BY P.FechaPrestamo DESC, P.IdPrestamo DESC";

            using SqlCommand cmd = new SqlCommand(sql, cn);
            if (!string.IsNullOrWhiteSpace(estado))
                cmd.Parameters.AddWithValue("@Estado", estado);

            using SqlDataReader lector = cmd.ExecuteReader();
            while (lector.Read())
            {
                prestamos.Add(new Prestamo
                {
                    IdPrestamo = lector.GetInt32(0),
                    IdUsuario = lector.GetInt32(1),
                    Usuario = lector.GetString(2),
                    ISBN = lector.GetString(3),
                    Libro = lector.GetString(4),
                    FechaPrestamo = lector.GetDateTime(5),
                    FechaDevolucion = lector.IsDBNull(6) ? null : lector.GetDateTime(6),
                    Estado = lector.GetString(7)
                });
            }

            return prestamos;
        }

        // ---- Consultas de apoyo para validar antes de registrar -------------

        public bool ExisteUsuario(int idUsuario)
        {
            return Contar("SELECT COUNT(1) FROM Usuarios WHERE IdUsuario = @Id",
                          new SqlParameter("@Id", idUsuario)) > 0;
        }

        /// <summary>Devuelve las existencias del libro o null si el libro no existe.</summary>
        public int? ObtenerExistencias(string isbn)
        {
            using SqlConnection cn = conexion.ObtenerConexion();
            cn.Open();

            using SqlCommand cmd = new SqlCommand("SELECT Existencias FROM Libros WHERE ISBN = @ISBN", cn);
            cmd.Parameters.AddWithValue("@ISBN", isbn);

            object? resultado = cmd.ExecuteScalar();
            return resultado == null ? null : Convert.ToInt32(resultado);
        }

        public int ContarPrestamosActivos(int idUsuario)
        {
            return Contar(
                "SELECT COUNT(1) FROM Prestamos WHERE IdUsuario = @Id AND Estado = 'Prestado'",
                new SqlParameter("@Id", idUsuario));
        }

        public bool ExistePrestamoActivo(int idUsuario, string isbn)
        {
            return Contar(
                "SELECT COUNT(1) FROM Prestamos WHERE IdUsuario = @Id AND ISBN = @ISBN AND Estado = 'Prestado'",
                new SqlParameter("@Id", idUsuario),
                new SqlParameter("@ISBN", isbn)) > 0;
        }

        public Prestamo? ObtenerPorId(int idPrestamo)
        {
            using SqlConnection cn = conexion.ObtenerConexion();
            cn.Open();

            using SqlCommand cmd = new SqlCommand(ConsultaBase + " WHERE P.IdPrestamo = @Id", cn);
            cmd.Parameters.AddWithValue("@Id", idPrestamo);

            using SqlDataReader lector = cmd.ExecuteReader();
            if (!lector.Read())
                return null;

            return new Prestamo
            {
                IdPrestamo = lector.GetInt32(0),
                IdUsuario = lector.GetInt32(1),
                Usuario = lector.GetString(2),
                ISBN = lector.GetString(3),
                Libro = lector.GetString(4),
                FechaPrestamo = lector.GetDateTime(5),
                FechaDevolucion = lector.IsDBNull(6) ? null : lector.GetDateTime(6),
                Estado = lector.GetString(7)
            };
        }

        // ---- Operaciones transaccionales -------------------------------------

        /// <summary>
        /// Registra el préstamo y descuenta un ejemplar del libro, en una sola transacción.
        /// </summary>
        public int Registrar(Prestamo prestamo)
        {
            using SqlConnection cn = conexion.ObtenerConexion();
            cn.Open();
            using SqlTransaction tx = cn.BeginTransaction();

            try
            {
                // El descuento solo se aplica si hay ejemplares: protege contra
                // dos préstamos simultáneos del último ejemplar.
                using (SqlCommand descontar = new SqlCommand(
                    "UPDATE Libros SET Existencias = Existencias - 1 WHERE ISBN = @ISBN AND Existencias > 0",
                    cn, tx))
                {
                    descontar.Parameters.AddWithValue("@ISBN", prestamo.ISBN);
                    if (descontar.ExecuteNonQuery() == 0)
                        throw new ReglaNegocioException("El libro no tiene existencias disponibles para prestar.");
                }

                int idNuevo;
                using (SqlCommand insertar = new SqlCommand(
                    @"INSERT INTO Prestamos (IdUsuario, ISBN, FechaPrestamo, FechaDevolucion, Estado)
                      OUTPUT INSERTED.IdPrestamo
                      VALUES (@IdUsuario, @ISBN, @FechaPrestamo, NULL, 'Prestado')", cn, tx))
                {
                    insertar.Parameters.AddWithValue("@IdUsuario", prestamo.IdUsuario);
                    insertar.Parameters.AddWithValue("@ISBN", prestamo.ISBN);
                    insertar.Parameters.AddWithValue("@FechaPrestamo", prestamo.FechaPrestamo.Date);
                    idNuevo = Convert.ToInt32(insertar.ExecuteScalar());
                }

                tx.Commit();
                return idNuevo;
            }
            catch (SqlException ex)
            {
                tx.Rollback();
                throw ErroresSql.Traducir(ex, "préstamo", AccionSql.Guardar);
            }
            catch
            {
                tx.Rollback();
                throw;
            }
        }

        /// <summary>
        /// Registra la devolución: actualiza fecha y estado del préstamo y
        /// suma un ejemplar al libro, en una sola transacción.
        /// </summary>
        public void Devolver(int idPrestamo, DateTime fechaDevolucion)
        {
            using SqlConnection cn = conexion.ObtenerConexion();
            cn.Open();
            using SqlTransaction tx = cn.BeginTransaction();

            try
            {
                string isbn;
                using (SqlCommand actualizar = new SqlCommand(
                    @"UPDATE Prestamos
                      SET FechaDevolucion = @Fecha, Estado = 'Devuelto'
                      OUTPUT INSERTED.ISBN
                      WHERE IdPrestamo = @Id AND Estado = 'Prestado'", cn, tx))
                {
                    actualizar.Parameters.AddWithValue("@Fecha", fechaDevolucion.Date);
                    actualizar.Parameters.AddWithValue("@Id", idPrestamo);

                    object? resultado = actualizar.ExecuteScalar();
                    if (resultado == null)
                        throw new ReglaNegocioException("El préstamo no existe o ya fue devuelto.");

                    isbn = Convert.ToString(resultado) ?? string.Empty;
                }

                using (SqlCommand sumar = new SqlCommand(
                    "UPDATE Libros SET Existencias = Existencias + 1 WHERE ISBN = @ISBN", cn, tx))
                {
                    sumar.Parameters.AddWithValue("@ISBN", isbn);
                    sumar.ExecuteNonQuery();
                }

                tx.Commit();
            }
            catch (SqlException ex)
            {
                tx.Rollback();
                throw ErroresSql.Traducir(ex, "préstamo", AccionSql.Guardar);
            }
            catch
            {
                tx.Rollback();
                throw;
            }
        }

        /// <summary>Cambia la fecha de un préstamo que todavía está activo.</summary>
        public void ActualizarFechaPrestamo(int idPrestamo, DateTime fechaPrestamo)
        {
            try
            {
                using SqlConnection cn = conexion.ObtenerConexion();
                cn.Open();

                using SqlCommand cmd = new SqlCommand(
                    "UPDATE Prestamos SET FechaPrestamo = @Fecha WHERE IdPrestamo = @Id AND Estado = 'Prestado'", cn);
                cmd.Parameters.AddWithValue("@Fecha", fechaPrestamo.Date);
                cmd.Parameters.AddWithValue("@Id", idPrestamo);

                if (cmd.ExecuteNonQuery() == 0)
                    throw new ReglaNegocioException("Solo se puede editar un préstamo que exista y esté en estado Prestado.");
            }
            catch (SqlException ex)
            {
                throw ErroresSql.Traducir(ex, "préstamo", AccionSql.Guardar);
            }
        }

        /// <summary>
        /// Elimina el préstamo. Si todavía estaba activo, devuelve el ejemplar
        /// a las existencias del libro para no perder la coherencia.
        /// </summary>
        public void Eliminar(int idPrestamo)
        {
            using SqlConnection cn = conexion.ObtenerConexion();
            cn.Open();
            using SqlTransaction tx = cn.BeginTransaction();

            try
            {
                string? isbn = null;
                string? estado = null;

                using (SqlCommand eliminar = new SqlCommand(
                    "DELETE FROM Prestamos OUTPUT DELETED.ISBN, DELETED.Estado WHERE IdPrestamo = @Id", cn, tx))
                {
                    eliminar.Parameters.AddWithValue("@Id", idPrestamo);
                    using SqlDataReader lector = eliminar.ExecuteReader();
                    if (lector.Read())
                    {
                        isbn = lector.GetString(0);
                        estado = lector.GetString(1);
                    }
                }

                if (isbn == null)
                    throw new ReglaNegocioException("El préstamo no existe.");

                if (estado == Prestamo.EstadoPrestado)
                {
                    using SqlCommand sumar = new SqlCommand(
                        "UPDATE Libros SET Existencias = Existencias + 1 WHERE ISBN = @ISBN", cn, tx);
                    sumar.Parameters.AddWithValue("@ISBN", isbn);
                    sumar.ExecuteNonQuery();
                }

                tx.Commit();
            }
            catch (SqlException ex)
            {
                tx.Rollback();
                throw ErroresSql.Traducir(ex, "préstamo", AccionSql.Eliminar);
            }
            catch
            {
                tx.Rollback();
                throw;
            }
        }

        private int Contar(string sql, params SqlParameter[] parametros)
        {
            using SqlConnection cn = conexion.ObtenerConexion();
            cn.Open();

            using SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddRange(parametros);

            return Convert.ToInt32(cmd.ExecuteScalar());
        }
    }
}
