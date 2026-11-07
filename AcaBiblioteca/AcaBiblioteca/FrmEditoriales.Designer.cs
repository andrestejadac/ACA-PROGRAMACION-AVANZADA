namespace AcaBiblioteca
{
    partial class FrmEditoriales
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
            dgvEditoriales = new DataGridView();
            pnlBotones = new Panel();
            pnlDatos = new Panel();
            pnlTitulo = new Panel();
            lblTitulo = new Label();
            lblNombre = new Label();
            txtNombre = new TextBox();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnCancelar = new Button();
            pnlBotones.SuspendLayout();
            pnlDatos.SuspendLayout();
            pnlTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEditoriales).BeginInit();
            SuspendLayout();
            // 
            // dgvEditoriales
            // 
            dgvEditoriales.AllowUserToAddRows = false;
            dgvEditoriales.AllowUserToDeleteRows = false;
            dgvEditoriales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEditoriales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEditoriales.Dock = DockStyle.Fill;
            dgvEditoriales.Location = new Point(0, 0);
            dgvEditoriales.MultiSelect = false;
            dgvEditoriales.ReadOnly = true;
            dgvEditoriales.RowHeadersWidth = 62;
            dgvEditoriales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEditoriales.Size = new Size(1029, 200);
            dgvEditoriales.TabIndex = 3;
            dgvEditoriales.Name = "dgvEditoriales";
            dgvEditoriales.CellDoubleClick += dgvEditoriales_CellDoubleClick;
            dgvEditoriales.CellClick += dgvEditoriales_CellClick;
            // 
            // pnlBotones
            // 
            pnlBotones.Dock = DockStyle.Top;
            pnlBotones.Location = new Point(0, 0);
            pnlBotones.Size = new Size(1029, 60);
            pnlBotones.TabIndex = 2;
            pnlBotones.Name = "pnlBotones";
            // 
            // pnlDatos
            // 
            pnlDatos.Dock = DockStyle.Top;
            pnlDatos.Location = new Point(0, 0);
            pnlDatos.Size = new Size(1029, 80);
            pnlDatos.TabIndex = 1;
            pnlDatos.Name = "pnlDatos";
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
            lblTitulo.Text = "GESTIÓN DE EDITORIALES";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            lblTitulo.Name = "lblTitulo";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNombre.Location = new Point(60, 23);
            lblNombre.Size = new Size(120, 23);
            lblNombre.Text = "Nombre:";
            lblNombre.Name = "lblNombre";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(230, 20);
            txtNombre.Size = new Size(320, 31);
            txtNombre.TabIndex = 0;
            txtNombre.Name = "txtNombre";
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(60, 10);
            btnNuevo.Size = new Size(140, 40);
            btnNuevo.TabIndex = 0;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(215, 10);
            btnGuardar.Size = new Size(140, 40);
            btnGuardar.TabIndex = 1;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(370, 10);
            btnEditar.Size = new Size(140, 40);
            btnEditar.TabIndex = 2;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Name = "btnEditar";
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(525, 10);
            btnEliminar.Size = new Size(140, 40);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(680, 10);
            btnCancelar.Size = new Size(140, 40);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Click += btnCancelar_Click;
            pnlTitulo.Controls.Add(lblTitulo);
            pnlDatos.Controls.Add(lblNombre);
            pnlDatos.Controls.Add(txtNombre);
            pnlBotones.Controls.Add(btnNuevo);
            pnlBotones.Controls.Add(btnGuardar);
            pnlBotones.Controls.Add(btnEditar);
            pnlBotones.Controls.Add(btnEliminar);
            pnlBotones.Controls.Add(btnCancelar);
            // 
            // FrmEditoriales
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1029, 474);
            Text = "FrmEditoriales";
            Controls.Add(dgvEditoriales);
            Controls.Add(pnlBotones);
            Controls.Add(pnlDatos);
            Controls.Add(pnlTitulo);
            Name = "FrmEditoriales";
            pnlBotones.ResumeLayout(false);
            pnlDatos.ResumeLayout(false);
            pnlTitulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvEditoriales).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvEditoriales;
        private Panel pnlBotones;
        private Panel pnlDatos;
        private Panel pnlTitulo;
        private Label lblTitulo;
        private Label lblNombre;
        private TextBox txtNombre;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnEditar;
        private Button btnEliminar;
        private Button btnCancelar;
    }
}
