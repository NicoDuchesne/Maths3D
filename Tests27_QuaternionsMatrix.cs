using Maths3D;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Maths_Matrices.Tests;

[TestFixture, DefaultFloatingPointTolerance(0.001f)]
public class Tests27_QuaternionsMatrix
{
    [Test]
    public void TestQuaternionMatrixXAxis()
    {
        Quaternion q = Quaternion.AngleAxis(30f, new Vector3(1f, 0f, 0f));

        ClassicAssert.AreEqual(new[,]
        {
            { 1f, 0f, 0f, 0f },
            { 0f, 0.866f, -0.5f, 0f },
            { 0f, 0.5f, 0.866f, 0f },
            { 0f, 0f, 0f, 1f },
        }, q.Matrix.ToArray2D());
    }

    [Test]
    public void TestQuaternionMatrixYAxis()
    {
        Quaternion q = Quaternion.AngleAxis(30f, new Vector3(0f, 1f, 0f));
    
        ClassicAssert.AreEqual(new[,]
        {
            { 0.866f, 0f, 0.5f, 0f },
            { 0f, 1f, 0f, 0f },
            { -0.5f, 0f, 0.866f, 0f },
            { 0f, 0f, 0f, 1f },
        }, q.Matrix.ToArray2D());
    }
    
    [Test]
    public void TestQuaternionMatrixZAxis()
    {
        Quaternion q = Quaternion.AngleAxis(30f, new Vector3(0f, 0f, 1f));
    
        ClassicAssert.AreEqual(new[,]
        {
            { 0.866f, -0.5f, 0f, 0f },
            { 0.5f, 0.866f, 0f, 0f },
            { 0f, 0f, 1f, 0f },
            { 0f, 0f, 0f, 1f },
        }, q.Matrix.ToArray2D());
    }
    
    [Test]
    public void TestQuaternionMatrixMultipleAxis()
    {
        Quaternion rotationXAxis = Quaternion.AngleAxis(30f, new Vector3(1f, 0f, 0f));
        Quaternion rotationYAxis = Quaternion.AngleAxis(90f, new Vector3(0f, 1f, 0f));
    
        Quaternion result = rotationXAxis * rotationYAxis;
        ClassicAssert.AreEqual(new[,]
        {
            { 0f, 0f, 1f, 0f },
            { 0.5f, 0.866f, 0f, 0f },
            { -0.866f, 0.5f, 0f, 0f },
            { 0f, 0f, 0f, 1f },
        }, result.Matrix.ToArray2D());
    
        Quaternion invertedResult = rotationYAxis * rotationXAxis;
        ClassicAssert.AreEqual(new[,]
        {
            { 0f, 0.5f, 0.866f, 0f },
            { 0f, 0.866f, -0.5f, 0f },
            { -1f, 0f, 0f, 0f },
            { 0f, 0f, 0f, 1f },
        }, invertedResult.Matrix.ToArray2D());
    }
    
    [Test]
    public void TestQuaternionMatrixIdentity()
    {
        Quaternion q = Quaternion.Identity;
    
        ClassicAssert.AreEqual(new[,]
        {
            { 1f, 0f, 0f, 0f },
            { 0f, 1f, 0f, 0f },
            { 0f, 0f, 1f, 0f },
            { 0f, 0f, 0f, 1f },
        }, q.Matrix.ToArray2D());
    }

}