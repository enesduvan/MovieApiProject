using Application.Features.CQRSDesignPattern.Commands.SeriesCommands;
using Application.Features.CQRSDesignPattern.Handlers.SeriesHandlers;
using Application.Features.CQRSDesignPattern.Queries.SeriesQueries;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Properties.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private readonly GetSeriesQueryHandler _getSeriesQueryHandler;
        private readonly GetSeriesByIdQueryHandler _getSeriesByIdQueryHandler;
        private readonly CreateSeriesCommandHandler _createSeriesCommandHandler;
        private readonly UpdateSeriesCommandHandler _updateSeriesCommandHandler;
        private readonly RemoveSeriesCommandHandler _removeSeriesCommandHandler;

        public SeriesController(GetSeriesQueryHandler getSeriesQueryHandler, GetSeriesByIdQueryHandler getSeriesByIdQueryHandler, CreateSeriesCommandHandler createSeriesCommandHandler, UpdateSeriesCommandHandler updateSeriesCommandHandler, RemoveSeriesCommandHandler removeSeriesCommandHandler)
        {
            _getSeriesQueryHandler = getSeriesQueryHandler;
            _getSeriesByIdQueryHandler = getSeriesByIdQueryHandler;
            _createSeriesCommandHandler = createSeriesCommandHandler;
            _updateSeriesCommandHandler = updateSeriesCommandHandler;
            _removeSeriesCommandHandler = removeSeriesCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSeries()
        {
            var series = await _getSeriesQueryHandler.Handle();
            return Ok(series);
        }
        [HttpGet("GetSeriesById")]
        public async Task<IActionResult> GetSeriesById(int id)
        {
            var series = await _getSeriesByIdQueryHandler.Handle(new GetSeriesByIdQuery(id));
            if (series == null)
            {
                return NotFound();
            }
            return Ok(series);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSeries(CreateSeriesCommand command)
        {
            await _createSeriesCommandHandler.Handle(command);
            return Ok("Series created successfully.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeries(int id)
        {
            await _removeSeriesCommandHandler.Handle(new RemoveSeriesCommand(id));
            return Ok("Series deleted successfully.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSeries(UpdateSeriesCommand command)
        {
            await _updateSeriesCommandHandler.Handle(command);
            return Ok("Series updated successfully.");
        }
    }
}
