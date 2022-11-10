namespace El_Sabroso_App.CapaPresentacion.abmPro
{
    partial class frmConsultaPro
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
            this.dgvProv = new System.Windows.Forms.DataGridView();
            this.id_prov = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ciudad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_alta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbFiltros = new System.Windows.Forms.GroupBox();
            this.checkFecha = new System.Windows.Forms.CheckBox();
            this.checkActivo = new System.Windows.Forms.CheckBox();
            this.dtpFechaAlta = new System.Windows.Forms.DateTimePicker();
            this.txtCiudad = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDarBaja = new System.Windows.Forms.Button();
            this.btnLimpiarDatos = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProv)).BeginInit();
            this.grbFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvProv
            // 
            this.dgvProv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_prov,
            this.nombre,
            this.apellido,
            this.email,
            this.telefono,
            this.direccion,
            this.ciudad,
            this.fecha_alta});
            this.dgvProv.Location = new System.Drawing.Point(3, 21);
            this.dgvProv.Name = "dgvProv";
            this.dgvProv.RowTemplate.Height = 25;
            this.dgvProv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProv.Size = new System.Drawing.Size(851, 219);
            this.dgvProv.TabIndex = 0;
            // 
            // id_prov
            // 
            this.id_prov.DataPropertyName = "id_proveedor";
            this.id_prov.HeaderText = "ID PROV";
            this.id_prov.Name = "id_prov";
            this.id_prov.ReadOnly = true;
            // 
            // nombre
            // 
            this.nombre.DataPropertyName = "nombre";
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            // 
            // apellido
            // 
            this.apellido.DataPropertyName = "apellido";
            this.apellido.HeaderText = "Apellido";
            this.apellido.Name = "apellido";
            this.apellido.ReadOnly = true;
            // 
            // email
            // 
            this.email.DataPropertyName = "email";
            this.email.HeaderText = "Email";
            this.email.Name = "email";
            this.email.ReadOnly = true;
            // 
            // telefono
            // 
            this.telefono.DataPropertyName = "telefono";
            this.telefono.HeaderText = "Telefono";
            this.telefono.Name = "telefono";
            this.telefono.ReadOnly = true;
            // 
            // direccion
            // 
            this.direccion.DataPropertyName = "direccion";
            this.direccion.HeaderText = "Direccion";
            this.direccion.Name = "direccion";
            this.direccion.ReadOnly = true;
            // 
            // ciudad
            // 
            this.ciudad.DataPropertyName = "ciudad";
            this.ciudad.HeaderText = "Ciudad";
            this.ciudad.Name = "ciudad";
            this.ciudad.ReadOnly = true;
            // 
            // fecha_alta
            // 
            this.fecha_alta.DataPropertyName = "fecha_alta";
            this.fecha_alta.HeaderText = "Fecha Alta";
            this.fecha_alta.Name = "fecha_alta";
            this.fecha_alta.ReadOnly = true;
            // 
            // grbFiltros
            // 
            this.grbFiltros.Controls.Add(this.checkFecha);
            this.grbFiltros.Controls.Add(this.checkActivo);
            this.grbFiltros.Controls.Add(this.dtpFechaAlta);
            this.grbFiltros.Controls.Add(this.txtCiudad);
            this.grbFiltros.Controls.Add(this.txtTelefono);
            this.grbFiltros.Controls.Add(this.txtApellido);
            this.grbFiltros.Controls.Add(this.txtNombre);
            this.grbFiltros.Controls.Add(this.label7);
            this.grbFiltros.Controls.Add(this.label6);
            this.grbFiltros.Controls.Add(this.label4);
            this.grbFiltros.Controls.Add(this.label2);
            this.grbFiltros.Controls.Add(this.label1);
            this.grbFiltros.Location = new System.Drawing.Point(38, 259);
            this.grbFiltros.Name = "grbFiltros";
            this.grbFiltros.Size = new System.Drawing.Size(810, 110);
            this.grbFiltros.TabIndex = 1;
            this.grbFiltros.TabStop = false;
            this.grbFiltros.Text = "FiltrosDeBusquedas";
            // 
            // checkFecha
            // 
            this.checkFecha.AutoSize = true;
            this.checkFecha.Location = new System.Drawing.Point(708, 65);
            this.checkFecha.Name = "checkFecha";
            this.checkFecha.Size = new System.Drawing.Size(15, 14);
            this.checkFecha.TabIndex = 15;
            this.checkFecha.UseVisualStyleBackColor = true;
            // 
            // checkActivo
            // 
            this.checkActivo.AutoSize = true;
            this.checkActivo.Checked = true;
            this.checkActivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkActivo.Location = new System.Drawing.Point(525, 27);
            this.checkActivo.Name = "checkActivo";
            this.checkActivo.Size = new System.Drawing.Size(60, 19);
            this.checkActivo.TabIndex = 14;
            this.checkActivo.Text = "Activo";
            this.checkActivo.UseVisualStyleBackColor = true;
            // 
            // dtpFechaAlta
            // 
            this.dtpFechaAlta.Location = new System.Drawing.Point(593, 62);
            this.dtpFechaAlta.Name = "dtpFechaAlta";
            this.dtpFechaAlta.Size = new System.Drawing.Size(100, 23);
            this.dtpFechaAlta.TabIndex = 13;
            // 
            // txtCiudad
            // 
            this.txtCiudad.Location = new System.Drawing.Point(371, 61);
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.Size = new System.Drawing.Size(100, 23);
            this.txtCiudad.TabIndex = 12;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(371, 28);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(100, 23);
            this.txtTelefono.TabIndex = 10;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(96, 61);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(129, 23);
            this.txtApellido.TabIndex = 8;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(96, 28);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(129, 23);
            this.txtNombre.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(525, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "FechaAlta:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(305, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Ciudad:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(305, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Telefono:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Apellido:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // btnDarBaja
            // 
            this.btnDarBaja.Location = new System.Drawing.Point(107, 402);
            this.btnDarBaja.Name = "btnDarBaja";
            this.btnDarBaja.Size = new System.Drawing.Size(96, 23);
            this.btnDarBaja.TabIndex = 2;
            this.btnDarBaja.Text = "Baja";
            this.btnDarBaja.UseVisualStyleBackColor = true;
            this.btnDarBaja.Click += new System.EventHandler(this.btnDarBaja_Click);
            // 
            // btnLimpiarDatos
            // 
            this.btnLimpiarDatos.Location = new System.Drawing.Point(261, 402);
            this.btnLimpiarDatos.Name = "btnLimpiarDatos";
            this.btnLimpiarDatos.Size = new System.Drawing.Size(121, 23);
            this.btnLimpiarDatos.TabIndex = 3;
            this.btnLimpiarDatos.Text = "Limpiar Datos";
            this.btnLimpiarDatos.UseVisualStyleBackColor = true;
            this.btnLimpiarDatos.Click += new System.EventHandler(this.btnLimpiarDatos_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(432, 402);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(94, 22);
            this.btnEditar.TabIndex = 4;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(584, 402);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // frmConsultaPro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 450);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnLimpiarDatos);
            this.Controls.Add(this.btnDarBaja);
            this.Controls.Add(this.grbFiltros);
            this.Controls.Add(this.dgvProv);
            this.Name = "frmConsultaPro";
            this.Text = "frmConsultaPro";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProv)).EndInit();
            this.grbFiltros.ResumeLayout(false);
            this.grbFiltros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dgvProv;
        private DataGridViewTextBoxColumn id_prov;
        private DataGridViewTextBoxColumn nombre;
        private DataGridViewTextBoxColumn apellido;
        private DataGridViewTextBoxColumn email;
        private DataGridViewTextBoxColumn telefono;
        private DataGridViewTextBoxColumn direccion;
        private DataGridViewTextBoxColumn ciudad;
        private DataGridViewTextBoxColumn fecha_alta;
        private GroupBox grbFiltros;
        private Label label2;
        private Label label1;
        private DateTimePicker dtpFechaAlta;
        private TextBox txtCiudad;
        private TextBox txtTelefono;
        private TextBox txtApellido;
        private TextBox txtNombre;
        private Label label7;
        private Label label6;
        private Label label4;
        private CheckBox checkActivo;
        private Button btnDarBaja;
        private Button btnLimpiarDatos;
        private Button btnEditar;
        private Button btnBuscar;
        private CheckBox checkFecha;
    }
}