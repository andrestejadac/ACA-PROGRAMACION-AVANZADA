using AcaBiblioteca.Comun;
using AcaBiblioteca.Datos;
using AcaBiblioteca.Entidades;

namespace AcaBiblioteca.Negocio
{
    /// <summary>
    /// Reglas de negocio de préstamos y devoluciones:
    ///  RN1. El usuario y el libro deben existir.
    ///  RN2. No se presta un libro sin existencias.
    ///  RN3. Un usuario no puede tener el mismo libro prestado dos veces a la vez.
    ///  RN4. Un usuario puede tener como máximo MaximoPrestamosActivos préstamos activos.
    ///  RN5. La fecha del préstamo no puede ser futura.
    ///  RN6. La devolución no puede ser anterior al préstamo ni futura.
    ///  RN7. Al prestar se descuenta un ejemplar; al devolver (o eliminar un préstamo activo) se suma.
    /// </summary>
    public class PrestamoNegocio
    {
        public const int MaximoPrestamosActivos = 3;

        private readonly PrestamoDatos datos = new PrestamoDatos();

        public List<Prestamo> Listar(string? estado = null) => datos.Listar(estado);

        public int Registrar(int idUsuario, string isbn, DateTime fechaPrestamo)
        {
            if (idUsuario <= 0)
                throw new ReglaNegocioException("Seleccione el usuario que solicita el préstamo.");

            if (string.IsNullOrWhiteSpace(isbn))
                throw new ReglaNegocioException("Seleccione el libro que se desea prestar.");

            if (fechaPrestamo.Date > DateTime.Today)
                throw new ReglaNegocioException("La fecha del préstamo no puede ser posterior a hoy.");

            isbn = isbn.Trim();

            if (!datos.ExisteUsuario(idUsuario))
                throw new ReglaNegocioException("El usuario seleccionado no existe.");

            int? existencias = datos.ObtenerExistencias(isbn);
            if (existencias == null)
                throw new ReglaNegocioException("El libro seleccionado no existe.");

            if (existencias.Value <= 0)
                throw new ReglaNegocioException("El libro no tiene existencias disponibles para prestar.");

            if (datos.ExistePrestamoActivo(idUsuario, isbn))
                throw new ReglaNegocioException("El usuario ya tiene este libro prestado y aún no lo ha devuelto.");

            if (datos.ContarPrestamosActivos(idUsuario) >= MaximoPrestamosActivos)
                throw new ReglaNegocioException(
                    $"El usuario ya tiene {MaximoPrestamosActivos} préstamos activos, que es el máximo permitido.");

            return datos.Registrar(new Prestamo(idUsuario, isbn, fechaPrestamo));
        }

        public void Devolver(int idPrestamo, DateTime fechaDevolucion)
        {
            Prestamo prestamo = ObtenerExistente(idPrestamo);

            if (prestamo.EstaDevuelto)
                throw new ReglaNegocioException("Este préstamo ya fue devuelto.");

            if (fechaDevolucion.Date < prestamo.FechaPrestamo.Date)
                throw new ReglaNegocioException("La fecha de devolución no puede ser anterior a la fecha del préstamo.");

            if (fechaDevolucion.Date > DateTime.Today)
                throw new ReglaNegocioException("La fecha de devolución no puede ser posterior a hoy.");

            datos.Devolver(idPrestamo, fechaDevolucion);
        }

        public void EditarFechaPrestamo(int idPrestamo, DateTime nuevaFecha)
        {
            Prestamo prestamo = ObtenerExistente(idPrestamo);

            if (prestamo.EstaDevuelto)
                throw new ReglaNegocioException("No se puede editar un préstamo que ya fue devuelto.");

            if (nuevaFecha.Date > DateTime.Today)
                throw new ReglaNegocioException("La fecha del préstamo no puede ser posterior a hoy.");

            datos.ActualizarFechaPrestamo(idPrestamo, nuevaFecha);
        }

        public void Eliminar(int idPrestamo)
        {
            ObtenerExistente(idPrestamo);
            datos.Eliminar(idPrestamo);
        }

        private Prestamo ObtenerExistente(int idPrestamo)
        {
            if (idPrestamo <= 0)
                throw new ReglaNegocioException("Seleccione un préstamo de la tabla.");

            return datos.ObtenerPorId(idPrestamo)
                   ?? throw new ReglaNegocioException("El préstamo seleccionado ya no existe.");
        }
    }
}
