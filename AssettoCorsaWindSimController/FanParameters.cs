namespace AssettoCorsaWindSim;

public class FanParameters
{
    public float angle;
    public float maxSpeed;
    public float gamma;

    public FanParameters(float _angle, float _maxSpeed, float _gamma) {
        angle = _angle;
        maxSpeed = _maxSpeed;
        gamma = _gamma;
    }

    public FanParameters() {
        angle = 0.0f;
        maxSpeed = 200f;
        gamma = 1f;
    }

    public uint CalculatePower(float speedKmh, float angularVelocity) {
        // Power compution here
        // For now, angularVelocity and fan angle are not taken into account
        return Convert.ToUInt32((Math.Pow(speedKmh, gamma)/Math.Pow(maxSpeed, gamma))*100);
    }
}
