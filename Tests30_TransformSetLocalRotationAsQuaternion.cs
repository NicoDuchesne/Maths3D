using Maths3D;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Maths_Matrices.Tests;

[TestFixture, DefaultFloatingPointTolerance(0.1f)]
public class Tests30_TransformSetLocalRotationAsQuaternion
{
    [Test]
    public void TestTransformSetLocalRotationQuaternionXAxis()
    {
        Transform t = new Transform();
        t.LocalRotationQuaternion = new Quaternion(0.259f, 0f, 0f, 0.966f);

        Vector3 localRotation = t.LocalRotation;
        ClassicAssert.AreEqual(30f, localRotation.x);
        ClassicAssert.AreEqual(0f, localRotation.y);
        ClassicAssert.AreEqual(0f, localRotation.z);

        ClassicAssert.AreEqual(new[,]
        {
            { 1f, 0f, 0f, 0f },
            { 0f, 0.866f, -0.5f, 0f },
            { 0f, 0.5f, 0.866f, 0f },
            { 0f, 0f, 0f, 1f },
        }, t.LocalRotationMatrix.ToArray2D());

        ClassicAssert.AreEqual(new[,]
        {
            { 1f, 0f, 0f, 0f },
            { 0f, 0.866f, -0.5f, 0f },
            { 0f, 0.5f, 0.866f, 0f },
            { 0f, 0f, 0f, 1f },
        }, t.LocalRotationXMatrix.ToArray2D());

        ClassicAssert.AreEqual(new[,]
        {
            { 1f, 0f, 0f, 0f },
            { 0f, 1f, 0f, 0f },
            { 0f, 0f, 1f, 0f },
            { 0f, 0f, 0f, 1f },
        }, t.LocalRotationYMatrix.ToArray2D());

        ClassicAssert.AreEqual(new[,]
        {
            { 1f, 0f, 0f, 0f },
            { 0f, 1f, 0f, 0f },
            { 0f, 0f, 1f, 0f },
            { 0f, 0f, 0f, 1f },
        }, t.LocalRotationZMatrix.ToArray2D());
    }

    [Test]
    public void TestTransformSetLocalRotationQuaternionYAxis()
    {
        Transform t = new Transform();
        t.LocalRotationQuaternion = new Quaternion(0f, 0.259f, 0f, 0.966f);
    
        Vector3 localRotation = t.LocalRotation;
        ClassicAssert.AreEqual(0f, localRotation.x);
        ClassicAssert.AreEqual(30f, localRotation.y);
        ClassicAssert.AreEqual(0f, localRotation.z);
    
        ClassicAssert.AreEqual(new[,]
        {
            { 0.866f, 0f, 0.5f, 0f },
            { 0f, 1f, 0f, 0f },
            { -0.5f, 0f, 0.866f, 0f },
            { 0f, 0f, 0f, 1f },
        }, t.LocalRotationMatrix.ToArray2D());
    
        ClassicAssert.AreEqual(new[,]
        {
            { 1f, 0f, 0f, 0f },
            { 0f, 1f, 0f, 0f },
            { 0f, 0f, 1f, 0f },
            { 0f, 0f, 0f, 1f },
        }, t.LocalRotationXMatrix.ToArray2D());
    
        ClassicAssert.AreEqual(new[,]
        {
            { 0.866f, 0f, 0.5f, 0f },
            { 0f, 1f, 0f, 0f },
            { -0.5f, 0f, 0.866f, 0f },
            { 0f, 0f, 0f, 1f },
        }, t.LocalRotationYMatrix.ToArray2D());
    
        ClassicAssert.AreEqual(new[,]
        {
            { 1f, 0f, 0f, 0f },
            { 0f, 1f, 0f, 0f },
            { 0f, 0f, 1f, 0f },
            { 0f, 0f, 0f, 1f },
        }, t.LocalRotationZMatrix.ToArray2D());
    }
    
    [Test]
    public void TestTransformSetLocalRotationQuaternionZAxis()
    {
        Transform t = new Transform();
        t.LocalRotationQuaternion = new Quaternion(0f, 0f, 0.259f, 0.966f);
    
        Vector3 localRotation = t.LocalRotation;
        ClassicAssert.AreEqual(0f, localRotation.x);
        ClassicAssert.AreEqual(0f, localRotation.y);
        ClassicAssert.AreEqual(30f, localRotation.z);
        
        ClassicAssert.AreEqual(new[,]
        {
            { 0.866f, -0.5f, 0f, 0f },
            { 0.5f, 0.866f, 0f, 0f },
            { 0f, 0f, 1f, 0f },
            { 0f, 0f, 0f, 1f },
        }, t.LocalRotationMatrix.ToArray2D());
    
        ClassicAssert.AreEqual(new[,]
        {
            { 1f, 0f, 0f, 0f },
            { 0f, 1f, 0f, 0f },
            { 0f, 0f, 1f, 0f },
            { 0f, 0f, 0f, 1f },
        }, t.LocalRotationXMatrix.ToArray2D());
        
        ClassicAssert.AreEqual(new[,]
        {
            { 1f, 0f, 0f, 0f },
            { 0f, 1f, 0f, 0f },
            { 0f, 0f, 1f, 0f },
            { 0f, 0f, 0f, 1f },
        }, t.LocalRotationYMatrix.ToArray2D());
        
        ClassicAssert.AreEqual(new[,]
        {
            { 0.866f, -0.5f, 0f, 0f },
            { 0.5f, 0.866f, 0f, 0f },
            { 0f, 0f, 1f, 0f },
            { 0f, 0f, 0f, 1f },
        }, t.LocalRotationZMatrix.ToArray2D());
    }
    
    [Test]
    public void TestTransformSetLocalRotationQuaternionMultipleAxis()
    {
        Transform t = new Transform();
        t.LocalRotationQuaternion = new Quaternion(0.430f, 0.092f, 0.561f, 0.701f);
    
        Vector3 localRotation = t.LocalRotation;
        ClassicAssert.AreEqual(30f, localRotation.x);
        ClassicAssert.AreEqual(45f, localRotation.y);
        ClassicAssert.AreEqual(90f, localRotation.z);
    
        ClassicAssert.AreEqual(new[,]
        {
            { 0.353f, -0.707f, 0.612f, 0f },
            { 0.866f, 0.000f, -0.500f, 0f },
            { 0.353f, 0.707f, 0.612f, 0f },
            { 0f, 0f, 0f, 1f },
        }, t.LocalRotationMatrix.ToArray2D());
    
        ClassicAssert.AreEqual(new[,]
        {
            { 1f, 0f, 0f, 0f },
            { 0f, 0.866f, -0.5f, 0f },
            { 0f, 0.5f, 0.866f, 0f },
            { 0f, 0f, 0f, 1f },
        }, t.LocalRotationXMatrix.ToArray2D());
    
        ClassicAssert.AreEqual(new[,]
        {
            { 0.707f, 0f, 0.707f, 0f },
            { 0f, 1f, 0f, 0f },
            { -0.707f, 0f, 0.707f, 0f },
            { 0f, 0f, 0f, 1f },
        }, t.LocalRotationYMatrix.ToArray2D());
    
        ClassicAssert.AreEqual(new[,]
        {
            { 0f, -1f, 0f, 0f },
            { 1f, 0f, 0f, 0f },
            { 0f, 0f, 1f, 0f },
            { 0f, 0f, 0f, 1f },
        }, t.LocalRotationZMatrix.ToArray2D());
    }
}