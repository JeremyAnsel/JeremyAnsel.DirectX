using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Claims;
using System.Text;

namespace JeremyAnsel.DirectX.WinCodec.ComInterfaces;

[SecurityCritical, SuppressUnmanagedCodeSecurity]
[ComImport, Guid("23BC3F0A-698B-4357-886B-F24D50671334")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IWicComponentInfo
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
}
