using static System.Math;

namespace SimulationInsight.MathLibrary;

public static class MathUtilities
{
    public static double PowerToDecibels(this double power)
    {
        var power_dB = 10.0 * Log10(power);

        return power_dB;
    }

    public static double MagnitudeToDecibels(this double magnitude)
    {
        var power_dB = 20.0 * Log10(magnitude);

        return power_dB;
    }

    public static double DecibelsToPower(this double power_dB)
    {
        var power = Pow(10.0, power_dB / 10.0);

        return power;
    }

    public static double DecibelsToMagnitude(this double power_dB)
    {
        var magnitude = Pow(10.0, power_dB / 20.0);

        return magnitude;
    }

    public static double dBTodBm(this double power_dB)
    {
        var power_dBm = power_dB + 30.0;

        return power_dBm;
    }

    public static double dBmTodB(this double power_dBm)
    {
        var power_dB = power_dBm - 30.0;

        return power_dB;
    }
}