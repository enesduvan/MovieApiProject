using Application.Features.MediatorDesignPattern.Queries.TagQueries;
using Application.Features.MediatorDesignPattern.Results.TagResults;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.MediatorDesignPattern.Handlers.TagHandlers
{
    internal class GetTagByIdQueryHandler : IRequestHandler<GetTagByIdQuery, GetTagByIdQueryResult>
    {
        private readonly MovieContext _context;
        public GetTagByIdQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public Task<GetTagByIdQueryResult> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
        {
            var tag = _context.Tags.Find(request.TagId);


            return Task.FromResult(new GetTagByIdQueryResult
            {
                TagId = tag.TagId,
                Title = tag.Title
            });


        }
    }
}
