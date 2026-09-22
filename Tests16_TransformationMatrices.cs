using System.Numerics;
using Maths3D;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using Vector4 = Maths3D.Vector4;

namespace Maths_Matrices.Tests;

[TestFixture, DefaultFloatingPointTolerance(0.001f)]
public class Tests16_TransformationMatrices
{
    [Test]
    public void TestVector4ToMatrixFloatImplicit()
    {
        Vector4 v = new Vector4(5f, 12f, 4f, 1f);
        //You will need an implicit operator to convert a Vector4 into a Matrix<float>
        //More infos here => https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/user-defined-conversion-operators
        Matrix<float> vMatrix = v;

        ClassicAssert.AreEqual(new[,]
        {
            { 5f },
            { 12f },
            { 4f },
            { 1f },
        }, vMatrix.ToArray2D());
    }

    [Test]
    public void TestTranslatePoint()
    {
        Vector4 v = new Vector4(1f, 0f, 0f, 1f);
        Matrix<float> m = new Matrix<float>(new[,]
        {
            { 1f, 0f, 0f, 5f },
            { 0f, 1f, 0f, 3f },
            { 0f, 0f, 1f, 1f },
            { 0f, 0f, 0f, 1f },
        });
    
        Vector4 vTransformed = m * v;
        ClassicAssert.AreEqual(vTransformed.x, 6f);
        ClassicAssert.AreEqual(vTransformed.y, 3f);
        ClassicAssert.AreEqual(vTransformed.z, 1f);
    
        Vector4 vTransformedInverted = m.InvertByRowReduction() * vTransformed;
        ClassicAssert.AreEqual(1f, vTransformedInverted.x);
        ClassicAssert.AreEqual(0f, vTransformedInverted.y);
        ClassicAssert.AreEqual(0f, vTransformedInverted.z);
    
        vTransformedInverted = m.InvertByDeterminant() * vTransformed;
        ClassicAssert.AreEqual(1f, vTransformedInverted.x);
        ClassicAssert.AreEqual(0f, vTransformedInverted.y);
        ClassicAssert.AreEqual(0f, vTransformedInverted.z);
    }
    
    [Test]
    public void TestTranslateDirection()
    {
        Vector4 v = new Vector4(1f, 0f, 0f, 0f);
        Matrix<float> m = new Matrix<float>(new[,]
        {
            { 1f, 0f, 0f, 5f },
            { 0f, 1f, 0f, 3f },
            { 0f, 0f, 1f, 1f },
            { 0f, 0f, 0f, 1f },
        });
        Vector4 vTransformed = m * v;
    
        ClassicAssert.AreEqual(1f, vTransformed.x);
        ClassicAssert.AreEqual(0f, vTransformed.y);
        ClassicAssert.AreEqual(0f, vTransformed.z);
    
        Vector4 vTransformedInverted = m.InvertByRowReduction() * vTransformed;
        ClassicAssert.AreEqual(1f, vTransformedInverted.x);
        ClassicAssert.AreEqual(0f, vTransformedInverted.y);
        ClassicAssert.AreEqual(0f, vTransformedInverted.z);
    
        vTransformedInverted = m.InvertByDeterminant() * vTransformed;
        ClassicAssert.AreEqual(1f, vTransformedInverted.x);
        ClassicAssert.AreEqual(0f, vTransformedInverted.y);
        ClassicAssert.AreEqual(0f, vTransformedInverted.z);
    }
    
    [Test]
    public void TestScalePoint()
    {
        Vector4 v = new Vector4(2f, 1f, 3f, 1f);
        Matrix<float> m = new Matrix<float>(new[,]
        {
            { 0.5f, 0f, 0f, 0f },
            { 0.0f, 2f, 0f, 0f },
            { 0.0f, 0f, 3f, 0f },
            { 0.0f, 0f, 0f, 1f },
        });
    
        Vector4 vTransformed = m * v;
        ClassicAssert.AreEqual(1f, vTransformed.x);
        ClassicAssert.AreEqual(2f, vTransformed.y);
        ClassicAssert.AreEqual(9f, vTransformed.z);
    
        Vector4 vTransformedInverted = m.InvertByRowReduction() * vTransformed;
        ClassicAssert.AreEqual(2f, vTransformedInverted.x);
        ClassicAssert.AreEqual(1f, vTransformedInverted.y);
        ClassicAssert.AreEqual(3f, vTransformedInverted.z);
    
        vTransformedInverted = m.InvertByDeterminant() * vTransformed;
        ClassicAssert.AreEqual(2f, vTransformedInverted.x);
        ClassicAssert.AreEqual(1f, vTransformedInverted.y);
        ClassicAssert.AreEqual(3f, vTransformedInverted.z);
    }
    
    [Test]
    public void TestRotatePoint()
    {
        Vector4 v = new Vector4(1f, 4f, 7f, 1f);
        double a = Math.PI / 2d;
        float cosA = (float)Math.Cos(a);
        float sinA = (float)Math.Sin(a);
        Matrix<float> m = new Matrix<float>(new[,]
        {
            { cosA, -sinA, 0f, 0f },
            { sinA, cosA, 0f, 0f },
            { 0f, 0f, 1f, 0f },
            { 0f, 0f, 0f, 1f },
        });
    
        Vector4 vTransformed = m * v;
        ClassicAssert.AreEqual(-4f, vTransformed.x);
        ClassicAssert.AreEqual(1f, vTransformed.y);
        ClassicAssert.AreEqual(7f, vTransformed.z);
    
        Vector4 vTransformedInverted = m.InvertByRowReduction() * vTransformed;
        ClassicAssert.AreEqual(1f, vTransformedInverted.x);
        ClassicAssert.AreEqual(4f, vTransformedInverted.y);
        ClassicAssert.AreEqual(7f, vTransformedInverted.z);
    
        vTransformedInverted = m.InvertByDeterminant() * vTransformed;
        ClassicAssert.AreEqual(1f, vTransformedInverted.x);
        ClassicAssert.AreEqual(4f, vTransformedInverted.y);
        ClassicAssert.AreEqual(7f, vTransformedInverted.z);
    }
}