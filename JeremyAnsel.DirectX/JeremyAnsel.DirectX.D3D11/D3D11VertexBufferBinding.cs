namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// 
/// </summary>
public struct D3D11VertexBufferBinding
{
    private D3D11Buffer? _vertexBuffer;
    private uint _stride;
    private uint _offset;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="vertexBuffer"></param>
    /// <param name="stride"></param>
    /// <param name="offset"></param>
    public D3D11VertexBufferBinding(D3D11Buffer? vertexBuffer, uint stride, uint offset)
    {
        _vertexBuffer = vertexBuffer;
        _stride = stride;
        _offset = offset;
    }

    /// <summary>
    /// 
    /// </summary>
    public D3D11Buffer? Buffer
    {
        get => _vertexBuffer;
        set => _vertexBuffer = value;
    }

    /// <summary>
    /// 
    /// </summary>
    public uint Stride
    {
        get => _stride;
        set => _stride = value;
    }

    /// <summary>
    /// 
    /// </summary>
    public uint Offset
    {
        get => _offset;
        set => _offset = value;
    }
}
