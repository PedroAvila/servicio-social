namespace ServicioSocial.Entities
{
    public class Country
    {
        public int CountryId { get; set; }
        public string? Name { get; set; }

        public virtual List<Region>? Regions { get; set; }
    }
}