using Microsoft.AspNetCore.Mvc;
using PrismaFacMovil.Servicios;
using PrismaFacMovil.Models;
using PrismaFacMovil.Servicios;

namespace PrismaFacMovil.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IProductoApi productoApi;
        public ProductoController(IProductoApi productoApi)
        { 
            this.productoApi = productoApi;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Nuevo()
        {
            return View();
        }
        public IActionResult Editar()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Lista(int IdEmisor)
        {
            Producto dtoProducto = new Producto();
            IdEmisor = Convert.ToInt32(HttpContext.Session.GetInt32("varIdEmisor"));
            List<Producto> lstProducto = await productoApi.Lista(IdEmisor);


            return View("Index", lstProducto);

        }
        [HttpGet]
        public async Task<IActionResult> ObtenerProducto(int IdProducto)
        {
            Producto dtoProducto = new Producto();
            List<Producto> lstProducto = new List<Producto>();
            dtoProducto = await productoApi.Obtener(IdProducto);
            lstProducto.Add(dtoProducto);
            return View("Editar", lstProducto);
        }
        [HttpPost]
        public async Task<IActionResult> GuardarCambios(IFormCollection frmProducto)
        {
            Producto dtoProducto = new Producto();
            ProductoResult dtoProductoResult = new ProductoResult();
            if (!string.IsNullOrEmpty(frmProducto["IdProducto"].ToString()))
            {
                dtoProducto.IdProducto = Convert.ToInt32(frmProducto["IdProducto"].ToString());
            }

            dtoProducto.Descripcion = frmProducto["Descripcion"].ToString();
            dtoProducto.Stok = Convert.ToInt32(frmProducto["Cantidad"].ToString());
            dtoProducto.PrecioUnitario = Convert.ToDecimal(frmProducto["Precio"].ToString());
            dtoProducto.PorcentajeDescuento = Convert.ToDecimal(frmProducto["Descuento"].ToString());
            dtoProducto.IdEmisor = HttpContext.Session.GetInt32("varIdEmisor");

            dtoProductoResult = await productoApi.Guardar(dtoProducto);
            if (dtoProductoResult.Codigo == "1")
            {
                HttpContext.Session.SetString("CodigoExistenteProducto", dtoProductoResult.Codigo);
                HttpContext.Session.SetString("MensajeExistenteProducto", dtoProductoResult.Mensaje);
                return RedirectToAction("Lista", "Producto");
            }
            else if (dtoProductoResult.Codigo == "0")
            {
                HttpContext.Session.SetInt32("CodigoExistenteProducto", 2);
                HttpContext.Session.SetString("MensajeExistenteProducto", dtoProductoResult.Mensaje);
                return RedirectToAction("Lista", "Producto");
            }
            else
            {
                return RedirectToAction("Lista", "Producto");
            }


        }

        public async Task<IActionResult> ObtenerNemonicoDescripcion(IFormCollection frmColeccion)
        {
            string strNemonico = frmColeccion["Nemonico"];
            string strDescripcion = frmColeccion["Descripcion"];
            if (string.IsNullOrEmpty(strNemonico))
            {
                strNemonico = "0";
            }
            if (string.IsNullOrEmpty(strDescripcion))
            {
                strDescripcion = "0";
            }

            Producto ModeloProducto = new Producto();
            List<Producto> lstProducto = await productoApi.ObtenerNemonicoDescripcion(strNemonico, strDescripcion);

            return View("Index", lstProducto);


        }
    }
}
