using AcaBiblioteca.Comun;
using AcaBiblioteca.Entidades;
using AcaBiblioteca.Negocio;

namespace AcaBiblioteca
{
    public partial class FrmEditoriales : Form
    {
        private readonly EditorialNegocio negocio = new EditorialNegocio();
        private int idSeleccionado = 0;

        public FrmEditoriales()
        {
            InitializeComponent();
            CargarEditoriales();
        }

        private void CargarEditoriales()
        {
            try
            {
                dgvEditoriales.DataSource = negocio.Listar();
            }
            catch (Exception ex)
            {
                Mensajes.Excepcion(ex, "Error al cargar las editoriales");
            }
        }

        private void LimpiarCampos()
        {
            idSeleccionado = 0;
            txtNombre.Clear();
            dgvEditoriales.ClearSelection();
            txtNombre.Focus();
        }

        private void SeleccionarFila(int indiceFila)
        {
            if (indiceFila < 0 || dgvEditoriales.Rows[indiceFila].DataBoundItem is not Editorial editorial)
                return;

            idSeleccionado = editorial.IdEditorial;
            txtNombre.Text = editorial.Nombre;
        }

        private void dgvEditoriales_CellClick(object? sender, DataGridViewCellEventArgs e) => SeleccionarFila(e.RowIndex);

        private void dgvEditoriales_CellDoubleClick(object? sender, DataGridViewCellEventArgs e) => SeleccionarFila(e.RowIndex);

        private void btnNuevo_Click(object? sender, EventArgs e) => LimpiarCampos();

        private void btnCancelar_Click(object? sender, EventArgs e) => LimpiarCampos();

        private void btnGuardar_Click(object? sender, EventArgs e)
        {
            try
            {
                negocio.Guardar(new Editorial(0, txtNombre.Text));
                Mensajes.Informacion("Editorial guardada correctamente.");
                CargarEditoriales();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                Mensajes.Excepcion(ex, "Error al guardar la editorial");
            }
        }

        private void btnEditar_Click(object? sender, EventArgs e)
        {
            try
            {
                negocio.Actualizar(new Editorial(idSeleccionado, txtNombre.Text));
                Mensajes.Informacion("Editorial actualizada correctamente.");
                CargarEditoriales();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                Mensajes.Excepcion(ex, "Error al actualizar la editorial");
            }
        }

        private void btnEliminar_Click(object? sender, EventArgs e)
        {
            try
            {
                if (idSeleccionado <= 0)
                {
                    Mensajes.Advertencia("Seleccione una editorial de la tabla para eliminar.");
                    return;
                }

                if (!Mensajes.Confirmar("¿Está seguro de eliminar esta editorial?"))
                    return;

                negocio.Eliminar(idSeleccionado);
                Mensajes.Informacion("Editorial eliminada correctamente.");
                CargarEditoriales();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                Mensajes.Excepcion(ex, "Error al eliminar la editorial");
            }
        }
    }
}
