using Newtonsoft.Json;
using PrismaFacMovil.Models;
using PrismaFacMovil.Servicios;
using System.Net.Http.Headers;
using System.Text;
namespace PrismaFacMovil.Servicios
{
    public class NotificacionApi : INotificacionApi
    {
        private static string strbaseUrl;
        public NotificacionApi()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            strbaseUrl = builder.GetSection("ApiSettings:baseUrl").Value;
        }
        public async Task<List<Notificacion>> Lista()
        {
            List<Notificacion> lista = new List<Notificacion>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(strbaseUrl);
            var response = await cliente.GetAsync($"/api/Notificacion/Lista");
            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<NotificacionResult>(json_respuesta);
                lista = result.lstNotificacion;
                return lista;
            }

            return null;
        }
    }
}
