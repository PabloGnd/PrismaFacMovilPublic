using Newtonsoft.Json;
using PrismaFacMovil.Models;
using PrismaFacMovil.Servicios;
using System.Net.Http.Headers;
using System.Text;
namespace PrismaFacMovil.Servicios
{
    public class PerfilApi : IPerfilApi
    {
        private static string strbaseUrl;

        public PerfilApi()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            strbaseUrl = builder.GetSection("ApiSettings:baseUrl").Value;
        }
        public async Task<Perfil> ObtenerPerfil(int intIdEmisor)
        {
            Perfil objeto = new Perfil();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(strbaseUrl);
            var response = await cliente.GetAsync($"/api/Usuario/ObtnerPerfil/{intIdEmisor}");
            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<PerfilResult>(json_respuesta);
                objeto = result.dtoPerfil;
                return objeto;
            }

            return null;
        }
        
        public async Task<EmisorResult> EditarEmisor(Emisor objeto)
        {
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(strbaseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync($"/api/Usuario/EditarEmisor", content);
            if (response.IsSuccessStatusCode)
            {
                var varJsonRespuesta = await response.Content.ReadAsStringAsync();
                var varResult = JsonConvert.DeserializeObject<EmisorResult>(varJsonRespuesta);



                return varResult;
            }

            return null;
        }
        public async Task<EmisorResult> EditarUsuarioEmisor(UsuarioEmisor objeto)
        {
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(strbaseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync($"/api/Usuario/EditarUsuarioEmisor", content);
            if (response.IsSuccessStatusCode)
            {
                var varJsonRespuesta = await response.Content.ReadAsStringAsync();
                var varResult = JsonConvert.DeserializeObject<EmisorResult>(varJsonRespuesta);



                return varResult;
            }

            return null;
        }
    }
}
