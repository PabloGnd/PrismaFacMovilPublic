namespace PrismaFacMovil.Models
{
    public class ProductoFactura
    {
        public int IdProducto { get; set; }
        public int? IdEmisor { get; set; }
        public string Nemonico { get; set; }
        public string Descripcion { get; set; }
        public decimal? PorcentajeDescuento { get; set; }
        public bool? Estado { get; set; }
        public int? Stok { get; set; }
        public decimal? PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
    }
}
