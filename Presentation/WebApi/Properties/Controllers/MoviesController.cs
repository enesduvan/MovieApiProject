using Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers;
using Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;
using Application.Features.CQRSDesignPattern.Queries.MovieQueries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Properties.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : Controller
    {
        private readonly GetMovieByIdQueryHandler _getMovieByIdQueryHandler;
        private readonly GetMovieQueryHandler _getMovieQueryHandler;
        private readonly CreateMovieCommandHandler _createMovieCommandHandler;
        private readonly UpdateMovieCommandHandler _updateMovieCommandHandler;
        private readonly RemoveMovieCommandHandler _removeMovieCommandHandler;

        public MoviesController(GetMovieByIdQueryHandler getMovieByIdQueryHandler, GetMovieQueryHandler getMovieQueryHandler, CreateMovieCommandHandler createMovieCommandHandler, UpdateMovieCommandHandler updateMovieCommandHandler, RemoveMovieCommandHandler removeMovieCommandHandler)
        {
            _getMovieByIdQueryHandler = getMovieByIdQueryHandler;
            _getMovieQueryHandler = getMovieQueryHandler;
            _createMovieCommandHandler = createMovieCommandHandler;
            _updateMovieCommandHandler = updateMovieCommandHandler;
            _removeMovieCommandHandler = removeMovieCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
        {
            var movies = await _getMovieQueryHandler.Handle();
            return Ok(movies);
        }
        [HttpGet("GetMovieById")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var movie = await _getMovieByIdQueryHandler.Handle(new GetMovieByIdQuery(id));
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }
        [HttpPost]
        public async Task<IActionResult> CreateMovie(CreateMovieCommand command)
        {
            await _createMovieCommandHandler.Handle(command);
            return Ok("Movie created successfully.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            await _removeMovieCommandHandler.Handle(new RemoveMovieCommand(id));
            return Ok("Movie deleted successfully.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateMovie( UpdateMovieCommand command)
        {
            await _updateMovieCommandHandler.Handle(command);
            return Ok("Movie updated successfully.");
        }
    }
}
