using ServicioSocial.Entities;

namespace ServicioSocial.Services
{
    public record CountryCreateDto
    {
        public string? Name { get; init; }

        public static Country ToEntity(CountryCreateDto dto) =>
        new Country
        {
            Name = dto.Name
        };
    }
}