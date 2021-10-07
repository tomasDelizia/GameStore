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
    public partial class ConsultaClasificacion : Form
    {
        private IServicioClasificacion _servicioClasificacion;
        private IUnidadDeTrabajo _unidadDeTrabajo;

        public ConsultaClasificacion(IUnidadDeTrabajo unidadDeTrabajo)
        {
            InitializeComponent();
            dgvClasificacion.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dgvClasificacion.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioClasificacion = new ServicioClasificacion(unidadDeTrabajo.RepositorioClasificacion);

        }

        private void ConsultaClasificacion_Load(object sender, EventArgs e)
        {
            ConsultarClasificaciones();
        }

        private void ConsultarClasificaciones()
        {
            var clasificaciones = _servicioClasificacion.ListarClasificaciones();
            CargarDgvClasificacion(clasificaciones);
            dgvClasificacion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarDgvClasificacion(List<Clasificacion> clasificaciones)
        {
            dgvClasificacion.Rows.Clear();
            foreach (var clasificacion in clasificaciones)
            {
                var fila = new string[]
                {
                    clasificacion.IdClasificacion.ToString(),
                    clasificacion.Nombre,                 
                    clasificacion.Descripcion,
                };
                dgvClasificacion.Rows.Add(fila);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            new AltaClasificacion(_unidadDeTrabajo).ShowDialog();
            ConsultarClasificaciones();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Validar la cantidad de filas seleccionadas
            if (dgvClasificacion.SelectedRows.Count == 1)
            {
                var cuit = Convert.ToInt32(dgvClasificacion.SelectedRows[0].Cells["Id"].Value);

                new ModificacionClasificacion(_unidadDeTrabajo, cuit).ShowDialog();
                ConsultarClasificaciones();
                return;
            }
            else if (dgvClasificacion.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un registro.", "Información", MessageBoxButtons.OK);
                return;
            }
            else if (dgvClasificacion.SelectedRows.Count > 1)
                MessageBox.Show("Debe seleccionar un solo registro, no muchos.", "Información", MessageBoxButtons.OK);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvClasificacion.SelectedRows.Count == 1)
            {
                var id = Convert.ToInt32(dgvClasificacion.SelectedRows[0].Cells["Id"].Value);

                new BajaClasificacion(_servicioClasificacion, id).ShowDialog();
                ConsultarClasificaciones();
                return;
            }

            else if (dgvClasificacion.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un registro.", "Información", MessageBoxButtons.OK);
                return;
            }
            else if (dgvClasificacion.SelectedRows.Count > 1)
                MessageBox.Show("Debe seleccionar un solo registro, no muchos.", "Información", MessageBoxButtons.OK);

        }

        private void btnFiltrar_Click_1(object sender, EventArgs e)
        {
            var nombre = txtNombre.Text.Trim();
            if (nombre.Length > 50)
                throw new ApplicationException("EL nombre no debe tener más de 50 caracteres.");

            var clasificacionesFiltradas = _servicioClasificacion.Encontrar(a => a.Nombre.Contains(nombre)).ToList();

            CargarDgvClasificacion(clasificacionesFiltradas);
        }

        private void btnReiniciarFiltros_Click_1(object sender, EventArgs e)
        {
            ConsultarClasificaciones();
        }
    }
}
