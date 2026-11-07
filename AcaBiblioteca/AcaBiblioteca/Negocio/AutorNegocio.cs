using AcaBiblioteca.Comun;
using AcaBiblioteca.Datos;
using AcaBiblioteca.Entidades;

namespace AcaBiblioteca.Negocio
{
    /// <summary>Reglas de negocio de los autores.</summary>
    public class AutorNegocio
    {
        private readonly AutorDatos datos = new AutorDatos();

        public List<Autor> Listar() => datos.Listar();

        public void Guardar(Autor autor)
        {
            Validar(autor);
            datos.Insertar(autor);
        }

        /// <summary>Busca el autor por nombre completo; si no existe, lo crea.</summary>
        public (int Id, string Nombre, bool Creado) ObtenerOCrear(string? texto)
        {
            string limpio = string.Join(' ', (texto ?? string.Empty).Split(' ', StringSplitOptions.RemoveEmptyEntries));
            if (limpio.Length == 0)
                throw new ReglaNegocioException("Seleccione o escriba el autor del libro.");

            Autor? existente = datos.Listar().FirstOrDefault(a =>
                string.Equals(a.NombreCompleto, limpio, StringComparison.OrdinalIgnoreCase));
            if (existente != null)
                return (existente.IdAutor, existente.NombreCompleto, false);

            int espacio = limpio.IndexOf(' ');
            if (espacio < 0)
                throw new ReglaNegocioException(
                    "Para registrar un autor nuevo escriba nombre y apellido (ejemplo: Gabriel García Márquez).");

            var nuevo = new Autor { Nombre = limpio.Substring(0, espacio), Apellido = limpio.Substring(espacio + 1) };
            Validar(nuevo);

            return (datos.InsertarObteniendoId(nuevo), nuevo.NombreCompleto, true);
        }

        public void Actualizar(Autor autor)
        {
            if (autor.IdAutor <= 0)
                throw new ReglaNegocioException("Seleccione un autor de la tabla para editar.");

            Validar(autor);

            if (!datos.Actualizar(autor))
                throw new ReglaNegocioException("El autor ya no existe en la base de datos.");
        }

        public void Eliminar(int idAutor)
        {
            if (idAutor <= 0)
                throw new ReglaNegocioException("Seleccione un autor de la tabla para eliminar.");

            if (!datos.Eliminar(idAutor))
                throw new ReglaNegocioException("El autor ya no existe en la base de datos.");
        }

        private static void Validar(Autor autor)
        {
            Validador.Texto(autor.Nombre, "nombre", 100);
            Validador.Texto(autor.Apellido, "apellido", 100);
        }
    }
}