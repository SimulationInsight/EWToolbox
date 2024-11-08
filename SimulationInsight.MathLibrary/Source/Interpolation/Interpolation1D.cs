namespace SimulationInsight.MathLibrary;

public class Interpolation1D
{
    public Vector X { get; set; }

    public Vector Y
    {
        get; set;
    }

    public double StepSize
    {
        get; set;
    }

    public Interpolation1D(Vector x, Vector y)
    {
        X = x;
        Y = y;

        Initialise();
    }

    public void Initialise()
    {
        if (X.NumberOfElements > 1)
        {
            StepSize = X[1] - X[0];
        }
    }

    public double Interpolate(double x)
    {
        if (X.NumberOfElements == 1)
        {
            return Y[0];
        }

        if (x <= X[0])
        {
            return Y[0];
        }

        if (x >= X[^1])
        {
            return Y[^1];
        }

        var index1 = (int)((x - X[0]) / StepSize);

        var x0 = X[index1];
        var x1 = X[index1 + 1];

        var y0 = Y[index1];
        var y1 = Y[index1 + 1];

        var y = y0 * (x1 - x) / StepSize + y1 * (x - x0) / StepSize;

        return y;
    }

    public Vector Interpolate(Vector x)
    {
        var result = new Vector(x.NumberOfElements);

        for (int i = 0; i < x.NumberOfElements; i++)
        {
            result[i] = Interpolate(x[i]);
        }

        return result;
    }
}