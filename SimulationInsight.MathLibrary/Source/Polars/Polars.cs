using static System.Math;

namespace SimulationInsight.MathLibrary;

public record Polars
{
    public double Range
    {
        get; init;
    }

    public double RangeRate
    {
        get; init;
    }

    public double AzimuthAngle
    {
        get; init;
    }

    public double AzimuthRate
    {
        get; init;
    }

    public double ElevationAngle
    {
        get; init;
    }

    public double ElevationRate
    {
        get; init;
    }

    public double GroundRange => Range * Cos(ElevationAngle);

    public Polars()
    {
    }

    public Polars(double range, double rangeRate, double azimuthAngle, double azimuthRate, double elevationAngle, double elevationRate)
    {
        Range = range;
        RangeRate = rangeRate;
        AzimuthAngle = azimuthAngle;
        AzimuthRate = azimuthRate;
        ElevationAngle = elevationAngle;
        ElevationRate = elevationRate;
    }

    public Polars(double[] polars)
    {
        Range = polars[0];
        RangeRate = polars[1];
        AzimuthAngle = polars[2];
        AzimuthRate = polars[3];
        ElevationAngle = polars[4];
        ElevationRate = polars[5];
    }

    public Polars(Vector polars) : this(polars.Data)
    {
    }

    public Cartesians ToCartesians()
    {
        var cartesians = CoordinateConversions.PolarsToCartesians(this);

        return cartesians;
    }

    public Matrix JacobianCartesiansWrtPolars()
    {
        var j = CoordinateConversions.JacobianCartesiansWrtPolars(this);

        return j;
    }
}