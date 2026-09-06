namespace JeremyAnsel.DirectX.DirectSound;

// define DSSPEAKER_GEOMETRY(a)       ((BYTE)(((DWORD)(a) >> 16) & 0x00FF))
public enum DsSpeakerGeometryConfig
{
    None,

    Min = 0x00000005, //   5 degrees

    Narrow = 0x0000000A, //  10 degrees

    Wide = 0x00000014, //  20 degrees

    Max = 0x000000B4, // 180 degrees
}
