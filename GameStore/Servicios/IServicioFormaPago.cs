using GameStore.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Servicios
{
    public interface IServicioFormaPago : IServicio<FormaPago>
    {
        void ValidarFormaPago(FormaPago formaPago);
        FormaPago GetPorId(int id);

        List<FormaPago> ListarFormaPago();
    }
}
