namespace ServicioSocial.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public int CommuneId { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public Role RoleId { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }

        public virtual Commune? Commune { get; set; }
        public virtual List<SocialAssistance>? SocialAssistances { get; set; }
    }
}