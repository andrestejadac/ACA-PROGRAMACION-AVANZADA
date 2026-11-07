using AcaBiblioteca.Comun;
using AcaBiblioteca.Datos;
using AcaBiblioteca.Entidades;

namespace AcaBiblioteca.Negocio
{
    /// <summary>Reglas de negocio de las editoriales.</summary>
    public class EditorialNegocio
    {
        private readonly EditorialDatos datos = new EditorialDatos();

        public List<Editorial> Listar() => datos.Listar();

        public void Guardar(Editorial editorial)
        {
            Validar(editorial);
            datos.Insertar(editorial);
        }

        /// <summary>Busca la editorial por nombre; si no existe, la crea.</summary>
        public (int Id, string Nombre, bool Creado) ObtenerOCrear(string? texto)
        {
            string limpio = string.Join(' ', (texto ?? string.Empty).Split(' ', StringSplitOptions.RemoveEmptyEntries));
            if (limpio.Length == 0)
                throw new ReglaNegocioException("Seleccione o escriba la editorial del libro.");

            Editorial? existente = datos.Listar().FirstOrDefault(e =>
                string.Equals(e.Nombre, limpio, StringComparison.OrdinalIgnoreCase));
            if (existente != null)
                return (existente.IdEditorial, existente.Nombre, false);

            var nueva = new Editorial { Nombre = limpio };
            Validar(nueva);

            return (datos.InsertarObteniendoId(nueva), nueva.Nombre, true);
        }

        public void Actualizar(Editorial editorial)
        {
            if (editorial.IdEditorial <= 0)
                throw new ReglaNegocioException("Seleccione una editorial de la tabla para editar.");

            Validar(editorial);

            if (!datos.Actualizar(editorial))
                throw new ReglaNegocioException("La editorial ya no existe en la base de datos.");
        }

        public void Eliminar(int idEditorial)
        {
            if (idEditorial <= 0)
                throw new ReglaNegocioException("Seleccione una editorial de la tabla para eliminar.");

            if (!datos.Eliminar(idEditorial))
                throw new ReglaNegocioException("La editorial ya no existe en la base de datos.");
        }

        private static void Validar(Editorial editorial)
        {
            Validador.Texto(editorial.Nombre, "nombre", 150);
        }
    }
}