namespace PrismaFacMovil.Models
{
    public class Sucursal
    {
        public int IdSucursal { get; set; }

        public int? IdEstablecimiento { get; set; }

        public string? CodigoSucursal { get; set; }

        public virtual Establecimiento? IdEstablecimientoNavigation { get; set; }
    }
}
