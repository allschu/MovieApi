using Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Movie.Interfaces
{
    public interface IMovieService
    {
        public Task<MovieResultSelection> GetPopularMovies(int page);

        public Task<MovieResultSelection> GetPopularMovies();

        public Task<MovieDetail> GetMovie(int id);

        public Task<MovieSearchResultSelection> Search(string query, int page);

        public Task<MovieResultSelection> GetMovieRecommendations(int id);

        public Task<MovieTrendingResultSelection> GetTrendingMovies();
    }
}
