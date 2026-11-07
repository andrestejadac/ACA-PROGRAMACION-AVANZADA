using AcaBiblioteca.Entidades;
using Microsoft.Data.SqlClient;

namespace AcaBiblioteca.Datos
{
    /// <summary>Acceso a datos de la tabla Autores (consultas parametrizadas).</summary>
    public class AutorDatos
    {
        private readonly Conexion conexion = new Conexion();

        public List<Autor> Listar()
        {
            var autores = new List<Autor>();

            using SqlConnection cn = conexion.ObtenerConexion();
            cn.Open();

            const string sql = "SELECT IdAutor, Nombre, Apellido FROM Autores ORDER BY Nombre, Apellido";
            using SqlCommand cmd = new SqlCommand(sql, cn);
            using SqlDataReader lector = cmd.ExecuteReader();

            while (lector.Read())
            {
                autores.Add(new Autor(
                    lector.GetInt32(0),
                    lector.GetString(1),
                    lector.GetString(2)));
            }

            return autores;
        }

        public void Insertar(Autor autor)
        {
            Ejecutar(
                "INSERT INTO Autores (Nombre, Apellido) VALUES (@Nombre, @Apellido)",
                autor, AccionSql.Guardar);
        }

        /// <summary>Inserta un autor y devuelve el id que le asignó la base de datos.</summary>
        public int InsertarObteniendoId(Autor autor)
        {
            try
            {
                using SqlConnection cn = conexion.ObtenerConexion();
                cn.Open();

                using SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Autores (Nombre, Apellido) OUTPUT INSERTED.IdAutor VALUES (@Nombre, @Apellido)", cn);
                cmd.Parameters.AddWithValue("@Nombre", autor.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", autor.Apellido);

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                throw ErroresSql.Traducir(ex, "autor", AccionSql.Guardar);
            }
        }

        public bool Actualizar(Autor autor)
        {
            return Ejecutar(
                "UPDATE Autores SET Nombre = @Nombre, Apellido = @Apellido WHERE IdAutor = @IdAutor",
                autor, AccionSql.Guardar) > 0;
        }

        public bool Eliminar(int idAutor)
        {
            return Ejecutar(
                "DELETE FROM Autores WHERE IdAutor = @IdAutor",
                new Autor { IdAutor = idAutor }, AccionSql.Eliminar) > 0;
        }

        private int Ejecutar(string sql, Autor autor, AccionSql accion)
        {
            try
            {
                using SqlConnection cn = conexion.ObtenerConexion();
                cn.Open();

                using SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@IdAutor", autor.IdAutor);
                cmd.Parameters.AddWithValue("@Nombre", autor.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", autor.Apellido);

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ErroresSql.Traducir(ex, "autor", accion);
            }
        }
    }
}
