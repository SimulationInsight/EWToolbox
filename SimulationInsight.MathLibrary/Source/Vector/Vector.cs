namespace SimulationInsight.MathLibrary;

public partial class Vector
{
    public int NumberOfElements => Data.Length;

    public int Length => NumberOfElements;

    public double[] Data
    {
        get; init;
    }

    public Vector() : this(0)
    {
    }

    public Vector(int numberOfElements)
    {
        Data = new double[numberOfElements];
    }

    public Vector(int numberOfElements, double value)
    {
        Data = new double[numberOfElements];

        for (int i = 0; i < numberOfElements; i++)
        {
            Data[i] = value;
        }
    }

    public Vector(params double[] data)
    {
        Data = data;
    }

    public double this[int index]
    {
        get => Data[index];
        set => Data[index] = value;
    }

    public Vector Copy()
    {
        var result = new Vector();

        Array.Copy(Data, result.Data, NumberOfElements);

        return result;
    }
}