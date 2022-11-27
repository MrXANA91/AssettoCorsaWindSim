using System;
using assettocorsasharedmemory;
using AssettoCorsaWindSim;

namespace ACConsoleTest {
    class Program {
        static void Main(string[] args) {
            ConsoleKeyInfo key;
            AssettoCorsaWindSimController acws = new AssettoCorsaWindSimController();

            key = Console.ReadKey();

            IList<FanParameters> list = acws.GetFanParametersList();

            int numberOfFans = list.Count;

            foreach (FanParameters fanParam in list) {
                float _angle = fanParam.angle;
                float _gamma = fanParam.gamma;
                float _maxSpeed = fanParam.maxSpeed;
                FanParameters.POWER_COMPUTATION _powerCompFunc = fanParam.powerCompFunc;
                Console.WriteLine("Index : {0}, angle : {1}, gamma : {2}, powerCompFunc : {3}", list.IndexOf(fanParam), _angle, _gamma, _maxSpeed, _powerCompFunc);
            }

            key = Console.ReadKey();

            list.Add(new FanParameters());

            numberOfFans = list.Count;

            foreach (FanParameters fanParam in list) {
                float _angle = fanParam.angle;
                float _gamma = fanParam.gamma;
                float _maxSpeed = fanParam.maxSpeed;
                FanParameters.POWER_COMPUTATION _powerCompFunc = fanParam.powerCompFunc;
                Console.WriteLine("Index : {0}, angle : {1}, gamma : {2}, powerCompFunc : {3}", list.IndexOf(fanParam), _angle, _gamma, _maxSpeed, _powerCompFunc);
            }

            key = Console.ReadKey();

            acws.Dispose();
        }
    }
}