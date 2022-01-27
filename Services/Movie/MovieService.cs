using System.Net.Http;
using Services.Movie.Interfaces;
using Services.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace Services.Movie
{
    public class MovieService : BaseHttpService, IMovieService
    {
        private readonly ILogger<MovieService> _logger;

        public MovieService(HttpClient client, IConfiguration configuration, ILogger<MovieService> logger) 
            : base(client, configuration)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        
        public async Task<MovieResultSelection> GetPopularMovies(int page)
        {
            var response = await Client.GetAsync($"3/movie/popular?page={page}").ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError($"HTTP ERROR: {response.ReasonPhrase}");
            }

            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonConvert.DeserializeObject<MovieResultSelection>(content);
        }

        public async Task<MovieResultSelection> GetPopularMovies()
        {
            var response = await Client.GetAsync($"3/movie/popular").ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError($"HTTP ERROR: {response.ReasonPhrase}");
            }

            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonConvert.DeserializeObject<MovieResultSelection>(content);
        }

        public async Task<MovieDetail> GetMovie(int id)
        {
            var response = await Client.GetAsync($"3/movie/{id}").ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError($"HTTP ERROR: {response.ReasonPhrase}");
            }

            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonConvert.DeserializeObject<MovieDetail>(content);
        }

        public async Task<MovieResultSelection> GetMovieRecommendations(int id)
        {
            var response = await Client.GetAsync($"3/movie/{id}/recommendations").ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError($"HTTP ERROR: {response.ReasonPhrase}");
            }

            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonConvert.DeserializeObject<MovieResultSelection>(content);
        }

        public async Task<MovieTrendingResultSelection> GetTrendingMovies()
        {
            var response = await Client.GetAsync($"3/trending/movie/day").ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError($"HTTP ERROR: {response.ReasonPhrase}");
            }

            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonConvert.DeserializeObject<MovieTrendingResultSelection>(content);
        }

        public async Task<MovieSearchResultSelection> Search(string query, int page)
        {
            var response = await Client.GetAsync($"3/search/movie?query={query}&page={page}&include_adult=false").ConfigureAwait(false);
            
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError($"HTTP ERROR: {response.ReasonPhrase}");
            }

            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonConvert.DeserializeObject<MovieSearchResultSelection>(content);
        }
    }
}
