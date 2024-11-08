namespace SimulationInsight.Core
{
    public interface ISystemClock : IExecutableModel
    {
        DateTime DateTimeOrigin
        {
            get; set;
        }

        DateTime CurrentDateTime
        {
            get;
        }

        double CurrentTime
        {
            get; set;
        }
    }
}