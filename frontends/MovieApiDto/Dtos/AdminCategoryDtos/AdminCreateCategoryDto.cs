using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApiDto.Dtos.AdminCategoryDtos
{
    public class AdminCreateCategoryDto
    {
        public string CategoryName { get; set; }
        public bool Status { get; set; }
        public string? Description { get; set; }
    }
}
