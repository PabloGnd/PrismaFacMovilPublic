
namespace PrismaFacMovil.Models
{
	public class Cliente
	{
		public int IdCliente { get; set; }

		public int? IdEmisor { get; set; }

		public string? TipoIdentificacion { get; set; }

		public string? Identificacion { get; set; }

		public string? Nombre1 { get; set; }

		public string? Nombre2 { get; set; }

		public string? Apellido1 { get; set; }

		public string? Apellido2 { get; set; }

		public string? DireccionCliente { get; set; }

		public string? Correo { get; set; }

		public string? Telefono { get; set; }

		public char InicialNombre { get; set; }
		public char InicialApellido { get; set; }
	}
}
