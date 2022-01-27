using MovieApi.Models.ViewModels;
using System.Collections.Generic;

namespace MovieApi.Models
{
    public class GetTrendingMovieResponse
    {
        public ICollection<MovieDetailViewModel> result { get; }

        public GetTrendingMovieResponse(ICollection<MovieDetailViewModel> movieDetailViewModel)
        {
            result = movieDetailViewModel;
        }
    }
}
