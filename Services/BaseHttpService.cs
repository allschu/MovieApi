using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Services
{
    public class BaseHttpService
    {
        public HttpClient Client { get; }

        public BaseHttpService(HttpClient httpClient, IConfiguration configuration)
        {
            httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

            httpClient.BaseAddress = new Uri("https://api.themoviedb.org/");
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer { configuration["MovieApiBearer"] }");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Client = httpClient;
        }
    }
}
