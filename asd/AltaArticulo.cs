using GameStore.RepositoriosBD;
using GameStore.Servicios;
using GameStore.Servicios.Implementaciones;
using System.Windows.Forms;

namespace GameStore.InterfacesDeUsuario.ABMC
{
    public partial class AltaArticulo : Form
    {
        private readonly IServicioArticulo _servicioArticulo;
        public AltaArticulo(IUnidadDeTrabajo unidadDeTrabajo)
        {
            InitializeComponent();
            _servicioArticulo = new ServicioArticulo(unidadDeTrabajo.RepositorioArticulo);
        }

        private void AltaArticulo_Load(object sender, System.EventArgs e)
        {
            CargarTipoArticulos(cmbTipoArticulo);
        }

        private void CargarTipoArticulos(ComboBox combo)
        {
            var tiposArticulos = this._servicioArticulo.ListarArticulos();
            foreach (var tipoArticulo in tiposArticulos)
            {
                combo.Items.Add(tipoArticulo);
            }
        }
    }
}
