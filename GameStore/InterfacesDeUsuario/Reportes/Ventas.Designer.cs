
namespace GameStore.InterfacesDeUsuario.Reportes
{
    partial class Ventas
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
            this.RwVentas = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnFiltrarVen = new System.Windows.Forms.Button();
            this.dtpFechaHastaVen = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaDesdeVen = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RwVentas
            // 
            this.RwVentas.LocalReport.ReportEmbeddedResource = "GameStore.InterfacesDeUsuario.Reportes.Ventas.rdlc";
            this.RwVentas.Location = new System.Drawing.Point(2, 47);
            this.RwVentas.Name = "RwVentas";
            this.RwVentas.ServerReport.BearerToken = null;
            this.RwVentas.Size = new System.Drawing.Size(1233, 766);
            this.RwVentas.TabIndex = 0;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnFiltrar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrar.ForeColor = System.Drawing.Color.DimGray;
            this.btnFiltrar.Location = new System.Drawing.Point(678, -173);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(10, 10);
            this.btnFiltrar.TabIndex = 128;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpFechaHasta.CalendarForeColor = System.Drawing.Color.DimGray;
            this.dtpFechaHasta.CalendarTitleForeColor = System.Drawing.Color.DimGray;
            this.dtpFechaHasta.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHasta.Location = new System.Drawing.Point(522, -173);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(10, 27);
            this.dtpFechaHasta.TabIndex = 127;
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpFechaDesde.CalendarForeColor = System.Drawing.Color.DimGray;
            this.dtpFechaDesde.CalendarTitleForeColor = System.Drawing.Color.DimGray;
            this.dtpFechaDesde.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesde.Location = new System.Drawing.Point(364, -173);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(10, 27);
            this.dtpFechaDesde.TabIndex = 126;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(495, -170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 22);
            this.label5.TabIndex = 125;
            this.label5.Text = "y";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DimGray;
            this.label9.Location = new System.Drawing.Point(301, -170);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 22);
            this.label9.TabIndex = 124;
            this.label9.Text = "Entre";
            // 
            // btnFiltrarVen
            // 
            this.btnFiltrarVen.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnFiltrarVen.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrarVen.ForeColor = System.Drawing.Color.DimGray;
            this.btnFiltrarVen.Location = new System.Drawing.Point(776, 12);
            this.btnFiltrarVen.Name = "btnFiltrarVen";
            this.btnFiltrarVen.Size = new System.Drawing.Size(100, 29);
            this.btnFiltrarVen.TabIndex = 133;
            this.btnFiltrarVen.Text = "Filtrar";
            this.btnFiltrarVen.UseVisualStyleBackColor = true;
            this.btnFiltrarVen.Click += new System.EventHandler(this.btnFiltrarVen_Click);
            // 
            // dtpFechaHastaVen
            // 
            this.dtpFechaHastaVen.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpFechaHastaVen.CalendarForeColor = System.Drawing.Color.DimGray;
            this.dtpFechaHastaVen.CalendarTitleForeColor = System.Drawing.Color.DimGray;
            this.dtpFechaHastaVen.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaHastaVen.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHastaVen.Location = new System.Drawing.Point(620, 12);
            this.dtpFechaHastaVen.Name = "dtpFechaHastaVen";
            this.dtpFechaHastaVen.Size = new System.Drawing.Size(125, 27);
            this.dtpFechaHastaVen.TabIndex = 132;
            // 
            // dtpFechaDesdeVen
            // 
            this.dtpFechaDesdeVen.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpFechaDesdeVen.CalendarForeColor = System.Drawing.Color.DimGray;
            this.dtpFechaDesdeVen.CalendarTitleForeColor = System.Drawing.Color.DimGray;
            this.dtpFechaDesdeVen.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaDesdeVen.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesdeVen.Location = new System.Drawing.Point(462, 12);
            this.dtpFechaDesdeVen.Name = "dtpFechaDesdeVen";
            this.dtpFechaDesdeVen.Size = new System.Drawing.Size(125, 27);
            this.dtpFechaDesdeVen.TabIndex = 131;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(593, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 22);
            this.label1.TabIndex = 130;
            this.label1.Text = "y";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(399, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 22);
            this.label2.TabIndex = 129;
            this.label2.Text = "Entre";
            // 
            // Ventas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(1237, 814);
            this.Controls.Add(this.btnFiltrarVen);
            this.Controls.Add(this.dtpFechaHastaVen);
            this.Controls.Add(this.dtpFechaDesdeVen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.dtpFechaHasta);
            this.Controls.Add(this.dtpFechaDesde);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.RwVentas);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Ventas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ventas";
            this.Load += new System.EventHandler(this.Ventas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer RwVentas;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnFiltrarVen;
        private System.Windows.Forms.DateTimePicker dtpFechaHastaVen;
        private System.Windows.Forms.DateTimePicker dtpFechaDesdeVen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}