using ServicioSocial.Entities;

namespace ServicioSocial.Services
{
    public record UserResponseDto
    {
        public int UserId { get; init; }
        public int CommuneId { get; init; }
        public string? Name { get; init; }
        public string? Address { get; init; }
        public Role RoleId { get; init; }
        public string? Phone { get; init; }
        public string? Email { get; init; }
    }
}