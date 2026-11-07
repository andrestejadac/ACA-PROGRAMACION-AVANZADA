using AcaBiblioteca.Comun;
using AcaBiblioteca.Entidades;
using AcaBiblioteca.Negocio;

namespace AcaBiblioteca
{
    public partial class FrmLibros : Form
    {
        private readonly LibroNegocio libroNegocio = new LibroNegocio();
        private readonly AutorNegocio autorNegocio = new AutorNegocio();
        private readonly EditorialNegocio editorialNegocio = new EditorialNegocio();

        public FrmLibros()
        {
            InitializeComponent();

            // La búsqueda ahora admite ISBN, título o autor (RF01)
            lblBuscar.Text = "Buscar :";
            txtBuscarISBN.PlaceholderText = "ISBN, título o autor";

            CargarAutores();
            CargarEditoriales();
            CargarLibros();
            LimpiarCampos();
        }

        // ---------------------------------------------------------------
        //  Carga de datos
        // ---------------------------------------------------------------

        private void CargarLibros(string? filtro = null)
        {
            try
            {
                dgvLibros.DataSource = libroNegocio.Listar(filtro);

                // Se muestran el nombre del autor y de la editorial en lugar de sus identificadores
                if (dgvLibros.Columns["IdAutor"] != null)
                    dgvLibros.Columns["IdAutor"]!.Visible = false;
                if (dgvLibros.Columns["IdEditorial"] != null)
                    dgvLibros.Columns["IdEditorial"]!.Visible = false;
            }
            catch (Exception ex)
            {
                Mensajes.Excepcion(ex, "Error al cargar los libros");
            }
        }

