using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameStore.InterfacesDeUsuario;
using GameStore.RepositoriosBD;
using GameStore.RepositoriosBD.Implementaciones;

namespace GameStore
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (IUnidadDeTrabajo unidadDeTrabajo = new UnidadDeTrabajo(new ContextoGameStore()))
            {
                //Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Inicio(unidadDeTrabajo));
                //Application.Run(new Login(unidadDeTrabajo));
                //Application.Run(new Form1(unidadDeTrabajo));

                // Guardar la unidad de trabajo para guardar cambios en la BD.
                // unidadDeTrabajo.Guardar();
            }

        }
    }
}
