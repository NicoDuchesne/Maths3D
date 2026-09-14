using Maths3D;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Maths_Matrices.Tests;

[TestFixture]
public class Tests07_TransposeMatrices
{
    [Test]
    public void TestTransposeMatrixInstance()
    {
        Matrix<int> m1 = new Matrix<int>(new[,]
        {
            { 1, 2, 3 },
            { 4, 5, 6 }
        });

        Matrix<int> m1t = m1.Transpose();

        ClassicAssert.AreEqual(new[,]
        {
            { 1, 4 },
            { 2, 5 },
            { 3, 6 }
        }, m1t.ToArray2D());
        
        // //test en void
        // m1.Transpose();
        //
        // ClassicAssert.AreEqual(new[,]
        // {
        //     { 1, 4 },
        //     { 2, 5 },
        //     { 3, 6 }
        // }, m1.ToArray2D());
    }

    [Test]
    public void TestTransposeMatrixStatic()
    {
        Matrix<int> m1 = new Matrix<int>(new[,]
        {
            { 1, 2, 3 },
            { 4, 5, 6 }
        });
    
        Matrix<int> m1t = Matrix<int>.Transpose(m1);
    
        ClassicAssert.AreEqual(new[,]
        {
            { 1, 4 },
            { 2, 5 },
            { 3, 6 }
        }, m1t.ToArray2D());
    }
}