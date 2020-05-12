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
    public class GetMovieSearchQueryHandler : IRequestHandler<GetMovieSearchQuery, MovieGridResult>
    {
        private readonly IMovieService movieService;

        public GetMovieSearchQueryHandler(IMovieService movieService)
        {
            this.movieService = movieService ?? throw new ArgumentNullException(nameof(movieService));
        }

        public async Task<MovieGridResult> Handle(GetMovieSearchQuery request, CancellationToken cancellationToken)
        {
            var parameters = request ?? throw new ArgumentNullException(nameof(request));

            if (parameters.Filter != null)
            {
                var movies = await movieService.Search(parameters.Filter.Query, parameters.Filter.Page).ConfigureAwait(false);

                return new MovieGridResult
                {
                    Results = movies.MapToViewModel(),
                    Total_Results = movies.Total_Results
                };
            }
            else
            {
                throw new NullReferenceException("There is no search filter present");
            }
        }
    }
}
