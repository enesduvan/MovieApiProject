using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class GetMovieQueryHandler
    {
        private readonly Persistence.MovieContext _context;
        public GetMovieQueryHandler(Persistence.MovieContext context)
        {
            _context = context;
        }
        public async Task<List<Results.MovieResults.GetMovieQueryResult>> Handle()
        {
            var values = await _context.Movies.ToListAsync();
            return values.Select(m => new Results.MovieResults.GetMovieQueryResult
            {
                MovieId = m.MovieId,
                Title = m.Title,
                Description = m.Description,
                CoverImageUrl = m.CoverImageUrl,
                Rating = m.Rating,
                Duration = m.Duration,
                ReleaseDate = m.ReleaseDate,
                CreatedYear = m.CreatedYear,
                Status = m.Status
            }).ToList();
        }
    }
}
