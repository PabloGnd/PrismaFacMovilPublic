using PrismaFacMovil.Models;
using Newtonsoft.Json;
using PrismaFacMovil.Servicios;
using System.Net.Http.Headers;
using System.Text;
namespace PrismaFacMovil.Servicios
{
    public class ProductoApi : IProductoApi
    {
        private static string strbaseUrl;
        public ProductoApi()
        {
            //accede al archivo appsettings.json.
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            strbaseUrl = builder.GetSection("ApiSettings:baseUrl").Value;
        }
        public async Task<List<Producto>> Lista(int IdEmisor)
        {
            List<Producto> lstProducto = new List<Producto>();
            var producto = new HttpClient();
            producto.BaseAddress = new Uri(strbaseUrl);
            var response = await producto.GetAsync($"/api/Producto/lista/{IdEmisor}");
            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ProductoResult>(json_respuesta);
                lstProducto = result.lstProducto;
                return lstProducto;
            }

            return null;
        }

        public async Task<ProductoResult> Guardar(Producto objeto)
        {


            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(strbaseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync($"/api/Producto/Guardar", content);


            if (response.IsSuccessStatusCode)
            {
                var varJsonRespuesta = await response.Content.ReadAsStringAsync();
                var varResult = JsonConvert.DeserializeObject<ProductoResult>(varJsonRespuesta);



                return varResult;

            }
            return null;

        }
        public async Task<Producto> Obtener(int IdProducto)
        {
            Producto objeto = new Producto();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(strbaseUrl);
            var response = await cliente.GetAsync($"/api/Producto/Obtener/{IdProducto}");
            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ProductoResult>(json_respuesta);
                objeto = result.dtoProducto;
                
            }

            return objeto;
        }

        public async Task<List<Producto>> ObtenerNemonicoDescripcion(string strNemonico, string strDescripcion)
        {
            List<Producto> lstProducto = new List<Producto>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(strbaseUrl);
            var response = await cliente.GetAsync($"/api/Producto/ObtenerNemonicoDescripcion/{strNemonico}/{strDescripcion}");
            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ProductoResult>(json_respuesta);
                lstProducto = result.lstProducto;
                return lstProducto;
            }

            return null;
        }
    }
    
}
