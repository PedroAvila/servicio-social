namespace ServicioSocial.Entities
{
    public class SocialServiceCommune
    {
        public int SocialServideId { get; set; }
        public int CommuneId { get; set; }

        public virtual SocialService? SocialService { get; set; }
        public virtual Commune? Commune { get; set; }
    }
}