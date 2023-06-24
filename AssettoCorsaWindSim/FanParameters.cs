using assettocorsasharedmemory;

namespace AssettoCorsaWindSim;

public class FanParameters
{
    public enum POWER_COMPUTATION {
        SPEED_ONLY = 0,
        STRICT_VECTOR_PROJECTION = 1,
        EXAGERATE_VECTOR_PROJECTION = 2
    };

    public static readonly Dictionary<POWER_COMPUTATION, string> PowerComputationNameLookup = new Dictionary<POWER_COMPUTATION, string>
    {
        { POWER_COMPUTATION.SPEED_ONLY, "Speed only" },
        { POWER_COMPUTATION.STRICT_VECTOR_PROJECTION, "Strict vector projection" },
        { POWER_COMPUTATION.EXAGERATE_VECTOR_PROJECTION, "Exagerate vector projection" }
    };

    public const float DEFAULT_ANGLE = 0f;
    public const float DEFAULT_MAXSPEED = 250f;
    public const float DEFAULT_GAMMA = 0.5f;
    public const POWER_COMPUTATION DEFAULT_COMPUTATION = POWER_COMPUTATION.SPEED_ONLY;
    public float angle;
    public float maxSpeed;
    public float gamma;
    public POWER_COMPUTATION powerCompFunc;

    public FanStatus status;

    public FanParameters(float _angle = DEFAULT_ANGLE, float _maxSpeed = DEFAULT_MAXSPEED, float _gamma = DEFAULT_GAMMA, POWER_COMPUTATION _powerCompFunc = DEFAULT_COMPUTATION) {
        angle = _angle;
        maxSpeed = _maxSpeed;
        gamma = _gamma;
        powerCompFunc = _powerCompFunc;

        status = new FanStatus();
    }

    public FanParameters() {
        angle = DEFAULT_ANGLE;
        maxSpeed = DEFAULT_MAXSPEED;
        gamma = DEFAULT_GAMMA;
        powerCompFunc = DEFAULT_COMPUTATION;

        status = new FanStatus();
    }

    public uint CalculatePower(float speedKmh, float angularVelocity) {
        float powerValue = 0;
        switch(powerCompFunc) {
            case POWER_COMPUTATION.SPEED_ONLY:
            default:
                powerValue = ComputeSpeedOnly(speedKmh, angularVelocity);
                break;
            case POWER_COMPUTATION.STRICT_VECTOR_PROJECTION:
                powerValue = ComputeVectorProj(speedKmh, angularVelocity, angle);
                break;
            case POWER_COMPUTATION.EXAGERATE_VECTOR_PROJECTION:
                powerValue = ComputeVectorProj(speedKmh, angularVelocity, 60.0f);
                break;
        }

        status.UpdateFlowFlags(powerValue > 1f, powerValue < 0f);
        if (status.Overload) powerValue = 1f;
        if (status.Underload) powerValue = 0f;

        status.UpdatePowerValue(Convert.ToUInt32(MathF.Pow(powerValue, gamma) * 255f));

        return status.PowerValue;
    }

    private float ComputeSpeedOnly(float speedKmh, float angularVelocity) {
        return (float)(speedKmh/maxSpeed);
    }

    private float ComputeVectorProj(float speedKmh, float angularVelocity, float targetAngle) {
        float baseValue = (float)(speedKmh/maxSpeed);
        float angleRad = angle / 180.0f * MathF.PI;
        float targetAngleRad = targetAngle / 180.0f * MathF.PI;

        return baseValue * MathF.Cos(targetAngleRad*(angleRad - angularVelocity)/angleRad);
    }
}

public class FanStatus
{
    public bool PowerEnabled { get; private set; } = false;

    public uint PowerValue { get; private set; } = 0;

    public bool Overload { get; private set; } = false;

    public bool Underload { get; private set; } = false;

    public FanStatus()
    {

    }

    internal void UpdatePowerEnable(bool powerEnabled)
    {
        PowerEnabled = powerEnabled;
    }

    internal void UpdatePowerValue(uint powerValue)
    {
        PowerValue = powerValue;
    }

    internal void UpdateFlowFlags(bool overload, bool underload)
    {
        Overload = overload;
        Underload = underload;
    }
}