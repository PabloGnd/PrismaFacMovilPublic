using PrismaFacMovil.Models;
namespace PrismaFacMovil.Servicios
{
    public interface INotificacionApi
    {
        Task<List<Notificacion>> Lista();
    }
}
