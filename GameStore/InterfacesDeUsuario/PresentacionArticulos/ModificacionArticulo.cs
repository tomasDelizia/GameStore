using System;
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
    public partial class ModificacionArticulo : Form
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
        private Archivo _nuevaImagen;
        private Articulo _articuloAModificar;

        public ModificacionArticulo(IUnidadDeTrabajo unidadDeTrabajo, long codigo)
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
            _articuloAModificar = _servicioArticulo.GetPorId(codigo);
        }

        private void ModificacionArticulo_Load(object sender, System.EventArgs e)
        {
            CargarTipoArticulos();
            CargarDesarrolladores();
            CargarGeneros();
            CargarClasificaciones();
            CargarPlataformas();
            CargarMarcas();
            CargarNombre(txtNombre);
            CargarDescripcion(txtDescripcion);
            CargarPrecio(numPrecioUnitario);
            CargarLanzamiento(dateLanzamiento);
            CargarImagen(imgArticulo);
            CargarUPC(txtUPC);
        }

        private void CargarUPC(TextBox txtUPC)
        {
            txtUPC.Text = _articuloAModificar.Codigo.ToString();
        }

        private void CargarImagen(PictureBox imgArticulo)
        {
            byte[] contenidoImagen = _articuloAModificar.Archivo.Contenido;
            MemoryStream memorystream = new MemoryStream(contenidoImagen, 0, contenidoImagen.Length);
            Image imagen = Image.FromStream(memorystream);
            imgArticulo.Image = imagen;
            imgArticulo.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void CargarLanzamiento(DateTimePicker dateLanzamiento)
        {
            dateLanzamiento.Value = _articuloAModificar.FechaSalida;
        }

        private void CargarPrecio(NumericUpDown numPrecioUnitario)
        {
            numPrecioUnitario.Value = _articuloAModificar.PrecioUnitario;
        }

        private void CargarDescripcion(RichTextBox txtDescripcion)
        {
            txtDescripcion.Text = _articuloAModificar.Descripcion.ToString();
        }

        private void CargarNombre(TextBox txtNombre)
        {
            txtNombre.Text = _articuloAModificar.Nombre.ToString();
        }

        private void CargarMarcas()
        {
            var marcas = _servicioMarca.ListarMarcas();
            FormUtils.CargarCombo(ref cboMarcas, new BindingSource() { DataSource = marcas }, "Nombre", "IdMarca");
            if (!_articuloAModificar.EsVideojuego())
                cboMarcas.SelectedItem = _articuloAModificar.Marca;
        }

        private void CargarPlataformas()
        {
            var plataformas = _servicioPlataforma.ListarPlataformas();
            FormUtils.CargarCombo(ref cboPlataformas, new BindingSource() { DataSource = plataformas }, "Nombre", "IdPlataforma");
            cboPlataformas.SelectedItem = _articuloAModificar.Plataforma;
        }

        private void CargarClasificaciones()
        {
            var clasificaciones = _servicioClasificacion.ListarClasificaciones();
            FormUtils.CargarCombo(ref cboClasificaciones, new BindingSource() { DataSource = clasificaciones }, "Nombre", "IdClasificacion");
            if (_articuloAModificar.EsVideojuego())
                cboClasificaciones.SelectedItem = _articuloAModificar.Clasificacion;
        }

        private void CargarTipoArticulos()
        {
            var tiposArticulos = _servicioTipoArticulo.ListarTiposDeArticulo();
            FormUtils.CargarCombo(ref cboTiposArticulo, new BindingSource() { DataSource = tiposArticulos }, "Nombre", "IdTipoArticulo");
            cboTiposArticulo.SelectedItem = _articuloAModificar.TipoArticulo;
        }

        private void CargarDesarrolladores()
        {
            var desarrolladores = _servicioDesarrollador.ListarDesarrolladores();
            FormUtils.CargarCombo(ref cboDesarrolladores, new BindingSource() { DataSource = desarrolladores }, "Nombre", "IdDesarrollador");
            if (_articuloAModificar.EsVideojuego())
                cboDesarrolladores.SelectedItem = _articuloAModificar.Desarrollador;
        }

        private void CargarGeneros()
        {
            var generos = _servicioGenero.ListarGeneros();
            FormUtils.CargarCombo(ref cboGeneros, new BindingSource() { DataSource = generos }, "Nombre", "IdGenero");
            if (_articuloAModificar.EsVideojuego())
                cboGeneros.SelectedItem = _articuloAModificar.Genero;
        }

        private void btnSubirImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgAbrirArchivo = new OpenFileDialog();
            dlgAbrirArchivo.Filter = "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg";
            if (dlgAbrirArchivo.ShowDialog() == DialogResult.OK)
            {
                string nombreImagen = dlgAbrirArchivo.FileName;
                Image imagen = new Bitmap(nombreImagen);

                imgArticulo.Image = imagen;
                imgArticulo.SizeMode = PictureBoxSizeMode.StretchImage;

                FileStream fstream = new FileStream(@nombreImagen, FileMode.Open, FileAccess.Read);
                byte[] contenido = new byte[fstream.Length];
                fstream.Read(contenido, 0, Convert.ToInt32(fstream.Length));
                fstream.Close();

                _nuevaImagen = new Archivo();
                _nuevaImagen.Nombre = dlgAbrirArchivo.SafeFileName;
                _nuevaImagen.Contenido = contenido;

            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!EsOperacionConfirmada())
                    return;
                if (!EsArticuloValido())
                    return;
                ModificarArticulo();
            }
            catch (ApplicationException aex)
            {
                MessageBox.Show(aex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException fe)
            {
                MessageBox.Show("El código de producto universal solo acepta caracteres numéricos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            var respuesta = MessageBox.Show("¿Desea confirmar la operación?", "Confirmación", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
                return true;
            return false;

        }

        private bool EsArticuloValido()
        {
            _articuloAModificar.Nombre = txtNombre.Text;
            _articuloAModificar.Descripcion = txtDescripcion.Text;
            _articuloAModificar.Stock = 0;
            _articuloAModificar.PrecioUnitario = numPrecioUnitario.Value;
            _articuloAModificar.FechaSalida = dateLanzamiento.Value;
            _articuloAModificar.Plataforma = (Plataforma)cboPlataformas.SelectedItem;
            _articuloAModificar.TipoArticulo = (TipoArticulo)cboTiposArticulo.SelectedItem;
            if (_articuloAModificar.TipoArticulo.Nombre == "Videojuego")
            {
                _articuloAModificar.Genero = (Genero)cboGeneros.SelectedItem;
                _articuloAModificar.Desarrollador = (Desarrollador)cboDesarrolladores.SelectedItem;
                _articuloAModificar.Clasificacion = (Clasificacion)cboClasificaciones.SelectedItem;
            }
            else
            {
                _articuloAModificar.Marca = (Marca)cboMarcas.SelectedItem;
            }
            if (_nuevaImagen != null)
            {
                _servicioArchivo.ValidarArchivo(_nuevaImagen);
                _articuloAModificar.Archivo = _nuevaImagen;
            }
            _servicioArticulo.ValidarArticulo(_articuloAModificar);
            return true;
        }

        private void ModificarArticulo()
        {
            _servicioArticulo.Actualizar(_articuloAModificar);
            MessageBox.Show("Se modificó con éxito el artículo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            }
            if (cboTiposArticulo.Text == "Periférico" || cboTiposArticulo.Text == "Consola")
            {
                cboGeneros.Enabled = false;
                cboDesarrolladores.Enabled = false;
                cboClasificaciones.Enabled = false;
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
