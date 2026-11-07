namespace AcaBiblioteca
{
    partial class FrmUsuarios
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
            dgvUsuarios = new DataGridView();
            pnlBotones = new Panel();
            pnlDatos = new Panel();
            pnlTitulo = new Panel();
            lblTitulo = new Label();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblApellido = new Label();
            txtApellido = new TextBox();
            lblDocumento = new Label();
            txtDocumento = new TextBox();
            lblTelefono = new Label();
            txtTelefono = new TextBox();
            lblCorreo = new Label();
            txtCorreo = new TextBox();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnCancelar = new Button();
            pnlBotones.SuspendLayout();
            pnlDatos.SuspendLayout();
            pnlTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            SuspendLayout();
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AllowUserToDeleteRows = false;
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Dock = DockStyle.Fill;
            dgvUsuarios.Location = new Point(0, 0);
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.RowHeadersWidth = 62;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.Size = new Size(1029, 200);
            dgvUsuarios.TabIndex = 3;
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.CellDoubleClick += dgvUsuarios_CellDoubleClick;
            dgvUsuarios.CellClick += dgvUsuarios_CellClick;
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
            pnlDatos.Size = new Size(1029, 260);
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
            lblTitulo.Text = "GESTIÓN DE USUARIOS";
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
            // lblDocumento
            // 
            lblDocumento.AutoSize = true;
            lblDocumento.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDocumento.Location = new Point(60, 113);
            lblDocumento.Size = new Size(120, 23);
            lblDocumento.Text = "Documento:";
            lblDocumento.Name = "lblDocumento";
            // 
            // txtDocumento
            // 
            txtDocumento.Location = new Point(230, 110);
            txtDocumento.Size = new Size(320, 31);
            txtDocumento.TabIndex = 2;
            txtDocumento.Name = "txtDocumento";
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTelefono.Location = new Point(60, 158);
            lblTelefono.Size = new Size(120, 23);
            lblTelefono.Text = "Teléfono:";
            lblTelefono.Name = "lblTelefono";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(230, 155);
            txtTelefono.Size = new Size(320, 31);
            txtTelefono.TabIndex = 3;
            txtTelefono.Name = "txtTelefono";
            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCorreo.Location = new Point(60, 203);
            lblCorreo.Size = new Size(120, 23);
            lblCorreo.Text = "Correo:";
            lblCorreo.Name = "lblCorreo";
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(230, 200);
            txtCorreo.Size = new Size(320, 31);
            txtCorreo.TabIndex = 4;
            txtCorreo.Name = "txtCorreo";
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
            pnlDatos.Controls.Add(lblDocumento);
            pnlDatos.Controls.Add(txtDocumento);
            pnlDatos.Controls.Add(lblTelefono);
            pnlDatos.Controls.Add(txtTelefono);
            pnlDatos.Controls.Add(lblCorreo);
            pnlDatos.Controls.Add(txtCorreo);
            pnlBotones.Controls.Add(btnNuevo);
            pnlBotones.Controls.Add(btnGuardar);
            pnlBotones.Controls.Add(btnEditar);
            pnlBotones.Controls.Add(btnEliminar);
            pnlBotones.Controls.Add(btnCancelar);
            // 
            // FrmUsuarios
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1029, 474);
            Text = "FrmUsuarios";
            Controls.Add(dgvUsuarios);
            Controls.Add(pnlBotones);
            Controls.Add(pnlDatos);
            Controls.Add(pnlTitulo);
            Name = "FrmUsuarios";
            pnlBotones.ResumeLayout(false);
            pnlDatos.ResumeLayout(false);
            pnlTitulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvUsuarios;
        private Panel pnlBotones;
        private Panel pnlDatos;
        private Panel pnlTitulo;
        private Label lblTitulo;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblApellido;
        private TextBox txtApellido;
        private Label lblDocumento;
        private TextBox txtDocumento;
        private Label lblTelefono;
        private TextBox txtTelefono;
        private Label lblCorreo;
        private TextBox txtCorreo;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnEditar;
        private Button btnEliminar;
        private Button btnCancelar;
    }
}
