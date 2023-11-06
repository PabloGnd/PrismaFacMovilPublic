namespace PrismaFacMovil.Models
{
    public class Registro
    {
        public Emisor Emisor { get; set; }
        public Establecimiento Establecimiento { get; set; }
        public Sucursal Sucursal { get; set; }
        public Emisor dtoEmisor { get; set; }
        public Sucursal dtoSucursal { get; set; }
        public Usuario Usuario { get; set; }
        public Usuario dtoUsuario { get; set; }
        public string Codigo { get; set; }
        public string Mensaje { get; set; }
        public string varIdSucursal { get; set; }
    }
}
