using System.Numerics;

namespace Maths3D;

public static class MatrixElementaryOperations
{
    public static void SwapLines<T>(Matrix<T> m, int x, int y) where T : INumber<T>
    {
        if (x < 0 || y < 0 || x >= m.NbLines || y >= m.NbLines)
        {
            throw new MatrixElementaryOperationsException("The lines indexes given are out of bounds, swapping lines is impossible");
        }
        
        for (int i = 0; i < m.NbColumns; i++)
        {
            T temp = m.MatrixArray[x, i];
            m.MatrixArray[x, i] = m.MatrixArray[y, i];
            m.MatrixArray[y, i] = temp;
        }
    }
    
    public static void SwapColumns<T>(Matrix<T> m, int x, int y) where T : INumber<T>
    {
        if (x < 0 || y < 0 || x >= m.NbColumns || y >= m.NbColumns)
        {
            throw new MatrixElementaryOperationsException("The column indexes given are out of bounds, swapping columns is impossible");
        }
        
        for (int i = 0; i < m.NbLines; i++)
        {
            T temp = m.MatrixArray[i, x];
            m.MatrixArray[i, x] = m.MatrixArray[i, y];
            m.MatrixArray[i, y] = temp;
        }
    }
    
    public static void MultiplyLine<T>(Matrix<T> m, int line, T factor) where T : INumber<T>
    {
        if (line < 0 || line >= m.NbLines)
        {
            throw new MatrixElementaryOperationsException("The line index given is out of bounds, multiplying line is impossible");
        }

        if (factor == T.Zero)
        {
            throw new MatrixScalarZeroException("The factor is zero, multiplying line is impossible");
        }
        
        for (int i = 0; i < m.NbColumns; i++)
        {
            m.MatrixArray[line, i] *= factor;
        }
    }
    
    public static void MultiplyColumn<T>(Matrix<T> m, int column, T factor) where T : INumber<T>
    {
        if (column < 0 || column >= m.NbColumns)
        {
            throw new MatrixElementaryOperationsException("The column index given is out of bounds, multiplying column is impossible");
        }

        if (factor == T.Zero)
        {
            throw new MatrixScalarZeroException("The factor is zero, multiplying line is impossible");
        }
        
        for (int i = 0; i < m.NbLines; i++)
        {
            m.MatrixArray[i, column] *= factor;
        }
    }
    
    public static void AddLineToAnother<T>(Matrix<T> m, int x, int y, T factor) where T : INumber<T>
    {
        if (x < 0 || y < 0 || x >= m.NbLines || y >= m.NbLines)
        {
            throw new MatrixElementaryOperationsException("The lines indexes given are out of bounds, adding lines is impossible");
        }
        
        if (factor == T.Zero)
        {
            throw new MatrixScalarZeroException("The factor is zero, multiplying line is impossible");
        }
        
        for (int i = 0; i < m.NbColumns; i++)
        {
            m.MatrixArray[y, i] += m.MatrixArray[x, i] * factor;
        }
    }
    
    public static void AddColumnToAnother<T>(Matrix<T> m, int x, int y, T factor) where T : INumber<T>
    {
        if (x < 0 || y < 0 || x >= m.NbColumns || y >= m.NbColumns)
        {
            throw new MatrixElementaryOperationsException("The columns indexes given are out of bounds, adding columns is impossible");
        }
        
        if (factor == T.Zero)
        {
            throw new MatrixScalarZeroException("The factor is zero, multiplying line is impossible");
        }
        
        for (int i = 0; i < m.NbLines; i++)
        {
            m.MatrixArray[i, y] += m.MatrixArray[i, x] * factor;
        }
    }
}