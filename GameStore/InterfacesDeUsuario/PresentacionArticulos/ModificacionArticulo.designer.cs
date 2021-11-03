
namespace GameStore.InterfacesDeUsuario.PresentacionArticulos
{
    partial class ModificacionArticulo
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
            this.numPrecioUnitario = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.btnAgregarMarca = new System.Windows.Forms.Button();
            this.cboMarca = new System.Windows.Forms.ComboBox();
            this.imgArticulo = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAgregarPlataforma = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.dateLanzamiento = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSubirImagen = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAgregarClasificacion = new System.Windows.Forms.Button();
            this.btnAgregarDesarrollador = new System.Windows.Forms.Button();
            this.btnAgregarGenero = new System.Windows.Forms.Button();
            this.cboPlataforma = new System.Windows.Forms.ComboBox();
            this.cboClasificacion = new System.Windows.Forms.ComboBox();
            this.cboDesarrollador = new System.Windows.Forms.ComboBox();
            this.cboGenero = new System.Windows.Forms.ComboBox();
            this.cboTipoArticulo = new System.Windows.Forms.ComboBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtUPC = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecioUnitario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgArticulo)).BeginInit();
            this.SuspendLayout();
            // 
            // numPrecioUnitario
            // 
            this.numPrecioUnitario.DecimalPlaces = 2;
            this.numPrecioUnitario.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numPrecioUnitario.ForeColor = System.Drawing.Color.DimGray;
            this.numPrecioUnitario.Location = new System.Drawing.Point(593, 75);
            this.numPrecioUnitario.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.numPrecioUnitario.Name = "numPrecioUnitario";
            this.numPrecioUnitario.Size = new System.Drawing.Size(279, 27);
            this.numPrecioUnitario.TabIndex = 77;
            this.numPrecioUnitario.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.DimGray;
            this.label11.Location = new System.Drawing.Point(90, 184);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 22);
            this.label11.TabIndex = 76;
            this.label11.Text = "Marca:";
            // 
            // btnAgregarMarca
            // 
            this.btnAgregarMarca.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarMarca.ForeColor = System.Drawing.Color.DimGray;
            this.btnAgregarMarca.Location = new System.Drawing.Point(378, 182);
            this.btnAgregarMarca.Name = "btnAgregarMarca";
            this.btnAgregarMarca.Size = new System.Drawing.Size(32, 29);
            this.btnAgregarMarca.TabIndex = 75;
            this.btnAgregarMarca.Text = "+";
            this.btnAgregarMarca.UseVisualStyleBackColor = true;
            this.btnAgregarMarca.Click += new System.EventHandler(this.btnAgregarMarca_Click);
            // 
            // cboMarca
            // 
            this.cboMarca.BackColor = System.Drawing.Color.White;
            this.cboMarca.Enabled = false;
            this.cboMarca.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMarca.ForeColor = System.Drawing.Color.DimGray;
            this.cboMarca.FormattingEnabled = true;
            this.cboMarca.Location = new System.Drawing.Point(172, 182);
            this.cboMarca.Name = "cboMarca";
            this.cboMarca.Size = new System.Drawing.Size(200, 29);
            this.cboMarca.TabIndex = 74;
            this.cboMarca.Text = "Selección";
            // 
            // imgArticulo
            // 
            this.imgArticulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgArticulo.Location = new System.Drawing.Point(631, 178);
            this.imgArticulo.Name = "imgArticulo";
            this.imgArticulo.Size = new System.Drawing.Size(200, 250);
            this.imgArticulo.TabIndex = 73;
            this.imgArticulo.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DimGray;
            this.label10.Location = new System.Drawing.Point(50, 44);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 22);
            this.label10.TabIndex = 72;
            this.label10.Text = "Plataforma:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DimGray;
            this.label9.Location = new System.Drawing.Point(37, 150);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(129, 22);
            this.label9.TabIndex = 71;
            this.label9.Text = "Clasificación:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DimGray;
            this.label8.Location = new System.Drawing.Point(31, 114);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(135, 22);
            this.label8.TabIndex = 70;
            this.label8.Text = "Desarrollador:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(80, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 22);
            this.label7.TabIndex = 69;
            this.label7.Text = "Género:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 22);
            this.label4.TabIndex = 68;
            this.label4.Text = "Tipo de artículo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(500, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 22);
            this.label3.TabIndex = 67;
            this.label3.Text = "Imagen:";
            // 
            // btnAgregarPlataforma
            // 
            this.btnAgregarPlataforma.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarPlataforma.ForeColor = System.Drawing.Color.DimGray;
            this.btnAgregarPlataforma.Location = new System.Drawing.Point(378, 42);
            this.btnAgregarPlataforma.Name = "btnAgregarPlataforma";
            this.btnAgregarPlataforma.Size = new System.Drawing.Size(32, 29);
            this.btnAgregarPlataforma.TabIndex = 66;
            this.btnAgregarPlataforma.Text = "+";
            this.btnAgregarPlataforma.UseVisualStyleBackColor = true;
            this.btnAgregarPlataforma.Click += new System.EventHandler(this.btnAgregarPlataforma_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.Color.DimGray;
            this.btnModificar.Location = new System.Drawing.Point(381, 394);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(100, 34);
            this.btnModificar.TabIndex = 58;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.DimGray;
            this.btnCancelar.Location = new System.Drawing.Point(487, 394);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 34);
            this.btnCancelar.TabIndex = 59;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // dateLanzamiento
            // 
            this.dateLanzamiento.CalendarForeColor = System.Drawing.Color.DimGray;
            this.dateLanzamiento.CalendarTitleForeColor = System.Drawing.Color.DimGray;
            this.dateLanzamiento.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateLanzamiento.Location = new System.Drawing.Point(593, 108);
            this.dateLanzamiento.Name = "dateLanzamiento";
            this.dateLanzamiento.Size = new System.Drawing.Size(279, 27);
            this.dateLanzamiento.TabIndex = 57;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(427, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(160, 22);
            this.label6.TabIndex = 65;
            this.label6.Text = "Fecha de salida:";
            // 
            // btnSubirImagen
            // 
            this.btnSubirImagen.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubirImagen.ForeColor = System.Drawing.Color.DimGray;
            this.btnSubirImagen.Location = new System.Drawing.Point(593, 141);
            this.btnSubirImagen.Name = "btnSubirImagen";
            this.btnSubirImagen.Size = new System.Drawing.Size(279, 31);
            this.btnSubirImagen.TabIndex = 56;
            this.btnSubirImagen.Text = "Cambiar imagen";
            this.btnSubirImagen.UseVisualStyleBackColor = true;
            this.btnSubirImagen.Click += new System.EventHandler(this.btnSubirImagen_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(443, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 22);
            this.label5.TabIndex = 64;
            this.label5.Text = "Precio unitario:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(498, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 22);
            this.label2.TabIndex = 63;
            this.label2.Text = "Nombre:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.AccessibleRole = System.Windows.Forms.AccessibleRole.SplitButton;
            this.txtDescripcion.BackColor = System.Drawing.Color.White;
            this.txtDescripcion.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.ForeColor = System.Drawing.Color.DimGray;
            this.txtDescripcion.Location = new System.Drawing.Point(19, 252);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(568, 136);
            this.txtDescripcion.TabIndex = 55;
            this.txtDescripcion.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(15, 227);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 22);
            this.label1.TabIndex = 54;
            this.label1.Text = "Descripción:";
            // 
            // btnAgregarClasificacion
            // 
            this.btnAgregarClasificacion.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarClasificacion.ForeColor = System.Drawing.Color.DimGray;
            this.btnAgregarClasificacion.Location = new System.Drawing.Point(378, 147);
            this.btnAgregarClasificacion.Name = "btnAgregarClasificacion";
            this.btnAgregarClasificacion.Size = new System.Drawing.Size(32, 29);
            this.btnAgregarClasificacion.TabIndex = 62;
            this.btnAgregarClasificacion.Text = "+";
            this.btnAgregarClasificacion.UseVisualStyleBackColor = true;
            this.btnAgregarClasificacion.Click += new System.EventHandler(this.btnAgregarClasificacion_Click);
            // 
            // btnAgregarDesarrollador
            // 
            this.btnAgregarDesarrollador.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarDesarrollador.ForeColor = System.Drawing.Color.DimGray;
            this.btnAgregarDesarrollador.Location = new System.Drawing.Point(378, 112);
            this.btnAgregarDesarrollador.Name = "btnAgregarDesarrollador";
            this.btnAgregarDesarrollador.Size = new System.Drawing.Size(32, 29);
            this.btnAgregarDesarrollador.TabIndex = 61;
            this.btnAgregarDesarrollador.Text = "+";
            this.btnAgregarDesarrollador.UseVisualStyleBackColor = true;
            this.btnAgregarDesarrollador.Click += new System.EventHandler(this.btnAgregarDesarrollador_Click);
            // 
            // btnAgregarGenero
            // 
            this.btnAgregarGenero.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarGenero.ForeColor = System.Drawing.Color.DimGray;
            this.btnAgregarGenero.Location = new System.Drawing.Point(378, 77);
            this.btnAgregarGenero.Name = "btnAgregarGenero";
            this.btnAgregarGenero.Size = new System.Drawing.Size(32, 29);
            this.btnAgregarGenero.TabIndex = 53;
            this.btnAgregarGenero.Text = "+";
            this.btnAgregarGenero.UseVisualStyleBackColor = true;
            this.btnAgregarGenero.Click += new System.EventHandler(this.btnAgregarGenero_Click);
            // 
            // cboPlataforma
            // 
            this.cboPlataforma.BackColor = System.Drawing.Color.White;
            this.cboPlataforma.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPlataforma.ForeColor = System.Drawing.Color.DimGray;
            this.cboPlataforma.FormattingEnabled = true;
            this.cboPlataforma.Location = new System.Drawing.Point(172, 42);
            this.cboPlataforma.Name = "cboPlataforma";
            this.cboPlataforma.Size = new System.Drawing.Size(200, 29);
            this.cboPlataforma.TabIndex = 52;
            this.cboPlataforma.Text = "Selección";
            // 
            // cboClasificacion
            // 
            this.cboClasificacion.BackColor = System.Drawing.Color.White;
            this.cboClasificacion.Enabled = false;
            this.cboClasificacion.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboClasificacion.ForeColor = System.Drawing.Color.DimGray;
            this.cboClasificacion.FormattingEnabled = true;
            this.cboClasificacion.Location = new System.Drawing.Point(172, 147);
            this.cboClasificacion.Name = "cboClasificacion";
            this.cboClasificacion.Size = new System.Drawing.Size(200, 29);
            this.cboClasificacion.TabIndex = 51;
            this.cboClasificacion.Text = "Selección";
            // 
            // cboDesarrollador
            // 
            this.cboDesarrollador.BackColor = System.Drawing.Color.White;
            this.cboDesarrollador.Enabled = false;
            this.cboDesarrollador.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDesarrollador.ForeColor = System.Drawing.Color.DimGray;
            this.cboDesarrollador.FormattingEnabled = true;
            this.cboDesarrollador.Location = new System.Drawing.Point(172, 112);
            this.cboDesarrollador.Name = "cboDesarrollador";
            this.cboDesarrollador.Size = new System.Drawing.Size(200, 29);
            this.cboDesarrollador.TabIndex = 50;
            this.cboDesarrollador.Text = "Selección";
            // 
            // cboGenero
            // 
            this.cboGenero.BackColor = System.Drawing.Color.White;
            this.cboGenero.Enabled = false;
            this.cboGenero.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboGenero.ForeColor = System.Drawing.Color.DimGray;
            this.cboGenero.FormattingEnabled = true;
            this.cboGenero.Location = new System.Drawing.Point(172, 77);
            this.cboGenero.Name = "cboGenero";
            this.cboGenero.Size = new System.Drawing.Size(200, 29);
            this.cboGenero.TabIndex = 49;
            this.cboGenero.Text = "Selección";
            // 
            // cboTipoArticulo
            // 
            this.cboTipoArticulo.BackColor = System.Drawing.Color.White;
            this.cboTipoArticulo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoArticulo.ForeColor = System.Drawing.Color.DimGray;
            this.cboTipoArticulo.FormattingEnabled = true;
            this.cboTipoArticulo.Location = new System.Drawing.Point(172, 7);
            this.cboTipoArticulo.Name = "cboTipoArticulo";
            this.cboTipoArticulo.Size = new System.Drawing.Size(200, 29);
            this.cboTipoArticulo.TabIndex = 48;
            this.cboTipoArticulo.Text = "Selección";
            this.cboTipoArticulo.SelectedValueChanged += new System.EventHandler(this.cboTipoArticulo_SelectedValueChanged);
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.White;
            this.txtNombre.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.ForeColor = System.Drawing.Color.DimGray;
            this.txtNombre.Location = new System.Drawing.Point(593, 42);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(279, 27);
            this.txtNombre.TabIndex = 47;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.DimGray;
            this.label12.Location = new System.Drawing.Point(534, 11);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 22);
            this.label12.TabIndex = 79;
            this.label12.Text = "UPC:";
            // 
            // txtUPC
            // 
            this.txtUPC.BackColor = System.Drawing.Color.White;
            this.txtUPC.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUPC.ForeColor = System.Drawing.Color.DimGray;
            this.txtUPC.Location = new System.Drawing.Point(593, 9);
            this.txtUPC.Name = "txtUPC";
            this.txtUPC.ReadOnly = true;
            this.txtUPC.Size = new System.Drawing.Size(279, 27);
            this.txtUPC.TabIndex = 78;
            // 
            // ModificacionArticulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(884, 436);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtUPC);
            this.Controls.Add(this.numPrecioUnitario);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnAgregarMarca);
            this.Controls.Add(this.cboMarca);
            this.Controls.Add(this.imgArticulo);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAgregarPlataforma);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.dateLanzamiento);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnSubirImagen);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAgregarClasificacion);
            this.Controls.Add(this.btnAgregarDesarrollador);
            this.Controls.Add(this.btnAgregarGenero);
            this.Controls.Add(this.cboPlataforma);
            this.Controls.Add(this.cboClasificacion);
            this.Controls.Add(this.cboDesarrollador);
            this.Controls.Add(this.cboGenero);
            this.Controls.Add(this.cboTipoArticulo);
            this.Controls.Add(this.txtNombre);
            this.Name = "ModificacionArticulo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ModificacionArticulo";
            this.Load += new System.EventHandler(this.ModificacionArticulo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numPrecioUnitario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgArticulo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numPrecioUnitario;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnAgregarMarca;
        private System.Windows.Forms.ComboBox cboMarca;
        private System.Windows.Forms.PictureBox imgArticulo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAgregarPlataforma;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DateTimePicker dateLanzamiento;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSubirImagen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox txtDescripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAgregarClasificacion;
        private System.Windows.Forms.Button btnAgregarDesarrollador;
        private System.Windows.Forms.Button btnAgregarGenero;
        private System.Windows.Forms.ComboBox cboPlataforma;
        private System.Windows.Forms.ComboBox cboClasificacion;
        private System.Windows.Forms.ComboBox cboDesarrollador;
        private System.Windows.Forms.ComboBox cboGenero;
        private System.Windows.Forms.ComboBox cboTipoArticulo;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtUPC;
    }
}