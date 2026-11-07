using AcaBiblioteca.Entidades;
using Microsoft.Data.SqlClient;

namespace AcaBiblioteca.Datos
{
    /// <summary>Acceso a datos de la tabla Libros (consultas parametrizadas).</summary>
    public class LibroDatos
    {
        private readonly Conexion conexion = new Conexion();

        private const string ConsultaBase = @"
            SELECT L.ISBN, L.Titulo, L.IdAutor, L.IdEditorial, L.Categoria, L.Anio, L.Existencias,
                   A.Nombre + ' ' + A.Apellido AS Autor,
                   E.Nombre AS Editorial
            FROM Libros L
            INNER JOIN Autores A ON A.IdAutor = L.IdAutor
            INNER JOIN Editoriales E ON E.IdEditorial = L.IdEditorial";

        /// <summary>
        /// Lista los libros. Si se envía un filtro, busca por ISBN, título o autor.
        /// </summary>
        public List<Libro> Listar(string? filtro = null)
        {
            var libros = new List<Libro>();

            using SqlConnection cn = conexion.ObtenerConexion();
            cn.Open();

            string sql = ConsultaBase;
            bool hayFiltro = !string.IsNullOrWhiteSpace(filtro);
            if (hayFiltro)
            {
                sql += @" WHERE L.ISBN LIKE @Filtro
                             OR L.Titulo LIKE @Filtro
                             OR A.Nombre + ' ' + A.Apellido LIKE @Filtro";
            }
            sql += " ORDER BY L.Titulo";

            using SqlCommand cmd = new SqlCommand(sql, cn);
            if (hayFiltro)
                cmd.Parameters.AddWithValue("@Filtro", "%" + filtro!.Trim() + "%");

            using SqlDataReader lector = cmd.ExecuteReader();
            while (lector.Read())
            {
                libros.Add(Mapear(lector));
            }

            return libros;
        }

        public Libro? ObtenerPorIsbn(string isbn)
        {
            using SqlConnection cn = conexion.ObtenerConexion();
            cn.Open();

            using SqlCommand cmd = new SqlCommand(ConsultaBase + " WHERE L.ISBN = @ISBN", cn);
            cmd.Parameters.AddWithValue("@ISBN", isbn);

            using SqlDataReader lector = cmd.ExecuteReader();
            return lector.Read() ? Mapear(lector) : null;
        }

        public bool Existe(string isbn)
        {
            using SqlConnection cn = conexion.ObtenerConexion();
            cn.Open();

            using SqlCommand cmd = new SqlCommand("SELECT COUNT(1) FROM Libros WHERE ISBN = @ISBN", cn);
            cmd.Parameters.AddWithValue("@ISBN", isbn);

            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        public void Insertar(Libro libro)
        {
            Ejecutar(
                @"INSERT INTO Libros (ISBN, Titulo, IdAutor, IdEditorial, Categoria, Anio, Existencias)
                  VALUES (@ISBN, @Titulo, @IdAutor, @IdEditorial, @Categoria, @Anio, @Existencias)",
                libro, AccionSql.Guardar);
        }

        public bool Actualizar(Libro libro)
        {
            return Ejecutar(
                @"UPDATE Libros
                  SET Titulo = @Titulo, IdAutor = @IdAutor, IdEditorial = @IdEditorial,
                      Categoria = @Categoria, Anio = @Anio, Existencias = @Existencias
                  WHERE ISBN = @ISBN",
                libro, AccionSql.Guardar) > 0;
        }

        public bool Eliminar(string isbn)
        {
            return Ejecutar(
                "DELETE FROM Libros WHERE ISBN = @ISBN",
                new Libro { ISBN = isbn }, AccionSql.Eliminar) > 0;
        }

        private int Ejecutar(string sql, Libro libro, AccionSql accion)
        {
            try
            {
                using SqlConnection cn = conexion.ObtenerConexion();
                cn.Open();

                using SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@ISBN", libro.ISBN);
                cmd.Parameters.AddWithValue("@Titulo", libro.Titulo);
                cmd.Parameters.AddWithValue("@IdAutor", libro.IdAutor);
                cmd.Parameters.AddWithValue("@IdEditorial", libro.IdEditorial);
                cmd.Parameters.AddWithValue("@Categoria",
                    string.IsNullOrWhiteSpace(libro.Categoria) ? DBNull.Value : (object)libro.Categoria);
                cmd.Parameters.AddWithValue("@Anio", libro.Anio.HasValue ? (object)libro.Anio.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@Existencias", libro.Existencias);

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ErroresSql.Traducir(ex, "libro", accion);
            }
        }

        private static Libro Mapear(SqlDataReader lector)
        {
            return new Libro(
                lector.GetString(0),
                lector.GetString(1),
                lector.GetInt32(2),
                lector.GetInt32(3),
                lector.IsDBNull(4) ? string.Empty : lector.GetString(4),
                lector.IsDBNull(5) ? null : lector.GetInt32(5),
                lector.GetInt32(6))
            {
                Autor = lector.GetString(7),
                Editorial = lector.GetString(8)
            };
        }
    }
}
