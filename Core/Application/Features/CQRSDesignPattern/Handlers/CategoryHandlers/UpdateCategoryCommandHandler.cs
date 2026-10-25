using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler
    {
        private readonly Persistence.MovieContext _context;
        public UpdateCategoryCommandHandler(Persistence.MovieContext context)
        {
            _context = context;
        }
        public async Task Handle(Commands.CategoryCommands.UpdateCategoryCommand command)
        {
            var category = await _context.Categories.FindAsync(command.CategoryId);
            if (category != null)
            {
                category.CategoryName = command.CategoryName;
                category.Status = command.Status;
                category.Description = command.Description;
                await _context.SaveChangesAsync();
            }
        }
    }
}
