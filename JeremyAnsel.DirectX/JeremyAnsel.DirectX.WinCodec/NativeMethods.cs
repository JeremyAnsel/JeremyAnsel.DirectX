using JeremyAnsel.DirectX.WinCodec.ComInterfaces;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.WinCodec;

[SecurityCritical, SuppressUnmanagedCodeSecurity]
internal static class NativeMethods
{
    [DllImport("Windowscodecs.dll", EntryPoint = "WICConvertBitmapSource")]
    public static extern void WICConvertBitmapSource(
        in WicPixelFormatGuid dstPixelFormat,
        IWicBitmapSource sourceBitmap,
        out IWicBitmapSource? destinationBitmap);
}
