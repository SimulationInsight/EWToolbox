namespace SimulationInsight.MathLibrary;

public record LLA
{
    public double LatitudeDeg { get; init; }

    public double LongitudeDeg { get; init; }

    public double Altitude { get; init; }

    public double Latitude => LatitudeDeg.FromDegrees();

    public double Longitude => LongitudeDeg.FromDegrees();
}