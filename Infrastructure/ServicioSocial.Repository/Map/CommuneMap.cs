using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServicioSocial.Entities;

namespace ServicioSocial.Repository.Map
{
    public class CommuneMap : IEntityTypeConfiguration<Commune>
    {
        public void Configure(EntityTypeBuilder<Commune> builder)
        {
            builder.ToTable("Communes");
            builder.HasKey(c => c.CommuneId);
            builder.Property(c => c.CommuneId).ValueGeneratedOnAdd();

            builder.HasOne(c => c.Region)
            .WithMany(c => c.Communes)
            .HasForeignKey(c => c.RegionId)
            .OnDelete(DeleteBehavior.Cascade);

            builder.Property(c => c.Name).HasMaxLength(150);
        }
    }
}