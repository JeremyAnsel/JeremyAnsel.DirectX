// <copyright file="ID2D1Layer.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.D2D1.ComInterfaces;

/// <summary>
/// Represents the backing store required to render a layer.
/// </summary>
/// <remarks>Inherited from <see cref="ID2D1Resource"/></remarks>
[Guid("2cd9069b-12e2-11dc-9fed-001143a055f9")]
internal unsafe readonly struct ID2D1Layer
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
    private readonly nint GetFactory;

    /// <summary>
    /// Gets the size of the layer in device-independent pixels.
    /// </summary>
    /// <param name="size">The size of the layer in device-independent pixels.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, void> GetSize;
}
