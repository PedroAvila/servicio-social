using ServicioSocial.Contract;
using ServicioSocial.Entities;

namespace ServicioSocial.Repository
{
    public class CommuneRepository : BaseRespository<Commune>, ICommuneRepository
    {
        public CommuneRepository(ServicioSocialContext context) : base(context) { }

    }
}