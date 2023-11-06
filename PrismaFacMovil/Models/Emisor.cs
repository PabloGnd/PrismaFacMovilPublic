namespace PrismaFacMovil.Models
{
	public class Emisor
	{
		public int IdEmisor { get; set; }

		public string? Ruc { get; set; }

		public string? RazonSocial { get; set; }

		public string? NombreComercial { get; set; }

		public string? ContribuyenteEspecial { get; set; }

		public string? ObligadoContabilidad { get; set; }

		public string? DireccionMatriz { get; set; }

		public string? Email { get; set; }

		public byte[]? Archivo { get; set; }

		public string Ambiente { get; set; }
		public string ContraceñaCertificado { get; set; }
		public int? SecuencialFactura { get; set; }
		public IFormFile ArchivoFile { set; get; }
        public bool? AplicaIva { get; set; }
        public string Telefono { get; set; }

        //public virtual ICollection<Cliente> Clientes { get; } = new List<Cliente>();

        //public virtual ICollection<Establecimiento> Establecimientos { get; } = new List<Establecimiento>();

        ////public virtual ICollection<Factura> Facturas { get; } = new List<Factura>();

        //public virtual ICollection<Producto> Productos { get; } = new List<Producto>();

        //public virtual ICollection<TipoComprobante> TipoComprobantes { get; } = new List<TipoComprobante>();
    }
}
