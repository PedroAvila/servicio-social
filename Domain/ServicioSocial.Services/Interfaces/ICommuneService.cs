using ServicioSocial.Entities;

namespace ServicioSocial.Services
{
    public interface ICommuneService
    {
        Task<IEnumerable<CommuneResponseDto>> GetAllAsync();
        Task<Commune> SingleAsync(int id);
        Task CreateAsync(Commune entity);
        Task UpdateAsync(Commune entity);
    }
}