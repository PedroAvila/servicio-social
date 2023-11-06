namespace ServicioSocial.Services
{
    public record CountryResponseDto
    {
        public int CountryId { get; init; }
        public string? Name { get; init; }
    }
}