using Application.Cast.Models;
using Application.Cast.Models.Extensions;
using Application.Cast.Queries;
using MediatR;
using Services.Cast.Interfaces;
using Services.Movie.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cast.Handlers
{
    public class GetMovieCastQueryHandler : IRequestHandler<GetMovieCastQuery, ICollection<CastViewModel>>
    {
        private readonly ICastService castService;

        public GetMovieCastQueryHandler(ICastService castService)
        {
            this.castService = castService ?? throw new ArgumentNullException(nameof(castService));
        }

        public async Task<ICollection<CastViewModel>> Handle(GetMovieCastQuery request, CancellationToken cancellationToken)
        {
            request = request ?? throw new ArgumentNullException(nameof(request));

            var cast = await castService.GetMoviesCredits(request.MovieId).ConfigureAwait(false);

            return cast.MapToViewModel();
        }
    }
}
 