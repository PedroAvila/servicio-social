namespace ServicioSocial.Entities
{
    public class Region
    {
        public int RegionId { get; set; }
        public int CountryId { get; set; }
        public string? Name { get; set; }

        public virtual Country? Country { get; set; }
        public virtual List<Commune>? Communes { get; set; }
    }
}