using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServicioSocial.Entities;

namespace ServicioSocial.Repository.Map
{
    public class LogMap : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.ToTable("Logs");
            builder.HasKey(c => c.LogId);
            builder.Property(c => c.LogId).ValueGeneratedOnAdd();

            builder.Property(c => c.Action).HasMaxLength(200);
            builder.Property(c => c.UserId);
            builder.Property(c => c.Date);
        }
    }
}