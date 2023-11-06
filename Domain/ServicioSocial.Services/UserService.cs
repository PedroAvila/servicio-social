using System.Net;
using ServicioSocial.Contract;
using ServicioSocial.Entities;
using ServicioSocial.Operations;
using ServicioSocial.Services.Validations;

namespace ServicioSocial.Services
{
    public class UserService : IUserService
    {
        private readonly UserValidator _userValidator = new();
        private readonly IKeyEncryptor _keyEncryptor;
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository, IKeyEncryptor keyEncryptor)
        {
            _keyEncryptor = keyEncryptor;
            _userRepository = userRepository;
        }

        public async Task<UserCreateResponse> CreateAsync(User entity)
        {
            var validate = _userValidator.Validate(entity);
            if (!validate.IsValid)
                throw new BusinessException(Validator.GetErrorMessages(validate.Errors), HttpStatusCode.BadRequest);

            var exist = await _userRepository.ExistAsync(x => x.Email == entity.Email);
            if (exist)
                throw new BusinessException("The email is already registered", HttpStatusCode.BadRequest);

            entity.Password = _keyEncryptor.HashPassword(entity.Password!);
            await _userRepository.CreateAsync(entity);
            int userId = entity.UserId;

            return UserCreateResponse.ToDto(entity, userId);
        }

        public async Task<IEnumerable<UserResponseDto>> GetAllAsync()
        {
            var listUser = await _userRepository.GetAllAsync();
            return listUser.Select(x => new UserResponseDto()
            {
                UserId = x.UserId,
                CommuneId = x.CommuneId,
                Name = x.Name,
                Address = x.Address,
                RoleId = x.RoleId,
                Phone = x.Phone,
                Email = x.Email
            });
        }

        public Task<User> LoginByCredentialAsync(UserLoginDto dto)
        {
            var userFound = _userRepository.LoginByCredentialAsync(dto.Email!);
            if (userFound is null)
                throw new BusinessException("Usuario no existe", HttpStatusCode.NotFound);
            return userFound;
        }

        public async Task<User> SingleAsync(int id)
        {
            var exist = await _userRepository.ExistAsync(x => x.UserId == id);
            if (!exist)
                throw new BusinessException("The user does not exist", HttpStatusCode.NotFound);
            return await _userRepository.SingleAsync(id);
        }

        public async Task UpdateAsync(User entity)
        {
            var exist = await _userRepository.ExistAsync(x => x.UserId == entity.UserId);
            if (!exist)
                throw new BusinessException("The user does not exist", HttpStatusCode.NotFound);
            await _userRepository.UpdateAsync(entity);
        }
    }
}