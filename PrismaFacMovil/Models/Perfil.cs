namespace PrismaFacMovil.Models
{
    public class Perfil
    {
        public int IdEmisor { get; set; }
        public string Ruc { get; set; }
        public string RazonSocial { get; set; }
        public string NombreComercial { get; set; }
        public string ContribuyenteEspecial { get; set; }
        public string ObligadoContabilidad { get; set; }
        public string DireccionMatriz { get; set; }
        public string Email { get; set; }
        public byte[] Archivo { get; set; }
        public string Ambiente { get; set; }
        public string ContraceñaCertificado { get; set; }
        public int? SecuencialFactura { get; set; }

        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string ApellidoUsuario { get; set; }
        public string NikUsuario { get; set; }
        public string Contrasenia { get; set; }
        public int? IdSucursal { get; set; }
        public bool? Estado { get; set; }
        public IFormFile ArchivoFile { set; get; }
        public bool? AplicaIva { get; set; }
    }
}
