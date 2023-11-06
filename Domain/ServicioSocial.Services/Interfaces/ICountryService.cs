using ServicioSocial.Entities;

namespace ServicioSocial.Services
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryResponseDto>> GetAllAsync();
        Task<Country> SingleAsync(int id);
        Task CreateAsync(Country entity);
        Task UpdateAsync(Country entity);
        Task DeleteAsync(int id);
    }
}