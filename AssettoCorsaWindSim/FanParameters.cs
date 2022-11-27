namespace AssettoCorsaWindSim;

public class FanParameters
{
    public enum POWER_COMPUTATION {
        SPEED_ONLY = 0,
        ANGLE_ADJUSTING_LOWERING_ONLY = 1,
        ANGLE_ADJUSTING = 2
    };

    public float angle;
    public float maxSpeed;
    public float gamma;

    public POWER_COMPUTATION powerCompFunc;

    public Boolean overload {
        get; private set;
    }
    public Boolean underload {
        get; private set;
    }

    public FanParameters(float _angle = 0.0f, float _maxSpeed = 200f, float _gamma = 1f, POWER_COMPUTATION _powerCompFunc = POWER_COMPUTATION.SPEED_ONLY) {
        angle = _angle;
        maxSpeed = _maxSpeed;
        gamma = _gamma;
        powerCompFunc = _powerCompFunc;

        overload = false;
        underload = false;
    }

    public FanParameters() {
        angle = 0.0f;
        maxSpeed = 200f;
        gamma = 1f;
        powerCompFunc = POWER_COMPUTATION.SPEED_ONLY;

        overload = false;
        underload = false;
    }

    public uint CalculatePower(float speedKmh, float angularVelocity) {
        float powerValue = 0;
        switch(powerCompFunc) {
            case POWER_COMPUTATION.SPEED_ONLY:
            default:
                powerValue = ComputeSpeedOnly(speedKmh, angularVelocity);
                break;
            case POWER_COMPUTATION.ANGLE_ADJUSTING_LOWERING_ONLY:
                powerValue = ComputeAngleAdjLoweringOnly(speedKmh, angularVelocity);
                break;
            case POWER_COMPUTATION.ANGLE_ADJUSTING:
                powerValue = ComputeAngleAdj(speedKmh, angularVelocity);
                break;
        }

        overload = powerValue > 1f;
        underload = powerValue < 0f;
        if (overload) powerValue = 1f;
        if (underload) powerValue = 0f;

        return Convert.ToUInt32(powerValue*255f);
    }

    private float ComputeSpeedOnly(float speedKmh, float angularVelocity) {
        return (float)(Math.Pow(speedKmh, gamma)/Math.Pow(maxSpeed, gamma));
    }

    private float ComputeAngleAdjLoweringOnly(float speedKmh, float angularVelocity) {
        float baseValue = ComputeSpeedOnly(speedKmh, angularVelocity);
        float adjustValue = angularVelocity*angle*MathF.PI/180f;    // This number has no physical sense, for test purposes for the moment

        if (adjustValue > 0f) {
            adjustValue = 0f;
        }
        if (adjustValue < -1.0f) {
            adjustValue = -1f;
        }

        return baseValue + baseValue*adjustValue;
    }

    private float ComputeAngleAdj(float speedKmh, float angularVelocity) {
        float baseValue = ComputeSpeedOnly(speedKmh, angularVelocity);
        float adjustValue = angularVelocity*angle*MathF.PI/180f;    // This number has no physical sense, for test purposes for the moment

        if (adjustValue > 1.0f) {
            adjustValue = 1f;
        }
        if (adjustValue < -1.0f) {
            adjustValue = -1f;
        }

        return baseValue + baseValue*adjustValue;
    }
}
