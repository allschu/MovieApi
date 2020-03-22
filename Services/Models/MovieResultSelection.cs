using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Services.Models
{
    public class MovieResultSelection
    {
        public int Page { get; set; }
        public int Total_Results { get; set; }
        public int Total_Pages { get; }
        public ICollection<MovieSelection> results { get; set; }
    }
}
