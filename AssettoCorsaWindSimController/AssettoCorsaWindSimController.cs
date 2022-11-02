using System.Timers;
using Timer = System.Timers.Timer;
using assettocorsasharedmemory;

namespace AssettoCorsaWindSim;

public class AssettoCorsaWindSimController : IDisposable
{
    public static int NUMBER_OF_AVAILABLE_VENTILATORS = 2;  // prévoir de récupérer l'info depuis l'arduino

    private ArduinoSerialCom fansController;
    private Timer fansControllerTimer;

    private AssettoCorsa ac;
    private bool updateFansPower;

    public AssettoCorsaWindSimController() {
        ac = new AssettoCorsa();
        ac.PhysicsInterval = 100;
        ac.GraphicsInterval = 100;  // Used for GameStatusUpdate
        ac.PhysicsUpdated += ac_PhysicsInfoUpdated;
        ac.GameStatusChanged += ac_GameStatusUpdated;

        fansController = new ArduinoSerialCom();
        fansControllerTimer = new Timer(3000);
        fansControllerTimer.AutoReset = true;
        fansControllerTimer.Elapsed += fansControllerTimer_Elapsed;

        updateFansPower = false;

        // Objets representants les ventilateurs, avec les paramètres softs pour le calcul (angle, maxSpeed, gamma)
        // ainsi que leurs attributs ENABLE et POWER du hardware
    }

    ~AssettoCorsaWindSimController() {
        Dispose();
    }

    public void Dispose() {
        ac.Stop();
        fansController.Dispose();
    }

    public void Start() {
        ac.Start();
    }

    public void Stop() {
        ac.Stop();
        
        fansController_StopAndDisconnect();
    }

    void ac_PhysicsInfoUpdated(object? sender, PhysicsEventArgs e) {
        float[] localangularvelocity = e.Physics.LocalAngularVelocity;
        
        // Données importantes
        float speedKmh = e.Physics.SpeedKmh;
        float localangularvelocityY = localangularvelocity[1];

        fansController_Update(speedKmh, localangularvelocityY);
    }

    void ac_GameStatusUpdated(object sender, GameStatusEventArgs e) {
        switch(e.GameStatus) {
            case AC_STATUS.AC_OFF:
            case AC_STATUS.AC_REPLAY:
            default:
                Console.WriteLine("Assetto Corsa is not live.");
                updateFansPower = false;
                fansController_StopAndDisconnect();
                break;
            case AC_STATUS.AC_PAUSE:
                Console.WriteLine("Assetto Corsa is paused!");
                updateFansPower = false;
                if (fansController.IsConnected) {
                    try {
                        lock(fansController) {
                            fansController.SetFanAEnable(false);
                        }
                    } catch (Exception ex) {
                        Console.WriteLine("Stopping Fan A exception : "+ex.ToString());
                    }
                    try {
                        lock(fansController) {
                            fansController.SetFanBEnable(false);
                        }
                    } catch (Exception ex) {
                        Console.WriteLine("Stopping Fan B exception : "+ex.ToString());
                    }
                }
                break;
            case AC_STATUS.AC_LIVE:
                Console.WriteLine("Assetto Corsa is started!");
                updateFansPower = true;
                if (fansController.IsConnected) {
                    try {
                        lock(fansController) {
                            fansController.SetFanAEnable(true);
                        }
                    } catch (Exception ex) {
                        Console.WriteLine("Enabling Fan A exception : "+ex.ToString());
                    }
                    try {
                        lock(fansController) {
                            fansController.SetFanBEnable(true);
                        }
                    } catch (Exception ex) {
                        Console.WriteLine("Enabling Fan B exception : "+ex.ToString());
                    }
                }
                fansControllerTimer.Start();
                break;
        }
    }

    void fansControllerTimer_Elapsed(object? sender, ElapsedEventArgs e ) {
        if (!fansController.IsConnected) {
            Console.WriteLine("Trying to connect...");
            foreach (string comport in fansController.ComportList) {
                bool _connected;
                lock(fansController) {
                    _connected = fansController.Connect(comport, 115200);
                }
                if (_connected) {
                    try {
                        lock(fansController) {
                            fansController.SetFanAEnable(true);
                        }
                    } catch (Exception ex) {
                        Console.WriteLine("Stopping Fan A exception : "+ex.ToString());
                    }
                    try {
                        lock(fansController) {
                            fansController.SetFanBEnable(true);
                        }
                    } catch (Exception ex) {
                        Console.WriteLine("Stopping Fan B exception : "+ex.ToString());
                    }
                    break;
                }
            }
        }
    }

    void fansController_StopAndDisconnect() {
        fansControllerTimer.Stop();
        if (fansController.IsConnected) {
            try {
                lock(fansController) {
                    fansController.SetFanAEnable(false);
                }
            } catch (Exception ex) {
                Console.WriteLine("Stopping Fan A exception : "+ex.ToString());
            }
            try {
                lock(fansController) {
                    fansController.SetFanBEnable(false);
                }
            } catch (Exception ex) {
                Console.WriteLine("Stopping Fan B exception : "+ex.ToString());
            }
        }
        lock(fansController) {
            fansController.Disconnect();
        }
    }

    void fansController_Update(float speedKmh, float localAngularVelocityY) {
        if (fansController.IsConnected && updateFansPower) {
            // CALCULATE AND SEND INSTRUCTION
            try {
                lock(fansController) {
                    fansController.SetFanAPower(Convert.ToUInt32((speedKmh/350f)*100));
                }
            }
            catch (Exception ex) {
                Console.WriteLine("Could not send Power command for Fan A : "+ex.ToString());
            }
            /*
            try {
                lock(fansController) {
                    fansController.SetFanBPower(Convert.ToUInt32((speedKmh/350f)*100));
                }
            }
            catch (Exception ex) {
                Console.WriteLine("Could not send Power command for Fan B : "+ex.ToString());
            }
            */
        }
    }
}