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
}