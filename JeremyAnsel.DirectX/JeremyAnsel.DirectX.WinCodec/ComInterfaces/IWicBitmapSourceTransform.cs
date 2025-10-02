using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.WinCodec.ComInterfaces;

[SecurityCritical, SuppressUnmanagedCodeSecurity]
[ComImport, Guid("3B16811B-6A43-4ec9-B713-3D5A0C13B940")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IWicBitmapSourceTransform
{
}
