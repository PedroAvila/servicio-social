using ServicioSocial.Entities;

namespace ServicioSocial.Contract
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> LoginByCredentialAsync(string email);
    }
}