using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using GameStore.Entidades;
using GameStore.RepositoriosBD;
using GameStore.Servicios;
using GameStore.Servicios.Implementaciones;

namespace GameStore.InterfacesDeUsuario.PresentacionArticulos
{
    public partial class AltaArticulo : Form
    {
        private readonly IServicioArticulo _servicioArticulo;
        private readonly IServicioTipoArticulo _servicioTipoArticulo;
        private readonly IServicioDesarrollador _servicioDesarrollador;
        private readonly IServicioGenero _servicioGenero;
        private readonly IServicioClasificacion _servicioClasificacion;
        private readonly IServicioPlataforma _servicioPlataforma;
        private readonly IServicioArchivo _servicioArchivo;
        private readonly IServicioMarca _servicioMarca;
        private Archivo _imagen;

        public AltaArticulo(IUnidadDeTrabajo unidadDeTrabajo)
        {
            InitializeComponent();
            _servicioArticulo = new ServicioArticulo(unidadDeTrabajo.RepositorioArticulo);
            _servicioTipoArticulo = new ServicioTipoArticulo(unidadDeTrabajo.RepositorioTipoArticulo);
            _servicioDesarrollador = new ServicioDesarrollador(unidadDeTrabajo.RepositorioDesarrollador);
            _servicioGenero = new ServicioGenero(unidadDeTrabajo.RepositorioGenero);
            _servicioClasificacion = new ServicioClasificacion(unidadDeTrabajo.RepositorioClasificacion);
            _servicioPlataforma = new ServicioPlataforma(unidadDeTrabajo.RepositorioPlataforma);
            _servicioArchivo = new ServicioArchivo(unidadDeTrabajo.RepositorioArchivo);
            _servicioMarca = new ServicioMarca(unidadDeTrabajo.RepositorioMarca);
        }

        private void AltaArticulo_Load(object sender, System.EventArgs e)
        {
            CargarTipoArticulos(cboTipoArticulo);
            CargarDesarrolladores(cboDesarrollador);
            CargarGeneros(cboGenero);
            CargarClasificaciones(cboClasificacion);
            CargarPlataformas(cboPlataforma);
            CargarMarcas(cboMarca);
        }

        private void CargarMarcas(ComboBox combo)
        {
            var marcas = _servicioMarca.ListarMarcas();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = marcas;
            combo.DataSource = bindingSource;
            combo.DisplayMember = "Nombre";
            combo.ValueMember = "IdMarca";
            combo.Text = "Selección";
        }

        private void CargarPlataformas(ComboBox combo)
        {
            var plataformas = _servicioPlataforma.ListarPlataformas();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = plataformas;
            combo.DataSource = bindingSource;
            combo.DisplayMember = "Nombre";
            combo.ValueMember = "IdPlataforma";
            combo.Text = "Selección";
        }

        private void CargarClasificaciones(ComboBox combo)
        {
            var clasificaciones = _servicioClasificacion.ListarClasificaciones();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = clasificaciones;
            combo.DataSource = bindingSource;
            combo.DisplayMember = "Nombre";
            combo.ValueMember = "IdClasificacion";
            combo.Text = "Selección";
        }

        private void CargarTipoArticulos(ComboBox combo)
        {
            var tiposArticulos = _servicioTipoArticulo.ListarTiposDeArticulo();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = tiposArticulos;
            combo.DataSource = bindingSource;
            combo.DisplayMember = "Nombre";
            combo.ValueMember = "IdTipoArticulo";
            combo.SelectedItem = null;
            combo.Text = "Selección";


        }

        private void CargarDesarrolladores(ComboBox combo)
        {
            var desarrolladores = _servicioDesarrollador.ListarDesarrolladores();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = desarrolladores;
            combo.DataSource = bindingSource;
            combo.DisplayMember = "Nombre";
            combo.ValueMember = "IdDesarrollador";
            combo.Text = "Selección";
        }

        private void CargarGeneros(ComboBox combo)
        {
            var generos = _servicioGenero.ListarGeneros();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = generos;
            combo.DataSource = bindingSource;
            combo.DisplayMember = "Nombre";
            combo.ValueMember = "IdGenero";
            combo.Text = "Selección";
        }

        private void btnSubirImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgAbrirArchivo = new OpenFileDialog();
            dlgAbrirArchivo.Filter = "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg";
            if (dlgAbrirArchivo.ShowDialog() == DialogResult.OK)
            {
                string nombreImagen = dlgAbrirArchivo.FileName;
                Image imagen = new Bitmap(nombreImagen);

                pictureBox.Image = imagen;
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

                FileStream fstream = new FileStream(@nombreImagen, FileMode.Open, FileAccess.Read);
                byte[] contenido = new byte[fstream.Length];
                fstream.Read(contenido, 0, Convert.ToInt32(fstream.Length));
                fstream.Close();

                _imagen = new Archivo();
                _imagen.Nombre = dlgAbrirArchivo.SafeFileName;
                _imagen.Contenido = contenido;
                
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            var articuloNuevo = new Articulo();
            articuloNuevo.Nombre = txtNombre.Text;
            articuloNuevo.Descripcion = txtDescripcion.Text;
            articuloNuevo.Stock = 0;
            articuloNuevo.Clasificacion = (Clasificacion)cboClasificacion.SelectedItem;
            articuloNuevo.Desarrollador = (Desarrollador)cboDesarrollador.SelectedItem;
            articuloNuevo.Genero = (Genero)cboGenero.SelectedItem;
            articuloNuevo.TipoArticulo = (TipoArticulo)cboTipoArticulo.SelectedItem;
            articuloNuevo.PrecioUnitario = Convert.ToInt32(txtPrecioUnitario.Text);
            articuloNuevo.FechaSalida = dateTimePicker.Value;

            _servicioArchivo.Insertar(_imagen);
            articuloNuevo.Archivo = _imagen;
            _servicioArticulo.Insertar(articuloNuevo);
        }

        private void cboTipoArticulo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void cboTipoArticulo_Click(object sender, EventArgs e)
        {

        }

        private void cboTipoArticulo_Enter(object sender, EventArgs e)
        {

        }

        private void cboTipoArticulo_TextUpdate(object sender, EventArgs e)
        {
            if (cboTipoArticulo.Text == "Videojuego")
            {
                cboGenero.Enabled = true;
                cboDesarrollador.Enabled = true;
                cboPlataforma.Enabled = true;
                cboClasificacion.Enabled = true;
            }
        }

        private void cboTipoArticulo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboTipoArticulo.Text == "Videojuego")
            {
                cboGenero.Enabled = true;
                cboDesarrollador.Enabled = true;
                cboPlataforma.Enabled = true;
                cboClasificacion.Enabled = true;
            }
            else
            {
                cboGenero.Enabled = false;
                cboDesarrollador.Enabled = false;
                cboPlataforma.Enabled = false;
                cboClasificacion.Enabled = false;
            }
        }
    }
}
