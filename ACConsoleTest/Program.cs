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
            double doubleValue = 0;

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
                                Console.WriteLine("\tIndex : {0}, angle : {1}, gamma : {2}, maxSpeed : {3}, powerCompFunc : "+ _powerCompFunc.ToString(), list.IndexOf(fanParam), _angle.ToString(), _gamma.ToString(), _maxSpeed.ToString());
                            }
                            Console.WriteLine("\tPhysicsInterval = {0}ms | GraphicsInterval = {1}ms", acws.PhysicsInterval, acws.GraphicsInterval);
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
                                Console.WriteLine("ConsoleCommand : Fan A - Write Angle (in degrees - default is 30)");
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
                                Console.WriteLine("ConsoleCommand : Fan A - Write Gamma (must be strictly greater than 0 - default is 0,5)");
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
                                Console.WriteLine("ConsoleCommand : Fan A - Write MaxSpeed (in km/h) (must be greater than 1 - default is 250)");
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
                                Console.WriteLine("ConsoleCommand : Fan A - Write Function (must be 0, 1 or 2 - default is 0)");
                                Console.WriteLine("\t0 : SPEED_ONLY | 1 : STRICT_VECTOR_PROJECTION | 2 : EXAGERATE_VECTOR_PROJECTION");
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
                                Console.WriteLine("ConsoleCommand : Fan B - Write Angle (in degrees - default is -30)");
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
                                Console.WriteLine("ConsoleCommand : Fan B - Write Gamma (must be strictly greater than 0 - default is 0,5)");
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
                                Console.WriteLine("ConsoleCommand : Fan B - Write MaxSpeed (in km/h) (must be greater than 1 - default is 250)");
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
                                Console.WriteLine("ConsoleCommand : Fan B - Write Function (must be 0, 1 or 2 - default is 0)");
                                Console.WriteLine("\t0 : SPEED_ONLY | 1 : STRICT_VECTOR_PROJECTION | 2 : EXAGERATE_VECTOR_PROJECTION");
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
                    case (ConsoleKey.I):
                        Console.WriteLine("ConsoleCommand : Intervals settings - choose PhysicsInterval (P) or GraphicsInterval (G)");
                        Console.WriteLine("ConsoleCommand : Press Escape or another letter to cancel");
                        doubleValue = 0;
                        cki = Console.ReadKey();
                        switch(cki.Key) {
                            case (ConsoleKey.P):
                                Console.WriteLine("ConsoleCommand : PhysicsInterval - Write value in ms (must be greater than 0 - default is 30)");
                                strValue = Console.ReadLine();

                                try {
                                    doubleValue = Convert.ToDouble(strValue);
                                }
                                catch (Exception ex) {
                                    Console.WriteLine("ConsoleCommand : PhysicsInterval - Could not change PhysicsInterval value ("+ex.Message+";"+strValue+")");
                                    break;
                                }

                                Console.WriteLine("ConsoleCommand : PhysicsInterval - Setting PhysicsInterval to "+((double)doubleValue).ToString());
                                acws.PhysicsInterval = doubleValue;
                                break;
                            case (ConsoleKey.G):
                                Console.WriteLine("ConsoleCommand : GraphicsInterval - Write value in ms (must be greater than 0 - default is 100)");
                                strValue = Console.ReadLine();

                                try {
                                    doubleValue = Convert.ToDouble(strValue);
                                }
                                catch (Exception ex) {
                                    Console.WriteLine("ConsoleCommand : GraphicsInterval - Could not change GraphicsInterval value ("+ex.Message+";"+strValue+")");
                                    break;
                                }

                                Console.WriteLine("ConsoleCommand : GraphicsInterval - Setting GraphicsInterval to "+((double)doubleValue).ToString());
                                acws.GraphicsInterval = doubleValue;
                                break;
                            default:
                            case (ConsoleKey.Escape):
                                Console.WriteLine("ConsoleCommand : Fan B - Cancelled");
                                break;
                        }
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