using AcaBiblioteca.Comun;
using AcaBiblioteca.Entidades;
using AcaBiblioteca.Negocio;

namespace AcaBiblioteca
{
    public partial class FrmAutores : Form
    {
        private readonly AutorNegocio negocio = new AutorNegocio();
        private int idSeleccionado = 0;

        public FrmAutores()
        {
            InitializeComponent();
            CargarAutores();
        }

        private void CargarAutores()
        {
            try
            {
                dgvAutores.DataSource = negocio.Listar();
            }
            catch (Exception ex)
            {
                Mensajes.Excepcion(ex, "Error al cargar los autores");
            }
        }

        private void LimpiarCampos()
        {
            idSeleccionado = 0;
            txtNombre.Clear();
            txtApellido.Clear();
            dgvAutores.ClearSelection();
            txtNombre.Focus();
        }

        private void SeleccionarFila(int indiceFila)
        {
            if (indiceFila < 0 || dgvAutores.Rows[indiceFila].DataBoundItem is not Autor autor)
                return;

            idSeleccionado = autor.IdAutor;
            txtNombre.Text = autor.Nombre;
            txtApellido.Text = autor.Apellido;
        }

        private void dgvAutores_CellClick(object? sender, DataGridViewCellEventArgs e) => SeleccionarFila(e.RowIndex);

        private void dgvAutores_CellDoubleClick(object? sender, DataGridViewCellEventArgs e) => SeleccionarFila(e.RowIndex);

        private void btnNuevo_Click(object? sender, EventArgs e) => LimpiarCampos();

        private void btnCancelar_Click(object? sender, EventArgs e) => LimpiarCampos();

        private void btnGuardar_Click(object? sender, EventArgs e)
        {
            try
            {
                negocio.Guardar(new Autor(0, txtNombre.Text, txtApellido.Text));
                Mensajes.Informacion("Autor guardado correctamente.");
                CargarAutores();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                Mensajes.Excepcion(ex, "Error al guardar el autor");
            }
        }

        private void btnEditar_Click(object? sender, EventArgs e)
        {
            try
            {
                negocio.Actualizar(new Autor(idSeleccionado, txtNombre.Text, txtApellido.Text));
                Mensajes.Informacion("Autor actualizado correctamente.");
                CargarAutores();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                Mensajes.Excepcion(ex, "Error al actualizar el autor");
            }
        }

        private void btnEliminar_Click(object? sender, EventArgs e)
        {
            try
            {
                if (idSeleccionado <= 0)
                {
                    Mensajes.Advertencia("Seleccione un autor de la tabla para eliminar.");
                    return;
                }

                if (!Mensajes.Confirmar("¿Está seguro de eliminar este autor?"))
                    return;

                negocio.Eliminar(idSeleccionado);
                Mensajes.Informacion("Autor eliminado correctamente.");
                CargarAutores();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                Mensajes.Excepcion(ex, "Error al eliminar el autor");
            }
        }
    }
}
