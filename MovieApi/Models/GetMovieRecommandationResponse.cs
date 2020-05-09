using MovieApi.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
