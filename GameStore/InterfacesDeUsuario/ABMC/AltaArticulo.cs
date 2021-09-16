using GameStore.Entidades;
using GameStore.RepositoriosBD;
using GameStore.Servicios;
using GameStore.Servicios.Implementaciones;
using System;
using System.Windows.Forms;

namespace GameStore.InterfacesDeUsuario.ABMC
{
    public partial class AltaArticulo : Form
    {
        private readonly IServicioTipoArticulo _servicioTipoArticulo;
        private readonly IServicioDesarrollador _ServicioDesarrollador;
        private readonly IServicioGenero _servicioGenero;
        private readonly IServicioClasificacion _servicioClasificacion;
        private readonly IServicioPlataforma _servicioPlataforma;
        public AltaArticulo(IUnidadDeTrabajo unidadDeTrabajo)
        {
            InitializeComponent();
            _servicioTipoArticulo = new ServicioTipoArticulo(unidadDeTrabajo.RepositorioTipoArticulo);
            _ServicioDesarrollador = new ServicioDesarrollador(unidadDeTrabajo.RepositorioDesarrollador);
            _servicioGenero = new ServicioGenero(unidadDeTrabajo.RepositorioGenero);
            _servicioClasificacion = new ServicioClasificacion(unidadDeTrabajo.RepositorioClasificacion);
            _servicioPlataforma = new ServicioPlataforma(unidadDeTrabajo.RepositorioPlataforma);
        }

        private void AltaArticulo_Load(object sender, System.EventArgs e)
        {
            CargarTipoArticulos(cmbTipoArticulo);
            CargarDesarrolladores(cmbDesarrollador);
            CargarGeneros(cmbGenero);
            CargarClasificaciones(cmbClasificacion);
            CargarPlataforma(cmbPlataforma);
        }

        private void CargarPlataforma(ComboBox combo)
        {
            var plataformas = this._servicioPlataforma.ListarPlataformas();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = plataformas;
            combo.DataSource = bindingSource;
            combo.DisplayMember = "Nombre";
            combo.ValueMember = "IdPlataforma";
        }

        private void CargarClasificaciones(ComboBox combo)
        {
            var clasificaciones = this._servicioClasificacion.ListarClasificaciones();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = clasificaciones;
            combo.DataSource = bindingSource;
            combo.DisplayMember = "Nombre";
            combo.ValueMember = "IdClasificacion";
        }

        private void CargarTipoArticulos(ComboBox combo)
        {
            var tiposArticulos = this._servicioTipoArticulo.ListarTiposDeArticulo();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = tiposArticulos;
            combo.DataSource = bindingSource;
            combo.DisplayMember = "Nombre";
            combo.ValueMember = "idTipoArticulo";   
        }

        private void CargarDesarrolladores(ComboBox combo)
        {
            var desarrolladores = this._ServicioDesarrollador.ListarDesarrolladores();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = desarrolladores;
            combo.DataSource = bindingSource;
            combo.DisplayMember = "Nombre";
            combo.ValueMember = "IdDesarrollador";
        }

        private void CargarGeneros(ComboBox combo)
        {
            var generos = this._servicioGenero.ListarGeneros();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = generos;
            combo.DataSource = bindingSource;
            combo.DisplayMember = "Nombre";
            combo.ValueMember = "IdGenero";
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            var articuloNuevo = new Articulo();
            articuloNuevo.Nombre = txtNombre.Text;
            articuloNuevo.Descripcion = txtDescripcion.Text;
            articuloNuevo.Clasificacion = (Clasificacion)cmbClasificacion.SelectedItem;
            articuloNuevo.Desarrollador = (Desarrollador)cmbDesarrollador.SelectedItem;
            articuloNuevo.Genero = (Genero)cmbGenero.SelectedItem;
            articuloNuevo.TipoArticulo = (TipoArticulo)cmbTipoArticulo.SelectedItem;
            articuloNuevo.PrecioUnitario = Convert.ToInt32(txtPrecioUnitario.Text);
        }
    }
}
