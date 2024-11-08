namespace SimulationInsight.ScenarioGenerator;

public record FlightpathSettings
{
    public int FlightpathId
    {
        get; init;
    }

    public string FlightpathName
    {
        get; init;
    }

    public string PlatformType
    {
        get; init;
    }

    public string PlatformIcon
    {
        get; init;
    }

    public double InitialPositionNorth
    {
        get; init;
    }

    public double InitialPositionEast
    {
        get; init;
    }

    public double InitialPositionDown
    {
        get; init;
    }

    public double InitialVelocityNorth
    {
        get; init;
    }

    public double InitialVelocityEast
    {
        get; init;
    }

    public double InitialVelocityDown
    {
        get; init;
    }
}