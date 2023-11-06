namespace PrismaFacMovil.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string ApellidoUsuario { get; set; }
        public string NikUsuario { get; set; }
        public string Contrasenia { get; set; }
        public int? IdEmisor { get; set; }
        public int? IdSucursal { get; set; }
        public bool? Estado { get; set; }
    }
}
