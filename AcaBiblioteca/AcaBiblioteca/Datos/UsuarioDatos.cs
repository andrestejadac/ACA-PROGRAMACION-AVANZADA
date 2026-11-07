using AcaBiblioteca.Entidades;
using Microsoft.Data.SqlClient;

namespace AcaBiblioteca.Datos
{
    /// <summary>Acceso a datos de la tabla Usuarios (consultas parametrizadas).</summary>
    public class UsuarioDatos
    {
        private readonly Conexion conexion = new Conexion();

        public List<Usuario> Listar()
        {
            var usuarios = new List<Usuario>();

            using SqlConnection cn = conexion.ObtenerConexion();
            cn.Open();

            const string sql = @"SELECT IdUsuario, Nombre, Apellido, Documento, Telefono, Correo
                                 FROM Usuarios
                                 ORDER BY Nombre, Apellido";
            using SqlCommand cmd = new SqlCommand(sql, cn);
            using SqlDataReader lector = cmd.ExecuteReader();

            while (lector.Read())
            {
                usuarios.Add(new Usuario(
                    lector.GetInt32(0),
                    lector.GetString(1),
                    lector.GetString(2),
                    lector.GetString(3),
                    lector.IsDBNull(4) ? string.Empty : lector.GetString(4),
                    lector.IsDBNull(5) ? string.Empty : lector.GetString(5)));
            }

            return usuarios;
        }

        public void Insertar(Usuario usuario)
        {
            Ejecutar(
                @"INSERT INTO Usuarios (Nombre, Apellido, Documento, Telefono, Correo)
                  VALUES (@Nombre, @Apellido, @Documento, @Telefono, @Correo)",
                usuario, AccionSql.Guardar);
        }

        public bool Actualizar(Usuario usuario)
        {
            return Ejecutar(
                @"UPDATE Usuarios
                  SET Nombre = @Nombre, Apellido = @Apellido, Documento = @Documento,
                      Telefono = @Telefono, Correo = @Correo
                  WHERE IdUsuario = @IdUsuario",
                usuario, AccionSql.Guardar) > 0;
        }

        public bool Eliminar(int idUsuario)
        {
            return Ejecutar(
                "DELETE FROM Usuarios WHERE IdUsuario = @IdUsuario",
                new Usuario { IdUsuario = idUsuario }, AccionSql.Eliminar) > 0;
        }

        private int Ejecutar(string sql, Usuario usuario, AccionSql accion)
        {
            try
            {
                using SqlConnection cn = conexion.ObtenerConexion();
                cn.Open();

                using SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                cmd.Parameters.AddWithValue("@Documento", usuario.Documento);
                cmd.Parameters.AddWithValue("@Telefono", ValorONulo(usuario.Telefono));
                cmd.Parameters.AddWithValue("@Correo", ValorONulo(usuario.Correo));

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ErroresSql.Traducir(ex, "usuario", accion);
            }
        }

        private static object ValorONulo(string texto)
        {
            return string.IsNullOrWhiteSpace(texto) ? DBNull.Value : (object)texto;
        }
    }
}
