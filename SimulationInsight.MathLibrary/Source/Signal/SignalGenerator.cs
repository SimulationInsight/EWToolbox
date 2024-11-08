namespace SimulationInsight.MathLibrary;

public static class SignalGenerator
{
    public static Signal RectangularPulsedSignal(double rfFrequencyCentre, double sampleRate, double pulseWidth, double endTime)
    {
        var nSamples = (int)(endTime * sampleRate);

        var nSamplesOn = (int)(pulseWidth * sampleRate);

        var I = new Vector(nSamples);
        var Q = new Vector(nSamples);

        for (var i = 0; i < nSamplesOn; i++)
        {
            I[i] = 1.0;
        }

        var startTime = 0.0;

        var signal = new Signal(startTime, endTime, sampleRate)
        {
            RfFrequencyCentre = rfFrequencyCentre,
            I = I,
            Q = Q
        };

        return signal;
    }
}