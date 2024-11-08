namespace SimulationInsight.MathLibrary;

public static class PhysicalConstants
{
    public const double SpeedOfLightVacuum = 299792458.0;
    public const double SpeedOfLightApproximate = 3.0E8;
    public const double SpeedOfLight = SpeedOfLightApproximate;

    public const double BoltzmannConstant = 1.38064852E-23;

    public const double EarthRadiusMean = 6371008.8;
    public const double EarthRadiusEquatorial = 6378137.0;
    public const double EarthRadiusPolar = 6356752.3;
    public const double EarthRadiusFourThirds = 4.0 / 3.0 * EarthRadiusMean;
    public const double EarthFlatteningFactor = 1.0 / 298.257223562;

    public const double SystemReferenceTemperature = 290.0;

    public const double GravitationalAcceleration = 9.80665;
}