using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class UpdateMovieCommandHandler
    {
        private readonly Persistence.MovieContext _context;

        public UpdateMovieCommandHandler(Persistence.MovieContext context)
        {
            _context = context;
        }

        public async Task Handle(Commands.MovieCommands.UpdateMovieCommand command)
        {
            var movie = await _context.Movies.FindAsync(command.MovieId);
            if (movie != null)
            {
                movie.Title = command.Title;
                movie.Description = command.Description;
                movie.CoverImageUrl = command.CoverImageUrl;
                movie.Rating = command.Rating;
                movie.Duration = command.Duration;
                movie.ReleaseDate = command.ReleaseDate;
                movie.CreatedYear = command.CreatedYear;
                movie.Status = command.Status;

                await _context.SaveChangesAsync();
            }
        }
    }
}
