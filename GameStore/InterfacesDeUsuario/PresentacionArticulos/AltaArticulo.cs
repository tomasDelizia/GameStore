using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using GameStore.Entidades;
using GameStore.RepositoriosBD;
using GameStore.Servicios;
using GameStore.Servicios.Implementaciones;
using GameStore.Utils;

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
        private readonly IServicioTarifaAlquiler _servicioTarifaAlquiler;
        private readonly IServicioEstadoVideojuego _servicioEstadoVideojuego;
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
            _servicioTarifaAlquiler = new ServicioTarifaAlquiler(_unidadDeTrabajo.RepositorioTarifaAlquiler);
            _servicioEstadoVideojuego = new ServicioEstadoVideojuego(_unidadDeTrabajo.RepositorioEstadoVideojuego);
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        private void AltaArticulo_Load(object sender, System.EventArgs e)
        {
            CargarTipoArticulos();
            CargarDesarrolladores();
            CargarGeneros();
            CargarClasificaciones();
            CargarPlataformas();
            CargarMarcas();
        }

        private void CargarMarcas()
        {
            var marcas = _servicioMarca.ListarMarcas();
            FormUtils.CargarCombo(ref cboMarcas, new BindingSource() { DataSource = marcas }, "Nombre", "IdMarca");
        }

        private void CargarPlataformas()
        {
            var plataformas = _servicioPlataforma.ListarPlataformas();
            FormUtils.CargarCombo(ref cboPlataformas, new BindingSource() { DataSource = plataformas }, "Nombre", "IdPlataforma");
        }

        private void CargarClasificaciones()
        {
            var clasificaciones = _servicioClasificacion.ListarClasificaciones();
            FormUtils.CargarCombo(ref cboClasificaciones, new BindingSource() { DataSource = clasificaciones }, "Nombre", "IdClasificacion");
        }

        private void CargarTipoArticulos()
        {
            var tiposArticulos = _servicioTipoArticulo.ListarTiposDeArticulo();
            FormUtils.CargarCombo(ref cboTiposArticulo, new BindingSource() { DataSource = tiposArticulos }, "Nombre", "IdTipoArticulo");
        }

        private void CargarDesarrolladores()
        {
            var desarrolladores = _servicioDesarrollador.ListarDesarrolladores();
            FormUtils.CargarCombo(ref cboDesarrolladores, new BindingSource() { DataSource = desarrolladores }, "Nombre", "IdDesarrollador");
        }

        private void CargarGeneros()
        {
            var generos = _servicioGenero.ListarGeneros();
            FormUtils.CargarCombo(ref cboGeneros, new BindingSource() { DataSource = generos }, "Nombre", "IdGenero");
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
            catch (FormatException fe)
            {
                MessageBox.Show("El código de producto universal solo acepta caracteres numéricos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NullReferenceException nre)
            {
                MessageBox.Show("Complete todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UpdateException ex) when (ex.InnerException is SqlException sqlException && (sqlException.Number == 2627 || sqlException.Number == 2601))
            {
                MessageBox.Show("UPC de artículo duplicado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                var mensaje = ex.Message;
                MessageBox.Show("Ha ocurrido un problema, intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool EsOperacionConfirmada()
        {
            return FormUtils.EsOperacionConfirmada();
        }

        private bool EsArticuloValido()
        {
            var articuloNuevo = new Articulo();
            articuloNuevo.Codigo = Convert.ToInt64(txtUPC.Text);
            articuloNuevo.Nombre = txtNombre.Text;
            articuloNuevo.Descripcion = txtDescripcion.Text;
            articuloNuevo.Stock = 0;
            articuloNuevo.PrecioUnitario = numPrecioUnitario.Value;
            articuloNuevo.FechaSalida = dateTimePicker.Value;
            articuloNuevo.Plataforma = (Plataforma)cboPlataformas.SelectedItem;
            articuloNuevo.TipoArticulo = (TipoArticulo)cboTiposArticulo.SelectedItem;

            articuloNuevo.EstadoVideojuego = _servicioEstadoVideojuego.GetEstadoRegistrado();

            var diferenciaDias = articuloNuevo.GetDiferenciaDias();
            if (diferenciaDias < 90)
                articuloNuevo.TarifaAlquiler = _servicioTarifaAlquiler.GetPorNombre("Estreno");
            else if (diferenciaDias >= 90 && diferenciaDias <= 365)
                articuloNuevo.TarifaAlquiler = _servicioTarifaAlquiler.GetPorNombre("Viejos");
            else if (diferenciaDias > 365)
                articuloNuevo.TarifaAlquiler = _servicioTarifaAlquiler.GetPorNombre("Muy viejos");
            
            var tipoArticulo = articuloNuevo.TipoArticulo;
            if (tipoArticulo != null)
            {
                if (tipoArticulo.Nombre == "Videojuego")
                {
                    articuloNuevo.Genero = (Genero)cboGeneros.SelectedItem;
                    articuloNuevo.Desarrollador = (Desarrollador)cboDesarrolladores.SelectedItem;
                    articuloNuevo.Clasificacion = (Clasificacion)cboClasificaciones.SelectedItem;
                }
                else
                    articuloNuevo.Marca = (Marca)cboMarcas.SelectedItem;
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
            if (cboTiposArticulo.Text == "Videojuego")
            {
                cboGeneros.Enabled = true;
                cboDesarrolladores.Enabled = true;
                cboClasificaciones.Enabled = true;
                cboMarcas.Enabled = false;
                cboMarcas.SelectedItem = null;
            }
            if (cboTiposArticulo.Text == "Periférico" || cboTiposArticulo.Text == "Consola")
            {
                cboGeneros.Enabled = false;
                cboGeneros.SelectedItem = null;
                cboDesarrolladores.Enabled = false;
                cboDesarrolladores.SelectedItem = null;
                cboClasificaciones.Enabled = false;
                cboClasificaciones.SelectedItem = null;
                cboMarcas.Enabled = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAgregarPlataforma_Click(object sender, EventArgs e)
        {
            new AltaPlataforma(_unidadDeTrabajo).ShowDialog();
            CargarPlataformas();
        }

        private void btnAgregarGenero_Click(object sender, EventArgs e)
        {
            new AltaGenero(_unidadDeTrabajo).ShowDialog();
            CargarGeneros();
        }

        private void btnAgregarDesarrollador_Click(object sender, EventArgs e)
        {
            new AltaDesarrollador(_unidadDeTrabajo).ShowDialog();
            CargarDesarrolladores();
        }

        private void btnAgregarClasificacion_Click(object sender, EventArgs e)
        {
            new AltaClasificacion(_unidadDeTrabajo).ShowDialog();
            CargarClasificaciones();
        }

        private void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            new AltaMarca(_unidadDeTrabajo).ShowDialog();
            CargarMarcas();
        }
    }
}
