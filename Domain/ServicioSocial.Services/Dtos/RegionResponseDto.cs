namespace ServicioSocial.Services
{
    public record RegionResponseDto
    {
        public int RegionId { get; init; }
        public int CountryId { get; init; }
        public string? Name { get; init; }
    }
}