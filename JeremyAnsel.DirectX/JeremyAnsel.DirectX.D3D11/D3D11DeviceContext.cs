// <copyright file="D3D11DeviceContext.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D3D11.ComInterfaces;
using JeremyAnsel.DirectX.DXCommon;
using JeremyAnsel.DirectX.Dxgi;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// Represents a device context which generates rendering commands.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class D3D11DeviceContext : D3D11DeviceChild
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid D3D11DeviceContextGuid = typeof(ID3D11DeviceContext).GUID;

    private readonly nint _comPtr;
    private readonly ID3D11DeviceContext* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11DeviceContext"/> class.
    /// </summary>
    public D3D11DeviceContext(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(ID3D11DeviceContext**)comPtr;
    }

    /// <summary>
    /// Gets the type of device context.
    /// </summary>
    public D3D11DeviceContextType ContextType
    {
        get { return _comImpl->GetContextType(_comPtr); }
    }

    /// <summary>
    /// Sets the constant buffers used by the vertex shader pipeline stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting constant buffers to.</param>
    /// <param name="constantBuffers">Array of constant buffers being given to the device.</param>
    public void VertexShaderSetConstantBuffers(uint startSlot, D3D11Buffer?[]? constantBuffers)
    {
        VertexShaderSetConstantBuffers(startSlot, constantBuffers.AsSpan());
    }

    /// <summary>
    /// Sets the constant buffers used by the vertex shader pipeline stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting constant buffers to.</param>
    /// <param name="constantBuffers">Array of constant buffers being given to the device.</param>
    public void VertexShaderSetConstantBuffers(uint startSlot, ReadOnlySpan<D3D11Buffer?> constantBuffers)
    {
        if (constantBuffers.Length == 0)
        {
            throw new ArgumentNullException(nameof(constantBuffers));
        }

        nint* buffers = stackalloc nint[constantBuffers.Length];
        for (int i = 0; i < constantBuffers.Length; i++)
        {
            D3D11Buffer? current = constantBuffers[i];
            buffers[i] = current is null ? 0 : current.Handle;
        }

        _comImpl->VertexShaderSetConstantBuffers(_comPtr, startSlot, (uint)constantBuffers.Length, buffers);
    }

    /// <summary>
    /// Sets the constant buffers used by the vertex shader pipeline stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting constant buffers to.</param>
    /// <param name="constantBuffers">Array of constant buffers being given to the device.</param>
    public void VertexShaderSetConstantBuffers(uint startSlot, D3D11Buffer? constantBuffers)
    {
        nint buffers = constantBuffers is null ? 0 : constantBuffers.Handle;
        _comImpl->VertexShaderSetConstantBuffers(_comPtr, startSlot, 1, &buffers);
    }

    /// <summary>
    /// Bind an array of shader resources to the pixel shader stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting shader resources to.</param>
    /// <param name="shaderResourceViews">Array of shader resource view interfaces to set to the device.</param>
    public void PixelShaderSetShaderResources(uint startSlot, D3D11ShaderResourceView?[]? shaderResourceViews)
    {
        PixelShaderSetShaderResources(startSlot, shaderResourceViews.AsSpan());
    }

    /// <summary>
    /// Bind an array of shader resources to the pixel shader stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting shader resources to.</param>
    /// <param name="shaderResourceViews">Array of shader resource view interfaces to set to the device.</param>
    public void PixelShaderSetShaderResources(uint startSlot, ReadOnlySpan<D3D11ShaderResourceView?> shaderResourceViews)
    {
        if (shaderResourceViews.Length == 0)
        {
            throw new ArgumentNullException(nameof(shaderResourceViews));
        }

        nint* views = stackalloc nint[shaderResourceViews.Length];
        for (int i = 0; i < shaderResourceViews.Length; i++)
        {
            D3D11ShaderResourceView? current = shaderResourceViews[i];
            views[i] = current is null ? 0 : current.Handle;
        }

        _comImpl->PixelShaderSetShaderResources(_comPtr, startSlot, (uint)shaderResourceViews.Length, views);
    }

    /// <summary>
    /// Bind an array of shader resources to the pixel shader stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting shader resources to.</param>
    /// <param name="shaderResourceViews">Array of shader resource view interfaces to set to the device.</param>
    public void PixelShaderSetShaderResources(uint startSlot, D3D11ShaderResourceView? shaderResourceViews)
    {
        nint views = shaderResourceViews is null ? 0 : shaderResourceViews.Handle;
        _comImpl->PixelShaderSetShaderResources(_comPtr, startSlot, 1, &views);
    }

    /// <summary>
    /// Sets a pixel shader to the device.
    /// </summary>
    /// <param name="pixelShader">A pixel shader.</param>
    public void PixelShaderSetShader(D3D11PixelShader? pixelShader)
    {
        PixelShaderSetShader(pixelShader, []);
    }

    /// <summary>
    /// Sets a pixel shader to the device.
    /// </summary>
    /// <param name="pixelShader">A pixel shader.</param>
    /// <param name="classInstances">An array of class-instance interfaces.</param>
    public void PixelShaderSetShader(D3D11PixelShader? pixelShader, D3D11ClassInstance?[]? classInstances)
    {
        PixelShaderSetShader(pixelShader, classInstances.AsSpan());
    }

    /// <summary>
    /// Sets a pixel shader to the device.
    /// </summary>
    /// <param name="pixelShader">A pixel shader.</param>
    /// <param name="classInstances">An array of class-instance interfaces.</param>
    public void PixelShaderSetShader(D3D11PixelShader? pixelShader, ReadOnlySpan<D3D11ClassInstance?> classInstances)
    {
        if (classInstances.Length == 0)
        {
            nint shader = pixelShader is null ? 0 : pixelShader.Handle;
            _comImpl->PixelShaderSetShader(_comPtr, shader, null, 0);
        }
        else
        {
            if (pixelShader is null)
            {
                throw new ArgumentNullException(nameof(pixelShader));
            }

            nint shader = pixelShader.Handle;
            nint* ptr = stackalloc nint[classInstances.Length];
            for (int i = 0; i < classInstances.Length; i++)
            {
                D3D11ClassInstance? current = classInstances[i];
                ptr[i] = current is null ? 0 : current.Handle;
            }

            _comImpl->PixelShaderSetShader(_comPtr, shader, ptr, (uint)classInstances.Length);
        }
    }

    /// <summary>
    /// Set an array of sampler states to the pixel shader pipeline stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting samplers to.</param>
    /// <param name="samplers">An array of sampler-state interfaces.</param>
    public void PixelShaderSetSamplers(uint startSlot, D3D11SamplerState?[]? samplers)
    {
        PixelShaderSetSamplers(startSlot, samplers.AsSpan());
    }

    /// <summary>
    /// Set an array of sampler states to the pixel shader pipeline stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting samplers to.</param>
    /// <param name="samplers">An array of sampler-state interfaces.</param>
    public void PixelShaderSetSamplers(uint startSlot, ReadOnlySpan<D3D11SamplerState?> samplers)
    {
        if (samplers.Length == 0)
        {
            throw new ArgumentNullException(nameof(samplers));
        }

        nint* samplersPtr = stackalloc nint[samplers.Length];
        for (int i = 0; i < samplers.Length; i++)
        {
            D3D11SamplerState? current = samplers[i];
            samplersPtr[i] = current is null ? 0 : current.Handle;
        }

        _comImpl->PixelShaderSetSamplers(_comPtr, startSlot, (uint)samplers.Length, samplersPtr);
    }

    /// <summary>
    /// Set an array of sampler states to the pixel shader pipeline stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting samplers to.</param>
    /// <param name="samplers">An array of sampler-state interfaces.</param>
    public void PixelShaderSetSamplers(uint startSlot, D3D11SamplerState? samplers)
    {
        nint samplersPtr = samplers is null ? 0 : samplers.Handle;
        _comImpl->PixelShaderSetSamplers(_comPtr, startSlot, 1, &samplersPtr);
    }

    /// <summary>
    /// Set a vertex shader to the device.
    /// </summary>
    /// <param name="vertexShader">A vertex shader.</param>
    public void VertexShaderSetShader(D3D11VertexShader? vertexShader)
    {
        VertexShaderSetShader(vertexShader, []);
    }

    /// <summary>
    /// Set a vertex shader to the device.
    /// </summary>
    /// <param name="vertexShader">A vertex shader.</param>
    /// <param name="classInstances">An array of class-instance interfaces.</param>
    public void VertexShaderSetShader(D3D11VertexShader? vertexShader, D3D11ClassInstance?[]? classInstances)
    {
        VertexShaderSetShader(vertexShader, classInstances.AsSpan());
    }

    /// <summary>
    /// Set a vertex shader to the device.
    /// </summary>
    /// <param name="vertexShader">A vertex shader.</param>
    /// <param name="classInstances">An array of class-instance interfaces.</param>
    public void VertexShaderSetShader(D3D11VertexShader? vertexShader, ReadOnlySpan<D3D11ClassInstance?> classInstances)
    {
        if (classInstances.Length == 0)
        {
            nint shader = vertexShader is null ? 0 : vertexShader.Handle;
            _comImpl->VertexShaderSetShader(_comPtr, shader, null, 0);
        }
        else
        {
            if (vertexShader is null)
            {
                throw new ArgumentNullException(nameof(vertexShader));
            }

            nint shader = vertexShader.Handle;
            nint* ptr = stackalloc nint[classInstances.Length];
            for (int i = 0; i < classInstances.Length; i++)
            {
                D3D11ClassInstance? current = classInstances[i];
                ptr[i] = current is null ? 0 : current.Handle;
            }

            _comImpl->VertexShaderSetShader(_comPtr, shader, ptr, (uint)classInstances.Length);
        }
    }

    /// <summary>
    /// Draw indexed, non-instanced primitives.
    /// </summary>
    /// <param name="indexCount">Number of indices to draw.</param>
    /// <param name="startIndexLocation">The location of the first index read by the GPU from the index buffer.</param>
    /// <param name="baseVertexLocation">A value added to each index before reading a vertex from the vertex buffer.</param>
    public void DrawIndexed(uint indexCount, uint startIndexLocation, int baseVertexLocation)
    {
        _comImpl->DrawIndexed(_comPtr, indexCount, startIndexLocation, baseVertexLocation);
    }

    /// <summary>
    /// Draw non-indexed, non-instanced primitives.
    /// </summary>
    /// <param name="vertexCount">Number of vertices to draw.</param>
    /// <param name="startVertexLocation">Index of the first vertex, which is usually an offset in a vertex buffer.</param>
    public void Draw(uint vertexCount, uint startVertexLocation)
    {
        _comImpl->Draw(_comPtr, vertexCount, startVertexLocation);
    }

    /// <summary>
    /// Gets a pointer to the data contained in a subresource, and denies the GPU access to that subresource.
    /// </summary>
    /// <param name="resource">A <see cref="D3D11Resource"/> interface.</param>
    /// <param name="subresource">Index number of the subresource.</param>
    /// <param name="cpuPermission">The CPU's read and write permissions for a resource.</param>
    /// <param name="options">Specifies what the CPU does when the GPU is busy.</param>
    /// <returns>The mapped subresource.</returns>
    public D3D11MappedSubResource Map(
        D3D11Resource? resource,
        uint subresource,
        D3D11MapCpuPermission cpuPermission,
        D3D11MapOptions options)
    {
        if (resource is null)
        {
            throw new ArgumentNullException(nameof(resource));
        }

        int size = D3D11MappedSubResource.NativeRequiredSize();
        byte* ptr = stackalloc byte[size];
        int hr = _comImpl->Map(_comPtr, resource.Handle, subresource, cpuPermission, options, ptr);
        Marshal.ThrowExceptionForHR(hr);
        return D3D11MappedSubResource.NativeReadFrom((nint)ptr);
    }

    /// <summary>
    /// Invalidate the pointer to a resource and reenable the GPU's access to that resource.
    /// </summary>
    /// <param name="resource">A <see cref="D3D11Resource"/> interface.</param>
    /// <param name="subresource">A subresource to be unmapped.</param>
    public void Unmap(D3D11Resource? resource, uint subresource)
    {
        if (resource is null)
        {
            throw new ArgumentNullException(nameof(resource));
        }

        _comImpl->Unmap(_comPtr, resource.Handle, subresource);
    }

    /// <summary>
    /// Sets the constant buffers used by the pixel shader pipeline stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting constant buffers to.</param>
    /// <param name="constantBuffers">Array of constant buffers.</param>
    public void PixelShaderSetConstantBuffers(uint startSlot, D3D11Buffer?[]? constantBuffers)
    {
        PixelShaderSetConstantBuffers(startSlot, constantBuffers.AsSpan());
    }

    /// <summary>
    /// Sets the constant buffers used by the pixel shader pipeline stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting constant buffers to.</param>
    /// <param name="constantBuffers">Array of constant buffers.</param>
    public void PixelShaderSetConstantBuffers(uint startSlot, ReadOnlySpan<D3D11Buffer?> constantBuffers)
    {
        if (constantBuffers.Length == 0)
        {
            throw new ArgumentNullException(nameof(constantBuffers));
        }

        nint* buffers = stackalloc nint[constantBuffers.Length];
        for (int i = 0; i < constantBuffers.Length; i++)
        {
            D3D11Buffer? current = constantBuffers[i];
            buffers[i] = current is null ? 0 : current.Handle;
        }

        _comImpl->PixelShaderSetConstantBuffers(_comPtr, startSlot, (uint)constantBuffers.Length, buffers);
    }

    /// <summary>
    /// Sets the constant buffers used by the pixel shader pipeline stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting constant buffers to.</param>
    /// <param name="constantBuffers">Array of constant buffers.</param>
    public void PixelShaderSetConstantBuffers(uint startSlot, D3D11Buffer? constantBuffers)
    {
        nint buffers = constantBuffers is null ? 0 : constantBuffers.Handle;
        _comImpl->PixelShaderSetConstantBuffers(_comPtr, startSlot, 1, &buffers);
    }

    /// <summary>
    /// Bind an input-layout object to the input-assembler stage.
    /// </summary>
    /// <param name="inputLayout">The input-layout object.</param>
    public void InputAssemblerSetInputLayout(D3D11InputLayout? inputLayout)
    {
        _comImpl->InputAssemblerSetInputLayout(_comPtr, inputLayout is null ? 0 : inputLayout.Handle);
    }

    /// <summary>
    /// Bind an array of vertex buffers to the input-assembler stage.
    /// </summary>
    /// <param name="startSlot">The first input slot for binding.</param>
    /// <param name="vertexBuffers">An array of vertex buffers.</param>
    /// <param name="strides">An array of stride values; one stride value for each buffer in the vertex-buffer array.</param>
    /// <param name="offsets">An array of offset values; one offset value for each buffer in the vertex-buffer array.</param>
    public void InputAssemblerSetVertexBuffers(uint startSlot, D3D11Buffer?[]? vertexBuffers, uint[]? strides, uint[]? offsets)
    {
        InputAssemblerSetVertexBuffers(startSlot, vertexBuffers.AsSpan(), strides.AsSpan(), offsets.AsSpan());
    }

    /// <summary>
    /// Bind an array of vertex buffers to the input-assembler stage.
    /// </summary>
    /// <param name="startSlot">The first input slot for binding.</param>
    /// <param name="vertexBuffers">An array of vertex buffers.</param>
    /// <param name="strides">An array of stride values; one stride value for each buffer in the vertex-buffer array.</param>
    /// <param name="offsets">An array of offset values; one offset value for each buffer in the vertex-buffer array.</param>
    public void InputAssemblerSetVertexBuffers(uint startSlot, ReadOnlySpan<D3D11Buffer?> vertexBuffers, ReadOnlySpan<uint> strides, ReadOnlySpan<uint> offsets)
    {
        if (vertexBuffers.Length == 0)
        {
            throw new ArgumentNullException(nameof(vertexBuffers));
        }

        if (strides.Length == 0)
        {
            throw new ArgumentNullException(nameof(strides));
        }

        if (offsets.Length == 0)
        {
            throw new ArgumentNullException(nameof(offsets));
        }

        if (strides.Length != vertexBuffers.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(strides));
        }

        if (offsets.Length != vertexBuffers.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(offsets));
        }

        nint* buffers = stackalloc nint[vertexBuffers.Length];
        for (int i = 0; i < vertexBuffers.Length; i++)
        {
            D3D11Buffer? current = vertexBuffers[i];
            buffers[i] = current is null ? 0 : current.Handle;
        }

        fixed (uint* stridesPtr = strides)
        fixed (uint* offsetsPtr = offsets)
        {
            _comImpl->InputAssemblerSetVertexBuffers(_comPtr, startSlot, (uint)vertexBuffers.Length, buffers, stridesPtr, offsetsPtr);
        }
    }

    /// <summary>
    /// Bind an array of vertex buffers to the input-assembler stage.
    /// </summary>
    /// <param name="startSlot">The first input slot for binding.</param>
    /// <param name="vertexBuffers">An array of vertex buffers.</param>
    /// <param name="strides">An array of stride values; one stride value for each buffer in the vertex-buffer array.</param>
    /// <param name="offsets">An array of offset values; one offset value for each buffer in the vertex-buffer array.</param>
    public void InputAssemblerSetVertexBuffers(uint startSlot, D3D11Buffer? vertexBuffers, uint strides, uint offsets)
    {
        nint buffers = vertexBuffers is null ? 0 : vertexBuffers.Handle;
        _comImpl->InputAssemblerSetVertexBuffers(_comPtr, startSlot, 1, &buffers, &strides, &offsets);
    }

    /// <summary>
    /// Bind an array of vertex buffers to the input-assembler stage.
    /// </summary>
    /// <param name="startSlot">The first input slot for binding.</param>
    /// <param name="vertexBuffers">An array of vertex buffers.</param>
    public void InputAssemblerSetVertexBuffers(uint startSlot, D3D11VertexBufferBinding[]? vertexBuffers)
    {
        InputAssemblerSetVertexBuffers(startSlot, vertexBuffers.AsSpan());
    }

    /// <summary>
    /// Bind an array of vertex buffers to the input-assembler stage.
    /// </summary>
    /// <param name="startSlot">The first input slot for binding.</param>
    /// <param name="vertexBuffers">An array of vertex buffers.</param>
    public void InputAssemblerSetVertexBuffers(uint startSlot, ReadOnlySpan<D3D11VertexBufferBinding> vertexBuffers)
    {
        if (vertexBuffers.Length == 0)
        {
            throw new ArgumentNullException(nameof(vertexBuffers));
        }

        nint* buffers = stackalloc nint[vertexBuffers.Length];
        uint* strides = stackalloc uint[vertexBuffers.Length];
        uint* offsets = stackalloc uint[vertexBuffers.Length];

        for (int i = 0; i < vertexBuffers.Length; i++)
        {
            D3D11VertexBufferBinding current = vertexBuffers[i];
            buffers[i] = current.Buffer is null ? 0 : current.Buffer.Handle;
            strides[i] = current.Stride;
            offsets[i] = current.Offset;
        }

        _comImpl->InputAssemblerSetVertexBuffers(_comPtr, startSlot, (uint)vertexBuffers.Length, buffers, strides, offsets);
    }

    /// <summary>
    /// Bind an array of vertex buffers to the input-assembler stage.
    /// </summary>
    /// <param name="startSlot">The first input slot for binding.</param>
    /// <param name="vertexBuffers">An array of vertex buffers.</param>
    public void InputAssemblerSetVertexBuffers(uint startSlot, D3D11VertexBufferBinding vertexBuffers)
    {
        nint buffers = vertexBuffers.Buffer is null ? 0 : vertexBuffers.Buffer.Handle;
        uint strides = vertexBuffers.Stride;
        uint offsets = vertexBuffers.Offset;
        _comImpl->InputAssemblerSetVertexBuffers(_comPtr, startSlot, 1, &buffers, &strides, &offsets);
    }

    /// <summary>
    /// Bind an index buffer to the input-assembler stage.
    /// </summary>
    /// <param name="indexBuffer">An <see cref="D3D11Buffer"/> object, that contains indices.</param>
    /// <param name="format">The format of the data in the index buffer.</param>
    /// <param name="offset">Offset (in bytes) from the start of the index buffer to the first index to use.</param>
    public void InputAssemblerSetIndexBuffer(D3D11Buffer? indexBuffer, DxgiFormat format, uint offset)
    {
        nint buffer = indexBuffer is null ? 0 : indexBuffer.Handle;
        _comImpl->InputAssemblerSetIndexBuffer(_comPtr, buffer, format, offset);
    }

    /// <summary>
    /// Draw indexed, instanced primitives.
    /// </summary>
    /// <param name="indexCountPerInstance">Number of indices read from the index buffer for each instance.</param>
    /// <param name="instanceCount">Number of instances to draw.</param>
    /// <param name="startIndexLocation">The location of the first index read by the GPU from the index buffer.</param>
    /// <param name="baseVertexLocation">A value added to each index before reading a vertex from the vertex buffer.</param>
    /// <param name="startInstanceLocation">A value added to each index before reading per-instance data from a vertex buffer.</param>
    public void DrawIndexedInstanced(
        uint indexCountPerInstance,
        uint instanceCount,
        uint startIndexLocation,
        int baseVertexLocation,
        uint startInstanceLocation)
    {
        _comImpl->DrawIndexedInstanced(
            _comPtr,
            indexCountPerInstance,
            instanceCount,
            startIndexLocation,
            baseVertexLocation,
            startInstanceLocation);
    }

    /// <summary>
    /// Draw non-indexed, instanced primitives.
    /// </summary>
    /// <param name="vertexCountPerInstance">Number of vertices to draw.</param>
    /// <param name="instanceCount">Number of instances to draw.</param>
    /// <param name="startVertexLocation">Index of the first vertex.</param>
    /// <param name="startInstanceLocation">A value added to each index before reading per-instance data from a vertex buffer.</param>
    public void DrawInstanced(
        uint vertexCountPerInstance,
        uint instanceCount,
        uint startVertexLocation,
        uint startInstanceLocation)
    {
        _comImpl->DrawInstanced(
            _comPtr,
            vertexCountPerInstance,
            instanceCount,
            startVertexLocation,
            startInstanceLocation);
    }

    /// <summary>
    /// Sets the constant buffers used by the geometry shader pipeline stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting constant buffers to.</param>
    /// <param name="constantBuffers">Array of constant buffers.</param>
    public void GeometryShaderSetConstantBuffers(uint startSlot, D3D11Buffer?[]? constantBuffers)
    {
        GeometryShaderSetConstantBuffers(startSlot, constantBuffers.AsSpan());
    }

    /// <summary>
    /// Sets the constant buffers used by the geometry shader pipeline stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting constant buffers to.</param>
    /// <param name="constantBuffers">Array of constant buffers.</param>
    public void GeometryShaderSetConstantBuffers(uint startSlot, ReadOnlySpan<D3D11Buffer?> constantBuffers)
    {
        if (constantBuffers.Length == 0)
        {
            throw new ArgumentNullException(nameof(constantBuffers));
        }

        nint* buffers = stackalloc nint[constantBuffers.Length];
        for (int i = 0; i < constantBuffers.Length; i++)
        {
            D3D11Buffer? current = constantBuffers[i];
            buffers[i] = current is null ? 0 : current.Handle;
        }

        _comImpl->GeometryShaderSetConstantBuffers(_comPtr, startSlot, (uint)constantBuffers.Length, buffers);
    }

    /// <summary>
    /// Set a geometry shader to the device.
    /// </summary>
    /// <param name="geometryShader">A geometry shader.</param>
    public void GeometryShaderSetShader(D3D11GeometryShader? geometryShader)
    {
        GeometryShaderSetShader(geometryShader, []);
    }

    /// <summary>
    /// Set a geometry shader to the device.
    /// </summary>
    /// <param name="geometryShader">A geometry shader.</param>
    /// <param name="classInstances">An array of class-instance interfaces.</param>
    public void GeometryShaderSetShader(D3D11GeometryShader? geometryShader, D3D11ClassInstance?[]? classInstances)
    {
        GeometryShaderSetShader(geometryShader, classInstances.AsSpan());
    }

    /// <summary>
    /// Set a geometry shader to the device.
    /// </summary>
    /// <param name="geometryShader">A geometry shader.</param>
    /// <param name="classInstances">An array of class-instance interfaces.</param>
    public void GeometryShaderSetShader(D3D11GeometryShader? geometryShader, ReadOnlySpan<D3D11ClassInstance?> classInstances)
    {
        if (classInstances.Length == 0)
        {
            nint shader = geometryShader is null ? 0 : geometryShader.Handle;
            _comImpl->GeometryShaderSetShader(_comPtr, shader, null, 0);
        }
        else
        {
            if (geometryShader is null)
            {
                throw new ArgumentNullException(nameof(geometryShader));
            }

            nint shader = geometryShader.Handle;
            nint* ptr = stackalloc nint[classInstances.Length];
            for (int i = 0; i < classInstances.Length; i++)
            {
                D3D11ClassInstance? current = classInstances[i];
                ptr[i] = current is null ? 0 : current.Handle;
            }

            _comImpl->GeometryShaderSetShader(_comPtr, shader, ptr, (uint)classInstances.Length);
        }
    }

    /// <summary>
    /// Bind information about the primitive type, and data order that describes input data for the input assembler stage.
    /// </summary>
    /// <param name="topology">The type of primitive and ordering of the primitive data.</param>
    public void InputAssemblerSetPrimitiveTopology(D3D11PrimitiveTopology topology)
    {
        _comImpl->InputAssemblerSetPrimitiveTopology(_comPtr, topology);
    }

    /// <summary>
    /// Bind an array of shader resources to the vertex shader stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting shader resources to.</param>
    /// <param name="shaderResourceViews">Array of shader resource view interfaces to set to the device.</param>
    public void VertexShaderSetShaderResources(uint startSlot, D3D11ShaderResourceView?[]? shaderResourceViews)
    {
        VertexShaderSetShaderResources(startSlot, shaderResourceViews.AsSpan());
    }

    /// <summary>
    /// Bind an array of shader resources to the vertex shader stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting shader resources to.</param>
    /// <param name="shaderResourceViews">Array of shader resource view interfaces to set to the device.</param>
    public void VertexShaderSetShaderResources(uint startSlot, ReadOnlySpan<D3D11ShaderResourceView?> shaderResourceViews)
    {
        if (shaderResourceViews.Length == 0)
        {
            throw new ArgumentNullException(nameof(shaderResourceViews));
        }

        nint* views = stackalloc nint[shaderResourceViews.Length];
        for (int i = 0; i < shaderResourceViews.Length; i++)
        {
            D3D11ShaderResourceView? current = shaderResourceViews[i];
            views[i] = current is null ? 0 : current.Handle;
        }

        _comImpl->VertexShaderSetShaderResources(_comPtr, startSlot, (uint)shaderResourceViews.Length, views);
    }

    /// <summary>
    /// Bind an array of shader resources to the vertex shader stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting shader resources to.</param>
    /// <param name="shaderResourceViews">Array of shader resource view interfaces to set to the device.</param>
    public void VertexShaderSetShaderResources(uint startSlot, D3D11ShaderResourceView? shaderResourceViews)
    {
        nint views = shaderResourceViews is null ? 0 : shaderResourceViews.Handle;
        _comImpl->VertexShaderSetShaderResources(_comPtr, startSlot, 1, &views);
    }

    /// <summary>
    /// Set an array of sampler states to the vertex shader pipeline stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting samplers to.</param>
    /// <param name="samplers">An array of sampler-state interfaces.</param>
    public void VertexShaderSetSamplers(uint startSlot, D3D11SamplerState?[]? samplers)
    {
        VertexShaderSetSamplers(startSlot, samplers.AsSpan());
    }

    /// <summary>
    /// Set an array of sampler states to the vertex shader pipeline stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting samplers to.</param>
    /// <param name="samplers">An array of sampler-state interfaces.</param>
    public void VertexShaderSetSamplers(uint startSlot, ReadOnlySpan<D3D11SamplerState?> samplers)
    {
        if (samplers.Length == 0)
        {
            throw new ArgumentNullException(nameof(samplers));
        }

        nint* samplersPtr = stackalloc nint[samplers.Length];
        for (int i = 0; i < samplers.Length; i++)
        {
            D3D11SamplerState? current = samplers[i];
            samplersPtr[i] = current is null ? 0 : current.Handle;
        }

        _comImpl->VertexShaderSetSamplers(_comPtr, startSlot, (uint)samplers.Length, samplersPtr);
    }

    /// <summary>
    /// Set an array of sampler states to the vertex shader pipeline stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting samplers to.</param>
    /// <param name="samplers">An array of sampler-state interfaces.</param>
    public void VertexShaderSetSamplers(uint startSlot, D3D11SamplerState? samplers)
    {
        nint samplersPtr = samplers is null ? 0 : samplers.Handle;
        _comImpl->VertexShaderSetSamplers(_comPtr, startSlot, 1, &samplersPtr);
    }

    /// <summary>
    /// Mark the beginning of a series of commands.
    /// </summary>
    /// <param name="async">A <see cref="D3D11Asynchronous"/> interface.</param>
    public void Begin(D3D11Asynchronous? async)
    {
        if (async is null)
        {
            throw new ArgumentNullException(nameof(async));
        }

        _comImpl->Begin(_comPtr, async.Handle);
    }

    /// <summary>
    /// Mark the end of a series of commands.
    /// </summary>
    /// <param name="async">A <see cref="D3D11Asynchronous"/> interface.</param>
    public void End(D3D11Asynchronous? async)
    {
        if (async is null)
        {
            throw new ArgumentNullException(nameof(async));
        }

        _comImpl->End(_comPtr, async.Handle);
    }

    /// <summary>
    /// Get data from the graphics processing unit (GPU) asynchronously.
    /// </summary>
    /// <param name="async">A <see cref="D3D11Asynchronous"/> interface for the object about which <c>GetData</c> retrieves data.</param>
    /// <returns>A boolean value indicating whether the operation succeeded.</returns>
    public bool GetData(D3D11Asynchronous? async)
    {
        return GetData(async, D3D11AsyncGetDataOptions.None);
    }

    /// <summary>
    /// Get data from the graphics processing unit (GPU) asynchronously.
    /// </summary>
    /// <param name="async">A <see cref="D3D11Asynchronous"/> interface for the object about which <c>GetData</c> retrieves data.</param>
    /// <param name="options">Optional flags.</param>
    /// <returns>A boolean value indicating whether the operation succeeded.</returns>
    public bool GetData(D3D11Asynchronous? async, D3D11AsyncGetDataOptions options)
    {
        if (async is null)
        {
            throw new ArgumentNullException(nameof(async));
        }

        int hr = _comImpl->GetData(_comPtr, async.Handle, null, 0, options);
        return hr == 0;
    }

    /// <summary>
    /// Get data from the graphics processing unit (GPU) asynchronously.
    /// </summary>
    /// <typeparam name="T">The type of data.</typeparam>
    /// <param name="async">A <see cref="D3D11Asynchronous"/> interface for the object about which <c>GetData</c> retrieves data.</param>
    /// <param name="data">The data.</param>
    /// <returns>A boolean value indicating whether the operation succeeded.</returns>
    public bool GetData<T>(D3D11Asynchronous? async, out T data)
        where T : unmanaged
    {
        return GetData(async, D3D11AsyncGetDataOptions.None, out data);
    }

    /// <summary>
    /// Get data from the graphics processing unit (GPU) asynchronously.
    /// </summary>
    /// <typeparam name="T">The type of data.</typeparam>
    /// <param name="async">A <see cref="D3D11Asynchronous"/> interface for the object about which <c>GetData</c> retrieves data.</param>
    /// <param name="options">Optional flags.</param>
    /// <param name="data">The data.</param>
    /// <returns>A boolean value indicating whether the operation succeeded.</returns>
    public bool GetData<T>(D3D11Asynchronous? async, D3D11AsyncGetDataOptions options, out T data)
        where T : unmanaged
    {
        if (async is null)
        {
            throw new ArgumentNullException(nameof(async));
        }

        int size = DXMarshal.SizeOf<T>();
        fixed (void* dataPtr = &data)
        {
            int hr = _comImpl->GetData(_comPtr, async.Handle, dataPtr, (uint)size, options);
            return hr == 0;
        }
    }

    /// <summary>
    /// Set a rendering predicate.
    /// </summary>
    /// <param name="predicate">A predicate.</param>
    /// <param name="value">A value indicating whether rendering will be affected by when the predicate's conditions are met or not met.</param>
    public void SetPredication(D3D11Predicate? predicate, bool value)
    {
        nint ptr = predicate is null ? 0 : predicate.Handle;
        _comImpl->SetPredication(_comPtr, ptr, value ? 1 : 0);
    }

    /// <summary>
    /// Bind an array of shader resources to the geometry shader stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting shader resources to.</param>
    /// <param name="shaderResourceViews">Array of shader resource view interfaces to set to the device.</param>
    public void GeometryShaderSetShaderResources(uint startSlot, D3D11ShaderResourceView?[]? shaderResourceViews)
    {
        GeometryShaderSetShaderResources(startSlot, shaderResourceViews.AsSpan());
    }

    /// <summary>
    /// Bind an array of shader resources to the geometry shader stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting shader resources to.</param>
    /// <param name="shaderResourceViews">Array of shader resource view interfaces to set to the device.</param>
    public void GeometryShaderSetShaderResources(uint startSlot, ReadOnlySpan<D3D11ShaderResourceView?> shaderResourceViews)
    {
        if (shaderResourceViews.Length == 0)
        {
            throw new ArgumentNullException(nameof(shaderResourceViews));
        }

        nint* views = stackalloc nint[shaderResourceViews.Length];
        for (int i = 0; i < shaderResourceViews.Length; i++)
        {
            D3D11ShaderResourceView? current = shaderResourceViews[i];
            views[i] = current is null ? 0 : current.Handle;
        }

        _comImpl->GeometryShaderSetShaderResources(_comPtr, startSlot, (uint)shaderResourceViews.Length, views);
    }

    /// <summary>
    /// Bind an array of shader resources to the geometry shader stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting shader resources to.</param>
    /// <param name="shaderResourceViews">Array of shader resource view interfaces to set to the device.</param>
    public void GeometryShaderSetShaderResources(uint startSlot, D3D11ShaderResourceView? shaderResourceViews)
    {
        nint views = shaderResourceViews is null ? 0 : shaderResourceViews.Handle;
        _comImpl->GeometryShaderSetShaderResources(_comPtr, startSlot, 1, &views);
    }

    /// <summary>
    /// Set an array of sampler states to the geometry shader pipeline stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting samplers to.</param>
    /// <param name="samplers">An array of sampler-state interfaces.</param>
    public void GeometryShaderSetSamplers(uint startSlot, D3D11SamplerState?[]? samplers)
    {
        GeometryShaderSetSamplers(startSlot, samplers.AsSpan());
    }

    /// <summary>
    /// Set an array of sampler states to the geometry shader pipeline stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting samplers to.</param>
    /// <param name="samplers">An array of sampler-state interfaces.</param>
    public void GeometryShaderSetSamplers(uint startSlot, ReadOnlySpan<D3D11SamplerState?> samplers)
    {
        if (samplers.Length == 0)
        {
            throw new ArgumentNullException(nameof(samplers));
        }

        nint* samplersPtr = stackalloc nint[samplers.Length];
        for (int i = 0; i < samplers.Length; i++)
        {
            D3D11SamplerState? current = samplers[i];
            samplersPtr[i] = current is null ? 0 : current.Handle;
        }

        _comImpl->GeometryShaderSetSamplers(_comPtr, startSlot, (uint)samplers.Length, samplersPtr);
    }

    /// <summary>
    /// Set an array of sampler states to the geometry shader pipeline stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting samplers to.</param>
    /// <param name="samplers">An array of sampler-state interfaces.</param>
    public void GeometryShaderSetSamplers(uint startSlot, D3D11SamplerState? samplers)
    {
        nint samplersPtr = samplers is null ? 0 : samplers.Handle;
        _comImpl->GeometryShaderSetSamplers(_comPtr, startSlot, 1, &samplersPtr);
    }

    /// <summary>
    /// Bind one or more render targets atomically and the depth-stencil buffer to the output-merger stage.
    /// </summary>
    /// <param name="renderTargetViews">The render targets to bind to the device.</param>
    /// <param name="depthStencilView">The depth-stencil view to bind to the device.</param>
    public void OutputMergerSetRenderTargets(D3D11RenderTargetView?[]? renderTargetViews, D3D11DepthStencilView? depthStencilView)
    {
        OutputMergerSetRenderTargets(renderTargetViews.AsSpan(), depthStencilView);
    }

    /// <summary>
    /// Bind one or more render targets atomically and the depth-stencil buffer to the output-merger stage.
    /// </summary>
    /// <param name="renderTargetViews">The render targets to bind to the device.</param>
    /// <param name="depthStencilView">The depth-stencil view to bind to the device.</param>
    public void OutputMergerSetRenderTargets(ReadOnlySpan<D3D11RenderTargetView?> renderTargetViews, D3D11DepthStencilView? depthStencilView)
    {
        if (renderTargetViews.Length == 0)
        {
            nint ptr = depthStencilView is null ? 0 : depthStencilView.Handle;
            _comImpl->OutputMergerSetRenderTargets(_comPtr, 0, null, ptr);
        }
        else
        {
            nint* views = stackalloc nint[renderTargetViews.Length];
            for (int i = 0; i < renderTargetViews.Length; i++)
            {
                D3D11RenderTargetView? current = renderTargetViews[i];
                views[i] = current is null ? 0 : current.Handle;
            }

            nint ptr = depthStencilView is null ? 0 : depthStencilView.Handle;
            _comImpl->OutputMergerSetRenderTargets(_comPtr, (uint)renderTargetViews.Length, views, ptr);
        }
    }

    /// <summary>
    /// Bind one or more render targets atomically and the depth-stencil buffer to the output-merger stage.
    /// </summary>
    /// <param name="renderTargetViews">The render targets to bind to the device.</param>
    /// <param name="depthStencilView">The depth-stencil view to bind to the device.</param>
    public void OutputMergerSetRenderTargets(D3D11RenderTargetView? renderTargetViews, D3D11DepthStencilView? depthStencilView)
    {
        nint views = renderTargetViews is null ? 0 : renderTargetViews.Handle;
        nint ptr = depthStencilView is null ? 0 : depthStencilView.Handle;
        _comImpl->OutputMergerSetRenderTargets(_comPtr, 1, &views, ptr);
    }

    /// <summary>
    /// Binds resources to the output-merger stage.
    /// </summary>
    /// <param name="renderTargetViews">The render targets to bind to the device.</param>
    /// <param name="depthStencilView">The depth-stencil view to bind to the device.</param>
    /// <param name="uavStartSlot">Index into a zero-based array to begin setting unordered-access views.</param>
    /// <param name="unorderedAccessViews">The unordered-access views to bind to the device.</param>
    /// <param name="uavInitialCounts">An array of append and consume buffer offsets. A value of <value>-1</value> indicates to keep the current offset.</param>
    public void OutputMergerSetRenderTargetsAndUnorderedAccessViews(
        D3D11RenderTargetView?[]? renderTargetViews,
        D3D11DepthStencilView? depthStencilView,
        uint uavStartSlot,
        D3D11UnorderedAccessView?[]? unorderedAccessViews,
        uint[]? uavInitialCounts)
    {
        OutputMergerSetRenderTargetsAndUnorderedAccessViews(
            renderTargetViews.AsSpan(),
            depthStencilView,
            uavStartSlot,
            unorderedAccessViews.AsSpan(),
            uavInitialCounts.AsSpan());
    }

    /// <summary>
    /// Binds resources to the output-merger stage.
    /// </summary>
    /// <param name="renderTargetViews">The render targets to bind to the device.</param>
    /// <param name="depthStencilView">The depth-stencil view to bind to the device.</param>
    /// <param name="uavStartSlot">Index into a zero-based array to begin setting unordered-access views.</param>
    /// <param name="unorderedAccessViews">The unordered-access views to bind to the device.</param>
    /// <param name="uavInitialCounts">An array of append and consume buffer offsets. A value of <value>-1</value> indicates to keep the current offset.</param>
    public void OutputMergerSetRenderTargetsAndUnorderedAccessViews(
        ReadOnlySpan<D3D11RenderTargetView?> renderTargetViews,
        D3D11DepthStencilView? depthStencilView,
        uint uavStartSlot,
        ReadOnlySpan<D3D11UnorderedAccessView?> unorderedAccessViews,
        ReadOnlySpan<uint> uavInitialCounts)
    {
        if (unorderedAccessViews.Length != 0)
        {
            if (uavInitialCounts.Length == 0)
            {
                throw new ArgumentNullException(nameof(uavInitialCounts));
            }

            if (uavInitialCounts.Length != unorderedAccessViews.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(uavInitialCounts));
            }
        }

        nint* rtv = stackalloc nint[renderTargetViews.Length];
        for (int i = 0; i < renderTargetViews.Length; i++)
        {
            D3D11RenderTargetView? current = renderTargetViews[i];
            rtv[i] = current is null ? 0 : current.Handle;
        }

        nint* uav = stackalloc nint[unorderedAccessViews.Length];
        for (int i = 0; i < unorderedAccessViews.Length; i++)
        {
            D3D11UnorderedAccessView? current = unorderedAccessViews[i];
            uav[i] = current is null ? 0 : current.Handle;
        }

        nint ptr = depthStencilView is null ? 0 : depthStencilView.Handle;

        fixed (uint* uavInitialCountsPtr = uavInitialCounts)
        {
            _comImpl->OutputMergerSetRenderTargetsAndUnorderedAccessViews(
                _comPtr,
                (uint)renderTargetViews.Length,
                rtv,
                ptr,
                uavStartSlot,
                (uint)unorderedAccessViews.Length,
                uav,
                unorderedAccessViews.Length == 0 ? null : uavInitialCountsPtr);
        }
    }

    /// <summary>
    /// Set the blend state of the output-merger stage.
    /// </summary>
    /// <param name="blendState">A blend-state interface.</param>
    /// <param name="blendFactor">Array of blend factors, one for each RGBA component. The blend factors modulate values for the pixel shader, render target, or both.</param>
    /// <param name="sampleMask">32-bit sample coverage. The default value is <value>0xffffffff</value>.</param>
    public void OutputMergerSetBlendState(D3D11BlendState? blendState, float[]? blendFactor, uint sampleMask)
    {
        OutputMergerSetBlendState(blendState, blendFactor.AsSpan(), sampleMask);
    }

    /// <summary>
    /// Set the blend state of the output-merger stage.
    /// </summary>
    /// <param name="blendState">A blend-state interface.</param>
    /// <param name="blendFactorR">Array of blend factors, one for each RGBA component. The blend factors modulate values for the pixel shader, render target, or both.</param>
    /// <param name="blendFactorG">Array of blend factors, one for each RGBA component. The blend factors modulate values for the pixel shader, render target, or both.</param>
    /// <param name="blendFactorB">Array of blend factors, one for each RGBA component. The blend factors modulate values for the pixel shader, render target, or both.</param>
    /// <param name="blendFactorA">Array of blend factors, one for each RGBA component. The blend factors modulate values for the pixel shader, render target, or both.</param>
    /// <param name="sampleMask">32-bit sample coverage. The default value is <value>0xffffffff</value>.</param>
    public void OutputMergerSetBlendState(D3D11BlendState? blendState, float blendFactorR, float blendFactorG, float blendFactorB, float blendFactorA, uint sampleMask)
    {
        nint ptr = blendState is null ? 0 : blendState.Handle;
        float* blendFactor = stackalloc float[4];
        blendFactor[0] = blendFactorR;
        blendFactor[1] = blendFactorG;
        blendFactor[2] = blendFactorB;
        blendFactor[3] = blendFactorA;
        _comImpl->OutputMergerSetBlendState(_comPtr, ptr, blendFactor, sampleMask);
    }

    /// <summary>
    /// Set the blend state of the output-merger stage.
    /// </summary>
    /// <param name="blendState">A blend-state interface.</param>
    /// <param name="blendFactor">Array of blend factors, one for each RGBA component. The blend factors modulate values for the pixel shader, render target, or both.</param>
    /// <param name="sampleMask">32-bit sample coverage. The default value is <value>0xffffffff</value>.</param>
    public void OutputMergerSetBlendState(D3D11BlendState? blendState, ReadOnlySpan<float> blendFactor, uint sampleMask)
    {
        if (blendFactor.Length != 0 && blendFactor.Length != 4)
        {
            throw new ArgumentOutOfRangeException(nameof(blendFactor));
        }

        nint ptr = blendState is null ? 0 : blendState.Handle;

        fixed (float* blendFactorPtr = blendFactor)
        {
            _comImpl->OutputMergerSetBlendState(_comPtr, ptr, blendFactorPtr, sampleMask);
        }
    }

    /// <summary>
    /// Sets the depth-stencil state of the output-merger stage.
    /// </summary>
    /// <param name="depthStencilState">A depth-stencil state interface.</param>
    /// <param name="stencilReference">Reference value to perform against when doing a depth-stencil test.</param>
    public void OutputMergerSetDepthStencilState(D3D11DepthStencilState? depthStencilState, uint stencilReference)
    {
        nint ptr = depthStencilState is null ? 0 : depthStencilState.Handle;
        _comImpl->OutputMergerSetDepthStencilState(_comPtr, ptr, stencilReference);
    }

    /// <summary>
    /// Reference value to perform against when doing a depth-stencil test.
    /// </summary>
    public void StreamOutputSetTargets()
    {
        _comImpl->StreamOutputSetTargets(_comPtr, 0, null, null);
    }

    /// <summary>
    /// Reference value to perform against when doing a depth-stencil test.
    /// </summary>
    /// <param name="targets">The array of output buffers to bind to the device.</param>
    /// <param name="offsets">Array of offsets to the output buffers.</param>
    public void StreamOutputSetTargets(D3D11Buffer?[]? targets, uint[]? offsets)
    {
        StreamOutputSetTargets(targets.AsSpan(), offsets.AsSpan());
    }

    /// <summary>
    /// Reference value to perform against when doing a depth-stencil test.
    /// </summary>
    /// <param name="targets">The array of output buffers to bind to the device.</param>
    /// <param name="offsets">Array of offsets to the output buffers.</param>
    public void StreamOutputSetTargets(ReadOnlySpan<D3D11Buffer?> targets, ReadOnlySpan<uint> offsets)
    {
        if (targets.Length != 0)
        {
            if (offsets.Length == 0)
            {
                throw new ArgumentNullException(nameof(offsets));
            }

            if (offsets.Length != targets.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(offsets));
            }
        }

        nint* targetsPtr = stackalloc nint[targets.Length];
        for (int i = 0; i < targets.Length; i++)
        {
            D3D11Buffer? current = targets[i];
            targetsPtr[i] = current is null ? 0 : current.Handle;
        }

        fixed (uint* offsetsPtr = offsets)
        {
            _comImpl->StreamOutputSetTargets(_comPtr, (uint)targets.Length, targetsPtr, offsetsPtr);
        }
    }

    /// <summary>
    /// Reference value to perform against when doing a depth-stencil test.
    /// </summary>
    /// <param name="targets">The array of output buffers to bind to the device.</param>
    /// <param name="offsets">Array of offsets to the output buffers.</param>
    public void StreamOutputSetTargets(D3D11Buffer? targets, uint offsets)
    {
        nint targetsPtr = targets is null ? 0 : targets.Handle;
        _comImpl->StreamOutputSetTargets(_comPtr, 1, &targetsPtr, &offsets);
    }

    /// <summary>
    /// Draw geometry of an unknown size.
    /// </summary>
    public void DrawAuto()
    {
        _comImpl->DrawAuto(_comPtr);
    }

    /// <summary>
    /// Draw indexed, instanced, GPU-generated primitives.
    /// </summary>
    /// <param name="bufferForArgs">A buffer containing the GPU generated primitives.</param>
    /// <param name="alignedByteOffsetForArgs">Offset to the start of the GPU generated primitives.</param>
    public void DrawIndexedInstancedIndirect(D3D11Buffer? bufferForArgs, uint alignedByteOffsetForArgs)
    {
        if (bufferForArgs is null)
        {
            throw new ArgumentNullException(nameof(bufferForArgs));
        }

        _comImpl->DrawIndexedInstancedIndirect(_comPtr, bufferForArgs.Handle, alignedByteOffsetForArgs);
    }

    /// <summary>
    /// Draw instanced, GPU-generated primitives.
    /// </summary>
    /// <param name="bufferForArgs">A buffer containing the GPU generated primitives.</param>
    /// <param name="alignedByteOffsetForArgs">Offset to the start of the GPU generated primitives.</param>
    public void DrawInstancedIndirect(D3D11Buffer? bufferForArgs, uint alignedByteOffsetForArgs)
    {
        if (bufferForArgs is null)
        {
            throw new ArgumentNullException(nameof(bufferForArgs));
        }

        _comImpl->DrawInstancedIndirect(_comPtr, bufferForArgs.Handle, alignedByteOffsetForArgs);
    }

    /// <summary>
    /// Execute a command list from a thread group.
    /// </summary>
    /// <param name="threadGroupCountX">The number of groups dispatched in the x direction.</param>
    /// <param name="threadGroupCountY">The number of groups dispatched in the y direction.</param>
    /// <param name="threadGroupCountZ">The number of groups dispatched in the z direction.</param>
    public void Dispatch(uint threadGroupCountX, uint threadGroupCountY, uint threadGroupCountZ)
    {
        _comImpl->Dispatch(_comPtr, threadGroupCountX, threadGroupCountY, threadGroupCountZ);
    }

    /// <summary>
    /// Execute a command list over one or more thread groups.
    /// </summary>
    /// <param name="bufferForArgs">A buffer, which must be loaded with data that matches the argument list.</param>
    /// <param name="alignedByteOffsetForArgs">A byte-aligned offset between the start of the buffer and the arguments.</param>
    public void DispatchIndirect(D3D11Buffer? bufferForArgs, uint alignedByteOffsetForArgs)
    {
        if (bufferForArgs is null)
        {
            throw new ArgumentNullException(nameof(bufferForArgs));
        }

        _comImpl->DispatchIndirect(_comPtr, bufferForArgs.Handle, alignedByteOffsetForArgs);
    }

    /// <summary>
    /// Set the rasterizer state for the rasterizer stage of the pipeline.
    /// </summary>
    /// <param name="rasterizerState">A rasterizer-state interface.</param>
    public void RasterizerStageSetState(D3D11RasterizerState? rasterizerState)
    {
        _comImpl->RasterizerStageSetState(_comPtr, rasterizerState is null ? 0 : rasterizerState.Handle);
    }

    /// <summary>
    /// Bind an array of viewports to the rasterizer stage of the pipeline.
    /// </summary>
    /// <param name="viewports">An array of <see cref="D3D11Viewport"/> structures to bind to the device.</param>
    public void RasterizerStageSetViewports(D3D11Viewport[]? viewports)
    {
        RasterizerStageSetViewports(viewports.AsSpan());
    }

    /// <summary>
    /// Bind an array of viewports to the rasterizer stage of the pipeline.
    /// </summary>
    /// <param name="viewports">An array of <see cref="D3D11Viewport"/> structures to bind to the device.</param>
    public void RasterizerStageSetViewports(ReadOnlySpan<D3D11Viewport> viewports)
    {
        if (viewports.Length == 0)
        {
            throw new ArgumentNullException(nameof(viewports));
        }

        int size = D3D11Viewport.NativeRequiredSize(viewports.Length);
        byte* ptr = stackalloc byte[size];
        D3D11Viewport.NativeWriteTo((nint)ptr, viewports);
        _comImpl->RasterizerStageSetViewports(_comPtr, (uint)viewports.Length, ptr);
    }

    /// <summary>
    /// Bind an array of viewports to the rasterizer stage of the pipeline.
    /// </summary>
    /// <param name="viewports">An array of <see cref="D3D11Viewport"/> structures to bind to the device.</param>
    public void RasterizerStageSetViewports(in D3D11Viewport viewports)
    {
        int size = D3D11Viewport.NativeRequiredSize();
        byte* ptr = stackalloc byte[size];
        D3D11Viewport.NativeWriteTo((nint)ptr, viewports);
        _comImpl->RasterizerStageSetViewports(_comPtr, 1, ptr);
    }

    /// <summary>
    /// Bind an array of scissor rectangles to the rasterizer stage.
    /// </summary>
    /// <param name="rects">An array of scissor rectangles.</param>
    public void RasterizerStageSetScissorRects(D3D11Rect[]? rects)
    {
        RasterizerStageSetScissorRects(rects.AsSpan());
    }

    /// <summary>
    /// Bind an array of scissor rectangles to the rasterizer stage.
    /// </summary>
    /// <param name="rects">An array of scissor rectangles.</param>
    public void RasterizerStageSetScissorRects(ReadOnlySpan<D3D11Rect> rects)
    {
        if (rects.Length == 0)
        {
            throw new ArgumentNullException(nameof(rects));
        }

        int size = D3D11Rect.NativeRequiredSize(rects.Length);
        byte* ptr = stackalloc byte[size];
        D3D11Rect.NativeWriteTo((nint)ptr, rects);
        _comImpl->RasterizerStageSetScissorRects(_comPtr, (uint)rects.Length, ptr);
    }

    /// <summary>
    /// Bind an array of scissor rectangles to the rasterizer stage.
    /// </summary>
    /// <param name="rects">An array of scissor rectangles.</param>
    public void RasterizerStageSetScissorRects(in D3D11Rect rects)
    {
        int size = D3D11Rect.NativeRequiredSize();
        byte* ptr = stackalloc byte[size];
        D3D11Rect.NativeWriteTo((nint)ptr, rects);
        _comImpl->RasterizerStageSetScissorRects(_comPtr, 1, ptr);
    }

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
    public void CopySubresourceRegion(
        D3D11Resource? destinationResource,
        uint destinationSubresource,
        uint destinationX,
        uint destinationY,
        uint destinationZ,
        D3D11Resource? sourceResource,
        uint sourceSubresource)
    {
        CopySubresourceRegion(
            destinationResource,
            destinationSubresource,
            destinationX,
            destinationY,
            destinationZ,
            sourceResource,
            sourceSubresource,
            null);
    }

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
    public void CopySubresourceRegion(
        D3D11Resource? destinationResource,
        uint destinationSubresource,
        uint destinationX,
        uint destinationY,
        uint destinationZ,
        D3D11Resource? sourceResource,
        uint sourceSubresource,
        D3D11Box? sourceBox)
    {
        if (destinationResource is null)
        {
            throw new ArgumentNullException(nameof(destinationResource));
        }

        if (sourceResource is null)
        {
            throw new ArgumentNullException(nameof(sourceResource));
        }

        if (sourceBox is null)
        {
            _comImpl->CopySubresourceRegion(
                _comPtr,
                destinationResource.Handle,
                destinationSubresource,
                destinationX,
                destinationY,
                destinationZ,
                sourceResource.Handle,
                sourceSubresource,
                null);
        }
        else
        {
            int size = D3D11Box.NativeRequiredSize();
            byte* ptr = stackalloc byte[size];
            D3D11Box.NativeWriteTo((nint)ptr, sourceBox.Value);

            _comImpl->CopySubresourceRegion(
                _comPtr,
                destinationResource.Handle,
                destinationSubresource,
                destinationX,
                destinationY,
                destinationZ,
                sourceResource.Handle,
                sourceSubresource,
                ptr);
        }
    }

    /// <summary>
    /// Copy the entire contents of the source resource to the destination resource using the GPU.
    /// </summary>
    /// <param name="destination">The destination resource.</param>
    /// <param name="source">The source resource.</param>
    public void CopyResource(D3D11Resource? destination, D3D11Resource? source)
    {
        if (destination is null)
        {
            throw new ArgumentNullException(nameof(destination));
        }

        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        _comImpl->CopyResource(_comPtr, destination.Handle, source.Handle);
    }

    /// <summary>
    /// The CPU copies data from memory to a subresource created in non-mappable memory.
    /// </summary>
    /// <typeparam name="T">The type of data.</typeparam>
    /// <param name="destinationResource">The destination resource.</param>
    /// <param name="destinationSubresource">A zero-based index, that identifies the destination subresource.</param>
    /// <param name="destinationBox">A box that defines the portion of the destination subresource to copy the resource data into. Coordinates are in bytes for buffers and in texels for textures.</param>
    /// <param name="sourceData">A pointer to the source data in memory.</param>
    /// <param name="sourceRowPitch">The size of one row of the source data.</param>
    /// <param name="sourceDepthPitch">The size of one depth slice of source data.</param>
    public void UpdateSubresource<T>(
        D3D11Resource? destinationResource,
        uint destinationSubresource,
        D3D11Box? destinationBox,
        in T sourceData,
        uint sourceRowPitch,
        uint sourceDepthPitch)
        where T : unmanaged
    {
        if (destinationResource is null)
        {
            throw new ArgumentNullException(nameof(destinationResource));
        }

        if (destinationBox is null)
        {
            fixed (void* sourceDataPtr = &sourceData)
            {
                _comImpl->UpdateSubresource(_comPtr, destinationResource.Handle, destinationSubresource, null, sourceDataPtr, sourceRowPitch, sourceDepthPitch);
            }
        }
        else
        {
            int size = D3D11Box.NativeRequiredSize();
            byte* ptr = stackalloc byte[size];
            D3D11Box.NativeWriteTo((nint)ptr, destinationBox.Value);

            fixed (void* sourceDataPtr = &sourceData)
            {
                _comImpl->UpdateSubresource(_comPtr, destinationResource.Handle, destinationSubresource, ptr, sourceDataPtr, sourceRowPitch, sourceDepthPitch);
            }
        }
    }

    /// <summary>
    /// The CPU copies data from memory to a subresource created in non-mappable memory.
    /// </summary>
    /// <typeparam name="T">The type of data.</typeparam>
    /// <param name="destinationResource">The destination resource.</param>
    /// <param name="destinationSubresource">A zero-based index, that identifies the destination subresource.</param>
    /// <param name="destinationBox">A box that defines the portion of the destination subresource to copy the resource data into. Coordinates are in bytes for buffers and in texels for textures.</param>
    /// <param name="sourceData">A pointer to the source data in memory.</param>
    /// <param name="sourceRowPitch">The size of one row of the source data.</param>
    /// <param name="sourceDepthPitch">The size of one depth slice of source data.</param>
    public void UpdateSubresource<T>(
        D3D11Resource? destinationResource,
        uint destinationSubresource,
        D3D11Box? destinationBox,
        T[] sourceData,
        uint sourceRowPitch,
        uint sourceDepthPitch)
        where T : unmanaged
    {
        UpdateSubresource<T>(destinationResource, destinationSubresource, destinationBox, sourceData.AsSpan(), sourceRowPitch, sourceDepthPitch);
    }

    /// <summary>
    /// The CPU copies data from memory to a subresource created in non-mappable memory.
    /// </summary>
    /// <typeparam name="T">The type of data.</typeparam>
    /// <param name="destinationResource">The destination resource.</param>
    /// <param name="destinationSubresource">A zero-based index, that identifies the destination subresource.</param>
    /// <param name="destinationBox">A box that defines the portion of the destination subresource to copy the resource data into. Coordinates are in bytes for buffers and in texels for textures.</param>
    /// <param name="sourceData">A pointer to the source data in memory.</param>
    /// <param name="sourceRowPitch">The size of one row of the source data.</param>
    /// <param name="sourceDepthPitch">The size of one depth slice of source data.</param>
    public void UpdateSubresource<T>(
        D3D11Resource? destinationResource,
        uint destinationSubresource,
        D3D11Box? destinationBox,
        ReadOnlySpan<T> sourceData,
        uint sourceRowPitch,
        uint sourceDepthPitch)
        where T : unmanaged
    {
        if (destinationResource is null)
        {
            throw new ArgumentNullException(nameof(destinationResource));
        }

        if (sourceData.Length == 0)
        {
            throw new ArgumentNullException(nameof(sourceData));
        }

        if (destinationBox is null)
        {
            fixed (void* sourceDataPtr = sourceData)
            {
                _comImpl->UpdateSubresource(_comPtr, destinationResource.Handle, destinationSubresource, null, sourceDataPtr, sourceRowPitch, sourceDepthPitch);
            }
        }
        else
        {
            int size = D3D11Box.NativeRequiredSize();
            byte* ptr = stackalloc byte[size];
            D3D11Box.NativeWriteTo((nint)ptr, destinationBox.Value);

            fixed (void* sourceDataPtr = sourceData)
            {
                _comImpl->UpdateSubresource(_comPtr, destinationResource.Handle, destinationSubresource, ptr, sourceDataPtr, sourceRowPitch, sourceDepthPitch);
            }
        }
    }

    /// <summary>
    /// Copies data from a buffer holding variable length data.
    /// </summary>
    /// <param name="destinationBuffer">The destination buffer.</param>
    /// <param name="destinationAlignedByteOffset">Offset from the start of the buffer to write 32-bit UINT structure (vertex) count.</param>
    /// <param name="sourceView">A structured buffer resource.</param>
    public void CopyStructureCount(D3D11Buffer? destinationBuffer, uint destinationAlignedByteOffset, D3D11UnorderedAccessView? sourceView)
    {
        if (destinationBuffer is null)
        {
            throw new ArgumentNullException(nameof(destinationBuffer));
        }

        if (sourceView is null)
        {
            throw new ArgumentNullException(nameof(sourceView));
        }

        _comImpl->CopyStructureCount(_comPtr, destinationBuffer.Handle, destinationAlignedByteOffset, sourceView.Handle);
    }

    /// <summary>
    /// Set all the elements in a render target to one value.
    /// </summary>
    /// <param name="renderTargetView">The render target.</param>
    /// <param name="colorRgba">A 4-component array that represents the color to fill the render target with.</param>
    public void ClearRenderTargetView(D3D11RenderTargetView? renderTargetView, float[]? colorRgba)
    {
        ClearRenderTargetView(renderTargetView, colorRgba.AsSpan());
    }

    /// <summary>
    /// Set all the elements in a render target to one value.
    /// </summary>
    /// <param name="renderTargetView">The render target.</param>
    /// <param name="colorRgbaR">A 4-component array that represents the color to fill the render target with.</param>
    /// <param name="colorRgbaG">A 4-component array that represents the color to fill the render target with.</param>
    /// <param name="colorRgbaB">A 4-component array that represents the color to fill the render target with.</param>
    /// <param name="colorRgbaA">A 4-component array that represents the color to fill the render target with.</param>
    /// <exception cref="ArgumentNullException"></exception>
    public void ClearRenderTargetView(D3D11RenderTargetView? renderTargetView, float colorRgbaR, float colorRgbaG, float colorRgbaB, float colorRgbaA)
    {
        if (renderTargetView is null)
        {
            throw new ArgumentNullException(nameof(renderTargetView));
        }

        float* colorRgba = stackalloc float[4];
        colorRgba[0] = colorRgbaR;
        colorRgba[1] = colorRgbaG;
        colorRgba[2] = colorRgbaB;
        colorRgba[3] = colorRgbaA;

        _comImpl->ClearRenderTargetView(_comPtr, renderTargetView.Handle, colorRgba);
    }

    /// <summary>
    /// Set all the elements in a render target to one value.
    /// </summary>
    /// <param name="renderTargetView">The render target.</param>
    /// <param name="colorRgba">A 4-component array that represents the color to fill the render target with.</param>
    public void ClearRenderTargetView(D3D11RenderTargetView? renderTargetView, ReadOnlySpan<float> colorRgba)
    {
        if (renderTargetView is null)
        {
            throw new ArgumentNullException(nameof(renderTargetView));
        }

        if (colorRgba.Length != 0 && colorRgba.Length != 4)
        {
            throw new ArgumentOutOfRangeException(nameof(colorRgba));
        }

        fixed (float* colorRgbaPtr = colorRgba)
        {
            _comImpl->ClearRenderTargetView(_comPtr, renderTargetView.Handle, colorRgbaPtr);
        }
    }

    /// <summary>
    /// Clears an unordered access resource with bit-precise values.
    /// </summary>
    /// <param name="unorderedAccessView">The unordered access resource to clear.</param>
    /// <param name="values">Values to copy to corresponding channels.</param>
    public void ClearUnorderedAccessViewUInt(D3D11UnorderedAccessView? unorderedAccessView, uint[]? values)
    {
        ClearUnorderedAccessViewUInt(unorderedAccessView, values.AsSpan());
    }

    /// <summary>
    /// Clears an unordered access resource with bit-precise values.
    /// </summary>
    /// <param name="unorderedAccessView">The unordered access resource to clear.</param>
    /// <param name="valuesX">Values to copy to corresponding channels.</param>
    /// <param name="valuesY">Values to copy to corresponding channels.</param>
    /// <param name="valuesZ">Values to copy to corresponding channels.</param>
    /// <param name="valuesW">Values to copy to corresponding channels.</param>
    public void ClearUnorderedAccessViewUInt(D3D11UnorderedAccessView? unorderedAccessView, uint valuesX, uint valuesY, uint valuesZ, uint valuesW)
    {
        if (unorderedAccessView is null)
        {
            throw new ArgumentNullException(nameof(unorderedAccessView));
        }

        uint* valuesPtr = stackalloc uint[4];
        valuesPtr[0] = valuesX;
        valuesPtr[1] = valuesY;
        valuesPtr[2] = valuesZ;
        valuesPtr[3] = valuesW;

        _comImpl->ClearUnorderedAccessViewUInt(_comPtr, unorderedAccessView.Handle, valuesPtr);
    }

    /// <summary>
    /// Clears an unordered access resource with bit-precise values.
    /// </summary>
    /// <param name="unorderedAccessView">The unordered access resource to clear.</param>
    /// <param name="values">Values to copy to corresponding channels.</param>
    public void ClearUnorderedAccessViewUInt(D3D11UnorderedAccessView? unorderedAccessView, ReadOnlySpan<uint> values)
    {
        if (unorderedAccessView is null)
        {
            throw new ArgumentNullException(nameof(unorderedAccessView));
        }

        if (values.Length != 0 && values.Length != 4)
        {
            throw new ArgumentOutOfRangeException(nameof(values));
        }

        fixed (uint* valuesPtr = values)
        {
            _comImpl->ClearUnorderedAccessViewUInt(_comPtr, unorderedAccessView.Handle, valuesPtr);
        }
    }

    /// <summary>
    /// Clears an unordered access resource with a float value.
    /// </summary>
    /// <param name="unorderedAccessView">The unordered access resource to clear.</param>
    /// <param name="values">Values to copy to corresponding channels.</param>
    public void ClearUnorderedAccessViewFloat(D3D11UnorderedAccessView? unorderedAccessView, float[]? values)
    {
        ClearUnorderedAccessViewFloat(unorderedAccessView, values.AsSpan());
    }

    /// <summary>
    /// Clears an unordered access resource with a float value.
    /// </summary>
    /// <param name="unorderedAccessView">The unordered access resource to clear.</param>
    /// <param name="values">Values to copy to corresponding channels.</param>
    public void ClearUnorderedAccessViewFloat(D3D11UnorderedAccessView? unorderedAccessView, ReadOnlySpan<float> values)
    {
        if (unorderedAccessView is null)
        {
            throw new ArgumentNullException(nameof(unorderedAccessView));
        }

        if (values.Length != 0 && values.Length != 4)
        {
            throw new ArgumentOutOfRangeException(nameof(values));
        }

        fixed (float* valuesPtr = values)
        {
            _comImpl->ClearUnorderedAccessViewFloat(_comPtr, unorderedAccessView.Handle, valuesPtr);
        }
    }

    /// <summary>
    /// Clears an unordered access resource with a float value.
    /// </summary>
    /// <param name="unorderedAccessView">The unordered access resource to clear.</param>
    /// <param name="valuesX">Values to copy to corresponding channels.</param>
    /// <param name="valuesY">Values to copy to corresponding channels.</param>
    /// <param name="valuesZ">Values to copy to corresponding channels.</param>
    /// <param name="valuesW">Values to copy to corresponding channels.</param>
    public void ClearUnorderedAccessViewFloat(D3D11UnorderedAccessView? unorderedAccessView, float valuesX, float valuesY, float valuesZ, float valuesW)
    {
        if (unorderedAccessView is null)
        {
            throw new ArgumentNullException(nameof(unorderedAccessView));
        }

        float* valuesPtr = stackalloc float[4];
        valuesPtr[0] = valuesX;
        valuesPtr[1] = valuesY;
        valuesPtr[2] = valuesZ;
        valuesPtr[3] = valuesW;

        _comImpl->ClearUnorderedAccessViewFloat(_comPtr, unorderedAccessView.Handle, valuesPtr);
    }

    /// <summary>
    /// Clears the depth-stencil resource.
    /// </summary>
    /// <param name="depthStencilView">The depth stencil to be cleared.</param>
    /// <param name="clearOptions">Identify the type of data to clear.</param>
    /// <param name="depth">Clear the depth buffer with this value. This value will be clamped between 0 and 1.</param>
    /// <param name="stencil">Clear the stencil buffer with this value.</param>
    public void ClearDepthStencilView(D3D11DepthStencilView? depthStencilView, D3D11ClearOptions clearOptions, float depth, byte stencil)
    {
        if (depthStencilView is null)
        {
            throw new ArgumentNullException(nameof(depthStencilView));
        }

        _comImpl->ClearDepthStencilView(_comPtr, depthStencilView.Handle, clearOptions, depth, stencil);
    }

    /// <summary>
    /// Generates mipmaps for the given shader resource.
    /// </summary>
    /// <param name="shaderResourceView">The shader resource.</param>
    public void GenerateMips(D3D11ShaderResourceView? shaderResourceView)
    {
        if (shaderResourceView is null)
        {
            throw new ArgumentNullException(nameof(shaderResourceView));
        }

        _comImpl->GenerateMips(_comPtr, shaderResourceView.Handle);
    }

    /// <summary>
    /// Sets the minimum level-of-detail (LOD) for a resource.
    /// </summary>
    /// <param name="resource">The resource.</param>
    /// <param name="minLod">The level-of-detail, which ranges between 0 and the maximum number of mipmap levels of the resource.</param>
    public void SetResourceMinLod(D3D11Resource? resource, float minLod)
    {
        if (resource is null)
        {
            throw new ArgumentNullException(nameof(resource));
        }

        _comImpl->SetResourceMinLod(_comPtr, resource.Handle, minLod);
    }

    /// <summary>
    /// Gets the minimum level-of-detail (LOD).
    /// </summary>
    /// <param name="resource">The resource.</param>
    /// <returns>The minimum LOD.</returns>
    public float GetResourceMinLod(D3D11Resource? resource)
    {
        if (resource is null)
        {
            throw new ArgumentNullException(nameof(resource));
        }

        return _comImpl->GetResourceMinLod(_comPtr, resource.Handle);
    }

    /// <summary>
    /// Copy a multisampled resource into a non-multisampled resource.
    /// </summary>
    /// <param name="destinationResource">Destination resource.</param>
    /// <param name="destinationSubresource">A zero-based index, that identifies the destination subresource.</param>
    /// <param name="sourceResource">Source resource.</param>
    /// <param name="sourceSubresource">The source subresource of the source resource.</param>
    /// <param name="format">Indicates how the multisampled resource will be resolved to a single-sampled resource.</param>
    public void ResolveSubresource(
        D3D11Resource? destinationResource,
        uint destinationSubresource,
        D3D11Resource? sourceResource,
        uint sourceSubresource,
        DxgiFormat format)
    {
        if (destinationResource is null)
        {
            throw new ArgumentNullException(nameof(destinationResource));
        }

        if (sourceResource is null)
        {
            throw new ArgumentNullException(nameof(sourceResource));
        }

        _comImpl->ResolveSubresource(_comPtr, destinationResource.Handle, destinationSubresource, sourceResource.Handle, sourceSubresource, format);
    }

    /// <summary>
    /// Queues commands from a command list onto a device.
    /// </summary>
    /// <param name="commandList">A command list.</param>
    /// <param name="restoreContextState">A value indicating whether the target context state is saved prior to and restored after the execution of a command list.</param>
    public void ExecuteCommandList(D3D11CommandList? commandList, bool restoreContextState)
    {
        if (commandList is null)
        {
            throw new ArgumentNullException(nameof(commandList));
        }

        _comImpl->ExecuteCommandList(_comPtr, commandList.Handle, restoreContextState ? 1 : 0);
    }

    /// <summary>
    /// Bind an array of shader resources to the hull shader stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting shader resources to.</param>
    /// <param name="shaderResourceViews">Array of shader resource view interfaces to set to the device.</param>
    public void HullShaderSetShaderResources(uint startSlot, D3D11ShaderResourceView?[]? shaderResourceViews)
    {
        HullShaderSetShaderResources(startSlot, shaderResourceViews.AsSpan());
    }

    /// <summary>
    /// Bind an array of shader resources to the hull shader stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting shader resources to.</param>
    /// <param name="shaderResourceViews">Array of shader resource view interfaces to set to the device.</param>
    public void HullShaderSetShaderResources(uint startSlot, ReadOnlySpan<D3D11ShaderResourceView?> shaderResourceViews)
    {
        if (shaderResourceViews.Length == 0)
        {
            throw new ArgumentNullException(nameof(shaderResourceViews));
        }

        nint* views = stackalloc nint[shaderResourceViews.Length];
        for (int i = 0; i < shaderResourceViews.Length; i++)
        {
            D3D11ShaderResourceView? current = shaderResourceViews[i];
            views[i] = current is null ? 0 : current.Handle;
        }

        _comImpl->HullShaderSetShaderResources(_comPtr, startSlot, (uint)shaderResourceViews.Length, views);
    }

    /// <summary>
    /// Bind an array of shader resources to the hull shader stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting shader resources to.</param>
    /// <param name="shaderResourceViews">Array of shader resource view interfaces to set to the device.</param>
    public void HullShaderSetShaderResources(uint startSlot, D3D11ShaderResourceView? shaderResourceViews)
    {
        nint views = shaderResourceViews is null ? 0 : shaderResourceViews.Handle;
        _comImpl->HullShaderSetShaderResources(_comPtr, startSlot, 1, &views);
    }

    /// <summary>
    /// Set a hull shader to the device.
    /// </summary>
    /// <param name="hullShader">A hull shader.</param>
    public void HullShaderSetShader(D3D11HullShader? hullShader)
    {
        HullShaderSetShader(hullShader, []);
    }

    /// <summary>
    /// Set a hull shader to the device.
    /// </summary>
    /// <param name="hullShader">A hull shader.</param>
    /// <param name="classInstances">An array of class-instance interfaces.</param>
    public void HullShaderSetShader(D3D11HullShader? hullShader, D3D11ClassInstance?[]? classInstances)
    {
        HullShaderSetShader(hullShader, classInstances.AsSpan());
    }

    /// <summary>
    /// Set a hull shader to the device.
    /// </summary>
    /// <param name="hullShader">A hull shader.</param>
    /// <param name="classInstances">An array of class-instance interfaces.</param>
    public void HullShaderSetShader(D3D11HullShader? hullShader, ReadOnlySpan<D3D11ClassInstance?> classInstances)
    {
        if (classInstances.Length == 0)
        {
            nint shader = hullShader is null ? 0 : hullShader.Handle;
            _comImpl->HullShaderSetShader(_comPtr, shader, null, 0);
        }
        else
        {
            if (hullShader is null)
            {
                throw new ArgumentNullException(nameof(hullShader));
            }

            nint shader = hullShader.Handle;
            nint* ptr = stackalloc nint[classInstances.Length];
            for (int i = 0; i < classInstances.Length; i++)
            {
                D3D11ClassInstance? current = classInstances[i];
                ptr[i] = current is null ? 0 : current.Handle;
            }

            _comImpl->HullShaderSetShader(_comPtr, shader, ptr, (uint)classInstances.Length);
        }
    }

    /// <summary>
    /// Set an array of sampler states to the hull shader stage.
    /// </summary>
    /// <param name="startSlot">Index into the zero-based array to begin setting samplers to.</param>
    /// <param name="samplers">An array of sampler-state interfaces.</param>
    public void HullShaderSetSamplers(uint startSlot, D3D11SamplerState?[]? samplers)
    {
        HullShaderSetSamplers(startSlot, samplers.AsSpan());
    }

    /// <summary>
    /// Set an array of sampler states to the hull shader stage.
    /// </summary>
    /// <param name="startSlot">Index into the zero-based array to begin setting samplers to.</param>
    /// <param name="samplers">An array of sampler-state interfaces.</param>
    public void HullShaderSetSamplers(uint startSlot, ReadOnlySpan<D3D11SamplerState?> samplers)
    {
        if (samplers.Length == 0)
        {
            throw new ArgumentNullException(nameof(samplers));
        }

        nint* samplersPtr = stackalloc nint[samplers.Length];
        for (int i = 0; i < samplers.Length; i++)
        {
            D3D11SamplerState? current = samplers[i];
            samplersPtr[i] = current is null ? 0 : current.Handle;
        }

        _comImpl->HullShaderSetSamplers(_comPtr, startSlot, (uint)samplers.Length, samplersPtr);
    }

    /// <summary>
    /// Set an array of sampler states to the hull shader stage.
    /// </summary>
    /// <param name="startSlot">Index into the zero-based array to begin setting samplers to.</param>
    /// <param name="samplers">An array of sampler-state interfaces.</param>
    public void HullShaderSetSamplers(uint startSlot, D3D11SamplerState? samplers)
    {
        nint samplersPtr = samplers is null ? 0 : samplers.Handle;
        _comImpl->HullShaderSetSamplers(_comPtr, startSlot, 1, &samplersPtr);
    }

    /// <summary>
    /// Set the constant buffers used by the hull shader stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting constant buffers to.</param>
    /// <param name="constantBuffers">Array of constant buffers being given to the device.</param>
    public void HullShaderSetConstantBuffers(uint startSlot, D3D11Buffer?[]? constantBuffers)
    {
        HullShaderSetConstantBuffers(startSlot, constantBuffers.AsSpan());
    }

    /// <summary>
    /// Set the constant buffers used by the hull shader stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting constant buffers to.</param>
    /// <param name="constantBuffers">Array of constant buffers being given to the device.</param>
    public void HullShaderSetConstantBuffers(uint startSlot, ReadOnlySpan<D3D11Buffer?> constantBuffers)
    {
        if (constantBuffers.Length == 0)
        {
            throw new ArgumentNullException(nameof(constantBuffers));
        }

        nint* buffers = stackalloc nint[constantBuffers.Length];
        for (int i = 0; i < constantBuffers.Length; i++)
        {
            D3D11Buffer? current = constantBuffers[i];
            buffers[i] = current is null ? 0 : current.Handle;
        }

        _comImpl->HullShaderSetConstantBuffers(_comPtr, startSlot, (uint)constantBuffers.Length, buffers);
    }

    /// <summary>
    /// Set the constant buffers used by the hull shader stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting constant buffers to.</param>
    /// <param name="constantBuffers">Array of constant buffers being given to the device.</param>
    public void HullShaderSetConstantBuffers(uint startSlot, D3D11Buffer? constantBuffers)
    {
        nint buffers = constantBuffers is null ? 0 : constantBuffers.Handle;
        _comImpl->HullShaderSetConstantBuffers(_comPtr, startSlot, 1, &buffers);
    }

    /// <summary>
    /// Bind an array of shader resources to the domain shader stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting shader resources to.</param>
    /// <param name="shaderResourceViews">Array of shader resource view interfaces to set to the device.</param>
    public void DomainShaderSetShaderResources(uint startSlot, D3D11ShaderResourceView?[]? shaderResourceViews)
    {
        DomainShaderSetShaderResources(startSlot, shaderResourceViews.AsSpan());
    }

    /// <summary>
    /// Bind an array of shader resources to the domain shader stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting shader resources to.</param>
    /// <param name="shaderResourceViews">Array of shader resource view interfaces to set to the device.</param>
    public void DomainShaderSetShaderResources(uint startSlot, ReadOnlySpan<D3D11ShaderResourceView?> shaderResourceViews)
    {
        if (shaderResourceViews.Length == 0)
        {
            throw new ArgumentNullException(nameof(shaderResourceViews));
        }

        nint* views = stackalloc nint[shaderResourceViews.Length];
        for (int i = 0; i < shaderResourceViews.Length; i++)
        {
            D3D11ShaderResourceView? current = shaderResourceViews[i];
            views[i] = current is null ? 0 : current.Handle;
        }

        _comImpl->DomainShaderSetShaderResources(_comPtr, startSlot, (uint)shaderResourceViews.Length, views);
    }

    /// <summary>
    /// Bind an array of shader resources to the domain shader stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting shader resources to.</param>
    /// <param name="shaderResourceViews">Array of shader resource view interfaces to set to the device.</param>
    public void DomainShaderSetShaderResources(uint startSlot, D3D11ShaderResourceView? shaderResourceViews)
    {
        nint views = shaderResourceViews is null ? 0 : shaderResourceViews.Handle;
        _comImpl->DomainShaderSetShaderResources(_comPtr, startSlot, 1, &views);
    }

    /// <summary>
    /// Set a domain shader to the device.
    /// </summary>
    /// <param name="domainShader">A domain shader.</param>
    public void DomainShaderSetShader(D3D11DomainShader? domainShader)
    {
        DomainShaderSetShader(domainShader, []);
    }

    /// <summary>
    /// Set a domain shader to the device.
    /// </summary>
    /// <param name="domainShader">A domain shader.</param>
    /// <param name="classInstances">An array of class-instance interfaces.</param>
    public void DomainShaderSetShader(D3D11DomainShader? domainShader, D3D11ClassInstance?[]? classInstances)
    {
        DomainShaderSetShader(domainShader, classInstances.AsSpan());
    }

    /// <summary>
    /// Set a domain shader to the device.
    /// </summary>
    /// <param name="domainShader">A domain shader.</param>
    /// <param name="classInstances">An array of class-instance interfaces.</param>
    public void DomainShaderSetShader(D3D11DomainShader? domainShader, ReadOnlySpan<D3D11ClassInstance?> classInstances)
    {
        if (classInstances.Length == 0)
        {
            nint shader = domainShader is null ? 0 : domainShader.Handle;
            _comImpl->DomainShaderSetShader(_comPtr, shader, null, 0);
        }
        else
        {
            if (domainShader is null)
            {
                throw new ArgumentNullException(nameof(domainShader));
            }

            nint shader = domainShader.Handle;
            nint* ptr = stackalloc nint[classInstances.Length];
            for (int i = 0; i < classInstances.Length; i++)
            {
                D3D11ClassInstance? current = classInstances[i];
                ptr[i] = current is null ? 0 : current.Handle;
            }

            _comImpl->DomainShaderSetShader(_comPtr, shader, ptr, (uint)classInstances.Length);
        }
    }

    /// <summary>
    /// Set an array of sampler states to the domain shader stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting samplers to.</param>
    /// <param name="samplers">An array of sampler-state interfaces.</param>
    public void DomainShaderSetSamplers(uint startSlot, D3D11SamplerState?[]? samplers)
    {
        DomainShaderSetSamplers(startSlot, samplers.AsSpan());
    }

    /// <summary>
    /// Set an array of sampler states to the domain shader stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting samplers to.</param>
    /// <param name="samplers">An array of sampler-state interfaces.</param>
    public void DomainShaderSetSamplers(uint startSlot, ReadOnlySpan<D3D11SamplerState?> samplers)
    {
        if (samplers.Length == 0)
        {
            throw new ArgumentNullException(nameof(samplers));
        }

        nint* samplersPtr = stackalloc nint[samplers.Length];
        for (int i = 0; i < samplers.Length; i++)
        {
            D3D11SamplerState? current = samplers[i];
            samplersPtr[i] = current is null ? 0 : current.Handle;
        }

        _comImpl->DomainShaderSetSamplers(_comPtr, startSlot, (uint)samplers.Length, samplersPtr);
    }

    /// <summary>
    /// Set an array of sampler states to the domain shader stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting samplers to.</param>
    /// <param name="samplers">An array of sampler-state interfaces.</param>
    public void DomainShaderSetSamplers(uint startSlot, D3D11SamplerState? samplers)
    {
        nint samplersPtr = samplers is null ? 0 : samplers.Handle;
        _comImpl->DomainShaderSetSamplers(_comPtr, startSlot, 1, &samplersPtr);
    }

    /// <summary>
    /// Sets the constant buffers used by the domain shader stage.
    /// </summary>
    /// <param name="startSlot">Index into the zero-based array to begin setting constant buffers to.</param>
    /// <param name="constantBuffers">Array of constant buffers being given to the device.</param>
    public void DomainShaderSetConstantBuffers(uint startSlot, D3D11Buffer?[]? constantBuffers)
    {
        DomainShaderSetConstantBuffers(startSlot, constantBuffers.AsSpan());
    }

    /// <summary>
    /// Sets the constant buffers used by the domain shader stage.
    /// </summary>
    /// <param name="startSlot">Index into the zero-based array to begin setting constant buffers to.</param>
    /// <param name="constantBuffers">Array of constant buffers being given to the device.</param>
    public void DomainShaderSetConstantBuffers(uint startSlot, ReadOnlySpan<D3D11Buffer?> constantBuffers)
    {
        if (constantBuffers.Length == 0)
        {
            throw new ArgumentNullException(nameof(constantBuffers));
        }

        nint* buffers = stackalloc nint[constantBuffers.Length];
        for (int i = 0; i < constantBuffers.Length; i++)
        {
            D3D11Buffer? current = constantBuffers[i];
            buffers[i] = current is null ? 0 : current.Handle;
        }

        _comImpl->DomainShaderSetConstantBuffers(_comPtr, startSlot, (uint)constantBuffers.Length, buffers);
    }

    /// <summary>
    /// Sets the constant buffers used by the domain shader stage.
    /// </summary>
    /// <param name="startSlot">Index into the zero-based array to begin setting constant buffers to.</param>
    /// <param name="constantBuffers">Array of constant buffers being given to the device.</param>
    public void DomainShaderSetConstantBuffers(uint startSlot, D3D11Buffer? constantBuffers)
    {
        nint buffers = constantBuffers is null ? 0 : constantBuffers.Handle;
        _comImpl->DomainShaderSetConstantBuffers(_comPtr, startSlot, 1, &buffers);
    }

    /// <summary>
    /// Bind an array of shader resources to the compute shader stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting shader resources to.</param>
    /// <param name="shaderResourceViews">Array of shader resource view interfaces to set to the device.</param>
    public void ComputeShaderSetShaderResources(uint startSlot, D3D11ShaderResourceView?[]? shaderResourceViews)
    {
        ComputeShaderSetShaderResources(startSlot, shaderResourceViews.AsSpan());
    }

    /// <summary>
    /// Bind an array of shader resources to the compute shader stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting shader resources to.</param>
    /// <param name="shaderResourceViews">Array of shader resource view interfaces to set to the device.</param>
    public void ComputeShaderSetShaderResources(uint startSlot, ReadOnlySpan<D3D11ShaderResourceView?> shaderResourceViews)
    {
        if (shaderResourceViews.Length == 0)
        {
            throw new ArgumentNullException(nameof(shaderResourceViews));
        }

        nint* views = stackalloc nint[shaderResourceViews.Length];
        for (int i = 0; i < shaderResourceViews.Length; i++)
        {
            D3D11ShaderResourceView? current = shaderResourceViews[i];
            views[i] = current is null ? 0 : current.Handle;
        }

        _comImpl->ComputeShaderSetShaderResources(_comPtr, startSlot, (uint)shaderResourceViews.Length, views);
    }

    /// <summary>
    /// Bind an array of shader resources to the compute shader stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting shader resources to.</param>
    /// <param name="shaderResourceViews">Array of shader resource view interfaces to set to the device.</param>
    public void ComputeShaderSetShaderResources(uint startSlot, D3D11ShaderResourceView? shaderResourceViews)
    {
        nint views = shaderResourceViews is null ? 0 : shaderResourceViews.Handle;
        _comImpl->ComputeShaderSetShaderResources(_comPtr, startSlot, 1, &views);
    }

    /// <summary>
    /// Sets an array of views for an unordered resource.
    /// </summary>
    /// <param name="startSlot">Index of the first element in the zero-based array to begin setting.</param>
    /// <param name="unorderedAccessViews">An array of unordered access views to be set.</param>
    /// <param name="uavInitialCounts">An array of append and consume buffer offsets. A value of <value>-1</value> indicates to keep the current offset.</param>
    public void ComputeShaderSetUnorderedAccessViews(uint startSlot, D3D11UnorderedAccessView?[]? unorderedAccessViews, uint[]? uavInitialCounts)
    {
        ComputeShaderSetUnorderedAccessViews(startSlot, unorderedAccessViews.AsSpan(), uavInitialCounts.AsSpan());
    }

    /// <summary>
    /// Sets an array of views for an unordered resource.
    /// </summary>
    /// <param name="startSlot">Index of the first element in the zero-based array to begin setting.</param>
    /// <param name="unorderedAccessViews">An array of unordered access views to be set.</param>
    /// <param name="uavInitialCounts">An array of append and consume buffer offsets. A value of <value>-1</value> indicates to keep the current offset.</param>
    public void ComputeShaderSetUnorderedAccessViews(uint startSlot, ReadOnlySpan<D3D11UnorderedAccessView?> unorderedAccessViews, ReadOnlySpan<uint> uavInitialCounts)
    {
        if (unorderedAccessViews.Length == 0)
        {
            throw new ArgumentNullException(nameof(unorderedAccessViews));
        }

        if (uavInitialCounts.Length == 0)
        {
            throw new ArgumentNullException(nameof(uavInitialCounts));
        }

        if (uavInitialCounts.Length != unorderedAccessViews.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(uavInitialCounts));
        }

        nint* views = stackalloc nint[unorderedAccessViews.Length];
        for (int i = 0; i < unorderedAccessViews.Length; i++)
        {
            D3D11UnorderedAccessView? current = unorderedAccessViews[i];
            views[i] = current is null ? 0 : current.Handle;
        }

        fixed (uint* uavInitialCountsPtr = uavInitialCounts)
        {
            _comImpl->ComputeShaderSetUnorderedAccessViews(_comPtr, startSlot, (uint)unorderedAccessViews.Length, views, uavInitialCountsPtr);
        }
    }

    /// <summary>
    /// Sets an array of views for an unordered resource.
    /// </summary>
    /// <param name="startSlot">Index of the first element in the zero-based array to begin setting.</param>
    /// <param name="unorderedAccessViews">An array of unordered access views to be set.</param>
    /// <param name="uavInitialCounts">An array of append and consume buffer offsets. A value of <value>-1</value> indicates to keep the current offset.</param>
    public void ComputeShaderSetUnorderedAccessViews(uint startSlot, D3D11UnorderedAccessView? unorderedAccessViews, uint uavInitialCounts)
    {
        nint views = unorderedAccessViews is null ? 0 : unorderedAccessViews.Handle;
        _comImpl->ComputeShaderSetUnorderedAccessViews(_comPtr, startSlot, 1, &views, &uavInitialCounts);
    }

    /// <summary>
    /// Set a compute shader to the device.
    /// </summary>
    /// <param name="computeShader">A compute shader.</param>
    public void ComputeShaderSetShader(D3D11ComputeShader? computeShader)
    {
        ComputeShaderSetShader(computeShader, []);
    }

    /// <summary>
    /// Set a compute shader to the device.
    /// </summary>
    /// <param name="computeShader">A compute shader.</param>
    /// <param name="classInstances">An array of class-instance interfaces.</param>
    public void ComputeShaderSetShader(D3D11ComputeShader? computeShader, D3D11ClassInstance?[]? classInstances)
    {
        ComputeShaderSetShader(computeShader, classInstances.AsSpan());
    }

    /// <summary>
    /// Set a compute shader to the device.
    /// </summary>
    /// <param name="computeShader">A compute shader.</param>
    /// <param name="classInstances">An array of class-instance interfaces.</param>
    public void ComputeShaderSetShader(D3D11ComputeShader? computeShader, ReadOnlySpan<D3D11ClassInstance?> classInstances)
    {
        if (classInstances.Length == 0)
        {
            nint shader = computeShader is null ? 0 : computeShader.Handle;
            _comImpl->ComputeShaderSetShader(_comPtr, shader, null, 0);
        }
        else
        {
            if (computeShader is null)
            {
                throw new ArgumentNullException(nameof(computeShader));
            }

            nint shader = computeShader.Handle;
            nint* ptr = stackalloc nint[classInstances.Length];
            for (int i = 0; i < classInstances.Length; i++)
            {
                D3D11ClassInstance? current = classInstances[i];
                ptr[i] = current is null ? 0 : current.Handle;
            }

            _comImpl->ComputeShaderSetShader(_comPtr, shader, ptr, (uint)classInstances.Length);
        }
    }

    /// <summary>
    /// Set an array of sampler states to the compute shader stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting samplers to.</param>
    /// <param name="samplers">An array of sampler-state interfaces.</param>
    public void ComputeShaderSetSamplers(uint startSlot, D3D11SamplerState?[]? samplers)
    {
        ComputeShaderSetSamplers(startSlot, samplers.AsSpan());
    }

    /// <summary>
    /// Set an array of sampler states to the compute shader stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting samplers to.</param>
    /// <param name="samplers">An array of sampler-state interfaces.</param>
    public void ComputeShaderSetSamplers(uint startSlot, ReadOnlySpan<D3D11SamplerState?> samplers)
    {
        if (samplers.Length == 0)
        {
            throw new ArgumentNullException(nameof(samplers));
        }

        nint* samplersPtr = stackalloc nint[samplers.Length];
        for (int i = 0; i < samplers.Length; i++)
        {
            D3D11SamplerState? current = samplers[i];
            samplersPtr[i] = current is null ? 0 : current.Handle;
        }

        _comImpl->ComputeShaderSetSamplers(_comPtr, startSlot, (uint)samplers.Length, samplersPtr);
    }

    /// <summary>
    /// Set an array of sampler states to the compute shader stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin setting samplers to.</param>
    /// <param name="samplers">An array of sampler-state interfaces.</param>
    public void ComputeShaderSetSamplers(uint startSlot, D3D11SamplerState? samplers)
    {
        nint samplersPtr = samplers is null ? 0 : samplers.Handle;
        _comImpl->ComputeShaderSetSamplers(_comPtr, startSlot, 1, &samplersPtr);
    }

    /// <summary>
    /// Sets the constant buffers used by the compute shader stage.
    /// </summary>
    /// <param name="startSlot">Index into the zero-based array to begin setting constant buffers to.</param>
    /// <param name="constantBuffers">Array of constant buffers.</param>
    public void ComputeShaderSetConstantBuffers(uint startSlot, D3D11Buffer?[]? constantBuffers)
    {
        ComputeShaderSetConstantBuffers(startSlot, constantBuffers.AsSpan());
    }

    /// <summary>
    /// Sets the constant buffers used by the compute shader stage.
    /// </summary>
    /// <param name="startSlot">Index into the zero-based array to begin setting constant buffers to.</param>
    /// <param name="constantBuffers">Array of constant buffers.</param>
    public void ComputeShaderSetConstantBuffers(uint startSlot, ReadOnlySpan<D3D11Buffer?> constantBuffers)
    {
        if (constantBuffers.Length == 0)
        {
            throw new ArgumentNullException(nameof(constantBuffers));
        }

        nint* buffers = stackalloc nint[constantBuffers.Length];
        for (int i = 0; i < constantBuffers.Length; i++)
        {
            D3D11Buffer? current = constantBuffers[i];
            buffers[i] = current is null ? 0 : current.Handle;
        }

        _comImpl->ComputeShaderSetConstantBuffers(_comPtr, startSlot, (uint)constantBuffers.Length, buffers);
    }

    /// <summary>
    /// Sets the constant buffers used by the compute shader stage.
    /// </summary>
    /// <param name="startSlot">Index into the zero-based array to begin setting constant buffers to.</param>
    /// <param name="constantBuffers">Array of constant buffers.</param>
    public void ComputeShaderSetConstantBuffers(uint startSlot, D3D11Buffer? constantBuffers)
    {
        nint buffers = constantBuffers is null ? 0 : constantBuffers.Handle;
        _comImpl->ComputeShaderSetConstantBuffers(_comPtr, startSlot, 1, &buffers);
    }

    /// <summary>
    /// Get the constant buffers used by the vertex shader pipeline stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin retrieving constant buffers from.</param>
    /// <param name="numBuffers">Number of buffers to retrieve.</param>
    /// <returns>Array of constant buffer interface pointers to be returned.</returns>
    public D3D11Buffer?[] VertexShaderGetConstantBuffers(uint startSlot, uint numBuffers)
    {
        var buffers = new D3D11Buffer?[numBuffers];
        VertexShaderGetConstantBuffers(startSlot, buffers.AsSpan());
        return buffers;
    }

    /// <summary>
    /// Get the constant buffers used by the vertex shader pipeline stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin retrieving constant buffers from.</param>
    /// <param name="numBuffers">Number of buffers to retrieve.</param>
    /// <param name="constantBuffers">Array of constant buffer interface pointers to be returned.</param>
    public void VertexShaderGetConstantBuffers(uint startSlot, Span<D3D11Buffer?> constantBuffers)
    {
        nint* buffers = stackalloc nint[constantBuffers.Length];
        _comImpl->VertexShaderGetConstantBuffers(_comPtr, startSlot, (uint)constantBuffers.Length, buffers);
        for (int i = 0; i < constantBuffers.Length; i++)
        {
            nint buffer = buffers[i];
            constantBuffers[i] = buffer == 0 ? null : new D3D11Buffer(buffer);
        }
    }

    /// <summary>
    /// Get the pixel shader resources.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin getting shader resources from.</param>
    /// <param name="numViews">The number of resources to get from the device.</param>
    /// <returns>Array of shader resource view interfaces to be returned by the device.</returns>
    public D3D11ShaderResourceView?[] PixelShaderGetShaderResources(uint startSlot, uint numViews)
    {
        var views = new D3D11ShaderResourceView?[numViews];
        PixelShaderGetShaderResources(startSlot, views.AsSpan());
        return views;
    }

    /// <summary>
    /// Get the pixel shader resources.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin getting shader resources from.</param>
    /// <param name="numViews">The number of resources to get from the device.</param>
    /// <param name="shaderResourceViews">Array of shader resource view interfaces to be returned by the device.</param>
    public void PixelShaderGetShaderResources(uint startSlot, Span<D3D11ShaderResourceView?> shaderResourceViews)
    {
        nint* views = stackalloc nint[shaderResourceViews.Length];
        _comImpl->PixelShaderGetShaderResources(_comPtr, startSlot, (uint)shaderResourceViews.Length, views);
        for (int i = 0; i < shaderResourceViews.Length; i++)
        {
            nint view = views[i];
            shaderResourceViews[i] = view == 0 ? null : new D3D11ShaderResourceView(view);
        }
    }

    /// <summary>
    /// Get the pixel shader currently set on the device.
    /// </summary>
    /// <returns>A pixel shader.</returns>
    public D3D11PixelShader? PixelShaderGetShader()
    {
        nint ptr;
        _comImpl->PixelShaderGetShader(_comPtr, &ptr, null, null);
        return ptr == 0 ? null : new D3D11PixelShader(ptr);
    }

    /// <summary>
    /// Get the pixel shader currently set on the device.
    /// </summary>
    /// <param name="numClassInstances">The number of class-instance elements in the array.</param>
    /// <param name="classInstances">An array of class instance interfaces.</param>
    /// <returns>A pixel shader.</returns>
    public D3D11PixelShader? PixelShaderGetShader(out uint numClassInstances, D3D11ClassInstance?[] classInstances)
    {
        return PixelShaderGetShader(out numClassInstances, classInstances.AsSpan());
    }

    /// <summary>
    /// Get the pixel shader currently set on the device.
    /// </summary>
    /// <param name="numClassInstances">The number of class-instance elements in the array.</param>
    /// <param name="classInstances">An array of class instance interfaces.</param>
    /// <returns>A pixel shader.</returns>
    public D3D11PixelShader? PixelShaderGetShader(out uint numClassInstances, Span<D3D11ClassInstance?> classInstances)
    {
        nint ptr;
        nint* instances = stackalloc nint[classInstances.Length];
        uint num;
        _comImpl->PixelShaderGetShader(_comPtr, &ptr, instances, &num);
        for (int i = 0; i < classInstances.Length; i++)
        {
            nint instance = instances[i];
            classInstances[i] = instance == 0 ? null : new D3D11ClassInstance(instance);
        }

        numClassInstances = num;
        return ptr == 0 ? null : new D3D11PixelShader(ptr);
    }

    /// <summary>
    /// Get an array of sampler states from the pixel shader pipeline stage.
    /// </summary>
    /// <param name="startSlot">Index into a zero-based array to begin getting samplers from.</param>
    /// <param name="numSamplers">Number of samplers to get from a device context.</param>
    /// <returns>Array of sampler-state interface pointers.</returns>
    public D3D11SamplerState?[] PixelShaderGetSamplers(uint startSlot, uint numSamplers)
    {
        var samplers = new D3D11SamplerState?[numSamplers];
        PixelShaderGetSamplers(startSlot, samplers.AsSpan());
        return samplers;
    }

    /// <summary>
    /// Get an array of sampler states from the pixel shader pipeline stage.
    /// </summary>
    /// <param name="startSlot">Index into a zero-based array to begin getting samplers from.</param>
    /// <param name="samplers">Array of sampler-state interface pointers.</param>
    public void PixelShaderGetSamplers(uint startSlot, Span<D3D11SamplerState?> samplers)
    {
        nint* ptr = stackalloc nint[samplers.Length];
        _comImpl->PixelShaderGetSamplers(_comPtr, startSlot, (uint)samplers.Length, ptr);
        for (int i = 0; i < samplers.Length; i++)
        {
            nint sampler = ptr[i];
            samplers[i] = sampler == 0 ? null : new D3D11SamplerState(sampler);
        }
    }

    /// <summary>
    /// Get the vertex shader currently set on the device.
    /// </summary>
    /// <returns>A vertex shader.</returns>
    public D3D11VertexShader? VertexShaderGetShader()
    {
        nint ptr;
        _comImpl->VertexShaderGetShader(_comPtr, &ptr, null, null);
        return ptr == 0 ? null : new D3D11VertexShader(ptr);
    }

    /// <summary>
    /// Get the vertex shader currently set on the device.
    /// </summary>
    /// <param name="numClassInstances">The number of class-instance elements in the array.</param>
    /// <param name="classInstances">An array of class instance interfaces.</param>
    /// <returns>A vertex shader.</returns>
    public D3D11VertexShader? VertexShaderGetShader(out uint numClassInstances, D3D11ClassInstance?[] classInstances)
    {
        return VertexShaderGetShader(out numClassInstances, classInstances.AsSpan());
    }

    /// <summary>
    /// Get the vertex shader currently set on the device.
    /// </summary>
    /// <param name="numClassInstances">The number of class-instance elements in the array.</param>
    /// <param name="classInstances">An array of class instance interfaces.</param>
    /// <returns>A vertex shader.</returns>
    public D3D11VertexShader? VertexShaderGetShader(out uint numClassInstances, Span<D3D11ClassInstance?> classInstances)
    {
        nint ptr;
        nint* instances = stackalloc nint[classInstances.Length];
        uint num;
        _comImpl->VertexShaderGetShader(_comPtr, &ptr, instances, &num);
        for (int i = 0; i < classInstances.Length; i++)
        {
            nint instance = instances[i];
            classInstances[i] = instance == 0 ? null : new D3D11ClassInstance(instance);
        }

        numClassInstances = num;
        return ptr == 0 ? null : new D3D11VertexShader(ptr);
    }

    /// <summary>
    /// Get the constant buffers used by the pixel shader pipeline stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin retrieving constant buffers from.</param>
    /// <param name="numBuffers">Number of buffers to retrieve.</param>
    /// <returns>Array of constant buffer interface pointers to be returned.</returns>
    public D3D11Buffer?[] PixelShaderGetConstantBuffers(uint startSlot, uint numBuffers)
    {
        var buffers = new D3D11Buffer?[numBuffers];
        PixelShaderGetConstantBuffers(startSlot, buffers.AsSpan());
        return buffers;
    }

    /// <summary>
    /// Get the constant buffers used by the pixel shader pipeline stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin retrieving constant buffers from.</param>
    /// <param name="constantBuffers">Array of constant buffer interface pointers to be returned.</param>
    public void PixelShaderGetConstantBuffers(uint startSlot, Span<D3D11Buffer?> constantBuffers)
    {
        nint* buffers = stackalloc nint[constantBuffers.Length];
        _comImpl->PixelShaderGetConstantBuffers(_comPtr, startSlot, (uint)constantBuffers.Length, buffers);
        for (int i = 0; i < constantBuffers.Length; i++)
        {
            nint buffer = buffers[i];
            constantBuffers[i] = buffer == 0 ? null : new D3D11Buffer(buffer);
        }
    }

    /// <summary>
    /// Get the input-layout object that is bound to the input-assembler stage.
    /// </summary>
    /// <returns>The input-layout object.</returns>
    public D3D11InputLayout? InputAssemblerGetInputLayout()
    {
        nint ptr;
        _comImpl->InputAssemblerGetInputLayout(_comPtr, &ptr);
        return ptr == 0 ? null : new D3D11InputLayout(ptr);
    }

    /// <summary>
    /// Get the vertex buffers bound to the input-assembler stage.
    /// </summary>
    /// <param name="startSlot">The input slot of the first vertex buffer to get.</param>
    /// <param name="numBuffers">The number of vertex buffers to get starting at the offset.</param>
    /// <param name="vertexBuffers">An array of vertex buffers.</param>
    /// <param name="strides">An array of stride values.</param>
    /// <param name="offsets">An array of offset values.</param>
    public void InputAssemblerGetVertexBuffers(
        uint startSlot,
        uint numBuffers,
        out D3D11Buffer?[] vertexBuffers,
        out uint[] strides,
        out uint[] offsets)
    {
        vertexBuffers = new D3D11Buffer?[numBuffers];
        strides = new uint[numBuffers];
        offsets = new uint[numBuffers];
        InputAssemblerGetVertexBuffers(startSlot, vertexBuffers.AsSpan(), strides.AsSpan(), offsets.AsSpan());
    }

    /// <summary>
    /// Get the vertex buffers bound to the input-assembler stage.
    /// </summary>
    /// <param name="startSlot">The input slot of the first vertex buffer to get.</param>
    /// <param name="numBuffers">The number of vertex buffers to get starting at the offset.</param>
    /// <param name="vertexBuffers">An array of vertex buffers.</param>
    /// <param name="strides">An array of stride values.</param>
    /// <param name="offsets">An array of offset values.</param>
    public void InputAssemblerGetVertexBuffers(
        uint startSlot,
        Span<D3D11Buffer?> vertexBuffers,
        Span<uint> strides,
        Span<uint> offsets)
    {
        int numBuffers = vertexBuffers.Length;

        if (strides.Length != numBuffers)
        {
            throw new ArgumentOutOfRangeException(nameof(strides));
        }

        if (offsets.Length != numBuffers)
        {
            throw new ArgumentOutOfRangeException(nameof(offsets));
        }

        nint* buffers = stackalloc nint[numBuffers];

        fixed (uint* stridesPtr = strides)
        fixed (uint* offsetsPtr = offsets)
        {
            _comImpl->InputAssemblerGetVertexBuffers(_comPtr, startSlot, (uint)numBuffers, buffers, stridesPtr, offsetsPtr);
        }

        for (int i = 0; i < numBuffers; i++)
        {
            nint buffer = buffers[i];
            vertexBuffers[i] = buffer == 0 ? null : new D3D11Buffer(buffer);
        }
    }

    /// <summary>
    /// Get the vertex buffers bound to the input-assembler stage.
    /// </summary>
    /// <param name="startSlot">The input slot of the first vertex buffer to get.</param>
    /// <param name="numBuffers">The number of vertex buffers to get starting at the offset.</param>
    /// <param name="vertexBuffers">An array of vertex buffers.</param>
    /// <param name="strides">An array of stride values.</param>
    /// <param name="offsets">An array of offset values.</param>
    public D3D11Buffer? InputAssemblerGetVertexBuffers(uint startSlot)
    {
        nint buffer;
        _comImpl->InputAssemblerGetVertexBuffers(_comPtr, startSlot, 1, &buffer, null, null);
        return buffer == 0 ? null : new D3D11Buffer(buffer);
    }

    /// <summary>
    /// Get the index buffer that is bound to the input-assembler stage.
    /// </summary>
    /// <param name="indexBuffer">An index buffer.</param>
    /// <param name="format">The format of the data in the index buffer.</param>
    /// <param name="offset">Offset (in bytes) from the start of the index buffer, to the first index to use.</param>
    public D3D11Buffer? InputAssemblerGetIndexBuffer(out DxgiFormat format, out uint offset)
    {
        nint ptr;
        DxgiFormat formatPtr;
        uint offsetPtr;
        _comImpl->InputAssemblerGetIndexBuffer(_comPtr, &ptr, &formatPtr, &offsetPtr);
        format = formatPtr;
        offset = offsetPtr;
        return ptr == 0 ? null : new D3D11Buffer(ptr);
    }

    /// <summary>
    /// Get the constant buffers used by the geometry shader pipeline stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin retrieving constant buffers from.</param>
    /// <param name="numBuffers">Number of buffers to retrieve.</param>
    /// <returns>Array of constant buffer interface pointers to be returned.</returns>
    public D3D11Buffer?[] GeometryShaderGetConstantBuffers(uint startSlot, uint numBuffers)
    {
        var buffers = new D3D11Buffer?[numBuffers];
        GeometryShaderGetConstantBuffers(startSlot, buffers.AsSpan());
        return buffers;
    }

    /// <summary>
    /// Get the constant buffers used by the geometry shader pipeline stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin retrieving constant buffers from.</param>
    /// <param name="constantBuffers">Array of constant buffer interface pointers to be returned.</param>
    public void GeometryShaderGetConstantBuffers(uint startSlot, Span<D3D11Buffer?> constantBuffers)
    {
        nint* buffers = stackalloc nint[constantBuffers.Length];
        _comImpl->GeometryShaderGetConstantBuffers(_comPtr, startSlot, (uint)constantBuffers.Length, buffers);
        for (int i = 0; i < constantBuffers.Length; i++)
        {
            nint buffer = buffers[i];
            constantBuffers[i] = buffer == 0 ? null : new D3D11Buffer(buffer);
        }
    }

    /// <summary>
    /// Get the geometry shader currently set on the device.
    /// </summary>
    /// <returns>A geometry shader.</returns>
    public D3D11GeometryShader? GeometryShaderGetShader()
    {
        nint ptr;
        _comImpl->GeometryShaderGetShader(_comPtr, &ptr, null, null);
        return ptr == 0 ? null : new D3D11GeometryShader(ptr);
    }

    /// <summary>
    /// Get the geometry shader currently set on the device.
    /// </summary>
    /// <param name="numClassInstances">The number of class-instance elements in the array.</param>
    /// <param name="classInstances">An array of class instance interfaces.</param>
    /// <returns>A geometry shader.</returns>
    public D3D11GeometryShader? GeometryShaderGetShader(out uint numClassInstances, D3D11ClassInstance?[] classInstances)
    {
        return GeometryShaderGetShader(out numClassInstances, classInstances.AsSpan());
    }

    /// <summary>
    /// Get the geometry shader currently set on the device.
    /// </summary>
    /// <param name="numClassInstances">The number of class-instance elements in the array.</param>
    /// <param name="classInstances">An array of class instance interfaces.</param>
    /// <returns>A geometry shader.</returns>
    public D3D11GeometryShader? GeometryShaderGetShader(out uint numClassInstances, Span<D3D11ClassInstance?> classInstances)
    {
        nint ptr;
        nint* instances = stackalloc nint[classInstances.Length];
        uint num;
        _comImpl->GeometryShaderGetShader(_comPtr, &ptr, instances, &num);
        for (int i = 0; i < classInstances.Length; i++)
        {
            nint instance = instances[i];
            classInstances[i] = instance == 0 ? null : new D3D11ClassInstance(instance);
        }

        numClassInstances = num;
        return ptr == 0 ? null : new D3D11GeometryShader(ptr);
    }

    /// <summary>
    /// Get information about the primitive type, and data order that describes input data for the input assembler stage.
    /// </summary>
    /// <returns>The type of primitive, and ordering of the primitive data.</returns>
    public D3D11PrimitiveTopology InputAssemblerGetPrimitiveTopology()
    {
        D3D11PrimitiveTopology topology;
        _comImpl->InputAssemblerGetPrimitiveTopology(_comPtr, &topology);
        return topology;
    }

    /// <summary>
    /// Get the vertex shader resources.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin getting shader resources from.</param>
    /// <param name="numViews">The number of resources to get from the device.</param>
    /// <returns>Array of shader resource view interfaces to be returned by the device.</returns>
    public D3D11ShaderResourceView?[] VertexShaderGetShaderResources(uint startSlot, uint numViews)
    {
        var shaderResourceViews = new D3D11ShaderResourceView?[numViews];
        VertexShaderGetShaderResources(startSlot, shaderResourceViews.AsSpan());
        return shaderResourceViews;
    }

    /// <summary>
    /// Get the vertex shader resources.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin getting shader resources from.</param>
    /// <param name="shaderResourceViews">Array of shader resource view interfaces to be returned by the device.</param>
    public void VertexShaderGetShaderResources(uint startSlot, Span<D3D11ShaderResourceView?> shaderResourceViews)
    {
        nint* views = stackalloc nint[shaderResourceViews.Length];
        _comImpl->VertexShaderGetShaderResources(_comPtr, startSlot, (uint)shaderResourceViews.Length, views);
        for (int i = 0; i < shaderResourceViews.Length; i++)
        {
            nint view = views[i];
            shaderResourceViews[i] = view == 0 ? null : new D3D11ShaderResourceView(view);
        }
    }

    /// <summary>
    /// Get an array of sampler states from the vertex shader pipeline stage.
    /// </summary>
    /// <param name="startSlot">Index into a zero-based array to begin getting samplers from.</param>
    /// <param name="numSamplers">Number of samplers to get from a device context.</param>
    /// <returns>Array of sampler-state interface pointers to be returned by the device.</returns>
    public D3D11SamplerState?[] VertexShaderGetSamplers(uint startSlot, uint numSamplers)
    {
        var samplers = new D3D11SamplerState?[numSamplers];
        VertexShaderGetSamplers(startSlot, samplers.AsSpan());
        return samplers;
    }

    /// <summary>
    /// Get an array of sampler states from the vertex shader pipeline stage.
    /// </summary>
    /// <param name="startSlot">Index into a zero-based array to begin getting samplers from.</param>
    /// <param name="samplers">Array of sampler-state interface pointers to be returned by the device.</param>
    public void VertexShaderGetSamplers(uint startSlot, Span<D3D11SamplerState?> samplers)
    {
        nint* ptr = stackalloc nint[samplers.Length];
        _comImpl->VertexShaderGetSamplers(_comPtr, startSlot, (uint)samplers.Length, ptr);
        for (int i = 0; i < samplers.Length; i++)
        {
            nint sampler = ptr[i];
            samplers[i] = sampler == 0 ? null : new D3D11SamplerState(sampler);
        }
    }

    /// <summary>
    /// Get the rendering predicate state.
    /// </summary>
    /// <param name="predicateValue">The predicate comparison value.</param>
    public D3D11Predicate? GetPredication(out bool predicateValue)
    {
        nint ptr;
        int value;
        _comImpl->GetPredication(_comPtr, &ptr, &value);
        predicateValue = value != 0;
        return ptr == 0 ? null : new D3D11Predicate(ptr);
    }

    /// <summary>
    /// Get the geometry shader resources.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin getting shader resources from.</param>
    /// <param name="numViews">The number of resources to get from the device.</param>
    /// <returns>Array of shader resource view interfaces to be returned by the device.</returns>
    public D3D11ShaderResourceView?[] GeometryShaderGetShaderResources(uint startSlot, uint numViews)
    {
        var shaderResourceViews = new D3D11ShaderResourceView?[numViews];
        GeometryShaderGetShaderResources(startSlot, shaderResourceViews.AsSpan());
        return shaderResourceViews;
    }

    /// <summary>
    /// Get the geometry shader resources.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin getting shader resources from.</param>
    /// <param name="shaderResourceViews">Array of shader resource view interfaces to be returned by the device.</param>
    public void GeometryShaderGetShaderResources(uint startSlot, Span<D3D11ShaderResourceView?> shaderResourceViews)
    {
        nint* views = stackalloc nint[shaderResourceViews.Length];
        _comImpl->GeometryShaderGetShaderResources(_comPtr, startSlot, (uint)shaderResourceViews.Length, views);
        for (int i = 0; i < shaderResourceViews.Length; i++)
        {
            nint view = views[i];
            shaderResourceViews[i] = view == 0 ? null : new D3D11ShaderResourceView(view);
        }
    }

    /// <summary>
    /// Get an array of sampler state interfaces from the geometry shader pipeline stage.
    /// </summary>
    /// <param name="startSlot">Index into a zero-based array to begin getting samplers from.</param>
    /// <param name="numSamplers">Number of samplers to get from a device context.</param>
    /// <returns>An array of sampler-state interfaces.</returns>
    public D3D11SamplerState?[] GeometryShaderGetSamplers(uint startSlot, uint numSamplers)
    {
        var samplers = new D3D11SamplerState?[numSamplers];
        GeometryShaderGetSamplers(startSlot, samplers.AsSpan());
        return samplers;
    }

    /// <summary>
    /// Get an array of sampler state interfaces from the geometry shader pipeline stage.
    /// </summary>
    /// <param name="startSlot">Index into a zero-based array to begin getting samplers from.</param>
    /// <param name="samplers">An array of sampler-state interfaces.</param>
    public void GeometryShaderGetSamplers(uint startSlot, Span<D3D11SamplerState?> samplers)
    {
        nint* ptr = stackalloc nint[samplers.Length];
        _comImpl->GeometryShaderGetSamplers(_comPtr, startSlot, (uint)samplers.Length, ptr);
        for (int i = 0; i < samplers.Length; i++)
        {
            nint sampler = ptr[i];
            samplers[i] = sampler == 0 ? null : new D3D11SamplerState(sampler);
        }
    }

    /// <summary>
    /// Get pointers to the resources bound to the output-merger stage.
    /// </summary>
    /// <param name="numViews">Number of render targets to retrieve.</param>
    /// <param name="renderTargetViews">The render target views.</param>
    /// <param name="depthStencilView">A depth-stencil view.</param>
    public void OutputMergerGetRenderTargets(
        D3D11RenderTargetView?[] renderTargetViews,
        out D3D11DepthStencilView? depthStencilView)
    {
        OutputMergerGetRenderTargets(renderTargetViews.AsSpan(), out depthStencilView);
    }

    /// <summary>
    /// Get pointers to the resources bound to the output-merger stage.
    /// </summary>
    /// <param name="numViews">Number of render targets to retrieve.</param>
    /// <param name="renderTargetViews">The render target views.</param>
    /// <param name="depthStencilView">A depth-stencil view.</param>
    public void OutputMergerGetRenderTargets(
        Span<D3D11RenderTargetView?> renderTargetViews,
        out D3D11DepthStencilView? depthStencilView)
    {
        nint* views = stackalloc nint[renderTargetViews.Length];
        nint dsv;
        _comImpl->OutputMergerGetRenderTargets(_comPtr, (uint)renderTargetViews.Length, views, &dsv);
        for (int i = 0; i < renderTargetViews.Length; i++)
        {
            nint view = views[i];
            renderTargetViews[i] = view == 0 ? null : new D3D11RenderTargetView(view);
        }
        depthStencilView = dsv == 0 ? null : new D3D11DepthStencilView(dsv);
    }

    /// <summary>
    /// Get pointers to the resources bound to the output-merger stage.
    /// </summary>
    /// <param name="numRenderTargetViews">The number of render-target views to retrieve.</param>
    /// <param name="renderTargetViews">The render-target views.</param>
    /// <param name="depthStencilView">A depth-stencil view.</param>
    /// <param name="uavStartSlot">Index into a zero-based array to begin retrieving unordered-access views.</param>
    /// <param name="numUnorderedAccessViews">Number of unordered-access views to return.</param>
    /// <param name="unorderedAccessViews">The  unordered-access views that are retrieved.</param>
    public void OutputMergerGetRenderTargetsAndUnorderedAccessViews(
        D3D11RenderTargetView?[] renderTargetViews,
        out D3D11DepthStencilView? depthStencilView,
        uint uavStartSlot,
        D3D11UnorderedAccessView?[] unorderedAccessViews)
    {
        OutputMergerGetRenderTargetsAndUnorderedAccessViews(renderTargetViews.AsSpan(), out depthStencilView, uavStartSlot, unorderedAccessViews.AsSpan());
    }

    /// <summary>
    /// Get pointers to the resources bound to the output-merger stage.
    /// </summary>
    /// <param name="numRenderTargetViews">The number of render-target views to retrieve.</param>
    /// <param name="renderTargetViews">The render-target views.</param>
    /// <param name="depthStencilView">A depth-stencil view.</param>
    /// <param name="uavStartSlot">Index into a zero-based array to begin retrieving unordered-access views.</param>
    /// <param name="numUnorderedAccessViews">Number of unordered-access views to return.</param>
    /// <param name="unorderedAccessViews">The  unordered-access views that are retrieved.</param>
    public void OutputMergerGetRenderTargetsAndUnorderedAccessViews(
        Span<D3D11RenderTargetView?> renderTargetViews,
        out D3D11DepthStencilView? depthStencilView,
        uint uavStartSlot,
        Span<D3D11UnorderedAccessView?> unorderedAccessViews)
    {
        nint* rtvs = stackalloc nint[renderTargetViews.Length];
        nint dsv;
        nint* uavs = stackalloc nint[unorderedAccessViews.Length];
        _comImpl->OutputMergerGetRenderTargetsAndUnorderedAccessViews(
            _comPtr,
            (uint)renderTargetViews.Length,
            rtvs,
            &dsv,
            uavStartSlot,
            (uint)unorderedAccessViews.Length,
            uavs);
        for (int i = 0; i < renderTargetViews.Length; i++)
        {
            nint view = rtvs[i];
            renderTargetViews[i] = view == 0 ? null : new D3D11RenderTargetView(view);
        }
        depthStencilView = dsv == 0 ? null : new D3D11DepthStencilView(dsv);
        for (int i = 0; i < unorderedAccessViews.Length; i++)
        {
            nint view = uavs[i];
            unorderedAccessViews[i] = view == 0 ? null : new D3D11UnorderedAccessView(view);
        }
    }

    /// <summary>
    /// Get the blend state of the output-merger stage.
    /// </summary>
    /// <param name="blendFactor">Array of blend factors, one for each RGBA component.</param>
    /// <param name="sampleMask">A sample mask.</param>
    /// <returns>A blend-state interface.</returns>
    public D3D11BlendState? OutputMergerGetBlendState(out float[] blendFactor, out uint sampleMask)
    {
        blendFactor = new float[4];
        return OutputMergerGetBlendState(blendFactor.AsSpan(), out sampleMask);
    }

    /// <summary>
    /// Get the blend state of the output-merger stage.
    /// </summary>
    /// <param name="blendFactor">Array of blend factors, one for each RGBA component.</param>
    /// <param name="sampleMask">A sample mask.</param>
    /// <returns>A blend-state interface.</returns>
    public D3D11BlendState? OutputMergerGetBlendState(Span<float> blendFactor, out uint sampleMask)
    {
        if (blendFactor.Length != 4)
        {
            throw new ArgumentOutOfRangeException(nameof(blendFactor));
        }

        nint ptr;
        uint mask;
        fixed (float* blendFactorPtr = blendFactor)
        {
            _comImpl->OutputMergerGetBlendState(_comPtr, &ptr, blendFactorPtr, &mask);
            sampleMask = mask;
            return ptr == 0 ? null : new D3D11BlendState(ptr);
        }
    }

    /// <summary>
    /// Gets the depth-stencil state of the output-merger stage.
    /// </summary>
    /// <param name="stencilReference">The stencil reference value used in the depth-stencil test.</param>
    /// <returns>A depth-stencil state interface.</returns>
    public D3D11DepthStencilState? OutputMergerGetDepthStencilState(out uint stencilReference)
    {
        nint ptr;
        uint stencil;
        _comImpl->OutputMergerGetDepthStencilState(_comPtr, &ptr, &stencil);
        stencilReference = stencil;
        return ptr == 0 ? null : new D3D11DepthStencilState(ptr);
    }

    /// <summary>
    /// Get the target output buffers for the stream-output stage of the pipeline.
    /// </summary>
    /// <param name="numBuffers">Number of buffers to get.</param>
    /// <returns>An array of output buffers to be retrieved from the device.</returns>
    public D3D11Buffer?[] StreamOutputGetTargets(uint numBuffers)
    {
        var buffers = new D3D11Buffer?[numBuffers];
        StreamOutputGetTargets(buffers.AsSpan());
        return buffers;
    }

    /// <summary>
    /// Get the target output buffers for the stream-output stage of the pipeline.
    /// </summary>
    /// <param name="targets">An array of output buffers to be retrieved from the device.</param>
    public void StreamOutputGetTargets(Span<D3D11Buffer?> targets)
    {
        nint* ptr = stackalloc nint[targets.Length];
        _comImpl->StreamOutputGetTargets(_comPtr, (uint)targets.Length, ptr);
        for (int i = 0; i < targets.Length; i++)
        {
            nint target = ptr[i];
            targets[i] = target == 0 ? null : new D3D11Buffer(target);
        }
    }

    /// <summary>
    /// Get the rasterizer state from the rasterizer stage of the pipeline.
    /// </summary>
    /// <returns>A rasterizer-state interface.</returns>
    public D3D11RasterizerState? RasterizerStageGetState()
    {
        nint ptr;
        _comImpl->RasterizerStageGetState(_comPtr, &ptr);
        return ptr == 0 ? null : new D3D11RasterizerState(ptr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public uint RasterizerStageGetViewportsCount()
    {
        uint count;
        _comImpl->RasterizerStageGetViewports(_comPtr, &count, null);
        return count;
    }

    /// <summary>
    /// Gets the array of viewports bound to the rasterizer stage.
    /// </summary>
    /// <returns>The viewports that are bound to the rasterizer stage.</returns>
    public D3D11Viewport[] RasterizerStageGetViewports()
    {
        uint count;
        _comImpl->RasterizerStageGetViewports(_comPtr, &count, null);
        int size = D3D11Viewport.NativeRequiredSize((int)count);
        byte* ptr = stackalloc byte[size];
        _comImpl->RasterizerStageGetViewports(_comPtr, &count, ptr);
        var viewports = new D3D11Viewport[count];
        D3D11Viewport.NativeReadFrom((nint)ptr, viewports.AsSpan());
        return viewports;
    }

    /// <summary>
    /// Gets the array of viewports bound to the rasterizer stage.
    /// </summary>
    /// <param name="viewports">The viewports that are bound to the rasterizer stage.</param>
    public void RasterizerStageGetViewports(Span<D3D11Viewport> viewports)
    {
        uint count;
        _comImpl->RasterizerStageGetViewports(_comPtr, &count, null);

        if (viewports.Length > count)
        {
            throw new ArgumentOutOfRangeException(nameof(viewports));
        }

        int size = D3D11Viewport.NativeRequiredSize((int)count);
        byte* ptr = stackalloc byte[size];
        _comImpl->RasterizerStageGetViewports(_comPtr, &count, ptr);
        D3D11Viewport.NativeReadFrom((nint)ptr, viewports);
    }

    /// <summary>
    /// Get the array of scissor rectangles bound to the rasterizer stage.
    /// </summary>
    /// <returns>An array of scissor rectangles.</returns>
    public D3D11Rect[] RasterizerStageGetScissorRects()
    {
        uint count;
        _comImpl->RasterizerStageGetScissorRects(_comPtr, &count, null);
        int size = D3D11Rect.NativeRequiredSize((int)count);
        byte* ptr = stackalloc byte[size];
        _comImpl->RasterizerStageGetScissorRects(_comPtr, &count, ptr);
        var rects = new D3D11Rect[count];
        D3D11Rect.NativeReadFrom((nint)ptr, rects.AsSpan());
        return rects;
    }

    /// <summary>
    /// Get the array of scissor rectangles bound to the rasterizer stage.
    /// </summary>
    /// <returns>An array of scissor rectangles.</returns>
    public void RasterizerStageGetScissorRects(Span<D3D11Rect> rects)
    {
        uint count;
        _comImpl->RasterizerStageGetScissorRects(_comPtr, &count, null);

        if (rects.Length > count)
        {
            throw new ArgumentOutOfRangeException(nameof(rects));
        }

        int size = D3D11Rect.NativeRequiredSize((int)count);
        byte* ptr = stackalloc byte[size];
        _comImpl->RasterizerStageGetScissorRects(_comPtr, &count, ptr);
        D3D11Rect.NativeReadFrom((nint)ptr, rects);
    }

    /// <summary>
    /// Get the hull shader resources.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin getting shader resources from.</param>
    /// <param name="numViews">The number of resources to get from the device.</param>
    /// <returns>Array of shader resource view interfaces to be returned by the device.</returns>
    public D3D11ShaderResourceView?[] HullShaderGetShaderResources(uint startSlot, uint numViews)
    {
        var views = new D3D11ShaderResourceView?[numViews];
        HullShaderGetShaderResources(startSlot, views.AsSpan());
        return views;
    }

    /// <summary>
    /// Get the hull shader resources.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin getting shader resources from.</param>
    /// <param name="shaderResourceViews">Array of shader resource view interfaces to be returned by the device.</param>
    public void HullShaderGetShaderResources(uint startSlot, Span<D3D11ShaderResourceView?> shaderResourceViews)
    {
        nint* views = stackalloc nint[shaderResourceViews.Length];
        _comImpl->HullShaderGetShaderResources(_comPtr, startSlot, (uint)shaderResourceViews.Length, views);
        for (int i = 0; i < shaderResourceViews.Length; i++)
        {
            nint view = views[i];
            shaderResourceViews[i] = view == 0 ? null : new D3D11ShaderResourceView(view);
        }
    }

    /// <summary>
    /// Get the hull shader currently set on the device.
    /// </summary>
    /// <returns>A hull shader.</returns>
    public D3D11HullShader? HullShaderGetShader()
    {
        nint ptr;
        _comImpl->HullShaderGetShader(_comPtr, &ptr, null, null);
        return ptr == 0 ? null : new D3D11HullShader(ptr);
    }

    /// <summary>
    /// Get the hull shader currently set on the device.
    /// </summary>
    /// <param name="numClassInstances">The number of class-instance elements in the array.</param>
    /// <param name="classInstances">An array of class instance interfaces.</param>
    /// <returns>A hull shader.</returns>
    public D3D11HullShader? HullShaderGetShader(out uint numClassInstances, D3D11ClassInstance?[] classInstances)
    {
        return HullShaderGetShader(out numClassInstances, classInstances.AsSpan());
    }

    /// <summary>
    /// Get the hull shader currently set on the device.
    /// </summary>
    /// <param name="numClassInstances">The number of class-instance elements in the array.</param>
    /// <param name="classInstances">An array of class instance interfaces.</param>
    /// <returns>A hull shader.</returns>
    public D3D11HullShader? HullShaderGetShader(out uint numClassInstances, Span<D3D11ClassInstance?> classInstances)
    {
        nint ptr;
        nint* instances = stackalloc nint[classInstances.Length];
        uint num;
        _comImpl->HullShaderGetShader(_comPtr, &ptr, instances, &num);
        for (int i = 0; i < classInstances.Length; i++)
        {
            nint instance = instances[i];
            classInstances[i] = instance == 0 ? null : new D3D11ClassInstance(instance);
        }

        numClassInstances = num;
        return ptr == 0 ? null : new D3D11HullShader(ptr);
    }

    /// <summary>
    /// Get an array of sampler state interfaces from the hull shader stage.
    /// </summary>
    /// <param name="startSlot">Index into a zero-based array to begin getting samplers from.</param>
    /// <param name="numSamplers">Number of samplers to get from a device context.</param>
    /// <returns>An array of sampler-state interfaces.</returns>
    public D3D11SamplerState?[] HullShaderGetSamplers(uint startSlot, uint numSamplers)
    {
        var samplers = new D3D11SamplerState?[numSamplers];
        HullShaderGetSamplers(startSlot, samplers.AsSpan());
        return samplers;
    }

    /// <summary>
    /// Get an array of sampler state interfaces from the hull shader stage.
    /// </summary>
    /// <param name="startSlot">Index into a zero-based array to begin getting samplers from.</param>
    /// <param name="samplers">An array of sampler-state interfaces.</param>
    public void HullShaderGetSamplers(uint startSlot, Span<D3D11SamplerState?> samplers)
    {
        nint* ptr = stackalloc nint[samplers.Length];
        _comImpl->HullShaderGetSamplers(_comPtr, startSlot, (uint)samplers.Length, ptr);
        for (int i = 0; i < samplers.Length; i++)
        {
            nint sampler = ptr[i];
            samplers[i] = sampler == 0 ? null : new D3D11SamplerState(sampler);
        }
    }

    /// <summary>
    /// Get the constant buffers used by the hull shader stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin retrieving constant buffers from.</param>
    /// <param name="numBuffers">Number of buffers to retrieve.</param>
    /// <returns>Array of constant buffer interface pointers to be returned by the method.</returns>
    public D3D11Buffer?[] HullShaderGetConstantBuffers(uint startSlot, uint numBuffers)
    {
        var buffers = new D3D11Buffer?[numBuffers];
        HullShaderGetConstantBuffers(startSlot, buffers.AsSpan());
        return buffers;
    }

    /// <summary>
    /// Get the constant buffers used by the hull shader stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin retrieving constant buffers from.</param>
    /// <param name="constantBuffers">Array of constant buffer interface pointers to be returned by the method.</param>
    public void HullShaderGetConstantBuffers(uint startSlot, Span<D3D11Buffer?> constantBuffers)
    {
        nint* buffers = stackalloc nint[constantBuffers.Length];
        _comImpl->HullShaderGetConstantBuffers(_comPtr, startSlot, (uint)constantBuffers.Length, buffers);
        for (int i = 0; i < constantBuffers.Length; i++)
        {
            nint buffer = buffers[i];
            constantBuffers[i] = buffer == 0 ? null : new D3D11Buffer(buffer);
        }
    }

    /// <summary>
    /// Get the domain shader resources.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin getting shader resources from.</param>
    /// <param name="numViews">The number of resources to get from the device.</param>
    /// <returns>Array of shader resource view interfaces to be returned by the device.</returns>
    public D3D11ShaderResourceView?[] DomainShaderGetShaderResources(uint startSlot, uint numViews)
    {
        var views = new D3D11ShaderResourceView?[numViews];
        DomainShaderGetShaderResources(startSlot, views.AsSpan());
        return views;
    }

    /// <summary>
    /// Get the domain shader resources.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin getting shader resources from.</param>
    /// <param name="shaderResourceViews">Array of shader resource view interfaces to be returned by the device.</param>
    public void DomainShaderGetShaderResources(uint startSlot, Span<D3D11ShaderResourceView?> shaderResourceViews)
    {
        nint* views = stackalloc nint[shaderResourceViews.Length];
        _comImpl->DomainShaderGetShaderResources(_comPtr, startSlot, (uint)shaderResourceViews.Length, views);
        for (int i = 0; i < shaderResourceViews.Length; i++)
        {
            nint view = views[i];
            shaderResourceViews[i] = view == 0 ? null : new D3D11ShaderResourceView(view);
        }
    }

    /// <summary>
    /// Get the domain shader currently set on the device.
    /// </summary>
    /// <returns>A domain shader.</returns>
    public D3D11DomainShader? DomainShaderGetShader()
    {
        nint ptr;
        _comImpl->DomainShaderGetShader(_comPtr, &ptr, null, null);
        return ptr == 0 ? null : new D3D11DomainShader(ptr);
    }

    /// <summary>
    /// Get the domain shader currently set on the device.
    /// </summary>
    /// <param name="numClassInstances">The number of class-instance elements in the array.</param>
    /// <param name="classInstances">An array of class instance interfaces.</param>
    /// <returns>A domain shader.</returns>
    public D3D11DomainShader? DomainShaderGetShader(out uint numClassInstances, D3D11ClassInstance?[] classInstances)
    {
        return DomainShaderGetShader(out numClassInstances, classInstances.AsSpan());
    }

    /// <summary>
    /// Get the domain shader currently set on the device.
    /// </summary>
    /// <param name="numClassInstances">The number of class-instance elements in the array.</param>
    /// <param name="classInstances">An array of class instance interfaces.</param>
    /// <returns>A domain shader.</returns>
    public D3D11DomainShader? DomainShaderGetShader(out uint numClassInstances, Span<D3D11ClassInstance?> classInstances)
    {
        nint ptr;
        nint* instances = stackalloc nint[classInstances.Length];
        uint num;
        _comImpl->DomainShaderGetShader(_comPtr, &ptr, instances, &num);
        for (int i = 0; i < classInstances.Length; i++)
        {
            nint instance = instances[i];
            classInstances[i] = instance == 0 ? null : new D3D11ClassInstance(instance);
        }

        numClassInstances = num;
        return ptr == 0 ? null : new D3D11DomainShader(ptr);
    }

    /// <summary>
    /// Get an array of sampler state interfaces from the domain shader stage.
    /// </summary>
    /// <param name="startSlot">Index into a zero-based array to begin getting samplers from.</param>
    /// <param name="numSamplers">Number of samplers to get from a device context.</param>
    /// <returns>An array of sampler-state interfaces.</returns>
    public D3D11SamplerState?[] DomainShaderGetSamplers(uint startSlot, uint numSamplers)
    {
        var samplers = new D3D11SamplerState?[numSamplers];
        DomainShaderGetSamplers(startSlot, samplers.AsSpan());
        return samplers;
    }

    /// <summary>
    /// Get an array of sampler state interfaces from the domain shader stage.
    /// </summary>
    /// <param name="startSlot">Index into a zero-based array to begin getting samplers from.</param>
    /// <param name="samplers">An array of sampler-state interfaces.</param>
    public void DomainShaderGetSamplers(uint startSlot, Span<D3D11SamplerState?> samplers)
    {
        nint* ptr = stackalloc nint[samplers.Length];
        _comImpl->DomainShaderGetSamplers(_comPtr, startSlot, (uint)samplers.Length, ptr);
        for (int i = 0; i < samplers.Length; i++)
        {
            nint sampler = ptr[i];
            samplers[i] = sampler == 0 ? null : new D3D11SamplerState(sampler);
        }
    }

    /// <summary>
    /// Get the constant buffers used by the domain shader stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin retrieving constant buffers from.</param>
    /// <param name="numBuffers">Number of buffers to retrieve.</param>
    /// <returns>Array of constant buffer interface pointers to be returned by the method.</returns>
    public D3D11Buffer?[] DomainShaderGetConstantBuffers(uint startSlot, uint numBuffers)
    {
        var buffers = new D3D11Buffer?[numBuffers];
        DomainShaderGetConstantBuffers(startSlot, buffers.AsSpan());
        return buffers;
    }

    /// <summary>
    /// Get the constant buffers used by the domain shader stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin retrieving constant buffers from.</param>
    /// <param name="constantBuffers">Array of constant buffer interface pointers to be returned by the method.</param>
    public void DomainShaderGetConstantBuffers(uint startSlot, Span<D3D11Buffer?> constantBuffers)
    {
        nint* buffers = stackalloc nint[constantBuffers.Length];
        _comImpl->DomainShaderGetConstantBuffers(_comPtr, startSlot, (uint)constantBuffers.Length, buffers);
        for (int i = 0; i < constantBuffers.Length; i++)
        {
            nint buffer = buffers[i];
            constantBuffers[i] = buffer == 0 ? null : new D3D11Buffer(buffer);
        }
    }

    /// <summary>
    /// Get the compute shader resources.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin getting shader resources from.</param>
    /// <param name="numViews">The number of resources to get from the device.</param>
    /// <returns>Array of shader resource view interfaces to be returned by the device.</returns>
    public D3D11ShaderResourceView?[] ComputeShaderGetShaderResources(uint startSlot, uint numViews)
    {
        var views = new D3D11ShaderResourceView?[numViews];
        ComputeShaderGetShaderResources(startSlot, views.AsSpan());
        return views;
    }

    /// <summary>
    /// Get the compute shader resources.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin getting shader resources from.</param>
    /// <param name="shaderResourceViews">Array of shader resource view interfaces to be returned by the device.</param>
    public void ComputeShaderGetShaderResources(uint startSlot, Span<D3D11ShaderResourceView?> shaderResourceViews)
    {
        nint* views = stackalloc nint[shaderResourceViews.Length];
        _comImpl->ComputeShaderGetShaderResources(_comPtr, startSlot, (uint)shaderResourceViews.Length, views);
        for (int i = 0; i < shaderResourceViews.Length; i++)
        {
            nint view = views[i];
            shaderResourceViews[i] = view == 0 ? null : new D3D11ShaderResourceView(view);
        }
    }

    /// <summary>
    /// Gets an array of views for an unordered resource.
    /// </summary>
    /// <param name="startSlot">Index of the first element in the zero-based array to return.</param>
    /// <param name="numUnorderedAccessViews">Number of views to get.</param>
    /// <returns>An array of interface pointers.</returns>
    public D3D11UnorderedAccessView?[] ComputeShaderGetUnorderedAccessViews(uint startSlot, uint numUnorderedAccessViews)
    {
        var views = new D3D11UnorderedAccessView?[numUnorderedAccessViews];
        ComputeShaderGetUnorderedAccessViews(startSlot, views.AsSpan());
        return views;
    }

    /// <summary>
    /// Gets an array of views for an unordered resource.
    /// </summary>
    /// <param name="startSlot">Index of the first element in the zero-based array to return.</param>
    /// <param name="unorderedAccessViews">An array of interface pointers.</param>
    public void ComputeShaderGetUnorderedAccessViews(uint startSlot, Span<D3D11UnorderedAccessView?> unorderedAccessViews)
    {
        nint* views = stackalloc nint[unorderedAccessViews.Length];
        _comImpl->ComputeShaderGetUnorderedAccessViews(_comPtr, startSlot, (uint)unorderedAccessViews.Length, views);
        for (int i = 0; i < unorderedAccessViews.Length; i++)
        {
            nint view = views[i];
            unorderedAccessViews[i] = view == 0 ? null : new D3D11UnorderedAccessView(view);
        }
    }

    /// <summary>
    /// Get the compute shader currently set on the device.
    /// </summary>
    /// <returns>A compute shader.</returns>
    public D3D11ComputeShader? ComputeShaderGetShader()
    {
        nint ptr;
        _comImpl->ComputeShaderGetShader(_comPtr, &ptr, null, null);
        return ptr == 0 ? null : new D3D11ComputeShader(ptr);
    }

    /// <summary>
    /// Get the compute shader currently set on the device.
    /// </summary>
    /// <param name="numClassInstances">The number of class-instance elements in the array.</param>
    /// <param name="classInstances">An array of class instance interfaces.</param>
    /// <returns>A compute shader.</returns>
    public D3D11ComputeShader? ComputeShaderGetShader(out uint numClassInstances, D3D11ClassInstance?[] classInstances)
    {
        return ComputeShaderGetShader(out numClassInstances, classInstances.AsSpan());
    }

    /// <summary>
    /// Get the compute shader currently set on the device.
    /// </summary>
    /// <param name="numClassInstances">The number of class-instance elements in the array.</param>
    /// <param name="classInstances">An array of class instance interfaces.</param>
    /// <returns>A compute shader.</returns>
    public D3D11ComputeShader? ComputeShaderGetShader(out uint numClassInstances, Span<D3D11ClassInstance?> classInstances)
    {
        nint ptr;
        nint* instances = stackalloc nint[classInstances.Length];
        uint num;
        _comImpl->ComputeShaderGetShader(_comPtr, &ptr, instances, &num);
        for (int i = 0; i < classInstances.Length; i++)
        {
            nint instance = instances[i];
            classInstances[i] = instance == 0 ? null : new D3D11ClassInstance(instance);
        }

        numClassInstances = num;
        return ptr == 0 ? null : new D3D11ComputeShader(ptr);
    }

    /// <summary>
    /// Get an array of sampler state interfaces from the compute shader stage.
    /// </summary>
    /// <param name="startSlot">Index into a zero-based array to begin getting samplers from.</param>
    /// <param name="numSamplers">Number of samplers to get from a device context.</param>
    /// <returns>An array of sampler-state interfaces.</returns>
    public D3D11SamplerState?[] ComputeShaderGetSamplers(uint startSlot, uint numSamplers)
    {
        var samplers = new D3D11SamplerState?[numSamplers];
        ComputeShaderGetSamplers(startSlot, samplers.AsSpan());
        return samplers;
    }

    /// <summary>
    /// Get an array of sampler state interfaces from the compute shader stage.
    /// </summary>
    /// <param name="startSlot">Index into a zero-based array to begin getting samplers from.</param>
    /// <param name="samplers">An array of sampler-state interfaces.</param>
    public void ComputeShaderGetSamplers(uint startSlot, Span<D3D11SamplerState?> samplers)
    {
        nint* ptr = stackalloc nint[samplers.Length];
        _comImpl->ComputeShaderGetSamplers(_comPtr, startSlot, (uint)samplers.Length, ptr);
        for (int i = 0; i < samplers.Length; i++)
        {
            nint sampler = ptr[i];
            samplers[i] = sampler == 0 ? null : new D3D11SamplerState(sampler);
        }
    }

    /// <summary>
    /// Get the constant buffers used by the compute shader stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin retrieving constant buffers from.</param>
    /// <param name="numBuffers">Number of buffers to retrieve.</param>
    /// <returns>Array of constant buffer interface pointers to be returned by the method.</returns>
    public D3D11Buffer?[] ComputeShaderGetConstantBuffers(uint startSlot, uint numBuffers)
    {
        var buffers = new D3D11Buffer?[numBuffers];
        ComputeShaderGetConstantBuffers(startSlot, buffers.AsSpan());
        return buffers;
    }

    /// <summary>
    /// Get the constant buffers used by the compute shader stage.
    /// </summary>
    /// <param name="startSlot">Index into the device's zero-based array to begin retrieving constant buffers from.</param>
    /// <param name="constantBuffers">Array of constant buffer interface pointers to be returned by the method.</param>
    public void ComputeShaderGetConstantBuffers(uint startSlot, Span<D3D11Buffer?> constantBuffers)
    {
        nint* buffers = stackalloc nint[constantBuffers.Length];
        _comImpl->ComputeShaderGetConstantBuffers(_comPtr, startSlot, (uint)constantBuffers.Length, buffers);
        for (int i = 0; i < constantBuffers.Length; i++)
        {
            nint buffer = buffers[i];
            constantBuffers[i] = buffer == 0 ? null : new D3D11Buffer(buffer);
        }
    }

    /// <summary>
    /// Restore all default settings.
    /// </summary>
    public void ClearState()
    {
        _comImpl->ClearState(_comPtr);
    }

    /// <summary>
    /// Sends queued-up commands in the command buffer to the graphics processing unit (GPU).
    /// </summary>
    public void Flush()
    {
        _comImpl->Flush(_comPtr);
    }

    /// <summary>
    /// Create a command list and record graphics commands into it.
    /// </summary>
    /// <param name="restoreDeferredContextState">A value indicating whether the runtime saves deferred context state before it executes <c>FinishCommandList</c> and restores it afterwards.</param>
    /// <returns>The recorded command list.</returns>
    public D3D11CommandList FinishCommandList(bool restoreDeferredContextState)
    {
        nint ptr;
        int hr = _comImpl->FinishCommandList(_comPtr, restoreDeferredContextState ? 1 : 0, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D3D11CommandList(ptr);
    }
}
