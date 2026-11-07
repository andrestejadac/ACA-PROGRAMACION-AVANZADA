using AcaBiblioteca.Comun;
using AcaBiblioteca.Datos;
using AcaBiblioteca.Entidades;

namespace AcaBiblioteca.Negocio
{
    /// <summary>Reglas de negocio de los usuarios de la biblioteca.</summary>
    public class UsuarioNegocio
    {
        private readonly UsuarioDatos datos = new UsuarioDatos();

        public List<Usuario> Listar() => datos.Listar();

        public void Guardar(Usuario usuario)
        {
            Validar(usuario);
            datos.Insertar(usuario);
        }

        public void Actualizar(Usuario usuario)
        {
            if (usuario.IdUsuario <= 0)
                throw new ReglaNegocioException("Seleccione un usuario de la tabla para editar.");

            Validar(usuario);

            if (!datos.Actualizar(usuario))
                throw new ReglaNegocioException("El usuario ya no existe en la base de datos.");
        }

        public void Eliminar(int idUsuario)
        {
            if (idUsuario <= 0)
                throw new ReglaNegocioException("Seleccione un usuario de la tabla para eliminar.");

            if (!datos.Eliminar(idUsuario))
                throw new ReglaNegocioException("El usuario ya no existe en la base de datos.");
        }

        private static void Validar(Usuario usuario)
        {
            Validador.Texto(usuario.Nombre, "nombre", 100);
            Validador.Texto(usuario.Apellido, "apellido", 100);
            Validador.Texto(usuario.Documento, "documento", 30);
            Validador.SoloDigitos(usuario.Documento, "documento");
            Validador.LongitudMaxima(usuario.Telefono, 30, "teléfono");
            Validador.SoloDigitos(usuario.Telefono, "teléfono");
            Validador.Correo(usuario.Correo);
        }
    }
}
