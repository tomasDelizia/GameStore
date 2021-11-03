
namespace GameStore.InterfacesDeUsuario.PresentacionArticulos
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
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.cboTiposArticulo = new System.Windows.Forms.ComboBox();
            this.cboGeneros = new System.Windows.Forms.ComboBox();
            this.cboDesarrolladores = new System.Windows.Forms.ComboBox();
            this.cboClasificaciones = new System.Windows.Forms.ComboBox();
            this.cboPlataformas = new System.Windows.Forms.ComboBox();
            this.btnAgregarGenero = new System.Windows.Forms.Button();
            this.btnAgregarDesarrollador = new System.Windows.Forms.Button();
            this.btnAgregarClasificacion = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSubirImagen = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnAgregarPlataforma = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnAgregarMarca = new System.Windows.Forms.Button();
            this.cboMarcas = new System.Windows.Forms.ComboBox();
            this.numPrecioUnitario = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.txtUPC = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecioUnitario)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.White;
            this.txtNombre.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.ForeColor = System.Drawing.Color.DimGray;
            this.txtNombre.Location = new System.Drawing.Point(586, 44);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(279, 27);
            this.txtNombre.TabIndex = 0;
            // 
            // cboTipoArticulo
            // 
            this.cboTiposArticulo.BackColor = System.Drawing.Color.White;
            this.cboTiposArticulo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTiposArticulo.ForeColor = System.Drawing.Color.DimGray;
            this.cboTiposArticulo.FormattingEnabled = true;
            this.cboTiposArticulo.Location = new System.Drawing.Point(172, 12);
            this.cboTiposArticulo.Name = "cboTipoArticulo";
            this.cboTiposArticulo.Size = new System.Drawing.Size(200, 29);
            this.cboTiposArticulo.TabIndex = 4;
            this.cboTiposArticulo.Text = "Selección";
            this.cboTiposArticulo.SelectedValueChanged += new System.EventHandler(this.cboTipoArticulo_SelectedValueChanged);
            // 
            // cboGenero
            // 
            this.cboGeneros.BackColor = System.Drawing.Color.White;
            this.cboGeneros.Enabled = false;
            this.cboGeneros.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboGeneros.ForeColor = System.Drawing.Color.DimGray;
            this.cboGeneros.FormattingEnabled = true;
            this.cboGeneros.Location = new System.Drawing.Point(172, 82);
            this.cboGeneros.Name = "cboGenero";
            this.cboGeneros.Size = new System.Drawing.Size(200, 29);
            this.cboGeneros.TabIndex = 5;
            this.cboGeneros.Text = "Selección";
            // 
            // cboDesarrollador
            // 
            this.cboDesarrolladores.BackColor = System.Drawing.Color.White;
            this.cboDesarrolladores.Enabled = false;
            this.cboDesarrolladores.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDesarrolladores.ForeColor = System.Drawing.Color.DimGray;
            this.cboDesarrolladores.FormattingEnabled = true;
            this.cboDesarrolladores.Location = new System.Drawing.Point(172, 117);
            this.cboDesarrolladores.Name = "cboDesarrollador";
            this.cboDesarrolladores.Size = new System.Drawing.Size(200, 29);
            this.cboDesarrolladores.TabIndex = 6;
            this.cboDesarrolladores.Text = "Selección";
            // 
            // cboClasificacion
            // 
            this.cboClasificaciones.BackColor = System.Drawing.Color.White;
            this.cboClasificaciones.Enabled = false;
            this.cboClasificaciones.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboClasificaciones.ForeColor = System.Drawing.Color.DimGray;
            this.cboClasificaciones.FormattingEnabled = true;
            this.cboClasificaciones.Location = new System.Drawing.Point(172, 152);
            this.cboClasificaciones.Name = "cboClasificacion";
            this.cboClasificaciones.Size = new System.Drawing.Size(200, 29);
            this.cboClasificaciones.TabIndex = 7;
            this.cboClasificaciones.Text = "Selección";
            // 
            // cboPlataforma
            // 
            this.cboPlataformas.BackColor = System.Drawing.Color.White;
            this.cboPlataformas.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPlataformas.ForeColor = System.Drawing.Color.DimGray;
            this.cboPlataformas.FormattingEnabled = true;
            this.cboPlataformas.Location = new System.Drawing.Point(172, 47);
            this.cboPlataformas.Name = "cboPlataforma";
            this.cboPlataformas.Size = new System.Drawing.Size(200, 29);
            this.cboPlataformas.TabIndex = 9;
            this.cboPlataformas.Text = "Selección";
            // 
            // btnAgregarGenero
            // 
            this.btnAgregarGenero.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarGenero.ForeColor = System.Drawing.Color.DimGray;
            this.btnAgregarGenero.Location = new System.Drawing.Point(378, 82);
            this.btnAgregarGenero.Name = "btnAgregarGenero";
            this.btnAgregarGenero.Size = new System.Drawing.Size(32, 29);
            this.btnAgregarGenero.TabIndex = 25;
            this.btnAgregarGenero.Text = "+";
            this.btnAgregarGenero.UseVisualStyleBackColor = true;
            this.btnAgregarGenero.Click += new System.EventHandler(this.btnAgregarGenero_Click);
            // 
            // btnAgregarDesarrollador
            // 
            this.btnAgregarDesarrollador.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarDesarrollador.ForeColor = System.Drawing.Color.DimGray;
            this.btnAgregarDesarrollador.Location = new System.Drawing.Point(378, 117);
            this.btnAgregarDesarrollador.Name = "btnAgregarDesarrollador";
            this.btnAgregarDesarrollador.Size = new System.Drawing.Size(32, 29);
            this.btnAgregarDesarrollador.TabIndex = 27;
            this.btnAgregarDesarrollador.Text = "+";
            this.btnAgregarDesarrollador.UseVisualStyleBackColor = true;
            this.btnAgregarDesarrollador.Click += new System.EventHandler(this.btnAgregarDesarrollador_Click);
            // 
            // btnAgregarClasificacion
            // 
            this.btnAgregarClasificacion.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarClasificacion.ForeColor = System.Drawing.Color.DimGray;
            this.btnAgregarClasificacion.Location = new System.Drawing.Point(378, 152);
            this.btnAgregarClasificacion.Name = "btnAgregarClasificacion";
            this.btnAgregarClasificacion.Size = new System.Drawing.Size(32, 29);
            this.btnAgregarClasificacion.TabIndex = 29;
            this.btnAgregarClasificacion.Text = "+";
            this.btnAgregarClasificacion.UseVisualStyleBackColor = true;
            this.btnAgregarClasificacion.Click += new System.EventHandler(this.btnAgregarClasificacion_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(8, 229);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 22);
            this.label1.TabIndex = 25;
            this.label1.Text = "Descripción:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.AccessibleRole = System.Windows.Forms.AccessibleRole.SplitButton;
            this.txtDescripcion.BackColor = System.Drawing.Color.White;
            this.txtDescripcion.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.ForeColor = System.Drawing.Color.DimGray;
            this.txtDescripcion.Location = new System.Drawing.Point(12, 254);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(568, 136);
            this.txtDescripcion.TabIndex = 25;
            this.txtDescripcion.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(491, 46);
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
            this.label5.Location = new System.Drawing.Point(436, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 22);
            this.label5.TabIndex = 33;
            this.label5.Text = "Precio unitario:";
            // 
            // btnSubirImagen
            // 
            this.btnSubirImagen.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubirImagen.ForeColor = System.Drawing.Color.DimGray;
            this.btnSubirImagen.Location = new System.Drawing.Point(586, 143);
            this.btnSubirImagen.Name = "btnSubirImagen";
            this.btnSubirImagen.Size = new System.Drawing.Size(279, 31);
            this.btnSubirImagen.TabIndex = 25;
            this.btnSubirImagen.Text = "Subir imagen";
            this.btnSubirImagen.UseVisualStyleBackColor = true;
            this.btnSubirImagen.Click += new System.EventHandler(this.btnSubirImagen_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(420, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(160, 22);
            this.label6.TabIndex = 34;
            this.label6.Text = "Fecha de salida:";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CalendarForeColor = System.Drawing.Color.DimGray;
            this.dateTimePicker.CalendarTitleForeColor = System.Drawing.Color.DimGray;
            this.dateTimePicker.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker.Location = new System.Drawing.Point(586, 110);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(279, 27);
            this.dateTimePicker.TabIndex = 25;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.DimGray;
            this.btnCancelar.Location = new System.Drawing.Point(480, 396);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 34);
            this.btnCancelar.TabIndex = 25;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrar.ForeColor = System.Drawing.Color.DimGray;
            this.btnRegistrar.Location = new System.Drawing.Point(374, 396);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(100, 34);
            this.btnRegistrar.TabIndex = 25;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // btnAgregarPlataforma
            // 
            this.btnAgregarPlataforma.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarPlataforma.ForeColor = System.Drawing.Color.DimGray;
            this.btnAgregarPlataforma.Location = new System.Drawing.Point(378, 47);
            this.btnAgregarPlataforma.Name = "btnAgregarPlataforma";
            this.btnAgregarPlataforma.Size = new System.Drawing.Size(32, 29);
            this.btnAgregarPlataforma.TabIndex = 35;
            this.btnAgregarPlataforma.Text = "+";
            this.btnAgregarPlataforma.UseVisualStyleBackColor = true;
            this.btnAgregarPlataforma.Click += new System.EventHandler(this.btnAgregarPlataforma_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(493, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 22);
            this.label3.TabIndex = 36;
            this.label3.Text = "Imagen:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(12, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 22);
            this.label4.TabIndex = 37;
            this.label4.Text = "Tipo de artículo:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(80, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 22);
            this.label7.TabIndex = 38;
            this.label7.Text = "Género:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DimGray;
            this.label8.Location = new System.Drawing.Point(31, 119);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(135, 22);
            this.label8.TabIndex = 39;
            this.label8.Text = "Desarrollador:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DimGray;
            this.label9.Location = new System.Drawing.Point(37, 155);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(129, 22);
            this.label9.TabIndex = 40;
            this.label9.Text = "Clasificación:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DimGray;
            this.label10.Location = new System.Drawing.Point(50, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 22);
            this.label10.TabIndex = 41;
            this.label10.Text = "Plataforma:";
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(624, 180);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(200, 250);
            this.pictureBox.TabIndex = 42;
            this.pictureBox.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.DimGray;
            this.label11.Location = new System.Drawing.Point(90, 189);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 22);
            this.label11.TabIndex = 45;
            this.label11.Text = "Marca:";
            // 
            // btnAgregarMarca
            // 
            this.btnAgregarMarca.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarMarca.ForeColor = System.Drawing.Color.DimGray;
            this.btnAgregarMarca.Location = new System.Drawing.Point(378, 187);
            this.btnAgregarMarca.Name = "btnAgregarMarca";
            this.btnAgregarMarca.Size = new System.Drawing.Size(32, 29);
            this.btnAgregarMarca.TabIndex = 44;
            this.btnAgregarMarca.Text = "+";
            this.btnAgregarMarca.UseVisualStyleBackColor = true;
            this.btnAgregarMarca.Click += new System.EventHandler(this.btnAgregarMarca_Click);
            // 
            // cboMarca
            // 
            this.cboMarcas.BackColor = System.Drawing.Color.White;
            this.cboMarcas.Enabled = false;
            this.cboMarcas.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMarcas.ForeColor = System.Drawing.Color.DimGray;
            this.cboMarcas.FormattingEnabled = true;
            this.cboMarcas.Location = new System.Drawing.Point(172, 187);
            this.cboMarcas.Name = "cboMarca";
            this.cboMarcas.Size = new System.Drawing.Size(200, 29);
            this.cboMarcas.TabIndex = 43;
            this.cboMarcas.Text = "Selección";
            // 
            // numPrecioUnitario
            // 
            this.numPrecioUnitario.DecimalPlaces = 2;
            this.numPrecioUnitario.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numPrecioUnitario.ForeColor = System.Drawing.Color.DimGray;
            this.numPrecioUnitario.Location = new System.Drawing.Point(586, 77);
            this.numPrecioUnitario.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.numPrecioUnitario.Name = "numPrecioUnitario";
            this.numPrecioUnitario.Size = new System.Drawing.Size(279, 27);
            this.numPrecioUnitario.TabIndex = 46;
            this.numPrecioUnitario.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.DimGray;
            this.label12.Location = new System.Drawing.Point(527, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 22);
            this.label12.TabIndex = 81;
            this.label12.Text = "UPC:";
            // 
            // txtUPC
            // 
            this.txtUPC.BackColor = System.Drawing.Color.White;
            this.txtUPC.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUPC.ForeColor = System.Drawing.Color.DimGray;
            this.txtUPC.Location = new System.Drawing.Point(586, 11);
            this.txtUPC.Name = "txtUPC";
            this.txtUPC.Size = new System.Drawing.Size(279, 27);
            this.txtUPC.TabIndex = 80;
            // 
            // AltaArticulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(877, 437);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtUPC);
            this.Controls.Add(this.numPrecioUnitario);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnAgregarMarca);
            this.Controls.Add(this.cboMarcas);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAgregarPlataforma);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnSubirImagen);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAgregarClasificacion);
            this.Controls.Add(this.btnAgregarDesarrollador);
            this.Controls.Add(this.btnAgregarGenero);
            this.Controls.Add(this.cboPlataformas);
            this.Controls.Add(this.cboClasificaciones);
            this.Controls.Add(this.cboDesarrolladores);
            this.Controls.Add(this.cboGeneros);
            this.Controls.Add(this.cboTiposArticulo);
            this.Controls.Add(this.txtNombre);
            this.Name = "AltaArticulo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar artículo";
            this.Load += new System.EventHandler(this.AltaArticulo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecioUnitario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.ComboBox cboTiposArticulo;
        private System.Windows.Forms.ComboBox cboGeneros;
        private System.Windows.Forms.ComboBox cboDesarrolladores;
        private System.Windows.Forms.ComboBox cboClasificaciones;
        private System.Windows.Forms.ComboBox cboPlataformas;
        private System.Windows.Forms.Button btnAgregarGenero;
        private System.Windows.Forms.Button btnAgregarDesarrollador;
        private System.Windows.Forms.Button btnAgregarClasificacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtDescripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSubirImagen;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnAgregarPlataforma;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnAgregarMarca;
        private System.Windows.Forms.ComboBox cboMarcas;
        private System.Windows.Forms.NumericUpDown numPrecioUnitario;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtUPC;
    }
}