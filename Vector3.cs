namespace Maths3D;

public class Vector3
{
    public float  x, y, z;
    public float Length => MathF.Sqrt(x*x + y*y + z*z);

    public Vector3(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
    
    public Vector3()
    {
        this.x = 0f;
        this.y = 0f;
        this.z = 0f;
    }
    
    public static Vector3 operator +(Vector3 left, Vector3 right)
    {
        return new Vector3(left.x + right.x, left.y + right.y, left.z + right.z);
    }
    
    public static Vector3 operator -(Vector3 left, Vector3 right)
    {
        return new Vector3(left.x - right.x, left.y - right.y, left.z - right.z);
    }
    
    public static Vector3 operator -(Vector3 v)
    {
        return new Vector3(-v.x, -v.y, -v.z);
    }
    
    public static Matrix<float> Vector3IntoMatrix(Vector3 v)
    {
        float[,] result = new float[,]
        {
            { v.x },
            { v.y },
            { v.z }
        };
        return new Matrix<float>(result);
    }
    
    public static Vector3 MatrixIntoVector3(Matrix<float> m)
    {
        if (m.NbLines != 3 || m.NbColumns != 1)
        {
            throw new MatrixIntoVector4Exception("Matrix isn't of the right dimensions (3,1) to turn it into a Vector3");
        }

        return new Vector3(m[0, 0], m[1, 0], m[2, 0]);
    }
}