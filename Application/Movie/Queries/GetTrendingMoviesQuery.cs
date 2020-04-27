using Application.Movie.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Movie.Queries
{
    public class GetTrendingMoviesQuery : IRequest<ICollection<MovieDetailViewModel>>
    {

    }
}
