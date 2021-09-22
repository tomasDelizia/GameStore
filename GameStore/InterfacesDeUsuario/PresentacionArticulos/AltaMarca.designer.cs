
namespace GameStore.InterfacesDeUsuario.PresentacionArticulos
{
    partial class AltaMarca
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
            this.lblNombreArticulo = new System.Windows.Forms.Label();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.TxtDescripcion = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnRegistrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNombreArticulo
            // 
            this.lblNombreArticulo.AutoSize = true;
            this.lblNombreArticulo.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreArticulo.ForeColor = System.Drawing.Color.DimGray;
            this.lblNombreArticulo.Location = new System.Drawing.Point(39, 9);
            this.lblNombreArticulo.Name = "lblNombreArticulo";
            this.lblNombreArticulo.Size = new System.Drawing.Size(89, 22);
            this.lblNombreArticulo.TabIndex = 15;
            this.lblNombreArticulo.Text = "Nombre:";
            // 
            // TxtNombre
            // 
            this.TxtNombre.BackColor = System.Drawing.Color.White;
            this.TxtNombre.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNombre.Location = new System.Drawing.Point(134, 7);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(277, 27);
            this.TxtNombre.TabIndex = 14;
            // 
            // TxtDescripcion
            // 
            this.TxtDescripcion.Location = new System.Drawing.Point(16, 62);
            this.TxtDescripcion.Name = "TxtDescripcion";
            this.TxtDescripcion.Size = new System.Drawing.Size(395, 132);
            this.TxtDescripcion.TabIndex = 16;
            this.TxtDescripcion.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 22);
            this.label1.TabIndex = 17;
            this.label1.Text = "Descripción";
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.ForeColor = System.Drawing.Color.DimGray;
            this.BtnCancelar.Location = new System.Drawing.Point(318, 200);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(93, 29);
            this.BtnCancelar.TabIndex = 18;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnRegistrar
            // 
            this.BtnRegistrar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRegistrar.ForeColor = System.Drawing.Color.DimGray;
            this.BtnRegistrar.Location = new System.Drawing.Point(214, 200);
            this.BtnRegistrar.Name = "BtnRegistrar";
            this.BtnRegistrar.Size = new System.Drawing.Size(98, 29);
            this.BtnRegistrar.TabIndex = 19;
            this.BtnRegistrar.Text = "Registrar";
            this.BtnRegistrar.UseVisualStyleBackColor = true;
            this.BtnRegistrar.Click += new System.EventHandler(this.BtnRegistrar_Click);
            // 
            // AltaMarca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(423, 238);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnRegistrar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtDescripcion);
            this.Controls.Add(this.lblNombreArticulo);
            this.Controls.Add(this.TxtNombre);
            this.Name = "AltaMarca";
            this.Text = "Registrar Marca";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombreArticulo;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.RichTextBox TxtDescripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnRegistrar;
    }
}