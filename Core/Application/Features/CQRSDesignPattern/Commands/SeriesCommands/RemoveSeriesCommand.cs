using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.CQRSDesignPattern.Commands.SeriesCommands
{
    public class RemoveSeriesCommand
    {
        public int SeriesId { get; set; }

        public RemoveSeriesCommand(int seriesId)
        {
            SeriesId = seriesId;
        }
    }
}
