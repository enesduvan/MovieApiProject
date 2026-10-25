using Application.Features.MediatorDesignPattern.Commands.CastCommands;
using Application.Features.MediatorDesignPattern.Commands.TagCommands;
using Application.Features.MediatorDesignPattern.Queries.CastQueries;
using Application.Features.MediatorDesignPattern.Queries.TagQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Properties.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetTags()
        {
            var result = await _mediator.Send(new GetTagQuery());
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTag(CreateTagCommand command)
        {
            await _mediator.Send(command);
            return Ok("Tag created successfully.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTag(UpdateTagCommand command)
        {
            await _mediator.Send(command);
            return Ok("Cast updated successfully.");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveTag(int tagId)
        {
            await _mediator.Send(new RemoveTagCommand(tagId));
            return Ok("Tag deleted successfully.");
        }
        [HttpGet("GetTagById")]
        public async Task<IActionResult> GetTagById(int tagId)
        {
            var result = await _mediator.Send(new GetTagByIdQuery(tagId));
            return Ok(result);
        }
    }
}

