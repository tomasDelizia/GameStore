using GameStore.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Servicios
{
    public interface IServicioTarifaAlquiler : IServicio<TarifaAlquiler>
    {
        List<TarifaAlquiler> ListarTarifasDeAlquiler();
        void ValidarCategoria(TarifaAlquiler tarifa);

        TarifaAlquiler GetPorNombre(string nombre);
    }
}
