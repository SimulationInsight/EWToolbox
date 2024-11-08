using static System.Math;

namespace SimulationInsight.MathLibrary;

public record PositionNED
{
    public double PositionNorth { get; init; }

    public double PositionEast { get; init; }

    public double PositionDown { get; init; }

    public PositionNED(double positionNorth, double positionEast, double positionDown)
    {
        PositionNorth = positionNorth;
        PositionEast = positionEast;
        PositionDown = positionDown;
    }

    public static PositionNED operator +(PositionNED a, PositionNED b)
    {
        var positionNorth = a.PositionNorth + b.PositionNorth;
        var positionEast = a.PositionEast + b.PositionEast;
        var positionDown = a.PositionDown + b.PositionDown;

        var result = new PositionNED(positionNorth, positionEast, positionDown);

        return result;
    }

    public static PositionNED operator -(PositionNED a, PositionNED b)
    {
        var positionNorth = a.PositionNorth - b.PositionNorth;
        var positionEast = a.PositionEast - b.PositionEast;
        var positionDown = a.PositionDown - b.PositionDown;

        var result = new PositionNED(positionNorth, positionEast, positionDown);

        return result;
    }

    public double GetMagnitude()
    {
        var magnitudeSquared = PositionNorth * PositionNorth + PositionEast * PositionEast + PositionDown * PositionDown;

        var magnitude = Sqrt(magnitudeSquared);

        return magnitude;
    }
}