using Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace Application.Movie.Models.Extensions
{
    public static class MappingExtensions
    {
        internal static MovieDetailViewModel MapToViewModel(this MovieDetail selection)
        {
            return new MovieDetailViewModel
            {
                id = selection.Id,
                original_title = selection.Original_Title,
                overview = selection.Overview,
                popularity = selection.Popularity,
                poster_path = selection.Poster_path,
                release_date = selection.Release_date,
                revenue = selection.Revenue,
                tagline = selection.Tagline,
                status = selection.Status,
                title = selection.Title,
                vote_average = selection.Vote_Average,
                vote_count = selection.Vote_Count
            };
        }
        
        internal static ICollection<MovieViewModel> MapToViewModel(this MovieResultSelection selection)
        {
            return selection.results.Select(x => x.MapToViewModel()).ToList();
        }

        internal static ICollection<MovieViewModel> MapToViewModel(this MovieSearchResultSelection selection)
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
                Vote_Average = selection.vote_average,
                Poster_Path = selection.poster_path
            };
        }

        internal static ICollection<MovieDetailViewModel> MapToViewModel(this MovieTrendingResultSelection selection)
        {
            return selection.results.Select(x => x.MapToViewModel()).ToList();
        }
    }
}
