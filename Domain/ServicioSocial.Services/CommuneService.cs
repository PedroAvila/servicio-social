using System.Net;
using ServicioSocial.Contract;
using ServicioSocial.Entities;
using ServicioSocial.Operations;
using ServicioSocial.Services.Validations;

namespace ServicioSocial.Services
{
    public class CommuneService : ICommuneService
    {
        private readonly CommuneValidator _communeValidator = new();
        private readonly ICommuneRepository _communeRepository;

        public CommuneService(ICommuneRepository communeRepository)
        {
            _communeRepository = communeRepository;
        }

        public async Task CreateAsync(Commune entity)
        {
            var validate = _communeValidator.Validate(entity);
            if (!validate.IsValid)
                throw new BusinessException(Validator.GetErrorMessages(validate.Errors), HttpStatusCode.BadRequest);
            await _communeRepository.CreateAsync(entity);
        }

        public async Task<IEnumerable<CommuneResponseDto>> GetAllAsync()
        {
            var listCommune = await _communeRepository.GetAllAsync();
            return listCommune.Select(x => new CommuneResponseDto()
            {
                CommuneId = x.CommuneId,
                RegionId = x.RegionId,
                Name = x.Name
            });
        }

        public async Task<Commune> SingleAsync(int id)
        {
            var exist = await _communeRepository.ExistAsync(x => x.CommuneId == id);
            if (!exist)
                throw new BusinessException("The commune does not exist", HttpStatusCode.NotFound);
            return await _communeRepository.SingleAsync(id);
        }

        public async Task UpdateAsync(Commune entity)
        {
            var exist = await _communeRepository.ExistAsync(x => x.CommuneId == entity.CommuneId);
            if (!exist)
                throw new BusinessException("The commune does not exist", HttpStatusCode.NotFound);
            await _communeRepository.UpdateAsync(entity);
        }
    }
}