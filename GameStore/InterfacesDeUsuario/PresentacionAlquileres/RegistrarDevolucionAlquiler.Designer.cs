
namespace GameStore.InterfacesDeUsuario.PresentacionAlquileres
{
    partial class RegistrarDevolucionAlquiler
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
            this.dgvDetallesDeAlquileres = new System.Windows.Forms.DataGridView();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSenia = new System.Windows.Forms.TextBox();
            this.lblFechaDevPrevista = new System.Windows.Forms.Label();
            this.lblFechaDevReal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtImporteFinal = new System.Windows.Forms.TextBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtImporteDevTardia = new System.Windows.Forms.TextBox();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.lblCantidadDias = new System.Windows.Forms.Label();
            this.lblDiasExtra = new System.Windows.Forms.Label();
            this.NroAlquiler = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UPC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoAlquilerPorDia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoDevTardia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Plataforma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallesDeAlquileres)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDetallesDeAlquileres
            // 
            this.dgvDetallesDeAlquileres.AllowUserToAddRows = false;
            this.dgvDetallesDeAlquileres.AllowUserToDeleteRows = false;
            this.dgvDetallesDeAlquileres.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetallesDeAlquileres.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDetallesDeAlquileres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetallesDeAlquileres.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NroAlquiler,
            this.UPC,
            this.Nombre,
            this.MontoAlquilerPorDia,
            this.MontoDevTardia,
            this.Subtotal,
            this.TipoArticulo,
            this.Plataforma});
            this.dgvDetallesDeAlquileres.Location = new System.Drawing.Point(12, 12);
            this.dgvDetallesDeAlquileres.Name = "dgvDetallesDeAlquileres";
            this.dgvDetallesDeAlquileres.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetallesDeAlquileres.Size = new System.Drawing.Size(885, 200);
            this.dgvDetallesDeAlquileres.TabIndex = 129;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.DimGray;
            this.lblTotal.Location = new System.Drawing.Point(685, 222);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(74, 22);
            this.lblTotal.TabIndex = 133;
            this.lblTotal.Text = "Total: $";
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.White;
            this.txtTotal.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(765, 220);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(132, 27);
            this.txtTotal.TabIndex = 132;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(460, 255);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(299, 22);
            this.label1.TabIndex = 135;
            this.label1.Text = "Descuento seña paga (-30%): $";
            // 
            // txtSenia
            // 
            this.txtSenia.BackColor = System.Drawing.Color.White;
            this.txtSenia.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenia.Location = new System.Drawing.Point(765, 253);
            this.txtSenia.Name = "txtSenia";
            this.txtSenia.ReadOnly = true;
            this.txtSenia.Size = new System.Drawing.Size(132, 27);
            this.txtSenia.TabIndex = 134;
            // 
            // lblFechaDevPrevista
            // 
            this.lblFechaDevPrevista.AutoSize = true;
            this.lblFechaDevPrevista.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaDevPrevista.ForeColor = System.Drawing.Color.DimGray;
            this.lblFechaDevPrevista.Location = new System.Drawing.Point(12, 255);
            this.lblFechaDevPrevista.Name = "lblFechaDevPrevista";
            this.lblFechaDevPrevista.Size = new System.Drawing.Size(291, 22);
            this.lblFechaDevPrevista.TabIndex = 136;
            this.lblFechaDevPrevista.Text = "Fecha de devolución prevista:";
            // 
            // lblFechaDevReal
            // 
            this.lblFechaDevReal.AutoSize = true;
            this.lblFechaDevReal.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaDevReal.ForeColor = System.Drawing.Color.DimGray;
            this.lblFechaDevReal.Location = new System.Drawing.Point(12, 320);
            this.lblFechaDevReal.Name = "lblFechaDevReal";
            this.lblFechaDevReal.Size = new System.Drawing.Size(251, 22);
            this.lblFechaDevReal.TabIndex = 137;
            this.lblFechaDevReal.Text = "Fecha de devolución real:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(614, 322);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 22);
            this.label2.TabIndex = 139;
            this.label2.Text = "Importe final: $";
            // 
            // txtImporteFinal
            // 
            this.txtImporteFinal.BackColor = System.Drawing.Color.White;
            this.txtImporteFinal.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImporteFinal.Location = new System.Drawing.Point(765, 320);
            this.txtImporteFinal.Name = "txtImporteFinal";
            this.txtImporteFinal.ReadOnly = true;
            this.txtImporteFinal.Size = new System.Drawing.Size(132, 27);
            this.txtImporteFinal.TabIndex = 138;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.ForeColor = System.Drawing.Color.DimGray;
            this.btnConfirmar.Location = new System.Drawing.Point(690, 353);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(108, 29);
            this.btnConfirmar.TabIndex = 141;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.DimGray;
            this.btnSalir.Location = new System.Drawing.Point(804, 353);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(93, 29);
            this.btnSalir.TabIndex = 140;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(437, 288);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(322, 22);
            this.label3.TabIndex = 143;
            this.label3.Text = "Adicional por devolución tardía: $";
            // 
            // txtImporteDevTardia
            // 
            this.txtImporteDevTardia.BackColor = System.Drawing.Color.White;
            this.txtImporteDevTardia.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImporteDevTardia.Location = new System.Drawing.Point(765, 286);
            this.txtImporteDevTardia.Name = "txtImporteDevTardia";
            this.txtImporteDevTardia.ReadOnly = true;
            this.txtImporteDevTardia.Size = new System.Drawing.Size(132, 27);
            this.txtImporteDevTardia.TabIndex = 142;
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaInicio.ForeColor = System.Drawing.Color.DimGray;
            this.lblFechaInicio.Location = new System.Drawing.Point(12, 225);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(153, 22);
            this.lblFechaInicio.TabIndex = 144;
            this.lblFechaInicio.Text = "Fecha de inicio:";
            // 
            // lblCantidadDias
            // 
            this.lblCantidadDias.AutoSize = true;
            this.lblCantidadDias.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadDias.ForeColor = System.Drawing.Color.DimGray;
            this.lblCantidadDias.Location = new System.Drawing.Point(12, 288);
            this.lblCantidadDias.Name = "lblCantidadDias";
            this.lblCantidadDias.Size = new System.Drawing.Size(175, 22);
            this.lblCantidadDias.TabIndex = 145;
            this.lblCantidadDias.Text = "Cantidad de días:";
            // 
            // lblDiasExtra
            // 
            this.lblDiasExtra.AutoSize = true;
            this.lblDiasExtra.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiasExtra.ForeColor = System.Drawing.Color.DimGray;
            this.lblDiasExtra.Location = new System.Drawing.Point(12, 353);
            this.lblDiasExtra.Name = "lblDiasExtra";
            this.lblDiasExtra.Size = new System.Drawing.Size(227, 22);
            this.lblDiasExtra.TabIndex = 146;
            this.lblDiasExtra.Text = "Cantidad de días extra:";
            // 
            // NroAlquiler
            // 
            this.NroAlquiler.HeaderText = "Nro Alquiler";
            this.NroAlquiler.Name = "NroAlquiler";
            this.NroAlquiler.ReadOnly = true;
            this.NroAlquiler.Visible = false;
            // 
            // UPC
            // 
            this.UPC.HeaderText = "Codigo";
            this.UPC.Name = "UPC";
            this.UPC.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // MontoAlquilerPorDia
            // 
            this.MontoAlquilerPorDia.HeaderText = "Precio Alquiler por día";
            this.MontoAlquilerPorDia.Name = "MontoAlquilerPorDia";
            this.MontoAlquilerPorDia.ReadOnly = true;
            // 
            // MontoDevTardia
            // 
            this.MontoDevTardia.HeaderText = "Monto Devolución tardía por día";
            this.MontoDevTardia.Name = "MontoDevTardia";
            this.MontoDevTardia.ReadOnly = true;
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
            // 
            // Plataforma
            // 
            this.Plataforma.HeaderText = "Plataforma";
            this.Plataforma.Name = "Plataforma";
            this.Plataforma.ReadOnly = true;
            // 
            // RegistrarDevolucionAlquiler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(909, 390);
            this.Controls.Add(this.lblDiasExtra);
            this.Controls.Add(this.lblCantidadDias);
            this.Controls.Add(this.lblFechaInicio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtImporteDevTardia);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtImporteFinal);
            this.Controls.Add(this.lblFechaDevReal);
            this.Controls.Add(this.lblFechaDevPrevista);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSenia);
            this.Controls.Add(this.dgvDetallesDeAlquileres);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.txtTotal);
            this.Name = "RegistrarDevolucionAlquiler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar devolución de alquiler";
            this.Load += new System.EventHandler(this.RegistrarDevolucionAlquiler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallesDeAlquileres)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvDetallesDeAlquileres;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSenia;
        private System.Windows.Forms.Label lblFechaDevPrevista;
        private System.Windows.Forms.Label lblFechaDevReal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtImporteFinal;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtImporteDevTardia;
        private System.Windows.Forms.DataGridViewTextBoxColumn NroAlquiler;
        private System.Windows.Forms.DataGridViewTextBoxColumn UPC;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoAlquilerPorDia;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoDevTardia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Plataforma;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.Label lblCantidadDias;
        private System.Windows.Forms.Label lblDiasExtra;
    }
}