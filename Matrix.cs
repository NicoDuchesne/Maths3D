using System.Numerics;

namespace Maths3D;

public class Matrix<T> where T : INumber<T>
{
    //Variables
    private T[,] _matrix;
    private int _nbLines;
    private int _nbColumns;
    
    //Properties
    public int NbLines => _nbLines;
    public int NbColumns => _nbColumns;
    
    //Constructors
    public Matrix(int nbLines, int nbColumns)
    {
        this._matrix = new T[nbLines,nbColumns];
        this._nbLines = nbLines;
        this._nbColumns = nbColumns;
    }

    public Matrix(T[,] matrix)
    {
        this._nbLines = matrix.GetLength(0);
        this._nbColumns = matrix.GetLength(1);
        
        this._matrix = new T[_nbLines,_nbColumns];
        this._matrix = matrix;
    }

    //Methods
    public T[,] ToArray2D()
    {
        return _matrix;
    }
    
    //Indexers 
    public T this[int x, int y]
    {
        get => _matrix[x,y];
    }
}