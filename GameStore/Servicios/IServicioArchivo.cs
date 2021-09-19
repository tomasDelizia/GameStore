﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.Entidades;

namespace GameStore.Servicios
{
    public interface IServicioArchivo : IServicio<Archivo>
    {
        void ValidarArchivo(Archivo archivo);
    }
}
