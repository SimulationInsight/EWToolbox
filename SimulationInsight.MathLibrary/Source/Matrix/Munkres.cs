namespace SimulationInsight.MathLibrary;

public class Munkres
{
    private bool _isTransposed;

    private double[,] _c;

    private double[,] _m;

    private int[,] _path;

    private int[] _rowCover;

    private int[] _columnCover;

    private int _numberOfRows;

    private int _numberOfColumns;

    private int _pathCount;

    private int _pathRow;

    private int _pathColumn;

    private int _stepNumber;

    public Munkres(Matrix costMatrix, bool isShowDiagnostics = false)
    {
        CostMatrix = costMatrix;
        IsShowDiagnostics = isShowDiagnostics;

        _c = new double[0, 0];
        _m = new double[0, 0];
        _path = new int[0, 0];
        _rowCover = Array.Empty<int>();
        _columnCover = Array.Empty<int>();

        AssignmentMatrix = new Matrix();
        SolutionMatrix = new Matrix();
    }

    public Matrix CostMatrix
    {
        get; set;
    }

    public Matrix AssignmentMatrix
    {
        get; set;
    }

    public Matrix SolutionMatrix
    {
        get; set;
    }

    public double TotalCost
    {
        get; set;
    }

    public bool IsShowDiagnostics
    {
        get; set;
    }

    public void Solve()
    {
        Initialise();

        var done = false;

        while (!done)
        {
            if (IsShowDiagnostics)
            {
                ShowCostMatrix();
                ShowMaskMatrix();
            }

            switch (_stepNumber)
            {
                case 1:
                    StepOne();
                    break;

                case 2:
                    StepTwo();
                    break;

                case 3:
                    StepThree();
                    break;

                case 4:
                    StepFour();
                    break;

                case 5:
                    StepFive();
                    break;

                case 6:
                    StepSix();
                    break;

                case 7:
                    done = true;
                    break;
            }
        }

        Finalise();
    }

    private void Finalise()
    {
        AssignmentMatrix = new Matrix(_m);

        if (_isTransposed)
        {
            AssignmentMatrix = AssignmentMatrix.Transpose();
        }

        SolutionMatrix = AssignmentMatrix.MultiplyElements(CostMatrix);
        TotalCost = SolutionMatrix.SumOfElements();

        if (IsShowDiagnostics)
        {
            ShowSolutionMatrix();
            ShowTotalCost();
        }
    }

    private void StepOne()
    {
        for (int r = 0; r < _numberOfRows; r++)
        {
            var minInRow = _c[r, 0];

            for (int c = 0; c < _numberOfColumns; c++)
            {
                if (_c[r, c] < minInRow)
                {
                    minInRow = _c[r, c];
                }
            }

            for (int c = 0; c < _numberOfColumns; c++)
            {
                _c[r, c] -= minInRow;
            }
        }

        _stepNumber = 2;
    }

    private void StepTwo()
    {
        for (int r = 0; r < _numberOfRows; r++)
        {
            for (int c = 0; c < _numberOfColumns; c++)
            {
                if (_c[r, c] == 0 && _rowCover[r] == 0 && _columnCover[c] == 0)
                {
                    _m[r, c] = 1;
                    _rowCover[r] = 1;
                    _columnCover[c] = 1;
                }
            }
        }

        for (int r = 0; r < _numberOfRows; r++)
        {
            _rowCover[r] = 0;
        }

        for (int c = 0; c < _numberOfColumns; c++)
        {
            _columnCover[c] = 0;
        }

        _stepNumber = 3;
    }

    private void StepThree()
    {
        int colcount = 0;

        for (int r = 0; r < _numberOfRows; r++)
        {
            for (int c = 0; c < _numberOfColumns; c++)
            {
                if (_m[r, c] == 1)
                {
                    _columnCover[c] = 1;
                }
            }
        }

        for (int c = 0; c < _numberOfColumns; c++)
        {
            if (_columnCover[c] == 1)
            {
                colcount += 1;
            }
        }

        if (colcount >= _numberOfColumns || colcount >= _numberOfRows)
        {
            _stepNumber = 7;
        }
        else
        {
            _stepNumber = 4;
        }
    }

    private void StepFour()
    {
        var done = false;

        while (!done)
        {
            FindAZero(out int row, out int col);

            if (row == -1)
            {
                done = true;
                _stepNumber = 6;
            }
            else
            {
                _m[row, col] = 2;
                if (IsStarInRow(row))
                {
                    FindStarInRow(row, out col);
                    _rowCover[row] = 1;
                    _columnCover[col] = 0;
                }
                else
                {
                    done = true;
                    _stepNumber = 5;
                    _pathRow = row;
                    _pathColumn = col;
                }
            }
        }
    }

    private void StepFive()
    {
        var done = false;

        int c = -1;

        _pathCount = 1;
        _path[_pathCount - 1, 0] = _pathRow;
        _path[_pathCount - 1, 1] = _pathColumn;

        while (!done)
        {
            FindStarInColumn(_path[_pathCount - 1, 1], out int r);

            if (r > -1)
            {
                _pathCount += 1;
                _path[_pathCount - 1, 0] = r;
                _path[_pathCount - 1, 1] = _path[_pathCount - 2, 1];
            }
            else
            {
                done = true;
            }

            if (!done)
            {
                FindPrimeInRow(_path[_pathCount - 1, 0], ref c);
                _pathCount += 1;
                _path[_pathCount - 1, 0] = _path[_pathCount - 2, 0];
                _path[_pathCount - 1, 1] = c;
            }
        }

        AugmentPath();
        ClearCovers();
        ErasePrimes();

        _stepNumber = 3;
    }

