using AcaBiblioteca.Comun;
using AcaBiblioteca.Entidades;
using AcaBiblioteca.Negocio;

namespace AcaBiblioteca
{
    public partial class FrmUsuarios : Form
    {
        private readonly UsuarioNegocio negocio = new UsuarioNegocio();
        private int idSeleccionado = 0;

        public FrmUsuarios()
        {
            InitializeComponent();
            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            try
            {
                dgvUsuarios.DataSource = negocio.Listar();
            }
            catch (Exception ex)
            {
                Mensajes.Excepcion(ex, "Error al cargar los usuarios");
            }
        }

        private void LimpiarCampos()
        {
            idSeleccionado = 0;
            txtNombre.Clear();
            txtApellido.Clear();
            txtDocumento.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            dgvUsuarios.ClearSelection();
            txtNombre.Focus();
        }

        private Usuario LeerFormulario()
        {
            return new Usuario(idSeleccionado, txtNombre.Text, txtApellido.Text,
                               txtDocumento.Text, txtTelefono.Text, txtCorreo.Text);
        }

        private void SeleccionarFila(int indiceFila)
        {
            if (indiceFila < 0 || dgvUsuarios.Rows[indiceFila].DataBoundItem is not Usuario usuario)
                return;

            idSeleccionado = usuario.IdUsuario;
            txtNombre.Text = usuario.Nombre;
            txtApellido.Text = usuario.Apellido;
            txtDocumento.Text = usuario.Documento;
            txtTelefono.Text = usuario.Telefono;
            txtCorreo.Text = usuario.Correo;
        }

        private void dgvUsuarios_CellClick(object? sender, DataGridViewCellEventArgs e) => SeleccionarFila(e.RowIndex);

        private void dgvUsuarios_CellDoubleClick(object? sender, DataGridViewCellEventArgs e) => SeleccionarFila(e.RowIndex);

        private void btnNuevo_Click(object? sender, EventArgs e) => LimpiarCampos();

        private void btnCancelar_Click(object? sender, EventArgs e) => LimpiarCampos();

        private void btnGuardar_Click(object? sender, EventArgs e)
        {
            try
            {
                Usuario usuario = LeerFormulario();
                usuario.IdUsuario = 0;

                negocio.Guardar(usuario);
                Mensajes.Informacion("Usuario guardado correctamente.");
                CargarUsuarios();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                Mensajes.Excepcion(ex, "Error al guardar el usuario");
            }
        }

        private void btnEditar_Click(object? sender, EventArgs e)
        {
            try
            {
                negocio.Actualizar(LeerFormulario());
                Mensajes.Informacion("Usuario actualizado correctamente.");
                CargarUsuarios();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                Mensajes.Excepcion(ex, "Error al actualizar el usuario");
            }
        }

        private void btnEliminar_Click(object? sender, EventArgs e)
        {
            try
            {
                if (idSeleccionado <= 0)
                {
                    Mensajes.Advertencia("Seleccione un usuario de la tabla para eliminar.");
                    return;
                }

                if (!Mensajes.Confirmar("¿Está seguro de eliminar este usuario?"))
                    return;

                negocio.Eliminar(idSeleccionado);
                Mensajes.Informacion("Usuario eliminado correctamente.");
                CargarUsuarios();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                Mensajes.Excepcion(ex, "Error al eliminar el usuario");
            }
        }
    }
}
