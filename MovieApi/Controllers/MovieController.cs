using System;
using System.Threading.Tasks;
using Application.Movie.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieApi.Models;
using MovieApi.Models.Extensions;
using MovieApi.Models.ViewModels;

namespace MovieApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<MovieController> _logger;

        public MovieController(IMediator mediator, ILogger<MovieController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        // GET: api/Movie
        [HttpGet]
        [Route("popular/{page:int}")]
        public async Task<ActionResult<GetMovieResponse>> GetMovies(int page)
        {
            try
            {
                var movies = await _mediator.Send(new GetPopularMoviesQuery(new GetPopularMoviesFilter(page))).ConfigureAwait(false);

                return new GetMovieResponse(movies.Results.Map(), movies.Total_Results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        [HttpGet]
        [Route("search")]
        public async Task<ActionResult<GetMovieResponse>> Search([FromQuery] string query, [FromQuery] int page)
        {
            try
            {
                var movies = await _mediator.Send(new GetMovieSearchQuery(new GetMovieSearchFilter(query, page))).ConfigureAwait(false);

                return new GetMovieResponse(movies.Results.Map(), movies.Total_Results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }


        [HttpGet]
        [Route("trending")]
        public async Task<ActionResult<GetTrendingMovieResponse>> GetTrendingMovies()
        {
            try
            {
                var movies = await _mediator.Send(new GetTrendingMoviesQuery()).ConfigureAwait(false);

                return new GetTrendingMovieResponse(movies.Map());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        [HttpGet]
        [Route("recommendations/{movieid:int}")]
        public async Task<ActionResult<GetMovieRecommandationResponse>> GetMovieRecommendations(int movieid)
        {
            try
            {
                var movies = await _mediator.Send(new GetMovieRecommendationsQuery(movieid)).ConfigureAwait(false);

                return new GetMovieRecommandationResponse(movies.Map());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        [HttpPost]
        [Route("popular")]
        public async Task<ActionResult<GetMovieResponse>> GetMovies()
        {
            try
            {
                var movies = await _mediator.Send(new GetPopularMoviesQuery()).ConfigureAwait(false);

                return new GetMovieResponse(movies.Results.Map(), movies.Total_Results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        // GET: api/Movie/5
        [HttpGet("{id}", Name = "GetMovie")]
        public async Task<ActionResult<MovieDetailViewModel>> GetMovie(int id)
        {
            try
            {
                var movie = await _mediator.Send(new GetMovieByIdQuery(id)).ConfigureAwait(false);

                return movie.Map();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        // POST: api/Movie
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Movie/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
