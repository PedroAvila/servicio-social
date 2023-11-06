using ServicioSocial.Entities;

namespace ServicioSocial.Services
{
    public record UserUpdateDto
    {
        public int UserId { get; init; }
        public int CommuneId { get; init; }
        public string? Name { get; init; }
        public string? Address { get; init; }
        public Role RoleId { get; init; }
        public string? Phone { get; init; }
        public string? Email { get; init; }

        public static User ToEntity(UserUpdateDto dto) =>
            new User()
            {
                UserId = dto.UserId,
                CommuneId = dto.CommuneId,
                Name = dto.Name,
                Address = dto.Address,
                RoleId = dto.RoleId,
                Phone = dto.Phone,
                Email = dto.Email
            };
    }
}