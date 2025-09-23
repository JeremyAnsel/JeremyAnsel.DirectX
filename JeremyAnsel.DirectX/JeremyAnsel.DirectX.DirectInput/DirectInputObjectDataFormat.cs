namespace JeremyAnsel.DirectX.DirectInput;

public sealed class DirectInputObjectDataFormat
{
    public Guid? Guid { get; set; }

    public int Offset { get; set; }

    public DirectInputObjectDataTypes DataType { get; set; }

    public short DataInstance { get; set; }

    public DirectInputObjectDataOptions Options { get; set; }
}
