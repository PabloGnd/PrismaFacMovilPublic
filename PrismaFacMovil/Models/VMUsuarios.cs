namespace PrismaFacMovil.Models
{
    public class VMUsuarios
    {
        public int IdUsuario { get; set; }
        public int? IdEmisor { get; set; }
        public int? IdSucursal { get; set; }
        public int? IdEstablecimiento { get; set; }
        public string NombreUsuario { get; set; }
        public string ApellidoUsuario { get; set; }
        public string NikUsuario { get; set; }
        public string Contrasenia { get; set; }
        public bool? Estado { get; set; }
        public string Codigo { set; get; }

        public string Mensaje { set; get; }

        public string CodigoSucursal { get; set; }
        public string CodigoEstablecimiento { get; set; }
        public bool? AplicaIva { get; set; }
        //public Emisor dtoEmisor { get; set; }

        //public List<VMPermisos> lstVMPermisos { get; set; }
    }
}
