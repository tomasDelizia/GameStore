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
        private IUnidadDeTrabajo _unidadDeTrabajo;
        private readonly IServicioArticulo _servicioArticulo;
        private readonly IServicioTipoArticulo _servicioTipoArticulo;
        private readonly IServicioDesarrollador _servicioDesarrollador;
        private readonly IServicioGenero _servicioGenero;
        private readonly IServicioClasificacion _servicioClasificacion;
        private readonly IServicioPlataforma _servicioPlataforma;
        private readonly IServicioArchivo _servicioArchivo;
        private readonly IServicioMarca _servicioMarca;
        private IUnidadDeTrabajo _unidadDeTrabajo;
        private Archivo _nuevaImagen;
        private Articulo _nuevoArticulo;

        public AltaArticulo(IUnidadDeTrabajo unidadDeTrabajo)
        {
            InitializeComponent();
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioArticulo = new ServicioArticulo(unidadDeTrabajo.RepositorioArticulo);
            _servicioTipoArticulo = new ServicioTipoArticulo(unidadDeTrabajo.RepositorioTipoArticulo);
            _servicioDesarrollador = new ServicioDesarrollador(unidadDeTrabajo.RepositorioDesarrollador);
            _servicioGenero = new ServicioGenero(unidadDeTrabajo.RepositorioGenero);
            _servicioClasificacion = new ServicioClasificacion(unidadDeTrabajo.RepositorioClasificacion);
            _servicioPlataforma = new ServicioPlataforma(unidadDeTrabajo.RepositorioPlataforma);
            _servicioArchivo = new ServicioArchivo(unidadDeTrabajo.RepositorioArchivo);
            _servicioMarca = new ServicioMarca(unidadDeTrabajo.RepositorioMarca);
            _unidadDeTrabajo = unidadDeTrabajo;
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

                _nuevaImagen = new Archivo();
                _nuevaImagen.Nombre = dlgAbrirArchivo.SafeFileName;
                _nuevaImagen.Contenido = contenido;
                
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!EsOperacionConfirmada())
                    return;
                if (!EsArticuloValido())
                    return;
                RegistrarArticulo();
            }
            catch (ApplicationException aex)
            {
                MessageBox.Show(aex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                var mensaje = ex.Message;
                MessageBox.Show("Ha ocurrido un problema, intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool EsOperacionConfirmada()
        {
            var respuesta = MessageBox.Show("¿Desea confirmar la operación?", "Confirmación", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
                return true;
            return false;
        }

        private bool EsArticuloValido()
        {
            var articuloNuevo = new Articulo();
            articuloNuevo.Nombre = txtNombre.Text;
            articuloNuevo.Descripcion = txtDescripcion.Text;
            articuloNuevo.Stock = 0;
            articuloNuevo.PrecioUnitario = numPrecioUnitario.Value;
            articuloNuevo.FechaSalida = dateTimePicker.Value;
            articuloNuevo.Plataforma = (Plataforma)cboPlataforma.SelectedItem;
            articuloNuevo.TipoArticulo = (TipoArticulo)cboTipoArticulo.SelectedItem;
            if (articuloNuevo.TipoArticulo.Nombre == "Videojuego")
            {
                articuloNuevo.Genero = (Genero)cboGenero.SelectedItem;
                articuloNuevo.Desarrollador = (Desarrollador)cboDesarrollador.SelectedItem;
                articuloNuevo.Clasificacion = (Clasificacion)cboClasificacion.SelectedItem;
            }
            else
            {
                articuloNuevo.Marca = (Marca)cboMarca.SelectedItem;
            }
            _servicioArchivo.ValidarArchivo(_nuevaImagen);
            articuloNuevo.Archivo = _nuevaImagen;
            _servicioArticulo.ValidarArticulo(articuloNuevo);
            _nuevoArticulo = articuloNuevo;
            return true;
        }

        private void RegistrarArticulo()
        {
            bool insertarImagen = _servicioArchivo.Insertar(_nuevaImagen);
            bool insertarArticulo = _servicioArticulo.Insertar(_nuevoArticulo);
            if (!insertarImagen)
            {
                MessageBox.Show("Ocurrió un problema al registrar la imagen", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!insertarArticulo)
            {
                MessageBox.Show("Ocurrió un problema al registrar el artículo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            MessageBox.Show("Se registró con éxito el artículo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Dispose();
        }

        private void cboTipoArticulo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboTipoArticulo.Text == "Videojuego")
            {
                cboGenero.Enabled = true;
                cboDesarrollador.Enabled = true;
                cboClasificacion.Enabled = true;
                cboMarca.Enabled = false;
            }
            if (cboTipoArticulo.Text == "Periférico" || cboTipoArticulo.Text == "Consola")
            {
                cboGenero.Enabled = false;
                cboDesarrollador.Enabled = false;
                cboClasificacion.Enabled = false;
                cboMarca.Enabled = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAgregarTipoArticulo_Click(object sender, EventArgs e)
        {
            Form frmAltaTipoArticulo = new AltaTipoArticulo();
            frmAltaTipoArticulo.Show();
        }

        private void btnAgregarPlataforma_Click(object sender, EventArgs e)
        {
            Form frmAltaPlataforma = new AltaPlataforma(_unidadDeTrabajo);
            frmAltaPlataforma.Show();
        }

        private void btnAgregarGenero_Click(object sender, EventArgs e)
        {
            Form frmAltaGenero = new AltaGenero();
            frmAltaGenero.Show();
        }

        private void btnAgregarDesarrollador_Click(object sender, EventArgs e)
        {
            Form frmAltaDesarrollador = new AltaDesarrollador(_unidadDeTrabajo);
            frmAltaDesarrollador.Show();
        }

        private void btnAgregarClasificacion_Click(object sender, EventArgs e)
        {
            Form frmAltaClasificacion = new AltaClasificacion();
            frmAltaClasificacion.Show();
        }

        private void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            Form frmAltaMarca = new AltaMarca();
            frmAltaMarca.Show();
        }
    }
}
