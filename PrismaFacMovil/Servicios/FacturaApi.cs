using Newtonsoft.Json;
using PrismaFacMovil.Models;
using PrismaFacMovil.Servicios;
using System.Net.Http.Headers;
using System.Text;
namespace PrismaFacMovil.Servicios
{
    public class FacturaApi : IFacturaApi
    {
        private static string strbaseUrl;
        public FacturaApi()
        {
            //accede al archivo appsettings.json.
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            strbaseUrl = builder.GetSection("ApiSettings:baseUrl").Value;
        }

        public async Task<List<Cliente>> Lista(int intIdEmisor)
        {
            List<Cliente> lista = new List<Cliente>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(strbaseUrl);
            var response = await cliente.GetAsync($"/api/Cliente/ListarTop/{intIdEmisor}");
            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ClienteResult>(json_respuesta);
                lista = result.lstClienteView;
                return lista;
            }

            return null;
        }

        public async Task<Cliente> ObtenerIdentificacion(string strIdentificacion)
        {
            Cliente dtoCliente = new Cliente();
           
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(strbaseUrl);
            var response = await cliente.GetAsync($"/api/Cliente/ObtenerIdentificacion/{strIdentificacion}");
            if (response.IsSuccessStatusCode)
            {

                var json_respuesta = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ClienteResult>(json_respuesta);
                dtoCliente = result.dtoCliente;

                return dtoCliente;
            }

            return null;
        }
        public async Task<List<Producto>> ListaProducto(int intIdEmisor)
        {
            List<Producto> lista = new List<Producto>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(strbaseUrl);
            var response = await cliente.GetAsync($"/api/Producto/Lista/{intIdEmisor}");
            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ProductoResult>(json_respuesta);
                lista = result.lstProducto;
                return lista;
            }

            return null;
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
        /// <summary>
        /// LLamado al API de emisión de facturas
        /// 2023/10/22 JG: Cambio el llamado a una nuev API para PrismaFac Móvil
        /// </summary>
        /// <param name="objeto">Modelo con datos de factura</param>
        /// <returns>Respuesta de la API Correcto: 1 Error: 0</returns>
        public async Task<GenerarFactura> Guardar(GenerarFactura objeto)
        {
            GenerarFactura dtoFactura = new GenerarFactura();
            Cliente dtoPrueba = new Cliente();
            GenerarFactura dtoFacturaResult = new GenerarFactura();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(strbaseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");
			var response = await cliente.PostAsync($"/api/Factura/GuardarFacturaMovil", content);
		


			if (response.IsSuccessStatusCode)
            {

                var varJsonRespuesta = await response.Content.ReadAsStringAsync();
                var varResult = JsonConvert.DeserializeObject<GenerarFactura>(varJsonRespuesta);
                dtoFactura.Codigo = varResult.Codigo;
                dtoFactura.Mensaje = varResult.Mensaje;


            }
            return dtoFactura;

        }
		public async Task<List<Factura>> Lista()
		{
			List<Factura> lstFactura = new List<Factura>();
			var factura = new HttpClient();
			factura.BaseAddress = new Uri(strbaseUrl);
			var response = await factura.GetAsync("/api/Factura/lista");
			if (response.IsSuccessStatusCode)
			{
				var json_respuesta = await response.Content.ReadAsStringAsync();
				var result = JsonConvert.DeserializeObject<FacturaResult>(json_respuesta);
				lstFactura = result.lstFactura;
				return lstFactura;
			}
			return null;
		}

		public async Task<List<Producto>> ConsultaProducto(int IdProducto)
		{
			List<Producto> lstProducto = new List<Producto>();
			var cliente = new HttpClient();
			cliente.BaseAddress = new Uri(strbaseUrl);
			var response = await cliente.GetAsync($"/api/Factura/ConsultaProducto/{IdProducto}");
			if (response.IsSuccessStatusCode)
			{
				var json_respuesta = await response.Content.ReadAsStringAsync();
				var result = JsonConvert.DeserializeObject<ProductoResult>(json_respuesta);
				lstProducto = result.lstProducto;
				return lstProducto;
			}
			return null;
		}

		public async Task<List<Factura>> ConsultaFecha(string strFechaInicio, string strFechaFin)
		{
			List<Factura> lstFactura = new List<Factura>();
			var cliente = new HttpClient();
			cliente.BaseAddress = new Uri(strbaseUrl);
			var response = await cliente.GetAsync($"/api/Factura/ConsultaFecha/{strFechaInicio}/{strFechaFin}");
			if (response.IsSuccessStatusCode)
			{
				var json_respuesta = await response.Content.ReadAsStringAsync();
				var result = JsonConvert.DeserializeObject<FacturaResult>(json_respuesta);
				lstFactura = result.lstFactura;
				return lstFactura;
			}
			return null;
		}
	}
}
