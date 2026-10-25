using Application.Features.MediatorDesignPattern.Commands.CastCommands;
using Application.Features.MediatorDesignPattern.Queries.CastQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Properties.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CastsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CastsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetCasts()
        {
            var result = await _mediator.Send(new GetCastQuery());
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCast(CreateCastCommand command)
        {
            await _mediator.Send(command);
            return Ok("Cast created successfully.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCast(UpdateCastCommand command)
        {
            await _mediator.Send(command);
            return Ok("Cast updated successfully.");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveCast(int castId)
        {
            await _mediator.Send(new RemoveCastCommand(castId));
            return Ok("Cast deleted successfully.");
        }
        [HttpGet("GetCastById")]
        public async Task<IActionResult> GetCastById(int castId)
        {
            var result = await _mediator.Send(new GetCastByIdQuery(castId));
            return Ok(result);
        }
    }
}