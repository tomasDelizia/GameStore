using GameStore.InterfacesDeUsuario.PresentacionCompras;
using GameStore.InterfacesDeUsuario.PresentacionVentas;
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
        private int _cantidad, _stock;

        public IngresarCantidad(int stock)
        {
            InitializeComponent();
            _cantidad = 0;
            _stock = stock;
        }

        public IngresarCantidad()
        {
            InitializeComponent();
            _cantidad = 0;
            _stock = -1;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                _cantidad = Convert.ToInt32(txtCantidad.Text);
                if (_stock >= 0 && _cantidad > _stock)
                    throw new ApplicationException("Ingrese una cantidad menor o igual a " + _stock);
                if (_cantidad <= 0)
                    throw new ApplicationException("Ingrese una cantidad mayor a cero");
                this.Hide();
            }
            catch (ApplicationException aex)
            {
                MessageBox.Show(aex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ingrese una cantidad válida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public int GetCantidad()
        {
            return _cantidad;
        }
    }
}
