using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GameStore.Entidades;
using GameStore.InterfacesDeUsuario.PresentacionEmpleados;
using GameStore.RepositoriosBD;
using GameStore.Servicios;
using GameStore.Servicios.Implementaciones;

namespace GameStore.InterfacesDeUsuario.PresentacionUsuarios
{
    public partial class ModificacionUsuario : Form
    {
        private readonly IServicioEmpleado _servicioEmpleado;
        private readonly IServicioPerfil _servicioPerfil;
        private readonly IServicioCargo _servicioCargo;
        private readonly IServicioUsuario _servicioUsuario;
        private Usuario _usuarioAModificar;
        private IUnidadDeTrabajo _unidadDeTrabajo;

        public ModificacionUsuario(IUnidadDeTrabajo unidadDeTrabajo, int id)
        {
            InitializeComponent();
            dgvEmpleados.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dgvEmpleados.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            _servicioEmpleado = new ServicioEmpleado(unidadDeTrabajo.RepositorioEmpleado);
            _servicioPerfil = new ServicioPerfil(unidadDeTrabajo.RepositorioPerfil);
            _servicioCargo = new ServicioCargo(unidadDeTrabajo.RepositorioCargo);
            _servicioUsuario = new ServicioUsuario(unidadDeTrabajo.RepositorioUsuario);
            _unidadDeTrabajo = unidadDeTrabajo;
            _usuarioAModificar = _servicioUsuario.GetPorId(id);
        }

        private void ModificacionUsuario_Load(object sender, System.EventArgs e)
        {
            CargarNombreUsuario();
            CargarPerfiles(cboPerfiles);
            CargarNombreEmpleado();
            CargarContrasenia();
            CargarCargos(cboCargos);
            ConsultarEmpleados();
        }

        private void CargarContrasenia()
        {
            txtContrasenia.Text = txtRecontrasenia.Text = _usuarioAModificar.Contrasenia;
        }

        private void CargarNombreEmpleado()
        {
            txtEmpleado.Text = _usuarioAModificar.Empleado.Nombre + " " + _usuarioAModificar.Empleado.Apellido;
        }

        private void CargarNombreUsuario()
        {
            txtNombreUsuario.Text = _usuarioAModificar.NombreUsuario;
        }

        private void CargarPerfiles(ComboBox combo)
        {
            var perfiles = _servicioPerfil.ListarPerfiles();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = perfiles;
            combo.DataSource = bindingSource;
            combo.DisplayMember = "Nombre";
            combo.ValueMember = "IdPerfil";
            combo.SelectedItem = _usuarioAModificar.Perfil.Nombre;
        }

        private void CargarCargos(ComboBox combo)
        {
            var cargos = _servicioCargo.ListarCargos();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = cargos;
            combo.DataSource = bindingSource;
            combo.DisplayMember = "Nombre";
            combo.ValueMember = "IdCargo";
            combo.SelectedItem = _usuarioAModificar.Empleado.Cargo.Nombre;
        }

        private void ConsultarEmpleados()
        {
            var empleados = _servicioEmpleado.ListarEmpleados();
            CargarDgvEmpleados(empleados);
        }

        private void CargarDgvEmpleados(List<Empleado> empleados)
        {
            dgvEmpleados.Rows.Clear();

            foreach (var empleado in empleados)
            {
                var fila = new string[]
                {
                    empleado.IdEmpleado.ToString(),
                    empleado.NroDocumento.ToString(),
                    empleado.Nombre,
                    empleado.Apellido,
                    empleado.Email,
                    empleado.Cargo.Nombre,
                };
                dgvEmpleados.Rows.Add(fila);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resultado = MessageBox.Show("Confirmar operación", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (resultado == DialogResult.Cancel)
                    return;
                ValidarUsuario();
                ActualizarUsuario();
                this.Dispose();
            }
            catch (ApplicationException aex)
            {
                MessageBox.Show(aex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un problema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidarUsuario()
        {
            var password = txtContrasenia.Text;
            var repassword = txtRecontrasenia.Text;
            if (password != repassword)
                throw new ApplicationException("La contraseña no coincide");
            _usuarioAModificar.NombreUsuario = txtNombreUsuario.Text;
            _usuarioAModificar.Contrasenia = password;
            _usuarioAModificar.Perfil = (Perfil)cboPerfiles.SelectedItem;
            var idEmpleadoSeleccionado = Convert.ToInt32(dgvEmpleados.CurrentRow.Cells["IdEmpleado"].Value);
            _usuarioAModificar.Empleado = _servicioEmpleado.GetPorId(idEmpleadoSeleccionado);

            _servicioUsuario.ValidarUsuario(_usuarioAModificar);
        }

        private void ActualizarUsuario()
        {
            _servicioUsuario.Actualizar(_usuarioAModificar);
            MessageBox.Show("Se actualizó el usuario con éxito", "Información");
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
    }
}
