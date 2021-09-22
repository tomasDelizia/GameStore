using GameStore.Entidades;
using GameStore.RepositoriosBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Servicios.Implementaciones
{
    public class ServicioFormaPago : Servicio<FormaPago>, IServicioFormaPago
    {
        private IRepositorioFormaPago _repositorioFormaPago;
        public ServicioFormaPago(IRepositorioFormaPago repositorioFormaPago) : base(repositorioFormaPago)
        {
            _repositorioFormaPago = repositorioFormaPago;
        }

        public void ValidarFormaPago(FormaPago formaPago)
        {
            formaPago.ValidarNombre();
        }
        public List<FormaPago> ListarFormaPago()
        {
            return _repositorioFormaPago.GetTodos().ToList();
        }

        public FormaPago GetPorId(int id)
        {
            return _repositorioFormaPago.GetPorId(id);
        }
    }
}
