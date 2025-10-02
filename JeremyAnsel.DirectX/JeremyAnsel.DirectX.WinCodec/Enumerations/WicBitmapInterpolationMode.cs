namespace JeremyAnsel.DirectX.WinCodec;

public enum WicBitmapInterpolationMode : uint
{
    WICBitmapInterpolationModeNearestNeighbor = 0x00000000,

    WICBitmapInterpolationModeLinear = 0x00000001,

    WICBitmapInterpolationModeCubic = 0x00000002,

    WICBitmapInterpolationModeFant = 0x00000003,

    WICBitmapInterpolationModeHighQualityCubic = 0x00000004,
}
