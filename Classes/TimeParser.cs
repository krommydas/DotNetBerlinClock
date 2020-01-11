using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock
{
    public interface ITimeParser
    {
        int ParseHours(string timeString);
        int ParseMinutes(string timeString);
        int ParseSeconds(string timeString);
    }

    public class DefaultTimeParser : ITimeParser
    {
        public int ParseHours(string timeString) { return ParseTimePart(timeString, "^(0[0-9]|1[0-9]|2[0-3]|[0-9])"); }

        public int ParseMinutes(string timeString) { return ParseTimePart(timeString, @"(?<=\d{1,2}:)[0-5][0-9]"); }

        public int ParseSeconds(string timeString) { return ParseTimePart(timeString, "[0-5][0-9]$"); }

        int ParseTimePart(string timeString, string partMask)
        {
            if (string.IsNullOrEmpty(timeString))
                throw new FormatException();

            var match = System.Text.RegularExpressions.Regex.Match(timeString, partMask);
            if (match == null)
                throw new FormatException();

            if (!short.TryParse(match.Value, out var result))
                throw new FormatException();

            return result;
        }
    }
}
