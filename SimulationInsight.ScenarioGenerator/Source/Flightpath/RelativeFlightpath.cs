namespace SimulationInsight.ScenarioGenerator;

public class RelativeFlightpath
{
    public Flightpath Origin
    {
        get; set;
    }

    public Flightpath Target
    {
        get; set;
    }

    public RelativeFlightpathData GetRelativeFlightpathData(double time)
    {
        var r = new RelativeFlightpathData()
        {
        };

        return r;
    }
}