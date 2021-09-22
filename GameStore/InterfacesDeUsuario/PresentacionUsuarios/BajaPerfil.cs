using GameStore.Entidades;
using GameStore.RepositoriosBD;
using GameStore.Servicios;
using GameStore.Servicios.Implementaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameStore.InterfacesDeUsuario.PresentacionUsuarios
{
    public partial class BajaPerfil : Form
    {
        private readonly IServicioPerfil _servicioPerfil;
        private Perfil _perfilABorrar;
        public BajaPerfil(IServicioPerfil servicioPerfil, int id)
        {
            InitializeComponent();
            _servicioPerfil = servicioPerfil;
            _perfilABorrar = _servicioPerfil.GetPorId(id);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void BajaPerfil_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            txtNombre.Text = _perfilABorrar.Nombre;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resultado = MessageBox.Show("Confirmar operación", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (resultado == DialogResult.Cancel)
                    return;
                DarBajaPerfil();
                this.Dispose();
            }
            catch (ApplicationException aex)
            {
                MessageBox.Show(aex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un problema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DarBajaPerfil()
        {
            _servicioPerfil.Borrar(_perfilABorrar);
            MessageBox.Show("La operación se realizó con éxito", "Información");
        }
    }
}
