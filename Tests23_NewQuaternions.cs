using Maths3D;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Maths_Matrices.Tests;

[TestFixture]
public class Tests23_NewQuaternions
{
    [Test]
    public void TestNewQuaternion()
    {
        Quaternion q = new Quaternion(0f, 0.71f, 0f, 0.71f);
        ClassicAssert.AreEqual(0f, q.x);
        ClassicAssert.AreEqual(0.71f, q.y);
        ClassicAssert.AreEqual(0f, q.z);
        ClassicAssert.AreEqual(0.71f, q.w);
    }

    [Test]
    public void TestNewQuaternionFromAnother()
    {
        Quaternion q1 = new Quaternion(0f, 0.71f, 0f, 0.71f);
        Quaternion q2 = q1;
        q2.x = 0.71f;
    
        ClassicAssert.AreEqual(0.71f, q2.x);
        ClassicAssert.AreEqual(0.71f, q2.y);
        ClassicAssert.AreEqual(0f, q2.z);
        ClassicAssert.AreEqual(0.71f, q2.w);
    
        ClassicAssert.AreEqual(0f, q1.x);
        ClassicAssert.AreEqual(0.71f, q1.y);
        ClassicAssert.AreEqual(0f, q1.z);
        ClassicAssert.AreEqual(0.71f, q1.w);
    }

    [Test]
    public void TestQuaternionIdentity()
    {
        //An identity quantity is a quaternion with no rotation
        Quaternion q = Quaternion.Identity;
        ClassicAssert.AreEqual(0f, q.x);
        ClassicAssert.AreEqual(0f, q.y);
        ClassicAssert.AreEqual(0f, q.z);
        ClassicAssert.AreEqual(1f, q.w);
    }
}