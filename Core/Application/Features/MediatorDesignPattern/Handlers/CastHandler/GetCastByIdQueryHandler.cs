using Application.Features.MediatorDesignPattern.Queries.CastQueries;
using Application.Features.MediatorDesignPattern.Results.CastResults;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.MediatorDesignPattern.Handlers.CastHandler
{
    public class GetCastByIdQueryHandler : IRequestHandler<GetCastByIdQuery, GetCastByIdQueryResult>
    {
        private readonly MovieContext _context;
        public GetCastByIdQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<GetCastByIdQueryResult> Handle(GetCastByIdQuery request, CancellationToken cancellationToken)
        {
            var cast = await _context.Casts.FindAsync(request.CastId);
            return new GetCastByIdQueryResult
            {
                CastId = cast.CastId,
                Title = cast.Title,
                Name = cast.Name,
                Surname = cast.Surname,
                ImageUrl = cast.ImageUrl,
                Overview = cast.Overview,
                Biography = cast.Biography
            };
        }
    }
}
