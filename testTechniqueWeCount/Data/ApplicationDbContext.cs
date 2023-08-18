using Microsoft.EntityFrameworkCore;
using testTechniqueWeCount.Models;

namespace testTechniqueWeCount.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}
        public DbSet<Candidature> Candidatures { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrateur>()
                .HasIndex(a => a.Login)
                .IsUnique();
        }

    }
}
