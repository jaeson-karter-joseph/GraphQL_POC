using GraphQL.Data.ContextConfigurations;
using GraphQL.Interfaces;

namespace GraphQL.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public MovieRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}
