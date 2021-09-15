using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GameStore.Entidades;
using GameStore.RepositoriosBD;
using GameStore.RepositoriosBD.Implementaciones;
using GameStore.Servicios;
using GameStore.Servicios.Implementaciones;

namespace GameStore.InterfacesDeUsuario
{
    public partial class Form1 : Form
    {
        private readonly IServicioClasificacion _servicioClasificacion;
        private readonly IServicioUsuario _servicioUsuario;

        public Form1(IUnidadDeTrabajo unidadDeTrabajo)
        {
            InitializeComponent();
            _servicioClasificacion = new ServicioClasificacion(unidadDeTrabajo.RepositorioClasificacion);
            _servicioUsuario = new ServicioUsuario(unidadDeTrabajo.RepositorioUsuario);
        }

        private void btn_Click(object sender, EventArgs e)
        {
            List<Clasificacion> clasificaciones = _servicioClasificacion.ListarClasificaciones();
            List<Usuario> usuarios = _servicioUsuario.ListarUsuarios();
            StringBuilder cadena = new StringBuilder();
            foreach (var usuario in usuarios)
            {
                cadena.Append(usuario.NombreUsuario + "\n");
            }
            txtClasificaciones.Text = cadena.ToString();
        }
    }
}
