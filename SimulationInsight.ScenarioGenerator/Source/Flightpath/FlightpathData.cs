using SimulationInsight.MathLibrary;

namespace SimulationInsight.ScenarioGenerator;

public record FlightpathData
{
    public int FlightpathId { get; init; }

    public double Time { get; init; }

    public LLA LLA { get; init; }

    public PositionNED PositionNED { get; init; }

    public VelocityNED VelocityNED { get; init; }

    public double TotalSpeed
    {
        get; init;
    }

    public double TotalSpeed_kts
    {
        get; init;
    }

    public double GroundSpeed
    {
        get; init;
    }

    public double GroundSpeed_kts
    {
        get; init;
    }

    public double AccelerationNorth
    {
        get; init;
    }

    public double AccelerationEast
    {
        get; init;
    }

    public double AccelerationDown
    {
        get; init;
    }

    public double AccelerationAxial
    {
        get; init;
    }

    public double AccelerationLateral
    {
        get; init;
    }

    public double AccelerationVetical
    {
        get; init;
    }

    public double HeadingAngleDeg
    {
        get; init;
    }

    public double PitchAngleDeg
    {
        get; init;
    }

    public double BankAngleDeg
    {
        get; init;
    }

    public double HeadingRateDeg
    {
        get; init;
    }

    public double PitchRateDeg
    {
        get; init;
    }

    public double BankRateDeg
    {
        get; init;
    }
}