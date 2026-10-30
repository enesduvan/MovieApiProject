using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.CQRSDesignPattern.Commands.CategoryCommands
{
    public class CreateCategoryCommand
    {
        public string CategoryName { get; set; }
        public bool Status { get; set; }
        public string? Description { get; set; }
    }
}
