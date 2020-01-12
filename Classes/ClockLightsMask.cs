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

    /*
     * This mask based clock lights row designer is using the "on lights" count.
     * This number determines how much part of the "all lights on" mask will be on the final result.
     * The rest part is filled with the "off lights" character
     */

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

            return onLightsMask.Substring(0, onLightsCount).PadRight(onLightsMask.Length, OffLight);
        }
    }
}
