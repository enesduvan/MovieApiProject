using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class RemoveMovieCommandHandler
    {
        private readonly Persistence.MovieContext _context;

        public RemoveMovieCommandHandler(Persistence.MovieContext context)
        {
            _context = context;
        }

        public async Task Handle(Commands.MovieCommands.RemoveMovieCommand command)
        {
            var movie = await _context.Movies.FindAsync(command.MovieId);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                await _context.SaveChangesAsync();
            }
        }
    }
}
