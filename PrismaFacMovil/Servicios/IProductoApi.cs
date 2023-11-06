using PrismaFacMovil.Models;

namespace PrismaFacMovil.Servicios
{
    public interface IProductoApi
    {
        Task<List<Producto>> Lista(int IdEmisor);
        Task<Producto> Obtener(int IdProducto);
        //Task<bool> Editar(Producto objeto);
        Task<ProductoResult> Guardar(Producto objeto);
        //Task<bool> Eliminar(int intIdProducto);
        Task<List<Producto>> ObtenerNemonicoDescripcion(string strNemonico, string strDescripcion);
    }
}
