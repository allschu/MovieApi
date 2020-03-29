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
        public int Total_Results { get; }

        public GetMovieResponse(ICollection<MovieViewModel> movies, int total)
        {
            this.Movies = movies ?? throw new ArgumentNullException(nameof(movies));
            Total_Results = total;
        }
       
    }
}
