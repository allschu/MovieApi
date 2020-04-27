﻿using Application.Movie.Models;
using MovieApi.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApi.Models.Extensions
{
    public static class MappingExtensions
    {
        internal static ViewModels.MovieDetailViewModel Map(this Application.Movie.Models.MovieDetailViewModel movie)
        {
            return new ViewModels.MovieDetailViewModel
            {
                id = movie.id,
                original_title = movie.original_title,
                overview = movie.overview,
                popularity = movie.popularity,
                poster_path = movie.poster_path,
                release_date = movie.release_date,
                revenue = movie.revenue,
                tagline = movie.tagline,
                status = movie.status,
                title = movie.title,
                vote_average = movie.vote_average,
                vote_count = movie.vote_count
            };
        }
        
        internal static ViewModels.MovieViewModel Map(this Application.Movie.Models.MovieViewModel movie)
        {
            return new ViewModels.MovieViewModel
            {
                Id = movie.Id,
                Adult = movie.Adult,
                Orginal_Title = movie.Orginal_Title,
                Original_Language = movie.Original_Language,
                Overview = movie.Overview,
                Popularity = movie.Popularity,
                Release_Date = movie.Release_Date.ToShortDateString(),
                Title = movie.Title,
                Video = movie.Video,
                Vote_Average = movie.Vote_Average
            };
        }

        internal static ICollection<ViewModels.MovieViewModel> Map(this ICollection<Application.Movie.Models.MovieViewModel> movies)
        {
            return movies.Select(x => x.Map()).ToList();
        }

        internal static ICollection<ViewModels.MovieDetailViewModel> Map(this ICollection<Application.Movie.Models.MovieDetailViewModel> movies)
        {
            return movies.Select(x => x.Map()).ToList();
        }
    }
}
