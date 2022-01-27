using System.Collections.Generic;

namespace Services.Models
{
    public class MovieSearchResultSelection
    {
        public int Page { get; set; }
        public int Total_Results { get; set; }
        public int Total_Pages { get; }
        public ICollection<MovieSelection> results { get; set; }
    }
}
