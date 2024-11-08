namespace SimulationInsight.Core;

public class SystemClock : ISystemClock
{
    public DateTime DateTimeOrigin { get; set; } = DateTime.Now;

    public DateTime CurrentDateTime => DateTimeOrigin.AddSeconds(CurrentTime);

    public double CurrentTime
    {
        get; set;
    }

    public void Initialise(double time)
    {
        CurrentTime = time;
    }

    public void Update(double time)
    {
        CurrentTime = time;
    }

    public void Finalise(double time)
    {
    }
}