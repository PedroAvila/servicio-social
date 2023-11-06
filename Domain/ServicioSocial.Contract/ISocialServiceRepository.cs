using ServicioSocial.Entities;

namespace ServicioSocial.Contract
{
    public interface ISocialServiceRepository : IRepository<SocialService>
    {
        Task CreateSocialServiceByCommuneAsync(SocialServiceCommune entity);
    }
}