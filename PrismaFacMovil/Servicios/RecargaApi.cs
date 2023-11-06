using Newtonsoft.Json;
using PrismaFacMovil.Models;
using PrismaFacMovil.Servicios;
using System.Net.Http.Headers;
using System.Text;
namespace PrismaFacMovil.Servicios
{
    public class RecargaApi : IRecargaApi
    {
        private static string strbaseUrl;
        public RecargaApi()
        {
            //accede al archivo appsettings.json.
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            strbaseUrl = builder.GetSection("ApiSettings:baseUrl").Value;
        }

        public async Task<RecargaResult> Guardar(Recarga objeto)
        {


            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(strbaseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync($"/api/Recarga/Guardar", content);


            if (response.IsSuccessStatusCode)
            {
                var varJsonRespuesta = await response.Content.ReadAsStringAsync();
                var varResult = JsonConvert.DeserializeObject<RecargaResult>(varJsonRespuesta);



                return varResult;

            }
            return null;

        }
		public async Task<Recarga> RecargaLista(int IdEmisor)
		{
			Recarga dtoRecarga = new Recarga();
			var cliente = new HttpClient();
			cliente.BaseAddress = new Uri(strbaseUrl);
			var response = await cliente.GetAsync($"/api/Recarga/Lista/{IdEmisor}");
			if (response.IsSuccessStatusCode)
			{
				var json_respuesta = await response.Content.ReadAsStringAsync();
				var result = JsonConvert.DeserializeObject<RecargaResult>(json_respuesta);
				dtoRecarga = result.dtoRecargaFantasma;
				return dtoRecarga;
			}

			return null;
		}
	}
    
}
