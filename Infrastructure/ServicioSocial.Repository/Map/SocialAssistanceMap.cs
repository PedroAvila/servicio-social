using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServicioSocial.Entities;

namespace ServicioSocial.Repository.Map
{
    public class SocialAssistanceMap : IEntityTypeConfiguration<SocialAssistance>
    {
        public void Configure(EntityTypeBuilder<SocialAssistance> builder)
        {
            builder.ToTable("SocialAssistences");
            builder.HasKey(c => c.SocialAssistanceId);
            builder.Property(c => c.SocialAssistanceId).ValueGeneratedOnAdd();

            builder.HasOne(c => c.User)
            .WithMany(c => c.SocialAssistances)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(c => c.SocialService)
            .WithMany(c => c.SocialAssistances)
            .HasForeignKey(c => c.SocialServiceId)
            .OnDelete(DeleteBehavior.ClientCascade);

            builder.Property(c => c.DateOfAssignment);
            builder.Property(c => c.ExpirationDate);
        }
    }
}