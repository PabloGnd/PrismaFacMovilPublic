namespace PrismaFacMovil.Models
{
    public class Establecimiento
    {
        public int IdEstablecimiento { get; set; }

        public int? IdEmisor { get; set; }

        public string? CodigoEstablecimiento { get; set; }

        public string? Descripcion { get; set; }

        public string? Direccion { get; set; }

        public virtual Emisor? IdEmisorNavigation { get; set; }

        //public virtual ICollection<Sucursal> Sucursals { get; } = new List<Sucursal>();
    }
}
