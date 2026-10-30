using Application.Features.CQRSDesignPattern.Commands.SeriesCommands;
using MovieApi.Domain.Entities;

namespace Application.Features.CQRSDesignPattern.Handlers.SeriesHandlers
{
    public class CreateSeriesCommandHandler
    {
        private readonly Persistence.MovieContext _context;

        public CreateSeriesCommandHandler(Persistence.MovieContext context)
        {
            _context = context;
        }
        public async Task Handle(CreateSeriesCommand command)
        {
            _context.Series.Add(new Series
            {
                Title = command.Title,
                CoverImageUrl = command.CoverImageUrl,
                Rating = command.Rating,
                Description = command.Description,
                FirstAirDate = command.FirstAirDate,
                CreatedYear = command.CreatedYear,
                AverageEpisodeDuration = command.AverageEpisodeDuration,
                SeasonCount = command.SeasonCount,
                EpisodeCount = command.EpisodeCount,
                Status = command.Status,
                CategoryId = command.CategoryId
            });
            await _context.SaveChangesAsync();
        }
    }
}
