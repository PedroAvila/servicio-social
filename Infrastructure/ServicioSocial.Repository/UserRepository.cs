using Microsoft.EntityFrameworkCore;
using ServicioSocial.Contract;
using ServicioSocial.Entities;

namespace ServicioSocial.Repository
{
    public class UserRepository : BaseRespository<User>, IUserRepository
    {
        private readonly ServicioSocialContext _context;
        public UserRepository(ServicioSocialContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> LoginByCredentialAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}