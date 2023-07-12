using Microsoft.EntityFrameworkCore;
using Movie.Management.Infra.Models;

namespace Movie.Management.Infra.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<MovieModel> Movies { get; set; }
    }
}
