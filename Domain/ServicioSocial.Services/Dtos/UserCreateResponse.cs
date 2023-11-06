using ServicioSocial.Entities;

namespace ServicioSocial.Services
{
    public record UserCreateResponse
    {
        public int UserId { get; set; }
        public int CommuneId { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public Role RoleId { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }

        public static UserCreateResponse ToDto(User entity, int id) =>
            new UserCreateResponse()
            {
                UserId = id,
                CommuneId = entity.CommuneId,
                Name = entity.Name,
                Address = entity.Address,
                RoleId = entity.RoleId,
                Password = entity.Password,
                Phone = entity.Phone,
                Email = entity.Email
            };
    }
}