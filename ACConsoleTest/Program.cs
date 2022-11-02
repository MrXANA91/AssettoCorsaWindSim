using System;
using assettocorsasharedmemory;
using AssettoCorsaWindSim;

namespace ACConsoleTest {
    class Program {
        static void Main(string[] args) {
            AssettoCorsaWindSimController acws = new AssettoCorsaWindSimController();
            
            acws.Start();

            Console.ReadKey();
            acws.Stop();
        }
    }
}