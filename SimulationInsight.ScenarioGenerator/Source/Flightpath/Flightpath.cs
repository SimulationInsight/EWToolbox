using SimulationInsight.MathLibrary;

namespace SimulationInsight.ScenarioGenerator;

public record Flightpath : IFlightpath
{
    public ILLAOrigin LLAOrigin
    {
        get; set;
    }

    public FlightpathSettings FlightpathSettings
    {
        get; set;
    }

    public List<FlightpathData> FlightpathData
    {
        get; set;
    }

    public Flightpath(ILLAOrigin llaOrigin, FlightpathSettings flightpathSettings)
    {
        LLAOrigin = llaOrigin;
        FlightpathSettings = flightpathSettings;
    }

    public void GenerateFlightpath(double time1, double time2)
    {
        FlightpathData = new List<FlightpathData>();

        var f1 = GetFlightpathData(time1);
        var f2 = GetFlightpathData(time2);

        FlightpathData.Add(f1);
        FlightpathData.Add(f2);
    }

    public FlightpathData GetFlightpathData(double time)
    {
        var fp = FlightpathSettings;

        var positionNED = new PositionNED(fp.InitialPositionNorth, fp.InitialPositionEast, fp.InitialPositionDown);
        var velocityNED = new VelocityNED(fp.InitialVelocityNorth, fp.InitialVelocityEast, fp.InitialVelocityDown);

        var lla = LLAConversions.ConvertPositionNEDToLLA(positionNED, LLAOrigin.LLA);

        var flightpathData = new FlightpathData()
        {
            Time = time,
            LLA = lla,
            PositionNED = positionNED,
            VelocityNED = velocityNED
        };

        return flightpathData;
    }

    public void Initialise(double time)
    {
        throw new NotImplementedException();
    }

    public void Update(double time)
    {
        throw new NotImplementedException();
    }

    public void Finalise(double time)
    {
        throw new NotImplementedException();
    }
}