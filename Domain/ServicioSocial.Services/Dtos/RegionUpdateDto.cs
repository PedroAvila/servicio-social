using ServicioSocial.Entities;

namespace ServicioSocial.Services
{
    public record RegionUpdateDto
    {
        public int RegionId { get; init; }
        public int CountryId { get; init; }
        public string? Name { get; init; }

        public static Region ToEntity(RegionUpdateDto dto) =>
        new Region()
        {
            RegionId = dto.RegionId,
            CountryId = dto.CountryId,
            Name = dto.Name
        };
    }
}