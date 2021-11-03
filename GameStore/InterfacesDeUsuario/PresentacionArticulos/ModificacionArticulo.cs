using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using GameStore.Entidades;
using GameStore.RepositoriosBD;
using GameStore.Servicios;
using GameStore.Servicios.Implementaciones;

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

        public ModificacionArticulo(IUnidadDeTrabajo unidadDeTrabajo, int codigo)
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
            CargarTipoArticulos(cboTipoArticulo);
            CargarDesarrolladores(cboDesarrollador);
            CargarGeneros(cboGenero);
            CargarClasificaciones(cboClasificacion);
            CargarPlataformas(cboPlataforma);
            CargarMarcas(cboMarca);
            CargarNombre(txtNombre);
            CargarDescripcion(txtDescripcion);
            CargarPrecio(numPrecioUnitario);
            CargarLanzamiento(dateLanzamiento);
            CargarImagen(imgArticulo);
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
            dateLanzamiento.Value = (DateTime)_articuloAModificar.FechaSalida;
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
            combo.SelectedItem = _articuloAModificar.Plataforma;
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
            combo.SelectedItem = _articuloAModificar.Clasificacion;
        }

        private void CargarTipoArticulos(ComboBox combo)
        {
            var tiposArticulos = _servicioTipoArticulo.ListarTiposDeArticulo();

            var bindingSource = new BindingSource();
            bindingSource.DataSource = tiposArticulos;

            combo.DataSource = bindingSource;
            combo.DisplayMember = "Nombre";
            combo.ValueMember = "IdTipoArticulo";
            combo.Text = "Selección";
            combo.SelectedItem = _articuloAModificar.TipoArticulo;
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
            combo.SelectedItem = _articuloAModificar.Desarrollador;
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
            combo.SelectedItem = _articuloAModificar.Genero;
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
            _articuloAModificar.Plataforma = (Plataforma)cboPlataforma.SelectedItem;
            _articuloAModificar.TipoArticulo = (TipoArticulo)cboTipoArticulo.SelectedItem;
            if (_articuloAModificar.TipoArticulo.Nombre == "Videojuego")
            {
                _articuloAModificar.Genero = (Genero)cboGenero.SelectedItem;
                _articuloAModificar.Desarrollador = (Desarrollador)cboDesarrollador.SelectedItem;
                _articuloAModificar.Clasificacion = (Clasificacion)cboClasificacion.SelectedItem;
            }
            else
            {
                _articuloAModificar.Marca = (Marca)cboMarca.SelectedItem;
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
            MessageBox.Show("Se mofificó con éxito el artículo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnAgregarPlataforma_Click(object sender, EventArgs e)
        {
            new AltaPlataforma(_unidadDeTrabajo).ShowDialog();
        }

        private void btnAgregarGenero_Click(object sender, EventArgs e)
        {
            new AltaGenero(_unidadDeTrabajo).ShowDialog();
        }

        private void btnAgregarDesarrollador_Click(object sender, EventArgs e)
        {
            new AltaDesarrollador(_unidadDeTrabajo).ShowDialog();
        }

        private void btnAgregarClasificacion_Click(object sender, EventArgs e)
        {
            new AltaClasificacion(_unidadDeTrabajo).ShowDialog();
        }

        private void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            new AltaMarca(_unidadDeTrabajo).ShowDialog();
        }
    }
}
