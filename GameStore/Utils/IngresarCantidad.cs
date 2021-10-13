using GameStore.InterfacesDeUsuario.PresentacionCompras;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameStore.Utils
{
    public partial class IngresarCantidad : Form
    {
        private int _cantidad;
        private RegistrarCompra _registrarCompra;
        public IngresarCantidad()
        {
            InitializeComponent();
            _cantidad = 0;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            _cantidad = Convert.ToInt32(txtCantidad.Text);
            this.Hide();
        }

        public int GetCantidad()
        {
            return _cantidad;
        }
        public void SetFormularioCompra(RegistrarCompra registrarCompra)
        {
        }
    }
}
