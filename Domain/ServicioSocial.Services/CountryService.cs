using System.Net;
using ServicioSocial.Contract;
using ServicioSocial.Entities;
using ServicioSocial.Operations;
using ServicioSocial.Services.Validations;

namespace ServicioSocial.Services
{
    public class CountryService : ICountryService
    {
        private readonly CountryValidator _countryValidator = new();
        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task CreateAsync(Country entity)
        {
            var validate = _countryValidator.Validate(entity);
            if (!validate.IsValid)
                throw new BusinessException(Validator.GetErrorMessages(validate.Errors), HttpStatusCode.BadRequest);

            await _countryRepository.CreateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _countryRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CountryResponseDto>> GetAllAsync()
        {
            var listCountry = await _countryRepository.GetAllAsync();
            return listCountry.Select(x => new CountryResponseDto()
            {
                CountryId = x.CountryId,
                Name = x.Name
            });
        }

        public async Task<Country> SingleAsync(int id)
        {
            var exist = await _countryRepository.ExistAsync(x => x.CountryId == id);
            if (!exist)
                throw new BusinessException("The country does not exist", HttpStatusCode.NotFound);
            return await _countryRepository.SingleAsync(id);
        }

        public async Task UpdateAsync(Country entity)
        {
            var exist = await _countryRepository.ExistAsync(x => x.CountryId == entity.CountryId);
            if (!exist)
                throw new BusinessException("The country does not exist", HttpStatusCode.NotFound);
            await _countryRepository.UpdateAsync(entity);
        }
    }
}