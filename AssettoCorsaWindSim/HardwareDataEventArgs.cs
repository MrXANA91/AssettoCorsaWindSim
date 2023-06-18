using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssettoCorsaWindSim
{
    public class HardwareDataEventArgs : EventArgs
    {
        public uint FanAPower { get; private set; }
        public uint FanBPower { get; private set; }

        public HardwareDataEventArgs(uint fanAPower, uint fanBPower)
        {
            FanAPower = fanAPower;
            FanBPower = fanBPower;
        }
    }
}
