using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssettoCorsaWindSim
{
    public class HardwareConnectionEventArgs : EventArgs
    {
        public Boolean Connected { get; private set; }
        public HardwareConnectionEventArgs(Boolean connected)
        {
            Connected = connected;
        }
    }
}
