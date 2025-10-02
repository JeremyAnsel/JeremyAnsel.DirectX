using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace JeremyAnsel.DirectX.WinCodec.ComInterfaces;

/// <remarks>Inherited from <see cref="IWicComponentInfo"/></remarks>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[ComImport, Guid("E87A44C4-B76E-4c47-8B09-298EB12A2714")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IWicBitmapCodecInfo
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

    void GetContainerFormat(
        [Out] out Guid pguidContainerFormat
        );

    void GetPixelFormats(
        [In] uint cFormats,
        [In, MarshalAs(UnmanagedType.LPArray)] Guid[]? pguidPixelFormats,
        [Out] out uint pcActual);

    void GetColorManagementVersion(
        [In] uint cchColorManagementVersion,
        [In, MarshalAs(UnmanagedType.LPWStr)] StringBuilder wzColorManagementVersion,
        [Out] out uint pcchActual
        );

    void GetDeviceManufacturer(
        [In] uint cchDeviceManufacturer,
        [In, MarshalAs(UnmanagedType.LPWStr)] StringBuilder wzDeviceManufacturer,
        [Out] out uint pcchActual
        );

    void GetDeviceModels(
        [In] uint cchDeviceModels,
        [In, MarshalAs(UnmanagedType.LPWStr)] StringBuilder wzDeviceModels,
        [Out] out uint pcchActual
        );

    void GetMimeTypes(
        [In] uint cchMimeTypes,
        [In, MarshalAs(UnmanagedType.LPWStr)] StringBuilder wzMimeTypes,
        [Out] out uint pcchActual
        );

    void GetFileExtensions(
        [In] uint cchFileExtensions,
        [In, MarshalAs(UnmanagedType.LPWStr)] StringBuilder wzFileExtensions,
        [Out] out uint pcchActual
        );

    void DoesSupportAnimation(
        [Out, MarshalAs(UnmanagedType.Bool)] out bool pfSupportAnimation
        );

    void DoesSupportChromakey(
        [Out, MarshalAs(UnmanagedType.Bool)] out bool pfSupportChromakey
        );

    void DoesSupportLossless(
        [Out, MarshalAs(UnmanagedType.Bool)] out bool pfSupportLossless
        );

    void DoesSupportMultiframe(
        [Out, MarshalAs(UnmanagedType.Bool)] out bool pfSupportMultiframe
        );

    void MatchesMimeType(
        [In, MarshalAs(UnmanagedType.LPWStr)] string wzMimeType,
        [Out, MarshalAs(UnmanagedType.Bool)] out bool pfMatches
        );
}
