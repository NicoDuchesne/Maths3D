using Maths3D;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Maths_Matrices.Tests;

[TestFixture, DefaultFloatingPointTolerance(0.001f)]
public class Tests29_TransformGetLocalRotationAsQuaternion
{
    [Test]
    public void TestTransformGetLocalRotationQuaternionDefault()
    {
        Transform t = new Transform();

        Quaternion q = t.LocalRotationQuaternion;
        ClassicAssert.AreEqual(0f, q.x);
        ClassicAssert.AreEqual(0f, q.y);
        ClassicAssert.AreEqual(0f, q.z);
        ClassicAssert.AreEqual(1f, q.w);
    }

    [Test]
    public void TestTransformGetLocalRotationQuaternionXAxis()
    {
        Transform t = new Transform();
        t.LocalRotation = new Vector3(30f, 0f, 0f);
    
        Quaternion q = t.LocalRotationQuaternion;
        ClassicAssert.AreEqual(0.259f, q.x);
        ClassicAssert.AreEqual(0f, q.y);
        ClassicAssert.AreEqual(0f, q.z);
        ClassicAssert.AreEqual(0.966f, q.w);
    }
    
    [Test]
    public void TestTransformGetLocalRotationQuaternionYAxis()
    {
        Transform t = new Transform();
        t.LocalRotation = new Vector3(0f, 30f, 0f);
    
        Quaternion q = t.LocalRotationQuaternion;
        ClassicAssert.AreEqual(0f, q.x);
        ClassicAssert.AreEqual(0.259f, q.y);
        ClassicAssert.AreEqual(0f, q.z);
        ClassicAssert.AreEqual(0.966f, q.w);
    }
    
    [Test]
    public void TestTransformGetLocalRotationQuaternionZAxis()
    {
        Transform t = new Transform();
        t.LocalRotation = new Vector3(0f, 0f, 30f);
    
        Quaternion q = t.LocalRotationQuaternion;
        ClassicAssert.AreEqual(0f, q.x);
        ClassicAssert.AreEqual(0f, q.y);
        ClassicAssert.AreEqual(0.259f, q.z);
        ClassicAssert.AreEqual(0.966f, q.w);
    }
    
    [Test]
    public void TestTransformGetLocalRotationQuaternionMultipleAxis()
    {
        Transform t = new Transform();
        t.LocalRotation = new Vector3(30f, 45f, 90f);
    
        Quaternion q = t.LocalRotationQuaternion;
        ClassicAssert.AreEqual(0.430f, q.x);
        ClassicAssert.AreEqual(0.092f, q.y);
        ClassicAssert.AreEqual(0.561f, q.z);
        ClassicAssert.AreEqual(0.701f, q.w);
    }
}