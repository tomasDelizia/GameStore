using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.Entidades;
using GameStore.RepositoriosBD;

namespace GameStore.Servicios.Implementaciones
{
    public class ServicioArchivo : Servicio<Archivo>, IServicioArchivo
    {
        private IRepositorioArchivo _repositorioArchivo;

        public ServicioArchivo(IRepositorioArchivo repositorioArchivo) : base(repositorioArchivo)
        {
            _repositorioArchivo = repositorioArchivo;
        }

        public void ValidarArchivo(Archivo archivo)
        {
            archivo.ValidarNombre();
        }
    }


}
