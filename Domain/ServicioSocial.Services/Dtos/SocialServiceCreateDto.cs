namespace ServicioSocial.Services
{
    public record SocialServiceCreateDto
    {
        public int CommuneId { get; set; }
        public string? Name { get; init; }
    }
}