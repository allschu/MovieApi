using Application.Movie.Models;
using MediatR;

namespace Application.Movie.Queries
{
    public class GetMovieSearchQuery: IRequest<MovieGridResult>
    {
        public GetMovieSearchFilter Filter { get; }
        public GetMovieSearchQuery(GetMovieSearchFilter filter)
        {
            this.Filter = filter;
        }
    }
}
