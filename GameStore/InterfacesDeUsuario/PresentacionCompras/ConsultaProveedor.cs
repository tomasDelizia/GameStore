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

namespace GameStore.InterfacesDeUsuario.PresentacionCompras
{
    public partial class ConsultaProveedor : Form
    {
        private IServicioProveedor _servicioProveedor;
        private IUnidadDeTrabajo _unidadDeTrabajo;
        private IServicioBarrio _servicioBarrio;
        private RegistrarCompra _registrarCompra;
        private ConsultaCompra _consultaCompra;

        public ConsultaProveedor(IUnidadDeTrabajo unidadDeTrabajo)
        {
            InitializeComponent();
            dgvProveedores.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dgvProveedores.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioBarrio = new ServicioBarrio(unidadDeTrabajo.RepositorioBarrio);
            _servicioProveedor = new ServicioProveedor(unidadDeTrabajo.RepositorioProveedor);
            btnSeleccionar.Visible = false;
        }

        public ConsultaProveedor(IUnidadDeTrabajo unidadDeTrabajo, RegistrarCompra frmRegistrarCompra)
        {
            InitializeComponent();
            dgvProveedores.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dgvProveedores.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioBarrio = new ServicioBarrio(unidadDeTrabajo.RepositorioBarrio);
            _servicioProveedor = new ServicioProveedor(unidadDeTrabajo.RepositorioProveedor);
            btnModificar.Visible = false;
            btnEliminar.Visible = false;
            _registrarCompra = frmRegistrarCompra;
        }

        public ConsultaProveedor(IUnidadDeTrabajo unidadDeTrabajo, ConsultaCompra consultaVenta)
        {
            InitializeComponent();
            dgvProveedores.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dgvProveedores.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioProveedor = new ServicioProveedor(_unidadDeTrabajo.RepositorioProveedor);
            _servicioBarrio = new ServicioBarrio(unidadDeTrabajo.RepositorioBarrio);
            ocultarBotonesDeConsulta();
            _consultaCompra = consultaVenta;

        }

        private void ocultarBotonesDeConsulta()
        {
            btnModificar.Visible = false;
            btnEliminar.Visible = false;
        }

        private void ConsultaProveedor_Load(object sender, EventArgs e)
        {
            CargarBarrios(cmbBarrio);
            ConsultarProveedores();
        }

        private void ConsultarProveedores()
        {
            ckbIncluirTodos.Checked = false;
            var proveedores = _servicioProveedor.ListarProveedoresActivos();
            CargarDgvProveedores(proveedores);
            dgvProveedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarDgvProveedores(List<Proveedor> proveedores)
        {
            dgvProveedores.Rows.Clear();
            foreach(var proveedor in proveedores)
            {
                var descripcionEstado = (bool)proveedor.Estado ? "Activo" : "Inactivo";
                var fila = new string[]
                {
                    proveedor.IdProveedor.ToString(),
                    proveedor.RazonSocial,
                    proveedor.Cuit.ToString(),
                    proveedor.Email,
                    proveedor.Telefono,
                    proveedor.CalleNombre,
                    proveedor.CalleNumero.ToString(),
                    proveedor.Barrio.Nombre,
                    descripcionEstado
                };
                dgvProveedores.Rows.Add(fila);
            }
        }

        private void CargarBarrios(ComboBox combo)
        {
            var barrios = _servicioBarrio.ListarBarrios();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = barrios;
            combo.DataSource = bindingSource;
            combo.DisplayMember = "Nombre";
            combo.ValueMember = "IdBarrio";
            combo.Text = "Selección";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            new AltaProveedor(_unidadDeTrabajo).ShowDialog();
            ConsultarProveedores();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Validar la cantidad de filas seleccionadas
            if (dgvProveedores.SelectedRows.Count == 1)
            {
                var id = Convert.ToInt32(dgvProveedores.SelectedRows[0].Cells["Id"].Value);

                new ModificacionProveedor(_unidadDeTrabajo, id).ShowDialog();
                ConsultarProveedores();
                return;
            }
            else if (dgvProveedores.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un registro.", "Información", MessageBoxButtons.OK);
                return;
            }
            else if (dgvProveedores.SelectedRows.Count > 1)
                MessageBox.Show("Debe seleccionar un solo registro, no muchos.", "Información", MessageBoxButtons.OK);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.SelectedRows.Count == 1)
            {
                var id = Convert.ToInt32(dgvProveedores.SelectedRows[0].Cells["Id"].Value);

                new BajaProveedor(_servicioProveedor, id).ShowDialog();
                ConsultarProveedores();
                return;
            }

            else if (dgvProveedores.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un registro.", "Información", MessageBoxButtons.OK);
                return;
            }
            else if (dgvProveedores.SelectedRows.Count > 1)
                MessageBox.Show("Debe seleccionar un solo registro, no muchos.", "Información", MessageBoxButtons.OK);
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            var razonSocial = txtRazonSocial.Text.Trim();
            if (razonSocial.Length > 50)
                throw new ApplicationException("La razón social no debe tener más de 50 caracteres.");

            var barrio = (Barrio)cmbBarrio.SelectedItem;
            if (barrio == null)
            {
                barrio = new Barrio();
                barrio.Nombre = "";
            }

            var proveedoresFiltrados = _servicioProveedor.Encontrar(a => a.RazonSocial.Contains(razonSocial) && a.Barrio.Nombre == barrio.Nombre).ToList();

            CargarDgvProveedores(proveedoresFiltrados);
        }

        private void btnReiniciarFiltros_Click(object sender, EventArgs e)
        {
            ConsultarProveedores();
        }

        private void dgvProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dgvProveedores.SelectedRows[0].Cells["Id"].Value);
                var proveedor = _servicioProveedor.GetPorId(id);
                _registrarCompra.SetProveedor(proveedor);
                this.Dispose();
                return;
            }
            else if (dgvProveedores.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un registro.", "Información", MessageBoxButtons.OK);
            }
            else if (dgvProveedores.SelectedRows.Count > 1)
                MessageBox.Show("Debe seleccionar un solo registro, no muchos.", "Información", MessageBoxButtons.OK);
        }

        private void ckbIncluirTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbIncluirTodos.Checked)
            {
                var proveedores = _servicioProveedor.ListarProveedores();
                CargarDgvProveedores(proveedores);
            }
            else
                ConsultarProveedores();
        }
    }
}
