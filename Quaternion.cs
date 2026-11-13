namespace Maths3D;

public struct Quaternion
{
    public float x;
    public float y;
    public float z;
    public float w;

    public static Quaternion Identity => new Quaternion(0f, 0f, 0f, 1f);

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
}