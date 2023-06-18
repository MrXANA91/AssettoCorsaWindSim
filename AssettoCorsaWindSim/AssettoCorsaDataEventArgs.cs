using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssettoCorsaWindSim
{
    public class AssettoCorsaDataEventArgs : EventArgs
    {
        public float Speed { get; private set; }
        public float LocalAngularVelocity {  get; private set; }

        public AssettoCorsaDataEventArgs(float speed, float localAngularVelocity)
        {
            Speed = speed;
            LocalAngularVelocity = localAngularVelocity;
        }
    }
}
