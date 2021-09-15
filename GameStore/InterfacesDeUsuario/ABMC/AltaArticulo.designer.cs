
namespace GameStore.InterfacesDeUsuario.ABMC
{
    partial class AltaArticulo
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
            this.components = new System.ComponentModel.Container();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.cmbTipoArticulo = new System.Windows.Forms.ComboBox();
            this.cmbGenero = new System.Windows.Forms.ComboBox();
            this.cmbDesarrollador = new System.Windows.Forms.ComboBox();
            this.cmbClasificacion = new System.Windows.Forms.ComboBox();
            this.cmbPublicante = new System.Windows.Forms.ComboBox();
            this.cmbPlataforma = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.gAMESTOREDataSet = new GameStore.GAMESTOREDataSet();
            this.tiposDeArticuloBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tiposDeArticuloTableAdapter = new GameStore.GAMESTOREDataSetTableAdapters.TiposDeArticuloTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.gAMESTOREDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tiposDeArticuloBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.DimGray;
            this.textBox1.Location = new System.Drawing.Point(487, 10);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(151, 27);
            this.textBox1.TabIndex = 0;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.White;
            this.textBox4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.ForeColor = System.Drawing.Color.DimGray;
            this.textBox4.Location = new System.Drawing.Point(487, 43);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(151, 27);
            this.textBox4.TabIndex = 3;
            // 
            // cmbTipoArticulo
            // 
            this.cmbTipoArticulo.BackColor = System.Drawing.Color.White;
            this.cmbTipoArticulo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoArticulo.ForeColor = System.Drawing.Color.DimGray;
            this.cmbTipoArticulo.FormattingEnabled = true;
            this.cmbTipoArticulo.Location = new System.Drawing.Point(16, 12);
            this.cmbTipoArticulo.Name = "cmbTipoArticulo";
            this.cmbTipoArticulo.Size = new System.Drawing.Size(171, 29);
            this.cmbTipoArticulo.TabIndex = 4;
            this.cmbTipoArticulo.Text = "Tipo de artículo";
            // 
            // cmbGenero
            // 
            this.cmbGenero.BackColor = System.Drawing.Color.White;
            this.cmbGenero.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGenero.ForeColor = System.Drawing.Color.DimGray;
            this.cmbGenero.FormattingEnabled = true;
            this.cmbGenero.Location = new System.Drawing.Point(16, 45);
            this.cmbGenero.Name = "cmbGenero";
            this.cmbGenero.Size = new System.Drawing.Size(171, 29);
            this.cmbGenero.TabIndex = 5;
            this.cmbGenero.Text = "Género";
            // 
            // cmbDesarrollador
            // 
            this.cmbDesarrollador.BackColor = System.Drawing.Color.White;
            this.cmbDesarrollador.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDesarrollador.ForeColor = System.Drawing.Color.DimGray;
            this.cmbDesarrollador.FormattingEnabled = true;
            this.cmbDesarrollador.Location = new System.Drawing.Point(16, 80);
            this.cmbDesarrollador.Name = "cmbDesarrollador";
            this.cmbDesarrollador.Size = new System.Drawing.Size(171, 29);
            this.cmbDesarrollador.TabIndex = 6;
            this.cmbDesarrollador.Text = "Desarrollador";
            // 
            // cmbClasificacion
            // 
            this.cmbClasificacion.BackColor = System.Drawing.Color.White;
            this.cmbClasificacion.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbClasificacion.ForeColor = System.Drawing.Color.DimGray;
            this.cmbClasificacion.FormattingEnabled = true;
            this.cmbClasificacion.Location = new System.Drawing.Point(16, 115);
            this.cmbClasificacion.Name = "cmbClasificacion";
            this.cmbClasificacion.Size = new System.Drawing.Size(171, 29);
            this.cmbClasificacion.TabIndex = 7;
            this.cmbClasificacion.Text = "Clasificación";
            // 
            // cmbPublicante
            // 
            this.cmbPublicante.BackColor = System.Drawing.Color.White;
            this.cmbPublicante.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPublicante.ForeColor = System.Drawing.Color.DimGray;
            this.cmbPublicante.FormattingEnabled = true;
            this.cmbPublicante.Location = new System.Drawing.Point(16, 150);
            this.cmbPublicante.Name = "cmbPublicante";
            this.cmbPublicante.Size = new System.Drawing.Size(171, 29);
            this.cmbPublicante.TabIndex = 8;
            this.cmbPublicante.Text = "Publicante";
            // 
            // cmbPlataforma
            // 
            this.cmbPlataforma.BackColor = System.Drawing.Color.White;
            this.cmbPlataforma.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPlataforma.ForeColor = System.Drawing.Color.DimGray;
            this.cmbPlataforma.FormattingEnabled = true;
            this.cmbPlataforma.Location = new System.Drawing.Point(16, 185);
            this.cmbPlataforma.Name = "cmbPlataforma";
            this.cmbPlataforma.Size = new System.Drawing.Size(171, 29);
            this.cmbPlataforma.TabIndex = 9;
            this.cmbPlataforma.Text = "Plataforma";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.DimGray;
            this.button1.Location = new System.Drawing.Point(193, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 29);
            this.button1.TabIndex = 25;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.DimGray;
            this.button2.Location = new System.Drawing.Point(193, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(32, 29);
            this.button2.TabIndex = 26;
            this.button2.Text = "+";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.DimGray;
            this.button3.Location = new System.Drawing.Point(193, 80);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(32, 29);
            this.button3.TabIndex = 27;
            this.button3.Text = "+";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.DimGray;
            this.button4.Location = new System.Drawing.Point(193, 150);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(32, 29);
            this.button4.TabIndex = 28;
            this.button4.Text = "+";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.DimGray;
            this.button5.Location = new System.Drawing.Point(193, 115);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(32, 29);
            this.button5.TabIndex = 29;
            this.button5.Text = "+";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(12, 228);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 22);
            this.label1.TabIndex = 25;
            this.label1.Text = "Descripción:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.White;
            this.richTextBox1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.ForeColor = System.Drawing.Color.DimGray;
            this.richTextBox1.Location = new System.Drawing.Point(16, 253);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(751, 123);
            this.richTextBox1.TabIndex = 25;
            this.richTextBox1.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(392, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 22);
            this.label2.TabIndex = 30;
            this.label2.Text = "Nombre:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(337, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 22);
            this.label5.TabIndex = 33;
            this.label5.Text = "Precio unitario:";
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.DimGray;
            this.button6.Location = new System.Drawing.Point(487, 109);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(282, 31);
            this.button6.TabIndex = 25;
            this.button6.Text = "Subir imagen";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(321, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(160, 22);
            this.label6.TabIndex = 34;
            this.label6.Text = "Fecha de salida:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarForeColor = System.Drawing.Color.DimGray;
            this.dateTimePicker1.CalendarTitleForeColor = System.Drawing.Color.DimGray;
            this.dateTimePicker1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(487, 76);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(280, 27);
            this.dateTimePicker1.TabIndex = 25;
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.Color.DimGray;
            this.button7.Location = new System.Drawing.Point(667, 382);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(100, 34);
            this.button7.TabIndex = 25;
            this.button7.Text = "Cancelar";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.ForeColor = System.Drawing.Color.DimGray;
            this.button8.Location = new System.Drawing.Point(563, 382);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(100, 34);
            this.button8.TabIndex = 25;
            this.button8.Text = "Registrar";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ForeColor = System.Drawing.Color.DimGray;
            this.button9.Location = new System.Drawing.Point(193, 185);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(32, 29);
            this.button9.TabIndex = 35;
            this.button9.Text = "+";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(394, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 22);
            this.label3.TabIndex = 36;
            this.label3.Text = "Imagen:";
            // 
            // gAMESTOREDataSet
            // 
            this.gAMESTOREDataSet.DataSetName = "GAMESTOREDataSet";
            this.gAMESTOREDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tiposDeArticuloBindingSource
            // 
            this.tiposDeArticuloBindingSource.DataMember = "TiposDeArticulo";
            this.tiposDeArticuloBindingSource.DataSource = this.gAMESTOREDataSet;
            // 
            // tiposDeArticuloTableAdapter
            // 
            this.tiposDeArticuloTableAdapter.ClearBeforeFill = true;
            // 
            // AltaArticulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(775, 420);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmbPlataforma);
            this.Controls.Add(this.cmbPublicante);
            this.Controls.Add(this.cmbClasificacion);
            this.Controls.Add(this.cmbDesarrollador);
            this.Controls.Add(this.cmbGenero);
            this.Controls.Add(this.cmbTipoArticulo);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox1);
            this.Name = "AltaArticulo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Artículo";
            this.Load += new System.EventHandler(this.AltaArticulo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gAMESTOREDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tiposDeArticuloBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.ComboBox cmbTipoArticulo;
        private System.Windows.Forms.ComboBox cmbGenero;
        private System.Windows.Forms.ComboBox cmbDesarrollador;
        private System.Windows.Forms.ComboBox cmbClasificacion;
        private System.Windows.Forms.ComboBox cmbPublicante;
        private System.Windows.Forms.ComboBox cmbPlataforma;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label label3;
        private GAMESTOREDataSet gAMESTOREDataSet;
        private System.Windows.Forms.BindingSource tiposDeArticuloBindingSource;
        private GAMESTOREDataSetTableAdapters.TiposDeArticuloTableAdapter tiposDeArticuloTableAdapter;
    }
}