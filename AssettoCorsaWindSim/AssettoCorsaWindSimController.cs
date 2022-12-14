using System.Timers;
using Timer = System.Timers.Timer;
using assettocorsasharedmemory;
using System.Collections.ObjectModel;

namespace AssettoCorsaWindSim;

public class AssettoCorsaWindSimController : IDisposable
{
    private List<FanParameters> fansParams;

    private ArduinoSerialCom fansController;
    
    private static uint _debug_verbose = ArduinoSerialCom.VERBOSE_IMPORTANT;
    public static uint DEBUG_VERBOSE {
        get {
            return _debug_verbose;
        }
        set {
            ArduinoSerialCom.DEBUG_VERBOSE = value;
            _debug_verbose = value;
        }
    }

    public double PhysicsInterval {
        get {
            return ac.PhysicsInterval;
        }
        set {
            ac.PhysicsInterval = value;
        }
    }

    public double GraphicsInterval {
        get {
            return ac.GraphicsInterval;
        }
        set {
            ac.GraphicsInterval = value;
        }
    }

    private Timer fansControllerTimer;

    private AssettoCorsa ac;
    private bool updateFansPower;

    private AC_STATUS gameStatus = AC_STATUS.AC_OFF;

    public AssettoCorsaWindSimController() {
        ac = new AssettoCorsa();
        ac.PhysicsInterval = 30;
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

    public ReadOnlyCollection<FanParameters> GetFanParametersList() {
        return fansParams.AsReadOnly();
    }

    private void ac_PhysicsInfoUpdated(object? sender, PhysicsEventArgs e) {
        float[] localangularvelocity = e.Physics.LocalAngularVelocity;
        
        // Important data
        float speedKmh = e.Physics.SpeedKmh;
        float localangularvelocityY = localangularvelocity[1];

        float localangularvelocityYDegrees = localangularvelocityY / MathF.PI * 180.0f;

        if (_debug_verbose>=2 && gameStatus == AC_STATUS.AC_LIVE)  Console.Write("{0, 6:F2}km/h, {1, 6:F1}, ({2, 6:F3}, {3, 6:F3}, {4, 6:F3}) ", speedKmh, localangularvelocityYDegrees, localangularvelocity[0], localangularvelocityY, localangularvelocity[2]);

        fansController_Update(speedKmh, localangularvelocityY);
    }

    private void ac_GameStatusUpdated(object sender, GameStatusEventArgs e) {
        gameStatus = e.GameStatus;
        switch(gameStatus) {
            case AC_STATUS.AC_OFF:
            case AC_STATUS.AC_REPLAY:
            default:
                if (_debug_verbose>=1)  Console.WriteLine("Assetto Corsa is not live.");
                updateFansPower = false;
                break;
            case AC_STATUS.AC_PAUSE:
                if (_debug_verbose>=1)  Console.WriteLine("Assetto Corsa is paused!");
                updateFansPower = false;
                fansController_deactivate();
                break;
            case AC_STATUS.AC_LIVE:
                if (_debug_verbose>=1)  Console.WriteLine("Assetto Corsa is started!");
                updateFansPower = true;
                fansController_activate();
                fansControllerTimer.Start();
                break;
        }
    }

    private void fansControllerTimer_Elapsed(object? sender, ElapsedEventArgs e ) {
        if (!fansController.IsConnected) {
            if (_debug_verbose>=1)  Console.WriteLine("Trying to connect...");
            foreach (string comport in fansController.ComportList) {
                bool _connected;
                lock(fansController) {
                    _connected = fansController.Connect(comport, 115200);
                }
                if (_connected) {
                    // Here, we know there will be 2 fans.
                    // TODO : plan to fetch infos from Arduino
                    // TODO : change FanParameters dynamically from the chosen car (even chosen combo car/track ?)
                    fansParams.Add(new FanParameters(30f));
                    fansParams.Add(new FanParameters(-30f));

                    fansController_activate();

                    ac.Start();
                }
            }
        }
    }

    private void fansController_StopAndDisconnect() {
        fansControllerTimer.Stop();
        fansController_deactivate();
        lock(fansController) {
            fansController.Disconnect();
        }
    }

    private void fansController_activate() {
        if (fansController.IsConnected) {
            try {
                lock(fansController) {
                    fansController.SetFanAEnable(true);
                }
            } catch (Exception ex) {
                if (_debug_verbose>=0)  Console.WriteLine("Enabling Fan A exception : "+ex.ToString());
            }
            try {
                lock(fansController) {
                    fansController.SetFanBEnable(true);
                }
            } catch (Exception ex) {
                if (_debug_verbose>=0)  Console.WriteLine("Enabling Fan B exception : "+ex.ToString());
            }
        }
    }

    private void fansController_deactivate() {
        if (fansController.IsConnected) {
            try {
                lock(fansController) {
                    fansController.SetFanAEnable(false);
                }
            } catch (Exception ex) {
                if (_debug_verbose>=0)  Console.WriteLine("Stopping Fan A exception : "+ex.ToString());
            }
            try {
                lock(fansController) {
                    fansController.SetFanBEnable(false);
                }
            } catch (Exception ex) {
                if (_debug_verbose>=0)  Console.WriteLine("Stopping Fan B exception : "+ex.ToString());
            }
        }
    }

    private void fansController_Update(float speedKmh, float localAngularVelocityY) {
        uint fanA_power = fansParams[0].CalculatePower(speedKmh, localAngularVelocityY);
        uint fanB_power = fansParams[1].CalculatePower(speedKmh, localAngularVelocityY);

        if (fansController.IsConnected && updateFansPower) {
            String fanAString = "";
            String fanBString = "";
            if (fansParams[0].overload) fanAString += "+";
            if (fansParams[0].underload) fanAString += "-";
            if (fansParams[1].overload) fanBString += "+";
            if (fansParams[1].underload) fanBString += "-";
            if (_debug_verbose>=2)  Console.WriteLine("| {0, -3} - {1, 3} | ({2,-2},{3,2})", fanA_power, fanB_power, fanAString, fanBString);
            try {
                lock(fansController) {
                    fansController.SetFanAPower(fanA_power);
                }
            }
            catch (Exception ex) {
                if (_debug_verbose>=0)  Console.WriteLine("Could not send Power command for Fan A : "+ex.ToString());
            }
            try {
                lock(fansController) {
                    fansController.SetFanBPower(fanB_power);
                }
            }
            catch (Exception ex) {
                if (_debug_verbose>=0)  Console.WriteLine("Could not send Power command for Fan B : "+ex.ToString());
            }
        }
    }
}