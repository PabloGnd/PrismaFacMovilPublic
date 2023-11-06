using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PrismaFacMovil.Models;
using PrismaFacMovil.Servicios;

namespace PrismaFacMovil.Controllers
{
    public class FacturaController : Controller
    {
        private readonly IFacturaApi facturaApi;

        public FacturaController(IFacturaApi facturaApi)
        {
            this.facturaApi = facturaApi;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Producto()
        {
            return View();
        }
        public IActionResult FacturaAprobada()
        {
            return View();
        }
        public IActionResult FacturasEmitidas()
        {
            return View();
        }
        public IActionResult Resumen()
        {
            FacturaViewcs dtoFacturaView = new FacturaViewcs();
            List<Factura> lstFactura = new List<Factura>();
            Factura dtoFactura = new Factura();
            List<ProductoFactura> lstProducto = new List<ProductoFactura>();
            Cliente dtoCliente = new Cliente();
            dtoFactura = JsonConvert.DeserializeObject<Factura>(HttpContext.Session.GetString("dtoFactura"));
            lstFactura.Add(dtoFactura);
            lstProducto = JsonConvert.DeserializeObject<List<ProductoFactura>>(HttpContext.Session.GetString("lstProducto"));
            dtoCliente = JsonConvert.DeserializeObject<Cliente>(HttpContext.Session.GetString("dtoCliente"));
            dtoCliente.InicialNombre = dtoCliente.Nombre1.FirstOrDefault();
            dtoCliente.InicialApellido = dtoCliente.Apellido1.FirstOrDefault();
            dtoFacturaView.lstProductoFactura = lstProducto;
            dtoFacturaView.lstFactura = lstFactura;
            dtoFacturaView.dtoCliente = dtoCliente;
            return View(dtoFacturaView);
        }

        [HttpGet]
        public async Task<IActionResult> Lista(int intIdEmisor)
        {

            Cliente dtoCliente = new Cliente();
            intIdEmisor = Convert.ToInt32(HttpContext.Session.GetInt32("varIdEmisor"));


            List<Cliente> lstCliente = await facturaApi.Lista(intIdEmisor);


            return View("Index", lstCliente);

        }

        [HttpPost]
        public async Task<JsonResult> ObtenerIdentificacion(string strIdentificacion)
        {

            List<Cliente> lstCliente = new List<Cliente>();
            string strNombre = "0";
            string strApellido = "0";
            if (string.IsNullOrEmpty(strIdentificacion))
            {
                strIdentificacion = "0";
            }

            Cliente dtoCliente = new Cliente();
            dtoCliente = await facturaApi.ObtenerIdentificacion(strIdentificacion);

            return new JsonResult(Ok(dtoCliente));


        }

        [HttpPost]
        public async Task<IActionResult> Guardar(Cliente Cliente)
        {


            string strVMCliente = JsonConvert.SerializeObject(Cliente);
            HttpContext.Session.SetString("dtoCliente", strVMCliente);
            return new JsonResult(Ok());



        }
        [HttpGet]
        public async Task<IActionResult> ListaProducto(int intIdEmisor)
        {

            Producto dtoProducto = new Producto();
            intIdEmisor = Convert.ToInt32(HttpContext.Session.GetInt32("varIdEmisor"));
            List<Producto> lstProductoResult = new List<Producto>();

            List<Producto> lstProducto = await facturaApi.ListaProducto(intIdEmisor);

            foreach (Producto dtoProductoFor in lstProducto)
            {
                if (dtoProductoFor.Estado == false)
                {
                    lstProductoResult.Add(dtoProductoFor);
                }
            }
            Cliente dtoCliente = new Cliente();
            FacturaViewcs dtoFacturaView = new FacturaViewcs();
            
            dtoCliente = JsonConvert.DeserializeObject<Cliente>(HttpContext.Session.GetString("dtoCliente"));
            dtoFacturaView.lstProducto = lstProductoResult;
            dtoFacturaView.dtoCliente = dtoCliente;
            return View("Producto", dtoFacturaView);

        }
        [HttpPost]
        public async Task<JsonResult> ObtenerNemonicoDescripcion(string strDescripcion)
        {
            string strNemonico = "";
            List<Producto> lstProductoResult = new List<Producto>();
            if (string.IsNullOrEmpty(strNemonico))
            {
                strNemonico = "0";
            }
            if (string.IsNullOrEmpty(strDescripcion))
            {
                strDescripcion = "0";
            }

            Producto ModeloProducto = new Producto();
            List<Producto> lstProducto = await facturaApi.ObtenerNemonicoDescripcion(strNemonico, strDescripcion);
            //foreach(Producto dtoProducto in lstProducto)
            //{
            //    if (dtoProducto.Estado == false) { 
                    
            //    }

            //}
            return new JsonResult(Ok(lstProducto));


        }

        [HttpPost]
        public async Task<IActionResult> GuardarProducto(Factura Factura, List<DetalleFactura> DetalleFactura, List<ProductoFactura> lstProducto)
        {


            string strVMFactura = JsonConvert.SerializeObject(Factura);
            HttpContext.Session.SetString("dtoFactura", strVMFactura);


            string strListaProducto = JsonConvert.SerializeObject(lstProducto);
            HttpContext.Session.SetString("lstProducto", strListaProducto);

            List<DetalleFactura> lstDetalleFactura = new List<DetalleFactura>();
            string strListaDetalleFactura = JsonConvert.SerializeObject(DetalleFactura);
            HttpContext.Session.SetString("lstDetalleFactura", strListaDetalleFactura);
            lstDetalleFactura = JsonConvert.DeserializeObject<List<DetalleFactura>>(HttpContext.Session.GetString("lstDetalleFactura"));
            return new JsonResult(Ok());

        }
        /// <summary>
        /// Controlador para enviar datos para emisión de factura
        /// 2023/10/22 JG: Quito variables de aplica iva para manejarlo centralizado en el API.
        /// </summary>
        /// <returns>Respuesta Correcto: 1 Error 0</returns>
        public async Task<IActionResult> GenerarFactura()
        {
            GenerarFactura dtoGenerarFactura = new GenerarFactura();
            Establecimiento dtoEstablecimiento = new Establecimiento();
            Sucursal dtoSucursal = new Sucursal();
            Emisor dtoEmisor = new Emisor();
            List<DetalleFactura> lstDetalleFactura = new List<DetalleFactura>();
            Cliente dtoCliente = new Cliente();
            lstDetalleFactura = JsonConvert.DeserializeObject<List<DetalleFactura>>(HttpContext.Session.GetString("lstDetalleFactura"));
            dtoCliente = JsonConvert.DeserializeObject<Cliente>(HttpContext.Session.GetString("dtoCliente"));
            dtoCliente.IdEmisor = HttpContext.Session.GetInt32("varIdEmisor");
            dtoEmisor.IdEmisor = (int)HttpContext.Session.GetInt32("varIdEmisor");
            dtoEstablecimiento.IdEstablecimiento = (int)HttpContext.Session.GetInt32("varIdEstablecimiento");
            dtoSucursal.IdSucursal = (int)HttpContext.Session.GetInt32("varIdSucursal");
            dtoEstablecimiento.CodigoEstablecimiento = HttpContext.Session.GetString("varCodigoEstablecimiento");
            dtoSucursal.CodigoSucursal = HttpContext.Session.GetString("varCodigoSucursal");
            dtoGenerarFactura.dtoClientes = dtoCliente;
            dtoGenerarFactura.dtoEmisor = dtoEmisor;
            dtoGenerarFactura.dtoEstablecimiento = dtoEstablecimiento;
            dtoGenerarFactura.dtoSucursal = dtoSucursal;
            dtoGenerarFactura.lstDetalleFactura = lstDetalleFactura;
            GenerarFactura dtoGenerarFacturaRespuesta = new GenerarFactura();

            dtoGenerarFacturaRespuesta = await facturaApi.Guardar(dtoGenerarFactura);

            HttpContext.Session.SetString("MensajeFactura", dtoGenerarFacturaRespuesta.Mensaje);
            HttpContext.Session.SetInt32("CodigoFactura", dtoGenerarFacturaRespuesta.Codigo);
            return View("FacturaAprobada", dtoGenerarFactura);



        }
        [HttpGet]
		public async Task<ActionResult> ConsultaFactura()
		{

			List<Factura> lstFactura = await facturaApi.Lista();
			HttpContext.Session.SetString("CodigoFactura", String.Empty);
			HttpContext.Session.SetString("MensajeErrorLogin", string.Empty);


			return View("FacturasEmitidas", lstFactura);

		}
        [HttpPost]
		public async Task<IActionResult> ConsultaProducto(int IdFactura)
		{

			Producto ModeloProducto = new Producto();

            List<Producto> lstProducto = await facturaApi.ConsultaProducto(IdFactura);


            if (lstProducto.Count == 0)
            {
                return new JsonResult(Ok(ModeloProducto));
            }
            return new JsonResult(Ok(lstProducto));
           

		}
   
		public async Task<IActionResult> ObtenerFacturas(IFormCollection frmColeccion)
		{
			string strFechaInicio = frmColeccion["ConsultaDesde"];
			string strFechaFin = frmColeccion["ConsultaHasta"];


			List<Factura> lstFactura = await facturaApi.ConsultaFecha(strFechaInicio, strFechaFin);
			return View("FacturasEmitidas", lstFactura);

		}
	}
}
