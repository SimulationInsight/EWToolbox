using SimulationInsight.MathLibrary;

namespace SimulationInsight.ScenarioGenerator;

public interface IScenarioSettings
{
    ILLAOrigin LLAOrigin
    {
        get;
        set;
    }

    List<FlightpathSettings> FlightpathSettings
    {
        get;
        set;
    }
}