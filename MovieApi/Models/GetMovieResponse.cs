using MovieApi.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApi.Models
{
    public class GetMovieResponse
    {
        public ICollection<MovieViewModel> Movies { get; }

        public GetMovieResponse(ICollection<MovieViewModel> movies)
        {
            this.Movies = movies ?? throw new ArgumentNullException(nameof(movies));
        }
       
    }
}
