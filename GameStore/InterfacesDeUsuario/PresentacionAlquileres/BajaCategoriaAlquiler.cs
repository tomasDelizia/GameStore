using GameStore.Entidades;
using GameStore.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameStore.InterfacesDeUsuario.PresentacionAlquileres
{
    public partial class BajaCategoriaAlquiler : Form
    {
        private IServicioCategoriaAlquiler _servicioCategoriaAlquiler;
        private CategoriaAlquiler _categoriaABorrar;
        public BajaCategoriaAlquiler(IServicioCategoriaAlquiler servicioCategoriaAlquiler, int id)
        {
            InitializeComponent();
            _servicioCategoriaAlquiler = servicioCategoriaAlquiler;
            _categoriaABorrar = _servicioCategoriaAlquiler.GetPorId(id);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void BajaCategoriaAlquiler_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            txtNombre.Text = _categoriaABorrar.Nombre;
            txtPrecio.Text = _categoriaABorrar.MontoAlquilerPorDia.ToString();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resultado = MessageBox.Show("Confirmar operación", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (resultado == DialogResult.Cancel)
                    return;
                DarBajaCategoria();
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

        private void DarBajaCategoria()
        {
            _servicioCategoriaAlquiler.Borrar(_categoriaABorrar);
            MessageBox.Show("La operación se realizó con éxito", "Información");
        }
    }
}
