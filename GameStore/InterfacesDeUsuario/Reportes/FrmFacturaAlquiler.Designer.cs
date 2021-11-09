
namespace GameStore.InterfacesDeUsuario.Reportes
{
    partial class FrmFacturaAlquiler
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
            this.rwFacturaAlquiler = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rwFacturaAlquiler
            // 
            this.rwFacturaAlquiler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rwFacturaAlquiler.LocalReport.ReportEmbeddedResource = "GameStore.InterfacesDeUsuario.Reportes.FacturaAlquiler.rdlc";
            this.rwFacturaAlquiler.Location = new System.Drawing.Point(0, 0);
            this.rwFacturaAlquiler.Name = "rwFacturaAlquiler";
            this.rwFacturaAlquiler.ServerReport.BearerToken = null;
            this.rwFacturaAlquiler.Size = new System.Drawing.Size(815, 789);
            this.rwFacturaAlquiler.TabIndex = 0;
            // 
            // FrmFacturaAlquiler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 789);
            this.Controls.Add(this.rwFacturaAlquiler);
            this.MinimumSize = new System.Drawing.Size(831, 828);
            this.Name = "FrmFacturaAlquiler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Factura del Alquiler";
            this.Load += new System.EventHandler(this.FrmFacturaAlquiler_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rwFacturaAlquiler;
    }
}