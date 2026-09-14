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
        this._matrixArray = new T[nbLines,nbColumns];
        this._nbLines = nbLines;
        this._nbColumns = nbColumns;
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
    
    //Indexers 
    public T this[int x, int y]
    {
        get => _matrixArray[x,y];
        set => _matrixArray[x,y] = value;
    }
}