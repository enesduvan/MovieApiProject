using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.CQRSDesignPattern.Handlers.SeriesHandlers
{
    public class GetSeriesByIdQueryHandler
    {
        private readonly Persistence.MovieContext _context;
        public GetSeriesByIdQueryHandler(Persistence.MovieContext context)
        {
            _context = context;
        }
        public async Task<Results.SeriesResults.GetSeriesByIdQueryResult> Handle(Queries.SeriesQueries.GetSeriesByIdQuery query)
        {
            var series = await _context.Series.FindAsync(query.SeriesId);
            if (series != null)
            {
                return new Results.SeriesResults.GetSeriesByIdQueryResult
                {
                    SeriesId = series.SeriesId,
                    Title = series.Title,
                    CoverImageUrl = series.CoverImageUrl,
                    Rating = series.Rating,
                    Description = series.Description,
                    AverageEpisodeDuration = series.AverageEpisodeDuration,
                    FirstAirDate = series.FirstAirDate,
                    CreatedYear = series.CreatedYear,
                    SeasonCount = series.SeasonCount,
                    EpisodeCount = series.EpisodeCount,
                    Status = series.Status,
                    CategoryId = series.CategoryId
                };
            }
            return null;
        }
    }
}
