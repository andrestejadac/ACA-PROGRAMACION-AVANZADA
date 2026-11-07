using AcaBiblioteca.Comun;
using AcaBiblioteca.Negocio;

namespace AcaBiblioteca
{
    public partial class FrmInicio : Form
    {
        public FrmInicio()
        {
            InitializeComponent();
            MostrarResumen();
        }

        /// <summary>Muestra en tarjetas los totales generales de la biblioteca.</summary>
        private void MostrarResumen()
        {
            try
            {
                var resumen = new ReporteNegocio().Resumen();
                if (resumen.Rows.Count == 0)
                    return;

                flpResumen.Controls.Clear();

                foreach (System.Data.DataColumn columna in resumen.Columns)
                {
                    flpResumen.Controls.Add(CrearTarjeta(columna.ColumnName, resumen.Rows[0][columna].ToString() ?? "0"));
                }
            }
            catch (Exception ex)
            {
                // La pantalla de inicio no debe bloquear la aplicación si no hay conexión
                Mensajes.Advertencia("No se pudo conectar con la base de datos para mostrar el resumen.\n" + ex.Message);
            }
        }

        private static Panel CrearTarjeta(string titulo, string valor)
        {
            var tarjeta = new Panel
            {
                Size = new Size(200, 110),
                Margin = new Padding(10),
                BackColor = Color.AliceBlue,
                BorderStyle = BorderStyle.FixedSingle
            };

            var lblValor = new Label
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 24F, FontStyle.Bold),
                ForeColor = Color.RoyalBlue,
                Text = valor,
                TextAlign = ContentAlignment.MiddleCenter
            };

            var lblTitulo = new Label
            {
                Dock = DockStyle.Bottom,
                Height = 34,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Text = titulo,
                TextAlign = ContentAlignment.MiddleCenter
            };

            tarjeta.Controls.Add(lblValor);
            tarjeta.Controls.Add(lblTitulo);
            return tarjeta;
        }
    }
}
