using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Movie.Models.Extensions
{
    public static class MappingExtensions
    {
        internal static ICollection<MovieViewModel> MapToViewModel(this MovieResultSelection selection)
        {
            return selection.results.Select(x => x.MapToViewModel()).ToList();
        }

        internal static MovieViewModel MapToViewModel(this MovieSelection selection)
        {
            return new MovieViewModel
            {
                Id = selection.id,
                Adult = selection.adult,
                Orginal_Title = selection.original_title,
                Original_Language = selection.original_language,
                Overview = selection.overview,
                Popularity = selection.popularity,
                Release_Date = selection.release_date,
                Title = selection.Title,
                Video = selection.video,
                Vote_Average = selection.vote_average
            };
        }
    }
}
