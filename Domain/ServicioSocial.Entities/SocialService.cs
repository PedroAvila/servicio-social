namespace ServicioSocial.Entities
{
    public class SocialService
    {
        public int SocialServiceId { get; set; }
        public string? Name { get; set; }

        public virtual List<SocialAssistance>? SocialAssistances { get; set; }
        public virtual List<SocialServiceCommune>? SocialServiceCommunes { get; set; }
    }
}