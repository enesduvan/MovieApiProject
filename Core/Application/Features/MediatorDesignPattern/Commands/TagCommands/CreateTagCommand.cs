using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.MediatorDesignPattern.Commands.TagCommands
{
    public class CreateTagCommand : IRequest
    {
        public string Title { get; set; }
    }
}
