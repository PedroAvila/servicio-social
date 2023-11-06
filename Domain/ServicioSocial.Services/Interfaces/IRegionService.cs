using ServicioSocial.Entities;

namespace ServicioSocial.Services
{
    public interface IRegionService
    {
        Task<IEnumerable<RegionResponseDto>> GetAllAsync();
        Task<Region> SingleAsync(int id);
        Task CreateAsync(Region entity);
        Task UpdateAsync(Region entity);
        Task DeleteAsync(int id);
    }
}