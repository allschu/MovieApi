using Application.Movie.Models;
using Application.Movie.Models.Extensions;
using Application.Movie.Queries;
using MediatR;
using Services.Models;
using Services.Movie.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Movie.Handlers
{
    public class GetPopularMoviesQueryHandler : IRequestHandler<GetPopularMoviesQuery, MovieGridResult>
    {
        private readonly IMovieService movieService;

        public GetPopularMoviesQueryHandler(IMovieService movieService)
        {
            this.movieService = movieService ?? throw new ArgumentNullException(nameof(movieService));
        }

        public async Task<MovieGridResult> Handle(GetPopularMoviesQuery request, CancellationToken cancellationToken)
        {
            var parameters = request ?? throw new ArgumentNullException(nameof(request));

            MovieResultSelection movies = null;

            if (parameters.Filter != null)
            {
                movies = await movieService.GetPopularMovies(parameters.Filter.Page).ConfigureAwait(false);
            }
            else
            {
                movies = await movieService.GetPopularMovies().ConfigureAwait(false);
            }
            

            return new MovieGridResult
            {
                Results = movies.MapToViewModel(),
                Total_Results = movies.Total_Results
            };
        }
    }
}
