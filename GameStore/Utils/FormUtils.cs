using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameStore.Utils
{
    public static class FormUtils
    {
        private static object pictureBox;

        public static void CargarCombo(ref ComboBox cb, BindingSource conector, string displayMember, string valueMember)
        {
            if (conector is null)
            {
                throw new ArgumentNullException(nameof(conector));
            }
            cb.DataSource = conector;
            cb.DisplayMember = displayMember;
            cb.ValueMember = valueMember;
            cb.SelectedItem = null;
            cb.Text = "Selección";
        }

        public static bool EsOperacionConfirmada()
        {
            var respuesta = MessageBox.Show("¿Desea confirmar la operación?", "Confirmación", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
                return true;
            return false;
        }
    }
}
