using Application.Movie.Models;
using MediatR;
using System.Collections.Generic;

namespace Application.Movie.Queries
{
    public class GetMovieRecommendationsQuery : IRequest<ICollection<MovieViewModel>>
    {
        public int MovieId { get; }

        public GetMovieRecommendationsQuery(int movieId)
        {
            this.MovieId = movieId;
        }
    }
}
