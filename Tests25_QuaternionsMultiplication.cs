using Maths3D;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Maths_Matrices.Tests;

[TestFixture, DefaultFloatingPointTolerance(0.01f)]
public class Tests25_QuaternionsMultiplication
{
    [Test]
    public void TestQuaternionMultiplyXAxisAndYAxis()
    {
        Quaternion rotationXAxis = Quaternion.AngleAxis(90f, new Vector3(1f, 0f, 0f));
        Quaternion rotationYAxis = Quaternion.AngleAxis(90f, new Vector3(0f, 1f, 0f));

        Quaternion result = rotationXAxis * rotationYAxis;
        ClassicAssert.AreEqual(0.5f, result.x);
        ClassicAssert.AreEqual(0.5f, result.y);
        ClassicAssert.AreEqual(0.5f, result.z);
        ClassicAssert.AreEqual(0.5f, result.w);

        result = rotationYAxis * rotationXAxis;
        ClassicAssert.AreEqual(0.5f, result.x);
        ClassicAssert.AreEqual(0.5f, result.y);
        ClassicAssert.AreEqual(-0.5f, result.z);
        ClassicAssert.AreEqual(0.5f, result.w);
    }

    [Test]
    public void TestQuaternionMultiplyXAxisAndZAxis()
    {
        Quaternion rotationXAxis = Quaternion.AngleAxis(90f, new Vector3(1f, 0f, 0f));
        Quaternion rotationZAxis = Quaternion.AngleAxis(90f, new Vector3(0f, 0f, 1f));
    
        Quaternion result = rotationXAxis * rotationZAxis;
        ClassicAssert.AreEqual(0.5f, result.x);
        ClassicAssert.AreEqual(-0.5f, result.y);
        ClassicAssert.AreEqual(0.5f, result.z);
        ClassicAssert.AreEqual(0.5f, result.w);
    
        result = rotationZAxis * rotationXAxis;
        ClassicAssert.AreEqual(0.5f, result.x);
        ClassicAssert.AreEqual(0.5f, result.y);
        ClassicAssert.AreEqual(0.5f, result.z);
        ClassicAssert.AreEqual(0.5f, result.w);
    }
    
    [Test]
    public void TestQuaternionMultiplyYAxisAndZAxis()
    {
        Quaternion rotationYAxis = Quaternion.AngleAxis(90f, new Vector3(0f, 1f, 0f));
        Quaternion rotationZAxis = Quaternion.AngleAxis(90f, new Vector3(0f, 0f, 1f));
    
        Quaternion result = rotationYAxis * rotationZAxis;
        ClassicAssert.AreEqual(0.5f, result.x);
        ClassicAssert.AreEqual(0.5f, result.y);
        ClassicAssert.AreEqual(0.5f, result.z);
        ClassicAssert.AreEqual(0.5f, result.w);
    
        result = rotationZAxis * rotationYAxis;
        ClassicAssert.AreEqual(-0.5f, result.x);
        ClassicAssert.AreEqual(0.5f, result.y);
        ClassicAssert.AreEqual(0.5f, result.z);
        ClassicAssert.AreEqual(0.5f, result.w);
    }
    
    [Test]
    public void TestQuaternionMultiplyIdentity()
    {
        Quaternion rotationYAxis = Quaternion.AngleAxis(90f, new Vector3(0f, 1f, 0f));
        Quaternion qIdentity = Quaternion.Identity;
    
        Quaternion result = rotationYAxis * qIdentity;
        ClassicAssert.AreEqual(0f, result.x);
        ClassicAssert.AreEqual(0.71f, result.y);
        ClassicAssert.AreEqual(0f, result.z);
        ClassicAssert.AreEqual(0.71f, result.w);
    
        result = qIdentity * rotationYAxis;
        ClassicAssert.AreEqual(0f, result.x);
        ClassicAssert.AreEqual(0.71f, result.y);
        ClassicAssert.AreEqual(0f, result.z);
        ClassicAssert.AreEqual(0.71f, result.w);
    }
}