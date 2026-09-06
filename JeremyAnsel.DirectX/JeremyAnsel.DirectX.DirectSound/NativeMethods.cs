using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.DirectSound;

/// <summary>
/// Native methods.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
internal static unsafe partial class NativeMethods
{
#if NET8_0_OR_GREATER
    [LibraryImport("dsound.dll", EntryPoint = "DirectSoundCreate")]
    public static partial int DirectSoundCreate(
#else
    [DllImport("dsound.dll", EntryPoint = "DirectSoundCreate")]
    public static extern int DirectSoundCreate(
#endif
        nint lpcGuid,
        nint* ppDS,
        nint pUnkOuter);
}
