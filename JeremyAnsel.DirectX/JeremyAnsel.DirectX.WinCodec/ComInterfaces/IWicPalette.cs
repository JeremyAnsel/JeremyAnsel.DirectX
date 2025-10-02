using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.WinCodec.ComInterfaces;

[SecurityCritical, SuppressUnmanagedCodeSecurity]
[ComImport, Guid("00000040-a8f2-4877-ba0a-fd2b6645fb94")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IWicPalette
{
    void InitializePredefined(
        [In] WicBitmapPaletteType ePaletteType,
        [In, MarshalAs(UnmanagedType.Bool)] bool fAddTransparentColor
        );

    void InitializeCustom(
        [In, MarshalAs(UnmanagedType.LPArray)] WicColor[] pColors,
        [In] uint cCount
        );

    void InitializeFromBitmap(
        [In] IWicBitmapSource pISurface,
        [In] uint cCount,
        [In, MarshalAs(UnmanagedType.Bool)] bool fAddTransparentColor
        );

    void InitializeFromPalette(
        [In] IWicPalette pIPalette
        );

    void GetType(
        [Out] out WicBitmapPaletteType pePaletteType
        );

    void GetColorCount(
        [Out] out uint pcCount
        );

    void GetColors(
        [In] uint cCount,
        [Out, MarshalAs(UnmanagedType.LPArray)] WicColor[]? pColors,
        [Out] out uint pcActualColors
        );

    void IsBlackWhite(
        [Out, MarshalAs(UnmanagedType.Bool)] out bool pfIsBlackWhite
        );

    void IsGrayscale(
        [Out, MarshalAs(UnmanagedType.Bool)] out bool pfIsGrayscale
        );

    void HasAlpha(
        [Out, MarshalAs(UnmanagedType.Bool)] out bool pfHasAlpha
        );
}
