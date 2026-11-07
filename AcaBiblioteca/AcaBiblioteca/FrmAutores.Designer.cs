namespace AcaBiblioteca
{
    partial class FrmAutores
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
            dgvAutores = new DataGridView();
            pnlBotones = new Panel();
            pnlDatos = new Panel();
            pnlTitulo = new Panel();
            lblTitulo = new Label();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblApellido = new Label();
            txtApellido = new TextBox();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnCancelar = new Button();
            pnlBotones.SuspendLayout();
            pnlDatos.SuspendLayout();
            pnlTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAutores).BeginInit();
            SuspendLayout();
            // 
            // dgvAutores
            // 
            dgvAutores.AllowUserToAddRows = false;
            dgvAutores.AllowUserToDeleteRows = false;
            dgvAutores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAutores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAutores.Dock = DockStyle.Fill;
            dgvAutores.Location = new Point(0, 0);
            dgvAutores.MultiSelect = false;
            dgvAutores.ReadOnly = true;
            dgvAutores.RowHeadersWidth = 62;
            dgvAutores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAutores.Size = new Size(1029, 200);
            dgvAutores.TabIndex = 3;
            dgvAutores.Name = "dgvAutores";
            dgvAutores.CellDoubleClick += dgvAutores_CellDoubleClick;
            dgvAutores.CellClick += dgvAutores_CellClick;
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
            pnlDatos.Size = new Size(1029, 125);
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
            lblTitulo.Text = "GESTIÓN DE AUTORES";
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
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblApellido.Location = new Point(60, 68);
            lblApellido.Size = new Size(120, 23);
            lblApellido.Text = "Apellido:";
            lblApellido.Name = "lblApellido";
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(230, 65);
            txtApellido.Size = new Size(320, 31);
            txtApellido.TabIndex = 1;
            txtApellido.Name = "txtApellido";
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
            pnlDatos.Controls.Add(lblApellido);
            pnlDatos.Controls.Add(txtApellido);
            pnlBotones.Controls.Add(btnNuevo);
            pnlBotones.Controls.Add(btnGuardar);
            pnlBotones.Controls.Add(btnEditar);
            pnlBotones.Controls.Add(btnEliminar);
            pnlBotones.Controls.Add(btnCancelar);
            // 
            // FrmAutores
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1029, 474);
            Text = "FrmAutores";
            Controls.Add(dgvAutores);
            Controls.Add(pnlBotones);
            Controls.Add(pnlDatos);
            Controls.Add(pnlTitulo);
            Name = "FrmAutores";
            pnlBotones.ResumeLayout(false);
            pnlDatos.ResumeLayout(false);
            pnlTitulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAutores).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvAutores;
        private Panel pnlBotones;
        private Panel pnlDatos;
        private Panel pnlTitulo;
        private Label lblTitulo;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblApellido;
        private TextBox txtApellido;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnEditar;
        private Button btnEliminar;
        private Button btnCancelar;
    }
}
