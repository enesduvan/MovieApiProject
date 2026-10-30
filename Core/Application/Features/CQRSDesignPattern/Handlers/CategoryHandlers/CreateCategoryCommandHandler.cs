using Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using MovieApi.Domain.Entities;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers
{
    public class CreateCategoryCommandHandler
    {
        private readonly MovieContext _context;

        public CreateCategoryCommandHandler(MovieContext context)
        {
            _context = context;
        }
        public async Task Handle(CreateCategoryCommand command)
        {
            _context.Categories.Add(new Category 
            { 
                CategoryName = command.CategoryName,
                Status = command.Status,
                Description = command.Description
            });
            await _context.SaveChangesAsync();
        }
    }
}
