using PrismaFacMovil.Models;

namespace PrismaFacMovil.Servicios
{
	public interface IClienteApi
	{
		Task<List<Cliente>> Lista(int intIdEmisor);
		Task<Cliente> Obtener(int intIdCliente);
		//Task<bool> Editar(Cliente objeto);
		Task<ClienteResult> Guardar(Cliente objeto);

        Task<List<Cliente>> ObtenerIdentificacionApellidoNombre(string strIdentificacion, string strApellido, string strNombre);

        //Task<bool> Eliminar(int intIdCliente);
    }
}
