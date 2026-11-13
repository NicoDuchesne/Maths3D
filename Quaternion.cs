using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Maths3D;

public struct Quaternion
{
    public float x;
    public float y;
    public float z;
    public float w;

    public static Quaternion Identity => new Quaternion(0f, 0f, 0f, 1f);
    
    public Quaternion Conjugate => new Quaternion(-x, -y, -z, w);
    public float Length => (float)Math.Sqrt(w*w + x*x + y*y + z*z);
    public float Norm => w*w + x*x + y*y + z*z;
    public Quaternion Invert => new Quaternion(Conjugate.x/Norm, Conjugate.y/Norm, Conjugate.z/Norm, Conjugate.w/Norm);
    
    public Quaternion(float x, float y, float z, float w)
    {
        this.x = x;
        this.y = y;
        this.z = z;
        this.w = w;
    }

    public Quaternion()
    {
        this.x = 0f;
        this.y = 0f;
        this.z = 0f;
        this.w = 1f;
    }
    
    public static Quaternion AngleAxis(float angle, Vector3 axis)
    {
        Quaternion q = new Quaternion();
        float teta = angle * (MathF.PI / 180f);
        float length = axis.Length;
        
        q.x = (axis.x/length) * MathF.Sin(teta/2f);
        q.y = (axis.y/length) * MathF.Sin(teta/2f);
        q.z = (axis.z/length) * MathF.Sin(teta/2f);
        q.w = MathF.Cos(teta/2f);
        
        return q;
    }
    
    public static Quaternion operator *(Quaternion left, Quaternion right)
    {
        return Multiply(left, right);
    }
    
    public static Vector3 operator *(Quaternion left, Vector3 right)
    {
        return Multiply(left, right);
    }

    private static Quaternion Multiply(Quaternion q1, Quaternion q2)
    {
        float wPart = q1.w * q2.w - q1.x * q2.x - q1.y * q2.y - q1.z * q2.z;
        float xPart = q1.w * q2.x + q1.x * q2.w + q1.y * q2.z - q1.z * q2.y;
        float yPart = q1.w * q2.y - q1.x * q2.z + q1.y * q2.w + q1.z * q2.x;
        float zPart = q1.w * q2.z + q1.x * q2.y - q1.y * q2.x + q1.z * q2.w;
        
        return new Quaternion(xPart, yPart, zPart, wPart);
    }
    
    private static Vector3 Multiply(Quaternion q, Vector3 v)
    {
        Quaternion q1 = q;
        Quaternion q2 = new Quaternion(v.x, v.y, v.z, 0f);
        Quaternion q3 = q.Invert;

        Quaternion multiplyResult = Multiply(Multiply(q1, q2), q3);

        return new Vector3(multiplyResult.x, multiplyResult.y, multiplyResult.z);
    }
    
    //Matrix Rotation
    // Matrix<float> rotationMatrix = new Matrix<float>(new[,]
    // {
    //     {1 - 2*(q.y*q.y) - 2*(q.z*q.z), 2*q.x*q.y - 2*q.w*q.z        , 2*q.x*q.z + 2*q.w*q.y         },
    //     {2*q.x*q.y + 2*q.w*q.z        , 1 - 2*(q.x*q.x) - 2*(q.z*q.z), 2*q.y*q.z - 2*q.w*q.x         },
    //     {2+q.x*q.z - 2*q.w*q.y        , 2*q.y*q.z + 2*q.w*q.x        , 1 - 2*(q.x*q.x) - 2*(q.y*q.y) }
    // });
}