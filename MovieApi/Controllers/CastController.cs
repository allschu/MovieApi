using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Cast.Queries;
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
    public class CastController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CastController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        // GET: api/Cast
        [HttpGet]
        public IEnumerable<string> GetCasts()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Cast/5
        [HttpGet("{movieId}", Name = "GetCast")]
        public async Task<ActionResult<GetMovieCastResponse>> GetCast(int movieId)
        {
            var cast = await this._mediator.Send(new GetMovieCastQuery(movieId)).ConfigureAwait(false);

            return new GetMovieCastResponse(movieId, cast.Map());
        }

        // POST: api/Cast
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Cast/5
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
