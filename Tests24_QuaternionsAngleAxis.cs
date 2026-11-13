using Maths3D;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Maths_Matrices.Tests;

[TestFixture, DefaultFloatingPointTolerance(0.01f)]
public class Tests24_QuaternionsAngleAxis
{
    [Test]
    public void TestQuaternionAngleAxisX()
    {
        //90 degree around X axis
        float angle = 90f;
        Vector3 axis = new Vector3(1f, 0f, 0f);
        Quaternion q = Quaternion.AngleAxis(angle, axis);
        ClassicAssert.AreEqual(0.71f, q.x);
        ClassicAssert.AreEqual(0f, q.y);
        ClassicAssert.AreEqual(0f, q.z);
        ClassicAssert.AreEqual(0.71f, q.w);
    }

    [Test]
    public void TestQuaternionAngleAxisY()
    {
        //90 degree around Y axis
        float angle = 90f;
        Vector3 axis = new Vector3(0f, 1f, 0f);
        Quaternion q = Quaternion.AngleAxis(angle, axis);
        ClassicAssert.AreEqual(0f, q.x);
        ClassicAssert.AreEqual(0.71f, q.y);
        ClassicAssert.AreEqual(0f, q.z);
        ClassicAssert.AreEqual(0.71f, q.w);
    }
    
    [Test]
    public void TestQuaternionAngleAxisZ()
    {
        //90 degree around Z axis
        float angle = 90f;
        Vector3 axis = new Vector3(0f, 0f, 1f);
        Quaternion q = Quaternion.AngleAxis(angle, axis);
        ClassicAssert.AreEqual(0f, q.x);
        ClassicAssert.AreEqual(0f, q.y);
        ClassicAssert.AreEqual(0.71f, q.z);
        ClassicAssert.AreEqual(0.71f, q.w);
    }
    
    [Test]
    public void TestQuaternionCustomAxis()
    {
        //60 degree around Vector(0,3,4)
        float angle = 60f;
        Vector3 axis = new Vector3(0f, 3f, 4f);
        Quaternion q = Quaternion.AngleAxis(angle, axis);
        ClassicAssert.AreEqual(0f, q.x);
        ClassicAssert.AreEqual(0.3f, q.y);
        ClassicAssert.AreEqual(0.4f, q.z);
        ClassicAssert.AreEqual(0.87f, q.w);
    }
}