
namespace GameStore.InterfacesDeUsuario.PresentacionArticulos
{
    partial class ConsultaArticulo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsultaArticulo));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReiniciarFiltros = new System.Windows.Forms.Button();
            this.numPrecioMax = new System.Windows.Forms.NumericUpDown();
            this.numPrecioMin = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboPlataforma = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.cboTipoArticulo = new System.Windows.Forms.ComboBox();
            this.dgvArticulos = new System.Windows.Forms.DataGridView();
            this.picArticulo = new System.Windows.Forms.PictureBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Plataforma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecioMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecioMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picArticulo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Controls.Add(this.btnReiniciarFiltros);
            this.panel1.Controls.Add(this.numPrecioMax);
            this.panel1.Controls.Add(this.numPrecioMin);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboPlataforma);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtNombre);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnFiltrar);
            this.panel1.Controls.Add(this.cboTipoArticulo);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(890, 191);
            this.panel1.TabIndex = 88;
            // 
            // btnReiniciarFiltros
            // 
            this.btnReiniciarFiltros.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReiniciarFiltros.ForeColor = System.Drawing.Color.DimGray;
            this.btnReiniciarFiltros.Location = new System.Drawing.Point(639, 154);
            this.btnReiniciarFiltros.Name = "btnReiniciarFiltros";
            this.btnReiniciarFiltros.Size = new System.Drawing.Size(136, 29);
            this.btnReiniciarFiltros.TabIndex = 101;
            this.btnReiniciarFiltros.Text = "Reiniciar filtros";
            this.btnReiniciarFiltros.UseVisualStyleBackColor = true;
            this.btnReiniciarFiltros.Click += new System.EventHandler(this.btnReiniciarFiltros_Click);
            // 
            // numPrecioMax
            // 
            this.numPrecioMax.DecimalPlaces = 2;
            this.numPrecioMax.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numPrecioMax.ForeColor = System.Drawing.Color.DimGray;
            this.numPrecioMax.Location = new System.Drawing.Point(240, 94);
            this.numPrecioMax.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.numPrecioMax.Name = "numPrecioMax";
            this.numPrecioMax.Size = new System.Drawing.Size(92, 27);
            this.numPrecioMax.TabIndex = 100;
            this.numPrecioMax.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // numPrecioMin
            // 
            this.numPrecioMin.DecimalPlaces = 2;
            this.numPrecioMin.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numPrecioMin.ForeColor = System.Drawing.Color.DimGray;
            this.numPrecioMin.Location = new System.Drawing.Point(99, 93);
            this.numPrecioMin.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.numPrecioMin.Name = "numPrecioMin";
            this.numPrecioMin.Size = new System.Drawing.Size(92, 27);
            this.numPrecioMin.TabIndex = 99;
            this.numPrecioMin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DimGray;
            this.label8.Location = new System.Drawing.Point(197, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 22);
            this.label8.TabIndex = 98;
            this.label8.Text = "y $";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(13, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 22);
            this.label7.TabIndex = 95;
            this.label7.Text = "Entre $";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(522, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 22);
            this.label6.TabIndex = 93;
            this.label6.Text = "Plataforma:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(484, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 22);
            this.label1.TabIndex = 91;
            this.label1.Text = "Tipo de artículo:";
            // 
            // cboPlataforma
            // 
            this.cboPlataforma.BackColor = System.Drawing.Color.White;
            this.cboPlataforma.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPlataforma.ForeColor = System.Drawing.Color.DimGray;
            this.cboPlataforma.FormattingEnabled = true;
            this.cboPlataforma.Location = new System.Drawing.Point(644, 94);
            this.cboPlataforma.Name = "cboPlataforma";
            this.cboPlataforma.Size = new System.Drawing.Size(242, 29);
            this.cboPlataforma.TabIndex = 90;
            this.cboPlataforma.Text = "Selección";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(379, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 33);
            this.label3.TabIndex = 88;
            this.label3.Text = "Búsqueda";
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.White;
            this.txtNombre.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.ForeColor = System.Drawing.Color.DimGray;
            this.txtNombre.Location = new System.Drawing.Point(99, 59);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(233, 27);
            this.txtNombre.TabIndex = 71;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(3, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 22);
            this.label2.TabIndex = 76;
            this.label2.Text = "Nombre:";
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrar.ForeColor = System.Drawing.Color.DimGray;
            this.btnFiltrar.Location = new System.Drawing.Point(781, 154);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(100, 29);
            this.btnFiltrar.TabIndex = 82;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // cboTipoArticulo
            // 
            this.cboTipoArticulo.BackColor = System.Drawing.Color.White;
            this.cboTipoArticulo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoArticulo.ForeColor = System.Drawing.Color.DimGray;
            this.cboTipoArticulo.FormattingEnabled = true;
            this.cboTipoArticulo.Location = new System.Drawing.Point(644, 59);
            this.cboTipoArticulo.Name = "cboTipoArticulo";
            this.cboTipoArticulo.Size = new System.Drawing.Size(242, 29);
            this.cboTipoArticulo.TabIndex = 72;
            this.cboTipoArticulo.Text = "Selección";
            // 
            // dgvArticulos
            // 
            this.dgvArticulos.AllowUserToAddRows = false;
            this.dgvArticulos.AllowUserToDeleteRows = false;
            this.dgvArticulos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticulos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Nombre,
            this.Precio,
            this.Stock,
            this.TipoArticulo,
            this.Plataforma});
            this.dgvArticulos.Location = new System.Drawing.Point(12, 209);
            this.dgvArticulos.Name = "dgvArticulos";
            this.dgvArticulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvArticulos.Size = new System.Drawing.Size(725, 200);
            this.dgvArticulos.TabIndex = 89;
            this.dgvArticulos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArticulos_CellClick);
            // 
            // picArticulo
            // 
            this.picArticulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picArticulo.Location = new System.Drawing.Point(752, 209);
            this.picArticulo.Name = "picArticulo";
            this.picArticulo.Size = new System.Drawing.Size(150, 200);
            this.picArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picArticulo.TabIndex = 90;
            this.picArticulo.TabStop = false;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar.BackgroundImage")));
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.DimGray;
            this.btnAgregar.Location = new System.Drawing.Point(12, 415);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(40, 40);
            this.btnAgregar.TabIndex = 101;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnModificar.BackgroundImage")));
            this.btnModificar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnModificar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.Color.DimGray;
            this.btnModificar.Location = new System.Drawing.Point(58, 415);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(40, 40);
            this.btnModificar.TabIndex = 102;
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminar.BackgroundImage")));
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.DimGray;
            this.btnEliminar.Location = new System.Drawing.Point(104, 415);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(40, 40);
            this.btnEliminar.TabIndex = 103;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.DimGray;
            this.btnSalir.Location = new System.Drawing.Point(809, 426);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(93, 29);
            this.btnSalir.TabIndex = 104;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Visible = false;
            this.Codigo.Width = 65;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 120;
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            this.Precio.Width = 114;
            // 
            // Stock
            // 
            this.Stock.HeaderText = "Stock";
            this.Stock.Name = "Stock";
            this.Stock.ReadOnly = true;
            this.Stock.Width = 113;
            // 
            // TipoArticulo
            // 
            this.TipoArticulo.HeaderText = "Tipo de Artículo";
            this.TipoArticulo.Name = "TipoArticulo";
            this.TipoArticulo.ReadOnly = true;
            this.TipoArticulo.Width = 114;
            // 
            // Plataforma
            // 
            this.Plataforma.HeaderText = "Plataforma";
            this.Plataforma.Name = "Plataforma";
            this.Plataforma.ReadOnly = true;
            this.Plataforma.Width = 114;
            // 
            // ConsultaArticulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(914, 464);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.picArticulo);
            this.Controls.Add(this.dgvArticulos);
            this.Controls.Add(this.panel1);
            this.Name = "ConsultaArticulo";
            this.Text = "Consultar Artículo";
            this.Load += new System.EventHandler(this.ConsultaArticulo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecioMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecioMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picArticulo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboPlataforma;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.ComboBox cboTipoArticulo;
        private System.Windows.Forms.NumericUpDown numPrecioMin;
        private System.Windows.Forms.DataGridView dgvArticulos;
        private System.Windows.Forms.PictureBox picArticulo;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnReiniciarFiltros;
        private System.Windows.Forms.NumericUpDown numPrecioMax;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Plataforma;
    }
}