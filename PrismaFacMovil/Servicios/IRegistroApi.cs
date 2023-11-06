using PrismaFacMovil.Models;
namespace PrismaFacMovil.Servicios
{
    public interface IRegistroApi
    {
        Task<Registro> GuardarEmisor(Registro objeto);
        Task<Registro> GuardarEstableciemintoSucursal(Registro objeto);
        Task<Registro> GuardarUsuario(Registro objeto);
        Task<VMUsuarios> ValidarMovil(string strNombreUsuario, string strPassword);
		Task<Recarga> RecargaLista(int IdEmisor);
	}
}
