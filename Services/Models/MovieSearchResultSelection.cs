using System;
using System.Collections.Generic;
using System.Text;

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
