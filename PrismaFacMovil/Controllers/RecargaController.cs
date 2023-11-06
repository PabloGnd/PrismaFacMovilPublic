using Microsoft.AspNetCore.Mvc;
using PrismaFacMovil.Models;
using PrismaFacMovil.Servicios;

namespace PrismaFacMovil.Controllers
{
	public class RecargaController : Controller
	{
        private readonly IRecargaApi recargaApi;
        public RecargaController(IRecargaApi recargaApi)
        {
            this.recargaApi = recargaApi;
        }
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult NuevaRecarga()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> ConsultaRecarga()
		{

			int IdEmisor = (int)HttpContext.Session.GetInt32("varIdEmisor");
			Recarga dtoRecarga = new Recarga();
			dtoRecarga = await recargaApi.RecargaLista(IdEmisor);

			return new JsonResult(Ok(dtoRecarga));


		}

		[HttpPost]
		public async Task<IActionResult> GenerarRecarga(string intNumeroComprobante, string intValorRecarga)
		{
			Recarga dtoRecarga = new Recarga();
			RecargaResult dtoRecargaResult = new RecargaResult();
			dtoRecarga.NumeroComprobante = intNumeroComprobante;
			dtoRecarga.ValorRecarga = intValorRecarga;
			dtoRecarga.IdEmisor = HttpContext.Session.GetInt32("varIdEmisor");
            dtoRecargaResult = await recargaApi.Guardar(dtoRecarga);

			return new JsonResult(Ok());


		}
	}
}
