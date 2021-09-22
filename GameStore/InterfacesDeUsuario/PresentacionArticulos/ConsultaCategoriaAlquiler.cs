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
    public partial class ConsultaCategoriaAlquiler : Form
    {
        private IUnidadDeTrabajo _unidadDeTrabajo;
        private readonly Servicios.IServicioCategoriaAlquiler _servicioCategoria;
        public ConsultaCategoriaAlquiler(IUnidadDeTrabajo unidadDeTrabajo)
        {
            InitializeComponent();
            dgvCategorias.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dgvCategorias.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioCategoria = new ServicioCategoriaAlquiler(_unidadDeTrabajo.RepositorioCategoriaAlquiler);
        }

        private void ConsultaCategoriaArticulo_Load(object sender, EventArgs e)
        {
            ConsultarCategorias();
        }

        private void ConsultarCategorias()
        {
            var categorias = _servicioCategoria.ListarCategorias();
            CargarDgvCategorias(categorias);
            dgvCategorias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarDgvCategorias(List<CategoriaAlquiler> categorias)
        {
            dgvCategorias.Rows.Clear();
            foreach (CategoriaAlquiler categoria in categorias)
            {
                var fila = new string[]
                {
                    categoria.IdCategoriaAlquiler.ToString(),
                    categoria.Nombre,
                    categoria.Descripcion,
                    categoria.MontoAlquilerPorDia.ToString(),
                    categoria.MontoDevolucionTardiaPorDia.ToString(),
                };
                dgvCategorias.Rows.Add(fila);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            var nombreCategoria = txtNombre.Text;
            var categoriasFiltradas = _servicioCategoria.Encontrar(a => a.Nombre.Contains(nombreCategoria)).ToList();
            CargarDgvCategorias(categoriasFiltradas);
        }

        private void btnReiniciarFiltros_Click(object sender, EventArgs e)
        {
            ConsultarCategorias();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            new AltaCategoriaAlquiler(_unidadDeTrabajo).ShowDialog();
            ConsultarCategorias();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Validar la cantidad de filas seleccionadas
            if (dgvCategorias.SelectedRows.Count == 1)
            {
                var id = Convert.ToInt32(dgvCategorias.SelectedRows[0].Cells["Id"].Value);

                new ModificacionCategoriaAlquiler(_unidadDeTrabajo, id).ShowDialog();
                ConsultarCategorias();
                return;
            }
            else if (dgvCategorias.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un registro.", "Información", MessageBoxButtons.OK);
                return;
            }
            else if (dgvCategorias.SelectedRows.Count > 1)
                MessageBox.Show("Debe seleccionar un solo registro, no muchos.", "Información", MessageBoxButtons.OK);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.SelectedRows.Count == 1)
            {
                var id = Convert.ToInt32(dgvCategorias.SelectedRows[0].Cells["Id"].Value);

                new BajaCategoriaAlquiler(_servicioCategoria, id).ShowDialog();
                ConsultarCategorias();
                return;
            }

            else if (dgvCategorias.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un registro.", "Información", MessageBoxButtons.OK);
                return;
            }
            else if (dgvCategorias.SelectedRows.Count > 1)
                MessageBox.Show("Debe seleccionar un solo registro, no muchos.", "Información", MessageBoxButtons.OK);
        }
    }
}
