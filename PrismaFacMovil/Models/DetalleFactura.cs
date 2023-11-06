namespace PrismaFacMovil.Models
{
    public class DetalleFactura
    {
        public int IdDetalleFactura { get; set; }
        public int? IdProducto { get; set; }
        public int? IdFactura { get; set; }
        public int? Cantidad { get; set; }
        public decimal? DetalleTotal { get; set; }
        public decimal? PrecioConIva { get; set; }
        public decimal? PrecioConDescuento { get; set; }
        public decimal? PrecioUnitario { get; set; }

        public virtual Factura IdFacturaNavigation { get; set; }
        public virtual Producto IdProductoNavigation { get; set; }
    }
}
