using ServicioSocial.Entities;

namespace ServicioSocial.Services
{
    public record UserCreateDto
    {
        public int CommuneId { get; init; }
        public string? Name { get; init; }
        public string? Address { get; init; }
        public Role RoleId { get; init; }
        public string? Password { get; init; }
        public string? Phone { get; init; }
        public string? Email { get; init; }

        public static User ToEntity(UserCreateDto dto) =>
            new User()
            {
                CommuneId = dto.CommuneId,
                Name = dto.Name,
                Address = dto.Address,
                RoleId = dto.RoleId,
                Password = dto.Password,
                Phone = dto.Phone,
                Email = dto.Email
            };
    }
}