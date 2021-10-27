
namespace GameStore.InterfacesDeUsuario.Reportes
{
    partial class MasFieles
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
            this.RwMasFieles = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // RwMasFieles
            // 
            this.RwMasFieles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RwMasFieles.LocalReport.ReportEmbeddedResource = "GameStore.InterfacesDeUsuario.Reportes.ReportesMasFieles.rdlc";
            this.RwMasFieles.Location = new System.Drawing.Point(0, 0);
            this.RwMasFieles.Name = "RwMasFieles";
            this.RwMasFieles.ServerReport.BearerToken = null;
            this.RwMasFieles.Size = new System.Drawing.Size(984, 461);
            this.RwMasFieles.TabIndex = 0;
            // 
            // MasFieles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.RwMasFieles);
            this.Name = "MasFieles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Socios más Fieles";
            this.Load += new System.EventHandler(this.MasFieles_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer RwMasFieles;
    }
}