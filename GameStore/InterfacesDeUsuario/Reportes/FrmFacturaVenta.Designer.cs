
namespace GameStore.InterfacesDeUsuario.Reportes
{
    partial class FrmFacturaVenta
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
            this.rwFacturaVenta = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rwFacturaVenta
            // 
            this.rwFacturaVenta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rwFacturaVenta.LocalReport.ReportEmbeddedResource = "GameStore.InterfacesDeUsuario.Reportes.FacturaVenta.rdlc";
            this.rwFacturaVenta.Location = new System.Drawing.Point(0, 0);
            this.rwFacturaVenta.Name = "rwFacturaVenta";
            this.rwFacturaVenta.ServerReport.BearerToken = null;
            this.rwFacturaVenta.Size = new System.Drawing.Size(742, 514);
            this.rwFacturaVenta.TabIndex = 0;
            // 
            // FrmFacturaVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 514);
            this.Controls.Add(this.rwFacturaVenta);
            this.Name = "FrmFacturaVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Factura de Venta";
            this.Load += new System.EventHandler(this.FrmFacturaVenta_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rwFacturaVenta;
    }
}