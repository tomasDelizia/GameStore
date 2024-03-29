﻿using GameStore.Entidades;
using GameStore.RepositoriosBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Servicios.Implementaciones
{
    public class ServicioDesarrollador : Servicio<Desarrollador>, IServicioDesarrollador
    {
        private IRepositorioDesarrollador _repositorioDesarrollador;

        public ServicioDesarrollador(IRepositorioDesarrollador repositorioDesarrollador) : base(repositorioDesarrollador)
        {
            _repositorioDesarrollador = repositorioDesarrollador;
        }

        public void ValidarDesarrollador(Desarrollador desarrollador)
        {
            desarrollador.ValidarNombre();
        }

        public List<Desarrollador> ListarDesarrolladores()
        {
            return _repositorioDesarrollador.GetTodos().ToList();
        }

        public Desarrollador GetPorId(int id)
        {
            return _repositorioDesarrollador.GetPorId(id);
        }
    }
}

