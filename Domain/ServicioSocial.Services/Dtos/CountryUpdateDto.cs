using ServicioSocial.Entities;

namespace ServicioSocial.Services.Dtos
{
    public record CountryUpdateDto
    {
        public int CountryId { get; init; }
        public string? Name { get; init; }

        public static Country ToEntity(CountryUpdateDto dto) =>
        new Country
        {
            CountryId = dto.CountryId,
            Name = dto.Name
        };
    }
}