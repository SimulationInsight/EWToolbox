namespace SimulationInsight.ScenarioGenerator;

public class Scenario : IScenario
{
    public IScenarioSettings ScenarioSettings
    {
        get; set;
    }

    public List<Flightpath> Flightpaths
    {
        get; set;
    }

    public List<RelativeFlightpath> RelativeFlightpaths
    {
        get; set;
    }

    public Scenario(IScenarioSettings scenarioSettings)
    {
        ScenarioSettings = scenarioSettings;
    }

    public void GenerateScenario()
    {
        Flightpaths = new List<Flightpath>();

        foreach (var flightpathSettings in ScenarioSettings.FlightpathSettings)
        {
            var flightpath = new Flightpath(ScenarioSettings.LLAOrigin, flightpathSettings);

            flightpath.GenerateFlightpath(0, 100.0);

            Flightpaths.Add(flightpath);
        }
    }
}