using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace JeremyAnsel.DirectX.WinCodec.ComInterfaces;

/// <remarks>Inherited from <see cref="IWicPixelFormatInfo"/></remarks>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[ComImport, Guid("A9DB33A2-AF5F-43C7-B679-74F5984B5AA4")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IWicPixelFormatInfo2
{
    void GetComponentType(
        [Out] out WicComponentType pType
        );

    void GetCLSID(
        [Out] out Guid pclsid
        );

    void GetSigningStatus(
        [Out] out WicComponentSigning pStatus
        );

    void GetAuthor(
        [In] uint cchAuthor,
        [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder wzAuthor,
        [Out] out uint pcchActual
        );

    void GetVendorGUID(
        [Out] out Guid pguidVendor
        );

    void GetVersion(
        [In] uint cchVersion,
        [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder wzVersion,
        [Out] out uint pcchActual
        );

    void GetSpecVersion(
        [In] uint cchSpecVersion,
        [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder wzSpecVersion,
        [Out] out uint pcchActual
        );

    void GetFriendlyName(
        [In] uint cchFriendlyName,
        [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder wzFriendlyName,
        [Out] out uint pcchActual
        );

    void GetFormatGUID(
        [Out] out Guid pFormat
        );

    void GetColorContext(
        [Out] out IWicColorContext ppIColorContext
        );

    void GetBitsPerPixel(
        [Out] out uint puiBitsPerPixel
        );

    void GetChannelCount(
        [Out] out uint puiChannelCount
        );

    void GetChannelMask();

    void SupportsTransparency(
        [Out, MarshalAs(UnmanagedType.Bool)] out bool pfSupportsTransparency
        );

    void GetNumericRepresentation(
        [Out] out WicPixelFormatNumericRepresentation pNumericRepresentation
        );
}
