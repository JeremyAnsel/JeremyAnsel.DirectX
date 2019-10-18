// <copyright file="D3D11BindOptions.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;

    /// <summary>
    /// Identifies how to bind a resource to the pipeline.
    /// </summary>
    [Flags]
    public enum D3D11BindOptions
    {
        /// <summary>
        /// No option.
        /// </summary>
        None = 0,

        /// <summary>
        /// Bind a buffer as a vertex buffer to the input-assembler stage.
        /// </summary>
        VertexBuffer = 0x00000001,

        /// <summary>
        /// Bind a buffer as an index buffer to the input-assembler stage.
        /// </summary>
        IndexBuffer = 0x00000002,

        /// <summary>
        /// Bind a buffer as a constant buffer to a shader stage; this flag may NOT be combined with any other bind flag.
        /// </summary>
        ConstantBuffer = 0x00000004,

        /// <summary>
        /// Bind a buffer or texture to a shader stage; this flag cannot be used with the <see cref="D3D11MapCpuPermission.WriteNoOverwrite"/> flag.
        /// </summary>
        ShaderResource = 0x00000008,

        /// <summary>
        /// Bind an output buffer for the stream-output stage.
        /// </summary>
        StreamOutput = 0x00000010,

        /// <summary>
        /// Bind a texture as a render target for the output-merger stage.
        /// </summary>
        RenderTarget = 0x00000020,

        /// <summary>
        /// Bind a texture as a depth-stencil target for the output-merger stage.
        /// </summary>
        DepthStencil = 0x00000040,

        /// <summary>
        /// Bind an unordered access resource.
        /// </summary>
        UnorderedAccess = 0x00000080,

        /// <summary>
        /// Set this flag to indicate that a 2D texture is used to receive output from the decoder API.
        /// </summary>
        Decoder = 0x00000200,

        /// <summary>
        /// Set this flag to indicate that a 2D texture is used to receive input from the video encoder API.
        /// </summary>
        VideoEncoder = 0x00000400,
    }
}
