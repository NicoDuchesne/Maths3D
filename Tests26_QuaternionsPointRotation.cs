using Maths3D;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Maths_Matrices.Tests;

[TestFixture, DefaultFloatingPointTolerance(0.01f)]
public class Tests26_QuaternionsPointRotation
{
    [Test]
    public void TestQuaternionPointRotation1()
    {
        Vector3 point = new Vector3(1f, 0f, 0f);
        Quaternion rotateZAxis = Quaternion.AngleAxis(90f, new Vector3(0f, 0f, 1f));

        Vector3 rotatedPoint = rotateZAxis * point;

        ClassicAssert.AreEqual(0f, rotatedPoint.x);
        ClassicAssert.AreEqual(1f, rotatedPoint.y);
        ClassicAssert.AreEqual(0f, rotatedPoint.z);
    }

    [Test]
    public void TestQuaternionPointRotation2()
    {
        Vector3 point = new Vector3(0f, 2f, 1f);
        Quaternion rotateXAxis = Quaternion.AngleAxis(45f, new Vector3(1f, 0f, 0f));
    
        Vector3 rotatedPoint = rotateXAxis * point;
    
        ClassicAssert.AreEqual(0f, rotatedPoint.x);
        ClassicAssert.AreEqual(0.71f, rotatedPoint.y);
        ClassicAssert.AreEqual(2.12f, rotatedPoint.z);
    }
}