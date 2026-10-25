using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers
{
    public class GetCategoryByIdQueryHandler
    {
        private readonly Persistence.MovieContext _context;
        public GetCategoryByIdQueryHandler(Persistence.MovieContext context)
        {
            _context = context;
        }

        public async Task<Results.CategoryResults.GetCategoryByIdQueryResult> Handle(Queries.CategoryQueries.GetCategoryByIdQuery query)
        {
            var category = await _context.Categories.FindAsync(query.CategoryId);
            if (category != null)
            {
                return new Results.CategoryResults.GetCategoryByIdQueryResult
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName,
                };
            }
            return null;
        }
    }
}
