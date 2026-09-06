namespace JeremyAnsel.DirectX.DirectSound;

public struct DsWaveFormatEx
{
    public short wFormatTag; /* format type */
    public short nChannels; /* number of channels (i.e. mono, stereo...) */
    public int nSamplesPerSec; /* sample rate */
    public int nAvgBytesPerSec; /* for buffer estimation */
    public short nBlockAlign; /* block size of data */
    public short wBitsPerSample; /* number of bits per sample of mono data */
    public short cbSize; /* the count in bytes of the size of */
    /* extra information (after cbSize) */
}
