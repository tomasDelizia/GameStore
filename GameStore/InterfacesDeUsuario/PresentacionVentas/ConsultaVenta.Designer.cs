
namespace GameStore.InterfacesDeUsuario.PresentacionVentas
{
    partial class ConsultaVenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsultaVenta));
            this.btnReiniciarFiltros = new System.Windows.Forms.Button();
            this.numPrecioMax = new System.Windows.Forms.NumericUpDown();
            this.numPrecioMin = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTiposFactura = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNroFactura = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnVerDetalle = new System.Windows.Forms.Button();
            this.cboFormasPago = new System.Windows.Forms.ComboBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.dgvVentas = new System.Windows.Forms.DataGridView();
            this.NroFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Socio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnConsultarVendedor = new System.Windows.Forms.Button();
            this.lblVendedor = new System.Windows.Forms.Label();
            this.btnConsultarSocio = new System.Windows.Forms.Button();
            this.lblSocio = new System.Windows.Forms.Label();
            this.btnNuevaVenta = new System.Windows.Forms.Button();
            this.btnGenerarFactura = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecioMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecioMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnReiniciarFiltros
            // 
            this.btnReiniciarFiltros.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReiniciarFiltros.ForeColor = System.Drawing.Color.DimGray;
            this.btnReiniciarFiltros.Location = new System.Drawing.Point(549, 147);
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
            this.numPrecioMax.Location = new System.Drawing.Point(223, 137);
            this.numPrecioMax.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.numPrecioMax.Name = "numPrecioMax";
            this.numPrecioMax.Size = new System.Drawing.Size(92, 27);
            this.numPrecioMax.TabIndex = 100;
            this.numPrecioMax.Value = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            // 
            // numPrecioMin
            // 
            this.numPrecioMin.DecimalPlaces = 2;
            this.numPrecioMin.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numPrecioMin.ForeColor = System.Drawing.Color.DimGray;
            this.numPrecioMin.Location = new System.Drawing.Point(82, 136);
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
            this.label8.Location = new System.Drawing.Point(180, 137);
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
            this.label7.Location = new System.Drawing.Point(3, 137);
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
            this.label6.Location = new System.Drawing.Point(445, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(155, 22);
            this.label6.TabIndex = 93;
            this.label6.Text = "Tipo de factura:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(445, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 22);
            this.label1.TabIndex = 91;
            this.label1.Text = "Forma de pago:";
            // 
            // cboTiposFactura
            // 
            this.cboTiposFactura.BackColor = System.Drawing.Color.White;
            this.cboTiposFactura.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTiposFactura.ForeColor = System.Drawing.Color.DimGray;
            this.cboTiposFactura.FormattingEnabled = true;
            this.cboTiposFactura.Location = new System.Drawing.Point(606, 73);
            this.cboTiposFactura.Name = "cboTiposFactura";
            this.cboTiposFactura.Size = new System.Drawing.Size(185, 29);
            this.cboTiposFactura.TabIndex = 90;
            this.cboTiposFactura.Text = "Selección";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(347, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 33);
            this.label3.TabIndex = 88;
            this.label3.Text = "Búsqueda";
            // 
            // txtNroFactura
            // 
            this.txtNroFactura.BackColor = System.Drawing.Color.White;
            this.txtNroFactura.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroFactura.ForeColor = System.Drawing.Color.DimGray;
            this.txtNroFactura.Location = new System.Drawing.Point(120, 38);
            this.txtNroFactura.Name = "txtNroFactura";
            this.txtNroFactura.Size = new System.Drawing.Size(195, 27);
            this.txtNroFactura.TabIndex = 71;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(3, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 22);
            this.label2.TabIndex = 76;
            this.label2.Text = "N° factura:";
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrar.ForeColor = System.Drawing.Color.DimGray;
            this.btnFiltrar.Location = new System.Drawing.Point(691, 147);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(100, 29);
            this.btnFiltrar.TabIndex = 82;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // btnVerDetalle
            // 
            this.btnVerDetalle.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerDetalle.ForeColor = System.Drawing.Color.DimGray;
            this.btnVerDetalle.Location = new System.Drawing.Point(608, 426);
            this.btnVerDetalle.Name = "btnVerDetalle";
            this.btnVerDetalle.Size = new System.Drawing.Size(110, 29);
            this.btnVerDetalle.TabIndex = 113;
            this.btnVerDetalle.Text = "Ver detalle";
            this.btnVerDetalle.UseVisualStyleBackColor = true;
            this.btnVerDetalle.Click += new System.EventHandler(this.btnVerDetalle_Click);
            // 
            // cboFormasPago
            // 
            this.cboFormasPago.BackColor = System.Drawing.Color.White;
            this.cboFormasPago.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFormasPago.ForeColor = System.Drawing.Color.DimGray;
            this.cboFormasPago.FormattingEnabled = true;
            this.cboFormasPago.Location = new System.Drawing.Point(606, 38);
            this.cboFormasPago.Name = "cboFormasPago";
            this.cboFormasPago.Size = new System.Drawing.Size(185, 29);
            this.cboFormasPago.TabIndex = 72;
            this.cboFormasPago.Text = "Selección";
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.DimGray;
            this.btnSalir.Location = new System.Drawing.Point(724, 426);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(93, 29);
            this.btnSalir.TabIndex = 112;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // dgvVentas
            // 
            this.dgvVentas.AllowUserToAddRows = false;
            this.dgvVentas.AllowUserToDeleteRows = false;
            this.dgvVentas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NroFactura,
            this.TipoFactura,
            this.FormaPago,
            this.Socio,
            this.Vendedor,
            this.FechaVenta,
            this.Total});
            this.dgvVentas.Location = new System.Drawing.Point(12, 209);
            this.dgvVentas.Name = "dgvVentas";
            this.dgvVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVentas.Size = new System.Drawing.Size(805, 200);
            this.dgvVentas.TabIndex = 107;
            // 
            // NroFactura
            // 
            this.NroFactura.HeaderText = "N° factura";
            this.NroFactura.Name = "NroFactura";
            this.NroFactura.ReadOnly = true;
            this.NroFactura.Width = 65;
            // 
            // TipoFactura
            // 
            this.TipoFactura.HeaderText = "Tipo de factura";
            this.TipoFactura.Name = "TipoFactura";
            this.TipoFactura.ReadOnly = true;
            this.TipoFactura.Width = 120;
            // 
            // FormaPago
            // 
            this.FormaPago.HeaderText = "Forma de pago";
            this.FormaPago.Name = "FormaPago";
            this.FormaPago.ReadOnly = true;
            this.FormaPago.Width = 114;
            // 
            // Socio
            // 
            this.Socio.HeaderText = "Socio";
            this.Socio.Name = "Socio";
            this.Socio.ReadOnly = true;
            this.Socio.Width = 113;
            // 
            // Vendedor
            // 
            this.Vendedor.HeaderText = "Vendedor";
            this.Vendedor.Name = "Vendedor";
            this.Vendedor.ReadOnly = true;
            this.Vendedor.Width = 114;
            // 
            // FechaVenta
            // 
            this.FechaVenta.HeaderText = "Fecha de venta";
            this.FechaVenta.Name = "FechaVenta";
            this.FechaVenta.ReadOnly = true;
            this.FechaVenta.Width = 114;
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Controls.Add(this.dtpFechaHasta);
            this.panel1.Controls.Add(this.dtpFechaDesde);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnConsultarVendedor);
            this.panel1.Controls.Add(this.lblVendedor);
            this.panel1.Controls.Add(this.btnConsultarSocio);
            this.panel1.Controls.Add(this.lblSocio);
            this.panel1.Controls.Add(this.btnReiniciarFiltros);
            this.panel1.Controls.Add(this.numPrecioMax);
            this.panel1.Controls.Add(this.numPrecioMin);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboTiposFactura);
            this.panel1.Controls.Add(this.txtNroFactura);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnFiltrar);
            this.panel1.Controls.Add(this.cboFormasPago);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(805, 191);
            this.panel1.TabIndex = 106;
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.CalendarForeColor = System.Drawing.Color.DimGray;
            this.dtpFechaHasta.CalendarTitleForeColor = System.Drawing.Color.DimGray;
            this.dtpFechaHasta.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHasta.Location = new System.Drawing.Point(666, 111);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(125, 27);
            this.dtpFechaHasta.TabIndex = 117;
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.CalendarForeColor = System.Drawing.Color.DimGray;
            this.dtpFechaDesde.CalendarTitleForeColor = System.Drawing.Color.DimGray;
            this.dtpFechaDesde.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesde.Location = new System.Drawing.Point(508, 108);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(125, 27);
            this.dtpFechaDesde.TabIndex = 116;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(639, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 22);
            this.label5.TabIndex = 115;
            this.label5.Text = "y";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DimGray;
            this.label9.Location = new System.Drawing.Point(445, 111);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 22);
            this.label9.TabIndex = 114;
            this.label9.Text = "Entre";
            // 
            // btnConsultarVendedor
            // 
            this.btnConsultarVendedor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConsultarVendedor.BackgroundImage")));
            this.btnConsultarVendedor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConsultarVendedor.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultarVendedor.ForeColor = System.Drawing.Color.DimGray;
            this.btnConsultarVendedor.Location = new System.Drawing.Point(337, 101);
            this.btnConsultarVendedor.Name = "btnConsultarVendedor";
            this.btnConsultarVendedor.Size = new System.Drawing.Size(30, 30);
            this.btnConsultarVendedor.TabIndex = 113;
            this.btnConsultarVendedor.UseVisualStyleBackColor = true;
            this.btnConsultarVendedor.Click += new System.EventHandler(this.btnConsultarVendedor_Click);
            // 
            // lblVendedor
            // 
            this.lblVendedor.AutoSize = true;
            this.lblVendedor.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVendedor.ForeColor = System.Drawing.Color.DimGray;
            this.lblVendedor.Location = new System.Drawing.Point(3, 105);
            this.lblVendedor.Name = "lblVendedor";
            this.lblVendedor.Size = new System.Drawing.Size(110, 22);
            this.lblVendedor.TabIndex = 112;
            this.lblVendedor.Text = "Vendedor:";
            // 
            // btnConsultarSocio
            // 
            this.btnConsultarSocio.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConsultarSocio.BackgroundImage")));
            this.btnConsultarSocio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConsultarSocio.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultarSocio.ForeColor = System.Drawing.Color.DimGray;
            this.btnConsultarSocio.Location = new System.Drawing.Point(337, 69);
            this.btnConsultarSocio.Name = "btnConsultarSocio";
            this.btnConsultarSocio.Size = new System.Drawing.Size(30, 30);
            this.btnConsultarSocio.TabIndex = 111;
            this.btnConsultarSocio.UseVisualStyleBackColor = true;
            this.btnConsultarSocio.Click += new System.EventHandler(this.btnConsultarSocio_Click);
            // 
            // lblSocio
            // 
            this.lblSocio.AutoSize = true;
            this.lblSocio.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSocio.ForeColor = System.Drawing.Color.DimGray;
            this.lblSocio.Location = new System.Drawing.Point(3, 73);
            this.lblSocio.Name = "lblSocio";
            this.lblSocio.Size = new System.Drawing.Size(63, 22);
            this.lblSocio.TabIndex = 110;
            this.lblSocio.Text = "Socio:";
            // 
            // btnNuevaVenta
            // 
            this.btnNuevaVenta.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevaVenta.BackgroundImage")));
            this.btnNuevaVenta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNuevaVenta.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevaVenta.ForeColor = System.Drawing.Color.DimGray;
            this.btnNuevaVenta.Location = new System.Drawing.Point(12, 415);
            this.btnNuevaVenta.Name = "btnNuevaVenta";
            this.btnNuevaVenta.Size = new System.Drawing.Size(40, 40);
            this.btnNuevaVenta.TabIndex = 114;
            this.btnNuevaVenta.UseVisualStyleBackColor = true;
            this.btnNuevaVenta.Click += new System.EventHandler(this.btnNuevaVenta_Click);
            // 
            // btnGenerarFactura
            // 
            this.btnGenerarFactura.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarFactura.ForeColor = System.Drawing.Color.DimGray;
            this.btnGenerarFactura.Location = new System.Drawing.Point(446, 426);
            this.btnGenerarFactura.Name = "btnGenerarFactura";
            this.btnGenerarFactura.Size = new System.Drawing.Size(156, 29);
            this.btnGenerarFactura.TabIndex = 115;
            this.btnGenerarFactura.Text = "Generar factura";
            this.btnGenerarFactura.UseVisualStyleBackColor = true;
            this.btnGenerarFactura.Click += new System.EventHandler(this.btnGenerarFactura_Click);
            // 
            // ConsultaVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(824, 465);
            this.Controls.Add(this.btnGenerarFactura);
            this.Controls.Add(this.btnNuevaVenta);
            this.Controls.Add(this.btnVerDetalle);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dgvVentas);
            this.Controls.Add(this.panel1);
            this.Name = "ConsultaVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultar Ventas";
            this.Load += new System.EventHandler(this.ConsultaVenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numPrecioMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecioMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnReiniciarFiltros;
        private System.Windows.Forms.NumericUpDown numPrecioMax;
        private System.Windows.Forms.NumericUpDown numPrecioMin;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTiposFactura;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNroFactura;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnVerDetalle;
        private System.Windows.Forms.ComboBox cboFormasPago;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridView dgvVentas;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnConsultarSocio;
        private System.Windows.Forms.Label lblSocio;
        private System.Windows.Forms.DataGridViewTextBoxColumn NroFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormaPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn Socio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnConsultarVendedor;
        private System.Windows.Forms.Label lblVendedor;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.Button btnNuevaVenta;
        private System.Windows.Forms.Button btnGenerarFactura;
    }
}