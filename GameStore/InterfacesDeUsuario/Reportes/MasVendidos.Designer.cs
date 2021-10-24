
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
            this.SuspendLayout();
            // 
            // RwMasVendidos
            // 
            this.RwMasVendidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RwMasVendidos.LocalReport.ReportEmbeddedResource = "GameStore.InterfacesDeUsuario.Reportes.ReporteMasVendidos.rdlc";
            this.RwMasVendidos.Location = new System.Drawing.Point(0, 0);
            this.RwMasVendidos.Name = "RwMasVendidos";
            this.RwMasVendidos.ServerReport.BearerToken = null;
            this.RwMasVendidos.Size = new System.Drawing.Size(833, 749);
            this.RwMasVendidos.TabIndex = 0;
            // 
            // MasVendidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 749);
            this.Controls.Add(this.RwMasVendidos);
            this.Name = "MasVendidos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MasVendidos";
            this.Load += new System.EventHandler(this.MasVendidos_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer RwMasVendidos;
    }
}