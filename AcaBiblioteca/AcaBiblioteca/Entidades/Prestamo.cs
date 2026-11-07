using System.ComponentModel;

namespace AcaBiblioteca.Entidades
{
    public class Prestamo
    {
        public const string EstadoPrestado = "Prestado";
        public const string EstadoDevuelto = "Devuelto";

        public Prestamo()
        {
        }

        public Prestamo(int idUsuario, string isbn, DateTime fechaPrestamo)
        {
            IdUsuario = idUsuario;
            ISBN = isbn;
            FechaPrestamo = fechaPrestamo.Date;
            Estado = EstadoPrestado;
        }

        public int IdPrestamo { get; set; }

        public int IdUsuario { get; set; }

        public string ISBN { get; set; } = string.Empty;

        public DateTime FechaPrestamo { get; set; }

        public DateTime? FechaDevolucion { get; set; }

        public string Estado { get; set; } = EstadoPrestado;

        // Datos de apoyo para mostrar en las tablas (vienen del JOIN)
        public string Usuario { get; set; } = string.Empty;

        public string Libro { get; set; } = string.Empty;

        [Browsable(false)]
        public bool EstaDevuelto => Estado == EstadoDevuelto;
    }
}
