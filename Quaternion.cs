namespace Maths3D;

public struct Quaternion
{
    public float x;
    public float y;
    public float z;
    public float w;

    public static Quaternion Identity => new Quaternion(0f, 0f, 0f, 1f);
    
    public Quaternion(float x, float y, float z, float w)
    {
        this.x = x;
        this.y = y;
        this.z = z;
        this.w = w;
    }
}