using Microsoft.AspNetCore.Mvc;
using PrismaFacMovil.Servicios;
using PrismaFacMovil.Models;
using Newtonsoft.Json;

namespace PrismaFacMovil.Controllers
{
	public class PerfilController : Controller
	{
		private readonly IPerfilApi perfilApi;
		public PerfilController(IPerfilApi perfilApi) 
        { 
			this.perfilApi = perfilApi;
		}
		
		public IActionResult Index()
		{
            
            return View();
		}
        [HttpGet]
        public async Task<IActionResult> ObtenerPerfil(int intIdEmisor)
        {
            Perfil dtoPerfil = new Perfil();
            intIdEmisor = Convert.ToInt32(HttpContext.Session.GetInt32("varIdEmisor"));
            dtoPerfil = await perfilApi.ObtenerPerfil(intIdEmisor);
            return View("Index", dtoPerfil);
        }
        [HttpPost]
        public async Task<IActionResult> EditarEmisor(IFormCollection frmEmisor, Perfil dtoPerfil) 
        {
            Emisor dtoEmisor = new Emisor();
            EmisorResult dtoEmisorResult = new EmisorResult();
            dtoEmisor.IdEmisor = Convert.ToInt32(HttpContext.Session.GetInt32("varIdEmisor"));
            dtoEmisor.RazonSocial = frmEmisor["RazonSocial"].ToString();
            dtoEmisor.DireccionMatriz = frmEmisor["DireccionNegocio"].ToString();
            if (dtoPerfil.ArchivoFile != null) {
                using (var ms = new System.IO.MemoryStream())
                {
                    await dtoPerfil.ArchivoFile.CopyToAsync(ms);
                    dtoEmisor.Archivo = ms.ToArray();
                }
            }

            dtoEmisorResult = await perfilApi.EditarEmisor(dtoEmisor);
            return RedirectToAction("ObtenerPerfil", "Perfil");
        }
        [HttpPost]
        public async Task<IActionResult> EditarUsuarioEmisor(IFormCollection frmUsuarioEmisor)
        {
            UsuarioEmisor dtoUsuarioEmisor = new UsuarioEmisor();
            EmisorResult dtoEmisorResult = new EmisorResult();
            dtoUsuarioEmisor.IdEmisor = Convert.ToInt32(HttpContext.Session.GetInt32("varIdEmisor"));
            dtoUsuarioEmisor.IdUsuario = Convert.ToInt32(HttpContext.Session.GetInt32("varIdUsuario"));

            dtoUsuarioEmisor.Email = frmUsuarioEmisor["Correo"].ToString();
            dtoUsuarioEmisor.Contrasenia = frmUsuarioEmisor["Contrasena"].ToString();
            

            dtoEmisorResult = await perfilApi.EditarUsuarioEmisor(dtoUsuarioEmisor);
            return RedirectToAction("ObtenerPerfil", "Perfil");
        }
        [HttpPost]
        public async Task<IActionResult> EditarIva(bool AplicaIva)
        {
            Emisor dtoEmisor = new Emisor();
            EmisorResult dtoEmisorResult = new EmisorResult();
            dtoEmisor.IdEmisor = Convert.ToInt32(HttpContext.Session.GetInt32("varIdEmisor"));
            dtoEmisor.AplicaIva = AplicaIva;
            dtoEmisorResult = await perfilApi.EditarEmisor(dtoEmisor);
            string strAplicaIva = dtoEmisor.AplicaIva.ToString();
            HttpContext.Session.SetString("varAplicaIva", strAplicaIva);
            return new JsonResult(Ok(dtoEmisor));
        }
    }
}
