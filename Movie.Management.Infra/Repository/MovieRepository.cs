using Microsoft.EntityFrameworkCore;
using Movie.Management.Infra.Data;
using Movie.Management.Infra.Models;
using Movie.Management.Infra.Repository.Interface;

namespace Movie.Management.Infra.Repository
{
    public class MovieRepository : EntityBaseRepository, IMovieRepository
    {
        private readonly AppDbContext _context;

        public MovieRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Movies>> GetAllAsync()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<Movies> GetByIdAsync(Guid id)
        {
            return await _context.Movies.SingleOrDefaultAsync(d => d.Id == id);
        }
    }
}
