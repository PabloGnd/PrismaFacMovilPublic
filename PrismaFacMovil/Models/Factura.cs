namespace PrismaFacMovil.Models
{
    public class Factura
    {
		public int IdFactura { get; set; }

		public int? IdCliente { get; set; }

		public int? IdEmisor { get; set; }

		public string? NumeroFactura { get; set; }

		public string? NumeroAutorizacion { get; set; }

		public DateTime? FechaAutorizacion { get; set; }

		public string? TotalDescuento { get; set; }

		public decimal? Subtotal { get; set; }

		public decimal? ValorIva { get; set; }
		public string Estado { get; set; }
		public decimal? Total { get; set; }
		public string? NombreCliente { get; set; }
		public string? ApellidoCliente { get; set; }
		public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; }
    }
}
