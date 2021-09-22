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
    public partial class ConsultaPlataforma : Form
    {
        private IUnidadDeTrabajo _unidadDeTrabajo;
        private IServicioPlataforma _servicioPlataforma;
        public ConsultaPlataforma(IUnidadDeTrabajo unidadDeTrabajo)
        {
            InitializeComponent();
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioPlataforma = new ServicioPlataforma(_unidadDeTrabajo.RepositorioPlataforma);
        }

        private void ConsultaPlataforma_Load(object sender, EventArgs e)
        {
            ConsultarPlataformas();
        }

        private void ConsultarPlataformas()
        {
            var plataformas = _servicioPlataforma.ListarPlataformas();
            CargarDgvPlataformas(plataformas);
            dgvPlataformas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarDgvPlataformas(List<Plataforma> plataformas)
        {
            dgvPlataformas.Rows.Clear();
            foreach(var plataforma in plataformas)
            {
                var fila = new string[]
                {
                    plataforma.IdPlataforma.ToString(),
                    plataforma.Nombre,
                    plataforma.Descripcion,
                };
                dgvPlataformas.Rows.Add(fila);
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            new AltaPlataforma(_unidadDeTrabajo).ShowDialog();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Validar la cantidad de filas seleccionadas
            if (dgvPlataformas.SelectedRows.Count == 1)
            {
                var id = Convert.ToInt32(dgvPlataformas.SelectedRows[0].Cells["Id"].Value);

                new ModificacionPlataforma(_unidadDeTrabajo, id).ShowDialog();
                ConsultarPlataformas();
                return;
            }
            else if (dgvPlataformas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un registro.", "Información", MessageBoxButtons.OK);
                return;
            }
            else if (dgvPlataformas.SelectedRows.Count > 1)
                MessageBox.Show("Debe seleccionar un solo registro, no muchos.", "Información", MessageBoxButtons.OK);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPlataformas.SelectedRows.Count == 1)
            {
                var id = Convert.ToInt32(dgvPlataformas.SelectedRows[0].Cells["Id"].Value);

                new BajaPlataforma(_servicioPlataforma, id).ShowDialog();
                ConsultarPlataformas();
                return;
            }

            else if (dgvPlataformas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un registro.", "Información", MessageBoxButtons.OK);
                return;
            }
            else if (dgvPlataformas.SelectedRows.Count > 1)
                MessageBox.Show("Debe seleccionar un solo registro, no muchos.", "Información", MessageBoxButtons.OK);
        }
    }
}
