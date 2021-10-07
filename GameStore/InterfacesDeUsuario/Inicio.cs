using System;
using System.Windows.Forms;
using GameStore.InterfacesDeUsuario.PresentacionAlquileres;
using GameStore.InterfacesDeUsuario.PresentacionArticulos;
using GameStore.InterfacesDeUsuario.PresentacionCompras;
using GameStore.InterfacesDeUsuario.PresentacionEmpleados;
using GameStore.InterfacesDeUsuario.PresentacionSocios;
using GameStore.InterfacesDeUsuario.PresentacionUsuarios;
using GameStore.InterfacesDeUsuario.PresentacionVentas;
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
            new Login(_unidadDeTrabajo).ShowDialog();
            this.WindowState = FormWindowState.Maximized;
        }

        private void customizeDesign()
        {
            PnlSubmenuABM.Visible = false;
            PnlSubMenuReporte.Visible = false;
            PnlSubMenuOtros.Visible = false;
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
            if (PnlSubMenuOtros.Visible == true)
                PnlSubMenuOtros.Visible = false;
        }
        private void ShowSubPanel(Panel SubMenu)
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

        private void BtnABM_Click(object sender, EventArgs e)
        {
            ShowSubMenu(PnlSubmenuABM);
        }

        private void BtnSocio_Click(object sender, EventArgs e)
        {
            new ConsultaSocio(_unidadDeTrabajo).ShowDialog();
        }

        private void BtnArticulos_Click(object sender, EventArgs e)
        {
            new ConsultaArticulo(_unidadDeTrabajo).ShowDialog();
        }

        private void BtnProveedores_Click(object sender, EventArgs e)
        {
            new ConsultaProveedor(_unidadDeTrabajo).ShowDialog();
        }

        private void BtnUsuario_Click(object sender, EventArgs e)
        {
            new ConsultaUsuario(_unidadDeTrabajo).ShowDialog();
        }

        private void BtnEmpleado_Click(object sender, EventArgs e)
        {
            new ConsultaEmpleado(_unidadDeTrabajo).ShowDialog();  
        }

        private void BtnOtros_Click(object sender, EventArgs e)
        {
            ShowSubPanel(PnlSubMenuOtros);
        }

        private void BtnCargo_Click(object sender, EventArgs e)
        {
            new ConsultarCargo(_unidadDeTrabajo).ShowDialog();
        }

        private void BtnCategoriaAlquiler_Click(object sender, EventArgs e)
        {
            new ConsultaCategoriaAlquiler(_unidadDeTrabajo).ShowDialog();
        }

        private void BtnClasificacion_Click(object sender, EventArgs e)
        {
            new ConsultaClasificacion(_unidadDeTrabajo).ShowDialog();
        }

        private void BtnDesarrollador_Click(object sender, EventArgs e)
        {
            new ConsultaDesarrollador(_unidadDeTrabajo).ShowDialog();
        }

        private void BtnFormaPago_Click(object sender, EventArgs e)
        {
            new ConsultaFormaPago(_unidadDeTrabajo).ShowDialog();
        }

        private void BtnGenero_Click(object sender, EventArgs e)
        {
            new ConsultaGenero(_unidadDeTrabajo).ShowDialog();
        }

        private void BtnMarca_Click(object sender, EventArgs e)
        {
            new ConsultaMarca(_unidadDeTrabajo).ShowDialog();
        }

        private void BtnPerfil_Click(object sender, EventArgs e)
        {
            new ConsultaPerfil(_unidadDeTrabajo).ShowDialog();
        }

        private void BtnPlataforma_Click(object sender, EventArgs e)
        {
            new ConsultaPlataforma(_unidadDeTrabajo).ShowDialog();
        }

        private void BtnReporte_Click(object sender, EventArgs e)
        {
            ShowSubMenu(PnlSubMenuReporte);
        }

        private void BtnCompraProveedor_Click(object sender, EventArgs e)
        {
            new RegistrarCompra(_unidadDeTrabajo).ShowDialog();
	}

        private void BtnRegistrarVenta_Click(object sender, EventArgs e)
        {
            new RegistrarVenta(_unidadDeTrabajo).ShowDialog();
        }
    }
}