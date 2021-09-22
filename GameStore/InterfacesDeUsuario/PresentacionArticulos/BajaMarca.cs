using GameStore.Entidades;
using GameStore.RepositoriosBD;
using GameStore.Servicios;
using GameStore.Servicios.Implementaciones;
using System;
using System.Windows.Forms;

namespace GameStore.InterfacesDeUsuario.PresentacionArticulos
{
    public partial class BajaMarca : Form
    {
        private Marca _marcaABorrar;
        private IServicioMarca _servicioMarca;
        public BajaMarca(IServicioMarca servicioMarca, int id)
        {
            InitializeComponent();
            _servicioMarca = servicioMarca;
            _marcaABorrar = _servicioMarca.GetPorId(id);
        }

        private void BajaMarca_Load(object sender, EventArgs e)
        {
            CargarNombre(TxtNombre);
        }

        private void CargarNombre(TextBox TxtNombre)
        {
            TxtNombre.Text = _marcaABorrar.Nombre;
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resultado = MessageBox.Show("Confirmar operación", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (resultado == DialogResult.Cancel)
                    return;
                DarBajaMarca();
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
        private void DarBajaMarca()
        {
            _servicioMarca.Borrar(_marcaABorrar);
            MessageBox.Show("La operación se realizó con éxito", "Información");
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
