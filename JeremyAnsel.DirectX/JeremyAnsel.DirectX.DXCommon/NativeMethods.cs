using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.DXCommon;

[SecurityCritical, SuppressUnmanagedCodeSecurity]
internal static unsafe partial class NativeMethods
{
#if NET8_0_OR_GREATER
    [LibraryImport("Shlwapi.dll", EntryPoint = "StrFormatByteSizeW")]
    public static partial long StrFormatByteSize(long fileSize, char* buffer, int bufferSize);
#else
    [DllImport("Shlwapi.dll", EntryPoint = "StrFormatByteSizeW")]
    public unsafe static extern long StrFormatByteSize(long fileSize, char* buffer, int bufferSize);
#endif

#if NET8_0_OR_GREATER
    [LibraryImport("Kernel32.dll", EntryPoint = "GetCurrentProcess")]
    public static partial nint GetCurrentProcess();
#else
    [DllImport("Kernel32.dll", EntryPoint = "GetCurrentProcess")]
    public static extern nint GetCurrentProcess();
#endif

#if NET8_0_OR_GREATER
    [LibraryImport("Psapi.dll", EntryPoint = "GetProcessMemoryInfo")]
    public static partial void GetProcessMemoryInfo(nint process, ref DXProcessMemoryCounters counters, int cb);
#else
    [DllImport("Psapi.dll", EntryPoint = "GetProcessMemoryInfo")]
    public static extern void GetProcessMemoryInfo(nint process, ref DXProcessMemoryCounters counters, int cb);
#endif
}
