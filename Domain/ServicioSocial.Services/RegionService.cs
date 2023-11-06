using System.Net;
using ServicioSocial.Contract;
using ServicioSocial.Entities;
using ServicioSocial.Operations;
using ServicioSocial.Services.Validations;

namespace ServicioSocial.Services
{
    public class RegionService : IRegionService
    {
        private readonly RegionValidator _regionValidator = new();
        private readonly IRegionRepository _regionRepository;

        public RegionService(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }

        public async Task CreateAsync(Region entity)
        {
            var validate = _regionValidator.Validate(entity);
            if (!validate.IsValid)
                throw new BusinessException(Validator.GetErrorMessages(validate.Errors), HttpStatusCode.BadRequest);
            await _regionRepository.CreateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var exist = await _regionRepository.ExistAsync(x => x.RegionId == id);
            if (!exist)
                throw new BusinessException("The region does not exist", HttpStatusCode.NotFound);
            await _regionRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<RegionResponseDto>> GetAllAsync()
        {
            var listRegion = await _regionRepository.GetAllAsync();
            return listRegion.Select(x => new RegionResponseDto()
            {
                RegionId = x.RegionId,
                CountryId = x.CountryId,
                Name = x.Name
            });
        }

        public async Task<Region> SingleAsync(int id)
        {
            var exist = await _regionRepository.ExistAsync(x => x.RegionId == id);
            if (!exist)
                throw new BusinessException("The region does not exist", HttpStatusCode.NotFound);
            return await _regionRepository.SingleAsync(id);
        }

        public async Task UpdateAsync(Region entity)
        {
            var exist = await _regionRepository.ExistAsync(x => x.RegionId == entity.RegionId);
            if (!exist)
                throw new BusinessException("The region does not exist", HttpStatusCode.NotFound);
            await _regionRepository.UpdateAsync(entity);
        }
    }
}