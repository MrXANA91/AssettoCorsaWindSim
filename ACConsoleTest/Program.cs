using System;
using assettocorsasharedmemory;

namespace ACConsoleTest {
    class Program {
        static void Main(string[] args) {
            AssettoCorsa ac = new AssettoCorsa();
            ac.PhysicsInterval = 1000;
            ac.PhysicsUpdated += ac_PhysicsInfoUpdated;
            ac.Start();

            Console.ReadKey();
            ac.Stop();
        }

        static void ac_PhysicsInfoUpdated(object? sender, PhysicsEventArgs e) {
            Console.WriteLine("PhysicsInfo");
            Console.WriteLine("  Speed: " + e.Physics.SpeedKmh);
            Console.WriteLine("  Roll: " + e.Physics.Roll);
            Console.WriteLine("  Pitch: " + e.Physics.Pitch);
            Console.WriteLine("  Heading: " + e.Physics.Heading);
            float[] localangularvelocity = e.Physics.LocalAngularVelocity;
            Console.Write("  LocalAngularVelocity: ");
            foreach (float value in localangularvelocity) {
                Console.Write(value);
                Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
}