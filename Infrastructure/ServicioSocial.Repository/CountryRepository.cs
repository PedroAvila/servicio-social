using ServicioSocial.Contract;
using ServicioSocial.Entities;

namespace ServicioSocial.Repository
{
    public class CountryRepository : BaseRespository<Country>, ICountryRepository
    {
        public CountryRepository(ServicioSocialContext context) : base(context) { }

    }
}