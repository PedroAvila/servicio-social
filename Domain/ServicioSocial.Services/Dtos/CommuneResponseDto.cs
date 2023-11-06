namespace ServicioSocial.Services
{
    public record CommuneResponseDto
    {
        public int CommuneId { get; init; }
        public int RegionId { get; init; }
        public string? Name { get; init; }
    }
}