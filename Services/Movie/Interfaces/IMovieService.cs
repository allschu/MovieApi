using Services.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Movie.Interfaces
{
    public interface IMovieService
    {
        public Task<MovieResultSelection> GetPopularMovies(int page, CancellationToken token = default);

        public Task<MovieResultSelection> GetPopularMovies(CancellationToken token = default);

        public Task<MovieDetail> GetMovie(int id, CancellationToken token = default);

        public Task<MovieSearchResultSelection> Search(string query, int page, CancellationToken token = default);

        public Task<MovieResultSelection> GetMovieRecommendations(int id, CancellationToken token = default);

        public Task<MovieTrendingResultSelection> GetTrendingMovies(CancellationToken token = default);
    }
}
