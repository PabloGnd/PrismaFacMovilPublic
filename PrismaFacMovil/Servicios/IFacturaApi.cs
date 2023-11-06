using PrismaFacMovil.Models;

namespace PrismaFacMovil.Servicios
{
    public interface IFacturaApi
    {
        Task<Cliente> ObtenerIdentificacion(string strIdentificacion);
        Task<List<Cliente>> Lista(int intIdEmisor);
        Task<List<Producto>> ListaProducto(int intIdEmisor);
        Task<List<Producto>> ObtenerNemonicoDescripcion(string strNemonico, string strDescripcion);
        Task<GenerarFactura> Guardar(GenerarFactura objeto);
        Task<List<Factura>> Lista();

		Task<List<Producto>> ConsultaProducto(int IdFactura);

        //Task<GenerarFactura> EnviarFactura(GenerarFactura objeto);


        Task<List<Factura>> ConsultaFecha(string strFechaInicio, string strFechaFin);

    }
}
