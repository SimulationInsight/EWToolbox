namespace SimulationInsight.MathLibrary;

public partial class Vector
{
    public double GetCircularValue(int index)
    {
        var i = index % Data.Length;

        var x = Data[i];

        return x;
    }

    public static Vector LinearlySpacedVector(double start, double end, double step)
    {
        var span = end - start;

        int numberOfSamples = (int)(span / step);

        var result = new Vector(numberOfSamples);

        for (int i = 0; i < numberOfSamples; i++)
        {
            result[i] = start + step * i;
        }

        return result;
    }

    public static Vector Cos(Vector x)
    {
        var data = new double[x.NumberOfElements];

        for (int i = 0; i < x.NumberOfElements; i++)
        {
            data[i] = Math.Cos(x.Data[i]);
        }

        var result = new Vector(data);

        return result;
    }

    public static Vector Sin(Vector x)
    {
        var data = new double[x.NumberOfElements];

        for (int i = 0; i < x.NumberOfElements; i++)
        {
            data[i] = Math.Sin(x.Data[i]);
        }

        var result = new Vector(data);

        return result;
    }

    public static Vector RandomNormalVector(int numberOfElements, double mean, double stddev)
    {
        var random = new Random();

        var data = new double[numberOfElements];

        for (int i = 0; i < numberOfElements; i++)
        {
            data[i] = MathNet.Numerics.Distributions.Normal.Sample(random, mean, stddev);
        }

        var result = new Vector(data);

        return result;
    }

    public bool IsMonotonicallyIncreasing()
    {
        if (NumberOfElements < 2)
        {
            return true;
        }

        var delta = 0.0;

        for (int i = 0; i < NumberOfElements - 1; i++)
        {
            delta = Data[i + 1] - Data[i];

            if (delta < 0.0)
            {
                return false;
            }
        }

        return true;
    }

    public bool IsMonotonicallyDecreasing()
    {
        if (NumberOfElements < 2)
        {
            return true;
        }

        var delta = 0.0;

        for (int i = 0; i < NumberOfElements - 2; i++)
        {
            delta = Data[i + 1] - Data[i];

            if (delta > 0.0)
            {
                return false;
            }
        }

        return true;
    }

    public bool IsMonotonic()
    {
        var isMonotonic = IsMonotonicallyIncreasing() || IsMonotonicallyDecreasing();

        return isMonotonic;
    }
}