        private void CargarAutores()
        {
            try
            {
                cmbAutor.DataSource = autorNegocio.Listar();
                cmbAutor.DisplayMember = "NombreCompleto";
                cmbAutor.ValueMember = "IdAutor";
                cmbAutor.DropDownStyle = ComboBoxStyle.DropDown;
                cmbAutor.AutoCompleteMode = AutoCompleteMode.Suggest;
                cmbAutor.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            catch (Exception ex)
            {
                Mensajes.Excepcion(ex, "Error al cargar los autores");
            }
        }

        private void CargarEditoriales()
        {
            try
            {
                cmbEditorial.DataSource = editorialNegocio.Listar();
                cmbEditorial.DisplayMember = "Nombre";
                cmbEditorial.ValueMember = "IdEditorial";
                cmbEditorial.DropDownStyle = ComboBoxStyle.DropDown;
                cmbEditorial.AutoCompleteMode = AutoCompleteMode.Suggest;
                cmbEditorial.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            catch (Exception ex)
            {
                Mensajes.Excepcion(ex, "Error al cargar las editoriales");
            }
        }

        // ---------------------------------------------------------------
        //  Apoyo de la interfaz
        // ---------------------------------------------------------------

        private void LimpiarCampos()
        {
            txtISBN.Clear();
            txtTitulo.Clear();
            txtCategoria.Clear();
            txtAnio.Clear();
            txtExistencias.Clear();
            cmbAutor.SelectedIndex = -1;
            cmbAutor.Text = string.Empty;
            cmbEditorial.SelectedIndex = -1;
            cmbEditorial.Text = string.Empty;
            txtISBN.Enabled = true;
            txtISBN.Focus();
        }

        private void MostrarLibro(Libro libro)
        {
            txtISBN.Text = libro.ISBN;
            txtTitulo.Text = libro.Titulo;
            cmbAutor.SelectedValue = libro.IdAutor;
            cmbEditorial.SelectedValue = libro.IdEditorial;
            txtCategoria.Text = libro.Categoria;
            txtAnio.Text = libro.Anio?.ToString() ?? string.Empty;
            txtExistencias.Text = libro.Existencias.ToString();
        }

        private static string MensajeExito(string mensaje, (string? AutorCreado, string? EditorialCreada) creados)
        {
            if (creados.AutorCreado != null)
                mensaje += $"\nSe registró el autor nuevo: {creados.AutorCreado}.";
            if (creados.EditorialCreada != null)
                mensaje += $"\nSe registró la editorial nueva: {creados.EditorialCreada}.";
            return mensaje;
        }

        /// <summary>Convierte los campos del formulario en un Libro (valida los números).</summary>
        private Libro LeerFormulario()
        {
            return new Libro
            {
                ISBN = txtISBN.Text,
                Titulo = txtTitulo.Text,
                IdAutor = cmbAutor.SelectedValue is int idAutor ? idAutor : 0,
                IdEditorial = cmbEditorial.SelectedValue is int idEditorial ? idEditorial : 0,
                Categoria = txtCategoria.Text,
                Anio = string.IsNullOrWhiteSpace(txtAnio.Text) ? null : Validador.Entero(txtAnio.Text, "año"),
                Existencias = Validador.Entero(txtExistencias.Text, "existencias")
            };
        }

        // ---------------------------------------------------------------
        //  Eventos
        // ---------------------------------------------------------------

        private void btnBuscar_Click(object? sender, EventArgs e)
        {
            try
            {
                string filtro = txtBuscarISBN.Text.Trim();
                CargarLibros(filtro);

                if (string.IsNullOrEmpty(filtro))
                    return;

                if (dgvLibros.Rows.Count == 0)
                {
                    Mensajes.Informacion("No se encontró ningún libro con ese ISBN, título o autor.");
                }
                else if (dgvLibros.Rows.Count == 1 && dgvLibros.Rows[0].DataBoundItem is Libro unico)
                {
                    MostrarLibro(unico);
                }
            }
            catch (Exception ex)
            {
                Mensajes.Excepcion(ex, "Error al buscar el libro");
            }
        }

        private void btnNuevo_Click(object? sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnCancelar_Click(object? sender, EventArgs e)
        {
            txtBuscarISBN.Clear();
            LimpiarCampos();
            CargarLibros();
        }

        private void btnGuardar_Click(object? sender, EventArgs e)
        {
            try
            {
                var creados = libroNegocio.Guardar(LeerFormulario(), cmbAutor.Text, cmbEditorial.Text);

                Mensajes.Informacion(MensajeExito("Libro guardado correctamente.", creados));
                CargarAutores();
                CargarEditoriales();
                CargarLibros();
                CargarLibros();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                Mensajes.Excepcion(ex, "Error al guardar el libro");
            }
        }

        private void btnEditar_Click(object? sender, EventArgs e)
        {
            try
            {
                var creados = libroNegocio.Actualizar(LeerFormulario(), cmbAutor.Text, cmbEditorial.Text);

                Mensajes.Informacion(MensajeExito("Libro actualizado correctamente.", creados));
                CargarAutores();
                CargarEditoriales();
                CargarLibros();
                CargarLibros();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                Mensajes.Excepcion(ex, "Error al actualizar el libro");
            }
        }

        private void dgvLibros_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvLibros.Rows[e.RowIndex].DataBoundItem is Libro libro)
            {
                MostrarLibro(libro);
                txtISBN.Enabled = false; // el ISBN es la clave y no se modifica al editar
            }
        }

        private void btnEliminar_Click(object? sender, EventArgs e)
        {
            try
            {
                if (dgvLibros.CurrentRow?.DataBoundItem is not Libro libro)
                {
                    Mensajes.Advertencia("Seleccione un libro de la tabla para eliminar.");
                    return;
                }

                if (!Mensajes.Confirmar($"¿Está seguro de eliminar el libro \"{libro.Titulo}\"?"))
                    return;

                libroNegocio.Eliminar(libro.ISBN);

                Mensajes.Informacion("Libro eliminado correctamente.");
                CargarLibros();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                Mensajes.Excepcion(ex, "Error al eliminar el libro");
            }
        }

        private void pnlBusqueda_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
