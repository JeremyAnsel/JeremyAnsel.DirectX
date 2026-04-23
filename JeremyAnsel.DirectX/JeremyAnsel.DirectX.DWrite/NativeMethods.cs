// <copyright file="NativeMethods.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.DWrite;

/// <summary>
/// Native methods.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
internal static unsafe partial class NativeMethods
{
    /// <summary>
    /// Creates a DirectWrite factory object that is used for subsequent creation of individual DirectWrite objects.
    /// </summary>
    /// <param name="factoryType">Identifies whether the factory object will be shared or isolated.</param>
    /// <param name="iid">Identifies the DirectWrite factory interface, such as <c>__uuidof(IDWriteFactory)</c>.</param>
    /// <param name="factory">Receives the DirectWrite factory object.</param>
    /// <remarks>
    /// Obtains DirectWrite factory object that is used for subsequent creation of individual DirectWrite classes.
    /// DirectWrite factory contains internal state such as font loader registration and cached font data.
    /// In most cases it is recommended to use the shared factory object, because it allows multiple components
    /// that use DirectWrite to share internal DirectWrite state and reduce memory usage.
    /// However, there are cases when it is desirable to reduce the impact of a component,
    /// such as a plug-in from an untrusted source, on the rest of the process by sandboxing and isolating it
    /// from the rest of the process components. In such cases, it is recommended to use an isolated factory for the sandboxed
    /// component.
    /// </remarks>
#if NET8_0_OR_GREATER
    [LibraryImport("Dwrite.dll", EntryPoint = "DWriteCreateFactory")]
    public static partial int DWriteCreateFactory(
#else
    [DllImport("Dwrite.dll", EntryPoint = "DWriteCreateFactory")]
    public static extern int DWriteCreateFactory(
#endif
        DWriteFactoryType factoryType,
        in Guid iid,
        nint* factory);
}
