namespace SimulationInsight.MathLibrary;

public record Cartesians
{
    public PositionNED PositionNED { get; init; }
    public VelocityNED VelocityNED { get; init; }

    public Cartesians()
    {
    }

    public Cartesians(double positionX, double positionY, double positionZ, double velocityX, double velocityY, double velocityZ)
    {
        PositionNED = new PositionNED(positionX, positionY, positionZ);
        VelocityNED = new VelocityNED(velocityX, velocityY, velocityZ);
    }

    public Cartesians(double[] x)
    {
        PositionNED = new PositionNED(x[0], x[1], x[2]);
        VelocityNED = new VelocityNED(x[3], x[4], x[5]);
    }

    public Cartesians(Vector x) : this(x.Data)
    {
    }

    public Cartesians(PositionNED positionNED, VelocityNED velocityNED)
    {
        PositionNED = positionNED;
        VelocityNED = velocityNED;
    }

    public static Cartesians operator +(Cartesians a, Cartesians b)
    {
        var positionNED = a.PositionNED + b.PositionNED;
        var velocityNED = a.VelocityNED + b.VelocityNED;

        var result = new Cartesians(positionNED, velocityNED);

        return result;
    }

    public static Cartesians operator -(Cartesians a, Cartesians b)
    {
        var positionNED = a.PositionNED - b.PositionNED;
        var velocityNED = a.VelocityNED - b.VelocityNED;

        var result = new Cartesians(positionNED, velocityNED);

        return result;
    }

    public double[] ToArray()
    {
        var array = new double[] { PositionNED.PositionNorth, PositionNED.PositionEast, PositionNED.PositionDown, VelocityNED.VelocityNorth, VelocityNED.VelocityEast, VelocityNED.VelocityDown };

        return array;
    }

    public Vector ToVector()
    {
        var vector = new Vector(PositionNED.PositionNorth, PositionNED.PositionEast, PositionNED.PositionDown, VelocityNED.VelocityNorth, VelocityNED.VelocityEast, VelocityNED.VelocityDown);

        return vector;
    }

    public Polars ToPolars()
    {
        var polars = CoordinateConversions.CartesiansToPolars(this);

        return polars;
    }

    public Matrix JacobianPolarsWrtCartesians()
    {
        var j = CoordinateConversions.JacobianPolarsWrtCartesians(this);

        return j;
    }
}