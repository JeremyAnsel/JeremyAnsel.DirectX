// <copyright file="D3D11DeviceContext.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using JeremyAnsel.DirectX.D3D11.ComInterfaces;
    using JeremyAnsel.DirectX.Dxgi;

    /// <summary>
    /// Represents a device context which generates rendering commands.
    /// </summary>
    public sealed class D3D11DeviceContext : D3D11DeviceChild
    {
        /// <summary>
        /// The D3D11 device context interface.
        /// </summary>
        private readonly ID3D11DeviceContext deviceContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11DeviceContext"/> class.
        /// </summary>
        /// <param name="deviceContext">A D3D11 device context interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D3D11DeviceContext(ID3D11DeviceContext deviceContext)
        {
            this.deviceContext = deviceContext;
        }

        /// <summary>
        /// Gets an handle representing the D3D11 object interface.
        /// </summary>
        public override object Handle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.deviceContext; }
        }

        /// <summary>
        /// Gets the type of device context.
        /// </summary>
        public D3D11DeviceContextType ContextType
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.deviceContext.GetContextType(); }
        }

        /// <summary>
        /// Gets the initialization flags associated with the current deferred context.
        /// </summary>
        public uint ContextOptions
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.deviceContext.GetContextOptions(); }
        }

        /// <summary>
        /// Sets the constant buffers used by the vertex shader pipeline stage.
        /// </summary>
        /// <param name="startSlot">Index into the device's zero-based array to begin setting constant buffers to.</param>
        /// <param name="constantBuffers">Array of constant buffers being given to the device.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public void VertexShaderSetConstantBuffers(uint startSlot, D3D11Buffer?[]? constantBuffers)
        {
            if (constantBuffers == null)
            {
                throw new ArgumentNullException(nameof(constantBuffers));
            }

            this.deviceContext.VertexShaderSetConstantBuffers(
                startSlot,
                (uint)constantBuffers.Length,
                Array.ConvertAll(constantBuffers, i => i?.GetHandle<ID3D11Buffer>()));
        }

        /// <summary>
        /// Bind an array of shader resources to the pixel shader stage.
        /// </summary>
        /// <param name="startSlot">Index into the device's zero-based array to begin setting shader resources to.</param>
        /// <param name="shaderResourceViews">Array of shader resource view interfaces to set to the device.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public void PixelShaderSetShaderResources(uint startSlot, D3D11ShaderResourceView?[]? shaderResourceViews)
        {
            if (shaderResourceViews == null)
            {
                throw new ArgumentNullException(nameof(shaderResourceViews));
            }

            this.deviceContext.PixelShaderSetShaderResources(
                startSlot,
                (uint)shaderResourceViews.Length,
                Array.ConvertAll(shaderResourceViews, i => i?.GetHandle<ID3D11ShaderResourceView>()));
        }

        /// <summary>
        /// Sets a pixel shader to the device.
        /// </summary>
        /// <param name="pixelShader">A pixel shader.</param>
        /// <param name="classInstances">An array of class-instance interfaces.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void PixelShaderSetShader(D3D11PixelShader? pixelShader, D3D11ClassInstance?[]? classInstances)
        {
            if (classInstances == null)
            {
                this.deviceContext.PixelShaderSetShader(
                    pixelShader?.GetHandle<ID3D11PixelShader>(),
                    null,
                    0);
            }
            else
            {
                if (pixelShader == null)
                {
                    throw new ArgumentNullException(nameof(pixelShader));
                }

                this.deviceContext.PixelShaderSetShader(
                    pixelShader.GetHandle<ID3D11PixelShader>(),
                    Array.ConvertAll(classInstances, i => i?.GetHandle<ID3D11ClassInstance>()),
                    (uint)classInstances.Length);
            }
        }

        /// <summary>
        /// Set an array of sampler states to the pixel shader pipeline stage.
        /// </summary>
        /// <param name="startSlot">Index into the device's zero-based array to begin setting samplers to.</param>
        /// <param name="samplers">An array of sampler-state interfaces.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public void PixelShaderSetSamplers(uint startSlot, D3D11SamplerState?[]? samplers)
        {
            if (samplers == null)
            {
                throw new ArgumentNullException(nameof(samplers));
            }

            this.deviceContext.PixelShaderSetSamplers(
                startSlot,
                (uint)samplers.Length,
                Array.ConvertAll(samplers, i => i?.GetHandle<ID3D11SamplerState>()));
        }

        /// <summary>
        /// Set a vertex shader to the device.
        /// </summary>
        /// <param name="vertexShader">A vertex shader.</param>
        /// <param name="classInstances">An array of class-instance interfaces.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void VertexShaderSetShader(D3D11VertexShader? vertexShader, D3D11ClassInstance?[]? classInstances)
        {
            if (classInstances == null)
            {
                this.deviceContext.VertexShaderSetShader(
                    vertexShader?.GetHandle<ID3D11VertexShader>(),
                    null,
                    0);
            }
            else
            {
                if (vertexShader == null)
                {
                    throw new ArgumentNullException(nameof(vertexShader));
                }

                this.deviceContext.VertexShaderSetShader(
                    vertexShader?.GetHandle<ID3D11VertexShader>(),
                    Array.ConvertAll(classInstances, i => i?.GetHandle<ID3D11ClassInstance>()),
                    (uint)classInstances.Length);
            }
        }

        /// <summary>
        /// Draw indexed, non-instanced primitives.
        /// </summary>
        /// <param name="indexCount">Number of indices to draw.</param>
        /// <param name="startIndexLocation">The location of the first index read by the GPU from the index buffer.</param>
        /// <param name="baseVertexLocation">A value added to each index before reading a vertex from the vertex buffer.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public void DrawIndexed(uint indexCount, uint startIndexLocation, int baseVertexLocation)
        {
            this.deviceContext.DrawIndexed(indexCount, startIndexLocation, baseVertexLocation);
        }

        /// <summary>
        /// Draw non-indexed, non-instanced primitives.
        /// </summary>
        /// <param name="vertexCount">Number of vertices to draw.</param>
        /// <param name="startVertexLocation">Index of the first vertex, which is usually an offset in a vertex buffer.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public void Draw(uint vertexCount, uint startVertexLocation)
        {
            this.deviceContext.Draw(vertexCount, startVertexLocation);
        }

        /// <summary>
        /// Gets a pointer to the data contained in a subresource, and denies the GPU access to that subresource.
        /// </summary>
        /// <param name="resource">A <see cref="D3D11Resource"/> interface.</param>
        /// <param name="subresource">Index number of the subresource.</param>
        /// <param name="cpuPermission">The CPU's read and write permissions for a resource.</param>
        /// <param name="options">Specifies what the CPU does when the GPU is busy.</param>
        /// <returns>The mapped subresource.</returns>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11MappedSubResource Map(
            D3D11Resource? resource,
            uint subresource,
            D3D11MapCpuPermission cpuPermission,
            D3D11MapOptions options)
        {
            if (resource == null)
            {
                throw new ArgumentNullException(nameof(resource));
            }

            return this.deviceContext.Map(resource.GetHandle<ID3D11Resource>(), subresource, cpuPermission, options);
        }

        /// <summary>
        /// Invalidate the pointer to a resource and reenable the GPU's access to that resource.
        /// </summary>
        /// <param name="resource">A <see cref="D3D11Resource"/> interface.</param>
        /// <param name="subresource">A subresource to be unmapped.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Unmap(D3D11Resource? resource, uint subresource)
        {
            if (resource == null)
            {
                throw new ArgumentNullException(nameof(resource));
            }

            this.deviceContext.Unmap(resource.GetHandle<ID3D11Resource>(), subresource);
        }

        /// <summary>
        /// Sets the constant buffers used by the pixel shader pipeline stage.
        /// </summary>
        /// <param name="startSlot">Index into the device's zero-based array to begin setting constant buffers to.</param>
        /// <param name="constantBuffers">Array of constant buffers.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public void PixelShaderSetConstantBuffers(uint startSlot, D3D11Buffer?[]? constantBuffers)
        {
            if (constantBuffers == null)
            {
                throw new ArgumentNullException(nameof(constantBuffers));
            }

            this.deviceContext.PixelShaderSetConstantBuffers(
                startSlot,
                (uint)constantBuffers.Length,
                Array.ConvertAll(constantBuffers, i => i?.GetHandle<ID3D11Buffer>()));
        }

        /// <summary>
        /// Bind an input-layout object to the input-assembler stage.
        /// </summary>
        /// <param name="inputLayout">The input-layout object.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void InputAssemblerSetInputLayout(D3D11InputLayout? inputLayout)
        {
            this.deviceContext.InputAssemblerSetInputLayout(inputLayout?.GetHandle<ID3D11InputLayout>());
        }

        /// <summary>
        /// Bind an array of vertex buffers to the input-assembler stage.
        /// </summary>
        /// <param name="startSlot">The first input slot for binding.</param>
        /// <param name="vertexBuffers">An array of vertex buffers.</param>
        /// <param name="strides">An array of stride values; one stride value for each buffer in the vertex-buffer array.</param>
        /// <param name="offsets">An array of offset values; one offset value for each buffer in the vertex-buffer array.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public void InputAssemblerSetVertexBuffers(uint startSlot, D3D11Buffer?[]? vertexBuffers, uint[]? strides, uint[]? offsets)
        {
            if (vertexBuffers == null)
            {
                throw new ArgumentNullException(nameof(vertexBuffers));
            }

            if (strides == null)
            {
                throw new ArgumentNullException(nameof(strides));
            }

            if (offsets == null)
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

            this.deviceContext.InputAssemblerSetVertexBuffers(
                startSlot,
                (uint)vertexBuffers.Length,
                Array.ConvertAll(vertexBuffers, i => i?.GetHandle<ID3D11Buffer>()),
                strides,
                offsets);
        }

        /// <summary>
        /// Bind an index buffer to the input-assembler stage.
        /// </summary>
        /// <param name="indexBuffer">An <see cref="D3D11Buffer"/> object, that contains indices.</param>
        /// <param name="format">The format of the data in the index buffer.</param>
        /// <param name="offset">Offset (in bytes) from the start of the index buffer to the first index to use.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void InputAssemblerSetIndexBuffer(D3D11Buffer? indexBuffer, DxgiFormat format, uint offset)
        {
            this.deviceContext.InputAssemblerSetIndexBuffer(indexBuffer?.GetHandle<ID3D11Buffer>(), format, offset);
        }

        /// <summary>
        /// Draw indexed, instanced primitives.
        /// </summary>
        /// <param name="indexCountPerInstance">Number of indices read from the index buffer for each instance.</param>
        /// <param name="instanceCount">Number of instances to draw.</param>
        /// <param name="startIndexLocation">The location of the first index read by the GPU from the index buffer.</param>
        /// <param name="baseVertexLocation">A value added to each index before reading a vertex from the vertex buffer.</param>
        /// <param name="startInstanceLocation">A value added to each index before reading per-instance data from a vertex buffer.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public void DrawIndexedInstanced(
            uint indexCountPerInstance,
            uint instanceCount,
            uint startIndexLocation,
            int baseVertexLocation,
            uint startInstanceLocation)
        {
            this.deviceContext.DrawIndexedInstanced(
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public void DrawInstanced(
            uint vertexCountPerInstance,
            uint instanceCount,
            uint startVertexLocation,
            uint startInstanceLocation)
        {
            this.deviceContext.DrawInstanced(
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public void GeometryShaderSetConstantBuffers(uint startSlot, D3D11Buffer?[]? constantBuffers)
        {
            if (constantBuffers == null)
            {
                throw new ArgumentNullException(nameof(constantBuffers));
            }

            this.deviceContext.GeometryShaderSetConstantBuffers(
                startSlot,
                (uint)constantBuffers.Length,
                Array.ConvertAll(constantBuffers, i => i?.GetHandle<ID3D11Buffer>()));
        }

        /// <summary>
        /// Set a geometry shader to the device.
        /// </summary>
        /// <param name="shader">A geometry shader.</param>
        /// <param name="classInstances">An array of class-instance interfaces.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void GeometryShaderSetShader(D3D11GeometryShader? shader, D3D11ClassInstance?[]? classInstances)
        {
            if (classInstances == null)
            {
                this.deviceContext.GeometryShaderSetShader(
                    shader?.GetHandle<ID3D11GeometryShader>(),
                    null,
                    0);
            }
            else
            {
                if (shader == null)
                {
                    throw new ArgumentNullException(nameof(shader));
                }

                this.deviceContext.GeometryShaderSetShader(
                    shader.GetHandle<ID3D11GeometryShader>(),
                    Array.ConvertAll(classInstances, i => i?.GetHandle<ID3D11ClassInstance>()),
                    (uint)classInstances.Length);
            }
        }

        /// <summary>
        /// Bind information about the primitive type, and data order that describes input data for the input assembler stage.
        /// </summary>
        /// <param name="topology">The type of primitive and ordering of the primitive data.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public void InputAssemblerSetPrimitiveTopology(D3D11PrimitiveTopology topology)
        {
            this.deviceContext.InputAssemblerSetPrimitiveTopology(topology);
        }

        /// <summary>
        /// Bind an array of shader resources to the vertex shader stage.
        /// </summary>
        /// <param name="startSlot">Index into the device's zero-based array to begin setting shader resources to.</param>
        /// <param name="shaderResourceViews">Array of shader resource view interfaces to set to the device.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public void VertexShaderSetShaderResources(uint startSlot, D3D11ShaderResourceView?[]? shaderResourceViews)
        {
            if (shaderResourceViews == null)
            {
                throw new ArgumentNullException(nameof(shaderResourceViews));
            }

            this.deviceContext.VertexShaderSetShaderResources(
                startSlot,
                (uint)shaderResourceViews.Length,
                Array.ConvertAll(shaderResourceViews, i => i?.GetHandle<ID3D11ShaderResourceView>()));
        }

        /// <summary>
        /// Set an array of sampler states to the vertex shader pipeline stage.
        /// </summary>
        /// <param name="startSlot">Index into the device's zero-based array to begin setting samplers to.</param>
        /// <param name="samplers">An array of sampler-state interfaces.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public void VertexShaderSetSamplers(uint startSlot, D3D11SamplerState?[]? samplers)
        {
            if (samplers == null)
            {
                throw new ArgumentNullException(nameof(samplers));
            }

            this.deviceContext.VertexShaderSetSamplers(
                startSlot,
                (uint)samplers.Length,
                Array.ConvertAll(samplers, i => i?.GetHandle<ID3D11SamplerState>()));
        }

        /// <summary>
        /// Mark the beginning of a series of commands.
        /// </summary>
        /// <param name="async">A <see cref="D3D11Asynchronous"/> interface.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Begin(D3D11Asynchronous? async)
        {
            if (async == null)
            {
                throw new ArgumentNullException(nameof(async));
            }

            this.deviceContext.Begin(async.GetHandle<ID3D11Asynchronous>());
        }

        /// <summary>
        /// Mark the end of a series of commands.
        /// </summary>
        /// <param name="async">A <see cref="D3D11Asynchronous"/> interface.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void End(D3D11Asynchronous? async)
        {
            if (async == null)
            {
                throw new ArgumentNullException(nameof(async));
            }

            this.deviceContext.End(async.GetHandle<ID3D11Asynchronous>());
        }

        /// <summary>
        /// Get data from the graphics processing unit (GPU) asynchronously.
        /// </summary>
        /// <param name="async">A <see cref="D3D11Asynchronous"/> interface for the object about which <c>GetData</c> retrieves data.</param>
        /// <returns>A boolean value indicating whether the operation succeeded.</returns>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool GetData(D3D11Asynchronous? async)
        {
            if (async == null)
            {
                throw new ArgumentNullException(nameof(async));
            }

            return this.deviceContext.GetData(async.GetHandle<ID3D11Asynchronous>(), IntPtr.Zero, 0U, D3D11AsyncGetDataOptions.None);
        }

        /// <summary>
        /// Get data from the graphics processing unit (GPU) asynchronously.
        /// </summary>
        /// <param name="async">A <see cref="D3D11Asynchronous"/> interface for the object about which <c>GetData</c> retrieves data.</param>
        /// <param name="options">Optional flags.</param>
        /// <returns>A boolean value indicating whether the operation succeeded.</returns>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool GetData(D3D11Asynchronous? async, D3D11AsyncGetDataOptions options)
        {
            if (async == null)
            {
                throw new ArgumentNullException(nameof(async));
            }

            return this.deviceContext.GetData(async.GetHandle<ID3D11Asynchronous>(), IntPtr.Zero, 0U, options);
        }

        /// <summary>
        /// Get data from the graphics processing unit (GPU) asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of data.</typeparam>
        /// <param name="async">A <see cref="D3D11Asynchronous"/> interface for the object about which <c>GetData</c> retrieves data.</param>
        /// <param name="data">The data.</param>
        /// <returns>A boolean value indicating whether the operation succeeded.</returns>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool GetData<T>(D3D11Asynchronous? async, out T data)
            where T : struct
        {
            if (async == null)
            {
                throw new ArgumentNullException(nameof(async));
            }

            int dataSize = Marshal.SizeOf(typeof(T));
            IntPtr dataPtr = Marshal.AllocHGlobal(dataSize);

            try
            {
                bool result = this.deviceContext.GetData(async.GetHandle<ID3D11Asynchronous>(), dataPtr, (uint)dataSize, D3D11AsyncGetDataOptions.None);

                data = (T)Marshal.PtrToStructure(dataPtr, typeof(T))!;
                return result;
            }
            finally
            {
                Marshal.FreeHGlobal(dataPtr);
            }
        }

        /// <summary>
        /// Get data from the graphics processing unit (GPU) asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of data.</typeparam>
        /// <param name="async">A <see cref="D3D11Asynchronous"/> interface for the object about which <c>GetData</c> retrieves data.</param>
        /// <param name="options">Optional flags.</param>
        /// <param name="data">The data.</param>
        /// <returns>A boolean value indicating whether the operation succeeded.</returns>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "2#", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool GetData<T>(D3D11Asynchronous? async, D3D11AsyncGetDataOptions options, out T data)
            where T : struct
        {
            if (async == null)
            {
                throw new ArgumentNullException(nameof(async));
            }

            int dataSize = Marshal.SizeOf(typeof(T));
            IntPtr dataPtr = Marshal.AllocHGlobal(dataSize);

            try
            {
                bool result = this.deviceContext.GetData(async.GetHandle<ID3D11Asynchronous>(), dataPtr, (uint)dataSize, options);

                data = (T)Marshal.PtrToStructure(dataPtr, typeof(T))!;
                return result;
            }
            finally
            {
                Marshal.FreeHGlobal(dataPtr);
            }
        }

        /// <summary>
        /// Set a rendering predicate.
        /// </summary>
        /// <param name="predicate">A predicate.</param>
        /// <param name="value">A value indicating whether rendering will be affected by when the predicate's conditions are met or not met.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetPredication(D3D11Predicate? predicate, bool value)
        {
            this.deviceContext.SetPredication(predicate?.GetHandle<ID3D11Predicate>(), value);
        }

        /// <summary>
        /// Bind an array of shader resources to the geometry shader stage.
        /// </summary>
        /// <param name="startSlot">Index into the device's zero-based array to begin setting shader resources to.</param>
        /// <param name="shaderResourceViews">Array of shader resource view interfaces to set to the device.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public void GeometryShaderSetShaderResources(uint startSlot, D3D11ShaderResourceView?[]? shaderResourceViews)
        {
            if (shaderResourceViews == null)
            {
                throw new ArgumentNullException(nameof(shaderResourceViews));
            }

            this.deviceContext.GeometryShaderSetShaderResources(
                startSlot,
                (uint)shaderResourceViews.Length,
                Array.ConvertAll(shaderResourceViews, i => i?.GetHandle<ID3D11ShaderResourceView>()));
        }

        /// <summary>
        /// Set an array of sampler states to the geometry shader pipeline stage.
        /// </summary>
        /// <param name="startSlot">Index into the device's zero-based array to begin setting samplers to.</param>
        /// <param name="samplers">An array of sampler-state interfaces.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public void GeometryShaderSetSamplers(uint startSlot, D3D11SamplerState?[]? samplers)
        {
            if (samplers == null)
            {
                throw new ArgumentNullException(nameof(samplers));
            }

            this.deviceContext.GeometryShaderSetSamplers(
                startSlot,
                (uint)samplers.Length,
                Array.ConvertAll(samplers, i => i?.GetHandle<ID3D11SamplerState>()));
        }

        /// <summary>
        /// Bind one or more render targets atomically and the depth-stencil buffer to the output-merger stage.
        /// </summary>
        /// <param name="renderTargetViews">The render targets to bind to the device.</param>
        /// <param name="depthStencilView">The depth-stencil view to bind to the device.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void OutputMergerSetRenderTargets(D3D11RenderTargetView?[]? renderTargetViews, D3D11DepthStencilView? depthStencilView)
        {
            this.deviceContext.OutputMergerSetRenderTargets(
                renderTargetViews == null ? 0 : (uint)renderTargetViews.Length,
                renderTargetViews == null ? null : Array.ConvertAll(renderTargetViews, i => i?.GetHandle<ID3D11RenderTargetView>()),
                depthStencilView?.GetHandle<ID3D11DepthStencilView>());
        }

        /// <summary>
        /// Binds resources to the output-merger stage.
        /// </summary>
        /// <param name="renderTargetViews">The render targets to bind to the device.</param>
        /// <param name="depthStencilView">The depth-stencil view to bind to the device.</param>
        /// <param name="uavStartSlot">Index into a zero-based array to begin setting unordered-access views.</param>
        /// <param name="unorderedAccessViews">The unordered-access views to bind to the device.</param>
        /// <param name="uavInitialCounts">An array of append and consume buffer offsets. A value of <value>-1</value> indicates to keep the current offset.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void OutputMergerSetRenderTargetsAndUnorderedAccessViews(
            D3D11RenderTargetView?[]? renderTargetViews,
            D3D11DepthStencilView? depthStencilView,
            uint uavStartSlot,
            D3D11UnorderedAccessView?[]? unorderedAccessViews,
            uint[]? uavInitialCounts)
        {
            if (unorderedAccessViews != null)
            {
                if (uavInitialCounts == null)
                {
                    throw new ArgumentNullException(nameof(uavInitialCounts));
                }

                if (uavInitialCounts.Length != unorderedAccessViews.Length)
                {
                    throw new ArgumentOutOfRangeException(nameof(uavInitialCounts));
                }
            }

            this.deviceContext.OutputMergerSetRenderTargetsAndUnorderedAccessViews(
                renderTargetViews == null ? 0 : (uint)renderTargetViews.Length,
                renderTargetViews == null ? null : Array.ConvertAll(renderTargetViews, i => i?.GetHandle<ID3D11RenderTargetView>()),
                depthStencilView?.GetHandle<ID3D11DepthStencilView>(),
                uavStartSlot,
                unorderedAccessViews == null ? 0 : (uint)unorderedAccessViews.Length,
                unorderedAccessViews == null ? null : Array.ConvertAll(unorderedAccessViews, i => i?.GetHandle<ID3D11UnorderedAccessView>()),
                unorderedAccessViews == null ? null : uavInitialCounts);
        }

        /// <summary>
        /// Set the blend state of the output-merger stage.
        /// </summary>
        /// <param name="blendState">A blend-state interface.</param>
        /// <param name="blendFactor">Array of blend factors, one for each RGBA component. The blend factors modulate values for the pixel shader, render target, or both.</param>
        /// <param name="sampleMask">32-bit sample coverage. The default value is <value>0xffffffff</value>.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void OutputMergerSetBlendState(D3D11BlendState? blendState, float[]? blendFactor, uint sampleMask)
        {
            if (blendFactor != null && blendFactor.Length != 4)
            {
                throw new ArgumentOutOfRangeException(nameof(blendFactor));
            }

            this.deviceContext.OutputMergerSetBlendState(
                blendState?.GetHandle<ID3D11BlendState>(),
                blendFactor,
                sampleMask);
        }

        /// <summary>
        /// Sets the depth-stencil state of the output-merger stage.
        /// </summary>
        /// <param name="depthStencilState">A depth-stencil state interface.</param>
        /// <param name="stencilReference">Reference value to perform against when doing a depth-stencil test.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void OutputMergerSetDepthStencilState(D3D11DepthStencilState? depthStencilState, uint stencilReference)
        {
            this.deviceContext.OutputMergerSetDepthStencilState(
                depthStencilState?.GetHandle<ID3D11DepthStencilState>(),
                stencilReference);
        }

        /// <summary>
        /// Reference value to perform against when doing a depth-stencil test.
        /// </summary>
        /// <param name="targets">The array of output buffers to bind to the device.</param>
        /// <param name="offsets">Array of offsets to the output buffers.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public void StreamOutputSetTargets(D3D11Buffer?[]? targets, uint[]? offsets)
        {
            if (targets != null)
            {
                if (offsets == null)
                {
                    throw new ArgumentNullException(nameof(offsets));
                }

                if (offsets.Length != targets.Length)
                {
                    throw new ArgumentOutOfRangeException(nameof(offsets));
                }
            }

            this.deviceContext.StreamOutputSetTargets(
                targets == null ? 0 : (uint)targets.Length,
                targets == null ? null : Array.ConvertAll(targets, i => i?.GetHandle<ID3D11Buffer>()),
                targets == null ? null : offsets);
        }

        /// <summary>
        /// Draw geometry of an unknown size.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public void DrawAuto()
        {
            this.deviceContext.DrawAuto();
        }

        /// <summary>
        /// Draw indexed, instanced, GPU-generated primitives.
        /// </summary>
        /// <param name="bufferForArgs">A buffer containing the GPU generated primitives.</param>
        /// <param name="alignedByteOffsetForArgs">Offset to the start of the GPU generated primitives.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "byte", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawIndexedInstancedIndirect(D3D11Buffer? bufferForArgs, uint alignedByteOffsetForArgs)
        {
            if (bufferForArgs == null)
            {
                throw new ArgumentNullException(nameof(bufferForArgs));
            }

            this.deviceContext.DrawIndexedInstancedIndirect(bufferForArgs.GetHandle<ID3D11Buffer>(), alignedByteOffsetForArgs);
        }

        /// <summary>
        /// Draw instanced, GPU-generated primitives.
        /// </summary>
        /// <param name="bufferForArgs">A buffer containing the GPU generated primitives.</param>
        /// <param name="alignedByteOffsetForArgs">Offset to the start of the GPU generated primitives.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "byte", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawInstancedIndirect(D3D11Buffer? bufferForArgs, uint alignedByteOffsetForArgs)
        {
            if (bufferForArgs == null)
            {
                throw new ArgumentNullException(nameof(bufferForArgs));
            }

            this.deviceContext.DrawInstancedIndirect(bufferForArgs.GetHandle<ID3D11Buffer>(), alignedByteOffsetForArgs);
        }

        /// <summary>
        /// Execute a command list from a thread group.
        /// </summary>
        /// <param name="threadGroupCountX">The number of groups dispatched in the x direction.</param>
        /// <param name="threadGroupCountY">The number of groups dispatched in the y direction.</param>
        /// <param name="threadGroupCountZ">The number of groups dispatched in the z direction.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public void Dispatch(uint threadGroupCountX, uint threadGroupCountY, uint threadGroupCountZ)
        {
            this.deviceContext.Dispatch(threadGroupCountX, threadGroupCountY, threadGroupCountZ);
        }

        /// <summary>
        /// Execute a command list over one or more thread groups.
        /// </summary>
        /// <param name="bufferForArgs">A buffer, which must be loaded with data that matches the argument list.</param>
        /// <param name="alignedByteOffsetForArgs">A byte-aligned offset between the start of the buffer and the arguments.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "byte", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DispatchIndirect(D3D11Buffer? bufferForArgs, uint alignedByteOffsetForArgs)
        {
            if (bufferForArgs == null)
            {
                throw new ArgumentNullException(nameof(bufferForArgs));
            }

            this.deviceContext.DispatchIndirect(bufferForArgs.GetHandle<ID3D11Buffer>(), alignedByteOffsetForArgs);
        }

        /// <summary>
        /// Set the rasterizer state for the rasterizer stage of the pipeline.
        /// </summary>
        /// <param name="rasterizerState">A rasterizer-state interface.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void RasterizerStageSetState(D3D11RasterizerState? rasterizerState)
        {
            this.deviceContext.RasterizerStageSetState(rasterizerState?.GetHandle<ID3D11RasterizerState>());
        }

        /// <summary>
        /// Bind an array of viewports to the rasterizer stage of the pipeline.
        /// </summary>
        /// <param name="viewports">An array of <see cref="D3D11Viewport"/> structures to bind to the device.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public void RasterizerStageSetViewports(D3D11Viewport[]? viewports)
        {
            if (viewports == null)
            {
                throw new ArgumentNullException(nameof(viewports));
            }

            this.deviceContext.RasterizerStageSetViewports((uint)viewports.Length, viewports);
        }

        /// <summary>
        /// Bind an array of scissor rectangles to the rasterizer stage.
        /// </summary>
        /// <param name="rects">An array of scissor rectangles.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public void RasterizerStageSetScissorRects(D3D11Rect[]? rects)
        {
            if (rects == null)
            {
                throw new ArgumentNullException(nameof(rects));
            }

            this.deviceContext.RasterizerStageSetScissorRects((uint)rects.Length, rects);
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
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopySubresourceRegion(
            D3D11Resource? destinationResource,
            uint destinationSubresource,
            uint destinationX,
            uint destinationY,
            uint destinationZ,
            D3D11Resource? sourceResource,
            uint sourceSubresource,
            D3D11Box sourceBox)
        {
            if (destinationResource == null)
            {
                throw new ArgumentNullException(nameof(destinationResource));
            }

            if (sourceResource == null)
            {
                throw new ArgumentNullException(nameof(sourceResource));
            }

            this.deviceContext.CopySubresourceRegion(
                destinationResource.GetHandle<ID3D11Resource>(),
                destinationSubresource,
                destinationX,
                destinationY,
                destinationZ,
                sourceResource.GetHandle<ID3D11Resource>(),
                sourceSubresource,
                ref sourceBox);
        }

        /// <summary>
        /// Copy the entire contents of the source resource to the destination resource using the GPU.
        /// </summary>
        /// <param name="destination">The destination resource.</param>
        /// <param name="source">The source resource.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyResource(D3D11Resource? destination, D3D11Resource? source)
        {
            if (destination == null)
            {
                throw new ArgumentNullException(nameof(destination));
            }

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            this.deviceContext.CopyResource(destination.GetHandle<ID3D11Resource>(), source.GetHandle<ID3D11Resource>());
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
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void UpdateSubresource<T>(
            D3D11Resource? destinationResource,
            uint destinationSubresource,
            D3D11Box? destinationBox,
            T sourceData,
            uint sourceRowPitch,
            uint sourceDepthPitch)
            where T : struct
        {
            if (destinationResource == null)
            {
                throw new ArgumentNullException(nameof(destinationResource));
            }

            int sourceDataSize = Marshal.SizeOf(typeof(T));
            IntPtr sourceDataPtr = Marshal.AllocHGlobal(sourceDataSize);

            try
            {
                Marshal.StructureToPtr(sourceData, sourceDataPtr, false);

                if (destinationBox == null)
                {
                    this.deviceContext.UpdateSubresource(
                        destinationResource.GetHandle<ID3D11Resource>(),
                        destinationSubresource,
                        IntPtr.Zero,
                        sourceDataPtr,
                        sourceRowPitch,
                        sourceDepthPitch);
                }
                else
                {
                    GCHandle destinationBoxHandle = GCHandle.Alloc(destinationBox.Value, GCHandleType.Pinned);

                    try
                    {
                        this.deviceContext.UpdateSubresource(
                            destinationResource.GetHandle<ID3D11Resource>(),
                            destinationSubresource,
                            destinationBoxHandle.AddrOfPinnedObject(),
                            sourceDataPtr,
                            sourceRowPitch,
                            sourceDepthPitch);
                    }
                    finally
                    {
                        destinationBoxHandle.Free();
                    }
                }
            }
            finally
            {
                Marshal.FreeHGlobal(sourceDataPtr);
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
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void UpdateSubresource<T>(
            D3D11Resource? destinationResource,
            uint destinationSubresource,
            D3D11Box? destinationBox,
            T[] sourceData,
            uint sourceRowPitch,
            uint sourceDepthPitch)
            where T : struct
        {
            if (destinationResource == null)
            {
                throw new ArgumentNullException(nameof(destinationResource));
            }

            if (sourceData == null)
            {
                throw new ArgumentNullException(nameof(sourceData));
            }

            if (sourceData.Length == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(sourceData));
            }

            int sourceDataSize = Marshal.SizeOf(typeof(T));
            IntPtr sourceDataPtr = Marshal.AllocHGlobal(sourceDataSize * sourceData.Length);

            try
            {
                for (int i = 0; i < sourceData.Length; i++)
                {
                    Marshal.StructureToPtr(sourceData[i], IntPtr.Add(sourceDataPtr, sourceDataSize * i), false);
                }

                if (destinationBox == null)
                {
                    this.deviceContext.UpdateSubresource(
                        destinationResource.GetHandle<ID3D11Resource>(),
                        destinationSubresource,
                        IntPtr.Zero,
                        sourceDataPtr,
                        sourceRowPitch,
                        sourceDepthPitch);
                }
                else
                {
                    GCHandle destinationBoxHandle = GCHandle.Alloc(destinationBox.Value, GCHandleType.Pinned);

                    try
                    {
                        this.deviceContext.UpdateSubresource(
                            destinationResource.GetHandle<ID3D11Resource>(),
                            destinationSubresource,
                            destinationBoxHandle.AddrOfPinnedObject(),
                            sourceDataPtr,
                            sourceRowPitch,
                            sourceDepthPitch);
                    }
                    finally
                    {
                        destinationBoxHandle.Free();
                    }
                }
            }
            finally
            {
                Marshal.FreeHGlobal(sourceDataPtr);
            }
        }

        /// <summary>
        /// Copies data from a buffer holding variable length data.
        /// </summary>
        /// <param name="destinationBuffer">The destination buffer.</param>
        /// <param name="destinationAlignedByteOffset">Offset from the start of the buffer to write 32-bit UINT structure (vertex) count.</param>
        /// <param name="sourceView">A structured buffer resource.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "byte", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyStructureCount(D3D11Buffer? destinationBuffer, uint destinationAlignedByteOffset, D3D11UnorderedAccessView? sourceView)
        {
            if (destinationBuffer == null)
            {
                throw new ArgumentNullException(nameof(destinationBuffer));
            }

            if (sourceView == null)
            {
                throw new ArgumentNullException(nameof(sourceView));
            }

            this.deviceContext.CopyStructureCount(
                destinationBuffer.GetHandle<ID3D11Buffer>(),
                destinationAlignedByteOffset,
                sourceView.GetHandle<ID3D11UnorderedAccessView>());
        }

        /// <summary>
        /// Set all the elements in a render target to one value.
        /// </summary>
        /// <param name="renderTargetView">The render target.</param>
        /// <param name="colorRgba">A 4-component array that represents the color to fill the render target with.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ClearRenderTargetView(D3D11RenderTargetView? renderTargetView, float[]? colorRgba)
        {
            if (renderTargetView == null)
            {
                throw new ArgumentNullException(nameof(renderTargetView));
            }

            if (colorRgba == null)
            {
                throw new ArgumentNullException(nameof(colorRgba));
            }

            if (colorRgba.Length != 4)
            {
                throw new ArgumentOutOfRangeException(nameof(colorRgba));
            }

            this.deviceContext.ClearRenderTargetView(renderTargetView.GetHandle<ID3D11RenderTargetView>(), colorRgba);
        }

        /// <summary>
        /// Clears an unordered access resource with bit-precise values.
        /// </summary>
        /// <param name="unorderedAccessView">The unordered access resource to clear.</param>
        /// <param name="values">Values to copy to corresponding channels.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ClearUnorderedAccessViewUInt(D3D11UnorderedAccessView? unorderedAccessView, uint[]? values)
        {
            if (unorderedAccessView == null)
            {
                throw new ArgumentNullException(nameof(unorderedAccessView));
            }

            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            if (values.Length != 4)
            {
                throw new ArgumentOutOfRangeException(nameof(values));
            }

            this.deviceContext.ClearUnorderedAccessViewUInt(unorderedAccessView.GetHandle<ID3D11UnorderedAccessView>(), values);
        }

        /// <summary>
        /// Clears an unordered access resource with a float value.
        /// </summary>
        /// <param name="unorderedAccessView">The unordered access resource to clear.</param>
        /// <param name="values">Values to copy to corresponding channels.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ClearUnorderedAccessViewFloat(D3D11UnorderedAccessView? unorderedAccessView, float[]? values)
        {
            if (unorderedAccessView == null)
            {
                throw new ArgumentNullException(nameof(unorderedAccessView));
            }

            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            if (values.Length != 4)
            {
                throw new ArgumentOutOfRangeException(nameof(values));
            }

            this.deviceContext.ClearUnorderedAccessViewFloat(unorderedAccessView.GetHandle<ID3D11UnorderedAccessView>(), values);
        }

        /// <summary>
        /// Clears the depth-stencil resource.
        /// </summary>
        /// <param name="depthStencilView">The depth stencil to be cleared.</param>
        /// <param name="clearOptions">Identify the type of data to clear.</param>
        /// <param name="depth">Clear the depth buffer with this value. This value will be clamped between 0 and 1.</param>
        /// <param name="stencil">Clear the stencil buffer with this value.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ClearDepthStencilView(D3D11DepthStencilView? depthStencilView, D3D11ClearOptions clearOptions, float depth, byte stencil)
        {
            if (depthStencilView == null)
            {
                throw new ArgumentNullException(nameof(depthStencilView));
            }

            this.deviceContext.ClearDepthStencilView(
                depthStencilView.GetHandle<ID3D11DepthStencilView>(),
                clearOptions,
                depth,
                stencil);
        }

        /// <summary>
        /// Generates mipmaps for the given shader resource.
        /// </summary>
        /// <param name="shaderResourceView">The shader resource.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void GenerateMips(D3D11ShaderResourceView? shaderResourceView)
        {
            if (shaderResourceView == null)
            {
                throw new ArgumentNullException(nameof(shaderResourceView));
            }

            this.deviceContext.GenerateMips(shaderResourceView.GetHandle<ID3D11ShaderResourceView>());
        }

        /// <summary>
        /// Sets the minimum level-of-detail (LOD) for a resource.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <param name="minLod">The level-of-detail, which ranges between 0 and the maximum number of mipmap levels of the resource.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetResourceMinLod(D3D11Resource? resource, float minLod)
        {
            if (resource == null)
            {
                throw new ArgumentNullException(nameof(resource));
            }

            this.deviceContext.SetResourceMinLod(resource.GetHandle<ID3D11Resource>(), minLod);
        }

        /// <summary>
        /// Gets the minimum level-of-detail (LOD).
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <returns>The minimum LOD.</returns>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float GetResourceMinLod(D3D11Resource? resource)
        {
            if (resource == null)
            {
                throw new ArgumentNullException(nameof(resource));
            }

            return this.deviceContext.GetResourceMinLod(resource.GetHandle<ID3D11Resource>());
        }

        /// <summary>
        /// Copy a multisampled resource into a non-multisampled resource.
        /// </summary>
        /// <param name="destinationResource">Destination resource.</param>
        /// <param name="destinationSubresource">A zero-based index, that identifies the destination subresource.</param>
        /// <param name="sourceResource">Source resource.</param>
        /// <param name="sourceSubresource">The source subresource of the source resource.</param>
        /// <param name="format">Indicates how the multisampled resource will be resolved to a single-sampled resource.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ResolveSubresource(
            D3D11Resource? destinationResource,
            uint destinationSubresource,
            D3D11Resource? sourceResource,
            uint sourceSubresource,
            DxgiFormat format)
        {
            if (destinationResource == null)
            {
                throw new ArgumentNullException(nameof(destinationResource));
            }

            if (sourceResource == null)
            {
                throw new ArgumentNullException(nameof(sourceResource));
            }

            this.deviceContext.ResolveSubresource(
                destinationResource.GetHandle<ID3D11Resource>(),
                destinationSubresource,
                sourceResource.GetHandle<ID3D11Resource>(),
                sourceSubresource,
                format);
        }

        /// <summary>
        /// Queues commands from a command list onto a device.
        /// </summary>
        /// <param name="commandList">A command list.</param>
        /// <param name="restoreContextState">A value indicating whether the target context state is saved prior to and restored after the execution of a command list.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ExecuteCommandList(D3D11CommandList? commandList, bool restoreContextState)
        {
            if (commandList == null)
            {
                throw new ArgumentNullException(nameof(commandList));
            }

            this.deviceContext.ExecuteCommandList(commandList.GetHandle<ID3D11CommandList>(), restoreContextState);
        }

        /// <summary>
        /// Bind an array of shader resources to the hull shader stage.
        /// </summary>
        /// <param name="startSlot">Index into the device's zero-based array to begin setting shader resources to.</param>
        /// <param name="shaderResourceViews">Array of shader resource view interfaces to set to the device.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public void HullShaderSetShaderResources(uint startSlot, D3D11ShaderResourceView?[]? shaderResourceViews)
        {
            if (shaderResourceViews == null)
            {
                throw new ArgumentNullException(nameof(shaderResourceViews));
            }

            this.deviceContext.HullShaderSetShaderResources(
                startSlot,
                (uint)shaderResourceViews.Length,
                Array.ConvertAll(shaderResourceViews, i => i?.GetHandle<ID3D11ShaderResourceView>()));
        }

        /// <summary>
        /// Set a hull shader to the device.
        /// </summary>
        /// <param name="hullShader">A hull shader.</param>
        /// <param name="classInstances">An array of class-instance interfaces.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void HullShaderSetShader(D3D11HullShader? hullShader, D3D11ClassInstance?[]? classInstances)
        {
            if (classInstances == null)
            {
                this.deviceContext.HullShaderSetShader(
                    hullShader?.GetHandle<ID3D11HullShader>(),
                    null,
                    0);
            }
            else
            {
                if (hullShader == null)
                {
                    throw new ArgumentNullException(nameof(hullShader));
                }

                this.deviceContext.HullShaderSetShader(
                    hullShader.GetHandle<ID3D11HullShader>(),
                    Array.ConvertAll(classInstances, i => i?.GetHandle<ID3D11ClassInstance>()),
                    (uint)classInstances.Length);
            }
        }

        /// <summary>
        /// Set an array of sampler states to the hull shader stage.
        /// </summary>
        /// <param name="startSlot">Index into the zero-based array to begin setting samplers to.</param>
        /// <param name="samplers">An array of sampler-state interfaces.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public void HullShaderSetSamplers(uint startSlot, D3D11SamplerState?[]? samplers)
        {
            if (samplers == null)
            {
                throw new ArgumentNullException(nameof(samplers));
            }

            this.deviceContext.HullShaderSetSamplers(
                startSlot,
                (uint)samplers.Length,
                Array.ConvertAll(samplers, i => i?.GetHandle<ID3D11SamplerState>()));
        }

        /// <summary>
        /// Set the constant buffers used by the hull shader stage.
        /// </summary>
        /// <param name="startSlot">Index into the device's zero-based array to begin setting constant buffers to.</param>
        /// <param name="constantBuffers">Array of constant buffers being given to the device.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public void HullShaderSetConstantBuffers(uint startSlot, D3D11Buffer?[]? constantBuffers)
        {
            if (constantBuffers == null)
            {
                throw new ArgumentNullException(nameof(constantBuffers));
            }

            this.deviceContext.HullShaderSetConstantBuffers(
                startSlot,
                (uint)constantBuffers.Length,
                Array.ConvertAll(constantBuffers, i => i?.GetHandle<ID3D11Buffer>()));
        }

        /// <summary>
        /// Bind an array of shader resources to the domain shader stage.
        /// </summary>
        /// <param name="startSlot">Index into the device's zero-based array to begin setting shader resources to.</param>
        /// <param name="shaderResourceViews">Array of shader resource view interfaces to set to the device.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public void DomainShaderSetShaderResources(uint startSlot, D3D11ShaderResourceView?[]? shaderResourceViews)
        {
            if (shaderResourceViews == null)
            {
                throw new ArgumentNullException(nameof(shaderResourceViews));
            }

            this.deviceContext.DomainShaderSetShaderResources(
                startSlot,
                (uint)shaderResourceViews.Length,
                Array.ConvertAll(shaderResourceViews, i => i?.GetHandle<ID3D11ShaderResourceView>()));
        }

        /// <summary>
        /// Set a domain shader to the device.
        /// </summary>
        /// <param name="domainShader">A domain shader.</param>
        /// <param name="classInstances">An array of class-instance interfaces.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DomainShaderSetShader(D3D11DomainShader? domainShader, D3D11ClassInstance?[]? classInstances)
        {
            if (classInstances == null)
            {
                this.deviceContext.DomainShaderSetShader(
                    domainShader?.GetHandle<ID3D11DomainShader>(),
                    null,
                    0);
            }
            else
            {
                if (domainShader == null)
                {
                    throw new ArgumentNullException(nameof(domainShader));
                }

                this.deviceContext.DomainShaderSetShader(
                    domainShader.GetHandle<ID3D11DomainShader>(),
                    Array.ConvertAll(classInstances, i => i?.GetHandle<ID3D11ClassInstance>()),
                    (uint)classInstances.Length);
            }
        }

        /// <summary>
        /// Set an array of sampler states to the domain shader stage.
        /// </summary>
        /// <param name="startSlot">Index into the device's zero-based array to begin setting samplers to.</param>
        /// <param name="samplers">An array of sampler-state interfaces.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public void DomainShaderSetSamplers(uint startSlot, D3D11SamplerState?[]? samplers)
        {
            if (samplers == null)
            {
                throw new ArgumentNullException(nameof(samplers));
            }

            this.deviceContext.DomainShaderSetSamplers(
                startSlot,
                (uint)samplers.Length,
                Array.ConvertAll(samplers, i => i?.GetHandle<ID3D11SamplerState>()));
        }

        /// <summary>
        /// Sets the constant buffers used by the domain shader stage.
        /// </summary>
        /// <param name="startSlot">Index into the zero-based array to begin setting constant buffers to.</param>
        /// <param name="constantBuffers">Array of constant buffers being given to the device.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public void DomainShaderSetConstantBuffers(uint startSlot, D3D11Buffer?[]? constantBuffers)
        {
            if (constantBuffers == null)
            {
                throw new ArgumentNullException(nameof(constantBuffers));
            }

            this.deviceContext.DomainShaderSetConstantBuffers(
                startSlot,
                (uint)constantBuffers.Length,
                Array.ConvertAll(constantBuffers, i => i?.GetHandle<ID3D11Buffer>()));
        }

        /// <summary>
        /// Bind an array of shader resources to the compute shader stage.
        /// </summary>
        /// <param name="startSlot">Index into the device's zero-based array to begin setting shader resources to.</param>
        /// <param name="shaderResourceViews">Array of shader resource view interfaces to set to the device.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public void ComputeShaderSetShaderResources(uint startSlot, D3D11ShaderResourceView?[]? shaderResourceViews)
        {
            if (shaderResourceViews == null)
            {
                throw new ArgumentNullException(nameof(shaderResourceViews));
            }

            this.deviceContext.ComputeShaderSetShaderResources(
                startSlot,
                (uint)shaderResourceViews.Length,
                Array.ConvertAll(shaderResourceViews, i => i?.GetHandle<ID3D11ShaderResourceView>()));
        }

        /// <summary>
        /// Sets an array of views for an unordered resource.
        /// </summary>
        /// <param name="startSlot">Index of the first element in the zero-based array to begin setting.</param>
        /// <param name="unorderedAccessViews">An array of unordered access views to be set.</param>
        /// <param name="uavInitialCounts">An array of append and consume buffer offsets. A value of <value>-1</value> indicates to keep the current offset.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public void ComputeShaderSetUnorderedAccessViews(uint startSlot, D3D11UnorderedAccessView?[]? unorderedAccessViews, uint[]? uavInitialCounts)
        {
            if (unorderedAccessViews == null)
            {
                throw new ArgumentNullException(nameof(unorderedAccessViews));
            }

            if (uavInitialCounts == null)
            {
                throw new ArgumentNullException(nameof(uavInitialCounts));
            }

            if (uavInitialCounts.Length != unorderedAccessViews.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(uavInitialCounts));
            }

            this.deviceContext.ComputeShaderSetUnorderedAccessViews(
                startSlot,
                (uint)unorderedAccessViews.Length,
                Array.ConvertAll(unorderedAccessViews, i => i?.GetHandle<ID3D11UnorderedAccessView>()),
                uavInitialCounts);
        }

        /// <summary>
        /// Set a compute shader to the device.
        /// </summary>
        /// <param name="computeShader">A compute shader.</param>
        /// <param name="classInstances">An array of class-instance interfaces.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ComputeShaderSetShader(D3D11ComputeShader? computeShader, D3D11ClassInstance?[]? classInstances)
        {
            if (classInstances == null)
            {
                this.deviceContext.ComputeShaderSetShader(
                    computeShader?.GetHandle<ID3D11ComputeShader>(),
                    null,
                    0);
            }
            else
            {
                if (computeShader == null)
                {
                    throw new ArgumentNullException(nameof(computeShader));
                }

                this.deviceContext.ComputeShaderSetShader(
                    computeShader.GetHandle<ID3D11ComputeShader>(),
                    Array.ConvertAll(classInstances, i => i?.GetHandle<ID3D11ClassInstance>()),
                    (uint)classInstances.Length);
            }
        }

        /// <summary>
        /// Set an array of sampler states to the compute shader stage.
        /// </summary>
        /// <param name="startSlot">Index into the device's zero-based array to begin setting samplers to.</param>
        /// <param name="samplers">An array of sampler-state interfaces.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public void ComputeShaderSetSamplers(uint startSlot, D3D11SamplerState?[]? samplers)
        {
            if (samplers == null)
            {
                throw new ArgumentNullException(nameof(samplers));
            }

            this.deviceContext.ComputeShaderSetSamplers(
                startSlot,
                (uint)samplers.Length,
                Array.ConvertAll(samplers, i => i?.GetHandle<ID3D11SamplerState>()));
        }

        /// <summary>
        /// Sets the constant buffers used by the compute shader stage.
        /// </summary>
        /// <param name="startSlot">Index into the zero-based array to begin setting constant buffers to.</param>
        /// <param name="constantBuffers">Array of constant buffers.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public void ComputeShaderSetConstantBuffers(uint startSlot, D3D11Buffer?[]? constantBuffers)
        {
            if (constantBuffers == null)
            {
                throw new ArgumentNullException(nameof(constantBuffers));
            }

            this.deviceContext.ComputeShaderSetConstantBuffers(
                startSlot,
                (uint)constantBuffers.Length,
                Array.ConvertAll(constantBuffers, i => i?.GetHandle<ID3D11Buffer>()));
        }

        /// <summary>
        /// Get the constant buffers used by the vertex shader pipeline stage.
        /// </summary>
        /// <param name="startSlot">Index into the device's zero-based array to begin retrieving constant buffers from.</param>
        /// <param name="numBuffers">Number of buffers to retrieve.</param>
        /// <returns>Array of constant buffer interface pointers to be returned.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public D3D11Buffer?[] VertexShaderGetConstantBuffers(uint startSlot, uint numBuffers)
        {
            object?[] constantBuffers = new object?[numBuffers];
            this.deviceContext.VertexShaderGetConstantBuffers(startSlot, numBuffers, constantBuffers);
            return Array.ConvertAll(constantBuffers, i => i == null ? null : new D3D11Buffer((ID3D11Buffer)i));
        }

        /// <summary>
        /// Get the pixel shader resources.
        /// </summary>
        /// <param name="startSlot">Index into the device's zero-based array to begin getting shader resources from.</param>
        /// <param name="numViews">The number of resources to get from the device.</param>
        /// <returns>Array of shader resource view interfaces to be returned by the device.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public D3D11ShaderResourceView?[] PixelShaderGetShaderResources(uint startSlot, uint numViews)
        {
            object?[] shaderResourceViews = new object?[numViews];
            this.deviceContext.PixelShaderGetShaderResources(startSlot, numViews, shaderResourceViews);
            return Array.ConvertAll(shaderResourceViews, i => i == null ? null : new D3D11ShaderResourceView((ID3D11ShaderResourceView)i));
        }

        /// <summary>
        /// Get the pixel shader currently set on the device.
        /// </summary>
        /// <returns>A pixel shader.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public D3D11PixelShader? PixelShaderGetShader()
        {
            uint numClassInstances = 0;
            this.deviceContext.PixelShaderGetShader(out ID3D11PixelShader? pixelShader, null, ref numClassInstances);

            if (pixelShader == null)
            {
                return null;
            }

            return new D3D11PixelShader(pixelShader);
        }

        /// <summary>
        /// Get the pixel shader currently set on the device.
        /// </summary>
        /// <param name="numClassInstances">The number of class-instance elements in the array.</param>
        /// <param name="classInstances">An array of class instance interfaces.</param>
        /// <returns>A pixel shader.</returns>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11PixelShader? PixelShaderGetShader(uint numClassInstances, out D3D11ClassInstance?[] classInstances)
        {
            object?[] objects1 = new object?[numClassInstances];
            this.deviceContext.PixelShaderGetShader(out ID3D11PixelShader? pixelShader, objects1, ref numClassInstances);
            object?[] objects2 = new object?[numClassInstances];
            Array.Copy(objects1, objects2, numClassInstances);
            classInstances = Array.ConvertAll(objects2, i => i == null ? null : new D3D11ClassInstance((ID3D11ClassInstance)i));

            if (pixelShader == null)
            {
                return null;
            }

            return new D3D11PixelShader(pixelShader);
        }

        /// <summary>
        /// Get an array of sampler states from the pixel shader pipeline stage.
        /// </summary>
        /// <param name="startSlot">Index into a zero-based array to begin getting samplers from.</param>
        /// <param name="numSamplers">Number of samplers to get from a device context.</param>
        /// <returns>Array of sampler-state interface pointers.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public D3D11SamplerState?[] PixelShaderGetSamplers(uint startSlot, uint numSamplers)
        {
            object?[] samplers = new object?[numSamplers];
            this.deviceContext.PixelShaderGetSamplers(startSlot, numSamplers, samplers);
            return Array.ConvertAll(samplers, i => i == null ? null : new D3D11SamplerState((ID3D11SamplerState)i));
        }

        /// <summary>
        /// Get the vertex shader currently set on the device.
        /// </summary>
        /// <returns>A vertex shader.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public D3D11VertexShader? VertexShaderGetShader()
        {
            uint numClassInstances = 0;
            this.deviceContext.VertexShaderGetShader(out ID3D11VertexShader? vertexShader, null, ref numClassInstances);

            if (vertexShader == null)
            {
                return null;
            }

            return new D3D11VertexShader(vertexShader);
        }

        /// <summary>
        /// Get the vertex shader currently set on the device.
        /// </summary>
        /// <param name="numClassInstances">The number of class-instance elements in the array.</param>
        /// <param name="classInstances">An array of class instance interfaces.</param>
        /// <returns>A vertex shader.</returns>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11VertexShader? VertexShaderGetShader(uint numClassInstances, out D3D11ClassInstance?[] classInstances)
        {
            object[] objects1 = new object[numClassInstances];
            this.deviceContext.VertexShaderGetShader(out ID3D11VertexShader? vertexShader, objects1, ref numClassInstances);
            object[] objects2 = new object[numClassInstances];
            Array.Copy(objects1, objects2, numClassInstances);
            classInstances = Array.ConvertAll(objects2, i => i == null ? null : new D3D11ClassInstance((ID3D11ClassInstance)i));

            if (vertexShader == null)
            {
                return null;
            }

            return new D3D11VertexShader(vertexShader);
        }

        /// <summary>
        /// Get the constant buffers used by the pixel shader pipeline stage.
        /// </summary>
        /// <param name="startSlot">Index into the device's zero-based array to begin retrieving constant buffers from.</param>
        /// <param name="numBuffers">Number of buffers to retrieve.</param>
        /// <returns>Array of constant buffer interface pointers to be returned.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public D3D11Buffer?[] PixelShaderGetConstantBuffers(uint startSlot, uint numBuffers)
        {
            object?[] constantBuffers = new object?[numBuffers];
            this.deviceContext.PixelShaderGetConstantBuffers(startSlot, numBuffers, constantBuffers);
            return Array.ConvertAll(constantBuffers, i => i == null ? null : new D3D11Buffer((ID3D11Buffer)i));
        }

        /// <summary>
        /// Get the input-layout object that is bound to the input-assembler stage.
        /// </summary>
        /// <returns>The input-layout object.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public D3D11InputLayout? InputAssemblerGetInputLayout()
        {
            this.deviceContext.InputAssemblerGetInputLayout(out ID3D11InputLayout? inputLayout);

            if (inputLayout == null)
            {
                return null;
            }

            return new D3D11InputLayout(inputLayout);
        }

        /// <summary>
        /// Get the vertex buffers bound to the input-assembler stage.
        /// </summary>
        /// <param name="startSlot">The input slot of the first vertex buffer to get.</param>
        /// <param name="numBuffers">The number of vertex buffers to get starting at the offset.</param>
        /// <param name="vertexBuffers">An array of vertex buffers.</param>
        /// <param name="strides">An array of stride values.</param>
        /// <param name="offsets">An array of offset values.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "2#", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "3#", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "4#", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void InputAssemblerGetVertexBuffers(
            uint startSlot,
            uint numBuffers,
            out D3D11Buffer?[] vertexBuffers,
            out uint[] strides,
            out uint[] offsets)
        {
            object?[] objects = new object?[numBuffers];
            strides = new uint[numBuffers];
            offsets = new uint[numBuffers];
            this.deviceContext.InputAssemblerGetVertexBuffers(startSlot, numBuffers, objects, strides, offsets);
            vertexBuffers = Array.ConvertAll(objects, i => i == null ? null : new D3D11Buffer((ID3D11Buffer)i));
        }

        /// <summary>
        /// Get the index buffer that is bound to the input-assembler stage.
        /// </summary>
        /// <param name="indexBuffer">An index buffer.</param>
        /// <param name="format">The format of the data in the index buffer.</param>
        /// <param name="offset">Offset (in bytes) from the start of the index buffer, to the first index to use.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "2#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void InputAssemblerGetIndexBuffer(out D3D11Buffer? indexBuffer, out DxgiFormat format, out uint offset)
        {
            this.deviceContext.InputAssemblerGetIndexBuffer(out ID3D11Buffer? buffer, out format, out offset);
            indexBuffer = buffer == null ? null : new D3D11Buffer(buffer);
        }

        /// <summary>
        /// Get the constant buffers used by the geometry shader pipeline stage.
        /// </summary>
        /// <param name="startSlot">Index into the device's zero-based array to begin retrieving constant buffers from.</param>
        /// <param name="numBuffers">Number of buffers to retrieve.</param>
        /// <returns>Array of constant buffer interface pointers to be returned.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public D3D11Buffer?[] GeometryShaderGetConstantBuffers(uint startSlot, uint numBuffers)
        {
            object?[] constantBuffers = new object?[numBuffers];
            this.deviceContext.GeometryShaderGetConstantBuffers(startSlot, numBuffers, constantBuffers);
            return Array.ConvertAll(constantBuffers, i => i == null ? null : new D3D11Buffer((ID3D11Buffer)i));
        }

        /// <summary>
        /// Get the geometry shader currently set on the device.
        /// </summary>
        /// <returns>A geometry shader.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public D3D11GeometryShader? GeometryShaderGetShader()
        {
            uint numClassInstances = 0;
            this.deviceContext.GeometryShaderGetShader(out ID3D11GeometryShader? geometryShader, null, ref numClassInstances);

            if (geometryShader == null)
            {
                return null;
            }

            return new D3D11GeometryShader(geometryShader);
        }

        /// <summary>
        /// Get the geometry shader currently set on the device.
        /// </summary>
        /// <param name="numClassInstances">The number of class-instance elements in the array.</param>
        /// <param name="classInstances">An array of class instance interfaces.</param>
        /// <returns>A geometry shader.</returns>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11GeometryShader? GeometryShaderGetShader(uint numClassInstances, out D3D11ClassInstance?[] classInstances)
        {
            object?[] objects1 = new object?[numClassInstances];
            this.deviceContext.GeometryShaderGetShader(out ID3D11GeometryShader? geometryShader, objects1, ref numClassInstances);
            object?[] objects2 = new object?[numClassInstances];
            Array.Copy(objects1, objects2, numClassInstances);
            classInstances = Array.ConvertAll(objects2, i => i == null ? null : new D3D11ClassInstance((ID3D11ClassInstance)i));

            if (geometryShader == null)
            {
                return null;
            }

            return new D3D11GeometryShader(geometryShader);
        }

        /// <summary>
        /// Get information about the primitive type, and data order that describes input data for the input assembler stage.
        /// </summary>
        /// <returns>The type of primitive, and ordering of the primitive data.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public D3D11PrimitiveTopology InputAssemblerGetPrimitiveTopology()
        {
            this.deviceContext.InputAssemblerGetPrimitiveTopology(out D3D11PrimitiveTopology topology);
            return topology;
        }

        /// <summary>
        /// Get the vertex shader resources.
        /// </summary>
        /// <param name="startSlot">Index into the device's zero-based array to begin getting shader resources from.</param>
        /// <param name="numViews">The number of resources to get from the device.</param>
        /// <returns>Array of shader resource view interfaces to be returned by the device.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public D3D11ShaderResourceView?[] VertexShaderGetShaderResources(uint startSlot, uint numViews)
        {
            object?[] shaderResourceViews = new object?[numViews];
            this.deviceContext.VertexShaderGetShaderResources(startSlot, numViews, shaderResourceViews);
            return Array.ConvertAll(shaderResourceViews, i => i == null ? null : new D3D11ShaderResourceView((ID3D11ShaderResourceView)i));
        }

        /// <summary>
        /// Get an array of sampler states from the vertex shader pipeline stage.
        /// </summary>
        /// <param name="startSlot">Index into a zero-based array to begin getting samplers from.</param>
        /// <param name="numSamplers">Number of samplers to get from a device context.</param>
        /// <returns>Array of sampler-state interface pointers to be returned by the device.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public D3D11SamplerState?[] VertexShaderGetSamplers(uint startSlot, uint numSamplers)
        {
            object?[] samplers = new object?[numSamplers];
            this.deviceContext.VertexShaderGetSamplers(startSlot, numSamplers, samplers);
            return Array.ConvertAll(samplers, i => i == null ? null : new D3D11SamplerState((ID3D11SamplerState)i));
        }

        /// <summary>
        /// Get the rendering predicate state.
        /// </summary>
        /// <param name="predicate">A predicate.</param>
        /// <param name="predicateValue">The predicate comparison value.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void GetPredication(out D3D11Predicate? predicate, out bool predicateValue)
        {
            this.deviceContext.GetPredication(out ID3D11Predicate? predicateInterface, out predicateValue);
            predicate = predicateInterface == null ? null : new D3D11Predicate(predicateInterface);
        }

        /// <summary>
        /// Get the geometry shader resources.
        /// </summary>
        /// <param name="startSlot">Index into the device's zero-based array to begin getting shader resources from.</param>
        /// <param name="numViews">The number of resources to get from the device.</param>
        /// <returns>Array of shader resource view interfaces to be returned by the device.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public D3D11ShaderResourceView?[] GeometryShaderGetShaderResources(uint startSlot, uint numViews)
        {
            object?[] shaderResourceViews = new object?[numViews];
            this.deviceContext.GeometryShaderGetShaderResources(startSlot, numViews, shaderResourceViews);
            return Array.ConvertAll(shaderResourceViews, i => i == null ? null : new D3D11ShaderResourceView((ID3D11ShaderResourceView)i));
        }

        /// <summary>
        /// Get an array of sampler state interfaces from the geometry shader pipeline stage.
        /// </summary>
        /// <param name="startSlot">Index into a zero-based array to begin getting samplers from.</param>
        /// <param name="numSamplers">Number of samplers to get from a device context.</param>
        /// <returns>An array of sampler-state interfaces.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public D3D11SamplerState?[] GeometryShaderGetSamplers(uint startSlot, uint numSamplers)
        {
            object?[] samplers = new object?[numSamplers];
            this.deviceContext.GeometryShaderGetSamplers(startSlot, numSamplers, samplers);
            return Array.ConvertAll(samplers, i => i == null ? null : new D3D11SamplerState((ID3D11SamplerState)i));
        }

        /// <summary>
        /// Get pointers to the resources bound to the output-merger stage.
        /// </summary>
        /// <param name="numViews">Number of render targets to retrieve.</param>
        /// <param name="renderTargetViews">The render target views.</param>
        /// <param name="depthStencilView">A depth-stencil view.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "2#", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void OutputMergerGetRenderTargets(
            uint numViews,
            out D3D11RenderTargetView?[] renderTargetViews,
            out D3D11DepthStencilView? depthStencilView)
        {
            object[] renderTargetViewObjects = new object[numViews];
            this.deviceContext.OutputMergerGetRenderTargets(numViews, renderTargetViewObjects, out ID3D11DepthStencilView? depthStencilViewInterface);
            renderTargetViews = Array.ConvertAll(renderTargetViewObjects, i => i == null ? null : new D3D11RenderTargetView((ID3D11RenderTargetView)i));
            depthStencilView = depthStencilViewInterface == null ? null : new D3D11DepthStencilView(depthStencilViewInterface);
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
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "2#", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "5#", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void OutputMergerGetRenderTargetsAndUnorderedAccessViews(
            uint numRenderTargetViews,
            out D3D11RenderTargetView?[] renderTargetViews,
            out D3D11DepthStencilView? depthStencilView,
            uint uavStartSlot,
            uint numUnorderedAccessViews,
            out D3D11UnorderedAccessView?[] unorderedAccessViews)
        {
            object[] renderTargetViewObjects = new object[numRenderTargetViews];
            object[] unorderedAccessViewObjects = new object[numUnorderedAccessViews];

            this.deviceContext.OutputMergerGetRenderTargetsAndUnorderedAccessViews(
                numRenderTargetViews,
                renderTargetViewObjects,
                out ID3D11DepthStencilView? depthStencilViewInterface,
                uavStartSlot,
                numUnorderedAccessViews,
                unorderedAccessViewObjects);

            renderTargetViews = Array.ConvertAll(renderTargetViewObjects, i => i == null ? null : new D3D11RenderTargetView((ID3D11RenderTargetView)i));
            depthStencilView = depthStencilViewInterface == null ? null : new D3D11DepthStencilView(depthStencilViewInterface);
            unorderedAccessViews = Array.ConvertAll(unorderedAccessViewObjects, i => i == null ? null : new D3D11UnorderedAccessView((ID3D11UnorderedAccessView)i));
        }

        /// <summary>
        /// Get the blend state of the output-merger stage.
        /// </summary>
        /// <param name="blendState">A blend-state interface.</param>
        /// <param name="blendFactor">Array of blend factors, one for each RGBA component.</param>
        /// <param name="sampleMask">A sample mask.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "2#", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void OutputMergerGetBlendState(out D3D11BlendState? blendState, out float[] blendFactor, out uint sampleMask)
        {
            blendFactor = new float[4];
            this.deviceContext.OutputMergerGetBlendState(out ID3D11BlendState? blendStateInterface, blendFactor, out sampleMask);
            blendState = blendStateInterface == null ? null : new D3D11BlendState(blendStateInterface);
        }

        /// <summary>
        /// Gets the depth-stencil state of the output-merger stage.
        /// </summary>
        /// <param name="depthStencilState">A depth-stencil state interface.</param>
        /// <param name="stencilReference">The stencil reference value used in the depth-stencil test.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void OutputMergerGetDepthStencilState(out D3D11DepthStencilState? depthStencilState, out uint stencilReference)
        {
            this.deviceContext.OutputMergerGetDepthStencilState(out ID3D11DepthStencilState? depthStencilStateInterface, out stencilReference);
            depthStencilState = depthStencilStateInterface == null ? null : new D3D11DepthStencilState(depthStencilStateInterface);
        }

        /// <summary>
        /// Get the target output buffers for the stream-output stage of the pipeline.
        /// </summary>
        /// <param name="numBuffers">Number of buffers to get.</param>
        /// <returns>An array of output buffers to be retrieved from the device.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public D3D11Buffer?[] StreamOutputGetTargets(uint numBuffers)
        {
            object?[] targets = new object?[numBuffers];
            this.deviceContext.StreamOutputGetTargets(numBuffers, targets);
            return Array.ConvertAll(targets, i => i == null ? null : new D3D11Buffer((ID3D11Buffer)i));
        }

        /// <summary>
        /// Get the rasterizer state from the rasterizer stage of the pipeline.
        /// </summary>
        /// <returns>A rasterizer-state interface.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public D3D11RasterizerState? RasterizerStageGetState()
        {
            this.deviceContext.RasterizerStageGetState(out ID3D11RasterizerState? rasterizerState);

            if (rasterizerState == null)
            {
                return null;
            }

            return new D3D11RasterizerState(rasterizerState);
        }

        /// <summary>
        /// Gets the array of viewports bound to the rasterizer stage.
        /// </summary>
        /// <returns>The viewports that are bound to the rasterizer stage.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public D3D11Viewport[] RasterizerStageGetViewports()
        {
            uint numViewports = 0;
            this.deviceContext.RasterizerStageGetViewports(ref numViewports, null);
            D3D11Viewport[] viewports = new D3D11Viewport[numViewports];
            this.deviceContext.RasterizerStageGetViewports(ref numViewports, viewports);
            return viewports;
        }

        /// <summary>
        /// Get the array of scissor rectangles bound to the rasterizer stage.
        /// </summary>
        /// <returns>An array of scissor rectangles.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public D3D11Rect[] RasterizerStageGetScissorRects()
        {
            uint numRects = 0;
            this.deviceContext.RasterizerStageGetScissorRects(ref numRects, null);
            D3D11Rect[] rects = new D3D11Rect[numRects];
            this.deviceContext.RasterizerStageGetScissorRects(ref numRects, rects);
            return rects;
        }

        /// <summary>
        /// Get the hull shader resources.
        /// </summary>
        /// <param name="startSlot">Index into the device's zero-based array to begin getting shader resources from.</param>
        /// <param name="numViews">The number of resources to get from the device.</param>
        /// <returns>Array of shader resource view interfaces to be returned by the device.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public D3D11ShaderResourceView?[] HullShaderGetShaderResources(uint startSlot, uint numViews)
        {
            object[] shaderResourceViews = new object[numViews];
            this.deviceContext.HullShaderGetShaderResources(startSlot, numViews, shaderResourceViews);
            return Array.ConvertAll(shaderResourceViews, i => i == null ? null : new D3D11ShaderResourceView((ID3D11ShaderResourceView)i));
        }

        /// <summary>
        /// Get the hull shader currently set on the device.
        /// </summary>
        /// <returns>A hull shader.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public D3D11HullShader? HullShaderGetShader()
        {
            uint numClassInstances = 0;
            this.deviceContext.HullShaderGetShader(out ID3D11HullShader? hullShader, null, ref numClassInstances);

            if (hullShader == null)
            {
                return null;
            }

            return new D3D11HullShader(hullShader);
        }

        /// <summary>
        /// Get the hull shader currently set on the device.
        /// </summary>
        /// <param name="numClassInstances">The number of class-instance elements in the array.</param>
        /// <param name="classInstances">An array of class instance interfaces.</param>
        /// <returns>A hull shader.</returns>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11HullShader? HullShaderGetShader(uint numClassInstances, out D3D11ClassInstance?[] classInstances)
        {
            object?[] objects1 = new object?[numClassInstances];
            this.deviceContext.HullShaderGetShader(out ID3D11HullShader? hullShader, objects1, ref numClassInstances);
            object?[] objects2 = new object?[numClassInstances];
            Array.Copy(objects1, objects2, numClassInstances);
            classInstances = Array.ConvertAll(objects2, i => i == null ? null : new D3D11ClassInstance((ID3D11ClassInstance)i));

            if (hullShader == null)
            {
                return null;
            }

            return new D3D11HullShader(hullShader);
        }

        /// <summary>
        /// Get an array of sampler state interfaces from the hull shader stage.
        /// </summary>
        /// <param name="startSlot">Index into a zero-based array to begin getting samplers from.</param>
        /// <param name="numSamplers">Number of samplers to get from a device context.</param>
        /// <returns>An array of sampler-state interfaces.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public D3D11SamplerState?[] HullShaderGetSamplers(uint startSlot, uint numSamplers)
        {
            object?[] samplers = new object?[numSamplers];
            this.deviceContext.HullShaderGetSamplers(startSlot, numSamplers, samplers);
            return Array.ConvertAll(samplers, i => i == null ? null : new D3D11SamplerState((ID3D11SamplerState)i));
        }

        /// <summary>
        /// Get the constant buffers used by the hull shader stage.
        /// </summary>
        /// <param name="startSlot">Index into the device's zero-based array to begin retrieving constant buffers from.</param>
        /// <param name="numBuffers">Number of buffers to retrieve.</param>
        /// <returns>Array of constant buffer interface pointers to be returned by the method.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public D3D11Buffer?[] HullShaderGetConstantBuffers(uint startSlot, uint numBuffers)
        {
            object?[] constantBuffers = new object?[numBuffers];
            this.deviceContext.HullShaderGetConstantBuffers(startSlot, numBuffers, constantBuffers);
            return Array.ConvertAll(constantBuffers, i => i == null ? null : new D3D11Buffer((ID3D11Buffer)i));
        }

        /// <summary>
        /// Get the domain shader resources.
        /// </summary>
        /// <param name="startSlot">Index into the device's zero-based array to begin getting shader resources from.</param>
        /// <param name="numViews">The number of resources to get from the device.</param>
        /// <returns>Array of shader resource view interfaces to be returned by the device.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public D3D11ShaderResourceView?[] DomainShaderGetShaderResources(uint startSlot, uint numViews)
        {
            object?[] shaderResourceViews = new object?[numViews];
            this.deviceContext.DomainShaderGetShaderResources(startSlot, numViews, shaderResourceViews);
            return Array.ConvertAll(shaderResourceViews, i => i == null ? null : new D3D11ShaderResourceView((ID3D11ShaderResourceView)i));
        }

        /// <summary>
        /// Get the domain shader currently set on the device.
        /// </summary>
        /// <returns>A domain shader.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public D3D11DomainShader? DomainShaderGetShader()
        {
            uint numClassInstances = 0;
            this.deviceContext.DomainShaderGetShader(out ID3D11DomainShader? domainShader, null, ref numClassInstances);

            if (domainShader == null)
            {
                return null;
            }

            return new D3D11DomainShader(domainShader);
        }

        /// <summary>
        /// Get the domain shader currently set on the device.
        /// </summary>
        /// <param name="numClassInstances">The number of class-instance elements in the array.</param>
        /// <param name="classInstances">An array of class instance interfaces.</param>
        /// <returns>A domain shader.</returns>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11DomainShader? DomainShaderGetShader(uint numClassInstances, out D3D11ClassInstance?[] classInstances)
        {
            object?[] objects1 = new object?[numClassInstances];
            this.deviceContext.DomainShaderGetShader(out ID3D11DomainShader? domainShader, objects1, ref numClassInstances);
            object?[] objects2 = new object?[numClassInstances];
            Array.Copy(objects1, objects2, numClassInstances);
            classInstances = Array.ConvertAll(objects2, i => i == null ? null : new D3D11ClassInstance((ID3D11ClassInstance)i));

            if (domainShader == null)
            {
                return null;
            }

            return new D3D11DomainShader(domainShader);
        }

        /// <summary>
        /// Get an array of sampler state interfaces from the domain shader stage.
        /// </summary>
        /// <param name="startSlot">Index into a zero-based array to begin getting samplers from.</param>
        /// <param name="numSamplers">Number of samplers to get from a device context.</param>
        /// <returns>An array of sampler-state interfaces.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public D3D11SamplerState?[] DomainShaderGetSamplers(uint startSlot, uint numSamplers)
        {
            object?[] samplers = new object?[numSamplers];
            this.deviceContext.DomainShaderGetSamplers(startSlot, numSamplers, samplers);
            return Array.ConvertAll(samplers, i => i == null ? null : new D3D11SamplerState((ID3D11SamplerState)i));
        }

        /// <summary>
        /// Get the constant buffers used by the domain shader stage.
        /// </summary>
        /// <param name="startSlot">Index into the device's zero-based array to begin retrieving constant buffers from.</param>
        /// <param name="numBuffers">Number of buffers to retrieve.</param>
        /// <returns>Array of constant buffer interface pointers to be returned by the method.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public D3D11Buffer?[] DomainShaderGetConstantBuffers(uint startSlot, uint numBuffers)
        {
            object?[] constantBuffers = new object?[numBuffers];
            this.deviceContext.DomainShaderGetConstantBuffers(startSlot, numBuffers, constantBuffers);
            return Array.ConvertAll(constantBuffers, i => i == null ? null : new D3D11Buffer((ID3D11Buffer)i));
        }

        /// <summary>
        /// Get the compute shader resources.
        /// </summary>
        /// <param name="startSlot">Index into the device's zero-based array to begin getting shader resources from.</param>
        /// <param name="numViews">The number of resources to get from the device.</param>
        /// <returns>Array of shader resource view interfaces to be returned by the device.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public D3D11ShaderResourceView?[] ComputeShaderGetShaderResources(uint startSlot, uint numViews)
        {
            object?[] shaderResourceViews = new object?[numViews];
            this.deviceContext.ComputeShaderGetShaderResources(startSlot, numViews, shaderResourceViews);
            return Array.ConvertAll(shaderResourceViews, i => i == null ? null : new D3D11ShaderResourceView((ID3D11ShaderResourceView)i));
        }

        /// <summary>
        /// Gets an array of views for an unordered resource.
        /// </summary>
        /// <param name="startSlot">Index of the first element in the zero-based array to return.</param>
        /// <param name="numUnorderedAccessViews">Number of views to get.</param>
        /// <returns>An array of interface pointers.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public D3D11UnorderedAccessView?[] ComputeShaderGetUnorderedAccessViews(uint startSlot, uint numUnorderedAccessViews)
        {
            object?[] unorderedAccessViews = new object?[numUnorderedAccessViews];
            this.deviceContext.ComputeShaderGetUnorderedAccessViews(startSlot, numUnorderedAccessViews, unorderedAccessViews);
            return Array.ConvertAll(unorderedAccessViews, i => i == null ? null : new D3D11UnorderedAccessView((ID3D11UnorderedAccessView)i));
        }

        /// <summary>
        /// Get the compute shader currently set on the device.
        /// </summary>
        /// <returns>A compute shader.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public D3D11ComputeShader? ComputeShaderGetShader()
        {
            uint numClassInstances = 0;
            this.deviceContext.ComputeShaderGetShader(out ID3D11ComputeShader? computeShader, null, ref numClassInstances);

            if (computeShader == null)
            {
                return null;
            }

            return new D3D11ComputeShader(computeShader);
        }

        /// <summary>
        /// Get the compute shader currently set on the device.
        /// </summary>
        /// <param name="numClassInstances">The number of class-instance elements in the array.</param>
        /// <param name="classInstances">An array of class instance interfaces.</param>
        /// <returns>A compute shader.</returns>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11ComputeShader? ComputeShaderGetShader(uint numClassInstances, out D3D11ClassInstance?[] classInstances)
        {
            object?[] objects1 = new object?[numClassInstances];
            this.deviceContext.ComputeShaderGetShader(out ID3D11ComputeShader? computeShader, objects1, ref numClassInstances);
            object?[] objects2 = new object?[numClassInstances];
            Array.Copy(objects1, objects2, numClassInstances);
            classInstances = Array.ConvertAll(objects2, i => i == null ? null : new D3D11ClassInstance((ID3D11ClassInstance)i));

            if (computeShader == null)
            {
                return null;
            }

            return new D3D11ComputeShader(computeShader);
        }

        /// <summary>
        /// Get an array of sampler state interfaces from the compute shader stage.
        /// </summary>
        /// <param name="startSlot">Index into a zero-based array to begin getting samplers from.</param>
        /// <param name="numSamplers">Number of samplers to get from a device context.</param>
        /// <returns>An array of sampler-state interfaces.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public D3D11SamplerState?[] ComputeShaderGetSamplers(uint startSlot, uint numSamplers)
        {
            object?[] samplers = new object?[numSamplers];
            this.deviceContext.ComputeShaderGetSamplers(startSlot, numSamplers, samplers);
            return Array.ConvertAll(samplers, i => i == null ? null : new D3D11SamplerState((ID3D11SamplerState)i));
        }

        /// <summary>
        /// Get the constant buffers used by the compute shader stage.
        /// </summary>
        /// <param name="startSlot">Index into the device's zero-based array to begin retrieving constant buffers from.</param>
        /// <param name="numBuffers">Number of buffers to retrieve.</param>
        /// <returns>Array of constant buffer interface pointers to be returned by the method.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public D3D11Buffer?[] ComputeShaderGetConstantBuffers(uint startSlot, uint numBuffers)
        {
            object?[] constantBuffers = new object?[numBuffers];
            this.deviceContext.ComputeShaderGetConstantBuffers(startSlot, numBuffers, constantBuffers);
            return Array.ConvertAll(constantBuffers, i => i == null ? null : new D3D11Buffer((ID3D11Buffer)i));
        }

        /// <summary>
        /// Restore all default settings.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public void ClearState()
        {
            this.deviceContext.ClearState();
        }

        /// <summary>
        /// Sends queued-up commands in the command buffer to the graphics processing unit (GPU).
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public void Flush()
        {
            this.deviceContext.Flush();
        }

        /// <summary>
        /// Create a command list and record graphics commands into it.
        /// </summary>
        /// <param name="restoreDeferredContextState">A value indicating whether the runtime saves deferred context state before it executes <c>FinishCommandList</c> and restores it afterwards.</param>
        /// <returns>The recorded command list.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11CommandList? FinishCommandList(bool restoreDeferredContextState)
        {
            ID3D11CommandList? commandList = this.deviceContext.FinishCommandList(restoreDeferredContextState);

            if (commandList == null)
            {
                return null;
            }

            return new D3D11CommandList(commandList);
        }
    }
}
