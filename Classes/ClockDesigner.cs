using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock
{
    interface IClockDesigner
    {
        string Design(int hours, int minutes, int seconds);
    }

    /*
     * The Berlin Clock implementation designs the clock row by row.
     * For each row, the design is provided by an "on lights" mask manipulator.
     * The amount of "on lights" is determined by how many integral lamp time units (hours/minutes) are fitted inside each unit type total amount.
     * The time units left behind, dictate how many single time unit lamps are going to be on on the following row
     * The seconds light row is on or off depending on the position of the 2 units mark on the total seconds (divided perfectly or not). 
     */

    sealed class BerlinClockDesigner : IClockDesigner
    {
        public BerlinClockDesigner(IClockLightsMask rowLightsMaskProvider)
        {
            RowLightsMaskProvider = rowLightsMaskProvider;
        }

        IClockLightsMask RowLightsMaskProvider { get; set; }

        public string Design(int hours, int minutes, int seconds)
        {
            StringBuilder result = new StringBuilder();

            result.Append(RowLightsMaskProvider.CurrentTime("Y", 1 - seconds % 2));
            result.Append(Console.Out.NewLine);

            result.Append(RowLightsMaskProvider.CurrentTime("RRRR", hours / 5));
            result.Append(Console.Out.NewLine);

            result.Append(RowLightsMaskProvider.CurrentTime("RRRR", hours % 5));
            result.Append(Console.Out.NewLine);

            result.Append(RowLightsMaskProvider.CurrentTime("YYRYYRYYRYY", minutes / 5));
            result.Append(Console.Out.NewLine);

            result.Append(RowLightsMaskProvider.CurrentTime("YYYY", minutes % 5));

            return result.ToString();
        }
    }
}
