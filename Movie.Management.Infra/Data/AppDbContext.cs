using Microsoft.EntityFrameworkCore;
using Movie.Management.Infra.Mappings;
using Movie.Management.Infra.Models;

namespace Movie.Management.Infra.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Movies> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MoviesMap());
        }
    }
}
