using Maths3D;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Maths_Matrices.Tests;

[TestFixture, DefaultFloatingPointTolerance(0.001f)]
public class Tests10_RowReduction
{
    [Test]
    public void TestApplyRowReduction_CourseExample()
    {
        Matrix<float> m1 = new Matrix<float>(new[,]
        {
            { 3f, 2f, -3f },
            { 4f, -3f, 6f },
            { 1f, 0f, -1f }
        });

        Matrix<float> m2 = new Matrix<float>(new[,]
        {
            { -13f },
            { 7f },
            { -5f }
        });

        //If you need a min or a max value for generic numbers inside row reduction algorithm, see IMinMaxValue<T> interface
        //https://learn.microsoft.com/en-us/dotnet/api/system.numerics.iminmaxvalue-1

        //This method use deconstruction tuple system
        //More information here =>
        //https://docs.microsoft.com/fr-fr/dotnet/csharp/fundamentals/functional/deconstruct
        (m1, m2) = MatrixRowReductionAlgorithm.Apply(m1, m2);
        ClassicAssert.AreEqual(new[,]
        {
            { 1f, 0f, 0f },
            { 0f, 1f, 0f },
            { 0f, 0f, 1f }
        }, m1.ToArray2D());

        ClassicAssert.AreEqual(new[,]
        {
            { -2f },
            { 1f },
            { 3f }
        }, m2.ToArray2D());
    }

    [Test]
    public void TestApplyRowReduction_Exercise()
    {
        Matrix<float> m1 = new Matrix<float>(new[,]
        {
            { 2f, 1f, 3f },
            { 0f, 1f, -1f },
            { 1f, 3f, -1f }
        });
    
        Matrix<float> m2 = new Matrix<float>(new[,]
        {
            { 0f },
            { 0f },
            { 0f }
        });
    
        //If you need a min or a max value for generic numbers inside row reduction algorithm, see IMinMaxValue<T> interface
        //https://learn.microsoft.com/en-us/dotnet/api/system.numerics.iminmaxvalue-1
    
        //This method use deconstruction tuple system
        //More information here =>
        //https://docs.microsoft.com/fr-fr/dotnet/csharp/fundamentals/functional/deconstruct
        (m1, m2) = MatrixRowReductionAlgorithm.Apply(m1, m2);
        ClassicAssert.AreEqual(new[,]
        {
            { 1f, 0f, 2f },
            { 0f, 1f, -1f },
            { 0f, 0f, 0f }
        }, m1.ToArray2D());
    
        ClassicAssert.AreEqual(new[,]
        {
            { 0f },
            { 0f },
            { 0f }
        }, m2.ToArray2D());
    }
    
    [Test]
    public void TestApplyRowReduction_ExceptionWhenRowColumsAreAllZeros()
    {
        Matrix<float> m1 = new Matrix<float>(new[,]
        {
            { 1f, 2f, 3f },
            { 4f, 5f, 6f },
            { 7f, 8f, 9f },
        });
    
        Matrix<float> m2 = Matrix<float>.Identity(3);
    
        ClassicAssert.Throws<MatrixRowReductionException>(() => { (m1, m2) = MatrixRowReductionAlgorithm.Apply(m1, m2, true); });
    }
}