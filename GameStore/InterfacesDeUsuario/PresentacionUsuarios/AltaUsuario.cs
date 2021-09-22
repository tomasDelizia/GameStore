using GameStore.Entidades;
using GameStore.InterfacesDeUsuario.PresentacionEmpleados;
using GameStore.RepositoriosBD;
using GameStore.Servicios;
using GameStore.Servicios.Implementaciones;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GameStore.InterfacesDeUsuario.PresentacionUsuarios
{
    public partial class AltaUsuario : Form
    {
        private readonly IServicioEmpleado _servicioEmpleado;
        private readonly IServicioPerfil _servicioPerfil;
        private readonly IServicioCargo _servicioCargo;
        private readonly IServicioUsuario _servicioUsuario;
        private Usuario _usuarioARegistrar;
        private IUnidadDeTrabajo _unidadDeTrabajo;

        public AltaUsuario(IUnidadDeTrabajo unidadDeTrabajo)
        {
            InitializeComponent();
            dgvEmpleados.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dgvEmpleados.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            _servicioEmpleado = new ServicioEmpleado(unidadDeTrabajo.RepositorioEmpleado);
            _servicioPerfil = new ServicioPerfil(unidadDeTrabajo.RepositorioPerfil);
            _servicioCargo = new ServicioCargo(unidadDeTrabajo.RepositorioCargo);
            _servicioUsuario = new ServicioUsuario(unidadDeTrabajo.RepositorioUsuario);
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        private void AltaUsuario_Load(object sender, System.EventArgs e)
        {
            CargarPerfiles(cboPerfiles);
            ConsultarEmpleados();
            CargarCargos(cboCargos);
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

        private void CargarCargos(ComboBox combo)
        {
            var cargos = _servicioCargo.ListarCargos();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = cargos;
            combo.DataSource = bindingSource;
            combo.DisplayMember = "Nombre";
            combo.ValueMember = "IdCargo";
            combo.Text = "Selección";
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!EsOperacionConfirmada())
                    return;
                if (!EsUsuarioValido())
                    return;
                RegistrarUsuario();
            }
            catch (ApplicationException aex)
            {
                MessageBox.Show(aex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                var mensaje = ex.Message;
                MessageBox.Show("Ha ocurrido un problema, intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool EsOperacionConfirmada()
        {
            var respuesta = MessageBox.Show("Desea confirmar la operación", "Confirmación", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
                return true;
            return false;
        }

        private bool EsUsuarioValido()
        {
            var contrasenia = txtContrasenia.Text;
            var recontrasenia = txtRecontrasenia.Text;
            if (contrasenia != recontrasenia)
            {
                MessageBox.Show("La constraseña no coincide.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            var nombre = TxtNombreUsuario.Text;
            var perfil = (Perfil)cboPerfiles.SelectedItem;

            var usuarioIngresado = new Usuario();
            usuarioIngresado.NombreUsuario = nombre;
            usuarioIngresado.Contrasenia = contrasenia;
            usuarioIngresado.Perfil = perfil;
            usuarioIngresado.FechaAlta = DateTime.Now;
            usuarioIngresado.Estado = true;
            var idEmpleadoSeleccionado = Convert.ToInt32(dgvEmpleados.CurrentRow.Cells["IdEmpleado"].Value);
            usuarioIngresado.Empleado = _servicioEmpleado.GetPorId(idEmpleadoSeleccionado);

            _servicioUsuario.ValidarUsuario(usuarioIngresado);
            _usuarioARegistrar = usuarioIngresado;
            return true;
        }

        private void RegistrarUsuario()
        {
            if (!_servicioUsuario.Insertar(_usuarioARegistrar))
            {
                MessageBox.Show("Ocurrió un problema al registrar el usuario", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            MessageBox.Show("El usuario se registró con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Dispose();
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
