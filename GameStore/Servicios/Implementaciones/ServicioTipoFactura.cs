using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.Entidades;
using GameStore.RepositoriosBD;

namespace GameStore.Servicios.Implementaciones
{
    public class ServicioTipoFactura : Servicio<TipoFactura>, IServicioTipoFactura
    {
        private IRepositorioTipoFactura _repositorioTipoFactura;

        public ServicioTipoFactura(IRepositorioTipoFactura repositorioTipoFactura) : base(repositorioTipoFactura)
        {
            _repositorioTipoFactura = repositorioTipoFactura;
        }

        public List<TipoFactura> ListarTiposDeFactura()
        {
            return _repositorioTipoFactura.GetTodos().ToList();
        }
    }
}
