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

namespace GameStore.InterfacesDeUsuario.PresentacionArticulos
{
    public partial class BajaPlataforma : Form
    {
        private readonly IServicioPlataforma _servicioPlataforma;
        private Plataforma _plataformaABorrar;
        public BajaPlataforma(IServicioPlataforma servicioPlataforma, int id)
        {
            InitializeComponent();
            _servicioPlataforma = servicioPlataforma;
            _plataformaABorrar = _servicioPlataforma.GetPorId(id);
        }

        private void BajaPlataforma_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            txtNombre.Text = _plataformaABorrar.Nombre;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resultado = MessageBox.Show("Confirmar operación", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (resultado == DialogResult.Cancel)
                    return;
                DarBajaPlataforma();
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

        private void DarBajaPlataforma()
        {
            _servicioPlataforma.Borrar(_plataformaABorrar);
            MessageBox.Show("La operación se realizó con éxito", "Información");
        }
    }
}
