using MovieApi.Models.ViewModels;
using System.Collections.Generic;

namespace MovieApi.Models
{
    public class GetMovieRecommandationResponse
    {
        public ICollection<MovieViewModel> result { get; }

        public GetMovieRecommandationResponse(ICollection<MovieViewModel> movies)
        {
            this.result = movies;
        }
    }
}
