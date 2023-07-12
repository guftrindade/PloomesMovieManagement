using Movie.Management.Infra.Data;
using Movie.Management.Infra.Models;
using Movie.Management.Infra.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Management.Infra.Repository
{
    public class MovieRepository : BaseRepository, IMovieRepository
    {
        private readonly AppDbContext _context;

        public MovieRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<MovieModel> Get()
        {
            return _context.Movies.ToList();
        }
    }
}
