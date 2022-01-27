using System;

namespace Services.Models
{
    public class MovieSelection
    {
        public int id { get; set; }
        public string Title { get; set; }
        public double popularity { get; set; }
        public double vote_average { get; set; }
        public int vote_count { get; set; }
        public bool adult { get; set; }
        public bool video { get; set; }
        public string original_title { get; set; }
        public DateTime? release_date { get; set; }
        public string original_language { get; set; }
        public string overview { get; set; }
        public string poster_path { get; set; }
    }
}
