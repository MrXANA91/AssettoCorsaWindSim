using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssettoCorsaWindSim
{
    public class HardwareDataEventArgs : EventArgs
    {
        public bool FanAEnabled { get; private set; }
        public uint FanAPower { get; private set; }
        public bool FanBEnabled { get; private set; }
        public uint FanBPower { get; private set; }

        public HardwareDataEventArgs(bool fanAEnabled, uint fanAPower, bool fanBEnabled, uint fanBPower)
        {
            FanAEnabled = fanAEnabled;
            FanAPower = fanAPower;
            FanBEnabled = fanBEnabled;
            FanBPower = fanBPower;
        }
    }
}
