
namespace GameStore.InterfacesDeUsuario.Reportes
{
    partial class Resumen
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
            this.RwResumen = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // RwResumen
            // 
            this.RwResumen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RwResumen.LocalReport.ReportEmbeddedResource = "GameStore.InterfacesDeUsuario.Reportes.Resumen.rdlc";
            this.RwResumen.Location = new System.Drawing.Point(0, 0);
            this.RwResumen.Name = "RwResumen";
            this.RwResumen.ServerReport.BearerToken = null;
            this.RwResumen.Size = new System.Drawing.Size(1237, 689);
            this.RwResumen.TabIndex = 0;
            // 
            // Resumen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(1237, 689);
            this.Controls.Add(this.RwResumen);
            this.Name = "Resumen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resumen";
            this.Load += new System.EventHandler(this.Ventas_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer RwResumen;
    }
}