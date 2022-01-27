using Application.Movie.Models;
using MediatR;

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
