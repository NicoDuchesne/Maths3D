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

    //La matrice de rotation donnée en dans les slides du cours
    private Matrix<float> RotationMatrix => new Matrix<float>(new[,] {
        {1 - 2*(y*y) - 2*(z*z), 2*x*y - 2*w*z        , 2*x*z + 2*w*y         },
        {2*x*y + 2*w*z        , 1 - 2*(x*x) - 2*(z*z), 2*y*z - 2*w*x         },
        {2*x*z - 2*w*y        , 2*y*z + 2*w*x        , 1 - 2*(x*x) - 2*(y*y) }
    });

    public Matrix<float> Matrix => Matrix<float>.RebuildMatrix(
        RotationMatrix,
        Matrix<float>.Identity(4).ReduceOneDimension().Item2,
        Matrix<float>.Identity(4).ReduceOneDimension().Item3
    );
    
    //c'est le calcul expliqué dans la vidéo youtube (avec des index informatiques, pas mathématiques) 
    //soit m notre matrix rotation et p = asin(-m12), si cos(p) == 0 alors
    //return Vector3 (x : p; y : atan2(-m20, m00); z : 0)
    //sinon
    //return Vector3 (x : p, y : atan2(m02, m22), z : atan2(m10, m11) )
    public Vector3 EulerAngles => MathF.Cos(MathF.Asin(-RotationMatrix[1,2])) < 0.01f && MathF.Cos(MathF.Asin(-RotationMatrix[1,2])) > -0.01f ?
        new Vector3( MathF.Asin(-RotationMatrix[1,2]) * 180f / MathF.PI,  MathF.Atan2(-RotationMatrix[2,0],RotationMatrix[0,0]) * 180f / MathF.PI,  0f) :
        new Vector3( MathF.Asin(-RotationMatrix[1,2]) * 180f / MathF.PI,  MathF.Atan2(RotationMatrix[0,2],RotationMatrix[2,2])  * 180f / MathF.PI , MathF.Atan2(RotationMatrix[1,0],RotationMatrix[1,1]) * 180f / MathF.PI)
    ;
    
    
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

    public static Quaternion Euler(float xAngle, float yAngle, float zAngle)
    {
        Quaternion qRX = AngleAxis(xAngle, new Vector3(1f, 0f, 0f));
        Quaternion qRY = AngleAxis(yAngle, new Vector3(0f, 1f, 0f));
        Quaternion qRZ = AngleAxis(zAngle, new Vector3(0f, 0f, 1f));
        
        return Multiply(qRY, qRX, qRZ);
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

    private static Quaternion Multiply(Quaternion q1, Quaternion q2, Quaternion q3)
    {
        return Multiply(Multiply(q1, q2), q3);
    }
    
    private static Vector3 Multiply(Quaternion q, Vector3 v)
    {
        Quaternion q1 = q;
        Quaternion q2 = new Quaternion(v.x, v.y, v.z, 0f);
        Quaternion q3 = q.Invert;

        Quaternion multiplyResult = Multiply(q1, q2, q3);

        return new Vector3(multiplyResult.x, multiplyResult.y, multiplyResult.z);
    }
    
}