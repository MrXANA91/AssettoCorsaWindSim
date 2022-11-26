using System.Timers;
using Timer = System.Timers.Timer;
using assettocorsasharedmemory;

namespace AssettoCorsaWindSim;

public class AssettoCorsaWindSimController : IDisposable
{
    public List<FanParameters> fansParams;

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

        fansParams = new List<FanParameters>();

        fansControllerTimer.Start();
    }

    ~AssettoCorsaWindSimController() {
        Dispose();
    }

    public void Dispose() {
        ac.Stop();
        fansController_StopAndDisconnect();
    }

    void ac_PhysicsInfoUpdated(object? sender, PhysicsEventArgs e) {
        float[] localangularvelocity = e.Physics.LocalAngularVelocity;
        
        // Important data
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
                break;
            case AC_STATUS.AC_PAUSE:
                Console.WriteLine("Assetto Corsa is paused!");
                updateFansPower = false;
                fansController_deactivate();
                break;
            case AC_STATUS.AC_LIVE:
                Console.WriteLine("Assetto Corsa is started!");
                updateFansPower = true;
                fansController_activate();
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
                    // Here, we know there will be 2 fans.
                    // TODO : plan to fetch infos from Arduino
                    fansParams.Add(new FanParameters(0f, 350f, 1f));
                    fansParams.Add(new FanParameters(0f, 350f, 1f));

                    fansController_activate();

                    ac.Start();
                }
            }
        }
    }

    void fansController_StopAndDisconnect() {
        fansControllerTimer.Stop();
        fansController_deactivate();
        lock(fansController) {
            fansController.Disconnect();
        }
    }

    void fansController_activate() {
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
    }

    void fansController_deactivate() {
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
    }

    void fansController_Update(float speedKmh, float localAngularVelocityY) {
        if (fansController.IsConnected && updateFansPower) {
            try {
                lock(fansController) {
                    fansController.SetFanAPower(fansParams[0].CalculatePower(speedKmh, localAngularVelocityY));
                }
            }
            catch (Exception ex) {
                Console.WriteLine("Could not send Power command for Fan A : "+ex.ToString());
            }
            try {
                lock(fansController) {
                    fansController.SetFanBPower(fansParams[1].CalculatePower(speedKmh, localAngularVelocityY));
                }
            }
            catch (Exception ex) {
                Console.WriteLine("Could not send Power command for Fan B : "+ex.ToString());
            }
        }
    }
}