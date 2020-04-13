using System;

namespace MovieApi.Models.ViewModels
{
    public class MovieDetailViewModel
    {
        public int id { get; set; }
        public string original_title { get; set; }
        public string overview { get; set; }
        public double popularity { get; set; }
        public DateTime release_date { get; set; }
        public string status { get; set; }
        public string tagline { get; set; }
        public string title { get; set; }
        public double vote_average { get; set; }
        public int vote_count { get; set; }
        public double revenue { get; set; }
        public string poster_path { get; set; }
        //genres: Genre[];
    }
}