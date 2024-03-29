﻿using GameStore.Entidades;
using GameStore.InterfacesDeUsuario.PresentacionAlquileres;
using GameStore.InterfacesDeUsuario.PresentacionVentas;
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

namespace GameStore.InterfacesDeUsuario.PresentacionSocios
{
    public partial class ConsultaSocio : Form
    {
        private IUnidadDeTrabajo _unidadDeTrabajo;
        private IServicioSocio _servicioSocio;
        private RegistrarAlquiler _registrarAlquiler;
        private RegistrarVenta _registrarVenta;
        private ConsultaVenta _consultaVenta;
        private ConsultaAlquiler _consultaAlquiler;

        public ConsultaSocio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            InitializeComponent();
            dgvSocios.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dgvSocios.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioSocio = new ServicioSocio(_unidadDeTrabajo.RepositorioSocio);
            btnSeleccionar.Visible = false;
        }

        public ConsultaSocio(IUnidadDeTrabajo unidadDeTrabajo, RegistrarAlquiler frmRegistrarAlquiler)
        {
            InitializeComponent();
            dgvSocios.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dgvSocios.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioSocio = new ServicioSocio(_unidadDeTrabajo.RepositorioSocio);
            btnModificar.Visible = false;
            btnEliminar.Visible = false;
            _registrarAlquiler = frmRegistrarAlquiler;
        }

        public ConsultaSocio(IUnidadDeTrabajo unidadDeTrabajo, RegistrarVenta registrarVenta)
        {
            InitializeComponent();
            dgvSocios.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dgvSocios.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioSocio = new ServicioSocio(_unidadDeTrabajo.RepositorioSocio);
            ocultarBotonesDeConsulta();
            _registrarVenta = registrarVenta;
        }

        public ConsultaSocio(IUnidadDeTrabajo unidadDeTrabajo, ConsultaVenta consultaVenta)
        {
            InitializeComponent();
            dgvSocios.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dgvSocios.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioSocio = new ServicioSocio(_unidadDeTrabajo.RepositorioSocio);
            ocultarBotonesDeConsulta();
            _consultaVenta = consultaVenta;

        }

        public ConsultaSocio(IUnidadDeTrabajo unidadDeTrabajo, ConsultaAlquiler consultaAlquiler)
        {
            InitializeComponent();
            dgvSocios.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dgvSocios.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioSocio = new ServicioSocio(_unidadDeTrabajo.RepositorioSocio);
            ocultarBotonesDeConsulta();
            _consultaAlquiler = consultaAlquiler;

        }

        private void ocultarBotonesDeConsulta()
        {
            btnModificar.Visible = false;
            btnEliminar.Visible = false;
        }

        private void ConsultaSocio_Load(object sender, EventArgs e)
        {
            ConsultarSocios();
        }

        private void ConsultarSocios()
        {
            ckbIncluirDevueltos.Checked = false;
            var socios = _servicioSocio.ListarSociosActivos();
            CargarDgvSocios(socios);
            dgvSocios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarDgvSocios(List<Socio> socios)
        {
            dgvSocios.Rows.Clear();
            foreach(var socio in socios)
            {
                var descripcionEstado = (bool)socio.Estado ? "Activo" : "Inactivo";
                var fila = new string[]
                {
                    socio.IdSocio.ToString(),
                    socio.Nombre,
                    socio.Apellido,
                    socio.Telefono,
                    socio.Email,
                    socio.FechaAlta.ToString().Substring(0,10),
                    socio.FechaNacimiento.ToString().Substring(0,10),
                    descripcionEstado
                };
                dgvSocios.Rows.Add(fila);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            var nombreSocio = txtNombre.Text;
            if (nombreSocio.Length > 50)
                throw new ApplicationException("El nombre no debe tener más de 50 caracteres.");
            var apellidoSocio = txtApellido.Text;
            if (apellidoSocio.Length > 50)
                throw new ApplicationException("El apellido no debe tener más de 50 caracteres.");
            var sociosFiltrados = _servicioSocio.Encontrar(a => a.Nombre.Contains(nombreSocio) && a.Apellido.Contains(apellidoSocio)).ToList();
            CargarDgvSocios(sociosFiltrados);
        }

        private void btnReiniciarFiltros_Click(object sender, EventArgs e)
        {
            ConsultarSocios();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            new AltaSocio(_unidadDeTrabajo).ShowDialog();
            ConsultarSocios();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Validar la cantidad de filas seleccionadas
            if (dgvSocios.SelectedRows.Count == 1)
            {
                var id = Convert.ToInt32(dgvSocios.SelectedRows[0].Cells["Id"].Value);

                new ModificacionSocio(_unidadDeTrabajo, id).ShowDialog();
                ConsultarSocios();
                return;
            }
            else if (dgvSocios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un registro.", "Información", MessageBoxButtons.OK);
                return;
            }
            else if (dgvSocios.SelectedRows.Count > 1)
                MessageBox.Show("Debe seleccionar un solo registro, no muchos.", "Información", MessageBoxButtons.OK);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvSocios.SelectedRows.Count == 1)
            {
                var id = Convert.ToInt32(dgvSocios.SelectedRows[0].Cells["Id"].Value);

                new BajaSocio(_servicioSocio, id).ShowDialog();
                ConsultarSocios();
                return;
            }

            else if (dgvSocios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un registro.", "Información", MessageBoxButtons.OK);
                return;
            }
            else if (dgvSocios.SelectedRows.Count > 1)
                MessageBox.Show("Debe seleccionar un solo registro, no muchos.", "Información", MessageBoxButtons.OK);
        }



        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvSocios.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dgvSocios.SelectedRows[0].Cells["Id"].Value);
                var socio = _servicioSocio.GetPorId(id);
                if (_registrarAlquiler != null)
                    _registrarAlquiler.SetSocio(socio);
                else if (_consultaAlquiler != null)
                    _consultaAlquiler.SetSocioFiltro(socio);
                else if (_registrarVenta != null)
                    _registrarVenta.SetSocio(socio);
                else if (_consultaVenta != null)
                    _consultaVenta.SetSocioFiltro(socio);
                this.Dispose();
                return;
            }
            else if (dgvSocios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un registro.", "Información", MessageBoxButtons.OK);
            }
            else if (dgvSocios.SelectedRows.Count > 1)
                MessageBox.Show("Debe seleccionar un solo registro, no muchos.", "Información", MessageBoxButtons.OK);
			}

        private void ckbIncluirTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbIncluirDevueltos.Checked)
            {
                var socios = _servicioSocio.ListarSocios();
                CargarDgvSocios(socios);
            }
            else
                ConsultarSocios();
        }
    }
	}
