using GameStore.RepositoriosBD;
using GameStore.RepositoriosBD.Implementaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameStore.InterfacesDeUsuario.Reportes
{
    public partial class FrmFacturaAlquiler : Form
    {
        private int _nroFactura;
        private IRepositorioReporte _repositorioReporte;
        public FrmFacturaAlquiler(int nroFactura)
        {
            InitializeComponent();
            _nroFactura = nroFactura;
            _repositorioReporte = new RepositorioReporte();
        }

        private void FrmFacturaAlquiler_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
