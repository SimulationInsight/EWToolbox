using static System.Math;

namespace SimulationInsight.MathLibrary;

public static class DoubleExtensionMethods
{
    public static double LimitAbsoluteValue(this double value, double maximumAbsoluteValue)
    {
        var result = value;

        if (value > maximumAbsoluteValue)
        {
            return maximumAbsoluteValue;
        }

        if (value < -maximumAbsoluteValue)
        {
            return -maximumAbsoluteValue;
        }

        return result;
    }

    public static double ConstrainAngleDegTo0To360(this double value)
    {
        var offset = Floor(value / 360.0) * 360.0;

        var result = value - offset;

        return result;
    }
}