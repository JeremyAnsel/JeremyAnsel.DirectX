// <copyright file="ID3D11Device.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11.ComInterfaces
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;
    using System.Text;
    using JeremyAnsel.DirectX.Dxgi;

    /// <summary>
    /// The device interface represents a virtual adapter; it is used to create resources.
    /// </summary>
    [SecurityCritical, SuppressUnmanagedCodeSecurity]
    [ComImport, Guid("db6f6ddb-ac77-4e88-8253-819df9bbf140")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ID3D11Device
    {
        /// <summary>
        /// Creates a buffer (vertex buffer, index buffer, or shader constant buffer).
        /// </summary>
        /// <param name="desc">Describes the buffer.</param>
        /// <param name="initialData">Describes the initialization data.</param>
        /// <returns>The buffer object created.</returns>
        ID3D11Buffer? CreateBuffer(
            [In] ref D3D11BufferDesc desc,
            [In] IntPtr initialData);

        /// <summary>
        /// Creates an array of 1D textures.
        /// </summary>
        /// <param name="desc">Describes a 1D texture resource.</param>
        /// <param name="initialData">Describe subresources for the 1D texture resource.</param>
        /// <returns>The created texture.</returns>
        ID3D11Texture1D? CreateTexture1D(
            [In] ref D3D11Texture1DDesc desc,
            [In, MarshalAs(UnmanagedType.LPArray)] D3D11SubResourceDataPtr[]? initialData);

        /// <summary>
        /// Create an array of 2D textures.
        /// </summary>
        /// <param name="desc">Describes a 2D texture resource.</param>
        /// <param name="initialData">Describe subresources for the 2D texture resource.</param>
        /// <returns>The created texture.</returns>
        ID3D11Texture2D? CreateTexture2D(
            [In] ref D3D11Texture2DDesc desc,
            [In, MarshalAs(UnmanagedType.LPArray)] D3D11SubResourceDataPtr[]? initialData);

        /// <summary>
        /// Create a single 3D texture.
        /// </summary>
        /// <param name="desc">Describes a 3D texture resource.</param>
        /// <param name="initialData">Describe subresources for the 3D texture resource.</param>
        /// <returns>The created texture.</returns>
        ID3D11Texture3D? CreateTexture3D(
            [In] ref D3D11Texture3DDesc desc,
            [In, MarshalAs(UnmanagedType.LPArray)] D3D11SubResourceDataPtr[]? initialData);

        /// <summary>
        /// Create a shader resource view for accessing data in a resource.
        /// </summary>
        /// <param name="resource">The resource that will serve as input to a shader.</param>
        /// <param name="desc">A pointer to a shader resource view description.</param>
        /// <returns>The created shader resource view.</returns>
        ID3D11ShaderResourceView? CreateShaderResourceView(
            [In] ID3D11Resource? resource,
            [In] IntPtr desc);

        /// <summary>
        /// Creates a view for accessing an unordered access resource.
        /// </summary>
        /// <param name="resource">A resources that will serve as an input to a shader.</param>
        /// <param name="desc">A pointer to a shader resource view description.</param>
        /// <returns>The created unordered-access view.</returns>
        ID3D11UnorderedAccessView? CreateUnorderedAccessView(
            [In] ID3D11Resource? resource,
            [In] IntPtr desc);

        /// <summary>
        /// Creates a render-target view for accessing resource data.
        /// </summary>
        /// <param name="resource">A render target resource.</param>
        /// <param name="desc">A pointer to a render-target view description.</param>
        /// <returns>The created render target view.</returns>
        ID3D11RenderTargetView? CreateRenderTargetView(
            [In] ID3D11Resource? resource,
            [In] IntPtr desc);

        /// <summary>
        /// Create a depth-stencil view for accessing resource data.
        /// </summary>
        /// <param name="resource">The resource that will serve as the depth-stencil surface.</param>
        /// <param name="desc">A pointer to a depth-stencil-view description.</param>
        /// <returns>The created depth-stencil view.</returns>
        ID3D11DepthStencilView? CreateDepthStencilView(
            [In] ID3D11Resource? resource,
            [In] IntPtr desc);

        /// <summary>
        /// Create an input-layout object to describe the input-buffer data for the input-assembler stage.
        /// </summary>
        /// <param name="inputElementDescs">An array of the input-assembler stage input data types; each type is described by an element description.</param>
        /// <param name="numElements">The number of input-data types in the array of input-elements.</param>
        /// <param name="shaderBytecodeWithInputSignature">The compiled shader. The compiled shader code contains a input signature which is validated against the array of elements.</param>
        /// <param name="bytecodeLength">The size of the compiled shader.</param>
        /// <returns>The created input-layout object.</returns>
        ID3D11InputLayout? CreateInputLayout(
            [In, MarshalAs(UnmanagedType.LPArray)] D3D11InputElementDesc[]? inputElementDescs,
            [In] uint numElements,
            [In, MarshalAs(UnmanagedType.LPArray)] byte[]? shaderBytecodeWithInputSignature,
            [In] UIntPtr bytecodeLength);

        /// <summary>
        /// Create a vertex shader object from a compiled shader.
        /// </summary>
        /// <param name="shaderBytecode">The compiled shader.</param>
        /// <param name="bytecodeLength">The size of the compiled vertex shader.</param>
        /// <param name="classLinkage">A class linkage interface.</param>
        /// <returns>The created vertex shader.</returns>
        ID3D11VertexShader? CreateVertexShader(
            [In, MarshalAs(UnmanagedType.LPArray)] byte[]? shaderBytecode,
            [In] UIntPtr bytecodeLength,
            [In] ID3D11ClassLinkage? classLinkage);

        /// <summary>
        /// Create a geometry shader.
        /// </summary>
        /// <param name="shaderBytecode">The compiled shader.</param>
        /// <param name="bytecodeLength">The size of the compiled geometry shader.</param>
        /// <param name="classLinkage">A class linkage interface.</param>
        /// <returns>The created geometry shader.</returns>
        ID3D11GeometryShader? CreateGeometryShader(
            [In, MarshalAs(UnmanagedType.LPArray)] byte[]? shaderBytecode,
            [In] UIntPtr bytecodeLength,
            [In] ID3D11ClassLinkage? classLinkage);

        /// <summary>
        /// Creates a geometry shader that can write to streaming output buffers.
        /// </summary>
        /// <param name="shaderBytecode">The compiled geometry shader for a standard geometry shader plus stream output.</param>
        /// <param name="bytecodeLength">The size of the compiled geometry shader.</param>
        /// <param name="streamOutputDeclaration">A <see cref="D3D11StreamOutputDeclarationEntry"/> array.</param>
        /// <param name="numEntries">The number of entries in the stream output declaration.</param>
        /// <param name="bufferStrides">An array of buffer strides; each stride is the size of an element for that buffer.</param>
        /// <param name="numStrides">The number of strides (or buffers).</param>
        /// <param name="rasterizedStream">The index number of the stream to be sent to the rasterizer stage.</param>
        /// <param name="classLinkage">A class linkage interface.</param>
        /// <returns>The created geometry shader.</returns>
        ID3D11GeometryShader? CreateGeometryShaderWithStreamOutput(
            [In, MarshalAs(UnmanagedType.LPArray)] byte[]? shaderBytecode,
            [In] UIntPtr bytecodeLength,
            [In, MarshalAs(UnmanagedType.LPArray)] D3D11StreamOutputDeclarationEntry[]? streamOutputDeclaration,
            [In] uint numEntries,
            [In, MarshalAs(UnmanagedType.LPArray)] uint[]? bufferStrides,
            [In] uint numStrides,
            [In] uint rasterizedStream,
            [In] ID3D11ClassLinkage? classLinkage);

        /// <summary>
        /// Create a pixel shader.
        /// </summary>
        /// <param name="shaderBytecode">The compiled shader.</param>
        /// <param name="bytecodeLength">The size of the compiled pixel shader.</param>
        /// <param name="classLinkage">A class linkage interface.</param>
        /// <returns>The created pixel shader.</returns>
        ID3D11PixelShader? CreatePixelShader(
            [In, MarshalAs(UnmanagedType.LPArray)] byte[]? shaderBytecode,
            [In] UIntPtr bytecodeLength,
            [In] ID3D11ClassLinkage? classLinkage);

        /// <summary>
        /// Create a hull shader.
        /// </summary>
        /// <param name="shaderBytecode">The compiled shader.</param>
        /// <param name="bytecodeLength">The size of the compiled shader.</param>
        /// <param name="classLinkage">A class linkage interface.</param>
        /// <returns>The created hull shader.</returns>
        ID3D11HullShader? CreateHullShader(
            [In, MarshalAs(UnmanagedType.LPArray)] byte[]? shaderBytecode,
            [In] UIntPtr bytecodeLength,
            [In] ID3D11ClassLinkage? classLinkage);

        /// <summary>
        /// Create a domain shader.
        /// </summary>
        /// <param name="shaderBytecode">The compiled shader.</param>
        /// <param name="bytecodeLength">The size of the compiled shader.</param>
        /// <param name="classLinkage">A class linkage interface.</param>
        /// <returns>The created domain shader.</returns>
        ID3D11DomainShader? CreateDomainShader(
            [In, MarshalAs(UnmanagedType.LPArray)] byte[]? shaderBytecode,
            [In] UIntPtr bytecodeLength,
            [In] ID3D11ClassLinkage? classLinkage);

        /// <summary>
        /// Create a compute shader.
        /// </summary>
        /// <param name="shaderBytecode">The compiled shader.</param>
        /// <param name="bytecodeLength">The size of the compiled shader.</param>
        /// <param name="classLinkage">A class linkage interface.</param>
        /// <returns>The created compute shader.</returns>
        ID3D11ComputeShader? CreateComputeShader(
            [In, MarshalAs(UnmanagedType.LPArray)] byte[]? shaderBytecode,
            [In] UIntPtr bytecodeLength,
            [In] ID3D11ClassLinkage? classLinkage);

        /// <summary>
        /// Creates class linkage libraries to enable dynamic shader linkage.
        /// </summary>
        /// <returns>The created class linkage.</returns>
        ID3D11ClassLinkage? CreateClassLinkage();

        /// <summary>
        /// Create a blend-state object that encapsules blend state for the output-merger stage.
        /// </summary>
        /// <param name="desc">A blend-state description.</param>
        /// <returns>The created blend-state object.</returns>
        ID3D11BlendState? CreateBlendState(
            [In] ref D3D11BlendDesc desc);

        /// <summary>
        /// Create a depth-stencil state object that encapsulates depth-stencil test information for the output-merger stage.
        /// </summary>
        /// <param name="desc">A depth-stencil state description.</param>
        /// <returns>The created depth-stencil state object.</returns>
        ID3D11DepthStencilState? CreateDepthStencilState(
            [In] ref D3D11DepthStencilDesc desc);

        /// <summary>
        /// Create a rasterizer state object that tells the rasterizer stage how to behave.
        /// </summary>
        /// <param name="desc">A rasterizer state description.</param>
        /// <returns>The created rasterizer state object.</returns>
        ID3D11RasterizerState? CreateRasterizerState(
            [In] ref D3D11RasterizerDesc desc);

        /// <summary>
        /// Create a sampler-state object that encapsulates sampling information for a texture.
        /// </summary>
        /// <param name="desc">A sampler state description.</param>
        /// <returns>The created sampler-state object.</returns>
        ID3D11SamplerState? CreateSamplerState(
            [In] ref D3D11SamplerDesc desc);

        /// <summary>
        /// Creates an object for querying information from the GPU.
        /// </summary>
        /// <param name="desc">A query description.</param>
        /// <returns>The created query.</returns>
        ID3D11Query? CreateQuery(
            [In] ref D3D11QueryDesc desc);

        /// <summary>
        /// Creates a predicate.
        /// </summary>
        /// <param name="desc">A query description for a predicate.</param>
        /// <returns>The created predicate.</returns>
        ID3D11Predicate? CreatePredicate(
            [In] ref D3D11QueryDesc desc);

        /// <summary>
        /// Create a counter object for measuring GPU performance.
        /// </summary>
        /// <param name="desc">A counter description.</param>
        /// <returns>The created counter.</returns>
        ID3D11Counter? CreateCounter(
            [In] ref D3D11CounterDesc desc);

        /// <summary>
        /// Creates a deferred context, which can record command lists.
        /// </summary>
        /// <param name="contextOptions">Reserved for future use.</param>
        /// <returns>The created deferred context.</returns>
        ID3D11DeviceContext? CreateDeferredContext(
            [In] uint contextOptions);

        /// <summary>
        /// Give a device access to a shared resource created on a different device.
        /// </summary>
        /// <param name="resourceHandle">A resource handle.</param>
        /// <param name="returnedInterface">The globally unique identifier (GUID) for the resource interface.</param>
        /// <returns>A pointer to the resource we are gaining access to.</returns>
        [return: MarshalAs(UnmanagedType.IUnknown)]
        object? OpenSharedResource(
            [In] IntPtr resourceHandle,
            [In] ref Guid returnedInterface);

        /// <summary>
        /// Get the support of a given format on the installed video device.
        /// </summary>
        /// <param name="format">A format for which to check for support.</param>
        /// <param name="formatSupport">Describes how the specified format is supported on the installed device.</param>
        /// <returns>A boolean value.</returns>
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Bool)]
        bool CheckFormatSupport(
            [In] DxgiFormat format,
            [Out] out D3D11FormatSupport formatSupport);

        /// <summary>
        /// Get the number of quality levels available during multisampling.
        /// </summary>
        /// <param name="format">The texture format.</param>
        /// <param name="sampleCount">The number of samples during multisampling.</param>
        /// <param name="numQualityLevels">The number of quality levels supported by the adapter.</param>
        /// <returns>A boolean value.</returns>
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Bool)]
        bool CheckMultisampleQualityLevels(
            [In] DxgiFormat format,
            [In] uint sampleCount,
            [Out] out uint numQualityLevels);

        /// <summary>
        /// Get a counter's information.
        /// </summary>
        /// <param name="counterInfo">A pointer to counter information.</param>
        [PreserveSig]
        void CheckCounterInfo(
            [Out] out D3D11CounterInfo counterInfo);

        /// <summary>
        /// Get the type, name, units of measure, and a description of an existing counter.
        /// </summary>
        /// <param name="desc">A counter description.</param>
        /// <param name="type">The data type of a counter.</param>
        /// <param name="activeCounters">The number of hardware counters that are needed for this counter type to be created. All instances of the same counter type use the same hardware counters.</param>
        /// <param name="name">String to be filled with a brief name for the counter.</param>
        /// <param name="nameLength">Length of the string returned to <paramref name="name"/>.</param>
        /// <param name="units">Name of the units a counter measures.</param>
        /// <param name="unitsLength">Length of the string returned to <paramref name="units"/>.</param>
        /// <param name="description">A description of the counter.</param>
        /// <param name="descriptionLength">Length of the string returned to <paramref name="description"/>.</param>
        /// <returns>A boolean value.</returns>
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Bool)]
        bool CheckCounter(
            [In] ref D3D11CounterDesc desc,
            [Out] out D3D11CounterDataType type,
            [Out] out uint activeCounters,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder? name,
            [In, Out] ref uint nameLength,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder? units,
            [In, Out] ref uint unitsLength,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder? description,
            [In, Out] ref uint descriptionLength);

        /// <summary>
        /// Gets information about the features that are supported by the current graphics driver.
        /// </summary>
        /// <param name="feature">Describes which feature to query for support.</param>
        /// <param name="featureSupportData">Upon completion of the method, the passed structure is filled with data that describes the feature support.</param>
        /// <param name="featureSupportDataSize">The size of the structure passed to the <paramref name="featureSupportData"/> parameter.</param>
        /// <returns>A boolean value.</returns>
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Bool)]
        bool CheckFeatureSupport(
            [In] D3D11Feature feature,
            [Out] IntPtr featureSupportData,
            [In] uint featureSupportDataSize);

        /// <summary>
        /// Get application-defined data from a device.
        /// </summary>
        /// <param name="name">The Guid associated with the data.</param>
        /// <param name="dataSize">A pointer to a variable that on input contains the size, in bytes, of the buffer.</param>
        /// <param name="data">A pointer to a buffer that will be filled with data from the device.</param>
        void GetPrivateData(
            [In] ref Guid name,
            [In, Out] ref uint dataSize,
            [Out, MarshalAs(UnmanagedType.LPArray)] byte[]? data);

        /// <summary>
        /// Set data to a device and associate that data with a guid.
        /// </summary>
        /// <param name="name">The Guid associated with the data.</param>
        /// <param name="dataSize">The size of the data.</param>
        /// <param name="data">The data to be stored with this device.</param>
        void SetPrivateData(
            [In] ref Guid name,
            [In] uint dataSize,
            [In, MarshalAs(UnmanagedType.LPArray)] byte[]? data);

        /// <summary>
        /// Associate an IUnknown-derived interface with this device child and associate that interface with an application-defined guid.
        /// </summary>
        /// <param name="name">The Guid associated with the interface.</param>
        /// <param name="unknown">An <c>IUnknown</c>-derived interface to be associated with the device child.</param>
        void SetPrivateDataInterface(
            [In] ref Guid name,
            [In, MarshalAs(UnmanagedType.IUnknown)] object? unknown);

        /// <summary>
        /// Gets the feature level of the hardware device.
        /// </summary>
        /// <returns>The feature level of the hardware device.</returns>
        [PreserveSig]
        D3D11FeatureLevel GetFeatureLevel();

        /// <summary>
        /// Get the options used during the call to create the device.
        /// </summary>
        /// <returns>The options used to create the device.</returns>
        [PreserveSig]
        D3D11CreateDeviceOptions GetCreationOptions();

        /// <summary>
        /// Get the reason why the device was removed.
        /// </summary>
        /// <returns>The removed reason.</returns>
        [PreserveSig]
        int GetDeviceRemovedReason();

        /// <summary>
        /// Gets an immediate context, which can play back command lists.
        /// </summary>
        /// <param name="immediateContext">An immediate context.</param>
        [PreserveSig]
        void GetImmediateContext(
            [Out] out ID3D11DeviceContext? immediateContext);

        /// <summary>
        /// Set the exception-mode options.
        /// </summary>
        /// <param name="raiseOptions">The exception options.</param>
        void SetExceptionMode(
            [In] D3D11RaiseOptions raiseOptions);

        /// <summary>
        /// Get the exception-mode options.
        /// </summary>
        /// <returns>The exception options.</returns>
        [PreserveSig]
        D3D11RaiseOptions GetExceptionMode();
    }
}
