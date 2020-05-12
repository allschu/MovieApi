using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Services
{
    public class BaseHttpService
    {
        public HttpClient Client { get; }

        public BaseHttpService(HttpClient httpClient)
        {
            httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

            httpClient.BaseAddress = new Uri("https://api.themoviedb.org/");
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIzOWM1MTlmMjA2MTc1NjBkNDY3Y2U5NTA4NzcyM2UyMSIsInN1YiI6IjVlNjM0OTU1MjJhZjNlMDAxM2RlZDEzYiIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.D53nmvOUFC6BwoO6OJriURGHD2cjgovODr4k_JD3p1I");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header

            Client = httpClient;
        }
    }
}
