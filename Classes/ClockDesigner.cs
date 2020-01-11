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

            result.Append(RowLightsMaskProvider.CurrentTime("Y", seconds % 2));
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
