namespace SimulationInsight.MathLibrary;

public class Signal
{
    public string Name
    {
        get;
        set;
    }

    public Vector Time
    {
        get;
        set;
    }

    public Vector I
    {
        get;
        set;
    }

    public Vector Q
    {
        get;
        set;
    }

    public double RfFrequencyCentre
    {
        get; 
        set;
    }

    public double RfFrequencyMin => RfFrequencyCentre - SampleRate / 2.0;

    public double RfFrequencyMax => RfFrequencyCentre + SampleRate / 2.0;

    public int NumberOfSamples => Time.Length;

    public double StartTime => Time[0];

    public double EndTime => Time[^1];

    public double SampleInterval => (EndTime - StartTime) / (NumberOfSamples - 1);

    public double SampleRate => 1 / SampleInterval;

    public Signal()
    {

    }

    public Signal(double startTime, double endTime, double sampleRate)
    {
        var step = 1.0 / sampleRate;

        Time = Vector.LinearlySpacedVector(startTime, endTime, step);
        I = new Vector(Time.Length);
        Q = new Vector(Time.Length);
    }

    public Signal(double[] time)
    {
        Time = new Vector(time);
        I = new Vector(Time.Length);
        Q = new Vector(Time.Length);
    }

    public Signal(Vector time)
    {
        Time = time;
        I = new Vector(Time.Length);
        Q = new Vector(Time.Length);
    }

    public float[] GetSampleDataFloat()
    {
        var data = new float[NumberOfSamples * 2];

        for (var i = 0; i < NumberOfSamples; i++)
        {
            data[i * 2] = (float)I[i];
            data[i * 2 + 1] = (float)Q[i];
        }

        return data;
    }
}