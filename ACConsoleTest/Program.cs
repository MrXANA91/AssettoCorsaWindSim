using System;
using assettocorsasharedmemory;
using AssettoCorsaWindSim;

namespace ACConsoleTest {
    class Program {
        static void Main(string[] args) {
            ConsoleKeyInfo cki;
            AssettoCorsaWindSimController acws = new AssettoCorsaWindSimController();
            
            IList<FanParameters> list = new List<FanParameters>();
            String strValue = "";
            float floatValue = 0f;
            uint uintValue = 0;

            Boolean loop = true;
            do {
                cki = Console.ReadKey();
                
                switch(cki.Key) {
                    default:
                        Console.WriteLine("ConsoleCommand : {0} Not supported", cki.Key.ToString());
                        break;
                    case (ConsoleKey.D):
                        if((cki.Modifiers & ConsoleModifiers.Control) != 0) {
                            Console.WriteLine("ConsoleCommand : Debug Verbose = {0}", AssettoCorsaWindSimController.DEBUG_VERBOSE);
                        } else {
                            Console.WriteLine("ConsoleCommand : Displaying values");

                            list = acws.GetFanParametersList();

                            foreach (FanParameters fanParam in list) {
                                float _angle = fanParam.angle;
                                float _gamma = fanParam.gamma;
                                float _maxSpeed = fanParam.maxSpeed;
                                FanParameters.POWER_COMPUTATION _powerCompFunc = fanParam.powerCompFunc;
                                Console.WriteLine("Index : {0}, angle : {1}, gamma : {2}, maxSpeed : {3}, powerCompFunc : "+ _powerCompFunc.ToString(), list.IndexOf(fanParam), _angle.ToString(), _gamma.ToString(), _maxSpeed.ToString());
                            }
                        }
                        break;
                    case (ConsoleKey.A):
                        Console.WriteLine("ConsoleCommand : Fan A - Choose Angle (A), Gamma (G), MaxSpeed (S), Function (F)");
                        Console.WriteLine("ConsoleCommand : Press Escape or another letter to cancel");
                        cki = Console.ReadKey();
                        strValue = "";
                        floatValue = 0f;
                        uintValue = 0;
                        list = acws.GetFanParametersList();
                        switch(cki.Key) {
                            case (ConsoleKey.A):
                                Console.WriteLine("ConsoleCommand : Fan A - Write Angle (in degrees)");
                                strValue = Console.ReadLine();

                                try {
                                    floatValue = Convert.ToSingle(strValue);
                                }
                                catch (Exception ex) {
                                    Console.WriteLine("ConsoleCommand : Fan A - Could not change angle value ("+ex.Message+";"+strValue+")");
                                    break;
                                }

                                Console.WriteLine("ConsoleCommand : Fan A - Setting Angle to {0}", floatValue);
                                list[0].angle = floatValue;
                                break;
                            case (ConsoleKey.G):
                                Console.WriteLine("ConsoleCommand : Fan A - Write Gamma (must be strictly greater than 0)");
                                strValue = Console.ReadLine();

                                try {
                                    floatValue = Convert.ToSingle(strValue);
                                }
                                catch (Exception ex) {
                                    Console.WriteLine("ConsoleCommand : Fan A - Could not change gamma value ("+ex.Message+";"+strValue+")");
                                    break;
                                }

                                Console.WriteLine("ConsoleCommand : Fan A - Setting Gamma to {0}", floatValue);
                                list[0].gamma = floatValue;
                                break;
                            case (ConsoleKey.S):
                                Console.WriteLine("ConsoleCommand : Fan A - Write MaxSpeed (in km/h) (must be greater than 1)");
                                strValue = Console.ReadLine();

                                try {
                                    floatValue = Convert.ToSingle(strValue);
                                }
                                catch (Exception ex) {
                                    Console.WriteLine("ConsoleCommand : Fan A - Could not change MaxSpeed value ("+ex.Message+";"+strValue+")");
                                    break;
                                }

                                Console.WriteLine("ConsoleCommand : Fan A - Setting MaxSpeed to {0}", floatValue);
                                list[0].maxSpeed = floatValue;
                                break;
                            case (ConsoleKey.F):
                                Console.WriteLine("ConsoleCommand : Fan A - Write Function (must be 0, 1 or 2)");
                                strValue = Console.ReadLine();

                                try {
                                    uintValue = Convert.ToByte(strValue);
                                }
                                catch (Exception ex) {
                                    Console.WriteLine("ConsoleCommand : Fan A - Could not change Function value ("+ex.Message+";"+strValue+")");
                                    break;
                                }

                                Console.WriteLine("ConsoleCommand : Fan A - Setting MaxSpeed to "+((AssettoCorsaWindSim.FanParameters.POWER_COMPUTATION)uintValue).ToString());
                                list[0].powerCompFunc = (AssettoCorsaWindSim.FanParameters.POWER_COMPUTATION)uintValue;
                                break;
                            default:
                            case (ConsoleKey.Escape):
                                Console.WriteLine("ConsoleCommand : Fan A - Cancelled");
                                break;
                        }
                        break;
                    case (ConsoleKey.B):
                        Console.WriteLine("ConsoleCommand : Fan B - Choose Angle (A), Gamma (G), MaxSpeed (S), Function (F)");
                        Console.WriteLine("ConsoleCommand : Press Escape or another letter to cancel");
                        cki = Console.ReadKey();
                        list = acws.GetFanParametersList();
                        switch(cki.Key) {
                            case (ConsoleKey.A):
                                Console.WriteLine("ConsoleCommand : Fan B - Write Angle (in degrees)");
                                strValue = Console.ReadLine();

                                try {
                                    floatValue = Convert.ToSingle(strValue);
                                }
                                catch (Exception ex) {
                                    Console.WriteLine("ConsoleCommand : Fan B - Could not change angle value ("+ex.Message+";"+strValue+")");
                                    break;
                                }

                                Console.WriteLine("ConsoleCommand : Fan B - Setting Angle to {0}", floatValue);
                                list[1].angle = floatValue;
                                break;
                            case (ConsoleKey.G):
                                Console.WriteLine("ConsoleCommand : Fan B - Write Gamma (must be strictly greater than 0)");
                                strValue = Console.ReadLine();

                                try {
                                    floatValue = Convert.ToSingle(strValue);
                                }
                                catch (Exception ex) {
                                    Console.WriteLine("ConsoleCommand : Fan B - Could not change gamma value ("+ex.Message+";"+strValue+")");
                                    break;
                                }

                                Console.WriteLine("ConsoleCommand : Fan B - Setting Gamma to {0}", floatValue);
                                list[1].gamma = floatValue;
                                break;
                            case (ConsoleKey.S):
                                Console.WriteLine("ConsoleCommand : Fan B - Write MaxSpeed (in km/h) (must be greater than 1)");
                                strValue = Console.ReadLine();

                                try {
                                    floatValue = Convert.ToSingle(strValue);
                                }
                                catch (Exception ex) {
                                    Console.WriteLine("ConsoleCommand : Fan B - Could not change MaxSpeed value ("+ex.Message+";"+strValue+")");
                                    break;
                                }

                                Console.WriteLine("ConsoleCommand : Fan B - Setting MaxSpeed to {0}", floatValue);
                                list[1].maxSpeed = floatValue;
                                break;
                            case (ConsoleKey.F):
                                Console.WriteLine("ConsoleCommand : Fan B - Write Function (must be 0, 1 or 2)");
                                strValue = Console.ReadLine();

                                try {
                                    uintValue = Convert.ToByte(strValue);
                                }
                                catch (Exception ex) {
                                    Console.WriteLine("ConsoleCommand : Fan B - Could not change Function value ("+ex.Message+";"+strValue+")");
                                    break;
                                }

                                Console.WriteLine("ConsoleCommand : Fan B - Setting MaxSpeed to "+((AssettoCorsaWindSim.FanParameters.POWER_COMPUTATION)uintValue).ToString());
                                list[1].powerCompFunc = (AssettoCorsaWindSim.FanParameters.POWER_COMPUTATION)uintValue;
                                break;
                            default:
                            case (ConsoleKey.Escape):
                                Console.WriteLine("ConsoleCommand : Fan B - Cancelled");
                                break;
                        }
                        break;
                    case (ConsoleKey.D6):   // Minus mapped to D6 ???
                        if (AssettoCorsaWindSimController.DEBUG_VERBOSE > 0) {
                            AssettoCorsaWindSimController.DEBUG_VERBOSE -= 1;
                        }
                        Console.WriteLine("ConsoleCommand : Debug Verbose = {0}", AssettoCorsaWindSimController.DEBUG_VERBOSE);
                        break;
                    case (ConsoleKey.OemPlus):
                        if (AssettoCorsaWindSimController.DEBUG_VERBOSE < 3) {
                            AssettoCorsaWindSimController.DEBUG_VERBOSE += 1;
                        }
                        Console.WriteLine("ConsoleCommand : Debug Verbose = {0}", AssettoCorsaWindSimController.DEBUG_VERBOSE);
                        break;
                    case (ConsoleKey.Escape):
                        Console.WriteLine("ConsoleCommand : Exit Main Program");
                        loop = false;
                        break;
                }
            } while(loop);

            acws.Dispose();
        }
    }
}