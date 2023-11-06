using Microsoft.AspNetCore.Mvc;
using PrismaFacMovil.Servicios;
using PrismaFacMovil.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.Win32;
using System.Diagnostics;

namespace PrismaFacMovil.Controllers
{
	public class RegistroController : Controller
	{
        private readonly IRegistroApi registroApi;

        public RegistroController(IRegistroApi registroApi)
        {
            this.registroApi = registroApi;
        }
        public IActionResult Index()
		{
            HttpContext.Session.SetString("CodigoExistente", "");
            HttpContext.Session.SetString("MensajeExistente", "");
            HttpContext.Session.SetString("dtoCliente", "");
            HttpContext.Session.SetString("dtoFactura", "");
            HttpContext.Session.SetString("lstProducto", "");
            HttpContext.Session.SetString("lstDetalleFactura", "");
            HttpContext.Session.SetString("MensajeFactura", "");
            HttpContext.Session.SetInt32("CodigoFactura", 0);
            HttpContext.Session.SetString("varAplicaIva", "");
            HttpContext.Session.SetString("CodigoExistenteProducto", "");
            HttpContext.Session.SetString("MensajeExistenteProducto", "");
            HttpContext.Session.SetInt32("CodigoRegistro", 0);
            HttpContext.Session.SetInt32("varIdEmisor", 0);
            HttpContext.Session.SetString("varAplicaIva", "");
            HttpContext.Session.SetInt32("varIdEmisor", 0);
            HttpContext.Session.SetInt32("varIdUsuario", 0);
            HttpContext.Session.SetString("varCodigoSucursal", "");
            HttpContext.Session.SetString("varCodigoEstablecimiento", "");
            HttpContext.Session.SetString("varIdNick", "");
            HttpContext.Session.SetInt32("varIdSucursal", 0);
            HttpContext.Session.SetInt32("varIdEstablecimiento", 0);

            return View();
		}
        public IActionResult Ingreso()
        {
            if (HttpContext.Session.GetInt32("CodigoRegistro") == null)
            {
                HttpContext.Session.SetInt32("CodigoRegistro", 0);
            }
            return View();
        }
        public IActionResult Registro() {
            if (HttpContext.Session.GetInt32("CodigoRegistro") == null)
            {
                HttpContext.Session.SetInt32("CodigoRegistro", 0);
            }
                return View();
		}

        public IActionResult RegistroEstablecimiento()
        {
            if (HttpContext.Session.GetInt32("CodigoRegistro") == null)
            {
                HttpContext.Session.SetInt32("CodigoRegistro", 0);
            }
            return View();
        }
        public IActionResult RegistroUsuario()
        {
            if (HttpContext.Session.GetInt32("CodigoRegistro") == null)
            {
                HttpContext.Session.SetInt32("CodigoRegistro", 0);
            }
            return View();
        }
        public IActionResult Login()
        {
            if (HttpContext.Session.GetInt32("CodigoRegistro") == null)
            {
                HttpContext.Session.SetInt32("CodigoRegistro", 0);
            }
            return View();
        }

        [HttpPost]
		public async Task<IActionResult> GuardarEmisor(IFormCollection frmRegistroEmisor, Emisor dtoR)
		{
			Registro dtoRegistro = new Registro();
			dtoRegistro.Emisor = new Emisor();
			Registro dtoRegistroRespuesta = new Registro();
			
            

            dtoRegistro.Emisor.Ruc = frmRegistroEmisor["Ruc"].ToString();
            dtoRegistro.Emisor.RazonSocial = frmRegistroEmisor["RazonSocial"].ToString();
            dtoRegistro.Emisor.DireccionMatriz = frmRegistroEmisor["DireccionNegocio"].ToString();
            dtoRegistro.Emisor.Telefono = frmRegistroEmisor["Telefono"].ToString();
            dtoRegistro.Emisor.ContraceñaCertificado = frmRegistroEmisor["ContraceñaCertificado"].ToString();


            using (var ms = new System.IO.MemoryStream())
            {


                await dtoR.ArchivoFile.CopyToAsync(ms);
                dtoRegistro.Emisor.Archivo = ms.ToArray();

            }
            dtoRegistroRespuesta = await registroApi.GuardarEmisor(dtoRegistro);
			if (dtoRegistroRespuesta.Codigo == "1")
			{
                HttpContext.Session.SetInt32("CodigoRegistro", 1);
                HttpContext.Session.SetInt32("varIdEmisor", (int)dtoRegistroRespuesta.dtoEmisor.IdEmisor);
                return RedirectToAction("RegistroEstablecimiento");
            }
			else
			{
				HttpContext.Session.SetString("MensajeError", dtoRegistroRespuesta.Mensaje);
				HttpContext.Session.SetInt32("CodigoRegistro", 2);
				return RedirectToAction("Registro");
			}
		}

