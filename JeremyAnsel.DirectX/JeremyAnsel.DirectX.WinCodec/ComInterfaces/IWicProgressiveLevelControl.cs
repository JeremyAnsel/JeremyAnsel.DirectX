using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.WinCodec.ComInterfaces;

[SecurityCritical, SuppressUnmanagedCodeSecurity]
[ComImport, Guid("DAAC296F-7AA5-4dbf-8D15-225C5976F891")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IWicProgressiveLevelControl
{
}
