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

namespace GameStore.InterfacesDeUsuario.PresentacionEmpleados
{
    public partial class ConsultarCargo : Form
    {
        private IUnidadDeTrabajo _unidadDeTrabajo;
        private readonly IServicioCargo _servicioCargo;

        public ConsultarCargo(IUnidadDeTrabajo unidadDeTrabajo)
        {
            InitializeComponent();
            dgvCargos.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dgvCargos.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioCargo = new ServicioCargo(unidadDeTrabajo.RepositorioCargo);
        }

        private void ConsultarCargo_Load(object sender, EventArgs e)
        {
            ConsultarCargos();
        }

        private void ConsultarCargos()
        {
            var cargos = _servicioCargo.ListarCargos();
            CargarDgvCargos(cargos);
            dgvCargos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarDgvCargos(List<Cargo> cargos)
        {
            dgvCargos.Rows.Clear();
            foreach (Cargo cargo in cargos)
            {
                var fila = new string[]
                {
                    cargo.IdCargo.ToString(),
                    cargo.Nombre,
                    cargo.Descripcion,
                };
                dgvCargos.Rows.Add(fila);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            new AltaCargo(_unidadDeTrabajo).ShowDialog();
            ConsultarCargos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Validar la cantidad de filas seleccionadas
            if (dgvCargos.SelectedRows.Count == 1)
            {
                var id = Convert.ToInt32(dgvCargos.SelectedRows[0].Cells["Id"].Value);

                new ModificacionCargo(_unidadDeTrabajo, id).ShowDialog();
                ConsultarCargos();
                return;
            }
            else if (dgvCargos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un registro.", "Información", MessageBoxButtons.OK);
                return;
            }
            else if (dgvCargos.SelectedRows.Count > 1)
                MessageBox.Show("Debe seleccionar un solo registro, no muchos.", "Información", MessageBoxButtons.OK);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCargos.SelectedRows.Count == 1)
            {
                var id = Convert.ToInt32(dgvCargos.SelectedRows[0].Cells["Id"].Value);

                new BajaCargo(_servicioCargo, id).ShowDialog();
                ConsultarCargos();
                return;
            }

            else if (dgvCargos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un registro.", "Información", MessageBoxButtons.OK);
                return;
            }
            else if (dgvCargos.SelectedRows.Count > 1)
                MessageBox.Show("Debe seleccionar un solo registro, no muchos.", "Información", MessageBoxButtons.OK);
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            var nombreCargo = txtNombre.Text;
            var cargosFiltrados = _servicioCargo.Encontrar(a => a.Nombre.Contains(nombreCargo)).ToList();
            CargarDgvCargos(cargosFiltrados);
        }

        private void btnReiniciarFiltros_Click(object sender, EventArgs e)
        {
            ConsultarCargos();
        }
    }
}
