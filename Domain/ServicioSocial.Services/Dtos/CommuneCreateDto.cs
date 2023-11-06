using ServicioSocial.Entities;

namespace ServicioSocial.Services
{
    public record CommuneCreateDto
    {
        public int RegionId { get; init; }
        public string? Name { get; init; }

        public static Commune ToEntity(CommuneCreateDto dto) =>
        new Commune
        {
            RegionId = dto.RegionId,
            Name = dto.Name
        };
    }
}