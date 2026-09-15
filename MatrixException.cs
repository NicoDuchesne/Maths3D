namespace Maths3D;

using System;
using System.Runtime.Serialization;

[Serializable()]
public class MatrixException : Exception
{
    protected MatrixException()
        : base()
    { }

    public MatrixException(string message)
        : base(message)
    { }
}

[Serializable()]
public class MatrixSumException : MatrixException
{
    protected MatrixSumException()
        : base()
    { }

    public MatrixSumException(string message)
        : base(message)
    { }
}

[Serializable()]
public class MatrixSubtractionException : MatrixException
{
    protected MatrixSubtractionException()
        : base()
    { }

    public MatrixSubtractionException(string message)
        : base(message)
    { }
}

[Serializable()]
public class MatrixMultiplyException : MatrixException
{
    protected MatrixMultiplyException()
        : base()
    { }

    public MatrixMultiplyException(string message)
        : base(message)
    { }
}

[Serializable()]
public class MatrixElementaryOperationsException : MatrixException
{
    protected MatrixElementaryOperationsException()
        : base()
    { }

    public MatrixElementaryOperationsException(string message)
        : base(message)
    { }
}

[Serializable()]
public class MatrixScalarZeroException : MatrixException
{
    protected MatrixScalarZeroException()
        : base()
    { }

    public MatrixScalarZeroException(string message)
        : base(message)
    { }
}

[Serializable()]
public class AugmentedMatrixException : MatrixException
{
    protected AugmentedMatrixException()
        : base()
    { }

    public AugmentedMatrixException(string message)
        : base(message)
    { }
}

[Serializable()]
public class SplitMatrixException : MatrixException
{
    protected SplitMatrixException()
        : base()
    { }

    public SplitMatrixException(string message)
        : base(message)
    { }
}