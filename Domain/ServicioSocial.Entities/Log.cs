namespace ServicioSocial.Entities
{
    public class Log
    {
        public int LogId { get; set; }
        public string? Action { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
    }
}