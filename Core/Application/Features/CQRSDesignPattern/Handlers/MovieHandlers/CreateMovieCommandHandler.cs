using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class CreateMovieCommandHandler
    {
        private readonly Persistence.MovieContext _context;

        public CreateMovieCommandHandler(Persistence.MovieContext context)
        {
            _context = context;
        }
        public async Task Handle(Commands.MovieCommands.CreateMovieCommand command)
        {
            _context.Movies.Add(new MovieApi.Domain.Entities.Movie
            {
                CoverImageUrl = command.CoverImageUrl,
                Title = command.Title,
                Description = command.Description,
                Rating = command.Rating,
                Duration = command.Duration,
                ReleaseDate = command.ReleaseDate,
                CreatedYear = command.CreatedYear,
                Status = command.Status
            });
            await _context.SaveChangesAsync();
        }
    }
}
