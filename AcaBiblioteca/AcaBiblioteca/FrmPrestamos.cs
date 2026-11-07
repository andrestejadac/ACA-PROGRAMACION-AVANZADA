using AcaBiblioteca.Comun;
using AcaBiblioteca.Entidades;
using AcaBiblioteca.Negocio;

namespace AcaBiblioteca
{
    public partial class FrmPrestamos : Form
    {
        private readonly PrestamoNegocio prestamoNegocio = new PrestamoNegocio();
        private readonly UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
        private readonly LibroNegocio libroNegocio = new LibroNegocio();

        private int idPrestamoSeleccionado = 0;
        private bool cargando = true;

        public FrmPrestamos()
        {
            InitializeComponent();

            dtpFechaPrestamo.MaxDate = DateTime.Today;
            dtpFechaDevolucion.MaxDate = DateTime.Today;
            dtpFechaEdicion.MaxDate = DateTime.Today;

            cmbFiltroEstado.SelectedIndex = 0;

            CargarUsuarios();
            CargarLibros();
            CargarPrestamos();

            cargando = false;
        }

        // ---------------------------------------------------------------
        //  Carga de datos
        // ---------------------------------------------------------------

        private void CargarUsuarios()
        {
            try
            {
                cmbUsuario.DataSource = usuarioNegocio.Listar()
                    .Select(u => new { u.IdUsuario, Texto = $"{u.NombreCompleto} - {u.Documento}" })
                    .ToList();
                cmbUsuario.DisplayMember = "Texto";
                cmbUsuario.ValueMember = "IdUsuario";
                cmbUsuario.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                Mensajes.Excepcion(ex, "Error al cargar los usuarios");
            }
        }

        private void CargarLibros()
        {
            try
            {
                cmbLibro.DataSource = libroNegocio.Listar()
                    .Select(l => new { l.ISBN, Texto = $"{l.Titulo}  ({l.Existencias} disponibles)" })
                    .ToList();
                cmbLibro.DisplayMember = "Texto";
                cmbLibro.ValueMember = "ISBN";
                cmbLibro.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                Mensajes.Excepcion(ex, "Error al cargar los libros");
            }
        }

        private void CargarPrestamos()
        {
            try
            {
                string? estado = cmbFiltroEstado.SelectedIndex > 0 ? cmbFiltroEstado.Text : null;

                dgvPrestamos.DataSource = prestamoNegocio.Listar(estado);

                if (dgvPrestamos.Columns["IdUsuario"] != null)
                    dgvPrestamos.Columns["IdUsuario"]!.Visible = false;

                dgvPrestamos.Columns["FechaPrestamo"]!.DefaultCellStyle.Format = "yyyy-MM-dd";
                dgvPrestamos.Columns["FechaDevolucion"]!.DefaultCellStyle.Format = "yyyy-MM-dd";

                idPrestamoSeleccionado = 0;
                dgvPrestamos.ClearSelection();
            }
            catch (Exception ex)
            {
                Mensajes.Excepcion(ex, "Error al cargar los préstamos");
            }
        }

        /// <summary>Refresca tabla y listas (las existencias cambian con cada operación).</summary>
        private void RefrescarTodo()
        {
            cargando = true;
            CargarLibros();
            CargarPrestamos();
            cargando = false;
        }

        // ---------------------------------------------------------------
        //  Eventos
        // ---------------------------------------------------------------

        private void cmbFiltroEstado_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (!cargando)
                CargarPrestamos();
        }

        private void dgvPrestamos_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvPrestamos.Rows[e.RowIndex].DataBoundItem is not Prestamo prestamo)
                return;

            idPrestamoSeleccionado = prestamo.IdPrestamo;
            dtpFechaEdicion.Value = Acotar(prestamo.FechaPrestamo);
            dtpFechaDevolucion.Value = Acotar(prestamo.FechaDevolucion ?? DateTime.Today);
        }

        private static DateTime Acotar(DateTime fecha)
        {
            return fecha.Date > DateTime.Today ? DateTime.Today : fecha.Date;
        }

        private void btnRegistrar_Click(object? sender, EventArgs e)
        {
            try
            {
                int idUsuario = cmbUsuario.SelectedValue is int id ? id : 0;
                string isbn = cmbLibro.SelectedValue as string ?? string.Empty;

                int numero = prestamoNegocio.Registrar(idUsuario, isbn, dtpFechaPrestamo.Value);

                Mensajes.Informacion($"Préstamo N.º {numero} registrado correctamente.");

                cmbUsuario.SelectedIndex = -1;
                RefrescarTodo();
            }
            catch (Exception ex)
            {
                Mensajes.Excepcion(ex, "Error al registrar el préstamo");
            }
        }

        private void btnDevolver_Click(object? sender, EventArgs e)
        {
            try
            {
                if (idPrestamoSeleccionado <= 0)
                {
                    Mensajes.Advertencia("Seleccione en la tabla el préstamo que se va a devolver.");
                    return;
                }

                prestamoNegocio.Devolver(idPrestamoSeleccionado, dtpFechaDevolucion.Value);

                Mensajes.Informacion("Devolución registrada correctamente.");
                RefrescarTodo();
            }
            catch (Exception ex)
            {
                Mensajes.Excepcion(ex, "Error al registrar la devolución");
            }
        }

        private void btnEditarFecha_Click(object? sender, EventArgs e)
        {
            try
            {
                if (idPrestamoSeleccionado <= 0)
                {
                    Mensajes.Advertencia("Seleccione en la tabla el préstamo que desea editar.");
                    return;
                }

                prestamoNegocio.EditarFechaPrestamo(idPrestamoSeleccionado, dtpFechaEdicion.Value);

                Mensajes.Informacion("Fecha del préstamo actualizada correctamente.");
                RefrescarTodo();
            }
            catch (Exception ex)
            {
                Mensajes.Excepcion(ex, "Error al editar el préstamo");
            }
        }

        private void btnEliminar_Click(object? sender, EventArgs e)
        {
            try
            {
                if (idPrestamoSeleccionado <= 0)
                {
                    Mensajes.Advertencia("Seleccione en la tabla el préstamo que desea eliminar.");
                    return;
                }

                if (!Mensajes.Confirmar("¿Está seguro de eliminar este préstamo? " +
                                        "Si estaba activo, el ejemplar volverá a las existencias del libro."))
                    return;

                prestamoNegocio.Eliminar(idPrestamoSeleccionado);

                Mensajes.Informacion("Préstamo eliminado correctamente.");
                RefrescarTodo();
            }
            catch (Exception ex)
            {
                Mensajes.Excepcion(ex, "Error al eliminar el préstamo");
            }
        }
    }
}
