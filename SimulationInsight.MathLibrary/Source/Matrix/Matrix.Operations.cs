using MathNet.Numerics.LinearAlgebra;

namespace SimulationInsight.MathLibrary;

public partial class Matrix
{
    public static Matrix IdentityMatrix(int numberOfRows)
    {
        var result = IdentityMatrix(numberOfRows, numberOfRows);

        return result;
    }

    public static Matrix IdentityMatrix(int numberOfRows, int numberOfColumns)
    {
        var result = new Matrix(numberOfRows, numberOfColumns);

        var rank = Math.Min(numberOfRows, numberOfColumns);

        for (int i = 0; i < rank; i++)
        {
            result[i, i] = 1.0;
        }

        return result;
    }

    public static Matrix RandomMatrix(int numberOfRows, int numberOfColumns, Random random)
    {
        var result = new Matrix(numberOfRows, numberOfColumns);

        for (int i = 0; i < numberOfRows; i++)
        {
            for (int j = 0; j < numberOfColumns; j++)
            {
                result.Data[i, j] = random.NextDouble();
            }
        }

        return result;
    }

    public Matrix Transpose()
    {
        Matrix result = new Matrix(NumberOfColumns, NumberOfRows);

        for (var i = 0; i < NumberOfRows; i++)
        {
            for (var j = 0; j < NumberOfColumns; j++)
            {
                result.Data[j, i] = Data[i, j];
            }
        }

        return result;
    }

    public Matrix MultiplyElements(Matrix a)
    {
        var result = new Matrix(NumberOfRows, NumberOfColumns);

        for (int i = 0; i < NumberOfRows; i++)
        {
            for (int j = 0; j < NumberOfColumns; j++)
            {
                result.Data[i, j] = Data[i, j] * a.Data[i, j];
            }
        }

        return result;
    }

    public double SumOfElements()
    {
        var result = 0.0;

        for (int i = 0; i < NumberOfRows; i++)
        {
            for (int j = 0; j < NumberOfColumns; j++)
            {
                result += Data[i, j];
            }
        }

        return result;
    }

    public double SumOfElementsSquared()
    {
        var result = 0.0;

        for (int i = 0; i < NumberOfRows; i++)
        {
            for (int j = 0; j < NumberOfColumns; j++)
            {
                result += Data[i, j] * Data[i, j];
            }
        }

        return result;
    }

    public Matrix Inverse()
    {
        var m = CreateMatrix.DenseOfArray(Data);

        var mInverse = m.Inverse();

        var data = mInverse.ToArray();

        var result = new Matrix(data);

        return result;
    }

    public static Matrix DiagonalMatrix(params double[] data)
    {
        var result = new Matrix(data.Length, data.Length);

        for (int i = 0; i < data.Length; i++)
        {
            result[i, i] = data[i];
        }

        return result;
    }

    public static Matrix DiagonalMatrix(Vector data)
    {
        var result = DiagonalMatrix(data.Data);

        return result;
    }

    public Vector GetDiagonal()
    {
        var result = new Vector(NumberOfRows);

        for (int i = 0; i < NumberOfRows; i++)
        {
            result[i] = Data[i, i];
        }

        return result;
    }
}