        [HttpPost]
        public async Task<IActionResult> GuardarEstableciemintoSucursal(IFormCollection frmRegistroEstablecimientoSucursal)
        {
            Registro dtoRegistro = new Registro();
            dtoRegistro.Establecimiento = new Establecimiento();
            dtoRegistro.Sucursal = new Sucursal();
            Registro dtoRegistroRespuesta = new Registro();


            dtoRegistro.Establecimiento.IdEmisor = HttpContext.Session.GetInt32("varIdEmisor");
            dtoRegistro.Establecimiento.CodigoEstablecimiento = frmRegistroEstablecimientoSucursal["CodigoEstablecimiento"].ToString();
            dtoRegistro.Establecimiento.Descripcion = frmRegistroEstablecimientoSucursal["Descripcion"].ToString();
            dtoRegistro.Sucursal.CodigoSucursal = frmRegistroEstablecimientoSucursal["CodigoSucursal"].ToString();
            


            
            dtoRegistroRespuesta = await registroApi.GuardarEstableciemintoSucursal(dtoRegistro);
            if (dtoRegistroRespuesta.Codigo == "1")
            {
                
                HttpContext.Session.SetString("varIdSucursal", dtoRegistroRespuesta.varIdSucursal);
                return RedirectToAction("RegistroUsuario");
            }
            else
            {
                HttpContext.Session.SetString("MensajeError", dtoRegistroRespuesta.Mensaje);
                HttpContext.Session.SetInt32("Error", 0);
                return RedirectToAction("Registro");
            }
        }

        [HttpPost]
        public async Task<IActionResult> GuardarUsuario(IFormCollection frmRegistroUsuario)
        {
            Registro dtoRegistro = new Registro();
            dtoRegistro.Usuario = new Usuario();
            dtoRegistro.Emisor = new Emisor();
            Registro dtoRegistroRespuesta = new Registro();


            dtoRegistro.Usuario.IdEmisor = HttpContext.Session.GetInt32("varIdEmisor");
            dtoRegistro.Usuario.NikUsuario = frmRegistroUsuario["NikUsuario"].ToString();
            dtoRegistro.Usuario.Contrasenia = frmRegistroUsuario["Contrasena"].ToString();
            dtoRegistro.Emisor.Email = frmRegistroUsuario["Correo"].ToString();

            dtoRegistroRespuesta = await registroApi.GuardarUsuario(dtoRegistro);
            if (dtoRegistroRespuesta.Codigo == "1")
            {

                
                return RedirectToAction("Login");
            }
            else
            {
                HttpContext.Session.SetString("MensajeError", dtoRegistroRespuesta.Mensaje);
                HttpContext.Session.SetInt32("Error", 0);
                return RedirectToAction("Registro");
            }
        }

        [HttpPost]
        public async Task<IActionResult> ValidarMovil(VMUsuarios dtoUsuario)
        {
            VMUsuarios dtoUsuarioResult = new VMUsuarios();
            Emisor dtoEmisor = new Emisor();

            if (!string.IsNullOrEmpty(dtoUsuario.NikUsuario) && !string.IsNullOrEmpty(dtoUsuario.Contrasenia))
            {
                dtoUsuarioResult = await registroApi.ValidarMovil(dtoUsuario.NikUsuario, dtoUsuario.Contrasenia);

                if (dtoUsuarioResult == null)
                {
                    HttpContext.Session.SetInt32("Error", 0);
                    HttpContext.Session.SetString("MensajeErrorLogin", dtoUsuarioResult.Mensaje);
                    return RedirectToAction("Login", "Registro");
                }
                else if (dtoUsuarioResult.Codigo == "1")
                {
                    string strAplicaIva = dtoUsuarioResult.AplicaIva.ToString();
                    HttpContext.Session.SetString("varAplicaIva", strAplicaIva);
                    HttpContext.Session.SetInt32("varIdEmisor", (int)dtoUsuarioResult.IdEmisor);
                    HttpContext.Session.SetInt32("varIdUsuario", (int)dtoUsuarioResult.IdUsuario);
                    HttpContext.Session.SetString("varCodigoSucursal", dtoUsuarioResult.CodigoSucursal);
                    HttpContext.Session.SetString("varCodigoEstablecimiento", dtoUsuarioResult.CodigoEstablecimiento);

                    HttpContext.Session.SetString("varIdNick", dtoUsuarioResult.NikUsuario);
                    HttpContext.Session.SetInt32("varIdSucursal", (int)dtoUsuarioResult.IdSucursal);
                    HttpContext.Session.SetInt32("varIdEstablecimiento", (int)dtoUsuarioResult.IdEstablecimiento);
                    return RedirectToAction("Ingreso", "Registro");
                }
                else if (dtoUsuarioResult.Codigo == "0")
                {
                    HttpContext.Session.SetInt32("Login", 2);
                    HttpContext.Session.SetString("MensajeErrorLogin", dtoUsuarioResult.Mensaje);
                    return RedirectToAction("Login", "Registro"); ;
                }
                else
                {
                    HttpContext.Session.SetInt32("Error", 0);
                    HttpContext.Session.SetString("MensajeErrorLogin", dtoUsuarioResult.Mensaje);
                    return RedirectToAction("Login", "Registro");
                }

            }
            else
            {
                return RedirectToAction("Error");
            }

        }

		[HttpPost]
		public async Task<IActionResult> ConsultaRecarga()
		{

			int IdEmisor = (int)HttpContext.Session.GetInt32("varIdEmisor");
            Recarga dtoRecarga = new Recarga();
			dtoRecarga = await registroApi.RecargaLista(IdEmisor);

			return new JsonResult(Ok(dtoRecarga));


		}
	}
}
