// <copyright file="ID3D11DeviceContext.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.Dxgi;
using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.D3D11.ComInterfaces;

/// <summary>
/// Represents a device context which generates rendering commands.
/// </summary>
/// <remarks>Inherited from <see cref="ID3D11DeviceChild"/></remarks>
[Guid("c0bfa96c-e089-44fb-8eaf-26f8796190da")]
internal unsafe readonly struct ID3D11DeviceContext
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
    private readonly nint GetDevice;
    private readonly nint GetPrivateData;
    private readonly nint SetPrivateData;
    private readonly nint SetPrivateDataInterface;

    /// <summary>
    /// Sets the constant buffers used by the vertex shader pipeline stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting constant buffers to.</param>
    /// <param name="numBuffers">Number of buffers to set.</param>
    /// <param name="constantBuffers">Array of constant buffers being given to the device.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint, nint*, void> VertexShaderSetConstantBuffers;

    /// <summary>
    /// Bind an array of shader resources to the pixel shader stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting shader resources to.</param>
    /// <param name="numViews">Number of shader resources to set.</param>
    /// <param name="shaderResourceViews">Array of shader resource view interfaces to set to the device.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint, nint*, void> PixelShaderSetShaderResources;

    /// <summary>
    /// Sets a pixel shader to the device.
    /// </summary>
    /// <param name="pixelShader">A pixel shader.</param>
    /// <param name="classInstances">An array of class-instance interfaces.</param>
    /// <param name="numClassInstances">The number of class-instance interfaces in the array.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, nint*, uint, void> PixelShaderSetShader;

    /// <summary>
    /// Set an array of sampler states to the pixel shader pipeline stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting samplers to.</param>
    /// <param name="numSamplers">Number of samplers in the array.</param>
    /// <param name="samplers">An array of sampler-state interfaces.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint, void*, void> PixelShaderSetSamplers;

    /// <summary>
    /// Set a vertex shader to the device.
    /// </summary>
    /// <param name="vertexShader">A vertex shader.</param>
    /// <param name="classInstances">An array of class-instance interfaces.</param>
    /// <param name="numClassInstances">The number of class-instance interfaces in the array.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, nint*, uint, void> VertexShaderSetShader;

    /// <summary>
    /// Draw indexed, non-instanced primitives.
    /// </summary>
    /// <param name="indexCount">Number of indices to draw.</param>
    /// <param name="startIndexLocation">The location of the first index read by the GPU from the index buffer.</param>
    /// <param name="baseVertexLocation">A value added to each index before reading a vertex from the vertex buffer.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint, int, void> DrawIndexed;

    /// <summary>
    /// Draw non-indexed, non-instanced primitives.
    /// </summary>
    /// <param name="vertexCount">Number of vertices to draw.</param>
    /// <param name="startVertexLocation">Index of the first vertex, which is usually an offset in a vertex buffer.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint, void> Draw;

    /// <summary>
    /// Gets a pointer to the data contained in a subresource, and denies the GPU access to that subresource.
    /// </summary>
    /// <param name="resource">A <see cref="ID3D11Resource"/> interface.</param>
    /// <param name="subresource">Index number of the subresource.</param>
    /// <param name="mapType">The CPU's read and write permissions for a resource.</param>
    /// <param name="mapOptions">Specifies what the CPU does when the GPU is busy.</param>
    /// <returns>The mapped subresource.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, uint, D3D11MapCpuPermission, D3D11MapOptions, nint*, int> Map;

    /// <summary>
    /// Invalidate the pointer to a resource and reenable the GPU's access to that resource.
    /// </summary>
    /// <param name="resource">A <see cref="ID3D11Resource"/> interface.</param>
    /// <param name="subresource">A subresource to be unmapped.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, uint, void> Unmap;

    /// <summary>
    /// Sets the constant buffers used by the pixel shader pipeline stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting constant buffers to.</param>
    /// <param name="numBuffers">Number of buffers to set.</param>
    /// <param name="constantBuffers">Array of constant buffers.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint, nint*, void> PixelShaderSetConstantBuffers;

    /// <summary>
    /// Bind an input-layout object to the input-assembler stage.
    /// </summary>
    /// <param name="inputLayout">The input-layout object.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, void> InputAssemblerSetInputLayout;

    /// <summary>
    /// Bind an array of vertex buffers to the input-assembler stage.
    /// </summary>
    /// <param name="startSlot">The first input slot for binding.</param>
    /// <param name="numBuffers">The number of vertex buffers in the array.</param>
    /// <param name="vertexBuffers">An array of vertex buffers.</param>
    /// <param name="strides">An array of stride values; one stride value for each buffer in the vertex-buffer array.</param>
    /// <param name="offsets">An array of offset values; one offset value for each buffer in the vertex-buffer array.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint, nint*, uint*, uint*, void> InputAssemblerSetVertexBuffers;

    /// <summary>
    /// Bind an index buffer to the input-assembler stage.
    /// </summary>
    /// <param name="indexBuffer">An <see cref="ID3D11Buffer"/> object, that contains indices.</param>
    /// <param name="format">The format of the data in the index buffer.</param>
    /// <param name="offset">Offset (in bytes) from the start of the index buffer to the first index to use.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, DxgiFormat, uint, void> InputAssemblerSetIndexBuffer;

    /// <summary>
    /// Draw indexed, instanced primitives.
    /// </summary>
    /// <param name="indexCountPerInstance">Number of indices read from the index buffer for each instance.</param>
    /// <param name="instanceCount">Number of instances to draw.</param>
    /// <param name="startIndexLocation">The location of the first index read by the GPU from the index buffer.</param>
    /// <param name="baseVertexLocation">A value added to each index before reading a vertex from the vertex buffer.</param>
    /// <param name="startInstanceLocation">A value added to each index before reading per-instance data from a vertex buffer.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint, uint, int, uint, void> DrawIndexedInstanced;

    /// <summary>
    /// Draw non-indexed, instanced primitives.
    /// </summary>
    /// <param name="vertexCountPerInstance">Number of vertices to draw.</param>
    /// <param name="instanceCount">Number of instances to draw.</param>
    /// <param name="startVertexLocation">Index of the first vertex.</param>
    /// <param name="startInstanceLocation">A value added to each index before reading per-instance data from a vertex buffer.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint, uint, uint, void> DrawInstanced;

    /// <summary>
    /// Sets the constant buffers used by the geometry shader pipeline stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting constant buffers to.</param>
    /// <param name="numBuffers">Number of buffers to set.</param>
    /// <param name="constantBuffers">Array of constant buffers.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint, nint*, void> GeometryShaderSetConstantBuffers;

    /// <summary>
    /// Set a geometry shader to the device.
    /// </summary>
    /// <param name="shader">A geometry shader.</param>
    /// <param name="classInstances">An array of class-instance interfaces.</param>
    /// <param name="numClassInstances">The number of class-instance interfaces in the array.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, nint*, uint, void> GeometryShaderSetShader;

    /// <summary>
    /// Bind information about the primitive type, and data order that describes input data for the input assembler stage.
    /// </summary>
    /// <param name="topology">The type of primitive and ordering of the primitive data.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, D3D11PrimitiveTopology, void> InputAssemblerSetPrimitiveTopology;

    /// <summary>
    /// Bind an array of shader resources to the vertex shader stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting shader resources to.</param>
    /// <param name="numViews">Number of shader resources to set.</param>
    /// <param name="shaderResourceViews">Array of shader resource view interfaces to set to the device.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint, nint*, void> VertexShaderSetShaderResources;

    /// <summary>
    /// Set an array of sampler states to the vertex shader pipeline stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting samplers to.</param>
    /// <param name="numSamplers">Number of samplers in the array.</param>
    /// <param name="samplers">An array of sampler-state interfaces.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint, nint*, void> VertexShaderSetSamplers;

    /// <summary>
    /// Mark the beginning of a series of commands.
    /// </summary>
    /// <param name="async">An <see cref="ID3D11Asynchronous"/> interface.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, void> Begin;

    /// <summary>
    /// Mark the end of a series of commands.
    /// </summary>
    /// <param name="async">An <see cref="ID3D11Asynchronous"/> interface.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, void> End;

    /// <summary>
    /// Get data from the graphics processing unit (GPU) asynchronously.
    /// </summary>
    /// <param name="async">An <see cref="ID3D11Asynchronous"/> interface for the object about which <c>GetData</c> retrieves data.</param>
    /// <param name="dataPtr">Address of memory that will receive the data.</param>
    /// <param name="dataSize">Size of the data to retrieve or 0.</param>
    /// <param name="options">Optional flags.</param>
    /// <returns>A boolean value indicating whether the operation succeeded.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, void*, uint, D3D11AsyncGetDataOptions, int> GetData;

    /// <summary>
    /// Set a rendering predicate.
    /// </summary>
    /// <param name="predicate">A predicate.</param>
    /// <param name="predicateValue">A value indicating whether rendering will be affected by when the predicate's conditions are met or not met.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, int, void> SetPredication;

    /// <summary>
    /// Bind an array of shader resources to the geometry shader stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting shader resources to.</param>
    /// <param name="numView">Number of shader resources to set.</param>
    /// <param name="shaderResourceViews">Array of shader resource view interfaces to set to the device.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint, nint*, void> GeometryShaderSetShaderResources;

    /// <summary>
    /// Set an array of sampler states to the geometry shader pipeline stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting samplers to.</param>
    /// <param name="numSamplers">Number of samplers in the array.</param>
    /// <param name="samplers">An array of sampler-state interfaces.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint, nint*, void> GeometryShaderSetSamplers;

    /// <summary>
    /// Bind one or more render targets atomically and the depth-stencil buffer to the output-merger stage.
    /// </summary>
    /// <param name="numViews">Number of render targets to bind.</param>
    /// <param name="renderTargetViews">The render targets to bind to the device.</param>
    /// <param name="depthStencilView">The depth-stencil view to bind to the device.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, nint*, nint, void> OutputMergerSetRenderTargets;

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
    public readonly delegate* unmanaged[Stdcall]<nint, uint, nint*, nint, uint, uint, nint*, uint*, void> OutputMergerSetRenderTargetsAndUnorderedAccessViews;

    /// <summary>
    /// Set the blend state of the output-merger stage.
    /// </summary>
    /// <param name="blendState">A blend-state interface.</param>
    /// <param name="blendFactor">Array of blend factors, one for each RGBA component. The blend factors modulate values for the pixel shader, render target, or both.</param>
    /// <param name="sampleMask">32-bit sample coverage. The default value is <value>0xffffffff</value>.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, float*, uint, void> OutputMergerSetBlendState;

    /// <summary>
    /// Sets the depth-stencil state of the output-merger stage.
    /// </summary>
    /// <param name="depthStencilState">A depth-stencil state interface.</param>
    /// <param name="stencilReference">Reference value to perform against when doing a depth-stencil test.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, uint, void> OutputMergerSetDepthStencilState;

    /// <summary>
    /// Reference value to perform against when doing a depth-stencil test.
    /// </summary>
    /// <param name="numBuffers">The number of buffer to bind to the device.</param>
    /// <param name="targets">The array of output buffers to bind to the device.</param>
    /// <param name="offsets">Array of offsets to the output buffers.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, nint*, uint*, void> StreamOutputSetTargets;

    /// <summary>
    /// Draw geometry of an unknown size.
    /// </summary>
    public readonly delegate* unmanaged[Stdcall]<nint, void> DrawAuto;

    /// <summary>
    /// Draw indexed, instanced, GPU-generated primitives.
    /// </summary>
    /// <param name="bufferForArgs">A buffer containing the GPU generated primitives.</param>
    /// <param name="alignedByteOffsetForArgs">Offset to the start of the GPU generated primitives.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, uint, void> DrawIndexedInstancedIndirect;

    /// <summary>
    /// Draw instanced, GPU-generated primitives.
    /// </summary>
    /// <param name="bufferForArgs">A buffer containing the GPU generated primitives.</param>
    /// <param name="alignedByteOffsetForArgs">Offset to the start of the GPU generated primitives.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, uint, void> DrawInstancedIndirect;

    /// <summary>
    /// Execute a command list from a thread group.
    /// </summary>
    /// <param name="threadGroupCountX">The number of groups dispatched in the x direction.</param>
    /// <param name="threadGroupCountY">The number of groups dispatched in the y direction.</param>
    /// <param name="threadGroupCountZ">The number of groups dispatched in the z direction.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint, uint, void> Dispatch;

    /// <summary>
    /// Execute a command list over one or more thread groups.
    /// </summary>
    /// <param name="bufferForArgs">A buffer, which must be loaded with data that matches the argument list.</param>
    /// <param name="alignedByteOffsetForArgs">A byte-aligned offset between the start of the buffer and the arguments.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, uint, void> DispatchIndirect;

    /// <summary>
    /// Set the rasterizer state for the rasterizer stage of the pipeline.
    /// </summary>
    /// <param name="rasterizerState">A rasterizer-state interface.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, void> RasterizerStageSetState;

    /// <summary>
    /// Bind an array of viewports to the rasterizer stage of the pipeline.
    /// </summary>
    /// <param name="numViewports">Number of viewports to bind.</param>
    /// <param name="viewports">An array of <see cref="D3D11Viewport"/> structures to bind to the device.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, void*, void> RasterizerStageSetViewports;

    /// <summary>
    /// Bind an array of scissor rectangles to the rasterizer stage.
    /// </summary>
    /// <param name="numRects">Number of scissor rectangles to bind.</param>
    /// <param name="rects">An array of scissor rectangles.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, void*, void> RasterizerStageSetScissorRects;

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
    public readonly delegate* unmanaged[Stdcall]<nint, nint, uint, uint, uint, uint, nint, uint, void*, void> CopySubresourceRegion;

    /// <summary>
    /// Copy the entire contents of the source resource to the destination resource using the GPU.
    /// </summary>
    /// <param name="destinationResource">The destination resource.</param>
    /// <param name="sourceResource">The source resource.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, nint, void> CopyResource;

    /// <summary>
    /// The CPU copies data from memory to a subresource created in non-mappable memory.
    /// </summary>
    /// <param name="destinationResource">The destination resource.</param>
    /// <param name="destinationSubresource">A zero-based index, that identifies the destination subresource.</param>
    /// <param name="destinationBox">A box that defines the portion of the destination subresource to copy the resource data into. Coordinates are in bytes for buffers and in texels for textures.</param>
    /// <param name="sourceData">A pointer to the source data in memory.</param>
    /// <param name="sourceRowPitch">The size of one row of the source data.</param>
    /// <param name="sourceDepthPitch">The size of one depth slice of source data.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, uint, void*, void*, uint, uint, void> UpdateSubresource;

    /// <summary>
    /// Copies data from a buffer holding variable length data.
    /// </summary>
    /// <param name="destinationBuffer">The destination buffer.</param>
    /// <param name="destinationAlignedByteOffset">Offset from the start of the buffer to write 32-bit UINT structure (vertex) count.</param>
    /// <param name="sourceView">A structured buffer resource.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, uint, nint, void> CopyStructureCount;

    /// <summary>
    /// Set all the elements in a render target to one value.
    /// </summary>
    /// <param name="renderTargetView">The render target.</param>
    /// <param name="colorRGBA">A 4-component array that represents the color to fill the render target with.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, float*, void> ClearRenderTargetView;

    /// <summary>
    /// Clears an unordered access resource with bit-precise values.
    /// </summary>
    /// <param name="unorderedAccessView">The unordered access resource to clear.</param>
    /// <param name="values">Values to copy to corresponding channels.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, uint*, void> ClearUnorderedAccessViewUInt;

    /// <summary>
    /// Clears an unordered access resource with a float value.
    /// </summary>
    /// <param name="unorderedAccessView">The unordered access resource to clear.</param>
    /// <param name="values">Values to copy to corresponding channels.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, float*, void> ClearUnorderedAccessViewFloat;

    /// <summary>
    /// Clears the depth-stencil resource.
    /// </summary>
    /// <param name="depthStencilView">The depth stencil to be cleared.</param>
    /// <param name="clearOptions">Identify the type of data to clear.</param>
    /// <param name="depth">Clear the depth buffer with this value. This value will be clamped between 0 and 1.</param>
    /// <param name="stencil">Clear the stencil buffer with this value.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, D3D11ClearOptions, float, byte, void> ClearDepthStencilView;

    /// <summary>
    /// Generates mipmaps for the given shader resource.
    /// </summary>
    /// <param name="shaderResourceView">The shader resource.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, void> GenerateMips;

    /// <summary>
    /// Sets the minimum level-of-detail (LOD) for a resource.
    /// </summary>
    /// <param name="resource">The resource.</param>
    /// <param name="minLod">The level-of-detail, which ranges between 0 and the maximum number of mipmap levels of the resource.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, float, void> SetResourceMinLod;

    /// <summary>
    /// Gets the minimum level-of-detail (LOD).
    /// </summary>
    /// <param name="resource">The resource.</param>
    /// <returns>The minimum LOD.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, float> GetResourceMinLod;

    /// <summary>
    /// Copy a multisampled resource into a non-multisampled resource.
    /// </summary>
    /// <param name="destinationResource">Destination resource.</param>
    /// <param name="destinationSubresource">A zero-based index, that identifies the destination subresource.</param>
    /// <param name="sourceResource">Source resource.</param>
    /// <param name="sourceSubresource">The source subresource of the source resource.</param>
    /// <param name="format">Indicates how the multisampled resource will be resolved to a single-sampled resource.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, uint, nint, uint, DxgiFormat, void> ResolveSubresource;

    /// <summary>
    /// Queues commands from a command list onto a device.
    /// </summary>
    /// <param name="commandList">A command list.</param>
    /// <param name="restoreContextState">A value indicating whether the target context state is saved prior to and restored after the execution of a command list.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, int, void> ExecuteCommandList;

    /// <summary>
    /// Bind an array of shader resources to the hull shader stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting shader resources to.</param>
    /// <param name="numViews">Number of shader resources to set.</param>
    /// <param name="shaderResourceViews">Array of shader resource view interfaces to set to the device.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint, nint*, void> HullShaderSetShaderResources;

    /// <summary>
    /// Set a hull shader to the device.
    /// </summary>
    /// <param name="hullShader">A hull shader.</param>
    /// <param name="classInstances">An array of class-instance interfaces.</param>
    /// <param name="numClassInstances">The number of class-instance interfaces in the array.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, nint*, uint, void> HullShaderSetShader;

    /// <summary>
    /// Set an array of sampler states to the hull shader stage.
    /// </summary>
    /// <param name="startSlot">Index into the zero-based array to begin setting samplers to.</param>
    /// <param name="numSamplers">Number of samplers in the array.</param>
    /// <param name="samplers">An array of sampler-state interfaces.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint, nint*, void> HullShaderSetSamplers;

    /// <summary>
    /// Set the constant buffers used by the hull shader stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting constant buffers to.</param>
    /// <param name="numBuffers">Number of buffers to set.</param>
    /// <param name="constantBuffers">Array of constant buffers being given to the device.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint, nint*, void> HullShaderSetConstantBuffers;

    /// <summary>
    /// Bind an array of shader resources to the domain shader stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting shader resources to.</param>
    /// <param name="numViews">Number of shader resources to set.</param>
    /// <param name="shaderResourceViews">Array of shader resource view interfaces to set to the device.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint, nint*, void> DomainShaderSetShaderResources;

    /// <summary>
    /// Set a domain shader to the device.
    /// </summary>
    /// <param name="domainShader">A domain shader.</param>
    /// <param name="classInstances">An array of class-instance interfaces.</param>
    /// <param name="numClassInstances">The number of class-instance interfaces in the array.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, nint*, uint, void> DomainShaderSetShader;

    /// <summary>
    /// Set an array of sampler states to the domain shader stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting samplers to.</param>
    /// <param name="numSamplers">Number of samplers in the array.</param>
    /// <param name="samplers">An array of sampler-state interfaces.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint, nint*, void> DomainShaderSetSamplers;

    /// <summary>
    /// Sets the constant buffers used by the domain shader stage.
    /// </summary>
    /// <param name="startSlot">Index into the zero-based array to begin setting constant buffers to.</param>
    /// <param name="numBuffers">Number of buffers to set.</param>
    /// <param name="constantBuffers">Array of constant buffers being given to the device.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint, nint*, void> DomainShaderSetConstantBuffers;

    /// <summary>
    /// Bind an array of shader resources to the compute shader stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting shader resources to.</param>
    /// <param name="numViews">Number of shader resources to set.</param>
    /// <param name="shaderResourceViews">Array of shader resource view interfaces to set to the device.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint, nint*, void> ComputeShaderSetShaderResources;

    /// <summary>
    /// Sets an array of views for an unordered resource.
    /// </summary>
    /// <param name="startSlot">Index of the first element in the zero-based array to begin setting.</param>
    /// <param name="numUnorderedAccessViews">Number of views to set.</param>
    /// <param name="unorderedAccessViews">An array of unordered access views to be set.</param>
    /// <param name="uavInitialCounts">An array of append and consume buffer offsets. A value of <value>-1</value> indicates to keep the current offset.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint, nint*, uint*, void> ComputeShaderSetUnorderedAccessViews;

    /// <summary>
    /// Set a compute shader to the device.
    /// </summary>
    /// <param name="computeShader">A compute shader.</param>
    /// <param name="classInstances">An array of class-instance interfaces.</param>
    /// <param name="numClassInstances">The number of class-instance interfaces in the array.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, nint*, uint, void> ComputeShaderSetShader;

    /// <summary>
    /// Set an array of sampler states to the compute shader stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting samplers to.</param>
    /// <param name="numSamplers">Number of samplers in the array.</param>
    /// <param name="samplers">An array of sampler-state interfaces.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint, nint*, void> ComputeShaderSetSamplers;

    /// <summary>
    /// Sets the constant buffers used by the compute shader stage.
    /// </summary>
    /// <param name="startSlot">Index into the zero-based array to begin setting constant buffers to.</param>
    /// <param name="numBuffers">Number of buffers to set.</param>
    /// <param name="constantBuffers">Array of constant buffers.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint, nint*, void> ComputeShaderSetConstantBuffers;

    /// <summary>
    /// Get the constant buffers used by the vertex shader pipeline stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin retrieving constant buffers from.</param>
    /// <param name="numBuffers">Number of buffers to retrieve.</param>
    /// <param name="constantBuffers">Array of constant buffer interface pointers to be returned.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint, nint*, void> VertexShaderGetConstantBuffers;

    /// <summary>
    /// Get the pixel shader resources.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin getting shader resources from.</param>
    /// <param name="numViews">The number of resources to get from the device.</param>
    /// <param name="shaderResourceViews">Array of shader resource view interfaces to be returned by the device.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint, nint*, void> PixelShaderGetShaderResources;

    /// <summary>
    /// Get the pixel shader currently set on the device.
    /// </summary>
    /// <param name="pixelShader">A pixel shader.</param>
    /// <param name="classInstances">An array of class instance interfaces.</param>
    /// <param name="numClassInstances">The number of class-instance elements in the array.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint*, nint*, uint*, void> PixelShaderGetShader;

    /// <summary>
    /// Get an array of sampler states from the pixel shader pipeline stage.
    /// </summary>
    /// <param name="startSlot">Index into a zero-based array to begin getting samplers from.</param>
    /// <param name="numSamplers">Number of samplers to get from a device context.</param>
    /// <param name="samplers">Array of sampler-state interface pointers.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint, nint*, void> PixelShaderGetSamplers;

    /// <summary>
    /// Get the vertex shader currently set on the device.
    /// </summary>
    /// <param name="vertexShader">A vertex shader.</param>
    /// <param name="classInstances">An array of class instance interfaces.</param>
    /// <param name="numClassInstances">The number of class-instance elements in the array.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint*, nint*, uint*, void> VertexShaderGetShader;

    /// <summary>
    /// Get the constant buffers used by the pixel shader pipeline stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin retrieving constant buffers from.</param>
    /// <param name="numBuffers">Number of buffers to retrieve.</param>
    /// <param name="constantBuffers">Array of constant buffer interface pointers to be returned.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint, nint*, void> PixelShaderGetConstantBuffers;

    /// <summary>
    /// Get a pointer to the input-layout object that is bound to the input-assembler stage.
    /// </summary>
    /// <param name="inputLayout">The input-layout object.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint*, void> InputAssemblerGetInputLayout;

    /// <summary>
    /// Get the vertex buffers bound to the input-assembler stage.
    /// </summary>
    /// <param name="startSlot">The input slot of the first vertex buffer to get.</param>
    /// <param name="numBuffers">The number of vertex buffers to get starting at the offset.</param>
    /// <param name="vertexBuffers">An array of vertex buffers.</param>
    /// <param name="strides">An array of stride values.</param>
    /// <param name="offsets">An array of offset values.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint, nint*, uint*, uint*, void> InputAssemblerGetVertexBuffers;

    /// <summary>
    /// Get a pointer to the index buffer that is bound to the input-assembler stage.
    /// </summary>
    /// <param name="indexBuffer">An index buffer.</param>
    /// <param name="format">The format of the data in the index buffer.</param>
    /// <param name="offset">Offset (in bytes) from the start of the index buffer, to the first index to use.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint*, DxgiFormat*, uint*, void> InputAssemblerGetIndexBuffer;

    /// <summary>
    /// Get the constant buffers used by the geometry shader pipeline stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin retrieving constant buffers from.</param>
    /// <param name="numBuffers">Number of buffers to retrieve.</param>
    /// <param name="constantBuffers">Array of constant buffer interface pointers to be returned.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint, nint*, void> GeometryShaderGetConstantBuffers;

    /// <summary>
    /// Get the geometry shader currently set on the device.
    /// </summary>
    /// <param name="geometryShader">A geometry shader.</param>
    /// <param name="classInstances">An array of class instance interfaces.</param>
    /// <param name="numClassInstances">The number of class-instance elements in the array.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint*, nint*, uint*, void> GeometryShaderGetShader;

    /// <summary>
    /// Get information about the primitive type, and data order that describes input data for the input assembler stage.
    /// </summary>
    /// <param name="topology">The type of primitive, and ordering of the primitive data.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, D3D11PrimitiveTopology*, void> InputAssemblerGetPrimitiveTopology;

    /// <summary>
    /// Get the vertex shader resources.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin getting shader resources from.</param>
    /// <param name="numViews">The number of resources to get from the device.</param>
    /// <param name="shaderResourceViews">Array of shader resource view interfaces to be returned by the device.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint, nint*, void> VertexShaderGetShaderResources;

    /// <summary>
    /// Get an array of sampler states from the vertex shader pipeline stage.
    /// </summary>
    /// <param name="startSlot">Index into a zero-based array to begin getting samplers from.</param>
    /// <param name="numSamplers">Number of samplers to get from a device context.</param>
    /// <param name="samplers">Array of sampler-state interface pointers to be returned by the device.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint, nint*, void> VertexShaderGetSamplers;

    /// <summary>
    /// Get the rendering predicate state.
    /// </summary>
    /// <param name="predicate">A predicate.</param>
    /// <param name="predicateValue">The predicate comparison value.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint*, int*, void> GetPredication;

    /// <summary>
    /// Get the geometry shader resources.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin getting shader resources from.</param>
    /// <param name="numViews">The number of resources to get from the device.</param>
    /// <param name="shaderResourceViews">Array of shader resource view interfaces to be returned by the device.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint, nint*, void> GeometryShaderGetShaderResources;

    /// <summary>
    /// Get an array of sampler state interfaces from the geometry shader pipeline stage.
    /// </summary>
    /// <param name="startSlot">Index into a zero-based array to begin getting samplers from.</param>
    /// <param name="numSamplers">Number of samplers to get from a device context.</param>
    /// <param name="samplers">An array of sampler-state interfaces.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint, nint*, void> GeometryShaderGetSamplers;

    /// <summary>
    /// Get pointers to the resources bound to the output-merger stage.
    /// </summary>
    /// <param name="numViews">Number of render targets to retrieve.</param>
    /// <param name="renderTargetViews">The render target views.</param>
    /// <param name="depthStencilView">A depth-stencil view.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, nint*, nint*, void> OutputMergerGetRenderTargets;

    /// <summary>
    /// Get pointers to the resources bound to the output-merger stage.
    /// </summary>
    /// <param name="numRenderTargetViews">The number of render-target views to retrieve.</param>
    /// <param name="renderTargetViews">The render-target views.</param>
    /// <param name="depthStencilView">A depth-stencil view.</param>
    /// <param name="uavStartSlot">Index into a zero-based array to begin retrieving unordered-access views.</param>
    /// <param name="numUnorderedAccessViews">Number of unordered-access views to return.</param>
    /// <param name="unorderedAccessViews">The  unordered-access views that are retrieved.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, nint*, nint*, uint, uint, nint*, void> OutputMergerGetRenderTargetsAndUnorderedAccessViews;

    /// <summary>
    /// Get the blend state of the output-merger stage.
    /// </summary>
    /// <param name="blendState">A blend-state interface.</param>
    /// <param name="blendFactor">Array of blend factors, one for each RGBA component.</param>
    /// <param name="sampleMask">A sample mask.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint*, float*, uint*, void> OutputMergerGetBlendState;

    /// <summary>
    /// Gets the depth-stencil state of the output-merger stage.
    /// </summary>
    /// <param name="depthStencilState">A depth-stencil state interface.</param>
    /// <param name="stencilReference">The stencil reference value used in the depth-stencil test.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint*, uint*, void> OutputMergerGetDepthStencilState;

    /// <summary>
    /// Get the target output buffers for the stream-output stage of the pipeline.
    /// </summary>
    /// <param name="numBuffers">Number of buffers to get.</param>
    /// <param name="targets">An array of output buffers to be retrieved from the device.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, nint*, void> StreamOutputGetTargets;

    /// <summary>
    /// Get the rasterizer state from the rasterizer stage of the pipeline.
    /// </summary>
    /// <param name="rasterizerState">A rasterizer-state interface.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint*, void> RasterizerStageGetState;

    /// <summary>
    /// Gets the array of viewports bound to the rasterizer stage.
    /// </summary>
    /// <param name="numViewports">The number of viewports.</param>
    /// <param name="viewports">The viewports that are bound to the rasterizer stage.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint*, void*, void> RasterizerStageGetViewports;

    /// <summary>
    /// Get the array of scissor rectangles bound to the rasterizer stage.
    /// </summary>
    /// <param name="numRects">The number of scissor rectangles bound.</param>
    /// <param name="rects">An array of scissor rectangles.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint*, void*, void> RasterizerStageGetScissorRects;

    /// <summary>
    /// Get the hull shader resources.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin getting shader resources from.</param>
    /// <param name="numViews">The number of resources to get from the device.</param>
    /// <param name="shaderResourceViews">Array of shader resource view interfaces to be returned by the device.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint, nint*, void> HullShaderGetShaderResources;

    /// <summary>
    /// Get the hull shader currently set on the device.
    /// </summary>
    /// <param name="hullShader">A hull shader.</param>
    /// <param name="classInstances">An array of class instance interfaces.</param>
    /// <param name="numClassInstances">The number of class-instance elements in the array.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint*, nint*, uint*, void> HullShaderGetShader;

    /// <summary>
    /// Get an array of sampler state interfaces from the hull shader stage.
    /// </summary>
    /// <param name="startSlot">Index into a zero-based array to begin getting samplers from.</param>
    /// <param name="numSamplers">Number of samplers to get from a device context.</param>
    /// <param name="samplers">An array of sampler-state interfaces.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint, nint*, void> HullShaderGetSamplers;

    /// <summary>
    /// Get the constant buffers used by the hull shader stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin retrieving constant buffers from.</param>
    /// <param name="numBuffers">Number of buffers to retrieve.</param>
    /// <param name="constantBuffers">Array of constant buffer interface pointers to be returned by the method.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint, nint*, void> HullShaderGetConstantBuffers;

    /// <summary>
    /// Get the domain shader resources.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin getting shader resources from.</param>
    /// <param name="numViews">The number of resources to get from the device.</param>
    /// <param name="shaderResourceViews">Array of shader resource view interfaces to be returned by the device.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint, nint*, void> DomainShaderGetShaderResources;

    /// <summary>
    /// Get the domain shader currently set on the device.
    /// </summary>
    /// <param name="domainShader">A domain shader.</param>
    /// <param name="classInstances">An array of class instance interfaces.</param>
    /// <param name="numClassInstances">The number of class-instance elements in the array.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint*, nint*, uint*, void> DomainShaderGetShader;

    /// <summary>
    /// Get an array of sampler state interfaces from the domain shader stage.
    /// </summary>
    /// <param name="startSlot">Index into a zero-based array to begin getting samplers from.</param>
    /// <param name="numSamplers">Number of samplers to get from a device context.</param>
    /// <param name="samplers">An array of sampler-state interfaces.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint, nint*, void> DomainShaderGetSamplers;

    /// <summary>
    /// Get the constant buffers used by the domain shader stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin retrieving constant buffers from.</param>
    /// <param name="numBuffers">Number of buffers to retrieve.</param>
    /// <param name="constantBuffers">Array of constant buffer interface pointers to be returned by the method.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint, nint*, void> DomainShaderGetConstantBuffers;

    /// <summary>
    /// Get the compute shader resources.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin getting shader resources from.</param>
    /// <param name="numViews">The number of resources to get from the device.</param>
    /// <param name="shaderResourceViews">Array of shader resource view interfaces to be returned by the device.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint, nint*, void> ComputeShaderGetShaderResources;

    /// <summary>
    /// Gets an array of views for an unordered resource.
    /// </summary>
    /// <param name="startSlot">Index of the first element in the zero-based array to return.</param>
    /// <param name="numUnorderedAccessViews">Number of views to get.</param>
    /// <param name="unorderedAccessViews">An array of interface pointers.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint, nint*, void> ComputeShaderGetUnorderedAccessViews;

    /// <summary>
    /// Get the compute shader currently set on the device.
    /// </summary>
    /// <param name="computeShader">A compute shader.</param>
    /// <param name="classInstances">An array of class instance interfaces.</param>
    /// <param name="numClassInstances">The number of class-instance elements in the array.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint*, nint*, uint*, void> ComputeShaderGetShader;

    /// <summary>
    /// Get an array of sampler state interfaces from the compute shader stage.
    /// </summary>
    /// <param name="startSlot">Index into a zero-based array to begin getting samplers from.</param>
    /// <param name="numSamplers">Number of samplers to get from a device context.</param>
    /// <param name="samplers">An array of sampler-state interfaces.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint, nint*, void> ComputeShaderGetSamplers;

    /// <summary>
    /// Get the constant buffers used by the compute shader stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin retrieving constant buffers from.</param>
    /// <param name="numBuffers">Number of buffers to retrieve.</param>
    /// <param name="constantBuffers">Array of constant buffer interface pointers to be returned by the method.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint, nint*, void> ComputeShaderGetConstantBuffers;

    /// <summary>
    /// Restore all default settings.
    /// </summary>
    public readonly delegate* unmanaged[Stdcall]<nint, void> ClearState;

    /// <summary>
    /// Sends queued-up commands in the command buffer to the graphics processing unit (GPU).
    /// </summary>
    public readonly delegate* unmanaged[Stdcall]<nint, void> Flush;

    /// <summary>
    /// Gets the type of device context.
    /// </summary>
    /// <returns>The type of device context.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, D3D11DeviceContextType> GetContextType;

    /// <summary>
    /// Gets the initialization flags associated with the current deferred context.
    /// </summary>
    /// <returns>The options that were supplied to the <c>ContextFlags</c> parameter of <see cref="D3D11Device.CreateDeferredContext"/></returns>
    public readonly delegate* unmanaged[Stdcall]<nint, uint> GetContextOptions;

    /// <summary>
    /// Create a command list and record graphics commands into it.
    /// </summary>
    /// <param name="restoreDeferredContextState">A value indicating whether the runtime saves deferred context state before it executes <c>FinishCommandList</c> and restores it afterwards.</param>
    /// <returns>The recorded command list.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, int, nint*, int> FinishCommandList;
}
