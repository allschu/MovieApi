using System.Collections.Generic;

namespace Application.Movie.Models
{
    public class MovieGridResult
    {
        public int Total_Results { get; set; }
        public int Total_Pages { get; set; }
        public ICollection<MovieViewModel> Results { get; set; }
    }
}
