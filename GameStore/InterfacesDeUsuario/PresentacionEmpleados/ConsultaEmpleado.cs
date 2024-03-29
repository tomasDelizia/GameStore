﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameStore.Entidades;
using GameStore.InterfacesDeUsuario.PresentacionCompras;
using GameStore.InterfacesDeUsuario.PresentacionVentas;
using GameStore.InterfacesDeUsuario.PresentacionAlquileres;
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
        private ConsultaVenta _consultaVenta;
        private ConsultaCompra _consultaCompra;
        private ConsultaAlquiler _consultaAlquiler;

        public ConsultaEmpleado(IUnidadDeTrabajo unidadDeTrabajo)
        {
            InitializeComponent();
            dgvEmpleados.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dgvEmpleados.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioCargo = new ServicioCargo(unidadDeTrabajo.RepositorioCargo);
            _servicioEmpleado = new ServicioEmpleado(unidadDeTrabajo.RepositorioEmpleado);
            btnSeleccionar.Visible = false;
        }

        public ConsultaEmpleado(IUnidadDeTrabajo unidadDeTrabajo, ConsultaVenta consultaVenta)
        {
            InitializeComponent();
            dgvEmpleados.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dgvEmpleados.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioCargo = new ServicioCargo(unidadDeTrabajo.RepositorioCargo);
            _servicioEmpleado = new ServicioEmpleado(unidadDeTrabajo.RepositorioEmpleado);
            btnModificar.Visible = false;
            btnEliminar.Visible = false;
            _consultaVenta = consultaVenta;
        }

        public ConsultaEmpleado(IUnidadDeTrabajo unidadDeTrabajo, ConsultaCompra consultaCompra)
        {
            InitializeComponent();
            dgvEmpleados.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dgvEmpleados.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioCargo = new ServicioCargo(unidadDeTrabajo.RepositorioCargo);
            _servicioEmpleado = new ServicioEmpleado(unidadDeTrabajo.RepositorioEmpleado);
            btnModificar.Visible = false;
            btnEliminar.Visible = false;
            _consultaCompra = consultaCompra;
        }

        public ConsultaEmpleado(IUnidadDeTrabajo unidadDeTrabajo, ConsultaAlquiler consultaAlquiler)
        {
            InitializeComponent();
            dgvEmpleados.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dgvEmpleados.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioCargo = new ServicioCargo(unidadDeTrabajo.RepositorioCargo);
            _servicioEmpleado = new ServicioEmpleado(unidadDeTrabajo.RepositorioEmpleado);
            btnModificar.Visible = false;
            btnEliminar.Visible = false;
            _consultaAlquiler = consultaAlquiler;
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
            ckbIncluirTodos.Checked = false;
            var empleados = _servicioEmpleado.ListarEmpleadosActivos();
            CargarDgvEmpleados(empleados);
        }

        private void CargarDgvEmpleados(List<Empleado> empleados)
        {
            dgvEmpleados.Rows.Clear();

            foreach (var empleado in empleados)
            {
                var descripcionEstado = (bool)empleado.Estado ? "Activo" : "Inactivo";
                var fila = new string[]
                {
                    empleado.IdEmpleado.ToString(),
                    empleado.NroDocumento.ToString(),
                    empleado.Nombre,
                    empleado.Apellido,
                    empleado.Email,
                    empleado.Cargo.Nombre,
                    descripcionEstado
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

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dgvEmpleados.SelectedRows[0].Cells["IdEmpleado"].Value);
                var empleado = _servicioEmpleado.GetPorId(id);
                if (_consultaVenta != null)
                    _consultaVenta.SetVendedorFiltro(empleado);
                else if (_consultaAlquiler != null)
                    _consultaAlquiler.SetVendedorFiltro(empleado);
                else if (_consultaCompra != null)
                    _consultaCompra.SetCompradorFiltro(empleado);
                this.Dispose();
                return;
            }
            else if (dgvEmpleados.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un registro.", "Información", MessageBoxButtons.OK);
            }
            else if (dgvEmpleados.SelectedRows.Count > 1)
                MessageBox.Show("Debe seleccionar un solo registro, no muchos.", "Información", MessageBoxButtons.OK);
        }

        private void ckbIncluirTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbIncluirTodos.Checked)
            {
                var empleados = _servicioEmpleado.ListarEmpleados();
                CargarDgvEmpleados(empleados);
            }
            else
                ConsultarEmpleados();
        }
    }
}
