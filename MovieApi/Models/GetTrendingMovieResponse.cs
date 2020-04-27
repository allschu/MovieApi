using MovieApi.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
