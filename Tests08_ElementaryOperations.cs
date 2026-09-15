using Maths3D;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Maths_Matrices.Tests;

[TestFixture]
public class Tests08_ElementaryOperations
{

    #region Swaps Tests

    [Test]
    public void TestSwapLines()
    {
        Matrix<int> m = new Matrix<int>(new[,]
        {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        });

        MatrixElementaryOperations.SwapLines(m, 0, 1);
        ClassicAssert.AreEqual(new[,]
        {
            { 4, 5, 6 },
            { 1, 2, 3 },
            { 7, 8, 9 }
        }, m.ToArray2D());

        MatrixElementaryOperations.SwapLines(m, 0, 2);
        ClassicAssert.AreEqual(new[,]
        {
            { 7, 8, 9 },
            { 1, 2, 3 },
            { 4, 5, 6 }
        }, m.ToArray2D());

        MatrixElementaryOperations.SwapLines(m, 2, 1);
        ClassicAssert.AreEqual(new[,]
        {
            { 7, 8, 9 },
            { 4, 5, 6 },
            { 1, 2, 3 }
        }, m.ToArray2D());
    }

    [Test]
    public void TestSwapColumns()
    {
        Matrix<int> m = new Matrix<int>(new[,]
        {
            { 1, 4, 7 },
            { 2, 5, 8 },
            { 3, 6, 9 }
        });
    
        MatrixElementaryOperations.SwapColumns(m, 0, 1);
        ClassicAssert.AreEqual(new[,]
        {
            { 4, 1, 7 },
            { 5, 2, 8 },
            { 6, 3, 9 }
        }, m.ToArray2D());
    
        MatrixElementaryOperations.SwapColumns(m, 0, 2);
        ClassicAssert.AreEqual(new[,]
        {
            { 7, 1, 4 },
            { 8, 2, 5 },
            { 9, 3, 6 }
        }, m.ToArray2D());
    
        MatrixElementaryOperations.SwapColumns(m, 2, 1);
        ClassicAssert.AreEqual(new[,]
        {
            { 7, 4, 1 },
            { 8, 5, 2 },
            { 9, 6, 3 }
        }, m.ToArray2D());
    }

    #endregion

    #region Multiply Lines/Columns Tests
    
    [Test]
    public void TestMultiplyLine()
    {
        Matrix<int> m = new Matrix<int>(new[,]
        {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        });
    
        MatrixElementaryOperations.MultiplyLine(m, 0, 2);
        ClassicAssert.AreEqual(new[,]
        {
            { 2, 4, 6 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        }, m.ToArray2D());
    
        MatrixElementaryOperations.MultiplyLine(m, 1, 3);
        ClassicAssert.AreEqual(new[,]
        {
            { 2, 4, 6 },
            { 12, 15, 18 },
            { 7, 8, 9 }
        }, m.ToArray2D());
    
        MatrixElementaryOperations.MultiplyLine(m, 2, 10);
        ClassicAssert.AreEqual(new[,]
        {
            { 2, 4, 6 },
            { 12, 15, 18 },
            { 70, 80, 90 }
        }, m.ToArray2D());
    
        ClassicAssert.Throws<MatrixScalarZeroException>(() => { MatrixElementaryOperations.MultiplyLine(m, 0, 0); });
    }
    
    [Test]
    public void TestMultiplyColumn()
    {
        Matrix<int> m = new Matrix<int>(new[,]
        {
            { 1, 4, 7 },
            { 2, 5, 8 },
            { 3, 6, 9 }
        });
    
        MatrixElementaryOperations.MultiplyColumn(m, 0, 2);
        ClassicAssert.AreEqual(new[,]
        {
            { 2, 4, 7 },
            { 4, 5, 8 },
            { 6, 6, 9 }
        }, m.ToArray2D());
    
        MatrixElementaryOperations.MultiplyColumn(m, 1, 3);
        ClassicAssert.AreEqual(new[,]
        {
            { 2, 12, 7 },
            { 4, 15, 8 },
            { 6, 18, 9 }
        }, m.ToArray2D());
    
        MatrixElementaryOperations.MultiplyColumn(m, 2, 10);
        ClassicAssert.AreEqual(new[,]
        {
            { 2, 12, 70 },
            { 4, 15, 80 },
            { 6, 18, 90 }
        }, m.ToArray2D());
    
        ClassicAssert.Throws<MatrixScalarZeroException>(() => { MatrixElementaryOperations.MultiplyColumn(m, 0, 0); });
    }
    
    #endregion
    
    #region Add Lines/Columns to another (with factor)
    
    [Test]
    public void TestAddLineToAnother()
    {
        Matrix<int> m = new Matrix<int>(new[,]
        {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        });
    
        //Parameters (in order) 
        //Matrix to modify
        //Line index to apply
        //Line index to modify
        //Factor to apply to second line
        // 1 + 4*2 = 9
        // 2 + 5*2 = 12
        // 3 + 6*2 = 15
        MatrixElementaryOperations.AddLineToAnother(m, 1, 0, 2);
        ClassicAssert.AreEqual(new[,]
        {
            { 9, 12, 15 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        }, m.ToArray2D());
    }
    
    [Test]
    public void TestAddColumnToAnother()
    {
        //Parameters (in order) 
        //Matrix to modify
        //Column index to apply
        //Column index to modify
        //Factor to apply to second column
        // 1 + 4*2 = 9
        // 2 + 5*2 = 12
        // 3 + 6*2 = 15
        Matrix<int> m = new Matrix<int>(new[,]
        {
            { 1, 4, 7 },
            { 2, 5, 8 },
            { 3, 6, 9 }
        });
    
        MatrixElementaryOperations.AddColumnToAnother(m, 1, 0, 2);
        ClassicAssert.AreEqual(new[,]
        {
            { 9, 4, 7 },
            { 12, 5, 8 },
            { 15, 6, 9 }
        }, m.ToArray2D());
    }
    
    #endregion

}