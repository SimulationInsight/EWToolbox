namespace SimulationInsight.MathLibrary;

public record VelocityNED
{
    public double VelocityNorth { get; init; }

    public double VelocityEast { get; init; }

    public double VelocityDown { get; init; }

    public VelocityNED(double velocityNorth, double velocityEast, double velocityDown)
    {
        VelocityNorth = velocityNorth;
        VelocityEast = velocityEast;
        VelocityDown = velocityDown;
    }

    public static VelocityNED operator +(VelocityNED a, VelocityNED b)
    {
        var velocityNorth = a.VelocityNorth + b.VelocityNorth;
        var velocityEast = a.VelocityEast + b.VelocityEast;
        var velocityDown = a.VelocityDown + b.VelocityDown;

        var result = new VelocityNED(velocityNorth, velocityEast, velocityDown);

        return result;
    }

    public static VelocityNED operator -(VelocityNED a, VelocityNED b)
    {
        var velocityNorth = a.VelocityNorth - b.VelocityNorth;
        var velocityEast = a.VelocityEast - b.VelocityEast;
        var velocityDown = a.VelocityDown - b.VelocityDown;

        var result = new VelocityNED(velocityNorth, velocityEast, velocityDown);

        return result;
    }
}