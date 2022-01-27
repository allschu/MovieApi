using Application.Movie.Models;
using MediatR;
using System.Collections.Generic;

namespace Application.Movie.Queries
{
    public class GetTrendingMoviesQuery : IRequest<ICollection<MovieDetailViewModel>>
    {

    }
}
