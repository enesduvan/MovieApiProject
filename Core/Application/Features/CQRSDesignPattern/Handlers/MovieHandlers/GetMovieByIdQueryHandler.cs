using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class GetMovieByIdQueryHandler
    {
        private readonly Persistence.MovieContext _context;
        public GetMovieByIdQueryHandler(Persistence.MovieContext context)
        {
            _context = context;
        }
        public async Task<Results.MovieResults.GetMovieByIdQueryResult> Handle(Queries.MovieQueries.GetMovieByIdQuery query)
        {
            var movie = await _context.Movies.FindAsync(query.MovieId);
            if (movie != null)
            {
                return new Results.MovieResults.GetMovieByIdQueryResult
                {
                    MovieId = movie.MovieId,
                    Title = movie.Title,
                    CoverImageUrl = movie.CoverImageUrl,
                    Rating = movie.Rating,
                    Description = movie.Description,
                    Duration = movie.Duration,
                    ReleaseDate = movie.ReleaseDate,
                    Status = movie.Status,
                    CreatedYear = movie.CreatedYear
                };
            }
            return null;
        }
    }
}
