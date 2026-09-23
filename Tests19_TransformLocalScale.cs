using Maths3D;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Maths_Matrices.Tests;

[TestFixture, DefaultFloatingPointTolerance(0.001f)]
public class Tests19_TransformLocalScale
{
    [Test]
    public void TestDefaultValues()
    {
        Transform t = new Transform();

        //Default Scale
        ClassicAssert.AreEqual(1f, t.LocalScale.x);
        ClassicAssert.AreEqual(1f, t.LocalScale.y);
        ClassicAssert.AreEqual(1f, t.LocalScale.z);

        //Default Matrix
        ClassicAssert.AreEqual(new[,]
        {
            { 1f, 0f, 0f, 0f },
            { 0f, 1f, 0f, 0f },
            { 0f, 0f, 1f, 0f },
            { 0f, 0f, 0f, 1f },
        }, t.LocalScaleMatrix.ToArray2D());
    }

    [Test]
    public void TestChangeScale()
    {
        Transform t = new Transform();
    
        //Scale X
        t.LocalScale = new Vector3(2f, 1f, 1f);
        ClassicAssert.AreEqual(new[,]
        {
            { 2f, 0f, 0f, 0f },
            { 0f, 1f, 0f, 0f },
            { 0f, 0f, 1f, 0f },
            { 0f, 0f, 0f, 1f },
        }, t.LocalScaleMatrix.ToArray2D());
    
        //Scale Y
        t.LocalScale = new Vector3(1f, 5f, 1f);
        ClassicAssert.AreEqual(new[,]
        {
            { 1f, 0f, 0f, 0f },
            { 0f, 5f, 0f, 0f },
            { 0f, 0f, 1f, 0f },
            { 0f, 0f, 0f, 1f },
        }, t.LocalScaleMatrix.ToArray2D());
    
        //Scale Z
        t.LocalScale = new Vector3(1f, 1f, 23f);
        ClassicAssert.AreEqual(new[,]
        {
            { 1f, 0f, 0f, 0f },
            { 0f, 1f, 0f, 0f },
            { 0f, 0f, 23f, 0f },
            { 0f, 0f, 0f, 1f },
        }, t.LocalScaleMatrix.ToArray2D());
    }
}