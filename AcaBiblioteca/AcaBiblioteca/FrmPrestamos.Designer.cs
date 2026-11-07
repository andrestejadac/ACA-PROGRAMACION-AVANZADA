namespace AcaBiblioteca
{
    partial class FrmPrestamos
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
            dgvPrestamos = new DataGridView();
            pnlFiltro = new Panel();
            pnlAcciones = new Panel();
            pnlTitulo = new Panel();
            lblTitulo = new Label();
            lblFiltro = new Label();
            cmbFiltroEstado = new ComboBox();
            lblAyuda = new Label();
            grpNuevo = new GroupBox();
            lblUsuario = new Label();
            cmbUsuario = new ComboBox();
            lblLibro = new Label();
            cmbLibro = new ComboBox();
            lblFechaPrestamo = new Label();
            dtpFechaPrestamo = new DateTimePicker();
            btnRegistrar = new Button();
            grpDevolucion = new GroupBox();
            lblFechaDevolucion = new Label();
            dtpFechaDevolucion = new DateTimePicker();
            btnDevolver = new Button();
            lblFechaEdicion = new Label();
            dtpFechaEdicion = new DateTimePicker();
            btnEditarFecha = new Button();
            btnEliminar = new Button();
            pnlFiltro.SuspendLayout();
            pnlAcciones.SuspendLayout();
            pnlTitulo.SuspendLayout();
            grpNuevo.SuspendLayout();
            grpDevolucion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPrestamos).BeginInit();
            SuspendLayout();
            // 
            // dgvPrestamos
            // 
            dgvPrestamos.AllowUserToAddRows = false;
            dgvPrestamos.AllowUserToDeleteRows = false;
            dgvPrestamos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPrestamos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPrestamos.Dock = DockStyle.Fill;
            dgvPrestamos.Location = new Point(0, 0);
            dgvPrestamos.MultiSelect = false;
            dgvPrestamos.ReadOnly = true;
            dgvPrestamos.RowHeadersWidth = 62;
            dgvPrestamos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPrestamos.Size = new Size(1029, 200);
            dgvPrestamos.TabIndex = 3;
            dgvPrestamos.Name = "dgvPrestamos";
            dgvPrestamos.CellClick += dgvPrestamos_CellClick;
            // 
            // pnlFiltro
            // 
            pnlFiltro.BackColor = Color.WhiteSmoke;
            pnlFiltro.Dock = DockStyle.Top;
            pnlFiltro.Location = new Point(0, 0);
            pnlFiltro.Size = new Size(1029, 50);
            pnlFiltro.TabIndex = 2;
            pnlFiltro.Name = "pnlFiltro";
            // 
            // pnlAcciones
            // 
            pnlAcciones.Dock = DockStyle.Top;
            pnlAcciones.Location = new Point(0, 0);
            pnlAcciones.Size = new Size(1029, 215);
            pnlAcciones.TabIndex = 1;
            pnlAcciones.Name = "pnlAcciones";
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
            lblTitulo.Text = "GESTIÓN DE PRÉSTAMOS Y DEVOLUCIONES";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            lblTitulo.Name = "lblTitulo";
            // 
            // lblFiltro
            // 
            lblFiltro.AutoSize = true;
            lblFiltro.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFiltro.Location = new Point(20, 13);
            lblFiltro.Size = new Size(150, 23);
            lblFiltro.Text = "Mostrar préstamos:";
            lblFiltro.Name = "lblFiltro";
            // 
            // cmbFiltroEstado
            // 
            cmbFiltroEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltroEstado.FormattingEnabled = true;
            cmbFiltroEstado.Items.AddRange(new object[] { "Todos", "Prestado", "Devuelto" });
            cmbFiltroEstado.Location = new Point(190, 8);
            cmbFiltroEstado.Size = new Size(180, 33);
            cmbFiltroEstado.TabIndex = 0;
            cmbFiltroEstado.Name = "cmbFiltroEstado";
            cmbFiltroEstado.SelectedIndexChanged += cmbFiltroEstado_SelectedIndexChanged;
            // 
            // lblAyuda
            // 
            lblAyuda.AutoSize = true;
            lblAyuda.Location = new Point(400, 13);
            lblAyuda.Size = new Size(400, 25);
            lblAyuda.Text = "Seleccione un préstamo de la tabla para devolverlo, editarlo o eliminarlo.";
            lblAyuda.Name = "lblAyuda";
            // 
            // grpNuevo
            // 
            grpNuevo.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpNuevo.Location = new Point(20, 10);
            grpNuevo.Size = new Size(540, 195);
            grpNuevo.TabIndex = 0;
            grpNuevo.TabStop = false;
            grpNuevo.Text = "Nuevo préstamo";
            grpNuevo.Name = "grpNuevo";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsuario.Location = new Point(20, 40);
            lblUsuario.Size = new Size(80, 23);
            lblUsuario.Text = "Usuario:";
            lblUsuario.Name = "lblUsuario";
            // 
            // cmbUsuario
            // 
            cmbUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUsuario.FormattingEnabled = true;
            cmbUsuario.Location = new Point(150, 36);
            cmbUsuario.Size = new Size(370, 33);
            cmbUsuario.TabIndex = 0;
            cmbUsuario.Name = "cmbUsuario";
            // 
            // lblLibro
            // 
            lblLibro.AutoSize = true;
            lblLibro.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLibro.Location = new Point(20, 85);
            lblLibro.Size = new Size(60, 23);
            lblLibro.Text = "Libro:";
            lblLibro.Name = "lblLibro";
            // 
            // cmbLibro
            // 
            cmbLibro.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLibro.FormattingEnabled = true;
            cmbLibro.Location = new Point(150, 81);
            cmbLibro.Size = new Size(370, 33);
            cmbLibro.TabIndex = 1;
            cmbLibro.Name = "cmbLibro";
            // 
            // lblFechaPrestamo
            // 
            lblFechaPrestamo.AutoSize = true;
            lblFechaPrestamo.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFechaPrestamo.Location = new Point(20, 130);
            lblFechaPrestamo.Size = new Size(130, 23);
            lblFechaPrestamo.Text = "Fecha préstamo:";
            lblFechaPrestamo.Name = "lblFechaPrestamo";
            // 
            // dtpFechaPrestamo
            // 
            dtpFechaPrestamo.Format = DateTimePickerFormat.Short;
            dtpFechaPrestamo.Location = new Point(150, 126);
            dtpFechaPrestamo.Size = new Size(150, 31);
            dtpFechaPrestamo.TabIndex = 2;
            dtpFechaPrestamo.Name = "dtpFechaPrestamo";
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(330, 124);
            btnRegistrar.Size = new Size(190, 40);
            btnRegistrar.TabIndex = 3;
            btnRegistrar.Text = "Registrar préstamo";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // grpDevolucion
            // 
            grpDevolucion.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpDevolucion.Location = new Point(580, 10);
            grpDevolucion.Size = new Size(540, 195);
            grpDevolucion.TabIndex = 1;
            grpDevolucion.TabStop = false;
            grpDevolucion.Text = "Devolución y edición del préstamo seleccionado";
            grpDevolucion.Name = "grpDevolucion";
            // 
            // lblFechaDevolucion
            // 
            lblFechaDevolucion.AutoSize = true;
            lblFechaDevolucion.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFechaDevolucion.Location = new Point(20, 40);
            lblFechaDevolucion.Size = new Size(140, 23);
            lblFechaDevolucion.Text = "Fecha devolución:";
            lblFechaDevolucion.Name = "lblFechaDevolucion";
            // 
            // dtpFechaDevolucion
            // 
            dtpFechaDevolucion.Format = DateTimePickerFormat.Short;
            dtpFechaDevolucion.Location = new Point(180, 36);
            dtpFechaDevolucion.Size = new Size(150, 31);
            dtpFechaDevolucion.TabIndex = 0;
            dtpFechaDevolucion.Name = "dtpFechaDevolucion";
            // 
            // btnDevolver
            // 
            btnDevolver.Location = new Point(350, 32);
            btnDevolver.Size = new Size(170, 40);
            btnDevolver.TabIndex = 1;
            btnDevolver.Text = "Registrar devolución";
            btnDevolver.UseVisualStyleBackColor = true;
            btnDevolver.Name = "btnDevolver";
            btnDevolver.Click += btnDevolver_Click;
            // 
            // lblFechaEdicion
            // 
            lblFechaEdicion.AutoSize = true;
            lblFechaEdicion.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFechaEdicion.Location = new Point(20, 95);
            lblFechaEdicion.Size = new Size(140, 23);
            lblFechaEdicion.Text = "Fecha préstamo:";
            lblFechaEdicion.Name = "lblFechaEdicion";
            // 
            // dtpFechaEdicion
            // 
            dtpFechaEdicion.Format = DateTimePickerFormat.Short;
            dtpFechaEdicion.Location = new Point(180, 91);
            dtpFechaEdicion.Size = new Size(150, 31);
            dtpFechaEdicion.TabIndex = 2;
            dtpFechaEdicion.Name = "dtpFechaEdicion";
            // 
            // btnEditarFecha
            // 
            btnEditarFecha.Location = new Point(350, 87);
            btnEditarFecha.Size = new Size(170, 40);
            btnEditarFecha.TabIndex = 3;
            btnEditarFecha.Text = "Editar fecha";
            btnEditarFecha.UseVisualStyleBackColor = true;
            btnEditarFecha.Name = "btnEditarFecha";
            btnEditarFecha.Click += btnEditarFecha_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(350, 140);
            btnEliminar.Size = new Size(170, 40);
            btnEliminar.TabIndex = 4;
            btnEliminar.Text = "Eliminar préstamo";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Click += btnEliminar_Click;
            pnlTitulo.Controls.Add(lblTitulo);
            pnlFiltro.Controls.Add(lblFiltro);
            pnlFiltro.Controls.Add(cmbFiltroEstado);
            pnlFiltro.Controls.Add(lblAyuda);
            pnlAcciones.Controls.Add(grpNuevo);
            grpNuevo.Controls.Add(lblUsuario);
            grpNuevo.Controls.Add(cmbUsuario);
            grpNuevo.Controls.Add(lblLibro);
            grpNuevo.Controls.Add(cmbLibro);
            grpNuevo.Controls.Add(lblFechaPrestamo);
            grpNuevo.Controls.Add(dtpFechaPrestamo);
            grpNuevo.Controls.Add(btnRegistrar);
            pnlAcciones.Controls.Add(grpDevolucion);
            grpDevolucion.Controls.Add(lblFechaDevolucion);
            grpDevolucion.Controls.Add(dtpFechaDevolucion);
            grpDevolucion.Controls.Add(btnDevolver);
            grpDevolucion.Controls.Add(lblFechaEdicion);
            grpDevolucion.Controls.Add(dtpFechaEdicion);
            grpDevolucion.Controls.Add(btnEditarFecha);
            grpDevolucion.Controls.Add(btnEliminar);
            // 
            // FrmPrestamos
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1029, 474);
            Text = "FrmPrestamos";
            Controls.Add(dgvPrestamos);
            Controls.Add(pnlFiltro);
            Controls.Add(pnlAcciones);
            Controls.Add(pnlTitulo);
            Name = "FrmPrestamos";
            pnlFiltro.ResumeLayout(false);
            pnlAcciones.ResumeLayout(false);
            pnlTitulo.ResumeLayout(false);
            grpNuevo.ResumeLayout(false);
            grpDevolucion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPrestamos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvPrestamos;
        private Panel pnlFiltro;
        private Panel pnlAcciones;
        private Panel pnlTitulo;
        private Label lblTitulo;
        private Label lblFiltro;
        private ComboBox cmbFiltroEstado;
        private Label lblAyuda;
        private GroupBox grpNuevo;
        private Label lblUsuario;
        private ComboBox cmbUsuario;
        private Label lblLibro;
        private ComboBox cmbLibro;
        private Label lblFechaPrestamo;
        private DateTimePicker dtpFechaPrestamo;
        private Button btnRegistrar;
        private GroupBox grpDevolucion;
        private Label lblFechaDevolucion;
        private DateTimePicker dtpFechaDevolucion;
        private Button btnDevolver;
        private Label lblFechaEdicion;
        private DateTimePicker dtpFechaEdicion;
        private Button btnEditarFecha;
        private Button btnEliminar;
    }
}
