using System;
using System.Windows.Forms;
using GameStore.InterfacesDeUsuario.ABMC;

namespace GameStore.InterfacesDeUsuario
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
            customizeDesing();
        }

        private void customizeDesing()
        {
            PnlSubmenuABM.Visible = false;
            PnlSubMenuReporte.Visible = false;
            PnlSubMenuArticulos.Visible = false;
            PnlSubMenuProveedores.Visible = false;
            PnlSubMenuSocios.Visible = false;
            PnlSubMenuUsuarios.Visible = false;
            PnlSubMenuEmpleados.Visible = false;
        }

        private void hideSubMenu() 
        {
            if (PnlSubmenuABM.Visible == true)
                PnlSubmenuABM.Visible = false;
            if (PnlSubMenuReporte.Visible == true)
                PnlSubMenuReporte.Visible = false;
        }

        private void hidePanel() 
        {
            if (PnlSubMenuArticulos.Visible == true)
                PnlSubMenuArticulos.Visible = false;
            if (PnlSubMenuSocios.Visible == true)
                PnlSubMenuSocios.Visible = false;
            if (PnlSubMenuProveedores.Visible == true)
                PnlSubMenuProveedores.Visible = false;
            if (PnlSubMenuUsuarios.Visible == true)
                PnlSubMenuUsuarios.Visible = false;
            if (PnlSubMenuEmpleados.Visible == true)
                PnlSubMenuEmpleados.Visible = false;
        }

        private void ShowSubMenu(Panel SubMenu) 
        {
            if (SubMenu.Visible == false)
            {
                hideSubMenu();
                SubMenu.Visible = true;
            }
            else 
            {
                SubMenu.Visible = false;
            }
        }

        private void ShowSubpanel(Panel SubMenu)
        {
            if (SubMenu.Visible == false)
            {
                hidePanel();
                SubMenu.Visible = true;
            }
            else
            {
                SubMenu.Visible = false;
            }
        }

        private void BtnABM_Click(object sender, EventArgs e)
        {
            ShowSubMenu(PnlSubmenuABM);
        }

        private void BtnSocio_Click(object sender, EventArgs e)
        {
            ShowSubpanel(PnlSubMenuSocios);
        }

        private void BtnArticulos_Click(object sender, EventArgs e)
        {
            ShowSubpanel(PnlSubMenuArticulos);
        }
        private void BtnProveedores_Click(object sender, EventArgs e)
        {
            ShowSubpanel(PnlSubMenuProveedores);
        }

        private void BtnUsuario_Click(object sender, EventArgs e)
        {
            ShowSubpanel(PnlSubMenuUsuarios);
        }
        private void BtnEmpleado_Click(object sender, EventArgs e)
        {
            ShowSubpanel(PnlSubMenuEmpleados);
        }

        private void BtnReporte_Click(object sender, EventArgs e)
        {
            ShowSubMenu(PnlSubMenuReporte);
        }

        //Diferentes AMB
        private void BtnNuevoSocio_Click(object sender, EventArgs e)
        {
            Form frmAltaSocio = new AltaSocio();
            frmAltaSocio.Show();
        }

        private void BtnModificarSocio_Click(object sender, EventArgs e)
        {
            Form frmModificacionSocio = new ModificacionSocio();
            frmModificacionSocio.Show();
        }

        private void BtnEliminarSocio_Click(object sender, EventArgs e)
        {
            Form frmBajaSocio = new BajaSocio();
            frmBajaSocio.Show();
        }

        private void BtnNuevoArticulo_Click(object sender, EventArgs e)
        {
            Form frmAltaArticulo = new AltaArticulo();
            frmAltaArticulo.Show();
        }

        private void BtnModificarArticulo_Click(object sender, EventArgs e)
        {
            Form frmModificarArticulo = new ModificacionArticulo();
            frmModificarArticulo.Show();
        }

        private void BtnEliminarArticulo_Click(object sender, EventArgs e)
        {
            Form frmBajaArticulo = new BajaArticulo();
            frmBajaArticulo.Show();
        }

        private void BtnNuevoProveedores_Click(object sender, EventArgs e)
        {
            Form frmAltaProveedor = new AltaProveedor();
            frmAltaProveedor.Show();
        }

        private void BtnModificarProveedores_Click(object sender, EventArgs e)
        {
            Form frmModificarProveedor = new ModificarProveedor();
            frmModificarProveedor.Show();
        }

        private void BtnEliminarProveedores_Click(object sender, EventArgs e)
        {
            Form frmBajaProveedor = new BajaProveedor();
            frmBajaProveedor.Show();
        }

        private void BtnNuevoUsuario_Click(object sender, EventArgs e)
        {
            Form frmAltaUsuario = new AltaUsuario();
            frmAltaUsuario.Show();
        }

        private void BtnModificarUsuario_Click(object sender, EventArgs e)
        {
            Form frmModificarUsuario = new ModificacionUsuario();
            frmModificarUsuario.Show();
        }

        private void BtnEliminarUsuario_Click(object sender, EventArgs e)
        {
            Form frmBajaUsuario = new BajaUsuario();
            frmBajaUsuario.Show();
        }

        private void BtnNuevoEmpleado_Click(object sender, EventArgs e)
        {
            Form frmAltaEmpleado = new AltaEmpleado();
            frmAltaEmpleado.Show();
        }

        private void BtnModificarEmpleado_Click(object sender, EventArgs e)
        {
            Form frmModificarEmpleado = new ModificacionEmpleado();
            frmModificarEmpleado.Show();
        }

        private void BtnEliminarEmpleado_Click(object sender, EventArgs e)
        {
            Form frmBajaEmpleado = new BajaEmpleado();
            frmBajaEmpleado.Show();
        }

        // Menu de arriba
        private void salirDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}