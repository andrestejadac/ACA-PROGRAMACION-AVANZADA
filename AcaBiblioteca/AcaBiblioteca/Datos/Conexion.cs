using System.Text.Json;
using Microsoft.Data.SqlClient;

namespace AcaBiblioteca.Datos
{
    /// <summary>
    /// Crea las conexiones a SQL Server.
    /// La cadena de conexión se toma, en este orden:
    ///   1. De la variable de entorno ACA_BIBLIOTECA_CONN.
    ///   2. Del archivo conexion.config.json junto al ejecutable.
    ///   3. De la cadena por defecto (instancia local SQL2022).
    /// </summary>
    public class Conexion
    {
        private const string CadenaPorDefecto =
            "Server=.\\SQL2022;Database=AcaBiblioteca;Integrated Security=true;TrustServerCertificate=true;";

        private const string ArchivoConfiguracion = "conexion.config.json";

        private static string? cadenaCache;

        private static string CadenaConexion => cadenaCache ??= LeerCadena();

        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(CadenaConexion);
        }

        private static string LeerCadena()
        {
            string? deEntorno = Environment.GetEnvironmentVariable("ACA_BIBLIOTECA_CONN");
            if (!string.IsNullOrWhiteSpace(deEntorno))
                return deEntorno;

            string ruta = Path.Combine(AppContext.BaseDirectory, ArchivoConfiguracion);
            if (File.Exists(ruta))
            {
                try
                {
                    using JsonDocument documento = JsonDocument.Parse(File.ReadAllText(ruta));
                    if (documento.RootElement.TryGetProperty("ConnectionString", out JsonElement valor))
                    {
                        string? cadena = valor.GetString();
                        if (!string.IsNullOrWhiteSpace(cadena))
                            return cadena;
                    }
                }
                catch (JsonException)
                {
                    // Si el archivo está mal formado se usa la cadena por defecto.
                }
            }

            return CadenaPorDefecto;
        }
    }
}
