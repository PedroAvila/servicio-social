using Microsoft.EntityFrameworkCore;
using ServicioSocial.Entities;
using ServicioSocial.Repository.Map;

namespace ServicioSocial.Repository
{
    public class ServicioSocialContext : DbContext
    {
        public ServicioSocialContext(DbContextOptions<ServicioSocialContext> options) : base(options) { }

        public DbSet<User>? Users { get; set; }
        public DbSet<Country>? Countries { get; set; }
        public DbSet<Region>? Regions { get; set; }
        public DbSet<Commune>? Communes { get; set; }
        public DbSet<SocialService>? SocialServices { get; set; }
        public DbSet<SocialAssistance>? SocialAssistances { get; set; }
        public DbSet<Log>? Logs { get; set; }
        public DbSet<SocialServiceCommune>? SocialServiceCommunes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SocialServiceCommune>()
            .HasKey(pc => new { pc.SocialServideId, pc.CommuneId });

            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new CountryMap());
            modelBuilder.ApplyConfiguration(new RegionMap());
            modelBuilder.ApplyConfiguration(new CommuneMap());
            modelBuilder.ApplyConfiguration(new SocialServiceMap());
            modelBuilder.ApplyConfiguration(new SocialAssistanceMap());
            modelBuilder.ApplyConfiguration(new LogMap());

            base.OnModelCreating(modelBuilder);
        }

    }
}