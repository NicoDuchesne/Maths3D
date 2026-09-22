using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;

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

    public T[,] MatrixArray
    {
        get { return _matrixArray; }
        set
        {
            _matrixArray = value;
            _nbLines = value.GetLength(0);
            _nbColumns = value.GetLength(1);
        }
    }
    
    
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
    
    public static Matrix<T> GenerateAugmentedMatrix(Matrix<T> m1, Matrix<T> m2)
    {
        if (m1.NbLines != m2.NbLines)
        {
            throw new AugmentedMatrixException("Matrices cannot generate an augmented matrix");
        }
        
        Matrix<T> result = new Matrix<T>(m1.NbLines, m1.NbColumns + m2.NbColumns);

        for (int i = 0; i < result.NbLines; i++)
        {
            for (int j = 0; j < result.NbColumns; j++)
            {
                if (j < m1.NbColumns)
                {
                    result.MatrixArray[i, j] = m1.MatrixArray[i, j];
                }
                else
                {
                    result.MatrixArray[i, j] = m2.MatrixArray[i, j-m1.NbColumns];
                }
            }
        }
        
        return result;
    }
    
    public (Matrix<T>, Matrix<T>) Split(int x)
    {
        if (x <= 0 || x >= _nbColumns - 1)
        {
            throw new SplitMatrixException("The column index is out of bound, the matrix cannot be split");
        }
        
        Matrix<T> m1 = new Matrix<T>(this._nbLines, x+1);
        Matrix<T> m2 = new Matrix<T>(this._nbLines, (this._nbColumns-1) - x);
        
        for (int i = 0; i < this._nbLines; i++)
        {
            for (int j = 0; j < this._nbColumns; j++)
            {
                if (j < x+1)
                {
                    m1.MatrixArray[i, j] = this.MatrixArray[i, j];
                }
                else
                {
                    m2.MatrixArray[i, j-(x+1)] = this.MatrixArray[i, j];
                }
            }
        }
        
        return (m1, m2);
    }
    
    //Indexers 
    public T this[int x, int y]
    {
        get => _matrixArray[x,y];
        set => _matrixArray[x,y] = value;
    }
    
    //Scalar Mutiplication
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
        Matrix<T> result = new Matrix<T>(m);
        result.Multiply(x);
        return result;
    }
    
    public static Matrix<T> operator *(Matrix<T> left, T right)
    {
        return Matrix<T>.Multiply(left, right);
    }
    
    public static Matrix<T> operator *(T left, Matrix<T> right)
    {
        return Matrix<T>.Multiply(right, left);
    }

    public static Matrix<T> operator -(Matrix<T> m)
    {
        return Matrix<T>.Multiply(m, -T.One);
    }
    
    //Add
    public void Add(Matrix<T> m)
    {
        if (_nbLines != m.NbLines || _nbColumns != m.NbColumns)
        {
            throw new MatrixSumException("Matrices are not of the same size, impossible to add");
        }
        
        for (int i = 0; i < _nbLines; i++)
        {
            for (int j = 0; j < _nbColumns; j++)
            {
                _matrixArray[i, j] += m[i,j];
            }
        }
    }
    
    public static Matrix<T> Add(Matrix<T> left, Matrix<T> right)
    {
        Matrix<T> result = new Matrix<T>(left);
        result.Add(right);
        return result;
    }

    public static Matrix<T> operator +(Matrix<T> left, Matrix<T> right)
    { 
        return Matrix<T>.Add(left, right);
    }
    
    //Subtract
    public void Subtract(Matrix<T> m)
    {
        if (_nbLines != m.NbLines || _nbColumns != m.NbColumns)
        {
            throw new MatrixSubtractionException("Matrices are not of the same size, impossible to subtract");
        }
        
        for (int i = 0; i < _nbLines; i++)
        {
            for (int j = 0; j < _nbColumns; j++)
            {
                _matrixArray[i, j] -= m[i,j];
            }
        }
    }
    
    public static Matrix<T> Subtract(Matrix<T> left, Matrix<T> right)
    {
        Matrix<T> result = new Matrix<T>(left);
        result.Subtract(right);
        return result;
    }

    public static Matrix<T> operator -(Matrix<T> left, Matrix<T> right)
    { 
        return Matrix<T>.Subtract(left, right);
    }
    
    //Matrices Mutiplication
    public Matrix<T> Multiply(Matrix<T> m) 
    {
        if (this._nbColumns != m.NbLines)
        {
            throw new MatrixMultiplyException("To multiply two matrices, the number of columns of first matrix must be equal to the number of lines of second matrix");
        }

        T[,] otherArray = m.ToArray2D();
        Matrix<T> resultMatrix = new Matrix<T>(this._nbLines, m.NbColumns);

        for (int i = 0; i < this._nbColumns; i++) //i : nombre de colonnes m1 ou nombre de lignes m2, peu importe, le nb de fois où on va construire une matrice intermédiaire
        {
            T[,] stepArray = new T[this._nbLines, m.NbColumns]; //matrice intermédiaire (lignes m1, colonnes m2)

            for (int j = 0; j < this._nbLines; j++) //j : nombre de lignes m1
            {
                for (int k = 0; k < m.NbColumns; k++) //k : nombre de colonnes m2
                {
                    stepArray[j, k] = _matrixArray[j,i] * otherArray[i, k];
                    //stepArray[j, k] : on construit la matrice intermédiaire en parcourant ses dimensions j et k
                    //_matrixArray[j,i] : toutes les valeurs d'une colonne i dans m1, j est le step (ligne suivante)
                    //otherArray[i,k] : toutes les valeurs de la ligne i correspondante dans m2, k est le step (colonne suivante)
                }
            }
            //On ajoute le resultat de cette matrice intermédiaire, jusqu'à temriner la multiplication complète
            resultMatrix.Add(new Matrix<T>(stepArray));
        }
        
        return resultMatrix;
        
        // //Version void
        // this._nbLines = resultMatrix.NbLines;
        // this._nbColumns = resultMatrix.NbColumns;
        //
        // this._matrixArray = new T[_nbLines,_nbColumns];
        // this._matrixArray = resultMatrix.ToArray2D();
    }
    
    public static Matrix<T> Multiply(Matrix<T> left, Matrix<T> right)
    {
        return left.Multiply(right);
        
        // //version avec void Multiply()
        // Matrix<T> result = new Matrix<T>(left);
        // result.Multiply(right);
        // return result;
    }
    
    public static Matrix<T> operator *(Matrix<T> left, Matrix<T> right)
    {
        return Matrix<T>.Multiply(left, right);
    }
    
    //Transpose
    
    public Matrix<T> Transpose()
    {
        T[,] result = new T[_nbColumns, _nbLines];
        
        for (int i = 0; i < _nbLines; i++)
        {
            for (int j = 0; j < _nbColumns; j++)
            {
                result[j,i] = _matrixArray[i, j];
            }
        }
        return new Matrix<T>(result);
        
        // //version void 
        // T[,] result = new T[_nbColumns, _nbLines];
        //
        // for (int i = 0; i < _nbLines; i++)
        // {
        //     for (int j = 0; j < _nbColumns; j++)
        //     {
        //         result[j,i] = _matrixArray[i, j];
        //     }
        // }
        //
        // int temp = this._nbColumns;
        // this._nbLines = this._nbColumns;
        // this._nbColumns = temp;
        //
        // this._matrixArray = new T[_nbLines,_nbColumns];
        // this._matrixArray = result;
    }

    public static Matrix<T> Transpose(Matrix<T> m)
    {
        return m.Transpose();
        
        // //version avec void Transpose()
        // Matrix<T> result = new Matrix<T>(m);
        // result.Transpose();
        // return result;
    }
    
    //Inverse
    public Matrix<T> InvertByRowReduction()
    {
        if (_nbLines != _nbColumns)
        {
            throw new MatrixInvertException("Matrix is not square, cannot be inverted");
        }
        
        Matrix<T> identity = Matrix<T>.Identity(this._nbLines);

        try
        {
            (Matrix<T> m1, Matrix<T> m2) reducted = MatrixRowReductionAlgorithm.Apply(this, identity, true);
            return reducted.m2;
        }
        catch (MatrixException e)
        {
            throw new MatrixInvertException("Row and columns are all zeros");
        }
    }
    
    public static Matrix<T> InvertByRowReduction(Matrix<T> m)
    {
        return m.InvertByRowReduction();
    }
    
    
    public Matrix<T> InvertByDeterminant()
    {
        if (_nbLines != _nbColumns)
        {
            throw new MatrixInvertException("Matrix is not square, cannot be inverted");
        }

        T det = Determinant();
        if (Determinant() == T.Zero)
        {
            throw new MatrixInvertException("Determinant is null, cannot be inverted");
        }

        Matrix<T> adj = Adjugate();
        Matrix<T> inverted = (T.One / det) * adj;
        
        return inverted;

    }
    
    public static Matrix<T> InvertByDeterminant(Matrix<T> m)
    {
        return m.InvertByDeterminant();
    }
    
    //Sub Matrix

    public Matrix<T> SubMatrix(int x, int y)
    {
        if (x >= _nbLines || y >= _nbColumns || _nbLines == 1 || _nbColumns == 1)
        {
            throw new MatrixSubException("Wrong indexes, cannot submatrix");
        }
        
        T[,] result = new T[_nbLines-1, _nbColumns-1];

        int m = 0;
        int n = 0;
        for (int i = 0; i < _nbLines; i++)
        {
            n = 0;
            if (i == x) continue;
            
            for (int j = 0; j < _nbColumns; j++)
            {
                if (j == y) continue;
                
                result[m, n] = _matrixArray[i, j];
                n++;
            }

            m++;
        }
        
        return new Matrix<T>(result);
    }
    
    public static Matrix<T> SubMatrix(Matrix<T> m, int x, int y)
    {
        return m.SubMatrix(x, y);
    }
    
    //Determinant

    public T Determinant()
    {
        if (_nbLines != _nbColumns)
        {
            throw new MatrixDeterminantException("Matrix is not square, cannot calculate determinant");
        }

        if (_nbLines == 1 && _nbColumns == 1) return MatrixArray[0, 0];

        if (_nbLines == 2 && _nbColumns == 2)
        {
            return MatrixArray[0, 0] * MatrixArray[1, 1] - MatrixArray[0, 1] * MatrixArray[1, 0];
        }

        T sum = T.Zero;
        for (int i = 0; i < _nbColumns; i++)
        {
            Matrix<T> subMatrix = SubMatrix(0, i);
            
            T det = subMatrix.Determinant();
            det *= MatrixArray[0, i];
            if (i % 2 != 0) det *= -T.One;
            
            sum += det;
        }

        return sum;
    }
    
    public static T Determinant(Matrix<T> m)
    {
        return m.Determinant();
    }
    
    //Adjugate

    public Matrix<T> Adjugate()
    {
        if (_nbLines != _nbColumns)
        {
            throw new MatrixAdjugateException("Matrix is not square, cannot adjugate");
        }
        
        Matrix<T> m = this.Transpose();
        T[,] result = new T[m._nbLines, m._nbColumns];
        
        for (int i = 0; i < m._nbLines; i++)
        {
            for (int j = 0; j < m._nbColumns; j++)
            {
                Matrix<T> subMatrix = m.SubMatrix(i, j);
                T det = subMatrix.Determinant();
                if (i % 2 == 0 && j % 2 != 0 || i % 2 != 0 && j % 2 == 0) det *= -T.One;
                result[i, j] = det;
            }
        }
        
        return new Matrix<T>(result);
    }
    
    public static Matrix<T> Adjugate(Matrix<T> m)
    {
        return m.Adjugate();
    }
    
    
}
