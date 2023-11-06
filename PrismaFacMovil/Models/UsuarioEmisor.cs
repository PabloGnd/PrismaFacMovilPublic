namespace PrismaFacMovil.Models
{
    public class UsuarioEmisor
    {
        public int IdUsuario { get; set; }
        public int? IdEmisor { get; set; }

        public int? IdEstablecimiento { get; set; }
        public int? IdSucursal { get; set; }
        public string NombreUsuario { get; set; }
        public string ApellidoUsuario { get; set; }
        public string NikUsuario { get; set; }
        public string Contrasenia { get; set; }
        public string CodigoSucursal { get; set; }
        public bool? Estado { get; set; }
        public string Email { get; set; }
        public bool? AplicaIva { get; set; }
    }
}
