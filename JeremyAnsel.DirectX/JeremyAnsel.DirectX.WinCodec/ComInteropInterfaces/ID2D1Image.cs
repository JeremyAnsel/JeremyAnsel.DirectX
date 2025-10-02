using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.WinCodec.ComInteropInterfaces;

[SecurityCritical, SuppressUnmanagedCodeSecurity]
[ComImport, Guid("65019f75-8da2-497c-b32c-dfa34e48ede6")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface ID2D1Image
{
}
