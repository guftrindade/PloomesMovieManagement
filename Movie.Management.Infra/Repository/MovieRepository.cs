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

        public IEnumerable<Movies> GetAllMovies()
        {
            return _context.Movies.ToList();
        }

        public Movies GetMovieById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
