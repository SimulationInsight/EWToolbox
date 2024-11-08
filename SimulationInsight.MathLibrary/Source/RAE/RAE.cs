namespace SimulationInsight.MathLibrary;

public record RAE
{
    public double Range { get; init; }

    public double AzimuthAngle { get; init; }

    public double ElevationAngle { get; init; }

    public RAE()
    {
    }

    public RAE(double a, double e)
    {
        Range = 1.0;
        AzimuthAngle = a;
        ElevationAngle = e;
    }

    public RAE(double r, double a, double e)
    {
        Range = r;
        AzimuthAngle = a;
        ElevationAngle = e;
    }

    public RAE(double[] rae)
    {
        Range = rae[0];
        AzimuthAngle = rae[1];
        ElevationAngle = rae[2];
    }

    public RAE(Vector rae) : this(rae.Data)
    {
    }

    public double Magnitude()
    {
        return Range;
    }

    public RAE UnitVector()
    {
        var unitVector = new RAE()
        {
            Range = 1.0,
            AzimuthAngle = AzimuthAngle,
            ElevationAngle = ElevationAngle
        };

        return unitVector;
    }

    public PositionNED ToPositionNED()
    {
        var positionNED = CoordinateConversions.RAEToPositionNED(this);

        return positionNED;
    }
}