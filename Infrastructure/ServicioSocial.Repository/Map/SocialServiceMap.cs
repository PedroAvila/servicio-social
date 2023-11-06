using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServicioSocial.Entities;

namespace ServicioSocial.Repository.Map
{
    public class SocialServiceMap : IEntityTypeConfiguration<SocialService>
    {
        public void Configure(EntityTypeBuilder<SocialService> builder)
        {
            builder.ToTable("SocialServices");
            builder.HasKey(c => c.SocialServiceId);
            builder.Property(c => c.SocialServiceId).ValueGeneratedOnAdd();

            builder.Property(c => c.Name).HasMaxLength(300);
        }
    }
}