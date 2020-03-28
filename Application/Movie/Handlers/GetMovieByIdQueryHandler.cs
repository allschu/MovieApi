using Application.Movie.Models;
using Application.Movie.Models.Extensions;
using Application.Movie.Queries;
using MediatR;
using Services.Movie.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Movie.Handlers
{
    public class GetMovieByIdQueryHandler : IRequestHandler<GetMovieByIdQuery, MovieViewModel>
    {
        private readonly IMovieService movieService;

        public GetMovieByIdQueryHandler(IMovieService movieService)
        {
            this.movieService = movieService ?? throw new ArgumentNullException(nameof(movieService));
        }
        public async Task<MovieViewModel> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
        {
            request = request ?? throw new ArgumentNullException(nameof(request));

            var movie = await this.movieService.GetMovie(request.MovieId).ConfigureAwait(false);

            return movie.MapToViewModel();
        }
    }
}
