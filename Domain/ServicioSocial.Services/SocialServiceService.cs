using System.Net;
using ServicioSocial.Contract;
using ServicioSocial.Entities;
using ServicioSocial.Operations;

namespace ServicioSocial.Services
{
    public class SocialServiceService : ISocialServiceService
    {
        private readonly ISocialServiceRepository _socialServiceRepository;
        private readonly ICommuneService _communeService;

        public SocialServiceService(
            ISocialServiceRepository socialServiceRepository,
            ICommuneService communeService
            )
        {
            _communeService = communeService;
            _socialServiceRepository = socialServiceRepository;
        }

        public async Task CreateSocialServiceByCommuneAsync(SocialServiceCreateDto dto)
        {
            var socialService = new SocialService { Name = dto.Name };
            await _socialServiceRepository.CreateAsync(socialService);
            int id = socialService.SocialServiceId;

            var communeFound = await _communeService.SingleAsync(dto.CommuneId);
            if (communeFound is null)
                throw new BusinessException("CommuneId entered does not exist", HttpStatusCode.NotFound);
            var socialServiceCommune = new SocialServiceCommune
            {
                SocialServideId = id,
                CommuneId = communeFound.CommuneId
            };

            await _socialServiceRepository.CreateSocialServiceByCommuneAsync(socialServiceCommune);
        }

        public Task CreateSocialServiceByRegionAsync()
        {
            throw new NotImplementedException();
        }
    }
}