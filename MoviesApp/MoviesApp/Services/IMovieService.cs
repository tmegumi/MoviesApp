using System.Collections.Generic;
using System.Threading.Tasks;
using MoviesApp.Models;

namespace MoviesApp.Services
{
    public interface IMovieService
    {
        Task<IList<Movie>> GetUpcomingMoviesAsync(int pageNumber);

        Task<IList<Movie>> GetPopularMoviesAsync();

        Task<IList<Genre>> GetGenresAsync();

        Task<IList<Movie>> SearchMoviesAsync(string query, int pageNumber);
    }
}
