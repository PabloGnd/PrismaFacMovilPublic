using PrismaFacMovil.Models;
namespace PrismaFacMovil.Models
{
    public class ProductoResult
    {
        public Producto dtoProducto { get; set; }
        public List<Producto> lstProducto { get; set; }
        public string Codigo { set; get; }

        public string Mensaje { set; get; }
    }
}
