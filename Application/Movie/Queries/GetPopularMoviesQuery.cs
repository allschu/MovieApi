using Application.Movie.Models;
using MediatR;

namespace Application.Movie.Queries
{
    public class GetPopularMoviesQuery : IRequest<MovieGridResult>
    {
        public GetPopularMoviesFilter Filter { get; private set; }

        public GetPopularMoviesQuery(GetPopularMoviesFilter filter)
        {
            this.Filter = filter;
        }

        public GetPopularMoviesQuery()
        {
        }
    }
}
