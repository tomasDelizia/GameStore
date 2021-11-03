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

namespace GameStore.InterfacesDeUsuario.PresentacionAlquileres
{
    public partial class ConsultaTarifaAlquiler : Form
    {
        private IUnidadDeTrabajo _unidadDeTrabajo;
        private readonly IServicioTarifaAlquiler _servicioTarifa;
        public ConsultaTarifaAlquiler(IUnidadDeTrabajo unidadDeTrabajo)
        {
            InitializeComponent();
            dgvTarifas.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dgvTarifas.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioTarifa = new ServicioTarifaAlquiler(_unidadDeTrabajo.RepositorioTarifaAlquiler);
        }

        private void ConsultaTarifaAlquiler_Load(object sender, EventArgs e)
        {
            ConsultarTarifas();
        }

        private void ConsultarTarifas()
        {
            var tarifas = _servicioTarifa.ListarTarifasDeAlquiler();
            CargarDgvTarifas(tarifas);
            dgvTarifas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarDgvTarifas(List<TarifaAlquiler> tarifas)
        {
            dgvTarifas.Rows.Clear();
            foreach (TarifaAlquiler tarifa in tarifas)
            {
                var fila = new string[]
                {
                    tarifa.IdTarifaAlquiler.ToString(),
                    tarifa.Nombre,
                    tarifa.Descripcion,
                    tarifa.MontoAlquilerPorDia.ToString(),
                    tarifa.MontoDevolucionTardiaPorDia.ToString(),
                };
                dgvTarifas.Rows.Add(fila);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            var nombreTarifa = txtNombre.Text;
            var tarifasFiltradas = _servicioTarifa.Encontrar(a => a.Nombre.Contains(nombreTarifa)).ToList();
            CargarDgvTarifas(tarifasFiltradas);
        }

        private void btnReiniciarFiltros_Click(object sender, EventArgs e)
        {
            ConsultarTarifas();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            new AltaTarifaAlquiler(_unidadDeTrabajo).ShowDialog();
            ConsultarTarifas();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Validar la cantidad de filas seleccionadas
            if (dgvTarifas.SelectedRows.Count == 1)
            {
                var id = Convert.ToInt32(dgvTarifas.SelectedRows[0].Cells["Id"].Value);

                new ModificacionTarifaAlquiler(_unidadDeTrabajo, id).ShowDialog();
                ConsultarTarifas();
                return;
            }
            else if (dgvTarifas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un registro.", "Información", MessageBoxButtons.OK);
                return;
            }
            else if (dgvTarifas.SelectedRows.Count > 1)
                MessageBox.Show("Debe seleccionar un solo registro, no muchos.", "Información", MessageBoxButtons.OK);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvTarifas.SelectedRows.Count == 1)
            {
                var id = Convert.ToInt32(dgvTarifas.SelectedRows[0].Cells["Id"].Value);

                new BajaTarifaAlquiler(_servicioTarifa, id).ShowDialog();
                ConsultarTarifas();
                return;
            }

            else if (dgvTarifas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un registro.", "Información", MessageBoxButtons.OK);
                return;
            }
            else if (dgvTarifas.SelectedRows.Count > 1)
                MessageBox.Show("Debe seleccionar un solo registro, no muchos.", "Información", MessageBoxButtons.OK);
        }
    }
}
