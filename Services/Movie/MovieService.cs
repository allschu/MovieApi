using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Services.Movie.Interfaces;
using Services.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Services.Movie
{
    public class MovieService : BaseHttpService, IMovieService
    {
        public MovieService(HttpClient client) 
            : base(client)
        {

        }
        
        public async Task<MovieResultSelection> GetPopularMovies()
        {
            var response = await Client.GetAsync("3/movie/popular").ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                // throw error / or insert circuitbreaker?
            }

            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonConvert.DeserializeObject<MovieResultSelection>(content);
        }

        public Task<MovieSelection> GetMovie(int id)
        {
            throw new NotImplementedException();
        }

        public Task<MovieSelection[]> GetMovieRecommendations(int id)
        {
            throw new NotImplementedException();
        }

        public Task<MovieSelection[]> GetTrendingMovies()
        {
            throw new NotImplementedException();
        }
    }
}
