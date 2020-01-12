using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock
{
    interface IClockFactory
    {
        IClockDesigner CreateBerlinClock();
    }

    /*
     * This is a factory for row based clock designers.
     * A row mask based designer is injected to each clock
     */

    class RowClocksFactory : IClockFactory
    {
        public RowClocksFactory() : this(new DefaultClockLightsMask()) { }

        public RowClocksFactory(IClockLightsMask rowLightsProvider)
        {
            RowLightsProvider = rowLightsProvider;
        }

        IClockLightsMask RowLightsProvider { get; set; }

        public IClockDesigner CreateBerlinClock()
        {
            return new BerlinClockDesigner(RowLightsProvider);
        }
    }
}
