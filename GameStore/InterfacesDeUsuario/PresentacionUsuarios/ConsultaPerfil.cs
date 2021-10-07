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

namespace GameStore.InterfacesDeUsuario.PresentacionUsuarios
{
    public partial class ConsultaPerfil : Form
    {
        private IUnidadDeTrabajo _unidadDeTrabajo;
        private readonly IServicioPerfil _servicioPerfil;
        public ConsultaPerfil(IUnidadDeTrabajo unidadDeTrabajo)
        {
            InitializeComponent();
            dgvPerfiles.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dgvPerfiles.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioPerfil = new ServicioPerfil(_unidadDeTrabajo.RepositorioPerfil);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            new AltaPerfil(_unidadDeTrabajo).ShowDialog();
            ConsultarPerfiles();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Validar la cantidad de filas seleccionadas
            if (dgvPerfiles.SelectedRows.Count == 1)
            {
                var id = Convert.ToInt32(dgvPerfiles.SelectedRows[0].Cells["Id"].Value);

                new ModificacionPerfil(_unidadDeTrabajo, id).ShowDialog();
                ConsultarPerfiles();
                return;
            }
            else if (dgvPerfiles.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un registro.", "Información", MessageBoxButtons.OK);
                return;
            }
            else if (dgvPerfiles.SelectedRows.Count > 1)
                MessageBox.Show("Debe seleccionar un solo registro, no muchos.", "Información", MessageBoxButtons.OK);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPerfiles.SelectedRows.Count == 1)
            {
                var id = Convert.ToInt32(dgvPerfiles.SelectedRows[0].Cells["Id"].Value);

                new BajaPerfil(_servicioPerfil, id).ShowDialog();
                ConsultarPerfiles();
                return;
            }

            else if (dgvPerfiles.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un registro.", "Información", MessageBoxButtons.OK);
                return;
            }
            else if (dgvPerfiles.SelectedRows.Count > 1)
                MessageBox.Show("Debe seleccionar un solo registro, no muchos.", "Información", MessageBoxButtons.OK);
        }

        private void ConsultarPerfiles()
        {
            var perfiles = _servicioPerfil.ListarPerfiles();
            CargarDgvPerfiles(perfiles);
            dgvPerfiles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarDgvPerfiles(List<Perfil> perfiles)
        {
            dgvPerfiles.Rows.Clear();
            foreach(var perfil in perfiles)
            {
                var fila = new string[]
                {
                    perfil.IdPerfil.ToString(),
                    perfil.Nombre,
                    perfil.Descripcion,
                };
                dgvPerfiles.Rows.Add(fila);
            }
        }

        private void ConsultaPerfil_Load(object sender, EventArgs e)
        {
            ConsultarPerfiles();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            var nombrePerfil = txtNombre.Text;
            var perfilesFiltrados = _servicioPerfil.Encontrar(a => a.Nombre.Contains(nombrePerfil)).ToList();
            CargarDgvPerfiles(perfilesFiltrados);
        }

        private void btnReiniciarFiltros_Click(object sender, EventArgs e)
        {
            ConsultarPerfiles();
        }
    }
}
