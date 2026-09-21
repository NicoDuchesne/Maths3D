using Maths3D;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Maths_Matrices.Tests;

[TestFixture, DefaultFloatingPointTolerance(0.001f)]
public class Tests11_InvertMatricesUsingRowReduction
{
    [Test]
    public void TestInvertMatrixInstance()
    {
        Matrix<float> m = new Matrix<float>(new[,]
        {
            { 2f, 3f, 8f },
            { 6f, 0f, -3f },
            { -1f, 3f, 2f },
        });

        Matrix<float> mInverted = m.InvertByRowReduction();

        ClassicAssert.AreEqual(new[,]
        {
            { 0.066f, 0.133f, -0.066f },
            { -0.066f, 0.088f, 0.4f },
            { 0.133f, -0.066f, -0.133f }
        }, mInverted.ToArray2D());
    }

    [Test]
    public void TestInvertMatrixStatic()
    {
        Matrix<float> m = new Matrix<float>(new[,]
        {
            { 1f, 2f },
            { 3f, 4f },
        });
    
        Matrix<float> mInverted = Matrix<float>.InvertByRowReduction(m);
    
        ClassicAssert.AreEqual(new[,]
        {
            { -2f, 1f },
            { 1.5f, -0.5f },
        }, mInverted.ToArray2D());
    }
    
    [Test]
    public void TestInvertImpossibleMatrix()
    {
        Matrix<float> m = new Matrix<float>(new[,]
        {
            { 1f, 2f, 3f },
            { 4f, 5f, 6f },
            { 7f, 8f, 9f },
        });
    
        ClassicAssert.Throws<MatrixInvertException>(() =>
        {
            Matrix<float> mInverted = m.InvertByRowReduction();
        });
    }
    
    [Test]
    public void TestInvertMatrixWithOnlyNegativesValuesOnFirstColumn()
    {
        Matrix<float> m = new Matrix<float>(new[,]
        {
            { 0f, 3f, 1f },
            { 0f, 1f, 1f },
            { -9f, 5f, 5f },
        });
    
        Matrix<float> mInverted = m.InvertByRowReduction();
    
        ClassicAssert.AreEqual(new[,]
        {
            { 0f, 0.555f, -0.111f },
            { 0.5f, -0.5f, 0f },
            { -0.5f, 1.5f, 0f },
        }, mInverted.ToArray2D());
    }
}