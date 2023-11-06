using Microsoft.AspNetCore.WebSockets;
using ServicioSocial.Contract;
using ServicioSocial.Repository;
using ServicioSocial.Services;

namespace ServicioSocial.Api
{
    public static class ApplicationServiceExtensions
    {
        public static void AddRegisterService(this IServiceCollection services)
        {
            /*Persistencia*/
            services.AddScoped(typeof(IRepository<>), typeof(BaseRespository<>));
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IRegionRepository, RegionRepository>();
            services.AddScoped<ICommuneRepository, CommuneRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISocialServiceRepository, SocialServiceRepository>();

            /*Services*/
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IRegionService, RegionService>();
            services.AddScoped<ICommuneService, CommuneService>();
            services.AddScoped<IKeyEncryptor, KeyEncryptor>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISocialServiceService, SocialServiceService>();
        }
    }
}