using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Movie.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Models;
using MovieApi.Models.Extensions;
using MovieApi.Models.ViewModels;

namespace MovieApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MovieController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        // GET: api/Movie
        [HttpGet]
        [Route("popular/{page:int}")]
        public async Task<ActionResult<GetMovieResponse>> GetMovies(int page)
        {
            var movies = await _mediator.Send(new GetPopularMoviesQuery(new GetPopularMoviesFilter(page))).ConfigureAwait(false);

            return new GetMovieResponse(movies.Results.Map(), movies.Total_Results);
        }

        [HttpGet]
        [Route("search")]
        public async Task<ActionResult<GetMovieResponse>> Search([FromQuery] string query, [FromQuery] int page)
        {
            var movies = await _mediator.Send(new GetMovieSearchQuery(new GetMovieSearchFilter(query, page))).ConfigureAwait(false);

            return new GetMovieResponse(movies.Results.Map(), movies.Total_Results);
        }


        [HttpGet]
        [Route("trending")]
        public async Task<ActionResult<GetTrendingMovieResponse>> GetTrendingMovies()
        {
            var movies = await _mediator.Send(new GetTrendingMoviesQuery()).ConfigureAwait(false);

            return new GetTrendingMovieResponse(movies.Map());
        }

        [HttpGet]
        [Route("recommendations/{movieid:int}")]
        public async Task<ActionResult<GetMovieRecommandationResponse>> GetMovieRecommendations(int movieid)
        {
            var movies = await _mediator.Send(new GetMovieRecommendationsQuery(movieid)).ConfigureAwait(false);

            return new GetMovieRecommandationResponse(movies.Map());
        }

        [HttpPost]
        [Route("popular")]
        public async Task<ActionResult<GetMovieResponse>> GetMovies()
        {
            var pageSize = 20;
            
            var movies = await _mediator.Send(new GetPopularMoviesQuery()).ConfigureAwait(false);

            return new GetMovieResponse(movies.Results.Map(), movies.Total_Results);
        }

        // GET: api/Movie/5
        [HttpGet("{id}", Name = "GetMovie")]
        public async Task<ActionResult<MovieDetailViewModel>> GetMovie(int id)
        {
            var movie = await _mediator.Send(new GetMovieByIdQuery(id)).ConfigureAwait(false);

            return movie.Map();
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
