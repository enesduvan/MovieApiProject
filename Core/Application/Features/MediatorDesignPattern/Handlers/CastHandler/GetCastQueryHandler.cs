using Application.Features.MediatorDesignPattern.Queries.CastQueries;
using Application.Features.MediatorDesignPattern.Results.CastResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.MediatorDesignPattern.Handlers.CastHandler
{
    public class GetCastQueryHandler : IRequestHandler<GetCastQuery, List<GetCastQueryResult>>
    {
        private readonly MovieContext _context;
        public GetCastQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<List<GetCastQueryResult>> Handle(GetCastQuery request, CancellationToken cancellationToken)
        {
            var cast = await _context.Casts.ToListAsync();
            return cast.Select(c => new GetCastQueryResult
            {
                CastId = c.CastId,
                Title = c.Title,
                Name = c.Name,
                Surname = c.Surname,
                ImageUrl = c.ImageUrl,
                Overview = c.Overview,
                Biography = c.Biography
            }).ToList();
        }
    }
}
