// <copyright file="D3D11FormatSupport.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;

    /// <summary>
    /// Which resources are supported for a given format and given device.
    /// </summary>
    [Flags]
    public enum D3D11FormatSupport
    {
        /// <summary>
        /// No value.
        /// </summary>
        None = 0,

        /// <summary>
        /// Buffer resources supported.
        /// </summary>
        Buffer = 0x00000001,

        /// <summary>
        /// Vertex buffers supported.
        /// </summary>
        InputAssemblerVertexBuffer = 0x00000002,

        /// <summary>
        /// Index buffers supported.
        /// </summary>
        InputAssemblerIndexBuffer = 0x00000004,

        /// <summary>
        /// Streaming output buffers supported.
        /// </summary>
        StreamOutputBuffer = 0x00000008,

        /// <summary>
        /// 1D texture resources supported.
        /// </summary>
        Texture1D = 0x00000010,

        /// <summary>
        /// 2D texture resources supported.
        /// </summary>
        Texture2D = 0x00000020,

        /// <summary>
        /// 3D texture resources supported.
        /// </summary>
        Texture3D = 0x00000040,

        /// <summary>
        /// Cube texture resources supported.
        /// </summary>
        TextureCube = 0x00000080,

        /// <summary>
        /// The HLSL Load function for texture objects is supported.
        /// </summary>
        ShaderLoad = 0x00000100,

        /// <summary>
        /// The HLSL Sample function for texture objects is supported.
        /// <note type="note">If the device supports the format as a resource (1D, 2D, 3D, or cube map) but doesn't support this option, the resource can still use the Sample method but must use only the point filtering sampler state to perform the sample.</note>
        /// </summary>
        ShaderSample = 0x00000200,

        /// <summary>
        /// The HLSL <c>SampleCmp</c> and <c>SampleCmpLevelZero </c>functions for texture objects are supported.
        /// </summary>
        ShaderSampleComparison = 0x00000400,

        /// <summary>
        /// Reserved value.
        /// </summary>
        ShaderSampleMonoTexture = 0x00000800,

        /// <summary>
        /// Mipmaps are supported.
        /// </summary>
        Mip = 0x00001000,

        /// <summary>
        /// Automatic generation of mipmaps is supported.
        /// </summary>
        MipAutogen = 0x00002000,

        /// <summary>
        /// Render targets are supported.
        /// </summary>
        RenderTarget = 0x00004000,

        /// <summary>
        /// Blend operations supported.
        /// </summary>
        Blendable = 0x00008000,

        /// <summary>
        /// Depth stencils supported.
        /// </summary>
        DepthStencil = 0x00010000,

        /// <summary>
        /// CPU locking supported.
        /// </summary>
        CpuLockable = 0x00020000,

        /// <summary>
        /// Multisample antialiasing (MSAA) resolve operations are supported.
        /// </summary>
        MultisampleResolve = 0x00040000,

        /// <summary>
        /// Format can be displayed on screen.
        /// </summary>
        Display = 0x00080000,

        /// <summary>
        /// Format cannot be cast to another format.
        /// </summary>
        CastWithinBitLayout = 0x00100000,

        /// <summary>
        /// Format can be used as a multisampled render target.
        /// </summary>
        MultisampleRenderTarget = 0x00200000,

        /// <summary>
        /// Format can be used as a multisampled texture and read into a shader with the HLSL load function.
        /// </summary>
        MultisampleLoad = 0x00400000,

        /// <summary>
        /// Format can be used with the HLSL gather function.
        /// </summary>
        ShaderGather = 0x00800000,

        /// <summary>
        /// Format supports casting when the resource is a back buffer.
        /// </summary>
        BackBufferCast = 0x01000000,

        /// <summary>
        /// Format can be used for an unordered access view.
        /// </summary>
        TypedUnorderedAccessView = 0x02000000,

        /// <summary>
        /// Format can be used with the HLSL gather with comparison function.
        /// </summary>
        ShaderGatherComparison = 0x04000000,

        /// <summary>
        /// Format can be used with the decoder output.
        /// </summary>
        DecoderOutput = 0x08000000,

        /// <summary>
        /// Format can be used with the video processor output.
        /// </summary>
        VideoProcessorOutput = 0x10000000,

        /// <summary>
        /// Format can be used with the video processor input.
        /// </summary>
        VideoProcessorInput = 0x20000000,

        /// <summary>
        /// Format can be used with the video encoder.
        /// </summary>
        VideoEncoder = 0x40000000,
    }
}
