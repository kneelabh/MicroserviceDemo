using System;
using System.Threading.Tasks;
using MediatR;
using MicroserviceDemo.Services.Command;
using MicroserviceDemo.Services.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MicroserviceDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly ILogger<MovieController> _logger;
        private readonly IMediator _mediator;
        public MovieController(ILogger<MovieController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("items")]
        public async Task<ActionResult> GetAllCatalogs()
        {
            var result = await _mediator.Send(new FindAllMovieQuery());

            return new JsonResult(result);
        }

        [HttpPost]
        public async Task<ActionResult> AddCatalog([FromBody] AddMoviesCommand request)
        {
            var result = await _mediator.Send(request);

            return new JsonResult(result);
        }
    }
}