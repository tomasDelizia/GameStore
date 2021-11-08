
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
            this.btnFiltrarMasFie = new System.Windows.Forms.Button();
            this.dtpFechaHastaMasFie = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaDesdeMasFie = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RwMasFieles
            // 
            this.RwMasFieles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RwMasFieles.LocalReport.ReportEmbeddedResource = "GameStore.InterfacesDeUsuario.Reportes.MasFieles.rdlc";
            this.RwMasFieles.Location = new System.Drawing.Point(0, 41);
            this.RwMasFieles.Name = "RwMasFieles";
            this.RwMasFieles.ServerReport.BearerToken = null;
            this.RwMasFieles.Size = new System.Drawing.Size(983, 420);
            this.RwMasFieles.TabIndex = 0;
            // 
            // btnFiltrarMasFie
            // 
            this.btnFiltrarMasFie.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnFiltrarMasFie.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrarMasFie.ForeColor = System.Drawing.Color.DimGray;
            this.btnFiltrarMasFie.Location = new System.Drawing.Point(660, 6);
            this.btnFiltrarMasFie.Name = "btnFiltrarMasFie";
            this.btnFiltrarMasFie.Size = new System.Drawing.Size(100, 29);
            this.btnFiltrarMasFie.TabIndex = 138;
            this.btnFiltrarMasFie.Text = "Filtrar";
            this.btnFiltrarMasFie.UseVisualStyleBackColor = true;
            this.btnFiltrarMasFie.Click += new System.EventHandler(this.btnFiltrarMasFie_Click);
            // 
            // dtpFechaHastaMasFie
            // 
            this.dtpFechaHastaMasFie.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpFechaHastaMasFie.CalendarForeColor = System.Drawing.Color.DimGray;
            this.dtpFechaHastaMasFie.CalendarTitleForeColor = System.Drawing.Color.DimGray;
            this.dtpFechaHastaMasFie.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaHastaMasFie.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHastaMasFie.Location = new System.Drawing.Point(504, 6);
            this.dtpFechaHastaMasFie.Name = "dtpFechaHastaMasFie";
            this.dtpFechaHastaMasFie.Size = new System.Drawing.Size(125, 27);
            this.dtpFechaHastaMasFie.TabIndex = 137;
            // 
            // dtpFechaDesdeMasFie
            // 
            this.dtpFechaDesdeMasFie.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpFechaDesdeMasFie.CalendarForeColor = System.Drawing.Color.DimGray;
            this.dtpFechaDesdeMasFie.CalendarTitleForeColor = System.Drawing.Color.DimGray;
            this.dtpFechaDesdeMasFie.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaDesdeMasFie.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesdeMasFie.Location = new System.Drawing.Point(346, 6);
            this.dtpFechaDesdeMasFie.Name = "dtpFechaDesdeMasFie";
            this.dtpFechaDesdeMasFie.Size = new System.Drawing.Size(125, 27);
            this.dtpFechaDesdeMasFie.TabIndex = 136;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(477, 9);
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
            this.label2.Location = new System.Drawing.Point(283, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 22);
            this.label2.TabIndex = 134;
            this.label2.Text = "Entre";
            // 
            // MasFieles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.btnFiltrarMasFie);
            this.Controls.Add(this.dtpFechaHastaMasFie);
            this.Controls.Add(this.dtpFechaDesdeMasFie);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RwMasFieles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MasFieles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Socios más Fieles";
            this.Load += new System.EventHandler(this.MasFieles_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer RwMasFieles;
        private System.Windows.Forms.Button btnFiltrarMasFie;
        private System.Windows.Forms.DateTimePicker dtpFechaHastaMasFie;
        private System.Windows.Forms.DateTimePicker dtpFechaDesdeMasFie;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}