using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.DirectInput;

[SecurityCritical, SuppressUnmanagedCodeSecurity]
internal static class NativeMethods
{
    [DllImport("Kernel32.dll", EntryPoint = "GetModuleHandleW")]
    public static extern IntPtr GetModuleHandle(
        [MarshalAs(UnmanagedType.LPWStr)]
        string? moduleName);

    [DllImport("joy.cpl", EntryPoint = "ShowJoyCPL")]
    public static extern void ShowJoyCPL(
        [In] IntPtr hWnd);

    [DllImport("Dinput8.dll", EntryPoint = "DirectInput8Create")]
    private static extern int DirectInput8Create(IntPtr hinst, int dwVersion, in Guid riidltf, out IDirectInput8? ppvOut, IntPtr punkOuter);

    public static IDirectInput8? CreateDInput8(IntPtr hinst)
    {
        int result = DirectInput8Create(
            hinst,
            DirectInputConstants.DirectInputVersion,
            in DirectInputGuids.IDirectInput8W,
            out IDirectInput8? pOut,
            IntPtr.Zero);

        if (result < 0)
        {
            return null;
        }

        return pOut;
    }
}
