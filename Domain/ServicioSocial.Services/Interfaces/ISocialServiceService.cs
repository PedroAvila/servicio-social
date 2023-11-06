namespace ServicioSocial.Services
{
    public interface ISocialServiceService
    {
        Task CreateSocialServiceByCommuneAsync(SocialServiceCreateDto dto);
        Task CreateSocialServiceByRegionAsync();
    }
}