using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.CQRSDesignPattern.Queries.SeriesQueries
{
    public class GetSeriesByIdQuery
    {
        public int SeriesId { get; set; }
        public GetSeriesByIdQuery(int seriesId)
        {
            SeriesId = seriesId;
        }
    }
}
