using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameStore.Entidades;
using GameStore.RepositoriosBD;
using GameStore.Servicios;
using GameStore.Servicios.Implementaciones;

namespace GameStore.InterfacesDeUsuario.PresentacionUsuarios
{
    public partial class ConsultaUsuario : Form
    {
        private IUnidadDeTrabajo _unidadDeTrabajo;
        private readonly IServicioUsuario _servicioUsuario;
        private readonly IServicioPerfil _servicioPerfil;
        private readonly IServicioEmpleado _servicioEmpleado;

        public ConsultaUsuario(IUnidadDeTrabajo unidadDeTrabajo)
        {
            InitializeComponent();
            dgvUsuarios.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
            dgvUsuarios.DefaultCellStyle.Font = new Font("Century Gothic", 12);
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioUsuario = new ServicioUsuario(unidadDeTrabajo.RepositorioUsuario);
            _servicioPerfil = new ServicioPerfil(unidadDeTrabajo.RepositorioPerfil);
            _servicioEmpleado = new ServicioEmpleado(unidadDeTrabajo.RepositorioEmpleado);
        }

        private void ConsultaUsuario_Load(object sender, EventArgs e)
        {
            CargarPerfiles(cboPerfiles);
            ConsultarUsuarios();
        }

        private void CargarPerfiles(ComboBox combo)
        {
            var perfiles = _servicioPerfil.ListarPerfiles();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = perfiles;
            combo.DataSource = bindingSource;
            combo.DisplayMember = "Nombre";
            combo.ValueMember = "IdPerfil";
            combo.Text = "Selección";
        }

        private void ConsultarUsuarios()
        {
            var usuarios = _servicioUsuario.ListarUsuarios();
            CargarDgvUsuarios(usuarios);
        }

        private void CargarDgvUsuarios(List<Usuario> usuarios)
        {
            dgvUsuarios.Rows.Clear();

            foreach (var usuario in usuarios)
            {
                var descripcionEstado = (bool)usuario.Estado ? "Activo" : "Inactivo";
                var fila = new string[]
                {
                    usuario.IdUsuario.ToString(),
                    usuario.NombreUsuario,
                    usuario.FechaAlta.ToString().Substring(0,10),
                    usuario.Perfil.Nombre,
                    descripcionEstado,
                    usuario.Empleado.Nombre + " " + usuario.Empleado.Apellido,
                };
                dgvUsuarios.Rows.Add(fila);
            }
        }

        private void btnReiniciarFiltros_Click(object sender, EventArgs e)
        {
            ConsultarUsuarios();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            var nombreUsuario = txtNombreUsuario.Text;
            var incluirTodos = ckbIncluirTodos.Checked;
            if (nombreUsuario.Length > 50)
                throw new ApplicationException("El nombre no debe tener más de 50 caracteres.");
            var perfil = (Perfil)cboPerfiles.SelectedItem;

            if (incluirTodos == true)
            {
                var usuariosFiltrados = _servicioUsuario.Encontrar(u => u.NombreUsuario.Contains(nombreUsuario) && u.Perfil.Nombre == perfil.Nombre
                                        ).ToList();
                CargarDgvUsuarios(usuariosFiltrados);
            }
            else
            {
                var usuariosFiltrados = _servicioUsuario.Encontrar(u => u.NombreUsuario.Contains(nombreUsuario) && u.Perfil.Nombre == perfil.Nombre
                                        && (bool)u.Estado).ToList();
                CargarDgvUsuarios(usuariosFiltrados);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //new AltaUsuario(_servicioPerfil);
        }
    }
}
