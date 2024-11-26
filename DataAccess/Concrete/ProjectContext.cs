using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class ProjectContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=portfolio;User Id=postgres;Password=admin");
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ContactForm> ContactForms { get; set; }
        public DbSet<ProjectImage> ProjectImages { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
    }
}
