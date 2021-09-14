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

        public Form1(IUnidadDeTrabajo unidadDeTrabajo)
        {
            InitializeComponent();
            _servicioClasificacion = new ServicioClasificacion(unidadDeTrabajo.RepositorioClasificacion);
        }

        private void btn_Click(object sender, EventArgs e)
        {
            List<Clasificacion> clasificaciones = _servicioClasificacion.ListarClasificaciones();
            StringBuilder cadena = new StringBuilder();
            foreach (var clasificacion in clasificaciones)
            {
                cadena.Append(clasificacion.Nombre + "\n");
            }
            txtClasificaciones.Text = cadena.ToString();
        }
    }
}
