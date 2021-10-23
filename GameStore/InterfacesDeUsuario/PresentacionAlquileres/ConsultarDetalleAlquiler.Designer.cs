
namespace GameStore.InterfacesDeUsuario.PresentacionAlquileres
{
    partial class ConsultarDetalleAlquiler
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
            this.btnSalir = new System.Windows.Forms.Button();
            this.dgvDetallesDeAlquileres = new System.Windows.Forms.DataGridView();
            this.NroAlquiler = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoAlquilerPorDia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Plataforma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.picArticulo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallesDeAlquileres)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picArticulo)).BeginInit();
            this.SuspendLayout();
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
            // dgvDetallesDeAlquileres
            // 
            this.dgvDetallesDeAlquileres.AllowUserToAddRows = false;
            this.dgvDetallesDeAlquileres.AllowUserToDeleteRows = false;
            this.dgvDetallesDeAlquileres.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDetallesDeAlquileres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetallesDeAlquileres.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NroAlquiler,
            this.Codigo,
            this.Nombre,
            this.MontoAlquilerPorDia,
            this.Subtotal,
            this.TipoArticulo,
            this.Plataforma});
            this.dgvDetallesDeAlquileres.Location = new System.Drawing.Point(12, 12);
            this.dgvDetallesDeAlquileres.Name = "dgvDetallesDeAlquileres";
            this.dgvDetallesDeAlquileres.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetallesDeAlquileres.Size = new System.Drawing.Size(770, 200);
            this.dgvDetallesDeAlquileres.TabIndex = 124;
            this.dgvDetallesDeAlquileres.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetallesDeAlquileres_CellClick);
            // 
            // NroAlquiler
            // 
            this.NroAlquiler.HeaderText = "Nro Alquiler";
            this.NroAlquiler.Name = "NroAlquiler";
            this.NroAlquiler.ReadOnly = true;
            this.NroAlquiler.Visible = false;
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
            // MontoAlquilerPorDia
            // 
            this.MontoAlquilerPorDia.HeaderText = "Precio Alquiler";
            this.MontoAlquilerPorDia.Name = "MontoAlquilerPorDia";
            this.MontoAlquilerPorDia.ReadOnly = true;
            this.MontoAlquilerPorDia.Width = 114;
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
            // ConsultarDetalleAlquiler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(949, 268);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.picArticulo);
            this.Controls.Add(this.dgvDetallesDeAlquileres);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.txtTotal);
            this.Name = "ConsultarDetalleAlquiler";
            this.Text = "ConsultarDetalleAlquiler";
            this.Load += new System.EventHandler(this.ConsultarDetalleAlquiler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallesDeAlquileres)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picArticulo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.PictureBox picArticulo;
        private System.Windows.Forms.DataGridView dgvDetallesDeAlquileres;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn NroAlquiler;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoAlquilerPorDia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Plataforma;
    }
}