namespace SimulationInsight.MathLibrary;

public partial class Vector
{
    public static Vector operator +(Vector x, double y)
    {
        var data = new double[x.NumberOfElements];

        for (int i = 0; i < x.NumberOfElements; i++)
        {
            data[i] = x.Data[i] + y;
        }

        var result = new Vector(data);

        return result;
    }

    public static Vector operator +(double x, Vector y)
    {
        var result = y + x;

        return result;
    }

    public static Vector operator +(Vector x, Vector y)
    {
        var data = new double[x.NumberOfElements];

        for (int i = 0; i < x.NumberOfElements; i++)
        {
            data[i] = x.Data[i] + y.Data[i];
        }

        var result = new Vector(data);

        return result;
    }

    public static Vector operator -(Vector x)
    {
        var data = new double[x.NumberOfElements];

        for (int i = 0; i < x.NumberOfElements; i++)
        {
            data[i] = -x.Data[i];
        }

        var result = new Vector(data);

        return result;
    }

    public static Vector operator -(Vector x, double y)
    {
        var data = new double[x.NumberOfElements];

        for (int i = 0; i < x.NumberOfElements; i++)
        {
            data[i] = x.Data[i] - y;
        }

        var result = new Vector(data);

        return result;
    }

    public static Vector operator -(double x, Vector y)
    {
        var data = new double[y.NumberOfElements];

        for (int i = 0; i < y.NumberOfElements; i++)
        {
            data[i] = x - y.Data[i];
        }

        var result = new Vector(data);

        return result;
    }

    public static Vector operator -(Vector x, Vector y)
    {
        var data = new double[x.NumberOfElements];

        for (int i = 0; i < x.NumberOfElements; i++)
        {
            data[i] = x.Data[i] - y.Data[i];
        }

        var result = new Vector(data);

        return result;
    }

    public static Vector operator *(Vector x, double y)
    {
        var data = new double[x.NumberOfElements];

        for (int i = 0; i < x.NumberOfElements; i++)
        {
            data[i] = x.Data[i] * y;
        }

        var result = new Vector(data);

        return result;
    }

    public static Vector operator *(double x, Vector y)
    {
        var result = y * x;

        return result;
    }

    public static Vector operator *(Vector x, Vector y)
    {
        var data = new double[x.NumberOfElements];

        for (int i = 0; i < x.NumberOfElements; i++)
        {
            data[i] = x.Data[i] * y.Data[i];
        }

        var result = new Vector(data);

        return result;
    }

    public static Vector operator /(Vector x, double y)
    {
        var data = new double[x.NumberOfElements];

        for (int i = 0; i < x.NumberOfElements; i++)
        {
            data[i] = x.Data[i] / y;
        }

        var result = new Vector(data);

        return result;
    }

    public static Vector operator /(double x, Vector y)
    {
        var data = new double[y.NumberOfElements];

        for (int i = 0; i < y.NumberOfElements; i++)
        {
            data[i] = x / y.Data[i];
        }

        var result = new Vector(data);

        return result;
    }

    public static Vector operator /(Vector x, Vector y)
    {
        var data = new double[x.NumberOfElements];

        for (int i = 0; i < x.NumberOfElements; i++)
        {
            data[i] = x.Data[i] / y.Data[i];
        }

        var result = new Vector(data);

        return result;
    }
}