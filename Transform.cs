
using Maths_Matrices.Tests;

namespace Maths3D;

public class Transform
{
    //Position
    private Vector3 _localPosition;
    public Vector3 LocalPosition{get => _localPosition; set => _localPosition = value; }
    public Matrix<float> LocalTranslationMatrix {
        get
        {
            Matrix<float> m = Matrix<float>.Identity(4);
            m[0,3] = _localPosition.x;
            m[1,3] = _localPosition.y;
            m[2,3] = _localPosition.z;
            return m;
        }
    }
    
    //Rotation
    private Vector3 _localRotation;
    public Vector3 LocalRotation{get => _localRotation; set => _localRotation = value; }
    public Matrix<float> LocalRotationMatrix => LocalRotationYMatrix * LocalRotationXMatrix * LocalRotationZMatrix;
    public Matrix<float> LocalRotationXMatrix => LocalRotationMatrixOnAxis(AXIS.X);
    public Matrix<float> LocalRotationYMatrix => LocalRotationMatrixOnAxis(AXIS.Y);
    public Matrix<float> LocalRotationZMatrix => LocalRotationMatrixOnAxis(AXIS.Z);
    
    //Scale
    private Vector3 _localScale;
    public Vector3 LocalScale{get => _localScale; set => _localScale = value; }
    public Matrix<float> LocalScaleMatrix{
        get
        {
            Matrix<float> m = Matrix<float>.Identity(4);
            m[0,0] = _localScale.x;
            m[1,1] = _localScale.y;
            m[2,2] = _localScale.z;
            return m;
        }
    }
    
    //Local and World
    private Transform _parent;
    public Matrix<float> LocalToWorldMatrix {
        get
        {
            if (_parent == null)
            {
                return LocalTranslationMatrix * LocalRotationMatrix * LocalScaleMatrix;
            }
            return _parent.LocalToWorldMatrix * (LocalTranslationMatrix * LocalRotationMatrix * LocalScaleMatrix);
        }
    }
    public Matrix<float> WorldToLocalMatrix => Matrix<float>.InvertByDeterminant(LocalToWorldMatrix);
    
    public Vector3 WorldPosition
    {
        get
        {
            Vector3 v = new Vector3();
            v.x = LocalToWorldMatrix[0,3];
            v.y = LocalToWorldMatrix[1,3];
            v.z = LocalToWorldMatrix[2,3];
            return v;
        }
    }
    

    public Transform()
    {
        _localPosition = new Vector3();
        _localRotation = new Vector3();
        _localScale = new Vector3(1f, 1f, 1f);
    }

    private Matrix<float> LocalRotationMatrixOnAxis(AXIS axis)
    {
        float teta;
        Matrix<float> rotationMatrix;
        (Matrix<float>, Matrix<float>, Matrix<float>) splitMatrix = Matrix<float>.Identity(4).ReduceOneDimension();

        switch (axis)
        {
            case AXIS.X:
                teta = _localRotation.x * MathF.PI / 180;
                rotationMatrix = new Matrix<float>(new[,]
                {
                    { 1f, 0f             , 0f              },
                    { 0f, MathF.Cos(teta), -MathF.Sin(teta)},
                    { 0f, MathF.Sin(teta), MathF.Cos(teta) }
                });
                break;
            case AXIS.Y:
                teta = _localRotation.y * MathF.PI / 180;
                rotationMatrix = new Matrix<float>(new[,]
                {
                    { MathF.Cos(teta) , 0f, MathF.Sin(teta)},
                    { 0f              , 1f, 0f             },
                    { -MathF.Sin(teta), 0f, MathF.Cos(teta)}
                });
                break;
            case AXIS.Z:
                teta = _localRotation.z * MathF.PI / 180;
                rotationMatrix = new Matrix<float>(new[,]
                {
                    { MathF.Cos(teta), -MathF.Sin(teta), 0f},
                    { MathF.Sin(teta), MathF.Cos(teta) , 0f},
                    { 0f             , 0f              , 1f}
                });
                break;
            default :
                throw new TransformException("Invalid axis " + axis);
        }
        
        rotationMatrix = Matrix<float>.RebuildMatrix(rotationMatrix, splitMatrix.Item2, splitMatrix.Item3);
        return rotationMatrix;
    }

    public void SetParent(Transform parent)
    {
        this._parent = parent;
    }

}

enum AXIS
{
    X,
    Y,
    Z
}