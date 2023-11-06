using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServicioSocial.Entities;

namespace ServicioSocial.Repository.Map
{
    public class CountryMap : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Countries");
            builder.HasKey(c => c.CountryId);
            builder.Property(c => c.CountryId).ValueGeneratedOnAdd();

            builder.Property(c => c.Name).HasMaxLength(50);
        }
    }
}