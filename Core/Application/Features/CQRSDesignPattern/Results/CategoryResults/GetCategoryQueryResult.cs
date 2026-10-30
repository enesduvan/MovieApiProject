using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.CQRSDesignPattern.Results.CategoryResults
{
    public class GetCategoryQueryResult
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public bool? Status { get; set; }
        public string? Description { get; set; }
        public int MovieCount { get; set; }
        public decimal AverageRating { get; set; }
        public int ReviewCount { get; set; }
    }
}
