using GameStore.RepositoriosBD;
using GameStore.Servicios;
using GameStore.Servicios.Implementaciones;
using System.Windows.Forms;

namespace GameStore.InterfacesDeUsuario.ABMC
{
    public partial class AltaArticulo : Form
    {
        private readonly IServicioTipoArticulo _servicioTipoArticulo;
        public AltaArticulo(IUnidadDeTrabajo unidadDeTrabajo)
        {
            InitializeComponent();
            _servicioTipoArticulo = new ServicioTipoArticulo(unidadDeTrabajo.RepositorioTipoArticulo);
        }

        private void AltaArticulo_Load(object sender, System.EventArgs e)
        {
            CargarTipoArticulos(cmbTipoArticulo);
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
    }
}
