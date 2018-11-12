// <copyright file="ID3D11DeviceContext.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11.ComInterfaces
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;
    using JeremyAnsel.DirectX.Dxgi;

    /// <summary>
    /// Represents a device context which generates rendering commands.
    /// </summary>
    /// <remarks>Inherited from <see cref="ID3D11DeviceChild"/></remarks>
    [SecurityCritical, SuppressUnmanagedCodeSecurity]
    [ComImport, Guid("c0bfa96c-e089-44fb-8eaf-26f8796190da")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ID3D11DeviceContext
    {
        /// <summary>
        /// Get a pointer to the device that created this interface.
        /// </summary>
        /// <param name="device">A device.</param>
        [PreserveSig]
        void GetDevice(
            [Out] out ID3D11Device device);

        /// <summary>
        /// Get application-defined data from a device.
        /// </summary>
        /// <param name="name">The Guid associated with the data.</param>
        /// <param name="dataSize">A pointer to a variable that on input contains the size, in bytes, of the buffer.</param>
        /// <param name="data">A pointer to a buffer that will be filled with data from the device.</param>
        void GetPrivateData(
            [In] ref Guid name,
            [In, Out] ref uint dataSize,
            [Out, MarshalAs(UnmanagedType.LPArray)] byte[] data);

        /// <summary>
        /// Set data to a device and associate that data with a guid.
        /// </summary>
        /// <param name="name">The Guid associated with the data.</param>
        /// <param name="dataSize">The size of the data.</param>
        /// <param name="data">The data to be stored with this device.</param>
        void SetPrivateData(
            [In] ref Guid name,
            [In] uint dataSize,
            [In, MarshalAs(UnmanagedType.LPArray)] byte[] data);

        /// <summary>
        /// Associate an IUnknown-derived interface with this device child and associate that interface with an application-defined guid.
        /// </summary>
        /// <param name="name">The Guid associated with the interface.</param>
        /// <param name="unknown">An <c>IUnknown</c>-derived interface to be associated with the device child.</param>
        void SetPrivateDataInterface(
            [In] ref Guid name,
            [In, MarshalAs(UnmanagedType.IUnknown)] object unknown);

        /// <summary>
        /// Sets the constant buffers used by the vertex shader pipeline stage.
        /// </summary>
        /// <param name="startSlot">Index into the device's zero-based array to begin setting constant buffers to.</param>
        /// <param name="numBuffers">Number of buffers to set.</param>
        /// <param name="constantBuffers">Array of constant buffers being given to the device.</param>
        [PreserveSig]
        void VertexShaderSetConstantBuffers(
            [In] uint startSlot,
            [In] uint numBuffers,
            [In, MarshalAs(UnmanagedType.LPArray)] ID3D11Buffer[] constantBuffers);

        /// <summary>
        /// Bind an array of shader resources to the pixel shader stage.
        /// </summary>
        /// <param name="startSlot">Index into the device's zero-based array to begin setting shader resources to.</param>
        /// <param name="numViews">Number of shader resources to set.</param>
        /// <param name="shaderResourceViews">Array of shader resource view interfaces to set to the device.</param>
        [PreserveSig]
        void PixelShaderSetShaderResources(
            [In] uint startSlot,
            [In] uint numViews,
            [In, MarshalAs(UnmanagedType.LPArray)] ID3D11ShaderResourceView[] shaderResourceViews);

        /// <summary>
        /// Sets a pixel shader to the device.
        /// </summary>
        /// <param name="pixelShader">A pixel shader.</param>
        /// <param name="classInstances">An array of class-instance interfaces.</param>
        /// <param name="numClassInstances">The number of class-instance interfaces in the array.</param>
        [PreserveSig]
        void PixelShaderSetShader(
            [In] ID3D11PixelShader pixelShader,
            [In, MarshalAs(UnmanagedType.LPArray)] ID3D11ClassInstance[] classInstances,
            [In] uint numClassInstances);

        /// <summary>
        /// Set an array of sampler states to the pixel shader pipeline stage.
        /// </summary>
        /// <param name="startSlot">Index into the device's zero-based array to begin setting samplers to.</param>
        /// <param name="numSamplers">Number of samplers in the array.</param>
        /// <param name="samplers">An array of sampler-state interfaces.</param>
        [PreserveSig]
        void PixelShaderSetSamplers(
            [In] uint startSlot,
            [In] uint numSamplers,
            [In, MarshalAs(UnmanagedType.LPArray)] ID3D11SamplerState[] samplers);

        /// <summary>
        /// Set a vertex shader to the device.
        /// </summary>
        /// <param name="vertexShader">A vertex shader.</param>
        /// <param name="classInstances">An array of class-instance interfaces.</param>
        /// <param name="numClassInstances">The number of class-instance interfaces in the array.</param>
        [PreserveSig]
        void VertexShaderSetShader(
            [In] ID3D11VertexShader vertexShader,
            [In, MarshalAs(UnmanagedType.LPArray)] ID3D11ClassInstance[] classInstances,
            [In] uint numClassInstances);

        /// <summary>
        /// Draw indexed, non-instanced primitives.
        /// </summary>
        /// <param name="indexCount">Number of indices to draw.</param>
        /// <param name="startIndexLocation">The location of the first index read by the GPU from the index buffer.</param>
        /// <param name="baseVertexLocation">A value added to each index before reading a vertex from the vertex buffer.</param>
        [PreserveSig]
        void DrawIndexed(
            [In] uint indexCount,
            [In] uint startIndexLocation,
            [In] int baseVertexLocation);

        /// <summary>
        /// Draw non-indexed, non-instanced primitives.
        /// </summary>
        /// <param name="vertexCount">Number of vertices to draw.</param>
        /// <param name="startVertexLocation">Index of the first vertex, which is usually an offset in a vertex buffer.</param>
        [PreserveSig]
        void Draw(
            [In] uint vertexCount,
            [In] uint startVertexLocation);

        /// <summary>
        /// Gets a pointer to the data contained in a subresource, and denies the GPU access to that subresource.
        /// </summary>
        /// <param name="resource">A <see cref="ID3D11Resource"/> interface.</param>
        /// <param name="subresource">Index number of the subresource.</param>
        /// <param name="mapType">The CPU's read and write permissions for a resource.</param>
        /// <param name="mapOptions">Specifies what the CPU does when the GPU is busy.</param>
        /// <returns>The mapped subresource.</returns>
        D3D11MappedSubResource Map(
            [In] ID3D11Resource resource,
            [In] uint subresource,
            [In] D3D11MapCpuPermission mapType,
            [In] D3D11MapOptions mapOptions);

        /// <summary>
        /// Invalidate the pointer to a resource and reenable the GPU's access to that resource.
        /// </summary>
        /// <param name="resource">A <see cref="ID3D11Resource"/> interface.</param>
        /// <param name="subresource">A subresource to be unmapped.</param>
        [PreserveSig]
        void Unmap(
            [In] ID3D11Resource resource,
            [In] uint subresource);

        /// <summary>
        /// Sets the constant buffers used by the pixel shader pipeline stage.
        /// </summary>
        /// <param name="startSlot">Index into the device's zero-based array to begin setting constant buffers to.</param>
        /// <param name="numBuffers">Number of buffers to set.</param>
        /// <param name="constantBuffers">Array of constant buffers.</param>
        [PreserveSig]
        void PixelShaderSetConstantBuffers(
            [In] uint startSlot,
            [In] uint numBuffers,
            [In, MarshalAs(UnmanagedType.LPArray)] ID3D11Buffer[] constantBuffers);

        /// <summary>
        /// Bind an input-layout object to the input-assembler stage.
        /// </summary>
        /// <param name="inputLayout">The input-layout object.</param>
        [PreserveSig]
        void InputAssemblerSetInputLayout(
            [In] ID3D11InputLayout inputLayout);

        /// <summary>
        /// Bind an array of vertex buffers to the input-assembler stage.
        /// </summary>
        /// <param name="startSlot">The first input slot for binding.</param>
        /// <param name="numBuffers">The number of vertex buffers in the array.</param>
        /// <param name="vertexBuffers">An array of vertex buffers.</param>
        /// <param name="strides">An array of stride values; one stride value for each buffer in the vertex-buffer array.</param>
        /// <param name="offsets">An array of offset values; one offset value for each buffer in the vertex-buffer array.</param>
        [PreserveSig]
        void InputAssemblerSetVertexBuffers(
            [In] uint startSlot,
            [In] uint numBuffers,
            [In, MarshalAs(UnmanagedType.LPArray)] ID3D11Buffer[] vertexBuffers,
            [In, MarshalAs(UnmanagedType.LPArray)] uint[] strides,
            [In, MarshalAs(UnmanagedType.LPArray)] uint[] offsets);

        /// <summary>
        /// Bind an index buffer to the input-assembler stage.
        /// </summary>
        /// <param name="indexBuffer">An <see cref="ID3D11Buffer"/> object, that contains indices.</param>
        /// <param name="format">The format of the data in the index buffer.</param>
        /// <param name="offset">Offset (in bytes) from the start of the index buffer to the first index to use.</param>
        [PreserveSig]
        void InputAssemblerSetIndexBuffer(
            [In] ID3D11Buffer indexBuffer,
            [In] DxgiFormat format,
            [In] uint offset);

        /// <summary>
        /// Draw indexed, instanced primitives.
        /// </summary>
        /// <param name="indexCountPerInstance">Number of indices read from the index buffer for each instance.</param>
        /// <param name="instanceCount">Number of instances to draw.</param>
        /// <param name="startIndexLocation">The location of the first index read by the GPU from the index buffer.</param>
        /// <param name="baseVertexLocation">A value added to each index before reading a vertex from the vertex buffer.</param>
        /// <param name="startInstanceLocation">A value added to each index before reading per-instance data from a vertex buffer.</param>
        [PreserveSig]
        void DrawIndexedInstanced(
            [In] uint indexCountPerInstance,
            [In] uint instanceCount,
            [In] uint startIndexLocation,
            [In] int baseVertexLocation,
            [In] uint startInstanceLocation);

        /// <summary>
        /// Draw non-indexed, instanced primitives.
        /// </summary>
        /// <param name="vertexCountPerInstance">Number of vertices to draw.</param>
        /// <param name="instanceCount">Number of instances to draw.</param>
        /// <param name="startVertexLocation">Index of the first vertex.</param>
        /// <param name="startInstanceLocation">A value added to each index before reading per-instance data from a vertex buffer.</param>
        [PreserveSig]
        void DrawInstanced(
            [In] uint vertexCountPerInstance,
            [In] uint instanceCount,
            [In] uint startVertexLocation,
            [In] uint startInstanceLocation);

        /// <summary>
        /// Sets the constant buffers used by the geometry shader pipeline stage.
        /// </summary>
        /// <param name="startSlot">Index into the device's zero-based array to begin setting constant buffers to.</param>
        /// <param name="numBuffers">Number of buffers to set.</param>
        /// <param name="constantBuffers">Array of constant buffers.</param>
        [PreserveSig]
        void GeometryShaderSetConstantBuffers(
            [In] uint startSlot,
            [In] uint numBuffers,
            [In, MarshalAs(UnmanagedType.LPArray)] ID3D11Buffer[] constantBuffers);

        /// <summary>
        /// Set a geometry shader to the device.
        /// </summary>
        /// <param name="shader">A geometry shader.</param>
        /// <param name="classInstances">An array of class-instance interfaces.</param>
        /// <param name="numClassInstances">The number of class-instance interfaces in the array.</param>
        [PreserveSig]
        void GeometryShaderSetShader(
            [In] ID3D11GeometryShader shader,
            [In, MarshalAs(UnmanagedType.LPArray)] ID3D11ClassInstance[] classInstances,
            [In] uint numClassInstances);

        /// <summary>
        /// Bind information about the primitive type, and data order that describes input data for the input assembler stage.
        /// </summary>
        /// <param name="topology">The type of primitive and ordering of the primitive data.</param>
        [PreserveSig]
        void InputAssemblerSetPrimitiveTopology(
            [In] D3D11PrimitiveTopology topology);

        /// <summary>
        /// Bind an array of shader resources to the vertex shader stage.
        /// </summary>
        /// <param name="startSlot">Index into the device's zero-based array to begin setting shader resources to.</param>
        /// <param name="numViews">Number of shader resources to set.</param>
        /// <param name="shaderResourceViews">Array of shader resource view interfaces to set to the device.</param>
        [PreserveSig]
        void VertexShaderSetShaderResources(
            [In] uint startSlot,
            [In] uint numViews,
            [In, MarshalAs(UnmanagedType.LPArray)] ID3D11ShaderResourceView[] shaderResourceViews);

        /// <summary>
        /// Set an array of sampler states to the vertex shader pipeline stage.
        /// </summary>
        /// <param name="startSlot">Index into the device's zero-based array to begin setting samplers to.</param>
        /// <param name="numSamplers">Number of samplers in the array.</param>
        /// <param name="samplers">An array of sampler-state interfaces.</param>
        [PreserveSig]
        void VertexShaderSetSamplers(
            [In] uint startSlot,
            [In] uint numSamplers,
            [In, MarshalAs(UnmanagedType.LPArray)] ID3D11SamplerState[] samplers);

        /// <summary>
        /// Mark the beginning of a series of commands.
        /// </summary>
        /// <param name="async">An <see cref="ID3D11Asynchronous"/> interface.</param>
        [PreserveSig]
        void Begin(
            [In] ID3D11Asynchronous async);

        /// <summary>
        /// Mark the end of a series of commands.
        /// </summary>
        /// <param name="async">An <see cref="ID3D11Asynchronous"/> interface.</param>
        [PreserveSig]
        void End(
            [In] ID3D11Asynchronous async);

        /// <summary>
        /// Get data from the graphics processing unit (GPU) asynchronously.
        /// </summary>
        /// <param name="async">An <see cref="ID3D11Asynchronous"/> interface for the object about which <c>GetData</c> retrieves data.</param>
        /// <param name="dataPtr">Address of memory that will receive the data.</param>
        /// <param name="dataSize">Size of the data to retrieve or 0.</param>
        /// <param name="options">Optional flags.</param>
        /// <returns>A boolean value indicating whether the operation succeeded.</returns>
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Bool)]
        bool GetData(
            [In] ID3D11Asynchronous async,
            [Out] IntPtr dataPtr,
            [In] uint dataSize,
            [In] D3D11AsyncGetDataOptions options);

        /// <summary>
        /// Set a rendering predicate.
        /// </summary>
        /// <param name="predicate">A predicate.</param>
        /// <param name="predicateValue">A value indicating whether rendering will be affected by when the predicate's conditions are met or not met.</param>
        [PreserveSig]
        void SetPredication(
            [In] ID3D11Predicate predicate,
            [In, MarshalAs(UnmanagedType.Bool)] bool predicateValue);

        /// <summary>
        /// Bind an array of shader resources to the geometry shader stage.
        /// </summary>
        /// <param name="startSlot">Index into the device's zero-based array to begin setting shader resources to.</param>
        /// <param name="numView">Number of shader resources to set.</param>
        /// <param name="shaderResourceViews">Array of shader resource view interfaces to set to the device.</param>
        [PreserveSig]
        void GeometryShaderSetShaderResources(
            [In] uint startSlot,
            [In] uint numView,
            [In, MarshalAs(UnmanagedType.LPArray)] ID3D11ShaderResourceView[] shaderResourceViews);

        /// <summary>
        /// Set an array of sampler states to the geometry shader pipeline stage.
        /// </summary>
        /// <param name="startSlot">Index into the device's zero-based array to begin setting samplers to.</param>
        /// <param name="numSamplers">Number of samplers in the array.</param>
        /// <param name="samplers">An array of sampler-state interfaces.</param>
        [PreserveSig]
        void GeometryShaderSetSamplers(
            [In] uint startSlot,
            [In] uint numSamplers,
            [In, MarshalAs(UnmanagedType.LPArray)] ID3D11SamplerState[] samplers);

        /// <summary>
        /// Bind one or more render targets atomically and the depth-stencil buffer to the output-merger stage.
        /// </summary>
        /// <param name="numViews">Number of render targets to bind.</param>
        /// <param name="renderTargetViews">The render targets to bind to the device.</param>
        /// <param name="depthStencilView">The depth-stencil view to bind to the device.</param>
        [PreserveSig]
        void OutputMergerSetRenderTargets(
            [In] uint numViews,
            [In, MarshalAs(UnmanagedType.LPArray)] ID3D11RenderTargetView[] renderTargetViews,
            [In] ID3D11DepthStencilView depthStencilView);

        /// <summary>
        /// Binds resources to the output-merger stage.
        /// </summary>
        /// <param name="numRenderTargetViews">Number of render targets to bind.</param>
        /// <param name="renderTargetViews">The render targets to bind to the device.</param>
        /// <param name="depthStencilView">The depth-stencil view to bind to the device.</param>
        /// <param name="uavStartSlot">Index into a zero-based array to begin setting unordered-access views.</param>
        /// <param name="numUnorderedAccessViews">Number of unordered-access views (UAVs).</param>
        /// <param name="unorderedAccessViews">The unordered-access views to bind to the device.</param>
        /// <param name="uavInitialCounts">An array of append and consume buffer offsets. A value of <value>-1</value> indicates to keep the current offset.</param>
        [PreserveSig]
        void OutputMergerSetRenderTargetsAndUnorderedAccessViews(
            [In] uint numRenderTargetViews,
            [In, MarshalAs(UnmanagedType.LPArray)] ID3D11RenderTargetView[] renderTargetViews,
            [In] ID3D11DepthStencilView depthStencilView,
            [In] uint uavStartSlot,
            [In] uint numUnorderedAccessViews,
            [In, MarshalAs(UnmanagedType.LPArray)] ID3D11UnorderedAccessView[] unorderedAccessViews,
            [In, MarshalAs(UnmanagedType.LPArray)] uint[] uavInitialCounts);

        /// <summary>
        /// Set the blend state of the output-merger stage.
        /// </summary>
        /// <param name="blendState">A blend-state interface.</param>
        /// <param name="blendFactor">Array of blend factors, one for each RGBA component. The blend factors modulate values for the pixel shader, render target, or both.</param>
        /// <param name="sampleMask">32-bit sample coverage. The default value is <value>0xffffffff</value>.</param>
        [PreserveSig]
        void OutputMergerSetBlendState(
            [In] ID3D11BlendState blendState,
            [In, MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] float[] blendFactor,
            [In] uint sampleMask);

        /// <summary>
        /// Sets the depth-stencil state of the output-merger stage.
        /// </summary>
        /// <param name="depthStencilState">A depth-stencil state interface.</param>
        /// <param name="stencilReference">Reference value to perform against when doing a depth-stencil test.</param>
        [PreserveSig]
        void OutputMergerSetDepthStencilState(
            [In] ID3D11DepthStencilState depthStencilState,
            [In] uint stencilReference);

        /// <summary>
        /// Reference value to perform against when doing a depth-stencil test.
        /// </summary>
        /// <param name="numBuffers">The number of buffer to bind to the device.</param>
        /// <param name="targets">The array of output buffers to bind to the device.</param>
        /// <param name="offsets">Array of offsets to the output buffers.</param>
        [PreserveSig]
        void StreamOutputSetTargets(
            [In] uint numBuffers,
            [In, MarshalAs(UnmanagedType.LPArray)] ID3D11Buffer[] targets,
            [In, MarshalAs(UnmanagedType.LPArray)] uint[] offsets);

        /// <summary>
        /// Draw geometry of an unknown size.
        /// </summary>
        [PreserveSig]
        void DrawAuto();

        /// <summary>
        /// Draw indexed, instanced, GPU-generated primitives.
        /// </summary>
        /// <param name="bufferForArgs">A buffer containing the GPU generated primitives.</param>
        /// <param name="alignedByteOffsetForArgs">Offset to the start of the GPU generated primitives.</param>
        [PreserveSig]
        void DrawIndexedInstancedIndirect(
            [In] ID3D11Buffer bufferForArgs,
            [In] uint alignedByteOffsetForArgs);

        /// <summary>
        /// Draw instanced, GPU-generated primitives.
        /// </summary>
        /// <param name="bufferForArgs">A buffer containing the GPU generated primitives.</param>
        /// <param name="alignedByteOffsetForArgs">Offset to the start of the GPU generated primitives.</param>
        [PreserveSig]
        void DrawInstancedIndirect(
            [In] ID3D11Buffer bufferForArgs,
            [In] uint alignedByteOffsetForArgs);

        /// <summary>
        /// Execute a command list from a thread group.
        /// </summary>
        /// <param name="threadGroupCountX">The number of groups dispatched in the x direction.</param>
        /// <param name="threadGroupCountY">The number of groups dispatched in the y direction.</param>
        /// <param name="threadGroupCountZ">The number of groups dispatched in the z direction.</param>
        [PreserveSig]
        void Dispatch(
            [In] uint threadGroupCountX,
            [In] uint threadGroupCountY,
            [In] uint threadGroupCountZ);

        /// <summary>
        /// Execute a command list over one or more thread groups.
        /// </summary>
        /// <param name="bufferForArgs">A buffer, which must be loaded with data that matches the argument list.</param>
        /// <param name="alignedByteOffsetForArgs">A byte-aligned offset between the start of the buffer and the arguments.</param>
        [PreserveSig]
        void DispatchIndirect(
            [In] ID3D11Buffer bufferForArgs,
            [In] uint alignedByteOffsetForArgs);

        /// <summary>
        /// Set the rasterizer state for the rasterizer stage of the pipeline.
        /// </summary>
        /// <param name="rasterizerState">A rasterizer-state interface.</param>
        [PreserveSig]
        void RasterizerStageSetState(
            [In] ID3D11RasterizerState rasterizerState);

        /// <summary>
        /// Bind an array of viewports to the rasterizer stage of the pipeline.
        /// </summary>
        /// <param name="numViewports">Number of viewports to bind.</param>
        /// <param name="viewports">An array of <see cref="D3D11Viewport"/> structures to bind to the device.</param>
        [PreserveSig]
        void RasterizerStageSetViewports(
            [In] uint numViewports,
            [In, MarshalAs(UnmanagedType.LPArray)] D3D11Viewport[] viewports);

        /// <summary>
        /// Bind an array of scissor rectangles to the rasterizer stage.
        /// </summary>
        /// <param name="numRects">Number of scissor rectangles to bind.</param>
        /// <param name="rects">An array of scissor rectangles.</param>
        [PreserveSig]
        void RasterizerStageSetScissorRects(
            [In] uint numRects,
            [In, MarshalAs(UnmanagedType.LPArray)] D3D11Rect[] rects);

        /// <summary>
        /// Copy a region from a source resource to a destination resource.
        /// </summary>
        /// <param name="destinationResource">The destination resource.</param>
        /// <param name="destinationSubresource">Destination subresource index.</param>
        /// <param name="destinationX">The x-coordinate of the upper left corner of the destination region.</param>
        /// <param name="destinationY">The y-coordinate of the upper left corner of the destination region.</param>
        /// <param name="destinationZ">The z-coordinate of the upper left corner of the destination region.</param>
        /// <param name="sourceResource">The source resource.</param>
        /// <param name="sourceSubresource">Source subresource index.</param>
        /// <param name="sourceBox">A 3D box that defines the source subresource that can be copied.</param>
        [PreserveSig]
        void CopySubresourceRegion(
            [In] ID3D11Resource destinationResource,
            [In] uint destinationSubresource,
            [In] uint destinationX,
            [In] uint destinationY,
            [In] uint destinationZ,
            [In] ID3D11Resource sourceResource,
            [In] uint sourceSubresource,
            [In] ref D3D11Box sourceBox);

        /// <summary>
        /// Copy the entire contents of the source resource to the destination resource using the GPU.
        /// </summary>
        /// <param name="destinationResource">The destination resource.</param>
        /// <param name="sourceResource">The source resource.</param>
        [PreserveSig]
        void CopyResource(
            [In] ID3D11Resource destinationResource,
            [In] ID3D11Resource sourceResource);

        /// <summary>
        /// The CPU copies data from memory to a subresource created in non-mappable memory.
        /// </summary>
        /// <param name="destinationResource">The destination resource.</param>
        /// <param name="destinationSubresource">A zero-based index, that identifies the destination subresource.</param>
        /// <param name="destinationBox">A box that defines the portion of the destination subresource to copy the resource data into. Coordinates are in bytes for buffers and in texels for textures.</param>
        /// <param name="sourceData">A pointer to the source data in memory.</param>
        /// <param name="sourceRowPitch">The size of one row of the source data.</param>
        /// <param name="sourceDepthPitch">The size of one depth slice of source data.</param>
        [PreserveSig]
        void UpdateSubresource(
            [In] ID3D11Resource destinationResource,
            [In] uint destinationSubresource,
            [In] IntPtr destinationBox,
            [In] IntPtr sourceData,
            [In] uint sourceRowPitch,
            [In] uint sourceDepthPitch);

        /// <summary>
        /// Copies data from a buffer holding variable length data.
        /// </summary>
        /// <param name="destinationBuffer">The destination buffer.</param>
        /// <param name="destinationAlignedByteOffset">Offset from the start of the buffer to write 32-bit UINT structure (vertex) count.</param>
        /// <param name="sourceView">A structured buffer resource.</param>
        [PreserveSig]
        void CopyStructureCount(
            [In] ID3D11Buffer destinationBuffer,
            [In] uint destinationAlignedByteOffset,
            [In] ID3D11UnorderedAccessView sourceView);

        /// <summary>
        /// Set all the elements in a render target to one value.
        /// </summary>
        /// <param name="renderTargetView">The render target.</param>
        /// <param name="colorRGBA">A 4-component array that represents the color to fill the render target with.</param>
        [PreserveSig]
        void ClearRenderTargetView(
            [In] ID3D11RenderTargetView renderTargetView,
            [In, MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] float[] colorRGBA);

        /// <summary>
        /// Clears an unordered access resource with bit-precise values.
        /// </summary>
        /// <param name="unorderedAccessView">The unordered access resource to clear.</param>
        /// <param name="values">Values to copy to corresponding channels.</param>
        [PreserveSig]
        void ClearUnorderedAccessViewUInt(
            [In] ID3D11UnorderedAccessView unorderedAccessView,
            [In, MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] uint[] values);

        /// <summary>
        /// Clears an unordered access resource with a float value.
        /// </summary>
        /// <param name="unorderedAccessView">The unordered access resource to clear.</param>
        /// <param name="values">Values to copy to corresponding channels.</param>
        [PreserveSig]
        void ClearUnorderedAccessViewFloat(
            [In] ID3D11UnorderedAccessView unorderedAccessView,
            [In, MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] float[] values);

        /// <summary>
        /// Clears the depth-stencil resource.
        /// </summary>
        /// <param name="depthStencilView">The depth stencil to be cleared.</param>
        /// <param name="clearOptions">Identify the type of data to clear.</param>
        /// <param name="depth">Clear the depth buffer with this value. This value will be clamped between 0 and 1.</param>
        /// <param name="stencil">Clear the stencil buffer with this value.</param>
        [PreserveSig]
        void ClearDepthStencilView(
            [In] ID3D11DepthStencilView depthStencilView,
            [In] D3D11ClearOptions clearOptions,
            [In] float depth,
            [In] byte stencil);

        /// <summary>
        /// Generates mipmaps for the given shader resource.
        /// </summary>
        /// <param name="shaderResourceView">The shader resource.</param>
        [PreserveSig]
        void GenerateMips(
            [In] ID3D11ShaderResourceView shaderResourceView);

        /// <summary>
        /// Sets the minimum level-of-detail (LOD) for a resource.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <param name="minLod">The level-of-detail, which ranges between 0 and the maximum number of mipmap levels of the resource.</param>
        [PreserveSig]
        void SetResourceMinLod(
            [In] ID3D11Resource resource,
            [In] float minLod);

        /// <summary>
        /// Gets the minimum level-of-detail (LOD).
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <returns>The minimum LOD.</returns>
        [PreserveSig]
        float GetResourceMinLod(
            [In] ID3D11Resource resource);

        /// <summary>
        /// Copy a multisampled resource into a non-multisampled resource.
        /// </summary>
        /// <param name="destinationResource">Destination resource.</param>
        /// <param name="destinationSubresource">A zero-based index, that identifies the destination subresource.</param>
        /// <param name="sourceResource">Source resource.</param>
        /// <param name="sourceSubresource">The source subresource of the source resource.</param>
        /// <param name="format">Indicates how the multisampled resource will be resolved to a single-sampled resource.</param>
        [PreserveSig]
        void ResolveSubresource(
            [In] ID3D11Resource destinationResource,
            [In] uint destinationSubresource,
            [In] ID3D11Resource sourceResource,
            [In] uint sourceSubresource,
            [In] DxgiFormat format);

        /// <summary>
        /// Queues commands from a command list onto a device.
        /// </summary>
        /// <param name="commandList">A command list.</param>
        /// <param name="restoreContextState">A value indicating whether the target context state is saved prior to and restored after the execution of a command list.</param>
        [PreserveSig]
        void ExecuteCommandList(
            [In] ID3D11CommandList commandList,
            [In, MarshalAs(UnmanagedType.Bool)] bool restoreContextState);

        /// <summary>
        /// Bind an array of shader resources to the hull shader stage.
        /// </summary>
        /// <param name="startSlot">Index into the device's zero-based array to begin setting shader resources to.</param>
        /// <param name="numViews">Number of shader resources to set.</param>
        /// <param name="shaderResourceViews">Array of shader resource view interfaces to set to the device.</param>
        [PreserveSig]
        void HullShaderSetShaderResources(
            [In] uint startSlot,
            [In] uint numViews,
            [In, MarshalAs(UnmanagedType.LPArray)] ID3D11ShaderResourceView[] shaderResourceViews);

        /// <summary>
        /// Set a hull shader to the device.
        /// </summary>
        /// <param name="hullShader">A hull shader.</param>
        /// <param name="classInstances">An array of class-instance interfaces.</param>
        /// <param name="numClassInstances">The number of class-instance interfaces in the array.</param>
        [PreserveSig]
        void HullShaderSetShader(
            [In] ID3D11HullShader hullShader,
            [In, MarshalAs(UnmanagedType.LPArray)] ID3D11ClassInstance[] classInstances,
            [In] uint numClassInstances);

        /// <summary>
        /// Set an array of sampler states to the hull shader stage.
        /// </summary>
        /// <param name="startSlot">Index into the zero-based array to begin setting samplers to.</param>
        /// <param name="numSamplers">Number of samplers in the array.</param>
        /// <param name="samplers">An array of sampler-state interfaces.</param>
        [PreserveSig]
        void HullShaderSetSamplers(
            [In] uint startSlot,
            [In] uint numSamplers,
            [In, MarshalAs(UnmanagedType.LPArray)] ID3D11SamplerState[] samplers);

        /// <summary>
        /// Set the constant buffers used by the hull shader stage.
        /// </summary>
        /// <param name="startSlot">Index into the device's zero-based array to begin setting constant buffers to.</param>
        /// <param name="numBuffers">Number of buffers to set.</param>
        /// <param name="constantBuffers">Array of constant buffers being given to the device.</param>
        [PreserveSig]
        void HullShaderSetConstantBuffers(
            [In] uint startSlot,
            [In] uint numBuffers,
            [In, MarshalAs(UnmanagedType.LPArray)] ID3D11Buffer[] constantBuffers);

        /// <summary>
        /// Bind an array of shader resources to the domain shader stage.
        /// </summary>
        /// <param name="startSlot">Index into the device's zero-based array to begin setting shader resources to.</param>
        /// <param name="numViews">Number of shader resources to set.</param>
        /// <param name="shaderResourceViews">Array of shader resource view interfaces to set to the device.</param>
        [PreserveSig]
        void DomainShaderSetShaderResources(
            [In] uint startSlot,
            [In] uint numViews,
            [In, MarshalAs(UnmanagedType.LPArray)] ID3D11ShaderResourceView[] shaderResourceViews);

        /// <summary>
        /// Set a domain shader to the device.
        /// </summary>
        /// <param name="domainShader">A domain shader.</param>
        /// <param name="classInstances">An array of class-instance interfaces.</param>
        /// <param name="numClassInstances">The number of class-instance interfaces in the array.</param>
        [PreserveSig]
        void DomainShaderSetShader(
            [In] ID3D11DomainShader domainShader,
            [In, MarshalAs(UnmanagedType.LPArray)] ID3D11ClassInstance[] classInstances,
            [In] uint numClassInstances);

        /// <summary>
        /// Set an array of sampler states to the domain shader stage.
        /// </summary>
        /// <param name="startSlot">Index into the device's zero-based array to begin setting samplers to.</param>
        /// <param name="numSamplers">Number of samplers in the array.</param>
        /// <param name="samplers">An array of sampler-state interfaces.</param>
        [PreserveSig]
        void DomainShaderSetSamplers(
            [In] uint startSlot,
            [In] uint numSamplers,
            [In, MarshalAs(UnmanagedType.LPArray)] ID3D11SamplerState[] samplers);

        /// <summary>
        /// Sets the constant buffers used by the domain shader stage.
        /// </summary>
        /// <param name="startSlot">Index into the zero-based array to begin setting constant buffers to.</param>
        /// <param name="numBuffers">Number of buffers to set.</param>
        /// <param name="constantBuffers">Array of constant buffers being given to the device.</param>
        [PreserveSig]
        void DomainShaderSetConstantBuffers(
            [In] uint startSlot,
            [In] uint numBuffers,
            [In, MarshalAs(UnmanagedType.LPArray)] ID3D11Buffer[] constantBuffers);

        /// <summary>
        /// Bind an array of shader resources to the compute shader stage.
        /// </summary>
        /// <param name="startSlot">Index into the device's zero-based array to begin setting shader resources to.</param>
        /// <param name="numViews">Number of shader resources to set.</param>
        /// <param name="shaderResourceViews">Array of shader resource view interfaces to set to the device.</param>
        [PreserveSig]
        void ComputeShaderSetShaderResources(
            [In] uint startSlot,
            [In] uint numViews,
            [In, MarshalAs(UnmanagedType.LPArray)] ID3D11ShaderResourceView[] shaderResourceViews);

        /// <summary>
        /// Sets an array of views for an unordered resource.
        /// </summary>
        /// <param name="startSlot">Index of the first element in the zero-based array to begin setting.</param>
        /// <param name="numUnorderedAccessViews">Number of views to set.</param>
        /// <param name="unorderedAccessViews">An array of unordered access views to be set.</param>
        /// <param name="uavInitialCounts">An array of append and consume buffer offsets. A value of <value>-1</value> indicates to keep the current offset.</param>
        [PreserveSig]
        void ComputeShaderSetUnorderedAccessViews(
            [In] uint startSlot,
            [In] uint numUnorderedAccessViews,
            [In, MarshalAs(UnmanagedType.LPArray)] ID3D11UnorderedAccessView[] unorderedAccessViews,
            [In, MarshalAs(UnmanagedType.LPArray)] uint[] uavInitialCounts);

        /// <summary>
        /// Set a compute shader to the device.
        /// </summary>
        /// <param name="computeShader">A compute shader.</param>
        /// <param name="classInstances">An array of class-instance interfaces.</param>
        /// <param name="numClassInstances">The number of class-instance interfaces in the array.</param>
        [PreserveSig]
        void ComputeShaderSetShader(
            [In] ID3D11ComputeShader computeShader,
            [In, MarshalAs(UnmanagedType.LPArray)] ID3D11ClassInstance[] classInstances,
            [In] uint numClassInstances);

        /// <summary>
        /// Set an array of sampler states to the compute shader stage.
        /// </summary>
        /// <param name="startSlot">Index into the device's zero-based array to begin setting samplers to.</param>
        /// <param name="numSamplers">Number of samplers in the array.</param>
        /// <param name="samplers">An array of sampler-state interfaces.</param>
        [PreserveSig]
        void ComputeShaderSetSamplers(
            [In] uint startSlot,
            [In] uint numSamplers,
            [In, MarshalAs(UnmanagedType.LPArray)] ID3D11SamplerState[] samplers);

        /// <summary>
        /// Sets the constant buffers used by the compute shader stage.
        /// </summary>
        /// <param name="startSlot">Index into the zero-based array to begin setting constant buffers to.</param>
        /// <param name="numBuffers">Number of buffers to set.</param>
        /// <param name="constantBuffers">Array of constant buffers.</param>
        [PreserveSig]
        void ComputeShaderSetConstantBuffers(
            [In] uint startSlot,
            [In] uint numBuffers,
            [In, MarshalAs(UnmanagedType.LPArray)] ID3D11Buffer[] constantBuffers);

        /// <summary>
        /// Get the constant buffers used by the vertex shader pipeline stage.
        /// </summary>
        /// <param name="startSlot">Index into the device's zero-based array to begin retrieving constant buffers from.</param>
        /// <param name="numBuffers">Number of buffers to retrieve.</param>
        /// <param name="constantBuffers">Array of constant buffer interface pointers to be returned.</param>
        [PreserveSig]
        void VertexShaderGetConstantBuffers(
            [In] uint startSlot,
            [In] uint numBuffers,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown)] object[] constantBuffers);

        /// <summary>
        /// Get the pixel shader resources.
        /// </summary>
        /// <param name="startSlot">Index into the device's zero-based array to begin getting shader resources from.</param>
        /// <param name="numViews">The number of resources to get from the device.</param>
        /// <param name="shaderResourceViews">Array of shader resource view interfaces to be returned by the device.</param>
        [PreserveSig]
        void PixelShaderGetShaderResources(
            [In] uint startSlot,
            [In] uint numViews,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown)] object[] shaderResourceViews);

        /// <summary>
        /// Get the pixel shader currently set on the device.
        /// </summary>
        /// <param name="pixelShader">A pixel shader.</param>
        /// <param name="classInstances">An array of class instance interfaces.</param>
        /// <param name="numClassInstances">The number of class-instance elements in the array.</param>
        [PreserveSig]
        void PixelShaderGetShader(
            [Out] out ID3D11PixelShader pixelShader,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown)] object[] classInstances,
            [In, Out] ref uint numClassInstances);

        /// <summary>
        /// Get an array of sampler states from the pixel shader pipeline stage.
        /// </summary>
        /// <param name="startSlot">Index into a zero-based array to begin getting samplers from.</param>
        /// <param name="numSamplers">Number of samplers to get from a device context.</param>
        /// <param name="samplers">Array of sampler-state interface pointers.</param>
        [PreserveSig]
        void PixelShaderGetSamplers(
            [In] uint startSlot,
            [In] uint numSamplers,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown)] object[] samplers);

        /// <summary>
        /// Get the vertex shader currently set on the device.
        /// </summary>
        /// <param name="vertexShader">A vertex shader.</param>
        /// <param name="classInstances">An array of class instance interfaces.</param>
        /// <param name="numClassInstances">The number of class-instance elements in the array.</param>
        [PreserveSig]
        void VertexShaderGetShader(
            [Out] out ID3D11VertexShader vertexShader,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown)] object[] classInstances,
            [In, Out] ref uint numClassInstances);

        /// <summary>
        /// Get the constant buffers used by the pixel shader pipeline stage.
        /// </summary>
        /// <param name="startSlot">Index into the device's zero-based array to begin retrieving constant buffers from.</param>
        /// <param name="numBuffers">Number of buffers to retrieve.</param>
        /// <param name="constantBuffers">Array of constant buffer interface pointers to be returned.</param>
        [PreserveSig]
        void PixelShaderGetConstantBuffers(
            [In] uint startSlot,
            [In] uint numBuffers,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown)] object[] constantBuffers);

        /// <summary>
        /// Get a pointer to the input-layout object that is bound to the input-assembler stage.
        /// </summary>
        /// <param name="inputLayout">The input-layout object.</param>
        [PreserveSig]
        void InputAssemblerGetInputLayout(
            [Out] out ID3D11InputLayout inputLayout);

        /// <summary>
        /// Get the vertex buffers bound to the input-assembler stage.
        /// </summary>
        /// <param name="startSlot">The input slot of the first vertex buffer to get.</param>
        /// <param name="numBuffers">The number of vertex buffers to get starting at the offset.</param>
        /// <param name="vertexBuffers">An array of vertex buffers.</param>
        /// <param name="strides">An array of stride values.</param>
        /// <param name="offsets">An array of offset values.</param>
        [PreserveSig]
        void InputAssemblerGetVertexBuffers(
            [In] uint startSlot,
            [In] uint numBuffers,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown)] object[] vertexBuffers,
            [Out, MarshalAs(UnmanagedType.LPArray)] uint[] strides,
            [Out, MarshalAs(UnmanagedType.LPArray)] uint[] offsets);

        /// <summary>
        /// Get a pointer to the index buffer that is bound to the input-assembler stage.
        /// </summary>
        /// <param name="indexBuffer">An index buffer.</param>
        /// <param name="format">The format of the data in the index buffer.</param>
        /// <param name="offset">Offset (in bytes) from the start of the index buffer, to the first index to use.</param>
        [PreserveSig]
        void InputAssemblerGetIndexBuffer(
            [Out] out ID3D11Buffer indexBuffer,
            [Out] out DxgiFormat format,
            [Out] out uint offset);

        /// <summary>
        /// Get the constant buffers used by the geometry shader pipeline stage.
        /// </summary>
        /// <param name="startSlot">Index into the device's zero-based array to begin retrieving constant buffers from.</param>
        /// <param name="numBuffers">Number of buffers to retrieve.</param>
        /// <param name="constantBuffers">Array of constant buffer interface pointers to be returned.</param>
        [PreserveSig]
        void GeometryShaderGetConstantBuffers(
            [In] uint startSlot,
            [In] uint numBuffers,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown)] object[] constantBuffers);

        /// <summary>
        /// Get the geometry shader currently set on the device.
        /// </summary>
        /// <param name="geometryShader">A geometry shader.</param>
        /// <param name="classInstances">An array of class instance interfaces.</param>
        /// <param name="numClassInstances">The number of class-instance elements in the array.</param>
        [PreserveSig]
        void GeometryShaderGetShader(
            [Out] out ID3D11GeometryShader geometryShader,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown)] object[] classInstances,
            [In, Out] ref uint numClassInstances);

        /// <summary>
        /// Get information about the primitive type, and data order that describes input data for the input assembler stage.
        /// </summary>
        /// <param name="topology">The type of primitive, and ordering of the primitive data.</param>
        [PreserveSig]
        void InputAssemblerGetPrimitiveTopology(
            [Out] out D3D11PrimitiveTopology topology);

        /// <summary>
        /// Get the vertex shader resources.
        /// </summary>
        /// <param name="startSlot">Index into the device's zero-based array to begin getting shader resources from.</param>
        /// <param name="numViews">The number of resources to get from the device.</param>
        /// <param name="shaderResourceViews">Array of shader resource view interfaces to be returned by the device.</param>
        [PreserveSig]
        void VertexShaderGetShaderResources(
            [In] uint startSlot,
            [In] uint numViews,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown)] object[] shaderResourceViews);

        /// <summary>
        /// Get an array of sampler states from the vertex shader pipeline stage.
        /// </summary>
        /// <param name="startSlot">Index into a zero-based array to begin getting samplers from.</param>
        /// <param name="numSamplers">Number of samplers to get from a device context.</param>
        /// <param name="samplers">Array of sampler-state interface pointers to be returned by the device.</param>
        [PreserveSig]
        void VertexShaderGetSamplers(
            [In] uint startSlot,
            [In] uint numSamplers,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown)] object[] samplers);

        /// <summary>
        /// Get the rendering predicate state.
        /// </summary>
        /// <param name="predicate">A predicate.</param>
        /// <param name="predicateValue">The predicate comparison value.</param>
        [PreserveSig]
        void GetPredication(
            [Out] out ID3D11Predicate predicate,
            [Out, MarshalAs(UnmanagedType.Bool)] out bool predicateValue);

        /// <summary>
        /// Get the geometry shader resources.
        /// </summary>
        /// <param name="startSlot">Index into the device's zero-based array to begin getting shader resources from.</param>
        /// <param name="numViews">The number of resources to get from the device.</param>
        /// <param name="shaderResourceViews">Array of shader resource view interfaces to be returned by the device.</param>
        [PreserveSig]
        void GeometryShaderGetShaderResources(
            [In] uint startSlot,
            [In] uint numViews,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown)] object[] shaderResourceViews);

        /// <summary>
        /// Get an array of sampler state interfaces from the geometry shader pipeline stage.
        /// </summary>
        /// <param name="startSlot">Index into a zero-based array to begin getting samplers from.</param>
        /// <param name="numSamplers">Number of samplers to get from a device context.</param>
        /// <param name="samplers">An array of sampler-state interfaces.</param>
        [PreserveSig]
        void GeometryShaderGetSamplers(
            [In] uint startSlot,
            [In] uint numSamplers,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown)] object[] samplers);

        /// <summary>
        /// Get pointers to the resources bound to the output-merger stage.
        /// </summary>
        /// <param name="numViews">Number of render targets to retrieve.</param>
        /// <param name="renderTargetViews">The render target views.</param>
        /// <param name="depthStencilView">A depth-stencil view.</param>
        [PreserveSig]
        void OutputMergerGetRenderTargets(
            [In] uint numViews,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown)] object[] renderTargetViews,
            [Out] out ID3D11DepthStencilView depthStencilView);

        /// <summary>
        /// Get pointers to the resources bound to the output-merger stage.
        /// </summary>
        /// <param name="numRenderTargetViews">The number of render-target views to retrieve.</param>
        /// <param name="renderTargetViews">The render-target views.</param>
        /// <param name="depthStencilView">A depth-stencil view.</param>
        /// <param name="uavStartSlot">Index into a zero-based array to begin retrieving unordered-access views.</param>
        /// <param name="numUnorderedAccessViews">Number of unordered-access views to return.</param>
        /// <param name="unorderedAccessViews">The  unordered-access views that are retrieved.</param>
        [PreserveSig]
        void OutputMergerGetRenderTargetsAndUnorderedAccessViews(
            [In] uint numRenderTargetViews,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown)] object[] renderTargetViews,
            [Out] out ID3D11DepthStencilView depthStencilView,
            [In] uint uavStartSlot,
            [In] uint numUnorderedAccessViews,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown)] object[] unorderedAccessViews);

        /// <summary>
        /// Get the blend state of the output-merger stage.
        /// </summary>
        /// <param name="blendState">A blend-state interface.</param>
        /// <param name="blendFactor">Array of blend factors, one for each RGBA component.</param>
        /// <param name="sampleMask">A sample mask.</param>
        [PreserveSig]
        void OutputMergerGetBlendState(
            [Out] out ID3D11BlendState blendState,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] float[] blendFactor,
            [Out] out uint sampleMask);

        /// <summary>
        /// Gets the depth-stencil state of the output-merger stage.
        /// </summary>
        /// <param name="depthStencilState">A depth-stencil state interface.</param>
        /// <param name="stencilReference">The stencil reference value used in the depth-stencil test.</param>
        [PreserveSig]
        void OutputMergerGetDepthStencilState(
            [Out] out ID3D11DepthStencilState depthStencilState,
            [Out] out uint stencilReference);

        /// <summary>
        /// Get the target output buffers for the stream-output stage of the pipeline.
        /// </summary>
        /// <param name="numBuffers">Number of buffers to get.</param>
        /// <param name="targets">An array of output buffers to be retrieved from the device.</param>
        [PreserveSig]
        void StreamOutputGetTargets(
            [In] uint numBuffers,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown)] object[] targets);

        /// <summary>
        /// Get the rasterizer state from the rasterizer stage of the pipeline.
        /// </summary>
        /// <param name="rasterizerState">A rasterizer-state interface.</param>
        [PreserveSig]
        void RasterizerStageGetState(
            [Out] out ID3D11RasterizerState rasterizerState);

        /// <summary>
        /// Gets the array of viewports bound to the rasterizer stage.
        /// </summary>
        /// <param name="numViewports">The number of viewports.</param>
        /// <param name="viewports">The viewports that are bound to the rasterizer stage.</param>
        [PreserveSig]
        void RasterizerStageGetViewports(
            [In, Out] ref uint numViewports,
            [Out, MarshalAs(UnmanagedType.LPArray)] D3D11Viewport[] viewports);

        /// <summary>
        /// Get the array of scissor rectangles bound to the rasterizer stage.
        /// </summary>
        /// <param name="numRects">The number of scissor rectangles bound.</param>
        /// <param name="rects">An array of scissor rectangles.</param>
        [PreserveSig]
        void RasterizerStageGetScissorRects(
            [In, Out] ref uint numRects,
            [Out, MarshalAs(UnmanagedType.LPArray)] D3D11Rect[] rects);

        /// <summary>
        /// Get the hull shader resources.
        /// </summary>
        /// <param name="startSlot">Index into the device's zero-based array to begin getting shader resources from.</param>
        /// <param name="numViews">The number of resources to get from the device.</param>
        /// <param name="shaderResourceViews">Array of shader resource view interfaces to be returned by the device.</param>
        [PreserveSig]
        void HullShaderGetShaderResources(
            [In] uint startSlot,
            [In] uint numViews,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown)] object[] shaderResourceViews);

        /// <summary>
        /// Get the hull shader currently set on the device.
        /// </summary>
        /// <param name="hullShader">A hull shader.</param>
        /// <param name="classInstances">An array of class instance interfaces.</param>
        /// <param name="numClassInstances">The number of class-instance elements in the array.</param>
        [PreserveSig]
        void HullShaderGetShader(
            [Out] out ID3D11HullShader hullShader,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown)] object[] classInstances,
            [In, Out] ref uint numClassInstances);

        /// <summary>
        /// Get an array of sampler state interfaces from the hull shader stage.
        /// </summary>
        /// <param name="startSlot">Index into a zero-based array to begin getting samplers from.</param>
        /// <param name="numSamplers">Number of samplers to get from a device context.</param>
        /// <param name="samplers">An array of sampler-state interfaces.</param>
        [PreserveSig]
        void HullShaderGetSamplers(
            [In] uint startSlot,
            [In] uint numSamplers,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown)] object[] samplers);

        /// <summary>
        /// Get the constant buffers used by the hull shader stage.
        /// </summary>
        /// <param name="startSlot">Index into the device's zero-based array to begin retrieving constant buffers from.</param>
        /// <param name="numBuffers">Number of buffers to retrieve.</param>
        /// <param name="constantBuffers">Array of constant buffer interface pointers to be returned by the method.</param>
        [PreserveSig]
        void HullShaderGetConstantBuffers(
            [In] uint startSlot,
            [In] uint numBuffers,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown)] object[] constantBuffers);

        /// <summary>
        /// Get the domain shader resources.
        /// </summary>
        /// <param name="startSlot">Index into the device's zero-based array to begin getting shader resources from.</param>
        /// <param name="numViews">The number of resources to get from the device.</param>
        /// <param name="shaderResourceViews">Array of shader resource view interfaces to be returned by the device.</param>
        [PreserveSig]
        void DomainShaderGetShaderResources(
            [In] uint startSlot,
            [In] uint numViews,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown)] object[] shaderResourceViews);

        /// <summary>
        /// Get the domain shader currently set on the device.
        /// </summary>
        /// <param name="domainShader">A domain shader.</param>
        /// <param name="classInstances">An array of class instance interfaces.</param>
        /// <param name="numClassInstances">The number of class-instance elements in the array.</param>
        [PreserveSig]
        void DomainShaderGetShader(
            [Out] out ID3D11DomainShader domainShader,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown)] object[] classInstances,
            [In, Out] ref uint numClassInstances);

        /// <summary>
        /// Get an array of sampler state interfaces from the domain shader stage.
        /// </summary>
        /// <param name="startSlot">Index into a zero-based array to begin getting samplers from.</param>
        /// <param name="numSamplers">Number of samplers to get from a device context.</param>
        /// <param name="samplers">An array of sampler-state interfaces.</param>
        [PreserveSig]
        void DomainShaderGetSamplers(
            [In] uint startSlot,
            [In] uint numSamplers,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown)] object[] samplers);

        /// <summary>
        /// Get the constant buffers used by the domain shader stage.
        /// </summary>
        /// <param name="startSlot">Index into the device's zero-based array to begin retrieving constant buffers from.</param>
        /// <param name="numBuffers">Number of buffers to retrieve.</param>
        /// <param name="constantBuffers">Array of constant buffer interface pointers to be returned by the method.</param>
        [PreserveSig]
        void DomainShaderGetConstantBuffers(
            [In] uint startSlot,
            [In] uint numBuffers,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown)] object[] constantBuffers);

        /// <summary>
        /// Get the compute shader resources.
        /// </summary>
        /// <param name="startSlot">Index into the device's zero-based array to begin getting shader resources from.</param>
        /// <param name="numViews">The number of resources to get from the device.</param>
        /// <param name="shaderResourceViews">Array of shader resource view interfaces to be returned by the device.</param>
        [PreserveSig]
        void ComputeShaderGetShaderResources(
            [In] uint startSlot,
            [In] uint numViews,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown)] object[] shaderResourceViews);

        /// <summary>
        /// Gets an array of views for an unordered resource.
        /// </summary>
        /// <param name="startSlot">Index of the first element in the zero-based array to return.</param>
        /// <param name="numUnorderedAccessViews">Number of views to get.</param>
        /// <param name="unorderedAccessViews">An array of interface pointers.</param>
        [PreserveSig]
        void ComputeShaderGetUnorderedAccessViews(
            [In] uint startSlot,
            [In] uint numUnorderedAccessViews,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown)] object[] unorderedAccessViews);

        /// <summary>
        /// Get the compute shader currently set on the device.
        /// </summary>
        /// <param name="computeShader">A compute shader.</param>
        /// <param name="classInstances">An array of class instance interfaces.</param>
        /// <param name="numClassInstances">The number of class-instance elements in the array.</param>
        [PreserveSig]
        void ComputeShaderGetShader(
            [Out] out ID3D11ComputeShader computeShader,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown)] object[] classInstances,
            [In, Out] ref uint numClassInstances);

        /// <summary>
        /// Get an array of sampler state interfaces from the compute shader stage.
        /// </summary>
        /// <param name="startSlot">Index into a zero-based array to begin getting samplers from.</param>
        /// <param name="numSamplers">Number of samplers to get from a device context.</param>
        /// <param name="samplers">An array of sampler-state interfaces.</param>
        [PreserveSig]
        void ComputeShaderGetSamplers(
            [In] uint startSlot,
            [In] uint numSamplers,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown)] object[] samplers);

        /// <summary>
        /// Get the constant buffers used by the compute shader stage.
        /// </summary>
        /// <param name="startSlot">Index into the device's zero-based array to begin retrieving constant buffers from.</param>
        /// <param name="numBuffers">Number of buffers to retrieve.</param>
        /// <param name="constantBuffers">Array of constant buffer interface pointers to be returned by the method.</param>
        [PreserveSig]
        void ComputeShaderGetConstantBuffers(
            [In] uint startSlot,
            [In] uint numBuffers,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown)] object[] constantBuffers);

        /// <summary>
        /// Restore all default settings.
        /// </summary>
        [PreserveSig]
        void ClearState();

        /// <summary>
        /// Sends queued-up commands in the command buffer to the graphics processing unit (GPU).
        /// </summary>
        [PreserveSig]
        void Flush();

        /// <summary>
        /// Gets the type of device context.
        /// </summary>
        /// <returns>The type of device context.</returns>
        [PreserveSig]
        D3D11DeviceContextType GetContextType();

        /// <summary>
        /// Gets the initialization flags associated with the current deferred context.
        /// </summary>
        /// <returns>The options that were supplied to the <c>ContextFlags</c> parameter of <see cref="D3D11Device.CreateDeferredContext"/></returns>
        [PreserveSig]
        uint GetContextOptions();

        /// <summary>
        /// Create a command list and record graphics commands into it.
        /// </summary>
        /// <param name="restoreDeferredContextState">A value indicating whether the runtime saves deferred context state before it executes <c>FinishCommandList</c> and restores it afterwards.</param>
        /// <returns>The recorded command list.</returns>
        ID3D11CommandList FinishCommandList(
            [In, MarshalAs(UnmanagedType.Bool)] bool restoreDeferredContextState);
    }
}