    private void StepSix()
    {
        var minval = double.MaxValue;

        FindSmallest(ref minval);

        for (int r = 0; r < _numberOfRows; r++)
        {
            for (int c = 0; c < _numberOfColumns; c++)
            {
                if (_rowCover[r] == 1)
                {
                    _c[r, c] += minval;
                }

                if (_columnCover[c] == 0)
                {
                    _c[r, c] -= minval;
                }
            }
        }

        _stepNumber = 4;
    }

    private void AugmentPath()
    {
        for (var p = 0; p < _pathCount; p++)
        {
            if (_m[_path[p, 0], _path[p, 1]] == 1)
            {
                _m[_path[p, 0], _path[p, 1]] = 0;
            }
            else
            {
                _m[_path[p, 0], _path[p, 1]] = 1;
            }
        }
    }

    private void ClearCovers()
    {
        for (var r = 0; r < _numberOfRows; r++)
        {
            _rowCover[r] = 0;
        }

        for (int c = 0; c < _numberOfColumns; c++)
        {
            _columnCover[c] = 0;
        }
    }

    private void ErasePrimes()
    {
        for (var r = 0; r < _numberOfRows; r++)
        {
            for (var c = 0; c < _numberOfColumns; c++)
            {
                if (_m[r, c] == 2)
                {
                    _m[r, c] = 0;
                }
            }
        }
    }

    private void FindAZero(out int row, out int col)
    {
        var r = 0;

        var done = false;

        row = -1;
        col = -1;

        while (!done)
        {
            var c = 0;

            while (true)
            {
                if (_c[r, c] == 0 && _rowCover[r] == 0 && _columnCover[c] == 0)
                {
                    row = r;
                    col = c;
                    done = true;
                }

                c += 1;

                if (c >= _numberOfColumns || done)
                {
                    break;
                }
            }

            r += 1;

            if (r >= _numberOfRows)
            {
                done = true;
            }
        }
    }

    private void FindPrimeInRow(int r, ref int c)
    {
        for (var j = 0; j < _numberOfColumns; j++)
        {
            if (_m[r, j] == 2)
            {
                c = j;
            }
        }
    }

    private void FindSmallest(ref double minval)
    {
        for (var r = 0; r < _numberOfRows; r++)
        {
            for (var c = 0; c < _numberOfColumns; c++)
            {
                if (_rowCover[r] == 0 && _columnCover[c] == 0)
                {
                    if (minval > _c[r, c])
                    {
                        minval = _c[r, c];
                    }
                }
            }
        }
    }

    private void FindStarInColumn(int c, out int r)
    {
        r = -1;

        for (var i = 0; i < _numberOfRows; i++)
        {
            if (_m[i, c] == 1)
            {
                r = i;
            }
        }
    }

    private void FindStarInRow(int row, out int col)
    {
        col = -1;

        for (var c = 0; c < _numberOfColumns; c++)
        {
            if (_m[row, c] == 1)
            {
                col = c;
            }
        }
    }

    private void Initialise()
    {
        var costMatrixCopy = CostMatrix.Copy();

        if (CostMatrix.NumberOfRows > CostMatrix.NumberOfColumns)
        {
            _isTransposed = true;
            costMatrixCopy = costMatrixCopy.Transpose();
        }

        _numberOfRows = costMatrixCopy.NumberOfRows;
        _numberOfColumns = costMatrixCopy.NumberOfColumns;

        _c = costMatrixCopy.Data;

        _path = new int[_numberOfRows + _numberOfColumns + 1, 2];

        _rowCover = new int[_numberOfRows];
        _columnCover = new int[_numberOfColumns];

        _m = new double[_numberOfRows, _numberOfColumns];

        _stepNumber = 1;
    }

    private bool IsStarInRow(int row)
    {
        var tmp = false;

        for (var c = 0; c < _numberOfColumns; c++)
        {
            if (_m[row, c] == 1)
            {
                tmp = true;
            }
        }

        return tmp;
    }

    private void ShowCostMatrix()
    {
        Console.WriteLine("\n");
        Console.WriteLine("------------Step {0}-------------", _stepNumber);

        for (int r = 0; r < _numberOfRows; r++)
        {
            Console.WriteLine();
            Console.Write("     ");

            for (int c = 0; c < _numberOfColumns; c++)
            {
                Console.Write(Convert.ToString(_c[r, c]) + " ");
            }
        }
    }

    private void ShowSolutionMatrix()
    {
        Console.WriteLine("\n");
        Console.WriteLine("------------Solution Matrix-------------");

        for (int r = 0; r < SolutionMatrix.NumberOfRows; r++)
        {
            Console.WriteLine();
            Console.Write("     ");

            for (int c = 0; c < SolutionMatrix.NumberOfColumns; c++)
            {
                Console.Write(Convert.ToString(SolutionMatrix[r, c]) + " ");
            }
        }
    }

    private void ShowTotalCost()
    {
        Console.WriteLine("\n");
        Console.WriteLine("------------Total Cost -------------");

        Console.WriteLine(TotalCost);
    }

    private void ShowMaskMatrix()
    {
        Console.WriteLine();
        Console.Write("\n    ");

        for (int c = 0; c < _numberOfColumns; c++)
        {
            Console.Write(" " + Convert.ToString(_columnCover[c]));
        }

        for (int r = 0; r < _numberOfRows; r++)
        {
            Console.Write("\n  " + Convert.ToString(_rowCover[r]) + "  ");

            for (int c = 0; c < _numberOfColumns; c++)
            {
                Console.Write(Convert.ToString(_m[r, c]) + " ");
            }
        }
    }
}