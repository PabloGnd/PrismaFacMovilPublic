namespace PrismaFacMovil.Models
{
	public class ClienteResult
	{
		public List<Cliente> lstClienteView { get; set;}	
		public Cliente dtoCliente { get; set; }

		public string Codigo { set; get; }

		public string Mensaje { set; get; }
	}
}
