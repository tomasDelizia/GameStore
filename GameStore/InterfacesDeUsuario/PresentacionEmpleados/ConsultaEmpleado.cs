using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameStore.Entidades;
using GameStore.RepositoriosBD;
using GameStore.Servicios;
using GameStore.Servicios.Implementaciones;

namespace GameStore.InterfacesDeUsuario.PresentacionEmpleados
{
    public partial class ConsultaEmpleado : Form
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;
        private readonly IServicioEmpleado _servicioEmpleado;
        private readonly IServicioCargo _servicioCargo;

        public ConsultaEmpleado(IUnidadDeTrabajo unidadDeTrabajo)
        {
            InitializeComponent();
            dgvEmpleados.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dgvEmpleados.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioCargo = new ServicioCargo(unidadDeTrabajo.RepositorioCargo);
            _servicioEmpleado = new ServicioEmpleado(unidadDeTrabajo.RepositorioEmpleado);
        }

        private void ConsultaEmpleado_Load(object sender, EventArgs e)
        {
            CargarCargos(cboCargos);
            ConsultarEmpleados();
        }

        private void CargarCargos(ComboBox combo)
        {
            var cargos = _servicioCargo.ListarCargos();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = cargos;
            combo.DataSource = bindingSource;
            combo.DisplayMember = "Nombre";
            combo.ValueMember = "IdCargo";
            combo.Text = "Selección";
        }

        private void ConsultarEmpleados()
        {
            var empleados = _servicioEmpleado.ListarEmpleados();
            CargarDgvEmpleados(empleados);
        }

        private void CargarDgvEmpleados(List<Empleado> empleados)
        {
            dgvEmpleados.Rows.Clear();

            foreach (var empleado in empleados)
            {
                var fila = new string[]
                {
                    empleado.IdEmpleado.ToString(),
                    empleado.NroDocumento.ToString(),
                    empleado.Nombre,
                    empleado.Apellido,
                    empleado.Email,
                    empleado.Cargo.Nombre,
                };
                dgvEmpleados.Rows.Add(fila);
            }
        }

        private void btnReiniciarFiltros_Click(object sender, EventArgs e)
        {
            ConsultarEmpleados();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            var nombreEmpleado = txtEmpleado.Text;
            var cargo = (Cargo)cboCargos.SelectedItem;
            var empleadosFiltrados = _servicioEmpleado.Encontrar(emp => (emp.Nombre + " " + emp.Apellido).Contains(nombreEmpleado) && emp.Cargo.Nombre == cargo.Nombre).ToList();
            CargarDgvEmpleados(empleadosFiltrados);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            new AltaEmpleado(_unidadDeTrabajo).ShowDialog();
            ConsultarEmpleados();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            // validar cantidad de filas seleccionadas.
            if (dgvEmpleados.SelectedRows.Count == 1)
            {
                var id = Convert.ToInt32(dgvEmpleados.SelectedRows[0].Cells["IdEmpleado"].Value);
                new ModificacionEmpleado(_unidadDeTrabajo, id).ShowDialog();
                ConsultarEmpleados();
                return;
            }

            else if (dgvEmpleados.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un registro.", "Información", MessageBoxButtons.OK);
                return;
            }
            else if (dgvEmpleados.SelectedRows.Count > 1)
                MessageBox.Show("Debe seleccionar un solo registro, no muchos.", "Información", MessageBoxButtons.OK);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.SelectedRows.Count == 1)
            {
                var id = Convert.ToInt32(dgvEmpleados.SelectedRows[0].Cells["IdEmpleado"].Value);

                new BajaEmpleado(_servicioEmpleado, id).ShowDialog();
                ConsultarEmpleados();
                return;
            }

            else if (dgvEmpleados.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un registro.", "Información", MessageBoxButtons.OK);
                return;
            }
            else if (dgvEmpleados.SelectedRows.Count > 1)
                MessageBox.Show("Debe seleccionar un solo registro, no muchos.", "Información", MessageBoxButtons.OK);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
