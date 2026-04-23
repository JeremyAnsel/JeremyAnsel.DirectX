// <copyright file="ID3D11ComputeShader.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.D3D11.ComInterfaces;

/// <summary>
/// A compute shader interface manages an executable program (a compute shader) that controls the compute shader stage.
/// </summary>
/// <remarks>Inherited from <see cref="ID3D11DeviceChild"/></remarks>
[Guid("4f5b196e-c2bd-495e-bd01-1fded38e4969")]
internal unsafe readonly struct ID3D11ComputeShader
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
    private readonly nint GetDevice;
    private readonly nint GetPrivateData;
    private readonly nint SetPrivateData;
    private readonly nint SetPrivateDataInterface;
}
