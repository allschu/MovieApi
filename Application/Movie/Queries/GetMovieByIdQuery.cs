using Application.Movie.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Movie.Queries
{
    public class GetMovieByIdQuery : IRequest<MovieDetailViewModel>
    {
        public int MovieId { get; }

        public GetMovieByIdQuery(int movieId)
        {
            this.MovieId = movieId;
        }
    }
}
