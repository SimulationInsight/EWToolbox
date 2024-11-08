using static System.Math;

namespace SimulationInsight.MathLibrary;

public static class LLAConversions
{
    public static LLA ConvertPositionNEDToLLA(PositionNED positionNED, LLA positionOrigin)
    {
        var R = PhysicalConstants.EarthRadiusEquatorial;
        var f = PhysicalConstants.EarthFlatteningFactor;

        var u0 = positionOrigin.Latitude;
        var l0 = positionOrigin.Longitude;

        var dN = positionNED.PositionNorth;
        var dE = positionNED.PositionEast;

        var numerator = 1 - (2 * f - f * f);
        var denominator = 1 - (2 * f - f * f) * Pow(Sin(u0), 2);

        var Rn = R / Sqrt(denominator);
        var Rm = Rn * numerator / denominator;

        var du = Atan2(1, Rm) * dN;
        var dl = Atan2(1, (Rn * Cos(u0))) * dE;

        var altitude = -positionNED.PositionDown;

        var u = u0 + du;
        var l = l0 + dl;
        var d = altitude - positionOrigin.Altitude;

        var uDeg = u.ToDegrees();
        var lDeg = l.ToDegrees();

        var lla = new LLA()
        {
            LatitudeDeg = uDeg,
            LongitudeDeg = lDeg,
            Altitude = d
        };

        return lla;
    }

    public static PositionNED ConvertLLAToPositionNED(LLA position, LLA positionOrigin)
    {
        var R = PhysicalConstants.EarthRadiusEquatorial;
        var f = PhysicalConstants.EarthFlatteningFactor;

        var u0 = positionOrigin.Latitude;
        var l0 = positionOrigin.Longitude;

        var numerator = 1 - (2 * f - f * f);
        var denominator = 1 - (2 * f - f * f) * Pow(Sin(u0), 2);

        var Rn = R / Sqrt(denominator);
        var Rm = Rn * numerator / denominator;

        var u = position.Latitude;
        var l = position.Longitude;

        var du = u - u0;
        var dl = l - l0;

        var positionNorth = du / Atan2(1, Rm);
        var positionEast = dl / Atan2(1, (Rn * Cos(u0)));
        var positionDown = -(position.Altitude - positionOrigin.Altitude);

        var positionNED = new PositionNED(positionNorth, positionEast, positionDown);

        return positionNED;
    }
}