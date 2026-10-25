using Application.Features.MediatorDesignPattern.Queries.TagQueries;
using Application.Features.MediatorDesignPattern.Results.TagResults;
using MediatR;
using Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.MediatorDesignPattern.Handlers.TagHandlers
{
    public class GetTagQueryHandler : IRequestHandler<GetTagQuery, List<GetTagQueryResult>>
    {
        private readonly MovieContext _context;
        public GetTagQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<List<GetTagQueryResult>> Handle(GetTagQuery request, CancellationToken cancellationToken)
        {
            var tags = await _context.Tags.ToListAsync();
            return tags.Select(tag => new GetTagQueryResult
            {
                TagId = tag.TagId,
                Title = tag.Title
            }).ToList();
        }
    }
}
