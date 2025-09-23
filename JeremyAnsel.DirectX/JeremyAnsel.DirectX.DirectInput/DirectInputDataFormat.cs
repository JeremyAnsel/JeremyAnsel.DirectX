namespace JeremyAnsel.DirectX.DirectInput;

public sealed class DirectInputDataFormat
{
    public DirectInputDataOptions Options { get; set; }

    public int DataSize { get; set; }

    public DirectInputObjectDataFormat[] ObjectDataFormats { get; set; } = Array.Empty<DirectInputObjectDataFormat>();
}
