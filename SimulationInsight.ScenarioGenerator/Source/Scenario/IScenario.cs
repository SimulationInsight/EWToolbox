namespace SimulationInsight.ScenarioGenerator;

public interface IScenario
{
    List<Flightpath> Flightpaths
    {
        get;
        set;
    }

    List<RelativeFlightpath> RelativeFlightpaths
    {
        get;
        set;
    }

    IScenarioSettings ScenarioSettings
    {
        get;
        set;
    }

    void GenerateScenario();
}