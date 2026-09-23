
namespace Maths3D;

public class Transform
{
    private Vector3 _localPosition;
    private Matrix<float> _localTranslationMatrix;
    
    private Vector3 _localRotation;
    private Matrix<float> _localRotationMatrix;
    private Matrix<float> _localRotationXMatrix;
    private Matrix<float> _localRotationYMatrix;
    private Matrix<float> _localRotationZMatrix;
    
    private Vector3 _localScale;
    private Matrix<float> _localScaleMatrix;

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

    public Vector3 LocalRotation
    {
        get { return _localRotation; }
        set
        {
            _localRotation = value;
            ApplyNewLocalRotation();
        }
    }
    public Matrix<float> LocalRotationMatrix => _localRotationMatrix;
    public Matrix<float> LocalRotationXMatrix => _localRotationXMatrix;
    public Matrix<float> LocalRotationYMatrix => _localRotationYMatrix;
    public Matrix<float> LocalRotationZMatrix => _localRotationZMatrix;

    public Vector3 LocalScale
    {
        get { return _localScale; }
        set
        {
            _localScale = value;
            _localScaleMatrix[0,0] = _localScale.x;
            _localScaleMatrix[1,1] = _localScale.y;
            _localScaleMatrix[2,2] = _localScale.z;
        }
    }
    public Matrix<float> LocalScaleMatrix => _localScaleMatrix;

    public Transform()
    {
        _localPosition = new Vector3();
        _localTranslationMatrix = Matrix<float>.Identity(4);
        
        _localRotation = new Vector3();
        _localRotationMatrix = Matrix<float>.Identity(4);
        _localRotationXMatrix = Matrix<float>.Identity(4);
        _localRotationYMatrix = Matrix<float>.Identity(4);
        _localRotationZMatrix = Matrix<float>.Identity(4);
        
        _localScale = new Vector3(1f, 1f, 1f);
        _localScaleMatrix = Matrix<float>.Identity(4);
    }

    private void ApplyNewLocalRotation()
    {
        ApplyLocalRotationOnAxis(_localRotation.x, AXIS.X);
        ApplyLocalRotationOnAxis(_localRotation.y, AXIS.Y);
        ApplyLocalRotationOnAxis(_localRotation.z, AXIS.Z);
    }

    private void ApplyLocalRotationOnAxis(float teta, AXIS axis)
    {
        teta = teta * MathF.PI / 180;
        Matrix<float> rotationMatrix;
        (Matrix<float>, Matrix<float>, Matrix<float>) splitMatrix;

        switch (axis)
        {
            case AXIS.X:
                splitMatrix = _localRotationXMatrix.ReduceOneDimension();
                rotationMatrix = new Matrix<float>(new[,]
                {
                    { 1f, 0f             , 0f              },
                    { 0f, MathF.Cos(teta), -MathF.Sin(teta)},
                    { 0f, MathF.Sin(teta), MathF.Cos(teta) }
                });
                _localRotationXMatrix = Matrix<float>.RebuildMatrix(rotationMatrix, splitMatrix.Item2, splitMatrix.Item3);
                break;
            case AXIS.Y:
                splitMatrix = _localRotationYMatrix.ReduceOneDimension();
                rotationMatrix = new Matrix<float>(new[,]
                {
                    { MathF.Cos(teta) , 0f, MathF.Sin(teta)},
                    { 0f              , 1f, 0f             },
                    { -MathF.Sin(teta), 0f, MathF.Cos(teta)}
                });
                _localRotationYMatrix = Matrix<float>.RebuildMatrix(rotationMatrix, splitMatrix.Item2, splitMatrix.Item3);
                break;
            case AXIS.Z:
                splitMatrix = _localRotationZMatrix.ReduceOneDimension();
                rotationMatrix = new Matrix<float>(new[,]
                {
                    { MathF.Cos(teta), -MathF.Sin(teta), 0f},
                    { MathF.Sin(teta), MathF.Cos(teta) , 0f},
                    { 0f             , 0f              , 1f}
                });
                _localRotationZMatrix = Matrix<float>.RebuildMatrix(rotationMatrix, splitMatrix.Item2, splitMatrix.Item3);
                break;
            default :
                throw new TransformException("Invalid axis " + axis);
        }

        _localRotationMatrix = _localRotationYMatrix * _localRotationXMatrix * _localRotationZMatrix;
    }
    
}

enum AXIS
{
    X,
    Y,
    Z
}