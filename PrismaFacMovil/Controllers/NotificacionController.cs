using Microsoft.AspNetCore.Mvc;
using PrismaFacMovil.Servicios;
using PrismaFacMovil.Models;
using Newtonsoft.Json;
namespace PrismaFacMovil.Controllers
{
    public class NotificacionController : Controller
    {
        private readonly INotificacionApi notificacionApi;
        public NotificacionController(INotificacionApi notificacionApi)
        {
            this.notificacionApi = notificacionApi;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Lista()
        {

            
            List<Notificacion> lstNotificacion = await notificacionApi.Lista();


            return View("Index", lstNotificacion);

        }
    }
}
