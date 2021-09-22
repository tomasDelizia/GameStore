using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameStore.Entidades;
using GameStore.RepositoriosBD;
using GameStore.Servicios;
using GameStore.Servicios.Implementaciones;

namespace GameStore.InterfacesDeUsuario.PresentacionVentas    
{
    public partial class ConsultaFormaPago : Form
    {
        private IUnidadDeTrabajo _unidadDeTrabajo;
        private readonly IServicioFormaPago _servicioFormaPago;
        public ConsultaFormaPago(IUnidadDeTrabajo unidadDeTrabajo)
        {
            InitializeComponent();
            dgvFormaPago.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dgvFormaPago.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioFormaPago = new ServicioFormaPago(unidadDeTrabajo.RepositorioFormaPago);
        }

        private void ConsultaFormaPago_Load(object sender, EventArgs e)
        {
            ConsultarFormaPago();
        }

        private void ConsultarFormaPago()
        {
            var formaPago = _servicioFormaPago.ListarFormaPago();
            CargarDgvFormaPago(formaPago);
            dgvFormaPago.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarDgvFormaPago(List<FormaPago> formaPagos)
        {
            dgvFormaPago.Rows.Clear();

            foreach (var desarrollador in formaPagos)
            {
                var fila = new string[]
                {
                    desarrollador.IdFormaPago.ToString(),
                    desarrollador.Nombre,
                    desarrollador.Descripcion,
                };
                dgvFormaPago.Rows.Add(fila);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            var nombreFormaPago = txtNombre.Text.Trim();
            if (nombreFormaPago.Length > 50)
                throw new ApplicationException("El nombre no debe tener más de 50 caracteres.");

            var Descripcion = txtDescripcion.Text.Trim();

            var FormaPagoFiltradas = _servicioFormaPago.Encontrar(a => a.Nombre.Contains(nombreFormaPago)).ToList();

            CargarDgvFormaPago(FormaPagoFiltradas);
        }

        private void btnReiniciarFiltros_Click(object sender, EventArgs e)
        {
            ConsultarFormaPago();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            new AltaFormaPago(_unidadDeTrabajo).ShowDialog();
            ConsultarFormaPago();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvFormaPago.SelectedRows.Count == 1)
            {
                var id = Convert.ToInt32(dgvFormaPago.SelectedRows[0].Cells["IdFormaPago"].Value);

                new ModificacionFormaPago(_unidadDeTrabajo, id).ShowDialog();
                ConsultarFormaPago();
                return;
            }
            else if (dgvFormaPago.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un registro.", "Información", MessageBoxButtons.OK);
                return;
            }
            else if (dgvFormaPago.SelectedRows.Count > 1)
                MessageBox.Show("Debe seleccionar un solo registro, no muchos.", "Información", MessageBoxButtons.OK);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvFormaPago.SelectedRows.Count == 1)
            {
                var id = Convert.ToInt32(dgvFormaPago.SelectedRows[0].Cells["IdFormaPago"].Value);

                new BajaFormaPago(_servicioFormaPago, id).ShowDialog();
                ConsultarFormaPago();
                return;
            }

            else if (dgvFormaPago.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un registro.", "Información", MessageBoxButtons.OK);
                return;
            }
            else if (dgvFormaPago.SelectedRows.Count > 1)
                MessageBox.Show("Debe seleccionar un solo registro, no muchos.", "Información", MessageBoxButtons.OK);

        }
    }
}
