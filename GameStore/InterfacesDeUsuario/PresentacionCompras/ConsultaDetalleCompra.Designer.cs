
namespace GameStore.InterfacesDeUsuario.PresentacionCompras
{
    partial class ConsultaDetalleCompra
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
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.picArticulo = new System.Windows.Forms.PictureBox();
            this.dgvDetallesDeCompra = new System.Windows.Forms.DataGridView();
            this.NroFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadComprada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Plataforma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.picArticulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallesDeCompra)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.DimGray;
            this.lblTotal.Location = new System.Drawing.Point(570, 220);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(74, 22);
            this.lblTotal.TabIndex = 128;
            this.lblTotal.Text = "Total: $";
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.White;
            this.txtTotal.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(650, 218);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(132, 27);
            this.txtTotal.TabIndex = 127;
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.DimGray;
            this.btnSalir.Location = new System.Drawing.Point(846, 229);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(93, 29);
            this.btnSalir.TabIndex = 126;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // picArticulo
            // 
            this.picArticulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picArticulo.Location = new System.Drawing.Point(789, 12);
            this.picArticulo.Name = "picArticulo";
            this.picArticulo.Size = new System.Drawing.Size(150, 200);
            this.picArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picArticulo.TabIndex = 125;
            this.picArticulo.TabStop = false;
            // 
            // dgvDetallesDeCompra
            // 
            this.dgvDetallesDeCompra.AllowUserToAddRows = false;
            this.dgvDetallesDeCompra.AllowUserToDeleteRows = false;
            this.dgvDetallesDeCompra.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDetallesDeCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetallesDeCompra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NroFactura,
            this.Codigo,
            this.Nombre,
            this.PrecioUnitario,
            this.CantidadComprada,
            this.Subtotal,
            this.TipoArticulo,
            this.Plataforma});
            this.dgvDetallesDeCompra.Location = new System.Drawing.Point(12, 12);
            this.dgvDetallesDeCompra.Name = "dgvDetallesDeCompra";
            this.dgvDetallesDeCompra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetallesDeCompra.Size = new System.Drawing.Size(770, 200);
            this.dgvDetallesDeCompra.TabIndex = 124;
            this.dgvDetallesDeCompra.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetallesDeCompra_CellClick);
            // 
            // NroFactura
            // 
            this.NroFactura.HeaderText = "Nro Factura";
            this.NroFactura.Name = "NroFactura";
            this.NroFactura.ReadOnly = true;
            this.NroFactura.Visible = false;
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Visible = false;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 120;
            // 
            // PrecioUnitario
            // 
            this.PrecioUnitario.HeaderText = "Precio Unitario";
            this.PrecioUnitario.Name = "PrecioUnitario";
            this.PrecioUnitario.ReadOnly = true;
            this.PrecioUnitario.Width = 114;
            // 
            // CantidadComprada
            // 
            this.CantidadComprada.HeaderText = "Cantidad comprada";
            this.CantidadComprada.Name = "CantidadComprada";
            this.CantidadComprada.ReadOnly = true;
            // 
            // Subtotal
            // 
            this.Subtotal.HeaderText = "Subtotal";
            this.Subtotal.Name = "Subtotal";
            this.Subtotal.ReadOnly = true;
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
            // ConsultaDetalleCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(947, 262);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.picArticulo);
            this.Controls.Add(this.dgvDetallesDeCompra);
            this.Name = "ConsultaDetalleCompra";
            this.Text = "Ver Detalles de la Compra";
            this.Load += new System.EventHandler(this.ConsultaDetalleCompra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picArticulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallesDeCompra)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.PictureBox picArticulo;
        private System.Windows.Forms.DataGridView dgvDetallesDeCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn NroFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadComprada;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Plataforma;
    }
}