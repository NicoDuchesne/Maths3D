using Maths3D;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Maths_Matrices.Tests;

[TestFixture, DefaultFloatingPointTolerance(0.001f)]
public class Tests17_TransformLocalPosition
{
    [Test]
    public void TestDefaultValues()
    {
        Transform t = new Transform();

        //Default Position
        ClassicAssert.AreEqual(0f, t.LocalPosition.x);
        ClassicAssert.AreEqual(0f, t.LocalPosition.y);
        ClassicAssert.AreEqual(0f, t.LocalPosition.z);

        //Default Translation Matrix
        ClassicAssert.AreEqual(new[,]
        {
            { 1f, 0f, 0f, 0f },
            { 0f, 1f, 0f, 0f },
            { 0f, 0f, 1f, 0f },
            { 0f, 0f, 0f, 1f },
        }, t.LocalTranslationMatrix.ToArray2D());
    }

    [Test]
    public void TestTransformChangePosition()
    {
        Transform t = new Transform();
    
        //Translation
        t.LocalPosition = new Vector3(5f, 2f, 1f);
        ClassicAssert.AreEqual(new[,]
        {
            { 1f, 0f, 0f, 5f },
            { 0f, 1f, 0f, 2f },
            { 0f, 0f, 1f, 1f },
            { 0f, 0f, 0f, 1f },
        }, t.LocalTranslationMatrix.ToArray2D());
    }

}