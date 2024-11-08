using SimulationInsight.Core;

namespace SimulationInsight.ScenarioGenerator;

public interface IFlightpath : IExecutableModel
{
    FlightpathSettings FlightpathSettings { get; set; }

    FlightpathData GetFlightpathData(double time);
}