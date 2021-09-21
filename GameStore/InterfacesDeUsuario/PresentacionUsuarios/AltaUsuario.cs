using GameStore.RepositoriosBD;
using GameStore.Servicios;
using GameStore.Servicios.Implementaciones;
using System;
using System.Windows.Forms;

namespace GameStore.InterfacesDeUsuario.PresentacionUsuarios
{
    public partial class AltaUsuario : Form
    {
        private readonly IServicioRol _servicioRoles;
        public AltaUsuario(IUnidadDeTrabajo unidadDeTrabajo)
        {
            InitializeComponent();
            _servicioRoles = new ServicioRol(unidadDeTrabajo.RepositorioRol);
        }

        private void AltaUsuario_Load(object sender, System.EventArgs e)
        {
            CargarRoles(cmbRoles); //Error en una consulta SQL "el nombre de la columna Usuario_IdUsuario no es valido"
        }

        private void CargarRoles(ComboBox cmbRoles)
        {
            var roles = _servicioRoles.ListarRoles();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = roles;
            cmbRoles.DataSource = bindingSource;
            cmbRoles.DisplayMember = "Nombre";
            cmbRoles.ValueMember = "IdRol";

        }
    }
}
