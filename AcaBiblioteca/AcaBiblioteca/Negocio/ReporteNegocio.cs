using System.Data;
using AcaBiblioteca.Datos;
using AcaBiblioteca.Entidades;

namespace AcaBiblioteca.Negocio
{
    /// <summary>Catálogo de reportes disponibles y su generación.</summary>
    public class ReporteNegocio
    {
        private readonly ReporteDatos datos = new ReporteDatos();

        /// <summary>Nombres de los reportes que se muestran en la lista desplegable.</summary>
        public static readonly string[] Reportes =
        {
            "Listado de libros",
            "Listado de autores",
            "Listado de editoriales",
            "Listado de usuarios",
            "Relación de préstamos (historial)",
            "Préstamos activos",
            "Préstamos devueltos",
            "Libros más prestados",
            "Libros sin existencias",
            "Información consolidada"
        };

        public DataTable Generar(string reporte)
        {
            return reporte switch
            {
                "Listado de libros" => datos.ListadoLibros(),
                "Listado de autores" => datos.ListadoAutores(),
                "Listado de editoriales" => datos.ListadoEditoriales(),
                "Listado de usuarios" => datos.ListadoUsuarios(),
                "Relación de préstamos (historial)" => datos.Prestamos(null),
                "Préstamos activos" => datos.Prestamos(Prestamo.EstadoPrestado),
                "Préstamos devueltos" => datos.Prestamos(Prestamo.EstadoDevuelto),
                "Libros más prestados" => datos.LibrosMasPrestados(),
                "Libros sin existencias" => datos.LibrosSinExistencias(),
                "Información consolidada" => datos.Resumen(),
                _ => throw new ArgumentException("Reporte no reconocido: " + reporte)
            };
        }

        public DataTable Resumen() => datos.Resumen();
    }
}
