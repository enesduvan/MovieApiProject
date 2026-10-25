using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.MediatorDesignPattern.Commands.TagCommands
{
    public class RemoveTagCommand : IRequest
    {
        public int TagId { get; set; }
        public RemoveTagCommand(int tagId)
        {
            TagId = tagId;
        }
    }
}
