using static System.Math;
using static SimulationInsight.MathLibrary.PhysicalConstants;
using static SimulationInsight.MathLibrary.UnitConversions;

namespace SimulationInsight.MathLibrary;

public static class UnitConversionMethods
{
    public static double ToDecibels(this double x)
    {
        var result = 10.0 * Log10(x);

        return result;
    }

    public static double FromDecibels(this double x)
    {
        var result = Pow(10.0, (x / 10.0));

        return result;
    }

    public static double ToDegrees(this double x)
    {
        var result = x * RadiansToDegrees;

        return result;
    }

    public static double FromDegrees(this double x)
    {
        var result = x * DegreesToRadians;

        return result;
    }

    public static double ToFeet(this double x)
    {
        var result = x * MeterToFoot;

        return result;
    }

    public static double FromFeet(this double x)
    {
        var result = x * FootToMeter;

        return result;
    }

    public static double ToKilometer(this double x)
    {
        var result = x * MeterToKilometer;

        return result;
    }

    public static double FromKilometer(this double x)
    {
        var result = x * KilometerToMeter;

        return result;
    }

    public static double ToNauticalMile(this double x)
    {
        var result = x * MeterToNauticalMile;

        return result;
    }

    public static double FromNauticalMile(this double x)
    {
        var result = x * NauticalMileToMeter;

        return result;
    }

    public static double ToKnots(this double x)
    {
        var result = x * MeterPerSecondToKnot;

        return result;
    }

    public static double FromKnots(this double x)
    {
        var result = x * KnotToMeterPerSecond;

        return result;
    }

    public static double FrequencyToWavelength(this double x)
    {
        var result = SpeedOfLight / x;

        return result;
    }

    public static double WavelengthToFrequency(this double x)
    {
        var result = SpeedOfLight / x;

        return result;
    }

    public static double PulseDurationToRange(this double x)
    {
        var result = SpeedOfLight * x / 2;

        return result;
    }

    public static double ToG(this double x)
    {
        var result = x * MeterPerSecondSquaredToG;

        return result;
    }

    public static double FromG(this double x)
    {
        var result = x * GToMeterPerSecondSquared;

        return result;
    }

    public static double RpmToDegrees(this double x)
    {
        var result = x * UnitConversions.RpmToDegrees;

        return result;
    }

    public static double DegreesToRpm(this double x)
    {
        var result = x * UnitConversions.DegreesToRpm;

        return result;
    }

    public static double RadiansToRpm(this double angleRate)
    {
        var angleRateRpm = angleRate.ToDegrees().DegreesToRpm();

        return angleRateRpm;
    }

    public static double RpmToRadians(this double angleRateRpm)
    {
        var angleRateRad = angleRateRpm.RpmToDegrees().FromDegrees();

        return angleRateRad;
    }

    public static double ToMilliseconds(this double x)
    {
        var result = x * 1.0e3;

        return result;
    }

    public static double FromMilliseconds(this double x)
    {
        var result = x / 1.0e3;

        return result;
    }

    public static double ToMicroseconds(this double x)
    {
        var result = x * 1.0e6;

        return result;
    }

    public static double FromMicroseconds(this double x)
    {
        var result = x / 1.0e6;

        return result;
    }

    public static double ToNanoseconds(this double x)
    {
        var result = x * 1.0e9;

        return result;
    }

    public static double FromNanoseconds(this double x)
    {
        var result = x / 1.0e9;

        return result;
    }
}