namespace SimulationInsight.ScenarioGenerator;

public record RelativeFlightpathData
{
    public int FlightpathIdOrigin
    {
        get; init;
    }

    public int FlightpathIdTarget
    {
        get; init;
    }

    public int Time
    {
        get; init;
    }

    public int LatitudeDeg
    {
        get; init;
    }

    public int LongitudeDeg
    {
        get; init;
    }

    public int Altitude
    {
        get; init;
    }

    public int PositionNorth
    {
        get; init;
    }

    public int PositionEast
    {
        get; init;
    }

    public int PositionDown
    {
        get; init;
    }

    public int VelocityNorth
    {
        get; init;
    }

    public int VelocityEast
    {
        get; init;
    }

    public int VelocityDown
    {
        get; init;
    }

    public int Range
    {
        get; init;
    }

    public int RangeRate
    {
        get; init;
    }

    public int AzimuthAngleDeg
    {
        get; init;
    }

    public int AzimuthRateDeg
    {
        get; init;
    }

    public int ElevationAngleDeg
    {
        get; init;
    }

    public int ElevationRateDeg
    {
        get; init;
    }
}