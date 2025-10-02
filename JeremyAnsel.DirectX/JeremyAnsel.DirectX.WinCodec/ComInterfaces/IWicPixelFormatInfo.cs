using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.WinCodec.ComInterfaces;

/// <remarks>Inherited from <see cref="IWicComponentInfo"/></remarks>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[ComImport, Guid("E8EDA601-3D48-431a-AB44-69059BE88BBE")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IWicPixelFormatInfo
{
}
