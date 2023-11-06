using Newtonsoft.Json;
using PrismaFacMovil.Models;
using PrismaFacMovil.Servicios;
using System.Net.Http.Headers;
using System.Text;
namespace PrismaFacMovil.Servicios
{
    public class RegistroApi : IRegistroApi
    {
        private static string strbaseUrl;
        public RegistroApi() {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            strbaseUrl = builder.GetSection("ApiSettings:baseUrl").Value;
        }
        public async Task<Registro> GuardarEmisor(Registro objeto)
        {
            
            Registro dtoRegistro = new Registro();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(strbaseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync($"/api/Registro/GuardarEmisor", content);


            if (response.IsSuccessStatusCode)
            {

                var varJsonRespuesta = await response.Content.ReadAsStringAsync();
                var varResult = JsonConvert.DeserializeObject<Registro>(varJsonRespuesta);
                dtoRegistro.dtoEmisor = varResult.dtoEmisor;
                dtoRegistro.Codigo = varResult.Codigo;
                dtoRegistro.Mensaje = varResult.Mensaje;
                

            }
            return dtoRegistro;

        }

        public async Task<Registro> GuardarEstableciemintoSucursal(Registro objeto)
        {

            Registro dtoRegistro = new Registro();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(strbaseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync($"/api/Registro/GuardarEstableciemintoSucursal", content);
            

            if (response.IsSuccessStatusCode)
            {

                var varJsonRespuesta = await response.Content.ReadAsStringAsync();
                var varResult = JsonConvert.DeserializeObject<Registro>(varJsonRespuesta);
                dtoRegistro.varIdSucursal = varResult.varIdSucursal;
                dtoRegistro.Codigo = varResult.Codigo;
                dtoRegistro.Mensaje = varResult.Mensaje;


            }
            return dtoRegistro;

        }
        public async Task<Registro> GuardarUsuario(Registro objeto)
        {

            Registro dtoRegistro = new Registro();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(strbaseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync($"/api/Registro/GuardarUsuario", content);


            if (response.IsSuccessStatusCode)
            {

                var varJsonRespuesta = await response.Content.ReadAsStringAsync();
                var varResult = JsonConvert.DeserializeObject<Registro>(varJsonRespuesta);
                dtoRegistro.Codigo = varResult.Codigo;
                dtoRegistro.Mensaje = varResult.Mensaje;


            }
            return dtoRegistro;

        }

        public async Task<VMUsuarios> ValidarMovil(string strNombreUsuario, string strPassword)
        {
            VMUsuarios dtoVMUsuarios = new VMUsuarios();

            var varCliente = new HttpClient();
            varCliente.BaseAddress = new Uri(strbaseUrl);
            var response = await varCliente.GetAsync($"/Api/Registro/ValidarMovil/{strNombreUsuario}/{strPassword}");
            if (response.IsSuccessStatusCode)
            {

                var varJsonRespuesta = await response.Content.ReadAsStringAsync();
                var varResult = JsonConvert.DeserializeObject<VMUsuariosResult>(varJsonRespuesta);

                dtoVMUsuarios = varResult.dtoVMUsuarios;
                dtoVMUsuarios.Codigo = varResult.Codigo;
                dtoVMUsuarios.Mensaje = varResult.Mensaje;


                return dtoVMUsuarios;
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
