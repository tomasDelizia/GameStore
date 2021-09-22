
namespace GameStore.InterfacesDeUsuario.PresentacionEmpleados
{
    partial class ConsultaEmpleado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsultaEmpleado));
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReiniciarFiltros = new System.Windows.Forms.Button();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.dgvEmpleados = new System.Windows.Forms.DataGridView();
            this.IdEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NroDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEmpleado = new System.Windows.Forms.TextBox();
            this.cboCargos = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).BeginInit();
            this.SuspendLayout();
            // 
            // btnModificar
            // 
            this.btnModificar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnModificar.BackgroundImage")));
            this.btnModificar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnModificar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.Color.DimGray;
            this.btnModificar.Location = new System.Drawing.Point(61, 298);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(40, 40);
            this.btnModificar.TabIndex = 113;
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar.BackgroundImage")));
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.DimGray;
            this.btnAgregar.Location = new System.Drawing.Point(15, 298);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(40, 40);
            this.btnAgregar.TabIndex = 112;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminar.BackgroundImage")));
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.DimGray;
            this.btnEliminar.Location = new System.Drawing.Point(107, 298);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(40, 40);
            this.btnEliminar.TabIndex = 114;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Controls.Add(this.btnReiniciarFiltros);
            this.panel1.Controls.Add(this.btnFiltrar);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtEmpleado);
            this.panel1.Controls.Add(this.cboCargos);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(601, 145);
            this.panel1.TabIndex = 115;
            // 
            // btnReiniciarFiltros
            // 
            this.btnReiniciarFiltros.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReiniciarFiltros.ForeColor = System.Drawing.Color.DimGray;
            this.btnReiniciarFiltros.Location = new System.Drawing.Point(457, 95);
            this.btnReiniciarFiltros.Name = "btnReiniciarFiltros";
            this.btnReiniciarFiltros.Size = new System.Drawing.Size(136, 29);
            this.btnReiniciarFiltros.TabIndex = 103;
            this.btnReiniciarFiltros.Text = "Reiniciar filtros";
            this.btnReiniciarFiltros.UseVisualStyleBackColor = true;
            this.btnReiniciarFiltros.Click += new System.EventHandler(this.btnReiniciarFiltros_Click);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrar.ForeColor = System.Drawing.Color.DimGray;
            this.btnFiltrar.Location = new System.Drawing.Point(493, 58);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(100, 29);
            this.btnFiltrar.TabIndex = 102;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // dgvEmpleados
            // 
            this.dgvEmpleados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvEmpleados.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvEmpleados.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmpleados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdEmpleado,
            this.NroDocumento,
            this.Nombre,
            this.Apellido,
            this.Email,
            this.Cargo});
            this.dgvEmpleados.Location = new System.Drawing.Point(12, 163);
            this.dgvEmpleados.Name = "dgvEmpleados";
            this.dgvEmpleados.Size = new System.Drawing.Size(601, 129);
            this.dgvEmpleados.TabIndex = 41;
            // 
            // IdEmpleado
            // 
            this.IdEmpleado.HeaderText = "IdEmpleado";
            this.IdEmpleado.Name = "IdEmpleado";
            this.IdEmpleado.ReadOnly = true;
            this.IdEmpleado.Visible = false;
            // 
            // NroDocumento
            // 
            this.NroDocumento.HeaderText = "N° Documento";
            this.NroDocumento.Name = "NroDocumento";
            this.NroDocumento.ReadOnly = true;
            this.NroDocumento.Width = 102;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 69;
            // 
            // Apellido
            // 
            this.Apellido.HeaderText = "Apellido";
            this.Apellido.Name = "Apellido";
            this.Apellido.ReadOnly = true;
            this.Apellido.Width = 69;
            // 
            // Email
            // 
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            this.Email.Width = 57;
            // 
            // Cargo
            // 
            this.Cargo.HeaderText = "Cargo";
            this.Cargo.Name = "Cargo";
            this.Cargo.ReadOnly = true;
            this.Cargo.Width = 60;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DimGray;
            this.label8.Location = new System.Drawing.Point(21, 97);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 22);
            this.label8.TabIndex = 91;
            this.label8.Text = "Cargo:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(6, 62);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 22);
            this.label5.TabIndex = 90;
            this.label5.Text = "Nombre:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(229, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 33);
            this.label4.TabIndex = 89;
            this.label4.Text = "Búsqueda";
            // 
            // txtEmpleado
            // 
            this.txtEmpleado.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmpleado.Location = new System.Drawing.Point(95, 60);
            this.txtEmpleado.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtEmpleado.Name = "txtEmpleado";
            this.txtEmpleado.Size = new System.Drawing.Size(200, 27);
            this.txtEmpleado.TabIndex = 44;
            // 
            // cboCargos
            // 
            this.cboCargos.BackColor = System.Drawing.Color.White;
            this.cboCargos.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCargos.ForeColor = System.Drawing.Color.DimGray;
            this.cboCargos.FormattingEnabled = true;
            this.cboCargos.Location = new System.Drawing.Point(95, 95);
            this.cboCargos.Name = "cboCargos";
            this.cboCargos.Size = new System.Drawing.Size(200, 29);
            this.cboCargos.TabIndex = 54;
            this.cboCargos.Text = "Selección";
            // 
            // ConsultaEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(630, 347);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dgvEmpleados);
            this.Controls.Add(this.btnEliminar);
            this.Name = "ConsultaEmpleado";
            this.Text = "Consultar Empleados";
            this.Load += new System.EventHandler(this.ConsultaEmpleado_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnReiniciarFiltros;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.DataGridView dgvEmpleados;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn NroDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cargo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEmpleado;
        private System.Windows.Forms.ComboBox cboCargos;
    }
}