using ServicioSocial.Entities;

namespace ServicioSocial.Services
{
    public record CommuneUpdateDto
    {
        public int CommuneId { get; init; }
        public int RegionId { get; init; }
        public string? Name { get; init; }

        public static Commune ToEntity(CommuneUpdateDto dto) =>
        new Commune
        {
            CommuneId = dto.CommuneId,
            RegionId = dto.RegionId,
            Name = dto.Name
        };
    }
}