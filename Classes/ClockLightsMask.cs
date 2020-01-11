using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock
{
    interface IClockLightsMask
    {
        string CurrentTime(String onLightsMask, int onLightsCount);
    }

    sealed class DefaultClockLightsMask : IClockLightsMask
    {
        public DefaultClockLightsMask() : this('O') { }

        public DefaultClockLightsMask(char offLight)
        {
            OffLight = offLight;
        }
        
        char OffLight { get; set; }

        public string CurrentTime(String onLightsMask, int onLightsCount)
        {
            if (String.IsNullOrEmpty(onLightsMask))
                throw new FormatException();

            if (onLightsCount < 0 || onLightsCount > onLightsMask.Length)
                throw new ArgumentOutOfRangeException();

            int offLightsCount = onLightsMask.Length - onLightsCount;

            return onLightsMask.PadRight(offLightsCount, OffLight);
        }
    }
}
