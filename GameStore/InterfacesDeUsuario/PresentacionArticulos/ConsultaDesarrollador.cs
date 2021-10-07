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

namespace GameStore.InterfacesDeUsuario.PresentacionArticulos
{
    public partial class ConsultaDesarrollador : Form
    {
        private IUnidadDeTrabajo _unidadDeTrabajo;
        private readonly IServicioDesarrollador _servicioDesarrollador;
        
        public ConsultaDesarrollador(IUnidadDeTrabajo unidadDeTrabajo)
        {
            InitializeComponent();
            dgvDesarrollador.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dgvDesarrollador.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioDesarrollador = new ServicioDesarrollador(unidadDeTrabajo.RepositorioDesarrollador);
        }

        private void ConsultaDesarrollador_Load(object sender, EventArgs e)
        {
            ConsultarDesarrollador();
        }

        private void ConsultarDesarrollador()
        {
            var desarrollador = _servicioDesarrollador.ListarDesarrolladores();
            CargarDgvDesarrollador(desarrollador);
            dgvDesarrollador.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarDgvDesarrollador(List<Desarrollador> desarrolladores)
        {
            dgvDesarrollador.Rows.Clear();

            foreach (var desarrollador in desarrolladores)
            {
                var fila = new string[]
                {
                    desarrollador.IdDesarrollador.ToString(),
                    desarrollador.Nombre,
                    desarrollador.Descripcion,
                };
                dgvDesarrollador.Rows.Add(fila);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            var nombreDesarrollador = txtNombre.Text.Trim();
            if (nombreDesarrollador.Length > 50)
                throw new ApplicationException("El nombre no debe tener más de 50 caracteres.");

            var DesarrolladoresFiltrados = _servicioDesarrollador.Encontrar(a => a.Nombre.Contains(nombreDesarrollador)).ToList();

            CargarDgvDesarrollador(DesarrolladoresFiltrados);
        }

        private void btnReiniciarFiltros_Click(object sender, EventArgs e)
        {
            ConsultarDesarrollador();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            new AltaDesarrollador(_unidadDeTrabajo).ShowDialog();
            ConsultarDesarrollador();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvDesarrollador.SelectedRows.Count == 1)
            {
                var id = Convert.ToInt32(dgvDesarrollador.SelectedRows[0].Cells["IdDesarrollador"].Value);

                new ModificacionDesarrollador(_unidadDeTrabajo, id).ShowDialog();
                ConsultarDesarrollador();
                return;
            }
            else if (dgvDesarrollador.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un registro.", "Información", MessageBoxButtons.OK);
                return;
            }
            else if (dgvDesarrollador.SelectedRows.Count > 1)
                MessageBox.Show("Debe seleccionar un solo registro, no muchos.", "Información", MessageBoxButtons.OK);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDesarrollador.SelectedRows.Count == 1)
            {
                var id = Convert.ToInt32(dgvDesarrollador.SelectedRows[0].Cells["IdDesarrollador"].Value);

                new BajaDesarrollador(_servicioDesarrollador, id).ShowDialog();
                ConsultarDesarrollador();
                return;
            }

            else if (dgvDesarrollador.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un registro.", "Información", MessageBoxButtons.OK);
                return;
            }
            else if (dgvDesarrollador.SelectedRows.Count > 1)
                MessageBox.Show("Debe seleccionar un solo registro, no muchos.", "Información", MessageBoxButtons.OK);

        }
    }
}
