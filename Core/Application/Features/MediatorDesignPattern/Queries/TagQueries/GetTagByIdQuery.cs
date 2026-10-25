using Application.Features.MediatorDesignPattern.Results.TagResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.MediatorDesignPattern.Queries.TagQueries
{
    public class GetTagByIdQuery : IRequest<GetTagByIdQueryResult>
    {
        public int TagId { get; set; }
        public GetTagByIdQuery(int tagId)
        {
            TagId = tagId;
        }
    }

}

