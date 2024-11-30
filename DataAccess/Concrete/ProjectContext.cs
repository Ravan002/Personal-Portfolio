using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class ProjectContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=portfolio;User Id=postgres;Password=admin");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Project>()
                .HasMany(p => p.ProjectImages)
                .WithOne(pi => pi.Project)
                .HasForeignKey(pi => pi.ProjectId);
        }

        public DbSet<AboutMe> AboutMes { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ContactForm> ContactForms { get; set; }
        public DbSet<ProjectImage> ProjectImage { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Skill> Skills { get; set; }

    }
}
