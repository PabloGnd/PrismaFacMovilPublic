
namespace PrismaFacMovil.Models
{
	public class FacturaViewcs
	{
		public List<Factura> lstFactura { get; set; }
		public List<Producto> lstProducto { get; set; }
        public List<ProductoFactura> lstProductoFactura { get; set; }
        public Cliente dtoCliente { get; set; }
	}
}
