using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace JeremyAnsel.DirectX.WinCodec.ComInterfaces;

/// <remarks>Inherited from <see cref="IWicComponentInfo"/></remarks>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[ComImport, Guid("9F34FB65-13F4-4f15-BC57-3726B5E53D9F")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IWicFormatConverterInfo
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

    void GetPixelFormats(
        [In] uint cFormats,
        [In, MarshalAs(UnmanagedType.LPArray)] WicPixelFormatGuid[]? pPixelFormatGUIDs,
        [Out] out uint pcActual);

    void CreateInstance(
        [Out] out IWicFormatConverter ppIConverter);
}
