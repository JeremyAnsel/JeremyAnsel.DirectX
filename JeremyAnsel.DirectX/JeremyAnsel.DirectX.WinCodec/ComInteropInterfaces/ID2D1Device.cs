using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.WinCodec.ComInteropInterfaces;

[SecurityCritical, SuppressUnmanagedCodeSecurity]
[ComImport, Guid("47dd575d-ac05-4cdd-8049-9b02cd16f44c")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface ID2D1Device
{
}
