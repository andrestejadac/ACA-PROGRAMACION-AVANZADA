namespace AcaBiblioteca
{
    partial class FrmReportes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvReporte = new DataGridView();
            pnlPie = new Panel();
            pnlOpciones = new Panel();
            pnlTitulo = new Panel();
            lblTitulo = new Label();
            lblReporte = new Label();
            cmbReporte = new ComboBox();
            btnGenerar = new Button();
            lblTotal = new Label();
            pnlPie.SuspendLayout();
            pnlOpciones.SuspendLayout();
            pnlTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReporte).BeginInit();
            SuspendLayout();
            // 
            // dgvReporte
            // 
            dgvReporte.AllowUserToAddRows = false;
            dgvReporte.AllowUserToDeleteRows = false;
            dgvReporte.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReporte.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReporte.Dock = DockStyle.Fill;
            dgvReporte.Location = new Point(0, 0);
            dgvReporte.MultiSelect = false;
            dgvReporte.ReadOnly = true;
            dgvReporte.RowHeadersWidth = 62;
            dgvReporte.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReporte.Size = new Size(1029, 200);
            dgvReporte.TabIndex = 3;
            dgvReporte.Name = "dgvReporte";
            // 
            // pnlPie
            // 
            pnlPie.BackColor = Color.WhiteSmoke;
            pnlPie.Dock = DockStyle.Bottom;
            pnlPie.Location = new Point(0, 434);
            pnlPie.Size = new Size(1029, 40);
            pnlPie.TabIndex = 2;
            pnlPie.Name = "pnlPie";
            // 
            // pnlOpciones
            // 
            pnlOpciones.BackColor = Color.WhiteSmoke;
            pnlOpciones.Dock = DockStyle.Top;
            pnlOpciones.Location = new Point(0, 0);
            pnlOpciones.Size = new Size(1029, 70);
            pnlOpciones.TabIndex = 1;
            pnlOpciones.Name = "pnlOpciones";
            // 
            // pnlTitulo
            // 
            pnlTitulo.BackColor = Color.RoyalBlue;
            pnlTitulo.Dock = DockStyle.Top;
            pnlTitulo.Location = new Point(0, 0);
            pnlTitulo.Size = new Size(1029, 60);
            pnlTitulo.TabIndex = 0;
            pnlTitulo.Name = "pnlTitulo";
            // 
            // lblTitulo
            // 
            lblTitulo.BackColor = Color.Transparent;
            lblTitulo.Dock = DockStyle.Fill;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Size = new Size(1029, 60);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "REPORTES DE LA BIBLIOTECA";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            lblTitulo.Name = "lblTitulo";
            // 
            // lblReporte
            // 
            lblReporte.AutoSize = true;
            lblReporte.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblReporte.Location = new Point(20, 22);
            lblReporte.Size = new Size(80, 23);
            lblReporte.Text = "Reporte:";
            lblReporte.Name = "lblReporte";
            // 
            // cmbReporte
            // 
            cmbReporte.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbReporte.FormattingEnabled = true;
            cmbReporte.Location = new Point(120, 18);
            cmbReporte.Size = new Size(420, 33);
            cmbReporte.TabIndex = 0;
            cmbReporte.Name = "cmbReporte";
            // 
            // btnGenerar
            // 
            btnGenerar.Location = new Point(560, 15);
            btnGenerar.Size = new Size(140, 40);
            btnGenerar.TabIndex = 1;
            btnGenerar.Text = "Generar";
            btnGenerar.UseVisualStyleBackColor = true;
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Click += btnGenerar_Click;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.Location = new Point(20, 8);
            lblTotal.Size = new Size(150, 23);
            lblTotal.Text = "Registros: 0";
            lblTotal.Name = "lblTotal";
            pnlTitulo.Controls.Add(lblTitulo);
            pnlOpciones.Controls.Add(lblReporte);
            pnlOpciones.Controls.Add(cmbReporte);
            pnlOpciones.Controls.Add(btnGenerar);
            pnlPie.Controls.Add(lblTotal);
            // 
            // FrmReportes
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1029, 474);
            Text = "FrmReportes";
            Controls.Add(dgvReporte);
            Controls.Add(pnlPie);
            Controls.Add(pnlOpciones);
            Controls.Add(pnlTitulo);
            Name = "FrmReportes";
            pnlPie.ResumeLayout(false);
            pnlOpciones.ResumeLayout(false);
            pnlTitulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvReporte).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvReporte;
        private Panel pnlPie;
        private Panel pnlOpciones;
        private Panel pnlTitulo;
        private Label lblTitulo;
        private Label lblReporte;
        private ComboBox cmbReporte;
        private Button btnGenerar;
        private Label lblTotal;
    }
}
