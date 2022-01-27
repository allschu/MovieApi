using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Services.Cast.Interfaces;
using Services.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace Services.Cast
{
    public class CastService : BaseHttpService, ICastService
    {
        public CastService(HttpClient httpClient, IConfiguration configuration) 
            : base(httpClient, configuration)
        {

        }

        public async Task<CastResultSelection> GetMoviesCredits(int movieId)
        {
            var response = await Client.GetAsync($"3/movie/{movieId}/credits").ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                // throw error / or insert circuitbreaker?
            }

            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonConvert.DeserializeObject<CastResultSelection>(content);
        }
    }
}
