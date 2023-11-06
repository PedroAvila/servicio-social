using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServicioSocial.Entities;

namespace ServicioSocial.Repository
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(c => c.UserId);
            builder.Property(c => c.UserId).ValueGeneratedOnAdd();

            builder.HasOne(c => c.Commune)
            .WithMany(c => c.Users)
            .HasForeignKey(c => c.CommuneId)
            .OnDelete(DeleteBehavior.Cascade);

            builder.Property(c => c.Name).HasMaxLength(100);
            builder.Property(c => c.Address).HasMaxLength(200);
            builder.Property(c => c.RoleId).IsRequired();
            builder.Property(c => c.Phone).HasMaxLength(10);
            builder.Property(c => c.Email).HasMaxLength(50);
            builder.Property(c => c.Password).HasMaxLength(50);
        }
    }
}