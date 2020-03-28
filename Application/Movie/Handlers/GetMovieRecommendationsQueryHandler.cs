using Application.Movie.Models;
using Application.Movie.Queries;
using MediatR;
using Services.Movie.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Movie.Handlers
{
    public class GetMovieRecommendationsQueryHandler : IRequestHandler<GetMovieRecommendationsQuery, ICollection<MovieViewModel>>
    {
        private readonly IMovieService movieService;

        public GetMovieRecommendationsQueryHandler(IMovieService movieService)
        {
            this.movieService = movieService ?? throw new ArgumentNullException(nameof(movieService));
        }

        public Task<ICollection<MovieViewModel>> Handle(GetMovieRecommendationsQuery request, CancellationToken cancellationToken)
        {
            
        }
    }
}
