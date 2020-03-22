﻿using Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Movie.Interfaces
{
    public interface IMovieService
    {
        public Task<MovieResultSelection> GetPopularMovies();

        public Task<MovieSelection> GetMovie(int id);

        public Task<MovieSelection[]> GetMovieRecommendations(int id);

        public Task<MovieSelection[]> GetTrendingMovies();
    }
}