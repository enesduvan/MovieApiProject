using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.CQRSDesignPattern.Handlers.SeriesHandlers
{
    public class GetSeriesQueryHandler
    {
        private readonly Persistence.MovieContext _context;
        public GetSeriesQueryHandler(Persistence.MovieContext context)
        {
            _context = context;
        }
        public async Task<List<Results.SeriesResults.GetSeriesQueryResult>> Handle()
        {
            var values = await _context.Series.ToListAsync();
            return values.Select(m => new Results.SeriesResults.GetSeriesQueryResult
            {
                SeriesId = m.SeriesId,
                Title = m.Title,
                Description = m.Description,
                CoverImageUrl = m.CoverImageUrl,
                Rating = m.Rating,
                FirstAirDate = m.FirstAirDate,
                CreatedYear = m.CreatedYear,
                AverageEpisodeDuration = m.AverageEpisodeDuration,
                SeasonCount = m.SeasonCount,
                EpisodeCount = m.EpisodeCount,
                Status = m.Status,
                CategoryId = m.CategoryId
            }).ToList();
        }
    }
}
