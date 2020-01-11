using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        public TimeConverter() : this(new DefaultTimeParser()) { }

        public TimeConverter(ITimeParser timeParser)
        {
            this.TimeParser = timeParser;
        }

        ITimeParser TimeParser { get; set; }

        public string convertTime(string aTime)
        {
            IClockDesigner berlinClock = new RowClocksFactory().CreateBerlinClock();

            return berlinClock.Design(TimeParser.ParseHours(aTime), TimeParser.ParseMinutes(aTime), TimeParser.ParseSeconds(aTime));
        }
    }
}
