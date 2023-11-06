using PrismaFacMovil.Models;

namespace PrismaFacMovil.Servicios
{
    public interface IPerfilApi
    {
        Task<Perfil> ObtenerPerfil(int intIdEmisor);
        Task<EmisorResult> EditarEmisor(Emisor objeto);
        Task<EmisorResult> EditarUsuarioEmisor(UsuarioEmisor objeto);
    }
}
