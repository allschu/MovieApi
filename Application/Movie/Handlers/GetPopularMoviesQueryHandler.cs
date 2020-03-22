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
    public class GetPopularMoviesQueryHandler : IRequestHandler<GetPopularMoviesQuery, ICollection<MovieViewModel>>
    {
        private readonly IMovieService movieService;

        public GetPopularMoviesQueryHandler(IMovieService movieService)
        {
            this.movieService = movieService ?? throw new ArgumentNullException(nameof(movieService));
        }

        public async Task<ICollection<MovieViewModel>> Handle(GetPopularMoviesQuery request, CancellationToken cancellationToken)
        {
            var movies = await movieService.GetPopularMovies().ConfigureAwait(false);

            return movies.MapToViewModel();
        }
    }
}
