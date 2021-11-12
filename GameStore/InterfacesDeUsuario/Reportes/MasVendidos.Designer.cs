
namespace GameStore.InterfacesDeUsuario.Reportes
{
    partial class MasVendidos
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
            this.RwMasVendidos = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnFiltrarMasVen = new System.Windows.Forms.Button();
            this.dtpFechaHastaMasVen = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaDesdeMasVen = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RwMasVendidos
            // 
            this.RwMasVendidos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RwMasVendidos.LocalReport.ReportEmbeddedResource = "GameStore.InterfacesDeUsuario.Reportes.MasVendidos.rdlc";
            this.RwMasVendidos.Location = new System.Drawing.Point(0, 41);
            this.RwMasVendidos.Name = "RwMasVendidos";
            this.RwMasVendidos.ServerReport.BearerToken = null;
            this.RwMasVendidos.Size = new System.Drawing.Size(866, 705);
            this.RwMasVendidos.TabIndex = 0;
            // 
            // btnFiltrarMasVen
            // 
            this.btnFiltrarMasVen.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnFiltrarMasVen.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrarMasVen.ForeColor = System.Drawing.Color.DimGray;
            this.btnFiltrarMasVen.Location = new System.Drawing.Point(596, 6);
            this.btnFiltrarMasVen.Name = "btnFiltrarMasVen";
            this.btnFiltrarMasVen.Size = new System.Drawing.Size(100, 29);
            this.btnFiltrarMasVen.TabIndex = 138;
            this.btnFiltrarMasVen.Text = "Filtrar";
            this.btnFiltrarMasVen.UseVisualStyleBackColor = true;
            this.btnFiltrarMasVen.Click += new System.EventHandler(this.btnFiltrarMasVen_Click);
            // 
            // dtpFechaHastaMasVen
            // 
            this.dtpFechaHastaMasVen.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpFechaHastaMasVen.CalendarForeColor = System.Drawing.Color.DimGray;
            this.dtpFechaHastaMasVen.CalendarTitleForeColor = System.Drawing.Color.DimGray;
            this.dtpFechaHastaMasVen.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaHastaMasVen.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHastaMasVen.Location = new System.Drawing.Point(440, 6);
            this.dtpFechaHastaMasVen.Name = "dtpFechaHastaMasVen";
            this.dtpFechaHastaMasVen.Size = new System.Drawing.Size(125, 27);
            this.dtpFechaHastaMasVen.TabIndex = 137;
            // 
            // dtpFechaDesdeMasVen
            // 
            this.dtpFechaDesdeMasVen.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpFechaDesdeMasVen.CalendarForeColor = System.Drawing.Color.DimGray;
            this.dtpFechaDesdeMasVen.CalendarTitleForeColor = System.Drawing.Color.DimGray;
            this.dtpFechaDesdeMasVen.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaDesdeMasVen.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesdeMasVen.Location = new System.Drawing.Point(282, 6);
            this.dtpFechaDesdeMasVen.Name = "dtpFechaDesdeMasVen";
            this.dtpFechaDesdeMasVen.Size = new System.Drawing.Size(125, 27);
            this.dtpFechaDesdeMasVen.TabIndex = 136;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(413, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 22);
            this.label1.TabIndex = 135;
            this.label1.Text = "y";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(219, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 22);
            this.label2.TabIndex = 134;
            this.label2.Text = "Entre";
            // 
            // MasVendidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(867, 768);
            this.Controls.Add(this.btnFiltrarMasVen);
            this.Controls.Add(this.dtpFechaHastaMasVen);
            this.Controls.Add(this.dtpFechaDesdeMasVen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RwMasVendidos);
            this.Name = "MasVendidos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Artículos más Vendidos";
            this.Load += new System.EventHandler(this.MasVendidos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer RwMasVendidos;
        private System.Windows.Forms.Button btnFiltrarMasVen;
        private System.Windows.Forms.DateTimePicker dtpFechaHastaMasVen;
        private System.Windows.Forms.DateTimePicker dtpFechaDesdeMasVen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}