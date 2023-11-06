using PrismaFacMovil.Models;
namespace PrismaFacMovil.Servicios
{
    public interface IRecargaApi
    {
        Task<RecargaResult> Guardar(Recarga objeto);
		Task<Recarga> RecargaLista(int IdEmisor);

	}
}
