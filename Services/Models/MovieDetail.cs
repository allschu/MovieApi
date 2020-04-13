using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Services.Models
{
    public class MovieDetail
    {
        public int Id { get; set; }
        public string Original_Title { get; set; }
        public string Overview { get; set; }
        public double Popularity { get; set; }
        public DateTime Release_date { get; set; }
        public string Status { get; set; }
        public string Tagline { get; set; }
        public string Title { get; set; }
        public double Vote_Average { get; set; }
        public int Vote_Count { get; set; }
        public int Revenue { get; set; }
        public string Poster_path { get; set; }
        public Collection<GenreSelection> Genres { get; set; }
    }
}
