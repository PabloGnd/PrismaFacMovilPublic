using Microsoft.AspNetCore.Mvc;
using PrismaFacMovil.Servicios;
using PrismaFacMovil.Models;
using Newtonsoft.Json;

namespace PrismaFacMovil.Controllers
{
	public class ClienteController : Controller
	{
		private readonly IClienteApi clienteApi;

		public ClienteController(IClienteApi clienteApi)
		{
			this.clienteApi = clienteApi;
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
		public async Task<IActionResult> Lista(int intIdEmisor)
		{
			
			Cliente dtoCliente = new Cliente();
			//intIdEmisor = Convert.ToInt32(HttpContext.Session.GetInt32("varIdEmisor"));
			intIdEmisor = 37;

			List<Cliente> lstCliente = await clienteApi.Lista(intIdEmisor);


			return View("Index", lstCliente);

		}

		[HttpGet]
		public async Task<IActionResult> ObtenerCliente(int IdCliente)
		{
			Cliente dtoCliente = new Cliente();
			List<Cliente> lstCliente = new List<Cliente>();


			dtoCliente = await clienteApi.Obtener(IdCliente);

			lstCliente.Add(dtoCliente);


			return View("Editar", lstCliente);
		}

		[HttpPost]
		public async Task<IActionResult> GuardarCambios(IFormCollection frmCliente)
		{
			Cliente dtoCliente = new Cliente();
			ClienteResult dtoClienteResult = new ClienteResult();
			if (!string.IsNullOrEmpty(frmCliente["IdCliente"].ToString()))
			{
				dtoCliente.IdCliente = Convert.ToInt32(frmCliente["IdCliente"].ToString());
			}

			dtoCliente.Identificacion = frmCliente["Identificacion"].ToString();
			dtoCliente.Apellido1 = frmCliente["Apellidos"].ToString();
			dtoCliente.Nombre1 = frmCliente["Nombres"].ToString();
			dtoCliente.TipoIdentificacion = frmCliente["TipoIdentificacion"].ToString();
			dtoCliente.DireccionCliente = frmCliente["Direccion"].ToString();
			dtoCliente.Correo = frmCliente["Correo"].ToString();
			dtoCliente.Telefono = frmCliente["Telefono"].ToString();
			dtoCliente.IdEmisor = HttpContext.Session.GetInt32("varIdEmisor");
			
			dtoClienteResult = await clienteApi.Guardar(dtoCliente);
			if (dtoClienteResult.Codigo == "1")
			{
				HttpContext.Session.SetString("CodigoExistente", dtoClienteResult.Codigo);
				HttpContext.Session.SetString("MensajeExistente", dtoClienteResult.Mensaje);
				return RedirectToAction("Lista", "Cliente");
			}
			else if (dtoClienteResult.Codigo == "0")
			{
				HttpContext.Session.SetInt32("CodigoExistente", 2);
				HttpContext.Session.SetString("MensajeExistente", dtoClienteResult.Mensaje);
				return RedirectToAction("Lista", "Cliente");
			}
			else {
				return RedirectToAction("Lista", "Cliente");
			}
			
			
		}
		[HttpPost]
        public async Task<IActionResult> ObtenerIdentificacionApellidoNombre(string strIdentificacion, string strApellido, string strNombre)
        {

			List<Cliente> lstCliente = new List<Cliente>();
			if (strIdentificacion != null) {
				strApellido = "0";
				strNombre = "0";
			} else if (strApellido != null) {
				strIdentificacion = "0";
				strNombre = "0";
			} else if (strNombre != null) {
				strApellido = "0";
				strIdentificacion = "0";
			}

            
            lstCliente = await clienteApi.ObtenerIdentificacionApellidoNombre(strIdentificacion, strApellido, strNombre);

            return new JsonResult(Ok(lstCliente));
           

        }

    }
}
