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