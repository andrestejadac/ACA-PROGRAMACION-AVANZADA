using AcaBiblioteca.Comun;
using AcaBiblioteca.Datos;
using AcaBiblioteca.Entidades;

namespace AcaBiblioteca.Negocio
{
    /// <summary>Reglas de negocio de los libros.</summary>
    public class LibroNegocio
    {
        private readonly LibroDatos datos = new LibroDatos();

        private readonly AutorNegocio autorNegocio = new AutorNegocio();
        private readonly EditorialNegocio editorialNegocio = new EditorialNegocio();

        public List<Libro> Listar(string? filtro = null) => datos.Listar(filtro);

        public Libro? ObtenerPorIsbn(string isbn) => datos.ObtenerPorIsbn(isbn.Trim());

        /// <summary>Guarda el libro; el autor y la editorial se crean si no existen.</summary>
        public (string? AutorCreado, string? EditorialCreada) Guardar(Libro libro, string? autorTexto, string? editorialTexto)
        {
            Validar(libro, exigirAutorYEditorial: false);

            if (datos.Existe(libro.ISBN))
                throw new ReglaNegocioException($"Ya existe un libro registrado con el ISBN {libro.ISBN}.");

            var creados = ResolverAutorYEditorial(libro, autorTexto, editorialTexto);
            datos.Insertar(libro);
            return creados;
        }

        /// <summary>Igual que Guardar, pero para actualizar.</summary>
        public (string? AutorCreado, string? EditorialCreada) Actualizar(Libro libro, string? autorTexto, string? editorialTexto)
        {
            Validar(libro, exigirAutorYEditorial: false);

            var creados = ResolverAutorYEditorial(libro, autorTexto, editorialTexto);

            if (!datos.Actualizar(libro))
                throw new ReglaNegocioException("No existe un libro con ese ISBN. Use Guardar para registrarlo.");

            return creados;
        }

        private (string? AutorCreado, string? EditorialCreada) ResolverAutorYEditorial(
            Libro libro, string? autorTexto, string? editorialTexto)
        {
            var autor = autorNegocio.ObtenerOCrear(autorTexto);
            var editorial = editorialNegocio.ObtenerOCrear(editorialTexto);

            libro.IdAutor = autor.Id;
            libro.IdEditorial = editorial.Id;

            return (autor.Creado ? autor.Nombre : null, editorial.Creado ? editorial.Nombre : null);
        }

        public void Guardar(Libro libro)
        {
            Validar(libro);

            if (datos.Existe(libro.ISBN))
                throw new ReglaNegocioException($"Ya existe un libro registrado con el ISBN {libro.ISBN}.");

            datos.Insertar(libro);
        }

        public void Actualizar(Libro libro)
        {
            Validar(libro);

            if (!datos.Actualizar(libro))
                throw new ReglaNegocioException("No existe un libro con ese ISBN. Use Guardar para registrarlo.");
        }

        public void Eliminar(string isbn)
        {
            if (string.IsNullOrWhiteSpace(isbn))
                throw new ReglaNegocioException("Seleccione un libro de la tabla para eliminar.");

            if (!datos.Eliminar(isbn.Trim()))
                throw new ReglaNegocioException("El libro ya no existe en la base de datos.");
        }

        private static void Validar(Libro libro, bool exigirAutorYEditorial = true)
        {
            Validador.Texto(libro.ISBN, "ISBN", 20);
            ValidarFormatoIsbn(libro.ISBN);
            Validador.Texto(libro.Titulo, "título", 200);
            Validador.Texto(libro.Categoria, "categoría", 100);

            if (exigirAutorYEditorial && libro.IdAutor <= 0)
                throw new ReglaNegocioException("Seleccione un autor.");

            if (exigirAutorYEditorial && libro.IdEditorial <= 0)
                throw new ReglaNegocioException("Seleccione una editorial.");

            if (!libro.Anio.HasValue)
                throw new ReglaNegocioException("El campo año es obligatorio.");

            int anioMaximo = DateTime.Today.Year + 1;
            if (libro.Anio.Value < 1 || libro.Anio.Value > anioMaximo)
                throw new ReglaNegocioException($"El año debe estar entre 1 y {anioMaximo}.");

            if (libro.Existencias < 0)
                throw new ReglaNegocioException("Las existencias no pueden ser negativas.");
        }

        private static void ValidarFormatoIsbn(string isbn)
        {
            string limpio = isbn.Replace("-", string.Empty).Trim();
            bool longitudValida = limpio.Length == 10 || limpio.Length == 13;
            bool caracteresValidos = limpio.All(char.IsLetterOrDigit);

            if (!longitudValida || !caracteresValidos)
                throw new ReglaNegocioException("El ISBN debe tener 10 o 13 caracteres (se permiten guiones).");
        }
    }
}
