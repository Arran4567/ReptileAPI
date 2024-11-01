using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReptileAPI.Authentication;
using ReptileAPI.Models;

namespace ReptileAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Link DB Table to Model
            modelBuilder.Entity<Animal>().ToTable("Animals");
            modelBuilder.Entity<Species>().ToTable("Species");
            modelBuilder.Entity<Morph>().ToTable("Morphs");
            modelBuilder.Entity<Condition>().ToTable("Conditions");
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Species> Species { get; set; }
        public DbSet<Morph> Morphs { get; set; }
        public DbSet<Condition> Conditions { get; set; }
    }
}
