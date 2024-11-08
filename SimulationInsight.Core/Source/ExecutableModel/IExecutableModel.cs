namespace SimulationInsight.Core;

public interface IExecutableModel
{
    void Initialise(double time);

    void Update(double time);

    void Finalise(double time);
}