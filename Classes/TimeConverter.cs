using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BerlinClock
{
    /*
     * This time - clock design converter is using a custom time parser to determine the time.
     * The default TimeSpan parser is not recognizing the 24:00:00 format, thus a custom implementation was used.
     * A row based clock designers factory is used to get a berlin clock designer implementation.
     * This, along with the parsed time will give the final design-result
     */ 

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
