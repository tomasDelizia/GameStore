using GameStore.Entidades;
using GameStore.RepositoriosBD;
using GameStore.Servicios;
using GameStore.Servicios.Implementaciones;
using System;
using System.Windows.Forms;

namespace GameStore.InterfacesDeUsuario.PresentacionArticulos
{
    public partial class BajaGenero : Form
    {
        private Genero _generoABorrar;
        private IServicioGenero _servicioGenero;
        public BajaGenero(IServicioGenero servicioGenero, int id)
        {
            InitializeComponent();
            _servicioGenero = servicioGenero;
            _generoABorrar = _servicioGenero.GetPorId(id);
        }

        private void BajaGenero_Load(object sender, EventArgs e)
        {
            CargarNombre(TxtNombre);
        }

        private void CargarNombre(TextBox TxtNombre)
        {
            TxtNombre.Text = _generoABorrar.Nombre;
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resultado = MessageBox.Show("Confirmar operación", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (resultado == DialogResult.Cancel)
                    return;
                DarBajaGenero();
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

        private void DarBajaGenero()
        {
            _servicioGenero.Borrar(_generoABorrar);
            MessageBox.Show("La operación se realizó con éxito", "Información");
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
