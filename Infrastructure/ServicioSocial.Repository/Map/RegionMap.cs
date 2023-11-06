using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServicioSocial.Entities;

namespace ServicioSocial.Repository.Map
{
    public class RegionMap : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.ToTable("Regions");
            builder.HasKey(c => c.RegionId);
            builder.Property(c => c.RegionId).ValueGeneratedOnAdd();

            builder.HasOne(c => c.Country)
            .WithMany(c => c.Regions)
            .HasForeignKey(c => c.CountryId)
            .OnDelete(DeleteBehavior.Cascade);

            builder.Property(c => c.Name).HasMaxLength(80);
        }
    }
}