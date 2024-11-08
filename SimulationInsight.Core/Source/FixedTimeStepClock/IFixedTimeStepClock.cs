namespace SimulationInsight.Core;

public interface IFixedTimeStepClock
{
    double CurrentTime
    {
        get;
        set;
    }

    double TimeStep
    {
        get;
        set;
    }

    void Initialise(double time);

    bool IsStepClock(double time);

    void StepClock();
}