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
    public partial class ConsultaGenero : Form
    {
        private IUnidadDeTrabajo _unidadDeTrabajo;
        private readonly IServicioGenero _servicioGenero;

        public ConsultaGenero(IUnidadDeTrabajo unidadDeTrabajo)
        {
            InitializeComponent();
            dgvGenero.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dgvGenero.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioGenero = new ServicioGenero(unidadDeTrabajo.RepositorioGenero);
        }

        private void ConsultaGenero_Load(object sender, EventArgs e)
        {
            ConsultarGenero();
        }

        private void ConsultarGenero()
        {
            var genero = _servicioGenero.ListarGeneros();
            CargarDgvGenero(genero);
            dgvGenero.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarDgvGenero(List<Genero> generos)
        {
            dgvGenero.Rows.Clear();

            foreach (var genero in generos)
            {
                var fila = new string[]
                {
                    genero.IdGenero.ToString(),
                    genero.Nombre,
                    genero.Descripcion,
                };
                dgvGenero.Rows.Add(fila);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            var nombreGenero = txtNombre.Text.Trim();
            if (nombreGenero.Length > 50)
                throw new ApplicationException("El nombre no debe tener más de 50 caracteres.");

            var GenerosFiltrados = _servicioGenero.Encontrar(a => a.Nombre.Contains(nombreGenero)).ToList();

            CargarDgvGenero(GenerosFiltrados);
        }

        private void btnReiniciarFiltros_Click(object sender, EventArgs e)
        {
            ConsultarGenero();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            new AltaGenero(_unidadDeTrabajo).ShowDialog();
            ConsultarGenero();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvGenero.SelectedRows.Count == 1)
            {
                var id = Convert.ToInt32(dgvGenero.SelectedRows[0].Cells["IdGenero"].Value);

                new ModificacionGenero(_unidadDeTrabajo, id).ShowDialog();
                ConsultarGenero();
                return;
            }
            else if (dgvGenero.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un registro.", "Información", MessageBoxButtons.OK);
                return;
            }
            else if (dgvGenero.SelectedRows.Count > 1)
                MessageBox.Show("Debe seleccionar un solo registro, no muchos.", "Información", MessageBoxButtons.OK);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvGenero.SelectedRows.Count == 1)
            {
                var id = Convert.ToInt32(dgvGenero.SelectedRows[0].Cells["IdGenero"].Value);

                new BajaGenero(_servicioGenero, id).ShowDialog();
                ConsultarGenero();
                return;
            }

            else if (dgvGenero.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un registro.", "Información", MessageBoxButtons.OK);
                return;
            }
            else if (dgvGenero.SelectedRows.Count > 1)
                MessageBox.Show("Debe seleccionar un solo registro, no muchos.", "Información", MessageBoxButtons.OK);

        }
    }
}
