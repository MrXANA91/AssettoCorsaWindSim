using System;
using assettocorsasharedmemory;
using AssettoCorsaWindSim;

namespace ACConsoleTest {
    class Program {
        static void Main(string[] args) {
            AssettoCorsaWindSimController acws = new AssettoCorsaWindSimController();

            ConsoleKeyInfo key = Console.ReadKey();
            acws.Dispose();
        }
    }
}