// <copyright file="ID2D1GdiInteropRenderTarget.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.D2D1.ComInterfaces;

/// <summary>
/// Provides access to an device context that can accept GDI drawing commands.
/// </summary>
[Guid("e0db51c3-6f77-4bae-b3d5-e47509b35838")]
internal unsafe readonly struct ID2D1GdiInteropRenderTarget
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;

    /// <summary>
    /// Retrieves the device context associated with this render target.
    /// </summary>
    /// <param name="mode">A value that specifies whether the device context should be cleared.</param>
    /// <param name="hdc">The device context associated with this render target.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, D2D1DCInitializeMode, nint*, int> GetDC;

    /// <summary>
    /// Indicates that drawing with the device context retrieved using the <see cref="GetDC"/> method is finished.
    /// </summary>
    /// <param name="update">The modified region of the device context.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, int> ReleaseDC;
}
