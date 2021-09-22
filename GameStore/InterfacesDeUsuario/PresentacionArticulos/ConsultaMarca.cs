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
    public partial class ConsultaMarca : Form
    {
        private IUnidadDeTrabajo _unidadDeTrabajo;
        private readonly IServicioMarca _servicioMarca;
        public ConsultaMarca(IUnidadDeTrabajo unidadDeTrabajo)
        {
            InitializeComponent();
            dgvMarca.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dgvMarca.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioMarca = new ServicioMarca(unidadDeTrabajo.RepositorioMarca);
        }

        private void ConsultaMarca_Load(object sender, EventArgs e)
        {
            ConsultarMarca();
        }

        private void ConsultarMarca()
        {
            var marca = _servicioMarca.ListarMarcas();
            CargarDgvMarcas(marca);
            dgvMarca.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarDgvMarcas(List<Marca> marcas)
        {
            dgvMarca.Rows.Clear();

            foreach (var marca in marcas)
            {
                var fila = new string[]
                {
                    marca.IdMarca.ToString(),
                    marca.Nombre,
                    marca.Descripcion,
                };
                dgvMarca.Rows.Add(fila);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            var nombreMarca = txtNombre.Text.Trim();
            if (nombreMarca.Length > 50)
                throw new ApplicationException("El nombre no debe tener más de 50 caracteres.");

            var MarcasFiltradas = _servicioMarca.Encontrar(a => a.Nombre.Contains(nombreMarca)).ToList();

            CargarDgvMarcas(MarcasFiltradas);
        }

        private void btnReiniciarFiltros_Click(object sender, EventArgs e)
        {
            ConsultarMarca();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            new AltaMarca(_unidadDeTrabajo).ShowDialog();
            ConsultarMarca();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvMarca.SelectedRows.Count == 1)
            {
                var id = Convert.ToInt32(dgvMarca.SelectedRows[0].Cells["IdMarca"].Value);

                new ModificacionMarca(_unidadDeTrabajo, id).ShowDialog();
                ConsultarMarca();
                return;
            }
            else if (dgvMarca.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un registro.", "Información", MessageBoxButtons.OK);
                return;
            }
            else if (dgvMarca.SelectedRows.Count > 1)
                MessageBox.Show("Debe seleccionar un solo registro, no muchos.", "Información", MessageBoxButtons.OK);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMarca.SelectedRows.Count == 1)
            {
                var id = Convert.ToInt32(dgvMarca.SelectedRows[0].Cells["IdMarca"].Value);

                new BajaMarca(_servicioMarca, id).ShowDialog();
                ConsultarMarca();
                return;
            }

            else if (dgvMarca.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un registro.", "Información", MessageBoxButtons.OK);
                return;
            }
            else if (dgvMarca.SelectedRows.Count > 1)
                MessageBox.Show("Debe seleccionar un solo registro, no muchos.", "Información", MessageBoxButtons.OK);

        }
    }
}
