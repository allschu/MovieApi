using Application.Movie.Models;
using Application.Movie.Models.Extensions;
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
    public class GetTrendingMoviesQueryHandler : IRequestHandler<GetTrendingMoviesQuery, ICollection<MovieDetailViewModel>>
    {
        private readonly IMovieService movieService;

        public GetTrendingMoviesQueryHandler(IMovieService movieService)
        {
            this.movieService = movieService ?? throw new ArgumentNullException(nameof(movieService));
        }

        public async Task<ICollection<MovieDetailViewModel>> Handle(GetTrendingMoviesQuery request, CancellationToken cancellationToken)
        {
            var result = await movieService.GetTrendingMovies().ConfigureAwait(false);

            return result.MapToViewModel();
        }
    }
}
