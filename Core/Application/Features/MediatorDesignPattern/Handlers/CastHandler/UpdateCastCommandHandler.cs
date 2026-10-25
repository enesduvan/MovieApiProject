using Application.Features.MediatorDesignPattern.Commands.CastCommands;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.MediatorDesignPattern.Handlers.CastHandler
{
    public class UpdateCastCommandHandler : IRequestHandler<UpdateCastCommand>
    {
        private readonly MovieContext _context;
        public UpdateCastCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateCastCommand request, CancellationToken cancellationToken)
        {
            var cast = await _context.Casts.FindAsync(request.CastId);
            cast.Title = request.Title;
            cast.Name = request.Name;
            cast.Surname = request.Surname;
            cast.ImageUrl = request.ImageUrl;
            cast.Overview = request.Overview;
            cast.Biography = request.Biography;
            await _context.SaveChangesAsync();
        }
    }
}
