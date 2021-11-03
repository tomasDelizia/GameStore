using GameStore.Entidades;
using GameStore.RepositoriosBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Servicios.Implementaciones
{
    public class ServicioProveedor : Servicio<Proveedor>, IServicioProveedor
    {
        private IRepositorioProveedor _repositorioProveedor;
        public ServicioProveedor(IRepositorioProveedor repositorioProveedor) : base(repositorioProveedor)
        {
            _repositorioProveedor = repositorioProveedor;
        }
        public void ValidarProveedor(Proveedor proveedor)
        {
            proveedor.ValidarRazonSocial();
            proveedor.ValidarCuit();
            proveedor.ValidarTelefono();
            proveedor.ValidarCalle();
            proveedor.ValidarNumeroCalle();
        }
        public List<Proveedor> ListarProveedores()
        {
            return _repositorioProveedor.GetTodos().ToList();
        }
        public Proveedor GetPorId(int cuit)
        {
            return _repositorioProveedor.GetPorId(cuit);
        }

        public void DarDeBaja(Proveedor proveedor)
        {
            proveedor.Estado = false;
            _repositorioProveedor.Actualizar(proveedor);
        }

        public List<Proveedor> ListarProveedoresActivos()
        {
            return _repositorioProveedor.Encontrar(u => (bool)u.Estado).ToList();
        }
    }
}
