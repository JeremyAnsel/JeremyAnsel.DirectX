// <copyright file="ID3D11PixelShader.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.D3D11.ComInterfaces;

/// <summary>
/// A pixel shader interface manages an executable program (a pixel shader) that controls the pixel shader stage.
/// </summary>
/// <remarks>Inherited from <see cref="ID3D11DeviceChild"/></remarks>
[Guid("ea82e40d-51dc-4f33-93d4-db7c9125ae8c")]
internal unsafe readonly struct ID3D11PixelShader
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
    private readonly nint GetDevice;
    private readonly nint GetPrivateData;
    private readonly nint SetPrivateData;
    private readonly nint SetPrivateDataInterface;
}
