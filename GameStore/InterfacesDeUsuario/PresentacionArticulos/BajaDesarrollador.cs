using GameStore.Entidades;
using GameStore.RepositoriosBD;
using GameStore.Servicios;
using GameStore.Servicios.Implementaciones;
using System;
using System.Windows.Forms;

namespace GameStore.InterfacesDeUsuario.PresentacionArticulos
{
    public partial class BajaDesarrollador : Form
    {
        private Desarrollador _desarrolladorABorrar;
        private IServicioDesarrollador _servicioDesarrollador;
        public BajaDesarrollador(IServicioDesarrollador servicioDesarrollador, int id)
        {
            InitializeComponent();
            _servicioDesarrollador = servicioDesarrollador;
            _desarrolladorABorrar = _servicioDesarrollador.GetPorId(id);
        }

        private void BajaDesarrollador_Load(object sender, EventArgs e)
        {
            CargarNombre(TxtNombre);
            CargarDescripcion(TxtDescripcion);
        }

        private void CargarNombre(TextBox TxtNombre)
        {
            TxtNombre.Text = _desarrolladorABorrar.Nombre;
        }

        private void CargarDescripcion(RichTextBox TxtDescripcion)
        {
            TxtDescripcion.Text = _desarrolladorABorrar.Descripcion;
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resultado = MessageBox.Show("Confirmar operación", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (resultado == DialogResult.Cancel)
                    return;
                DarBajaDesarrollador();
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

        private void DarBajaDesarrollador()
        {
            _servicioDesarrollador.Borrar(_desarrolladorABorrar);
            MessageBox.Show("La operación se realizó con éxito", "Información");
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
