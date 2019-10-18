// <copyright file="D3D11ResourceMiscOptions.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;
    using JeremyAnsel.DirectX.Dxgi;

    /// <summary>
    /// Identifies options for resources.
    /// </summary>
    [Flags]
    public enum D3D11ResourceMiscOptions
    {
        /// <summary>
        /// No option.
        /// </summary>
        None = 0,

        /// <summary>
        /// Enables MIP map generation by using <see cref="D3D11DeviceContext.GenerateMips"/> on a texture resource. The resource must be created with the bind flags that specify that the resource is a render target and a shader resource.
        /// </summary>
        GenerateMips = 0x00000001,

        /// <summary>
        /// Enables resource data sharing between two or more Direct3D devices. The only resources that can be shared are 2D non-mipmapped textures.
        /// </summary>
        Shared = 0x00000002,

        /// <summary>
        /// Sets a resource to be a cube texture created from a Texture2DArray that contains 6 textures.
        /// </summary>
        TextureCube = 0x00000004,

        /// <summary>
        /// Enables instancing of GPU-generated content.
        /// </summary>
        DrawIndirectArgs = 0x00000010,

        /// <summary>
        /// Enables a resource as a byte address buffer.
        /// </summary>
        BufferAllowRawViews = 0x00000020,

        /// <summary>
        /// Enables a resource as a structured buffer.
        /// </summary>
        BufferStructured = 0x00000040,

        /// <summary>
        /// Enables a resource with MIP map clamping for use with <see cref="D3D11DeviceContext.SetResourceMinLod"/>.
        /// </summary>
        ResourceClamp = 0x00000080,

        /// <summary>
        /// Enables the resource to be synchronized by using the <see cref="DxgiKeyedMutex.AcquireSync"/> and <see cref="DxgiKeyedMutex.ReleaseSync"/> APIs.
        /// </summary>
        SharedKeyedMutex = 0x00000100,

        /// <summary>
        /// Enables a resource compatible with GDI.
        /// </summary>
        GdiCompatible = 0x00000200,

        /// <summary>
        /// Set this flag to enable the use of NT HANDLE values when you create a shared resource. By enabling this flag, you deprecate the use of existing HANDLE values.
        /// </summary>
        SharedNTHandle = 0x00000800,

        /// <summary>
        /// Set this flag to indicate that the resource might contain protected content; therefore, the operating system should use the resource only when the driver and hardware support content protection. If the driver and hardware do not support content protection and you try to create a resource with this flag, the resource creation fails.
        /// </summary>
        RestrictedContent = 0x00001000,

        /// <summary>
        /// Set this flag to indicate that the operating system restricts access to the shared surface.
        /// </summary>
        RestrictSharedResource = 0x00002000,

        /// <summary>
        /// Set this flag to indicate that the driver restricts access to the shared surface.
        /// </summary>
        RestrictSharedResourceDriver = 0x00004000,

        /// <summary>
        /// Set this flag to indicate that the resource is guarded.
        /// </summary>
        Guarded = 0x00008000,

        /// <summary>
        /// Set this flag to indicate that the resource is a tile pool.
        /// </summary>
        TilePool = 0x00020000,

        /// <summary>
        /// Set this flag to indicate that the resource is a tiled resource.
        /// </summary>
        Tiled = 0x00040000,
    }
}
