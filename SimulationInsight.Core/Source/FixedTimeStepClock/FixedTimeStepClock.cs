using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationInsight.Core;

public class FixedTimeStepClock : IFixedTimeStepClock
{
    public double StartTime
    {
        get;
        set;
    }

    public double CurrentTime
    {
        get;
        set;
    }

    public double TimeStep
    {
        get;
        set;
    }

    public double NumberOfClockTicks
    {
        get;
        set;
    }

    public double NextTimeStep => CurrentTime + TimeStep;

    public FixedTimeStepClock()
    {
    }

    public void Initialise(double time)
    {
        StartTime = (int)(time / TimeStep) * TimeStep;

        NumberOfClockTicks = 0;

        CurrentTime = StartTime;
    }

    public void StepClock()
    {
        NumberOfClockTicks++;

        CurrentTime = NumberOfClockTicks * TimeStep + StartTime;
    }

    public bool IsStepClock(double time)
    {
        var isStepClock = time >= NextTimeStep;

        return isStepClock;
    }
}
