using System.Timers;
using Timer = System.Timers.Timer;
using assettocorsasharedmemory;
using System.Collections.ObjectModel;

namespace AssettoCorsaWindSim;

public class AssettoCorsaWindSimController : IDisposable
{
    public delegate void AssettoCorsaConnectionChangedHandler(object sender, GameStatusEventArgs e);
    public delegate void AssettoCorsaDataReceivedHandler(object sender, AssettoCorsaDataEventArgs e);

    public delegate void HardwareConnectionChangedHandler(object sender, HardwareConnectionEventArgs e);
    public delegate void HardwareDataSentHandler(object sender, HardwareDataEventArgs e);

    private List<FanParameters> fansParams;

    private ArduinoSerialCom fansController;
    private bool fansControllerConnected;
    private object connectLock = new object();

    public bool IsHardwareConnected
    {
        get { return fansControllerConnected; }
        private set { fansControllerConnected = value; }
    }
    
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

    public AC_STATUS gameStatus
    {
        get; private set;
    }

    #region "EVENTS MANAGER"

    public event AssettoCorsaConnectionChangedHandler? AssettoCorsaConnectionChanged;

    public virtual void OnAssettoCorsaConnectionChanged(GameStatusEventArgs e)
    {
        AssettoCorsaConnectionChanged?.Invoke(this, e);
    }

    public event AssettoCorsaDataReceivedHandler? AssettoCorsaDataReceived;

    public virtual void OnAssettoCorsaDataReceived(AssettoCorsaDataEventArgs e)
    {
        AssettoCorsaDataReceived?.Invoke(this, e);
    }

    public event HardwareConnectionChangedHandler? HardwareConnectionChanged;

    public virtual void OnHardwareConnectionChanged(HardwareConnectionEventArgs e)
    {
        HardwareConnectionChanged?.Invoke(this, e);
    }

    public event HardwareDataSentHandler? HardwareDataSent;

    public virtual void OnHardwareDataSent(HardwareDataEventArgs e)
    {
        HardwareDataSent?.Invoke(this, e);
    }

    #endregion

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
        gameStatus = AC_STATUS.AC_OFF;

        fansParams = new List<FanParameters>();
    }

    ~AssettoCorsaWindSimController() {
        Dispose();
    }

    public void Dispose() {
        Stop();

        GC.SuppressFinalize(this);
    }

    public void Start()
    {
        fansControllerTimer.Start();
        ac.Start();
    }

    public void Stop()
    {
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

        OnAssettoCorsaDataReceived(new AssettoCorsaDataEventArgs(speedKmh, localangularvelocityYDegrees));

        if (_debug_verbose>=2 && gameStatus == AC_STATUS.AC_LIVE)  Console.Write("{0, 6:F2}km/h, {1, 6:F1}, ({2, 6:F3}, {3, 6:F3}, {4, 6:F3}) ", speedKmh, localangularvelocityYDegrees, localangularvelocity[0], localangularvelocityY, localangularvelocity[2]);

        fansController_Update(speedKmh, localangularvelocityY);
    }

    private void ac_GameStatusUpdated(object sender, GameStatusEventArgs e) {
        gameStatus = e.GameStatus;
        OnAssettoCorsaConnectionChanged(new GameStatusEventArgs(gameStatus));
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
        bool isConnected;
        
        lock (connectLock)
        {
            isConnected = fansController.IsConnected;

            if (!isConnected)
            {
                if (_debug_verbose >= 1) Console.WriteLine("Trying to connect...");
                foreach (string comport in fansController.ComportList)
                {
                    bool _connected;
                    lock (fansController)
                    {
                        _connected = fansController.Connect(comport, 115200);
                    }
                    if (_connected)
                    {
                        InitializeFans();
                        break;
                    }
                }
            }
        }

        if (isConnected != fansControllerConnected)
        {
            fansControllerConnected = isConnected;
            OnHardwareConnectionChanged(new HardwareConnectionEventArgs(isConnected));
        }
    }

    private void InitializeFans()
    {
        // Here, we know there will be 2 fans.
        // TODO : plan to fetch infos from Arduino
        // TODO : change FanParameters dynamically from the chosen car (even chosen combo car/track ?)
        fansParams.Add(new FanParameters(30f));
        fansParams.Add(new FanParameters(-30f));

        fansController_activate();
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
            OnHardwareDataSent(new HardwareDataEventArgs(fanA_power, fanB_power));

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