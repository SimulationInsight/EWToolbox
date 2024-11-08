namespace SimulationInsight.MathLibrary;

public partial class Matrix
{
    public static Matrix operator +(Matrix a, int b)
    {
        var result = new Matrix(a.NumberOfRows, a.NumberOfColumns);

        for (int i = 0; i < result.NumberOfRows; i++)
        {
            for (int j = 0; j < result.NumberOfColumns; j++)
            {
                result[i, j] = a[i, j] + b;
            }
        }

        return result;
    }

    public static Matrix operator +(int a, Matrix b)
    {
        var result = new Matrix(b.NumberOfRows, b.NumberOfColumns);

        for (int i = 0; i < result.NumberOfRows; i++)
        {
            for (int j = 0; j < result.NumberOfColumns; j++)
            {
                result[i, j] = a + b[i, j];
            }
        }

        return result;
    }

    public static Matrix operator +(Matrix a, Matrix b)
    {
        var result = new Matrix(a.NumberOfRows, a.NumberOfColumns);

        for (int i = 0; i < result.NumberOfRows; i++)
        {
            for (int j = 0; j < result.NumberOfColumns; j++)
            {
                result[i, j] = a[i, j] + b[i, j];
            }
        }

        return result;
    }

    public static Matrix operator -(Matrix a)
    {
        var result = new Matrix(a.NumberOfRows, a.NumberOfColumns);

        for (int i = 0; i < result.NumberOfRows; i++)
        {
            for (int j = 0; j < result.NumberOfColumns; j++)
            {
                result[i, j] = -a[i, j];
            }
        }

        return result;
    }

    public static Matrix operator -(Matrix a, int b)
    {
        var result = new Matrix(a.NumberOfRows, a.NumberOfColumns);

        for (int i = 0; i < result.NumberOfRows; i++)
        {
            for (int j = 0; j < result.NumberOfColumns; j++)
            {
                result[i, j] = a[i, j] - b;
            }
        }

        return result;
    }

    public static Matrix operator -(int a, Matrix b)
    {
        var result = new Matrix(b.NumberOfRows, b.NumberOfColumns);

        for (int i = 0; i < result.NumberOfRows; i++)
        {
            for (int j = 0; j < result.NumberOfColumns; j++)
            {
                result[i, j] = a - b[i, j];
            }
        }

        return result;
    }

    public static Matrix operator -(Matrix a, Matrix b)
    {
        var result = new Matrix(a.NumberOfRows, a.NumberOfColumns);

        for (int i = 0; i < result.NumberOfRows; i++)
        {
            for (int j = 0; j < result.NumberOfColumns; j++)
            {
                result[i, j] = a[i, j] - b[i, j];
            }
        }

        return result;
    }

    public static Matrix operator *(Matrix a, int b)
    {
        var result = new Matrix(a.NumberOfRows, a.NumberOfColumns);

        for (int i = 0; i < result.NumberOfRows; i++)
        {
            for (int j = 0; j < result.NumberOfColumns; j++)
            {
                result[i, j] = a[i, j] * b;
            }
        }

        return result;
    }

    public static Matrix operator *(int a, Matrix b)
    {
        var result = new Matrix(b.NumberOfRows, b.NumberOfColumns);

        for (int i = 0; i < result.NumberOfRows; i++)
        {
            for (int j = 0; j < result.NumberOfColumns; j++)
            {
                result[i, j] = a * b[i, j];
            }
        }

        return result;
    }

    public static Vector operator *(Vector a, Matrix b)
    {
        var result = new Vector(b.NumberOfColumns);

        for (int i = 0; i < b.NumberOfRows; i++)
        {
            for (int j = 0; j < b.NumberOfColumns; j++)
            {
                result[j] += a[i] * b[i, j];
            }
        }

        return result;
    }

    public static Vector operator *(Matrix a, Vector b)
    {
        var result = new Vector(a.NumberOfRows);

        for (int i = 0; i < a.NumberOfRows; i++)
        {
            for (int j = 0; j < a.NumberOfColumns; j++)
            {
                result[i] += a[i, j] * b[j];
            }
        }

        return result;
    }

    public static Matrix operator *(Matrix a, Matrix b)
    {
        var result = new Matrix(a.NumberOfRows, b.NumberOfColumns);

        for (int i = 0; i < result.NumberOfRows; i++)
        {
            for (int j = 0; j < result.NumberOfColumns; j++)
            {
                for (int k = 0; k < a.NumberOfColumns; k++)
                {
                    result[i, j] += a[i, k] * b[k, j];
                }
            }
        }

        return result;
    }

    public static Matrix operator /(Matrix a, int b)
    {
        var result = new Matrix(a.NumberOfRows, a.NumberOfColumns);

        for (int i = 0; i < result.NumberOfRows; i++)
        {
            for (int j = 0; j < result.NumberOfColumns; j++)
            {
                result[i, j] = a[i, j] / b;
            }
        }

        return result;
    }

    public static Matrix operator /(int a, Matrix b)
    {
        var result = new Matrix(b.NumberOfRows, b.NumberOfColumns);

        for (int i = 0; i < result.NumberOfRows; i++)
        {
            for (int j = 0; j < result.NumberOfColumns; j++)
            {
                result[i, j] = a / b[i, j];
            }
        }

        return result;
    }

    public static Matrix operator /(Matrix a, Matrix b)
    {
        var result = new Matrix(a.NumberOfRows, a.NumberOfColumns);

        for (int i = 0; i < result.NumberOfRows; i++)
        {
            for (int j = 0; j < result.NumberOfColumns; j++)
            {
                result[i, j] = a[i, j] / b[i, j];
            }
        }

        return result;
    }
}