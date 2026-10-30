using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.CQRSDesignPattern.Handlers.SeriesHandlers
{
    public class RemoveSeriesCommandHandler
    {
        private readonly Persistence.MovieContext _context;

        public RemoveSeriesCommandHandler(Persistence.MovieContext context)
        {
            _context = context;
        }

        public async Task Handle(Commands.SeriesCommands.RemoveSeriesCommand command)
        {
            var series = await _context.Series.FindAsync(command.SeriesId);
            if (series != null)
            {
                _context.Series.Remove(series);
                await _context.SaveChangesAsync();
            }
        }
    }
}

