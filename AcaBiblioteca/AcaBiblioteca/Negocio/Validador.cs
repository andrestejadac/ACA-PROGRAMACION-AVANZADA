using System.Net.Mail;
using AcaBiblioteca.Comun;

namespace AcaBiblioteca.Negocio
{
    /// <summary>Validaciones reutilizables por las clases de negocio.</summary>
    public static class Validador
    {
        public static void Obligatorio(string valor, string campo)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new ReglaNegocioException($"El campo {campo} es obligatorio.");
        }

        public static void LongitudMaxima(string valor, int maximo, string campo)
        {
            if (valor != null && valor.Trim().Length > maximo)
                throw new ReglaNegocioException($"El campo {campo} no puede superar los {maximo} caracteres.");
        }

        /// <summary>Texto obligatorio con longitud máxima (como en la base de datos).</summary>
        public static void Texto(string valor, string campo, int maximo)
        {
            Obligatorio(valor, campo);
            LongitudMaxima(valor, maximo, campo);
        }

        public static void Correo(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                return; // el correo es opcional

            LongitudMaxima(valor, 150, "correo electrónico");

            bool valido = MailAddress.TryCreate(valor.Trim(), out MailAddress? direccion)
                          && direccion.Address == valor.Trim()
                          && valor.Trim().Contains('.', StringComparison.Ordinal);

            if (!valido)
                throw new ReglaNegocioException("El correo electrónico no tiene un formato válido (ejemplo: nombre@dominio.com).");
        }

        public static void SoloDigitos(string valor, string campo)
        {
            if (!string.IsNullOrWhiteSpace(valor) && !valor.Trim().All(char.IsDigit))
                throw new ReglaNegocioException($"El campo {campo} solo debe contener números.");
        }

        /// <summary>Convierte un texto a entero o lanza un error claro.</summary>
        public static int Entero(string valor, string campo)
        {
            if (!int.TryParse(valor?.Trim(), out int numero))
                throw new ReglaNegocioException($"El campo {campo} debe ser un número entero.");

            return numero;
        }
    }
}
