using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameStore.RepositoriosBD;

namespace GameStore.InterfacesDeUsuario
{
    public abstract partial class TransaccionBase : Form, ITransaccionBase
    {
        public abstract void btnAgregarArticulo_Click(object sender, EventArgs e);
    }
}
