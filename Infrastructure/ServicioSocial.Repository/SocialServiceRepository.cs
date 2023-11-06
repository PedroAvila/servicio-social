using ServicioSocial.Contract;
using ServicioSocial.Entities;

namespace ServicioSocial.Repository
{
    public class SocialServiceRepository : BaseRespository<SocialService>, ISocialServiceRepository
    {
        private readonly ServicioSocialContext _context;
        public SocialServiceRepository(ServicioSocialContext context) : base(context)
        {
            _context = context;
        }

        public async Task CreateSocialServiceByCommuneAsync(SocialServiceCommune entity)
        {
            await _context.SocialServiceCommunes.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
    }
}