using Application.Features.MediatorDesignPattern.Commands.CastCommands;
using MediatR;
using MovieApi.Domain.Entities;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.MediatorDesignPattern.Handlers.CastHandler
{
    public class CreateCommandCastHandler : IRequestHandler<CreateCastCommand>
    {
        private readonly MovieContext _context;
        public CreateCommandCastHandler(MovieContext context)
        {
            _context = context;
        }




        public async Task Handle(CreateCastCommand request, CancellationToken cancellationToken)
        {
            _context.Add(new Cast
            {
                Title = request.Title,
                Name = request.Name,
                Surname = request.Surname,
                ImageUrl = request.ImageUrl,
                Overview = request.Overview,
                Biography = request.Biography
            });
            await _context.SaveChangesAsync();
        }
    }
}
