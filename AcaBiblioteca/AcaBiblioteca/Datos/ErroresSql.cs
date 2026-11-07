using AcaBiblioteca.Comun;
using Microsoft.Data.SqlClient;

namespace AcaBiblioteca.Datos
{
    public enum AccionSql
    {
        Guardar,
        Eliminar
    }

    /// <summary>
    /// Traduce los errores de SQL Server más comunes a mensajes claros.
    /// Se usan los números de error (no el texto) para no depender del idioma del servidor.
    /// </summary>
    public static class ErroresSql
    {
        private const int ViolacionUnique = 2627;
        private const int IndiceUnicoDuplicado = 2601;
        private const int ViolacionRestriccion = 547; // FOREIGN KEY o CHECK

        public static Exception Traducir(SqlException ex, string entidad, AccionSql accion)
        {
            if (ex.Number == ViolacionUnique || ex.Number == IndiceUnicoDuplicado)
            {
                return new ReglaNegocioException(
                    $"Ya existe un registro de {entidad} con esos datos. No se permiten duplicados.", ex);
            }

            if (ex.Number == ViolacionRestriccion)
            {
                if (accion == AccionSql.Eliminar)
                {
                    return new ReglaNegocioException(
                        $"No se puede eliminar el registro de {entidad} porque tiene información relacionada " +
                        "(libros o préstamos).", ex);
                }

                return new ReglaNegocioException(
                    $"Los datos de {entidad} no cumplen las restricciones de la base de datos. " +
                    "Verifique que los registros relacionados existan y que los valores sean válidos.", ex);
            }

            return ex;
        }
    }
}
