using System.Numerics;

namespace Maths3D;

public class Matrix<T> where T : INumber<T>
{
    //Variables
    private T[,] _matrixArray;
    private int _nbLines;
    private int _nbColumns;
    
    //Properties
    public int NbLines => _nbLines;
    public int NbColumns => _nbColumns;
    
    //Constructors
    public Matrix(int nbLines, int nbColumns)
    {
        this._nbLines = nbLines;
        this._nbColumns = nbColumns;
        this._matrixArray = new T[_nbLines,_nbColumns];
    }

    public Matrix(T[,] array)
    {
        this._nbLines = array.GetLength(0);
        this._nbColumns = array.GetLength(1);
        
        this._matrixArray = new T[_nbLines,_nbColumns];
        this._matrixArray = array;
    }
    
    public Matrix(Matrix<T> matrix)
    {
        this._nbLines = matrix.NbLines;
        this._nbColumns = matrix.NbColumns;
        
        this._matrixArray = new T[_nbLines,_nbColumns];
        this._matrixArray = matrix.ToArray2D();
    }

    //Methods
    public T[,] ToArray2D()
    {
        T[,] rebuiltArray = new T[_nbLines, _nbColumns];

        for (int i = 0; i < _nbLines; i++)
        {
            for (int j = 0; j < _nbColumns; j++)
            {
                rebuiltArray[i, j] = this._matrixArray[i, j];
            }
        }
        
        return rebuiltArray;
    }

    public static Matrix<T> Identity(int size)
    {
        T[,] newArray = new T[size, size];

        for (int i = 0; i < size; i++)
        {
            newArray[i, i] = T.One;
        }
        
        return new Matrix<T>(newArray);
    }

    public bool IsIdentity()
    {
        if (_nbLines != _nbColumns) return false;
        
        for (int i = 0; i < _nbLines; i++)
        {
            for (int j = 0; j < _nbColumns; j++)
            {
                if (i == j && _matrixArray[i, j] != T.One) return false;
                if (i != j && _matrixArray[i, j] != T.Zero) return false;
            }
        }
        
        return true;
    }

    public void Multiply(T x)
    {
        for (int i = 0; i < _nbLines; i++)
        {
            for (int j = 0; j < _nbColumns; j++)
            {
                _matrixArray[i, j] *= x;
            }
        }
    }

    public static Matrix<T> Multiply(Matrix<T> m, T x)
    {
        Matrix<T> result = new Matrix<T>(m.ToArray2D());
        result.Multiply(x);
        return result;

    }
    
    //Indexers 
    public T this[int x, int y]
    {
        get => _matrixArray[x,y];
        set => _matrixArray[x,y] = value;
    }
    
    //Operators 
    public static Matrix<T> operator *(Matrix<T> left, T right)
    {
        Matrix<T> result = new Matrix<T>(left.ToArray2D());
        result.Multiply(right);
        return result;
    }
    
    public static Matrix<T> operator *(T left, Matrix<T> right)
    {
        Matrix<T> result = new Matrix<T>(right.ToArray2D());
        result.Multiply(left);
        return result;
    }

    public static Matrix<T> operator -(Matrix<T> m)
    {
        Matrix<T> result = new Matrix<T>(m.ToArray2D());
        result.Multiply(-T.One);
        return result;
    }
}