﻿using GameStore.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Servicios
{
    public interface IServicioBarrio : IServicio<Barrio>
    {
        List<Barrio> ListarBarrios();
    }
}
