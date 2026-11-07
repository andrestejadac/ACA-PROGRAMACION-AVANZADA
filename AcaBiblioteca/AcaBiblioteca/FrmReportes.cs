using AcaBiblioteca.Comun;
using AcaBiblioteca.Negocio;

namespace AcaBiblioteca
{
    public partial class FrmReportes : Form
    {
        private readonly ReporteNegocio negocio = new ReporteNegocio();

        public FrmReportes()
        {
            InitializeComponent();

            cmbReporte.Items.AddRange(ReporteNegocio.Reportes);
            cmbReporte.SelectedIndex = 0;
            dgvReporte.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            GenerarReporte();
        }

        private void GenerarReporte()
        {
            try
            {
                if (cmbReporte.SelectedItem is not string reporte)
                {
                    Mensajes.Advertencia("Seleccione el reporte que desea generar.");
                    return;
                }

                var tabla = negocio.Generar(reporte);
                dgvReporte.DataSource = tabla;
                lblTotal.Text = $"Registros: {tabla.Rows.Count}";

                // Las fechas se muestran sin hora
                foreach (DataGridViewColumn columna in dgvReporte.Columns)
                {
                    if (columna.ValueType == typeof(DateTime))
                        columna.DefaultCellStyle.Format = "yyyy-MM-dd";
                }
            }
            catch (Exception ex)
            {
                Mensajes.Excepcion(ex, "Error al generar el reporte");
            }
        }

        private void btnGenerar_Click(object? sender, EventArgs e)
        {
            GenerarReporte();
        }
    }
}
