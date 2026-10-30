using Application.Features.CQRSDesignPattern.Results.CategoryResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers
{
    public class GetCategoryQueryHandler
    {
        private readonly Persistence.MovieContext _context;
        public GetCategoryQueryHandler(Persistence.MovieContext context)
        {
            _context = context;
        }
        public async Task<List<GetCategoryQueryResult>> Handle()
        {
            var categories = await _context.Categories.ToListAsync();
            var movies = await _context.Movies.ToListAsync();

            return categories.Select(c =>
            {
                var categoryMovies = movies.Where(m => m.CategoryId == c.CategoryId).ToList();
                var avgRating = categoryMovies.Any() ? categoryMovies.Average(m => m.Rating) : 0m;

                return new GetCategoryQueryResult
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.CategoryName,
                    Status = c.Status,
                    Description = c.Description,
                    MovieCount = categoryMovies.Count,
                    AverageRating = Math.Round(avgRating, 1),
                    ReviewCount = categoryMovies.Count * 25 + 12
                };
            }).ToList();
        }
    }
}
