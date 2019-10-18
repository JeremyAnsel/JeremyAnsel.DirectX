// <copyright file="D3D11Device.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;
    using JeremyAnsel.DirectX.D3D11.ComInterfaces;
    using JeremyAnsel.DirectX.Dxgi;

    /// <summary>
    /// The device interface represents a virtual adapter; it is used to create resources.
    /// </summary>
    [SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "Reviewed")]
    public sealed class D3D11Device : IDisposable, ID3D11Releasable
    {
        /// <summary>
        /// The D3D11 device interface.
        /// </summary>
        private readonly ID3D11Device device;

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11Device"/> class.
        /// </summary>
        /// <param name="device">A D3D11 device interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D3D11Device(ID3D11Device device)
        {
            this.device = device;
        }

        /// <summary>
        /// Gets an handle representing the D3D11 object interface.
        /// </summary>
        public object Handle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.device; }
        }

        /// <summary>
        /// Gets the feature level of the hardware device.
        /// </summary>
        public D3D11FeatureLevel FeatureLevel
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.device.GetFeatureLevel(); }
        }

        /// <summary>
        /// Gets the options used during the call to create the device.
        /// </summary>
        public D3D11CreateDeviceOptions CreationOptions
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.device.GetCreationOptions(); }
        }

        /// <summary>
        /// Gets a boolean indicating if the handle is not null.
        /// </summary>
        /// <param name="value">A D3D11 device.</param>
        /// <returns>A boolean</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool(D3D11Device value)
        {
            return value != null && value.Handle != null;
        }

        /// <summary>
        /// Creates a device that represents the display adapter.
        /// </summary>
        /// <param name="adapter">A pointer to the video adapter to use when creating a device.</param>
        /// <param name="driverType">The driver type to create.</param>
        /// <param name="options">The runtime layers to enable.</param>
        /// <param name="featureLevels">Determine the order of feature levels to attempt to create.</param>
        /// <param name="device">The created device.</param>
        /// <param name="featureLevel">If successful, returns the first feature level from the <paramref name="featureLevels"/> array which succeeded.</param>
        /// <param name="immediateContext">The device context.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "4#", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "5#", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "6#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CreateDevice(
            object adapter,
            D3D11DriverType driverType,
            D3D11CreateDeviceOptions options,
            D3D11FeatureLevel[] featureLevels,
            out D3D11Device device,
            out D3D11FeatureLevel featureLevel,
            out D3D11DeviceContext immediateContext)
        {
            ID3D11Device deviceInterface;
            ID3D11DeviceContext immediateContextInterface;

            if (featureLevels == null || featureLevels.Length == 0)
            {
                featureLevels = (D3D11FeatureLevel[])Enum.GetValues(typeof(D3D11FeatureLevel));
                Array.Reverse(featureLevels);
            }

            NativeMethods.D3D11CreateDevice(
                adapter,
                driverType,
                IntPtr.Zero,
                options,
                featureLevels,
                (uint)featureLevels.Length,
                7, // SDK_VERSION
                out deviceInterface,
                out featureLevel,
                out immediateContextInterface);

            device = new D3D11Device(deviceInterface);
            immediateContext = new D3D11DeviceContext(immediateContextInterface);
        }

        /// <summary>
        /// Creates a device that represents the display adapter and a swap chain used for rendering.
        /// </summary>
        /// <param name="adapter">The video adapter to use when creating a device.</param>
        /// <param name="driverType">The driver type to create.</param>
        /// <param name="options">The runtime layers to enable.</param>
        /// <param name="featureLevels">Determine the order of feature levels to attempt to create.</param>
        /// <param name="swapChainDesc">A swap chain description that contains initialization parameters for the swap chain.</param>
        /// <param name="swapChain">The swap chain used for rendering.</param>
        /// <param name="device">The created device.</param>
        /// <param name="featureLevel">If successful, returns the first feature level from the <paramref name="featureLevels"/> array which succeeded.</param>
        /// <param name="immediateContext">The device context.</param>
        [Obsolete("Use CreateDevice instead.")]
        [SuppressMessage("Microsoft.Design", "CA1007:UseGenericsWhereAppropriate", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CreateDeviceAndSwapChain(
            object adapter,
            D3D11DriverType driverType,
            D3D11CreateDeviceOptions options,
            D3D11FeatureLevel[] featureLevels,
            DxgiSwapChainDesc swapChainDesc,
            out object swapChain,
            out D3D11Device device,
            out D3D11FeatureLevel featureLevel,
            out D3D11DeviceContext immediateContext)
        {
            ID3D11Device deviceInterface;
            ID3D11DeviceContext immediateContextInterface;

            if (featureLevels == null || featureLevels.Length == 0)
            {
                featureLevels = (D3D11FeatureLevel[])Enum.GetValues(typeof(D3D11FeatureLevel));
                Array.Reverse(featureLevels);
            }

            NativeMethods.D3D11CreateDeviceAndSwapChain(
                adapter,
                driverType,
                IntPtr.Zero,
                options,
                featureLevels,
                (uint)featureLevels.Length,
                7, // SDK_VERSION
                ref swapChainDesc,
                out swapChain,
                out deviceInterface,
                out featureLevel,
                out immediateContextInterface);

            device = new D3D11Device(deviceInterface);
            immediateContext = new D3D11DeviceContext(immediateContextInterface);
        }

        /// <summary>
        /// Gets a boolean indicating if the handle is not null.
        /// </summary>
        /// <returns>A boolean</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool ToBoolean()
        {
            return this.Handle != null;
        }

        /// <summary>
        /// Immediately releases the unmanaged resources used by the <see cref="D3D11Device"/> object.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Dispose()
        {
            Marshal.ReleaseComObject(this.Handle);
        }

        /// <summary>
        /// Releases the managed reference to the COM D3D11 interface.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Release()
        {
            Marshal.FinalReleaseComObject(this.Handle);
        }

        /// <summary>
        /// Sets an application-defined data to the object and associates that data with a GUID.
        /// </summary>
        /// <param name="name">A GUID that identifies the data.</param>
        /// <param name="text">The object's text.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetPrivateDataText(Guid name, string text)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (string.IsNullOrEmpty(text))
            {
                text = "<unnamed>";
            }

            if (text.Length > 255)
            {
                text = text.Substring(0, 255);
            }

            byte[] textBytes = Encoding.ASCII.GetBytes(text);
            this.device.SetPrivateData(ref name, (uint)textBytes.Length, textBytes);
        }

        /// <summary>
        /// Gets an application-defined data from the object that is associated with a GUID.
        /// </summary>
        /// <param name="name">A GUID identifying the data.</param>
        /// <returns>The object's text.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string GetPrivateDataText(Guid name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            uint dataSize = 256;
            byte[] data = new byte[dataSize];

            this.device.GetPrivateData(ref name, ref dataSize, data);

            var text = Encoding.ASCII.GetString(data);
            return text.Substring(0, text.IndexOf('\0'));
        }

        /// <summary>
        /// Sets a unique name to objects in order to assist the developer during debugging.
        /// </summary>
        /// <param name="name">The friendly name.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetDebugName(string name)
        {
            this.SetPrivateDataText(D3D11WellKnownPrivateDataId.DebugObjectName, name);
        }

        /// <summary>
        /// Gets a unique name to objects in order to assist the developer during debugging.
        /// </summary>
        /// <returns>The friendly name.</returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string GetDebugName()
        {
            return this.GetPrivateDataText(D3D11WellKnownPrivateDataId.DebugObjectName);
        }

        /// <summary>
        /// Creates a buffer (vertex buffer, index buffer, or shader constant buffer).
        /// </summary>
        /// <param name="desc">Describes the buffer.</param>
        /// <returns>The buffer object created.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11Buffer CreateBuffer(D3D11BufferDesc desc)
        {
            return new D3D11Buffer(this.device.CreateBuffer(ref desc, IntPtr.Zero));
        }

        /// <summary>
        /// Creates a buffer (vertex buffer, index buffer, or shader constant buffer).
        /// </summary>
        /// <param name="desc">Describes the buffer.</param>
        /// <param name="data">Describes the initialization data.</param>
        /// <returns>The buffer object created.</returns>
        [SuppressMessage("Microsoft.Reliability", "CA2000:Supprimer les objets avant la mise hors de portée", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11Buffer CreateBuffer(D3D11BufferDesc desc, D3D11SubResourceData data)
        {
            D3D11SubResourceDataPtr resource = new D3D11SubResourceDataPtr
            {
                SysMem = Marshal.UnsafeAddrOfPinnedArrayElement(data.Data, 0),
                SysMemPitch = data.Pitch,
                SysMemSlicePitch = data.SlicePitch
            };

            GCHandle resourceHandle = GCHandle.Alloc(resource, GCHandleType.Pinned);

            try
            {
                return new D3D11Buffer(this.device.CreateBuffer(ref desc, resourceHandle.AddrOfPinnedObject()));
            }
            finally
            {
                resourceHandle.Free();
            }
        }

        /// <summary>
        /// Creates a buffer (vertex buffer, index buffer, or shader constant buffer).
        /// </summary>
        /// <typeparam name="T">A struct.</typeparam>
        /// <param name="desc">Describes the buffer.</param>
        /// <param name="data">Describes the initialization data.</param>
        /// <param name="sysMemPitch">The distance (in bytes) from the beginning of one line of a texture to the next line.</param>
        /// <param name="sysMemSlicePitch">The distance (in bytes) from the beginning of one depth level to the next.</param>
        /// <returns>The buffer object created.</returns>
        [SuppressMessage("Microsoft.Reliability", "CA2000:Supprimer les objets avant la mise hors de portée", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11Buffer CreateBuffer<T>(D3D11BufferDesc desc, T data, uint sysMemPitch, uint sysMemSlicePitch)
            where T : struct
        {
            int dataSize = Marshal.SizeOf(typeof(T));
            IntPtr dataPtr = Marshal.AllocHGlobal(dataSize);

            try
            {
                Marshal.StructureToPtr(data, dataPtr, false);

                D3D11SubResourceDataPtr resource = new D3D11SubResourceDataPtr
                {
                    SysMem = dataPtr,
                    SysMemPitch = sysMemPitch,
                    SysMemSlicePitch = sysMemSlicePitch
                };

                GCHandle resourceHandle = GCHandle.Alloc(resource, GCHandleType.Pinned);

                try
                {
                    return new D3D11Buffer(this.device.CreateBuffer(ref desc, resourceHandle.AddrOfPinnedObject()));
                }
                finally
                {
                    resourceHandle.Free();
                }
            }
            finally
            {
                Marshal.FreeHGlobal(dataPtr);
            }
        }

        /// <summary>
        /// Creates a buffer (vertex buffer, index buffer, or shader constant buffer).
        /// </summary>
        /// <typeparam name="T">A array of struct.</typeparam>
        /// <param name="desc">Describes the buffer.</param>
        /// <param name="data">Describes the initialization data.</param>
        /// <param name="sysMemPitch">The distance (in bytes) from the beginning of one line of a texture to the next line.</param>
        /// <param name="sysMemSlicePitch">The distance (in bytes) from the beginning of one depth level to the next.</param>
        /// <returns>The buffer object created.</returns>
        [SuppressMessage("Microsoft.Reliability", "CA2000:Supprimer les objets avant la mise hors de portée", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11Buffer CreateBuffer<T>(D3D11BufferDesc desc, T[] data, uint sysMemPitch, uint sysMemSlicePitch)
            where T : struct
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            if (data.Length == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(data));
            }

            int dataSize = Marshal.SizeOf(typeof(T));
            IntPtr dataPtr = Marshal.AllocHGlobal(dataSize * data.Length);

            try
            {
                for (int i = 0; i < data.Length; i++)
                {
                    Marshal.StructureToPtr(data[i], IntPtr.Add(dataPtr, dataSize * i), false);
                }

                D3D11SubResourceDataPtr resource = new D3D11SubResourceDataPtr
                {
                    SysMem = dataPtr,
                    SysMemPitch = sysMemPitch,
                    SysMemSlicePitch = sysMemSlicePitch
                };

                GCHandle resourceHandle = GCHandle.Alloc(resource, GCHandleType.Pinned);

                try
                {
                    return new D3D11Buffer(this.device.CreateBuffer(ref desc, resourceHandle.AddrOfPinnedObject()));
                }
                finally
                {
                    resourceHandle.Free();
                }
            }
            finally
            {
                Marshal.FreeHGlobal(dataPtr);
            }
        }

        /// <summary>
        /// Creates an array of 1D textures.
        /// </summary>
        /// <param name="desc">Describes a 1D texture resource.</param>
        /// <returns>The created texture.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11Texture1D CreateTexture1D(D3D11Texture1DDesc desc)
        {
            return new D3D11Texture1D(this.device.CreateTexture1D(ref desc, null));
        }

        /// <summary>
        /// Creates an array of 1D textures.
        /// </summary>
        /// <param name="desc">Describes a 1D texture resource.</param>
        /// <param name="data">Describe subresources for the 1D texture resource.</param>
        /// <returns>The created texture.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11Texture1D CreateTexture1D(D3D11Texture1DDesc desc, D3D11SubResourceData[] data)
        {
            if (data == null)
            {
                return new D3D11Texture1D(this.device.CreateTexture1D(ref desc, null));
            }

            int length = desc.MipLevels == 0 ? (int)desc.ArraySize : (int)(desc.MipLevels * desc.ArraySize);

            if (data.Length != length)
            {
                throw new ArgumentOutOfRangeException(nameof(data));
            }

            var subResources = new D3D11SubResourceDataPtr[length];

            for (int i = 0; i < length; i++)
            {
                subResources[i].SysMem = Marshal.UnsafeAddrOfPinnedArrayElement(data[i].Data, 0);
                subResources[i].SysMemPitch = data[i].Pitch;
                subResources[i].SysMemSlicePitch = data[i].SlicePitch;
            }

            return new D3D11Texture1D(this.device.CreateTexture1D(ref desc, subResources));
        }

        /// <summary>
        /// Create an array of 2D textures.
        /// </summary>
        /// <param name="desc">Describes a 2D texture resource.</param>
        /// <returns>The created texture.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11Texture2D CreateTexture2D(D3D11Texture2DDesc desc)
        {
            return new D3D11Texture2D(this.device.CreateTexture2D(ref desc, null));
        }

        /// <summary>
        /// Create an array of 2D textures.
        /// </summary>
        /// <param name="desc">Describes a 2D texture resource.</param>
        /// <param name="data">Describe subresources for the 2D texture resource.</param>
        /// <returns>The created texture.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11Texture2D CreateTexture2D(D3D11Texture2DDesc desc, D3D11SubResourceData[] data)
        {
            if (data == null)
            {
                return new D3D11Texture2D(this.device.CreateTexture2D(ref desc, null));
            }

            int length = desc.MipLevels == 0 ? (int)desc.ArraySize : (int)(desc.MipLevels * desc.ArraySize);

            if (data.Length != length)
            {
                throw new ArgumentOutOfRangeException(nameof(data));
            }

            var subResources = new D3D11SubResourceDataPtr[length];

            for (int i = 0; i < length; i++)
            {
                subResources[i].SysMem = Marshal.UnsafeAddrOfPinnedArrayElement(data[i].Data, 0);
                subResources[i].SysMemPitch = data[i].Pitch;
                subResources[i].SysMemSlicePitch = data[i].SlicePitch;
            }

            return new D3D11Texture2D(this.device.CreateTexture2D(ref desc, subResources));
        }

        /// <summary>
        /// Create a single 3D texture.
        /// </summary>
        /// <param name="desc">Describes a 3D texture resource.</param>
        /// <returns>The created texture.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11Texture3D CreateTexture3D(D3D11Texture3DDesc desc)
        {
            return new D3D11Texture3D(this.device.CreateTexture3D(ref desc, null));
        }

        /// <summary>
        /// Create a single 3D texture.
        /// </summary>
        /// <param name="desc">Describes a 3D texture resource.</param>
        /// <param name="data">Describe subresources for the 3D texture resource.</param>
        /// <returns>The created texture.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11Texture3D CreateTexture3D(D3D11Texture3DDesc desc, D3D11SubResourceData[] data)
        {
            if (data == null)
            {
                return new D3D11Texture3D(this.device.CreateTexture3D(ref desc, null));
            }

            int length = desc.MipLevels == 0 ? 1 : (int)desc.MipLevels;

            if (data.Length != length)
            {
                throw new ArgumentOutOfRangeException(nameof(data));
            }

            var subResources = new D3D11SubResourceDataPtr[length];

            for (int i = 0; i < length; i++)
            {
                subResources[i].SysMem = Marshal.UnsafeAddrOfPinnedArrayElement(data[i].Data, 0);
                subResources[i].SysMemPitch = data[i].Pitch;
                subResources[i].SysMemSlicePitch = data[i].SlicePitch;
            }

            return new D3D11Texture3D(this.device.CreateTexture3D(ref desc, subResources));
        }

        /// <summary>
        /// Create a shader resource view for accessing data in a resource.
        /// </summary>
        /// <param name="resource">The resource that will serve as input to a shader.</param>
        /// <param name="desc">A shader resource view description.</param>
        /// <returns>The created shader resource view.</returns>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Reliability", "CA2000:Supprimer les objets avant la mise hors de portée", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11ShaderResourceView CreateShaderResourceView(D3D11Resource resource, D3D11ShaderResourceViewDesc? desc)
        {
            if (resource == null)
            {
                throw new ArgumentNullException(nameof(resource));
            }

            if (desc == null)
            {
                return new D3D11ShaderResourceView(this.device.CreateShaderResourceView(resource.GetHandle<ID3D11Resource>(), IntPtr.Zero));
            }
            else
            {
                IntPtr descPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(D3D11ShaderResourceViewDesc)));

                try
                {
                    Marshal.StructureToPtr(desc.Value, descPtr, false);
                    return new D3D11ShaderResourceView(this.device.CreateShaderResourceView(resource.GetHandle<ID3D11Resource>(), descPtr));
                }
                finally
                {
                    Marshal.FreeHGlobal(descPtr);
                }
            }
        }

        /// <summary>
        /// Creates a view for accessing an unordered access resource.
        /// </summary>
        /// <param name="resource">A resources that will serve as an input to a shader.</param>
        /// <param name="desc">A shader resource view description.</param>
        /// <returns>The created unordered-access view.</returns>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Reliability", "CA2000:Supprimer les objets avant la mise hors de portée", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11UnorderedAccessView CreateUnorderedAccessView(D3D11Resource resource, D3D11UnorderedAccessViewDesc? desc)
        {
            if (resource == null)
            {
                throw new ArgumentNullException(nameof(resource));
            }

            if (desc == null)
            {
                return new D3D11UnorderedAccessView(this.device.CreateUnorderedAccessView(resource.GetHandle<ID3D11Resource>(), IntPtr.Zero));
            }
            else
            {
                IntPtr descPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(D3D11UnorderedAccessViewDesc)));

                try
                {
                    Marshal.StructureToPtr(desc.Value, descPtr, false);
                    return new D3D11UnorderedAccessView(this.device.CreateUnorderedAccessView(resource.GetHandle<ID3D11Resource>(), descPtr));
                }
                finally
                {
                    Marshal.FreeHGlobal(descPtr);
                }
            }
        }

        /// <summary>
        /// Creates a render-target view for accessing resource data.
        /// </summary>
        /// <param name="resource">A render target resource.</param>
        /// <param name="desc">A render-target view description.</param>
        /// <returns>The created render target view.</returns>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Reliability", "CA2000:Supprimer les objets avant la mise hors de portée", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11RenderTargetView CreateRenderTargetView(D3D11Resource resource, D3D11RenderTargetViewDesc? desc)
        {
            if (resource == null)
            {
                throw new ArgumentNullException(nameof(resource));
            }

            if (desc == null)
            {
                return new D3D11RenderTargetView(this.device.CreateRenderTargetView(resource.GetHandle<ID3D11Resource>(), IntPtr.Zero));
            }
            else
            {
                IntPtr descPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(D3D11RenderTargetViewDesc)));

                try
                {
                    Marshal.StructureToPtr(desc.Value, descPtr, false);
                    return new D3D11RenderTargetView(this.device.CreateRenderTargetView(resource.GetHandle<ID3D11Resource>(), descPtr));
                }
                finally
                {
                    Marshal.FreeHGlobal(descPtr);
                }
            }
        }

        /// <summary>
        /// Create a depth-stencil view for accessing resource data.
        /// </summary>
        /// <param name="resource">The resource that will serve as the depth-stencil surface.</param>
        /// <param name="desc">A depth-stencil-view description.</param>
        /// <returns>The created depth-stencil view.</returns>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Reliability", "CA2000:Supprimer les objets avant la mise hors de portée", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11DepthStencilView CreateDepthStencilView(D3D11Resource resource, D3D11DepthStencilViewDesc? desc)
        {
            if (resource == null)
            {
                throw new ArgumentNullException(nameof(resource));
            }

            if (desc == null)
            {
                return new D3D11DepthStencilView(this.device.CreateDepthStencilView(resource.GetHandle<ID3D11Resource>(), IntPtr.Zero));
            }
            else
            {
                IntPtr descPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(D3D11DepthStencilViewDesc)));

                try
                {
                    Marshal.StructureToPtr(desc.Value, descPtr, false);
                    return new D3D11DepthStencilView(this.device.CreateDepthStencilView(resource.GetHandle<ID3D11Resource>(), descPtr));
                }
                finally
                {
                    Marshal.FreeHGlobal(descPtr);
                }
            }
        }

        /// <summary>
        /// Create an input-layout object to describe the input-buffer data for the input-assembler stage.
        /// </summary>
        /// <param name="elementDescs">An array of the input-assembler stage input data types; each type is described by an element description.</param>
        /// <param name="shaderBytecodeWithInputSignature">The compiled shader. The compiled shader code contains a input signature which is validated against the array of elements.</param>
        /// <returns>The created input-layout object.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11InputLayout CreateInputLayout(D3D11InputElementDesc[] elementDescs, byte[] shaderBytecodeWithInputSignature)
        {
            if (elementDescs == null)
            {
                throw new ArgumentNullException(nameof(elementDescs));
            }

            return new D3D11InputLayout(this.device.CreateInputLayout(
                elementDescs,
                (uint)elementDescs.Length,
                shaderBytecodeWithInputSignature,
                shaderBytecodeWithInputSignature == null ? UIntPtr.Zero : new UIntPtr((uint)shaderBytecodeWithInputSignature.Length)));
        }

        /// <summary>
        /// Create a vertex shader object from a compiled shader.
        /// </summary>
        /// <param name="shaderBytecode">The compiled shader.</param>
        /// <param name="classLinkage">A class linkage interface.</param>
        /// <returns>The created vertex shader.</returns>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11VertexShader CreateVertexShader(byte[] shaderBytecode, D3D11ClassLinkage classLinkage)
        {
            if (shaderBytecode == null)
            {
                throw new ArgumentNullException(nameof(shaderBytecode));
            }

            return new D3D11VertexShader(this.device.CreateVertexShader(
                shaderBytecode,
                new UIntPtr((uint)shaderBytecode.Length),
                classLinkage?.GetHandle<ID3D11ClassLinkage>()));
        }

        /// <summary>
        /// Create a geometry shader.
        /// </summary>
        /// <param name="shaderBytecode">The compiled shader.</param>
        /// <param name="classLinkage">A class linkage interface.</param>
        /// <returns>The created geometry shader.</returns>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11GeometryShader CreateGeometryShader(byte[] shaderBytecode, D3D11ClassLinkage classLinkage)
        {
            if (shaderBytecode == null)
            {
                throw new ArgumentNullException(nameof(shaderBytecode));
            }

            return new D3D11GeometryShader(this.device.CreateGeometryShader(
                shaderBytecode,
                new UIntPtr((uint)shaderBytecode.Length),
                classLinkage?.GetHandle<ID3D11ClassLinkage>()));
        }

        /// <summary>
        /// Creates a geometry shader that can write to streaming output buffers.
        /// </summary>
        /// <param name="shaderBytecode">The compiled geometry shader for a standard geometry shader plus stream output.</param>
        /// <param name="streamOutputDeclaration">A <see cref="D3D11StreamOutputDeclarationEntry"/> array.</param>
        /// <param name="bufferStrides">An array of buffer strides; each stride is the size of an element for that buffer.</param>
        /// <param name="rasterizedStream">The index number of the stream to be sent to the rasterizer stage.</param>
        /// <param name="classLinkage">A class linkage interface.</param>
        /// <returns>The created geometry shader.</returns>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11GeometryShader CreateGeometryShaderWithStreamOutput(
            byte[] shaderBytecode,
            D3D11StreamOutputDeclarationEntry[] streamOutputDeclaration,
            uint[] bufferStrides,
            uint rasterizedStream,
            D3D11ClassLinkage classLinkage)
        {
            if (shaderBytecode == null)
            {
                throw new ArgumentNullException(nameof(shaderBytecode));
            }

            if (streamOutputDeclaration == null)
            {
                throw new ArgumentNullException(nameof(streamOutputDeclaration));
            }

            if (bufferStrides == null)
            {
                throw new ArgumentNullException(nameof(bufferStrides));
            }

            return new D3D11GeometryShader(this.device.CreateGeometryShaderWithStreamOutput(
                shaderBytecode,
                new UIntPtr((uint)shaderBytecode.Length),
                streamOutputDeclaration,
                (uint)streamOutputDeclaration.Length,
                bufferStrides,
                (uint)bufferStrides.Length,
                rasterizedStream,
                classLinkage?.GetHandle<ID3D11ClassLinkage>()));
        }

        /// <summary>
        /// Create a pixel shader.
        /// </summary>
        /// <param name="shaderBytecode">The compiled shader.</param>
        /// <param name="classLinkage">A class linkage interface.</param>
        /// <returns>The created pixel shader.</returns>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11PixelShader CreatePixelShader(byte[] shaderBytecode, D3D11ClassLinkage classLinkage)
        {
            if (shaderBytecode == null)
            {
                throw new ArgumentNullException(nameof(shaderBytecode));
            }

            return new D3D11PixelShader(this.device.CreatePixelShader(
                shaderBytecode,
                new UIntPtr((uint)shaderBytecode.Length),
                classLinkage?.GetHandle<ID3D11ClassLinkage>()));
        }

        /// <summary>
        /// Create a hull shader.
        /// </summary>
        /// <param name="shaderBytecode">The compiled shader.</param>
        /// <param name="classLinkage">A class linkage interface.</param>
        /// <returns>The created hull shader.</returns>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11HullShader CreateHullShader(byte[] shaderBytecode, D3D11ClassLinkage classLinkage)
        {
            if (shaderBytecode == null)
            {
                throw new ArgumentNullException(nameof(shaderBytecode));
            }

            return new D3D11HullShader(this.device.CreateHullShader(
                shaderBytecode,
                new UIntPtr((uint)shaderBytecode.Length),
                classLinkage?.GetHandle<ID3D11ClassLinkage>()));
        }

        /// <summary>
        /// Create a domain shader.
        /// </summary>
        /// <param name="shaderBytecode">The compiled shader.</param>
        /// <param name="classLinkage">A class linkage interface.</param>
        /// <returns>The created domain shader.</returns>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11DomainShader CreateDomainShader(byte[] shaderBytecode, D3D11ClassLinkage classLinkage)
        {
            if (shaderBytecode == null)
            {
                throw new ArgumentNullException(nameof(shaderBytecode));
            }

            return new D3D11DomainShader(this.device.CreateDomainShader(
                shaderBytecode,
                new UIntPtr((uint)shaderBytecode.Length),
                classLinkage?.GetHandle<ID3D11ClassLinkage>()));
        }

        /// <summary>
        /// Create a compute shader.
        /// </summary>
        /// <param name="shaderBytecode">The compiled shader.</param>
        /// <param name="classLinkage">A class linkage interface.</param>
        /// <returns>The created compute shader.</returns>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11ComputeShader CreateComputeShader(byte[] shaderBytecode, D3D11ClassLinkage classLinkage)
        {
            if (shaderBytecode == null)
            {
                throw new ArgumentNullException(nameof(shaderBytecode));
            }

            return new D3D11ComputeShader(this.device.CreateComputeShader(
                shaderBytecode,
                new UIntPtr((uint)shaderBytecode.Length),
                classLinkage?.GetHandle<ID3D11ClassLinkage>()));
        }

        /// <summary>
        /// Creates class linkage libraries to enable dynamic shader linkage.
        /// </summary>
        /// <returns>The created class linkage.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11ClassLinkage CreateClassLinkage()
        {
            return new D3D11ClassLinkage(this.device.CreateClassLinkage());
        }

        /// <summary>
        /// Create a blend-state object that encapsules blend state for the output-merger stage.
        /// </summary>
        /// <param name="desc">A blend-state description.</param>
        /// <returns>The created blend-state object.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11BlendState CreateBlendState(D3D11BlendDesc desc)
        {
            return new D3D11BlendState(this.device.CreateBlendState(ref desc));
        }

        /// <summary>
        /// Create a depth-stencil state object that encapsulates depth-stencil test information for the output-merger stage.
        /// </summary>
        /// <param name="desc">A depth-stencil state description.</param>
        /// <returns>The created depth-stencil state object.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11DepthStencilState CreateDepthStencilState(D3D11DepthStencilDesc desc)
        {
            return new D3D11DepthStencilState(this.device.CreateDepthStencilState(ref desc));
        }

        /// <summary>
        /// Create a rasterizer state object that tells the rasterizer stage how to behave.
        /// </summary>
        /// <param name="desc">A rasterizer state description.</param>
        /// <returns>The created rasterizer state object.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11RasterizerState CreateRasterizerState(D3D11RasterizerDesc desc)
        {
            return new D3D11RasterizerState(this.device.CreateRasterizerState(ref desc));
        }

        /// <summary>
        /// Create a sampler-state object that encapsulates sampling information for a texture.
        /// </summary>
        /// <param name="desc">A sampler state description.</param>
        /// <returns>The created sampler-state object.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11SamplerState CreateSamplerState(D3D11SamplerDesc desc)
        {
            return new D3D11SamplerState(this.device.CreateSamplerState(ref desc));
        }

        /// <summary>
        /// Creates an object for querying information from the GPU.
        /// </summary>
        /// <param name="desc">A query description.</param>
        /// <returns>The created query.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11Query CreateQuery(D3D11QueryDesc desc)
        {
            return new D3D11Query(this.device.CreateQuery(ref desc));
        }

        /// <summary>
        /// Creates a predicate.
        /// </summary>
        /// <param name="desc">A query description for a predicate.</param>
        /// <returns>The created predicate.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11Predicate CreatePredicate(D3D11QueryDesc desc)
        {
            return new D3D11Predicate(this.device.CreatePredicate(ref desc));
        }

        /// <summary>
        /// Create a counter object for measuring GPU performance.
        /// </summary>
        /// <param name="desc">A counter description.</param>
        /// <returns>The created counter.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11Counter CreateCounter(D3D11CounterDesc desc)
        {
            return new D3D11Counter(this.device.CreateCounter(ref desc));
        }

        /// <summary>
        /// Creates a deferred context, which can record command lists.
        /// </summary>
        /// <returns>The created deferred context.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11DeviceContext CreateDeferredContext()
        {
            return new D3D11DeviceContext(this.device.CreateDeferredContext(0));
        }

        /// <summary>
        /// Give a device access to a shared resource created on a different device.
        /// </summary>
        /// <param name="resourceHandle">A resource handle.</param>
        /// <param name="returnedInterface">The globally unique identifier (GUID) for the resource interface.</param>
        /// <returns>A pointer to the resource we are gaining access to.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object OpenSharedResource(IntPtr resourceHandle, Guid returnedInterface)
        {
            return this.device.OpenSharedResource(resourceHandle, ref returnedInterface);
        }

        /// <summary>
        /// Get the support of a given format on the installed video device.
        /// </summary>
        /// <param name="format">A format for which to check for support.</param>
        /// <param name="formatSupport">Describes how the specified format is supported on the installed device.</param>
        /// <returns>A boolean value.</returns>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool CheckFormatSupport(DxgiFormat format, out D3D11FormatSupport formatSupport)
        {
            return this.device.CheckFormatSupport(format, out formatSupport);
        }

        /// <summary>
        /// Get the number of quality levels available during multisampling.
        /// </summary>
        /// <param name="format">The texture format.</param>
        /// <param name="sampleCount">The number of samples during multisampling.</param>
        /// <param name="numQualityLevels">The number of quality levels supported by the adapter.</param>
        /// <returns>A boolean value.</returns>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "2#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool CheckMultisampleQualityLevels(DxgiFormat format, uint sampleCount, out uint numQualityLevels)
        {
            return this.device.CheckMultisampleQualityLevels(format, sampleCount, out numQualityLevels);
        }

        /// <summary>
        /// Get a counter's information.
        /// </summary>
        /// <returns>A counter information.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public D3D11CounterInfo CheckCounterInfo()
        {
            D3D11CounterInfo counterInfo;
            this.device.CheckCounterInfo(out counterInfo);
            return counterInfo;
        }

        /// <summary>
        /// Get the type, name, units of measure, and a description of an existing counter.
        /// </summary>
        /// <param name="desc">A counter description.</param>
        /// <param name="type">The data type of a counter.</param>
        /// <param name="activeCounters">The number of hardware counters that are needed for this counter type to be created. All instances of the same counter type use the same hardware counters.</param>
        /// <returns>A boolean value.</returns>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "2#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool CheckCounter(D3D11CounterDesc desc, out D3D11CounterDataType type, out uint activeCounters)
        {
            uint nameLength = 0;
            uint unitsLength = 0;
            uint descriptionLength = 0;

            return this.device.CheckCounter(
                ref desc,
                out type,
                out activeCounters,
                null,
                ref nameLength,
                null,
                ref unitsLength,
                null,
                ref descriptionLength);
        }

        /// <summary>
        /// Get the type, name, units of measure, and a description of an existing counter.
        /// </summary>
        /// <param name="desc">A counter description.</param>
        /// <param name="type">The data type of a counter.</param>
        /// <param name="activeCounters">The number of hardware counters that are needed for this counter type to be created. All instances of the same counter type use the same hardware counters.</param>
        /// <param name="name">String to be filled with a brief name for the counter.</param>
        /// <param name="units">Name of the units a counter measures.</param>
        /// <param name="description">A description of the counter.</param>
        /// <returns>A boolean value.</returns>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "2#", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "3#", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "4#", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "5#", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool CheckCounter(
            D3D11CounterDesc desc,
            out D3D11CounterDataType type,
            out uint activeCounters,
            out string name,
            out string units,
            out string description)
        {
            uint nameLength = 1;
            uint unitsLength = 1;
            uint descriptionLength = 1;

            this.device.CheckCounter(
                ref desc,
                out type,
                out activeCounters,
                null,
                ref nameLength,
                null,
                ref unitsLength,
                null,
                ref descriptionLength);

            StringBuilder nameBuilder = new StringBuilder((int)nameLength);
            StringBuilder unitsBuilder = new StringBuilder((int)unitsLength);
            StringBuilder descriptionBuilder = new StringBuilder((int)descriptionLength);

            bool ret = this.device.CheckCounter(
                ref desc,
                out type,
                out activeCounters,
                nameBuilder,
                ref nameLength,
                unitsBuilder,
                ref unitsLength,
                descriptionBuilder,
                ref descriptionLength);

            name = nameBuilder.ToString();
            units = unitsBuilder.ToString();
            description = descriptionBuilder.ToString();

            return ret;
        }

        /// <summary>
        /// Gets information about the features that are supported by the current graphics driver.
        /// </summary>
        /// <param name="feature">Describes which feature to query for support.</param>
        /// <returns>A structure filled with data that describes the feature support.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object CheckFeatureSupport(D3D11Feature feature)
        {
            switch (feature)
            {
                case D3D11Feature.Threading:
                    return this.CheckFeatureSupport<D3D11FeatureDataThreading>(D3D11Feature.Threading);

                case D3D11Feature.Doubles:
                    return this.CheckFeatureSupport<D3D11FeatureDataDoubles>(D3D11Feature.Doubles);

                case D3D11Feature.FormatSupport:
                    return this.CheckFeatureSupport<D3D11FeatureDataFormatSupport>(D3D11Feature.FormatSupport);

                case D3D11Feature.FormatSupport2:
                    return this.CheckFeatureSupport<D3D11FeatureDataFormatSupport2>(D3D11Feature.FormatSupport2);

                case D3D11Feature.D3D10XHardwareOptions:
                    return this.CheckFeatureSupport<D3D11FeatureDataD3D10XHardwareOptions>(D3D11Feature.D3D10XHardwareOptions);

                case D3D11Feature.D3D11Options:
                    return this.CheckFeatureSupport<D3D11FeatureDataD3D11Options>(D3D11Feature.D3D11Options);

                case D3D11Feature.ArchitectureInfo:
                    return this.CheckFeatureSupport<D3D11FeatureDataArchitectureInfo>(D3D11Feature.ArchitectureInfo);

                case D3D11Feature.D3D9Options:
                    return this.CheckFeatureSupport<D3D11FeatureDataD3D9Options>(D3D11Feature.D3D9Options);

                case D3D11Feature.ShaderMinPrecisionSupport:
                    return this.CheckFeatureSupport<D3D11FeatureDataShaderMinPrecisionSupport>(D3D11Feature.ShaderMinPrecisionSupport);

                case D3D11Feature.D3D9ShadowSupport:
                    return this.CheckFeatureSupport<D3D11FeatureDataD3D9ShadowSupport>(D3D11Feature.D3D9ShadowSupport);

                case D3D11Feature.D3D11Options1:
                    return this.CheckFeatureSupport<D3D11FeatureDataD3D11Options1>(D3D11Feature.D3D11Options1);

                case D3D11Feature.D3D9SimpleInstancingSupport:
                    return this.CheckFeatureSupport<D3D11FeatureDataD3D9SimpleInstancingSupport>(D3D11Feature.D3D9SimpleInstancingSupport);

                case D3D11Feature.MarkerSupport:
                    return this.CheckFeatureSupport<D3D11FeatureDataMarkerSupport>(D3D11Feature.MarkerSupport);

                case D3D11Feature.D3D9Options1:
                    return this.CheckFeatureSupport<D3D11FeatureDataD3D9Options1>(D3D11Feature.D3D9Options1);

                default:
                    throw new ArgumentOutOfRangeException(nameof(feature));
            }
        }

        /// <summary>
        /// Gets information about the features that are supported by the current graphics driver.
        /// </summary>
        /// <returns>A structure filled with data that describes the feature support.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11FeatureDataThreading CheckFeatureSupportThreading()
        {
            return this.CheckFeatureSupport<D3D11FeatureDataThreading>(D3D11Feature.Threading);
        }

        /// <summary>
        /// Gets information about the features that are supported by the current graphics driver.
        /// </summary>
        /// <returns>A structure filled with data that describes the feature support.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11FeatureDataDoubles CheckFeatureSupportDoubles()
        {
            return this.CheckFeatureSupport<D3D11FeatureDataDoubles>(D3D11Feature.Doubles);
        }

        /// <summary>
        /// Gets information about the features that are supported by the current graphics driver.
        /// </summary>
        /// <returns>A structure filled with data that describes the feature support.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11FeatureDataFormatSupport CheckFeatureSupportFormatSupport()
        {
            return this.CheckFeatureSupport<D3D11FeatureDataFormatSupport>(D3D11Feature.FormatSupport);
        }

        /// <summary>
        /// Gets information about the features that are supported by the current graphics driver.
        /// </summary>
        /// <returns>A structure filled with data that describes the feature support.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11FeatureDataFormatSupport2 CheckFeatureSupportFormatSupport2()
        {
            return this.CheckFeatureSupport<D3D11FeatureDataFormatSupport2>(D3D11Feature.FormatSupport2);
        }

        /// <summary>
        /// Gets information about the features that are supported by the current graphics driver.
        /// </summary>
        /// <returns>A structure filled with data that describes the feature support.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11FeatureDataD3D10XHardwareOptions CheckFeatureSupportD3D10XHardwareOptions()
        {
            return this.CheckFeatureSupport<D3D11FeatureDataD3D10XHardwareOptions>(D3D11Feature.D3D10XHardwareOptions);
        }

        /// <summary>
        /// Gets information about the features that are supported by the current graphics driver.
        /// </summary>
        /// <returns>A structure filled with data that describes the feature support.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11FeatureDataD3D11Options CheckFeatureSupportD3D11Options()
        {
            return this.CheckFeatureSupport<D3D11FeatureDataD3D11Options>(D3D11Feature.D3D11Options);
        }

        /// <summary>
        /// Gets information about the features that are supported by the current graphics driver.
        /// </summary>
        /// <returns>A structure filled with data that describes the feature support.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11FeatureDataArchitectureInfo CheckFeatureSupportArchitectureInfo()
        {
            return this.CheckFeatureSupport<D3D11FeatureDataArchitectureInfo>(D3D11Feature.ArchitectureInfo);
        }

        /// <summary>
        /// Gets information about the features that are supported by the current graphics driver.
        /// </summary>
        /// <returns>A structure filled with data that describes the feature support.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11FeatureDataD3D9Options CheckFeatureSupportD3D9Options()
        {
            return this.CheckFeatureSupport<D3D11FeatureDataD3D9Options>(D3D11Feature.D3D9Options);
        }

        /// <summary>
        /// Gets information about the features that are supported by the current graphics driver.
        /// </summary>
        /// <returns>A structure filled with data that describes the feature support.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11FeatureDataShaderMinPrecisionSupport CheckFeatureSupportShaderMinPrecisionSupport()
        {
            return this.CheckFeatureSupport<D3D11FeatureDataShaderMinPrecisionSupport>(D3D11Feature.ShaderMinPrecisionSupport);
        }

        /// <summary>
        /// Gets information about the features that are supported by the current graphics driver.
        /// </summary>
        /// <returns>A structure filled with data that describes the feature support.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11FeatureDataD3D9ShadowSupport CheckFeatureSupportD3D9ShadowSupport()
        {
            return this.CheckFeatureSupport<D3D11FeatureDataD3D9ShadowSupport>(D3D11Feature.D3D9ShadowSupport);
        }

        /// <summary>
        /// Gets information about the features that are supported by the current graphics driver.
        /// </summary>
        /// <returns>A structure filled with data that describes the feature support.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11FeatureDataD3D11Options1 CheckFeatureSupportD3D11Options1()
        {
            return this.CheckFeatureSupport<D3D11FeatureDataD3D11Options1>(D3D11Feature.D3D11Options1);
        }

        /// <summary>
        /// Gets information about the features that are supported by the current graphics driver.
        /// </summary>
        /// <returns>A structure filled with data that describes the feature support.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11FeatureDataD3D9SimpleInstancingSupport CheckFeatureSupportD3D9SimpleInstancingSupport()
        {
            return this.CheckFeatureSupport<D3D11FeatureDataD3D9SimpleInstancingSupport>(D3D11Feature.D3D9SimpleInstancingSupport);
        }

        /// <summary>
        /// Gets information about the features that are supported by the current graphics driver.
        /// </summary>
        /// <returns>A structure filled with data that describes the feature support.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11FeatureDataMarkerSupport CheckFeatureSupportMarkerSupport()
        {
            return this.CheckFeatureSupport<D3D11FeatureDataMarkerSupport>(D3D11Feature.MarkerSupport);
        }

        /// <summary>
        /// Gets information about the features that are supported by the current graphics driver.
        /// </summary>
        /// <returns>A structure filled with data that describes the feature support.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11FeatureDataD3D9Options1 CheckFeatureSupportD3D9Options1()
        {
            return this.CheckFeatureSupport<D3D11FeatureDataD3D9Options1>(D3D11Feature.D3D9Options1);
        }

        /// <summary>
        /// Get the reason why the device was removed.
        /// </summary>
        /// <returns>The removed reason exception.</returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Exception GetDeviceRemovedReason()
        {
            return Marshal.GetExceptionForHR(this.device.GetDeviceRemovedReason());
        }

        /// <summary>
        /// Throw a device removed reason exception.
        /// </summary>
        public void ThrowDeviceRemovedReason()
        {
            var reason = this.GetDeviceRemovedReason();

            if (reason != null)
            {
                throw reason;
            }
        }

        /// <summary>
        /// Gets an immediate context, which can play back command lists.
        /// </summary>
        /// <returns>An immediate context.</returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11DeviceContext GetImmediateContext()
        {
            ID3D11DeviceContext immediateContext;
            this.device.GetImmediateContext(out immediateContext);
            return new D3D11DeviceContext(immediateContext);
        }

        /// <summary>
        /// Gets information about the features that are supported by the current graphics driver.
        /// </summary>
        /// <typeparam name="T">The type of structure to return.</typeparam>
        /// <param name="feature">Describes which feature to query for support.</param>
        /// <returns>A structure filled with data that describes the feature support.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        private T CheckFeatureSupport<T>(D3D11Feature feature)
            where T : struct
        {
            int dataSize = Marshal.SizeOf(typeof(T));
            IntPtr dataPtr = Marshal.AllocHGlobal(dataSize);

            this.device.CheckFeatureSupport(feature, dataPtr, (uint)dataSize);

            T data = (T)Marshal.PtrToStructure(dataPtr, typeof(T));
            Marshal.FreeHGlobal(dataPtr);
            return data;
        }
    }
}
