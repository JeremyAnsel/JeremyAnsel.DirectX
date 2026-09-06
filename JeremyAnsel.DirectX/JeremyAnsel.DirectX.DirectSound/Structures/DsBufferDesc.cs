namespace JeremyAnsel.DirectX.DirectSound;

public struct DsBufferDesc
{
    public int dwSize;
    public DsBufferCapsFlags dwFlags;
    public int dwBufferBytes;
    public int dwReserved;
    public nint lpwfxFormat; // pointer to DsWaveFormatEx
    public Guid guid3DAlgorithm;
}
