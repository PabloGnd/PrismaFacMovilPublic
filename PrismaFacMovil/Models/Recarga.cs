namespace PrismaFacMovil.Models
{
	public class Recarga
	{
        public int IdRecarga { get; set; }
        public int? IdEmisor { get; set; }
        public string ValorRecarga { get; set; }
        public string NumeroComprobante { get; set; }
        public DateTime? FechaRecarga { get; set; }
        public DateTime? FechaActualizacionRecarga { get; set; }
        public bool? Estado { get; set; }
        public bool? EsRegalo { get; set; }
        public int? NumeroFacturasConsumidas { get; set; }
        public int? NumeroFacturas { get; set; }
        public int? NumeroFacturasSaldo { get; set; }


        public virtual Emisor IdEmisorNavigation { get; set; }
	}
}
