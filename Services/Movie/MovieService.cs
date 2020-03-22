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
    public class MovieService : IMovieService
    {
        public HttpClient Client { get; private set; }

        public MovieService(HttpClient httpClient)
        {
            httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

            httpClient.BaseAddress = new Uri("https://api.themoviedb.org/");
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIzOWM1MTlmMjA2MTc1NjBkNDY3Y2U5NTA4NzcyM2UyMSIsInN1YiI6IjVlNjM0OTU1MjJhZjNlMDAxM2RlZDEzYiIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.D53nmvOUFC6BwoO6OJriURGHD2cjgovODr4k_JD3p1I");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header

            Client = httpClient;
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
