// <copyright file="NativeMethods.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.DirectInput;

[SecurityCritical, SuppressUnmanagedCodeSecurity]
internal static unsafe partial class NativeMethods
{
#if NET8_0_OR_GREATER
    [LibraryImport("Kernel32.dll", EntryPoint = "GetModuleHandleW")]
    public static partial nint GetModuleHandle(
#else
    [DllImport("Kernel32.dll", EntryPoint = "GetModuleHandleW")]
    public static extern nint GetModuleHandle(
#endif
        char* moduleName);

#if NET8_0_OR_GREATER
    [LibraryImport("joy.cpl", EntryPoint = "ShowJoyCPL")]
    public static partial void ShowJoyCPL(
#else
    [DllImport("joy.cpl", EntryPoint = "ShowJoyCPL")]
    public static extern void ShowJoyCPL(
#endif
        nint hWnd);

#if NET8_0_OR_GREATER
    [LibraryImport("Dinput8.dll", EntryPoint = "DirectInput8Create")]
    public static partial int DirectInput8Create(
#else
    [DllImport("Dinput8.dll", EntryPoint = "DirectInput8Create")]
    private static extern int DirectInput8Create(
#endif
        nint hinst,
        int dwVersion,
        in Guid riidltf,
        nint* ppvOut,
        nint punkOuter);

    public static nint CreateDInput8()
    {
        nint hinst = GetModuleHandle(null);

        nint ptr;
        int result = DirectInput8Create(
            hinst,
            DirectInputConstants.DirectInputVersion,
            DirectInputGuids.IDirectInput8W,
            &ptr,
            0);

        if (result < 0)
        {
            throw new InvalidOperationException("DirectInput factory creation failed.");
        }

        return ptr;
    }
}
