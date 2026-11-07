using AcaBiblioteca.Entidades;
using Microsoft.Data.SqlClient;

namespace AcaBiblioteca.Datos
{
    /// <summary>Acceso a datos de la tabla Editoriales (consultas parametrizadas).</summary>
    public class EditorialDatos
    {
        private readonly Conexion conexion = new Conexion();

        public List<Editorial> Listar()
        {
            var editoriales = new List<Editorial>();

            using SqlConnection cn = conexion.ObtenerConexion();
            cn.Open();

            const string sql = "SELECT IdEditorial, Nombre FROM Editoriales ORDER BY Nombre";
            using SqlCommand cmd = new SqlCommand(sql, cn);
            using SqlDataReader lector = cmd.ExecuteReader();

            while (lector.Read())
            {
                editoriales.Add(new Editorial(lector.GetInt32(0), lector.GetString(1)));
            }

            return editoriales;
        }

        public void Insertar(Editorial editorial)
        {
            Ejecutar("INSERT INTO Editoriales (Nombre) VALUES (@Nombre)", editorial, AccionSql.Guardar);
        }

        /// <summary>Inserta una editorial y devuelve el id que le asignó la base de datos.</summary>
        public int InsertarObteniendoId(Editorial editorial)
        {
            try
            {
                using SqlConnection cn = conexion.ObtenerConexion();
                cn.Open();

                using SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Editoriales (Nombre) OUTPUT INSERTED.IdEditorial VALUES (@Nombre)", cn);
                cmd.Parameters.AddWithValue("@Nombre", editorial.Nombre);

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                throw ErroresSql.Traducir(ex, "editorial", AccionSql.Guardar);
            }
        }

        public bool Actualizar(Editorial editorial)
        {
            return Ejecutar(
                "UPDATE Editoriales SET Nombre = @Nombre WHERE IdEditorial = @IdEditorial",
                editorial, AccionSql.Guardar) > 0;
        }

        public bool Eliminar(int idEditorial)
        {
            return Ejecutar(
                "DELETE FROM Editoriales WHERE IdEditorial = @IdEditorial",
                new Editorial { IdEditorial = idEditorial }, AccionSql.Eliminar) > 0;
        }

        private int Ejecutar(string sql, Editorial editorial, AccionSql accion)
        {
            try
            {
                using SqlConnection cn = conexion.ObtenerConexion();
                cn.Open();

                using SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@IdEditorial", editorial.IdEditorial);
                cmd.Parameters.AddWithValue("@Nombre", editorial.Nombre);

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ErroresSql.Traducir(ex, "editorial", accion);
            }
        }
    }
}
