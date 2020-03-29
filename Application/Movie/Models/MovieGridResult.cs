using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Movie.Models
{
    public class MovieGridResult
    {
        public int Total_Results { get; set; }
        public int Total_Pages { get; set; }
        public ICollection<MovieViewModel> Results { get; set; }
    }
}
