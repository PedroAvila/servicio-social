using ServicioSocial.Entities;

namespace ServicioSocial.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponseDto>> GetAllAsync();
        Task<User> SingleAsync(int id);
        Task<UserCreateResponse> CreateAsync(User entity);
        Task UpdateAsync(User entity);
        Task<User> LoginByCredentialAsync(UserLoginDto dto);
    }
}