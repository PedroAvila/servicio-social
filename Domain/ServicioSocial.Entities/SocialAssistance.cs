namespace ServicioSocial.Entities
{
    /// <summary>
    /// Es la ayuda social
    /// </summary>
    public class SocialAssistance
    {
        public int SocialAssistanceId { get; set; }
        public int? UserId { get; set; }
        public int? SocialServiceId { get; set; }
        public DateTime DateOfAssignment { get; set; }
        public DateTime ExpirationDate { get; set; }

        public virtual User? User { get; set; }
        public virtual SocialService? SocialService { get; set; }
    }
}