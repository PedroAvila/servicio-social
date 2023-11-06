using ServicioSocial.Entities;

namespace ServicioSocial.Services
{
    public record RegionCreateDto
    {
        public int CountryId { get; init; }
        public string? Name { get; init; }

        public static Region ToEntity(RegionCreateDto dto) =>
        new Region
        {
            CountryId = dto.CountryId,
            Name = dto.Name
        };
    }
}