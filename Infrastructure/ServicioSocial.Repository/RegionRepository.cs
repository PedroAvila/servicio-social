using ServicioSocial.Contract;
using ServicioSocial.Entities;

namespace ServicioSocial.Repository
{
    public class RegionRepository : BaseRespository<Region>, IRegionRepository
    {
        public RegionRepository(ServicioSocialContext context) : base(context) { }

    }
}