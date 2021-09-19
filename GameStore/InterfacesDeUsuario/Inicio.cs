using System;
using System.Windows.Forms;
using GameStore.InterfacesDeUsuario.PresentacionArticulos;
using GameStore.InterfacesDeUsuario.PresentacionCompras;
using GameStore.InterfacesDeUsuario.PresentacionEmpleados;
using GameStore.InterfacesDeUsuario.PresentacionSocios;
using GameStore.InterfacesDeUsuario.PresentacionUsuarios;
using GameStore.RepositoriosBD;

namespace GameStore.InterfacesDeUsuario
{
    public partial class Inicio : Form
    {
        private IUnidadDeTrabajo _unidadDeTrabajo;

        public Inicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            InitializeComponent();
            customizeDesign();
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            var frmLogin = new Login(_unidadDeTrabajo);
            frmLogin.ShowDialog();
            this.WindowState = FormWindowState.Maximized;
        }

        private void customizeDesign()
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
            //ShowSubpanel(PnlSubMenuArticulos);
            new ConsultaArticulo(_unidadDeTrabajo).ShowDialog();
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

        // Menú superior
        private void salirDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}