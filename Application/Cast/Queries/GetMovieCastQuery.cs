using Application.Cast.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Cast.Queries
{
    public class GetMovieCastQuery : IRequest<ICollection<CastViewModel>>
    {
        public int MovieId { get; }

        public GetMovieCastQuery(int movieId)
        {
            MovieId = movieId;
        }
    }
}
