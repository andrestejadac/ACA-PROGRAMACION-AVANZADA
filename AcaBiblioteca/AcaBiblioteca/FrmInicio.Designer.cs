namespace AcaBiblioteca
{
    partial class FrmInicio
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
            flpResumen = new FlowLayoutPanel();
            pnlBienvenida = new Panel();
            lblDescripcion = new Label();
            lblBienvenida = new Label();
            flpResumen.SuspendLayout();
            pnlBienvenida.SuspendLayout();
            SuspendLayout();
            // 
            // flpResumen
            // 
            flpResumen.Dock = DockStyle.Fill;
            flpResumen.Location = new Point(0, 0);
            flpResumen.Padding = new Padding(30, 10, 10, 10);
            flpResumen.Size = new Size(1029, 300);
            flpResumen.TabIndex = 1;
            flpResumen.Name = "flpResumen";
            // 
            // pnlBienvenida
            // 
            pnlBienvenida.BackColor = Color.RoyalBlue;
            pnlBienvenida.Dock = DockStyle.Top;
            pnlBienvenida.Location = new Point(0, 0);
            pnlBienvenida.Size = new Size(1029, 130);
            pnlBienvenida.TabIndex = 0;
            pnlBienvenida.Name = "pnlBienvenida";
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = false;
            lblDescripcion.BackColor = Color.Transparent;
            lblDescripcion.Dock = DockStyle.Fill;
            lblDescripcion.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDescripcion.ForeColor = Color.White;
            lblDescripcion.Location = new Point(0, 75);
            lblDescripcion.Size = new Size(1029, 55);
            lblDescripcion.TabIndex = 1;
            lblDescripcion.Text = "Use el menú de la izquierda para administrar libros, usuarios, autores, editoriales, préstamos y reportes.";
            lblDescripcion.TextAlign = ContentAlignment.TopCenter;
            lblDescripcion.Name = "lblDescripcion";
            // 
            // lblBienvenida
            // 
            lblBienvenida.AutoSize = false;
            lblBienvenida.BackColor = Color.Transparent;
            lblBienvenida.Dock = DockStyle.Top;
            lblBienvenida.Font = new Font("Segoe UI", 22F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBienvenida.ForeColor = Color.White;
            lblBienvenida.Location = new Point(0, 0);
            lblBienvenida.Size = new Size(1029, 75);
            lblBienvenida.TabIndex = 0;
            lblBienvenida.Text = "Bienvenido al Sistema de Gestión de Biblioteca";
            lblBienvenida.TextAlign = ContentAlignment.MiddleCenter;
            lblBienvenida.Name = "lblBienvenida";
            pnlBienvenida.Controls.Add(lblDescripcion);
            pnlBienvenida.Controls.Add(lblBienvenida);
            // 
            // FrmInicio
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1029, 474);
            Text = "FrmInicio";
            Controls.Add(flpResumen);
            Controls.Add(pnlBienvenida);
            Name = "FrmInicio";
            flpResumen.ResumeLayout(false);
            pnlBienvenida.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flpResumen;
        private Panel pnlBienvenida;
        private Label lblDescripcion;
        private Label lblBienvenida;
    }
}
