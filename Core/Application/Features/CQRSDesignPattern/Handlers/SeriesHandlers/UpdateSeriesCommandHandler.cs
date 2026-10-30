using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.CQRSDesignPattern.Handlers.SeriesHandlers
{
    public class UpdateSeriesCommandHandler
    {
        private readonly Persistence.MovieContext _context;

        public UpdateSeriesCommandHandler(Persistence.MovieContext context)
        {
            _context = context;
        }

        public async Task Handle(Commands.SeriesCommands.UpdateSeriesCommand command)
        {
            var series = await _context.Series.FindAsync(command.SeriesId);
            if (series != null)
            {
                series.Title = command.Title;
                series.Description = command.Description;
                series.CoverImageUrl = command.CoverImageUrl;
                series.Rating = command.Rating;
                series.FirstAirDate = command.FirstAirDate;
                series.AverageEpisodeDuration = command.AverageEpisodeDuration;
                series.CategoryId = command.CategoryId;
                series.CreatedYear = command.CreatedYear;
                series.SeasonCount = command.SeasonCount;
                series.EpisodeCount = command.EpisodeCount;
                series.Status = command.Status;

                await _context.SaveChangesAsync();
            }
        }
    }
}
