using SimulationInsight.MathLibrary;

namespace SimulationInsight.ScenarioGenerator;

public class ScenarioSettings : IScenarioSettings
{
    public ILLAOrigin LLAOrigin
    {
        get; 
        set;
    }

    public List<FlightpathSettings> FlightpathSettings
    {
        get;
        set;
    }

    public ScenarioSettings(ILLAOrigin llaAOrigin)
    {
        LLAOrigin = llaAOrigin;
        FlightpathSettings = new List<FlightpathSettings>();
    }
}