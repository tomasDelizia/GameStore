using System;
using System.Windows.Forms;

namespace GameStore.InterfacesDeUsuario.ABMC
{
    public partial class AltaSocio : Form
    {
        public AltaSocio()
        {
            InitializeComponent();
        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Registro con exito", "AltaSocio", MessageBoxButtons.OK);
            this.Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
