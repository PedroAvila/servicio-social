namespace ServicioSocial.Entities
{
    public class Commune
    {
        public int CommuneId { get; set; }
        public int RegionId { get; set; }
        public string? Name { get; set; }

        public virtual Region? Region { get; set; }
        public virtual List<User>? Users { get; set; }
        public List<SocialServiceCommune>? SocialServiceCommunes { get; set; }
    }
}