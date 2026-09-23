namespace Maths3D;

public class Vector4
{
    public float  x, y, z, w;

    public Vector4(float x, float y, float z, float w)
    {
        this.x = x;
        this.y = y;
        this.z = z;
        this.w = w;
    }
    
    public Vector4()
    {
        this.x = 0f;
        this.y = 0f;
        this.z = 0f;
        this.w = 0f;
    }

    private static Matrix<float> Vector4IntoMatrix(Vector4 v)
    {
        float[,] result = new float[,]
        {
            { v.x },
            { v.y },
            { v.z },
            { v.w }
        };
        return new Matrix<float>(result);
    }
    
    private static Vector4 MatrixIntoVector4(Matrix<float> m)
    {
        if (m.NbLines != 4 || m.NbColumns != 1)
        {
            throw new MatrixIntoVector4Exception("Matrix isn't of the right dimensions (4,1) to turn it into a Vector4");
        }

        return new Vector4(m[0, 0], m[1, 0], m[2, 0], m[3, 0]);
    }
    
    private static Vector4 MultiplyVector4ByMatrix(Vector4 v, Matrix<float> m1)
    {
        Matrix<float> m2 = Vector4IntoMatrix(v);
        Matrix<float> result = m1.Multiply(m2);
        return MatrixIntoVector4(result);
    }
    
    public static implicit operator Matrix<float>(Vector4 v)
    {
        return Vector4IntoMatrix(v);
    }
    
    public static Vector4 operator *(Vector4 left, Matrix<float> right)
    {
        return MultiplyVector4ByMatrix(left, right);
    }
    
    public static Vector4 operator *(Matrix<float> left, Vector4 right)
    {
        return MultiplyVector4ByMatrix(right, left);
    }
}