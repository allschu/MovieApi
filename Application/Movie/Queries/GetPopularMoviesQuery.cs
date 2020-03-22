using Application.Movie.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Application.Movie.Queries
{
    public class GetPopularMoviesQuery : IRequest<ICollection<MovieViewModel>>
    {
        public GetPopularMoviesFilter Filter { get; private set; }

        public GetPopularMoviesQuery(GetPopularMoviesFilter filter)
        {
            this.Filter = filter;
        }
    }
}
