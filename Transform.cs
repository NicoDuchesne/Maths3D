
namespace Maths3D;

public class Transform
{
    private Vector3 _localPosition;
    private Matrix<float> _localTranslationMatrix;

    public Vector3 LocalPosition
    {
        get { return _localPosition; }
        set
        {
            _localPosition = value;
            _localTranslationMatrix[0,3] = _localPosition.x;
            _localTranslationMatrix[1,3] = _localPosition.y;
            _localTranslationMatrix[2,3] = _localPosition.z;
        }
    }
    public Matrix<float> LocalTranslationMatrix => _localTranslationMatrix;

    public Transform()
    {
        _localPosition = new Vector3();
        _localTranslationMatrix = Matrix<float>.Identity(4);
    }
}