// <copyright file="D3D11Device.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D3D11.ComInterfaces;
using JeremyAnsel.DirectX.DXCommon;
using JeremyAnsel.DirectX.Dxgi;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// The device interface represents a virtual adapter; it is used to create resources.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class D3D11Device : DXComObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid D3D11DeviceGuid = typeof(ID3D11Device).GUID;

    private readonly nint _comPtr;
    private readonly ID3D11Device* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11Device"/> class.
    /// </summary>
    public D3D11Device(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(ID3D11Device**)comPtr;
    }

    /// <summary>
    /// Gets the feature level of the hardware device.
    /// </summary>
    public D3D11FeatureLevel FeatureLevel
    {
        get { return _comImpl->GetFeatureLevel(_comPtr); }
    }

    /// <summary>
    /// Gets the options used during the call to create the device.
    /// </summary>
    public D3D11CreateDeviceOptions CreationOptions
    {
        get { return _comImpl->GetCreationOptions(_comPtr); }
    }

    /// <summary>
    /// Sets an application-defined data to the object and associates that data with a GUID.
    /// </summary>
    /// <param name="name">A GUID that identifies the data.</param>
    /// <param name="text">The object's text.</param>
    public void SetPrivateDataText(in Guid name, string? text)
    {
        if (string.IsNullOrEmpty(text))
        {
            text = "<unnamed>";
        }

        SetPrivateDataText(in name, text.AsSpan());
    }

    /// <summary>
    /// Sets an application-defined data to the object and associates that data with a GUID.
    /// </summary>
    /// <param name="name">A GUID that identifies the data.</param>
    /// <param name="text">The object's text.</param>
    public void SetPrivateDataText(in Guid name, ReadOnlySpan<char> text)
    {
        if (text.IsEmpty)
        {
            text = "<unnamed>".AsSpan();
        }

        if (text.Length > 255)
        {
            text = text[..255];
        }

        int bytesCount;
        fixed (char* textPtr = text)
        {
            bytesCount = Encoding.ASCII.GetByteCount(textPtr, text.Length);
        }

        byte* bytesPtr = stackalloc byte[bytesCount];

        fixed (char* textPtr = text)
        {
            Encoding.ASCII.GetBytes(textPtr, text.Length, bytesPtr, bytesCount);
        }

        int hr = _comImpl->SetPrivateData(_comPtr, in name, (uint)bytesCount, bytesPtr);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Gets an application-defined data from the object that is associated with a GUID.
    /// </summary>
    /// <param name="name">A GUID identifying the data.</param>
    /// <returns>The object's text.</returns>
    public string GetPrivateDataText(in Guid name)
    {
        uint dataSize = 256;
        byte* dataPtr = stackalloc byte[(int)dataSize];
        int hr = _comImpl->GetPrivateData(_comPtr, in name, &dataSize, dataPtr);
        Marshal.ThrowExceptionForHR(hr);
        string text = Encoding.ASCII.GetString(dataPtr, (int)dataSize);
        return text;
    }

    /// <summary>
    /// Gets an application-defined data from the object that is associated with a GUID.
    /// </summary>
    /// <param name="name">A GUID identifying the data.</param>
    /// <returns>The count.</returns>
    public int GetPrivateDataTextCharCount(in Guid name)
    {
        uint dataSize = 0;
        int hr = _comImpl->GetPrivateData(_comPtr, in name, &dataSize, null);
        Marshal.ThrowExceptionForHR(hr);
        return (int)dataSize;
    }

    /// <summary>
    /// Gets an application-defined data from the object that is associated with a GUID.
    /// </summary>
    /// <param name="name">A GUID identifying the data.</param>
    /// <param name="text">A char buffer.</param>
    /// <returns>The object's text.</returns>
    public int GetPrivateDataTextChars(in Guid name, Span<char> text)
    {
        uint dataSize = 256;
        byte* dataPtr = stackalloc byte[(int)dataSize];

        int hr = _comImpl->GetPrivateData(_comPtr, in name, &dataSize, dataPtr);
        Marshal.ThrowExceptionForHR(hr);

        int count;
        fixed (char* textPtr = text)
        {
            count = Encoding.ASCII.GetChars(dataPtr, (int)dataSize, textPtr, text.Length);
        }

        return count;
    }

    /// <summary>
    /// Sets a unique name to objects in order to assist the developer during debugging.
    /// </summary>
    /// <param name="name">The friendly name.</param>
    public void SetDebugName(string? name)
    {
        SetPrivateDataText(D3D11WellKnownPrivateDataId.DebugObjectName, name);
    }

    /// <summary>
    /// Sets a unique name to objects in order to assist the developer during debugging.
    /// </summary>
    /// <param name="name">The friendly name.</param>
    public void SetDebugName(ReadOnlySpan<char> name)
    {
        SetPrivateDataText(D3D11WellKnownPrivateDataId.DebugObjectName, name);
    }

    /// <summary>
    /// Gets a unique name to objects in order to assist the developer during debugging.
    /// </summary>
    /// <returns>The friendly name.</returns>
    public string GetDebugName()
    {
        return GetPrivateDataText(D3D11WellKnownPrivateDataId.DebugObjectName);
    }

    /// <summary>
    /// Gets an application-defined data from the object that is associated with a GUID.
    /// </summary>
    /// <param name="name">A GUID identifying the data.</param>
    /// <returns>The count.</returns>
    public int GetDebugNameCharCount()
    {
        return GetPrivateDataTextCharCount(D3D11WellKnownPrivateDataId.DebugObjectName);
    }

    /// <summary>
    /// Gets an application-defined data from the object that is associated with a GUID.
    /// </summary>
    /// <param name="name">A GUID identifying the data.</param>
    /// <param name="text">A char buffer.</param>
    /// <returns>The object's text.</returns>
    public int GetDebugNameChars(Span<char> text)
    {
        return GetPrivateDataTextChars(D3D11WellKnownPrivateDataId.DebugObjectName, text);
    }

    /// <summary>
    /// Creates a buffer (vertex buffer, index buffer, or shader constant buffer).
    /// </summary>
    /// <param name="desc">Describes the buffer.</param>
    /// <returns>The buffer object created.</returns>
    public D3D11Buffer CreateBuffer(in D3D11BufferDesc desc)
    {
        int size = D3D11BufferDesc.NativeRequiredSize();
        byte* descPtr = stackalloc byte[size];
        D3D11BufferDesc.NativeWriteTo((nint)descPtr, desc);
        nint ptr;
        int hr = _comImpl->CreateBuffer(_comPtr, descPtr, null, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D3D11Buffer(ptr);
    }

    /// <summary>
    /// Creates a buffer (vertex buffer, index buffer, or shader constant buffer).
    /// </summary>
    /// <param name="desc">Describes the buffer.</param>
    /// <param name="data">Describes the initialization data.</param>
    /// <returns>The buffer object created.</returns>
    public D3D11Buffer CreateBuffer(in D3D11BufferDesc desc, in D3D11SubResourceData data)
    {
        int descSize = D3D11BufferDesc.NativeRequiredSize();
        byte* descPtr = stackalloc byte[descSize];
        D3D11BufferDesc.NativeWriteTo((nint)descPtr, desc);

        D3D11SubResourceDataPtr resource = new()
        {
            SysMem = Marshal.UnsafeAddrOfPinnedArrayElement(data.Data, data.Index),
            SysMemPitch = data.Pitch,
            SysMemSlicePitch = data.SlicePitch
        };

        int resourceSize = D3D11SubResourceDataPtr.NativeRequiredSize();
        byte* resourcePtr = stackalloc byte[resourceSize];
        D3D11SubResourceDataPtr.NativeWriteTo((nint)resourcePtr, resource);

        nint ptr;
        int hr = _comImpl->CreateBuffer(_comPtr, descPtr, resourcePtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D3D11Buffer(ptr);
    }

    /// <summary>
    /// Creates a buffer (vertex buffer, index buffer, or shader constant buffer).
    /// </summary>
    /// <param name="desc">Describes the buffer.</param>
    /// <param name="data">Describes the initialization data.</param>
    /// <returns>The buffer object created.</returns>
    public D3D11Buffer CreateBuffer(in D3D11BufferDesc desc, in D3D11SubResourceDataPtr data)
    {
        int descSize = D3D11BufferDesc.NativeRequiredSize();
        byte* descPtr = stackalloc byte[descSize];
        D3D11BufferDesc.NativeWriteTo((nint)descPtr, desc);
        int resourceSize = D3D11SubResourceDataPtr.NativeRequiredSize();
        byte* resourcePtr = stackalloc byte[resourceSize];
        D3D11SubResourceDataPtr.NativeWriteTo((nint)resourcePtr, data);
        nint ptr;
        int hr = _comImpl->CreateBuffer(_comPtr, descPtr, resourcePtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D3D11Buffer(ptr);
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
    public D3D11Buffer CreateBuffer<T>(in D3D11BufferDesc desc, in T data, uint sysMemPitch, uint sysMemSlicePitch)
        where T : unmanaged
    {
        int descSize = D3D11BufferDesc.NativeRequiredSize();
        byte* descPtr = stackalloc byte[descSize];
        D3D11BufferDesc.NativeWriteTo((nint)descPtr, desc);

        fixed (void* dataPtr = &data)
        {
            D3D11SubResourceDataPtr resource = new()
            {
                SysMem = (nint)dataPtr,
                SysMemPitch = sysMemPitch,
                SysMemSlicePitch = sysMemSlicePitch
            };

            int resourceSize = D3D11SubResourceDataPtr.NativeRequiredSize();
            byte* resourcePtr = stackalloc byte[resourceSize];
            D3D11SubResourceDataPtr.NativeWriteTo((nint)resourcePtr, resource);

            nint ptr;
            int hr = _comImpl->CreateBuffer(_comPtr, descPtr, resourcePtr, &ptr);
            Marshal.ThrowExceptionForHR(hr);
            return new D3D11Buffer(ptr);
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
    public D3D11Buffer CreateBuffer<T>(in D3D11BufferDesc desc, T[]? data, uint sysMemPitch, uint sysMemSlicePitch)
        where T : unmanaged
    {
        if (data is null)
        {
            throw new ArgumentNullException(nameof(data));
        }

        return CreateBuffer<T>(desc, data.AsSpan(), sysMemPitch, sysMemSlicePitch);
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
    public D3D11Buffer CreateBuffer<T>(in D3D11BufferDesc desc, ReadOnlySpan<T> data, uint sysMemPitch, uint sysMemSlicePitch)
        where T : unmanaged
    {
        if (data.Length == 0)
        {
            throw new ArgumentOutOfRangeException(nameof(data));
        }

        int descSize = D3D11BufferDesc.NativeRequiredSize();
        byte* descPtr = stackalloc byte[descSize];
        D3D11BufferDesc.NativeWriteTo((nint)descPtr, desc);

        fixed (void* dataPtr = data)
        {
            D3D11SubResourceDataPtr resource = new()
            {
                SysMem = (nint)dataPtr,
                SysMemPitch = sysMemPitch,
                SysMemSlicePitch = sysMemSlicePitch
            };

            int resourceSize = D3D11SubResourceDataPtr.NativeRequiredSize();
            byte* resourcePtr = stackalloc byte[resourceSize];
            D3D11SubResourceDataPtr.NativeWriteTo((nint)resourcePtr, resource);

            nint ptr;
            int hr = _comImpl->CreateBuffer(_comPtr, descPtr, resourcePtr, &ptr);
            Marshal.ThrowExceptionForHR(hr);
            return new D3D11Buffer(ptr);
        }
    }

    /// <summary>
    /// Creates an array of 1D textures.
    /// </summary>
    /// <param name="desc">Describes a 1D texture resource.</param>
    /// <returns>The created texture.</returns>
    public D3D11Texture1D CreateTexture1D(in D3D11Texture1DDesc desc)
    {
        int size = D3D11Texture1DDesc.NativeRequiredSize();
        byte* descPtr = stackalloc byte[size];
        D3D11Texture1DDesc.NativeWriteTo((nint)descPtr, desc);
        nint ptr;
        int hr = _comImpl->CreateTexture1D(_comPtr, descPtr, null, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D3D11Texture1D(ptr);
    }

    /// <summary>
    /// Creates an array of 1D textures.
    /// </summary>
    /// <param name="desc">Describes a 1D texture resource.</param>
    /// <param name="data">Describe subresources for the 1D texture resource.</param>
    /// <returns>The created texture.</returns>
    public D3D11Texture1D CreateTexture1D(in D3D11Texture1DDesc desc, D3D11SubResourceData[]? data)
    {
        if (data is null)
        {
            throw new ArgumentNullException(nameof(data));
        }

        return CreateTexture1D(desc, data.AsSpan());
    }

    /// <summary>
    /// Creates an array of 1D textures.
    /// </summary>
    /// <param name="desc">Describes a 1D texture resource.</param>
    /// <param name="data">Describe subresources for the 1D texture resource.</param>
    /// <returns>The created texture.</returns>
    public D3D11Texture1D CreateTexture1D(in D3D11Texture1DDesc desc, ReadOnlySpan<D3D11SubResourceData> data)
    {
        if (data.Length == 0)
        {
            throw new ArgumentNullException(nameof(data));
        }

        int length = desc.MipLevels == 0 ? (int)desc.ArraySize : (int)(desc.MipLevels * desc.ArraySize);

        if (data.Length != length)
        {
            throw new ArgumentOutOfRangeException(nameof(data));
        }

        Span<D3D11SubResourceDataPtr> subResources = stackalloc D3D11SubResourceDataPtr[length];

        for (int i = 0; i < length; i++)
        {
            subResources[i].SysMem = Marshal.UnsafeAddrOfPinnedArrayElement(data[i].Data, data[i].Index);
            subResources[i].SysMemPitch = data[i].Pitch;
            subResources[i].SysMemSlicePitch = data[i].SlicePitch;
        }

        int subResourcesSize = D3D11SubResourceDataPtr.NativeRequiredSize(length);
        byte* subResourcesPtr = stackalloc byte[subResourcesSize];
        D3D11SubResourceDataPtr.NativeWriteTo((nint)subResourcesPtr, subResources);

        int size = D3D11Texture1DDesc.NativeRequiredSize();
        byte* descPtr = stackalloc byte[size];
        D3D11Texture1DDesc.NativeWriteTo((nint)descPtr, desc);
        nint ptr;
        int hr = _comImpl->CreateTexture1D(_comPtr, descPtr, subResourcesPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D3D11Texture1D(ptr);
    }

    /// <summary>
    /// Creates an array of 1D textures.
    /// </summary>
    /// <param name="desc">Describes a 1D texture resource.</param>
    /// <param name="data">Describe subresources for the 1D texture resource.</param>
    /// <returns>The created texture.</returns>
    public D3D11Texture1D CreateTexture1D(in D3D11Texture1DDesc desc, D3D11SubResourceDataPtr[]? data)
    {
        if (data is null)
        {
            throw new ArgumentNullException(nameof(data));
        }

        return CreateTexture1D(desc, data.AsSpan());
    }

    /// <summary>
    /// Creates an array of 1D textures.
    /// </summary>
    /// <param name="desc">Describes a 1D texture resource.</param>
    /// <param name="data">Describe subresources for the 1D texture resource.</param>
    /// <returns>The created texture.</returns>
    public D3D11Texture1D CreateTexture1D(in D3D11Texture1DDesc desc, ReadOnlySpan<D3D11SubResourceDataPtr> data)
    {
        if (data.Length == 0)
        {
            throw new ArgumentNullException(nameof(data));
        }

        int length = desc.MipLevels == 0 ? (int)desc.ArraySize : (int)(desc.MipLevels * desc.ArraySize);

        if (data.Length != length)
        {
            throw new ArgumentOutOfRangeException(nameof(data));
        }

        int subResourcesSize = D3D11SubResourceDataPtr.NativeRequiredSize(length);
        byte* subResourcesPtr = stackalloc byte[subResourcesSize];
        D3D11SubResourceDataPtr.NativeWriteTo((nint)subResourcesPtr, data);

        int size = D3D11Texture1DDesc.NativeRequiredSize();
        byte* descPtr = stackalloc byte[size];
        D3D11Texture1DDesc.NativeWriteTo((nint)descPtr, desc);
        nint ptr;
        int hr = _comImpl->CreateTexture1D(_comPtr, descPtr, subResourcesPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D3D11Texture1D(ptr);
    }

    /// <summary>
    /// Create an array of 2D textures.
    /// </summary>
    /// <param name="desc">Describes a 2D texture resource.</param>
    /// <returns>The created texture.</returns>
    public D3D11Texture2D CreateTexture2D(in D3D11Texture2DDesc desc)
    {
        int size = D3D11Texture2DDesc.NativeRequiredSize();
        byte* descPtr = stackalloc byte[size];
        D3D11Texture2DDesc.NativeWriteTo((nint)descPtr, desc);
        nint ptr;
        int hr = _comImpl->CreateTexture2D(_comPtr, descPtr, null, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D3D11Texture2D(ptr);
    }

    /// <summary>
    /// Create an array of 2D textures.
    /// </summary>
    /// <param name="desc">Describes a 2D texture resource.</param>
    /// <param name="data">Describe subresources for the 2D texture resource.</param>
    /// <returns>The created texture.</returns>
    public D3D11Texture2D CreateTexture2D(in D3D11Texture2DDesc desc, D3D11SubResourceData[]? data)
    {
        if (data is null)
        {
            throw new ArgumentNullException(nameof(data));
        }

        return CreateTexture2D(desc, data.AsSpan());
    }

    /// <summary>
    /// Create an array of 2D textures.
    /// </summary>
    /// <param name="desc">Describes a 2D texture resource.</param>
    /// <param name="data">Describe subresources for the 2D texture resource.</param>
    /// <returns>The created texture.</returns>
    public D3D11Texture2D CreateTexture2D(in D3D11Texture2DDesc desc, ReadOnlySpan<D3D11SubResourceData> data)
    {
        if (data.Length == 0)
        {
            throw new ArgumentNullException(nameof(data));
        }

        int length = desc.MipLevels == 0 ? (int)desc.ArraySize : (int)(desc.MipLevels * desc.ArraySize);

        if (data.Length != length)
        {
            throw new ArgumentOutOfRangeException(nameof(data));
        }

        Span<D3D11SubResourceDataPtr> subResources = stackalloc D3D11SubResourceDataPtr[length];

        for (int i = 0; i < length; i++)
        {
            subResources[i].SysMem = Marshal.UnsafeAddrOfPinnedArrayElement(data[i].Data, data[i].Index);
            subResources[i].SysMemPitch = data[i].Pitch;
            subResources[i].SysMemSlicePitch = data[i].SlicePitch;
        }

        int subResourcesSize = D3D11SubResourceDataPtr.NativeRequiredSize(length);
        byte* subResourcesPtr = stackalloc byte[subResourcesSize];
        D3D11SubResourceDataPtr.NativeWriteTo((nint)subResourcesPtr, subResources);

        int size = D3D11Texture2DDesc.NativeRequiredSize();
        byte* descPtr = stackalloc byte[size];
        D3D11Texture2DDesc.NativeWriteTo((nint)descPtr, desc);
        nint ptr;
        int hr = _comImpl->CreateTexture2D(_comPtr, descPtr, subResourcesPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D3D11Texture2D(ptr);
    }

    /// <summary>
    /// Create an array of 2D textures.
    /// </summary>
    /// <param name="desc">Describes a 2D texture resource.</param>
    /// <param name="data">Describe subresources for the 2D texture resource.</param>
    /// <returns>The created texture.</returns>
    public D3D11Texture2D CreateTexture2D(in D3D11Texture2DDesc desc, D3D11SubResourceDataPtr[]? data)
    {
        if (data is null)
        {
            throw new ArgumentNullException(nameof(data));
        }

        return CreateTexture2D(desc, data.AsSpan());
    }

    /// <summary>
    /// Create an array of 2D textures.
    /// </summary>
    /// <param name="desc">Describes a 2D texture resource.</param>
    /// <param name="data">Describe subresources for the 2D texture resource.</param>
    /// <returns>The created texture.</returns>
    public D3D11Texture2D CreateTexture2D(in D3D11Texture2DDesc desc, ReadOnlySpan<D3D11SubResourceDataPtr> data)
    {
        if (data.Length == 0)
        {
            throw new ArgumentNullException(nameof(data));
        }

        int length = desc.MipLevels == 0 ? (int)desc.ArraySize : (int)(desc.MipLevels * desc.ArraySize);

        if (data.Length != length)
        {
            throw new ArgumentOutOfRangeException(nameof(data));
        }

        int subResourcesSize = D3D11SubResourceDataPtr.NativeRequiredSize(length);
        byte* subResourcesPtr = stackalloc byte[subResourcesSize];
        D3D11SubResourceDataPtr.NativeWriteTo((nint)subResourcesPtr, data);

        int size = D3D11Texture2DDesc.NativeRequiredSize();
        byte* descPtr = stackalloc byte[size];
        D3D11Texture2DDesc.NativeWriteTo((nint)descPtr, desc);
        nint ptr;
        int hr = _comImpl->CreateTexture2D(_comPtr, descPtr, subResourcesPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D3D11Texture2D(ptr);
    }

    /// <summary>
    /// Create a single 3D texture.
    /// </summary>
    /// <param name="desc">Describes a 3D texture resource.</param>
    /// <returns>The created texture.</returns>
    public D3D11Texture3D CreateTexture3D(in D3D11Texture3DDesc desc)
    {
        int size = D3D11Texture3DDesc.NativeRequiredSize();
        byte* descPtr = stackalloc byte[size];
        D3D11Texture3DDesc.NativeWriteTo((nint)descPtr, desc);
        nint ptr;
        int hr = _comImpl->CreateTexture3D(_comPtr, descPtr, null, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D3D11Texture3D(ptr);
    }

    /// <summary>
    /// Create a single 3D texture.
    /// </summary>
    /// <param name="desc">Describes a 3D texture resource.</param>
    /// <param name="data">Describe subresources for the 3D texture resource.</param>
    /// <returns>The created texture.</returns>
    public D3D11Texture3D CreateTexture3D(in D3D11Texture3DDesc desc, D3D11SubResourceData[]? data)
    {
        if (data is null)
        {
            throw new ArgumentNullException(nameof(data));
        }

        return CreateTexture3D(desc, data.AsSpan());
    }

    /// <summary>
    /// Create a single 3D texture.
    /// </summary>
    /// <param name="desc">Describes a 3D texture resource.</param>
    /// <param name="data">Describe subresources for the 3D texture resource.</param>
    /// <returns>The created texture.</returns>
    public D3D11Texture3D CreateTexture3D(in D3D11Texture3DDesc desc, ReadOnlySpan<D3D11SubResourceData> data)
    {
        if (data.Length == 0)
        {
            throw new ArgumentNullException(nameof(data));
        }

        int length = desc.MipLevels == 0 ? 1 : (int)desc.MipLevels;

        if (data.Length != length)
        {
            throw new ArgumentOutOfRangeException(nameof(data));
        }

        Span<D3D11SubResourceDataPtr> subResources = stackalloc D3D11SubResourceDataPtr[length];

        for (int i = 0; i < length; i++)
        {
            subResources[i].SysMem = Marshal.UnsafeAddrOfPinnedArrayElement(data[i].Data, data[i].Index);
            subResources[i].SysMemPitch = data[i].Pitch;
            subResources[i].SysMemSlicePitch = data[i].SlicePitch;
        }

        int subResourcesSize = D3D11SubResourceDataPtr.NativeRequiredSize(length);
        byte* subResourcesPtr = stackalloc byte[subResourcesSize];
        D3D11SubResourceDataPtr.NativeWriteTo((nint)subResourcesPtr, subResources);

        int size = D3D11Texture3DDesc.NativeRequiredSize();
        byte* descPtr = stackalloc byte[size];
        D3D11Texture3DDesc.NativeWriteTo((nint)descPtr, desc);
        nint ptr;
        int hr = _comImpl->CreateTexture3D(_comPtr, descPtr, subResourcesPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D3D11Texture3D(ptr);
    }

    /// <summary>
    /// Create a single 3D texture.
    /// </summary>
    /// <param name="desc">Describes a 3D texture resource.</param>
    /// <param name="data">Describe subresources for the 3D texture resource.</param>
    /// <returns>The created texture.</returns>
    public D3D11Texture3D CreateTexture3D(in D3D11Texture3DDesc desc, D3D11SubResourceDataPtr[]? data)
    {
        if (data is null)
        {
            throw new ArgumentNullException(nameof(data));
        }

        return CreateTexture3D(desc, data.AsSpan());
    }

    /// <summary>
    /// Create a single 3D texture.
    /// </summary>
    /// <param name="desc">Describes a 3D texture resource.</param>
    /// <param name="data">Describe subresources for the 3D texture resource.</param>
    /// <returns>The created texture.</returns>
    public D3D11Texture3D CreateTexture3D(in D3D11Texture3DDesc desc, ReadOnlySpan<D3D11SubResourceDataPtr> data)
    {
        if (data.Length == 0)
        {
            throw new ArgumentNullException(nameof(data));
        }

        int length = desc.MipLevels == 0 ? 1 : (int)desc.MipLevels;

        if (data.Length != length)
        {
            throw new ArgumentOutOfRangeException(nameof(data));
        }

        int subResourcesSize = D3D11SubResourceDataPtr.NativeRequiredSize(length);
        byte* subResourcesPtr = stackalloc byte[subResourcesSize];
        D3D11SubResourceDataPtr.NativeWriteTo((nint)subResourcesPtr, data);

        int size = D3D11Texture3DDesc.NativeRequiredSize();
        byte* descPtr = stackalloc byte[size];
        D3D11Texture3DDesc.NativeWriteTo((nint)descPtr, desc);
        nint ptr;
        int hr = _comImpl->CreateTexture3D(_comPtr, descPtr, subResourcesPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D3D11Texture3D(ptr);
    }

    /// <summary>
    /// Create a shader resource view for accessing data in a resource.
    /// </summary>
    /// <param name="resource">The resource that will serve as input to a shader.</param>
    /// <returns>The created shader resource view.</returns>
    public D3D11ShaderResourceView CreateShaderResourceView(D3D11Resource? resource)
    {
        return CreateShaderResourceView(resource, null);
    }

    /// <summary>
    /// Create a shader resource view for accessing data in a resource.
    /// </summary>
    /// <param name="resource">The resource that will serve as input to a shader.</param>
    /// <param name="desc">A shader resource view description.</param>
    /// <returns>The created shader resource view.</returns>
    public D3D11ShaderResourceView CreateShaderResourceView(D3D11Resource? resource, in D3D11ShaderResourceViewDesc? desc)
    {
        if (resource is null)
        {
            throw new ArgumentNullException(nameof(resource));
        }

        nint ptr;
        int hr;

        if (desc is null)
        {
            hr = _comImpl->CreateShaderResourceView(_comPtr, resource.Handle, null, &ptr);
        }
        else
        {
            int size = D3D11ShaderResourceViewDesc.NativeRequiredSize();
            byte* descPtr = stackalloc byte[size];
            D3D11ShaderResourceViewDesc.NativeWriteTo((nint)descPtr, desc.Value);
            hr = _comImpl->CreateShaderResourceView(_comPtr, resource.Handle, descPtr, &ptr);
        }

        Marshal.ThrowExceptionForHR(hr);
        return new D3D11ShaderResourceView(ptr);
    }

    /// <summary>
    /// Creates a view for accessing an unordered access resource.
    /// </summary>
    /// <param name="resource">A resources that will serve as an input to a shader.</param>
    /// <returns>The created unordered-access view.</returns>
    public D3D11UnorderedAccessView CreateUnorderedAccessView(D3D11Resource? resource)
    {
        return CreateUnorderedAccessView(resource, null);
    }

    /// <summary>
    /// Creates a view for accessing an unordered access resource.
    /// </summary>
    /// <param name="resource">A resources that will serve as an input to a shader.</param>
    /// <param name="desc">A shader resource view description.</param>
    /// <returns>The created unordered-access view.</returns>
    public D3D11UnorderedAccessView CreateUnorderedAccessView(D3D11Resource? resource, in D3D11UnorderedAccessViewDesc? desc)
    {
        if (resource is null)
        {
            throw new ArgumentNullException(nameof(resource));
        }

        nint ptr;
        int hr;

        if (desc is null)
        {
            hr = _comImpl->CreateUnorderedAccessView(_comPtr, resource.Handle, null, &ptr);
        }
        else
        {
            int size = D3D11UnorderedAccessViewDesc.NativeRequiredSize();
            byte* descPtr = stackalloc byte[size];
            D3D11UnorderedAccessViewDesc.NativeWriteTo((nint)descPtr, desc.Value);
            hr = _comImpl->CreateUnorderedAccessView(_comPtr, resource.Handle, descPtr, &ptr);
        }

        Marshal.ThrowExceptionForHR(hr);
        return new D3D11UnorderedAccessView(ptr);
    }

    /// <summary>
    /// Creates a render-target view for accessing resource data.
    /// </summary>
    /// <param name="resource">A render target resource.</param>
    /// <returns>The created render target view.</returns>
    public D3D11RenderTargetView CreateRenderTargetView(D3D11Resource? resource)
    {
        return CreateRenderTargetView(resource, null);
    }

    /// <summary>
    /// Creates a render-target view for accessing resource data.
    /// </summary>
    /// <param name="resource">A render target resource.</param>
    /// <param name="desc">A render-target view description.</param>
    /// <returns>The created render target view.</returns>
    public D3D11RenderTargetView CreateRenderTargetView(D3D11Resource? resource, in D3D11RenderTargetViewDesc? desc)
    {
        if (resource is null)
        {
            throw new ArgumentNullException(nameof(resource));
        }

        nint ptr;
        int hr;

        if (desc is null)
        {
            hr = _comImpl->CreateRenderTargetView(_comPtr, resource.Handle, null, &ptr);
        }
        else
        {
            int size = D3D11RenderTargetViewDesc.NativeRequiredSize();
            byte* descPtr = stackalloc byte[size];
            D3D11RenderTargetViewDesc.NativeWriteTo((nint)descPtr, desc.Value);
            hr = _comImpl->CreateRenderTargetView(_comPtr, resource.Handle, descPtr, &ptr);
        }

        Marshal.ThrowExceptionForHR(hr);
        return new D3D11RenderTargetView(ptr);
    }

    /// <summary>
    /// Create a depth-stencil view for accessing resource data.
    /// </summary>
    /// <param name="resource">The resource that will serve as the depth-stencil surface.</param>
    /// <returns>The created depth-stencil view.</returns>
    public D3D11DepthStencilView CreateDepthStencilView(D3D11Resource? resource)
    {
        return CreateDepthStencilView(resource, null);
    }

    /// <summary>
    /// Create a depth-stencil view for accessing resource data.
    /// </summary>
    /// <param name="resource">The resource that will serve as the depth-stencil surface.</param>
    /// <param name="desc">A depth-stencil-view description.</param>
    /// <returns>The created depth-stencil view.</returns>
    public D3D11DepthStencilView CreateDepthStencilView(D3D11Resource? resource, in D3D11DepthStencilViewDesc? desc)
    {
        if (resource is null)
        {
            throw new ArgumentNullException(nameof(resource));
        }

        nint ptr;
        int hr;

        if (desc is null)
        {
            hr = _comImpl->CreateDepthStencilView(_comPtr, resource.Handle, null, &ptr);
        }
        else
        {
            int size = D3D11DepthStencilViewDesc.NativeRequiredSize();
            byte* descPtr = stackalloc byte[size];
            D3D11DepthStencilViewDesc.NativeWriteTo((nint)descPtr, desc.Value);
            hr = _comImpl->CreateDepthStencilView(_comPtr, resource.Handle, descPtr, &ptr);
        }

        Marshal.ThrowExceptionForHR(hr);
        return new D3D11DepthStencilView(ptr);
    }

    /// <summary>
    /// Create an input-layout object to describe the input-buffer data for the input-assembler stage.
    /// </summary>
    /// <param name="elementDescs">An array of the input-assembler stage input data types; each type is described by an element description.</param>
    /// <param name="shaderBytecodeWithInputSignature">The compiled shader. The compiled shader code contains a input signature which is validated against the array of elements.</param>
    /// <returns>The created input-layout object.</returns>
    public D3D11InputLayout CreateInputLayout(D3D11InputElementDesc[]? elementDescs, byte[]? shaderBytecodeWithInputSignature)
    {
        if (elementDescs is null)
        {
            throw new ArgumentNullException(nameof(elementDescs));
        }

        if (shaderBytecodeWithInputSignature is null)
        {
            throw new ArgumentNullException(nameof(shaderBytecodeWithInputSignature));
        }

        return CreateInputLayout(elementDescs.AsSpan(), shaderBytecodeWithInputSignature.AsSpan());
    }

    /// <summary>
    /// Create an input-layout object to describe the input-buffer data for the input-assembler stage.
    /// </summary>
    /// <param name="elementDescs">An array of the input-assembler stage input data types; each type is described by an element description.</param>
    /// <param name="shaderBytecodeWithInputSignature">The compiled shader. The compiled shader code contains a input signature which is validated against the array of elements.</param>
    /// <returns>The created input-layout object.</returns>
    public D3D11InputLayout CreateInputLayout(ReadOnlySpan<D3D11InputElementDesc> elementDescs, ReadOnlySpan<byte> shaderBytecodeWithInputSignature)
    {
        if (elementDescs.Length == 0)
        {
            throw new ArgumentNullException(nameof(elementDescs));
        }

        if (shaderBytecodeWithInputSignature.Length == 0)
        {
            throw new ArgumentNullException(nameof(shaderBytecodeWithInputSignature));
        }

        int elementDescsSize = D3D11InputElementDesc.NativeRequiredSize(elementDescs.Length);
        byte* elementDescsPtr = stackalloc byte[elementDescsSize];
        D3D11InputElementDesc.NativeWriteTo((nint)elementDescsPtr, elementDescs);

        fixed (byte* shaderBytecodeWithInputSignaturePtr = shaderBytecodeWithInputSignature)
        {
            nint ptr;
            int hr = _comImpl->CreateInputLayout(
                _comPtr,
                elementDescsPtr,
                (uint)elementDescs.Length,
                shaderBytecodeWithInputSignaturePtr,
                (nuint)shaderBytecodeWithInputSignature.Length,
                &ptr);
            Marshal.ThrowExceptionForHR(hr);
            return new D3D11InputLayout(ptr);
        }
    }

    /// <summary>
    /// Create a vertex shader object from a compiled shader.
    /// </summary>
    /// <param name="shaderBytecode">The compiled shader.</param>
    /// <returns>The created vertex shader.</returns>
    public D3D11VertexShader CreateVertexShader(byte[]? shaderBytecode)
    {
        return CreateVertexShader(shaderBytecode, null);
    }

    /// <summary>
    /// Create a vertex shader object from a compiled shader.
    /// </summary>
    /// <param name="shaderBytecode">The compiled shader.</param>
    /// <param name="classLinkage">A class linkage interface.</param>
    /// <returns>The created vertex shader.</returns>
    public D3D11VertexShader CreateVertexShader(byte[]? shaderBytecode, D3D11ClassLinkage? classLinkage)
    {
        if (shaderBytecode is null)
        {
            throw new ArgumentNullException(nameof(shaderBytecode));
        }

        return CreateVertexShader(shaderBytecode.AsSpan(), classLinkage);
    }

    /// <summary>
    /// Create a vertex shader object from a compiled shader.
    /// </summary>
    /// <param name="shaderBytecode">The compiled shader.</param>
    /// <returns>The created vertex shader.</returns>
    public D3D11VertexShader CreateVertexShader(ReadOnlySpan<byte> shaderBytecode)
    {
        return CreateVertexShader(shaderBytecode, null);
    }

    /// <summary>
    /// Create a vertex shader object from a compiled shader.
    /// </summary>
    /// <param name="shaderBytecode">The compiled shader.</param>
    /// <param name="classLinkage">A class linkage interface.</param>
    /// <returns>The created vertex shader.</returns>
    public D3D11VertexShader CreateVertexShader(ReadOnlySpan<byte> shaderBytecode, D3D11ClassLinkage? classLinkage)
    {
        if (shaderBytecode.Length == 0)
        {
            throw new ArgumentNullException(nameof(shaderBytecode));
        }

        fixed (byte* data = shaderBytecode)
        {
            nint ptr;
            int hr = _comImpl->CreateVertexShader(
                _comPtr,
                data,
                (nuint)shaderBytecode.Length,
                classLinkage is null ? 0 : classLinkage.Handle,
                &ptr);
            Marshal.ThrowExceptionForHR(hr);
            return new D3D11VertexShader(ptr);
        }
    }

    /// <summary>
    /// Create a geometry shader.
    /// </summary>
    /// <param name="shaderBytecode">The compiled shader.</param>
    /// <returns>The created geometry shader.</returns>
    public D3D11GeometryShader CreateGeometryShader(byte[]? shaderBytecode)
    {
        return CreateGeometryShader(shaderBytecode, null);
    }

    /// <summary>
    /// Create a geometry shader.
    /// </summary>
    /// <param name="shaderBytecode">The compiled shader.</param>
    /// <param name="classLinkage">A class linkage interface.</param>
    /// <returns>The created geometry shader.</returns>
    public D3D11GeometryShader CreateGeometryShader(byte[]? shaderBytecode, D3D11ClassLinkage? classLinkage)
    {
        if (shaderBytecode is null)
        {
            throw new ArgumentNullException(nameof(shaderBytecode));
        }

        return CreateGeometryShader(shaderBytecode.AsSpan(), classLinkage);
    }

    /// <summary>
    /// Create a geometry shader.
    /// </summary>
    /// <param name="shaderBytecode">The compiled shader.</param>
    /// <returns>The created geometry shader.</returns>
    public D3D11GeometryShader CreateGeometryShader(ReadOnlySpan<byte> shaderBytecode)
    {
        return CreateGeometryShader(shaderBytecode, null);
    }

    /// <summary>
    /// Create a geometry shader.
    /// </summary>
    /// <param name="shaderBytecode">The compiled shader.</param>
    /// <param name="classLinkage">A class linkage interface.</param>
    /// <returns>The created geometry shader.</returns>
    public D3D11GeometryShader CreateGeometryShader(ReadOnlySpan<byte> shaderBytecode, D3D11ClassLinkage? classLinkage)
    {
        if (shaderBytecode.Length == 0)
        {
            throw new ArgumentNullException(nameof(shaderBytecode));
        }

        fixed (byte* data = shaderBytecode)
        {
            nint ptr;
            int hr = _comImpl->CreateGeometryShader(
                _comPtr,
                data,
                (nuint)shaderBytecode.Length,
                classLinkage is null ? 0 : classLinkage.Handle,
                &ptr);
            Marshal.ThrowExceptionForHR(hr);
            return new D3D11GeometryShader(ptr);
        }
    }

    /// <summary>
    /// Creates a geometry shader that can write to streaming output buffers.
    /// </summary>
    /// <param name="shaderBytecode">The compiled geometry shader for a standard geometry shader plus stream output.</param>
    /// <param name="streamOutputDeclaration">A <see cref="D3D11StreamOutputDeclarationEntry"/> array.</param>
    /// <param name="rasterizedStream">The index number of the stream to be sent to the rasterizer stage.</param>
    /// <param name="classLinkage">A class linkage interface.</param>
    /// <returns>The created geometry shader.</returns>
    public D3D11GeometryShader CreateGeometryShaderWithStreamOutput(
        byte[]? shaderBytecode,
        D3D11StreamOutputDeclarationEntry[]? streamOutputDeclaration,
        uint rasterizedStream)
    {
        return CreateGeometryShaderWithStreamOutput(shaderBytecode, streamOutputDeclaration, null, rasterizedStream, null);
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
    public D3D11GeometryShader CreateGeometryShaderWithStreamOutput(
        byte[]? shaderBytecode,
        D3D11StreamOutputDeclarationEntry[]? streamOutputDeclaration,
        uint[]? bufferStrides,
        uint rasterizedStream)
    {
        return CreateGeometryShaderWithStreamOutput(shaderBytecode, streamOutputDeclaration, bufferStrides, rasterizedStream, null);
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
    public D3D11GeometryShader CreateGeometryShaderWithStreamOutput(
        byte[]? shaderBytecode,
        D3D11StreamOutputDeclarationEntry[]? streamOutputDeclaration,
        uint[]? bufferStrides,
        uint rasterizedStream,
        D3D11ClassLinkage? classLinkage)
    {
        if (shaderBytecode is null)
        {
            throw new ArgumentNullException(nameof(shaderBytecode));
        }

        if (streamOutputDeclaration is null)
        {
            throw new ArgumentNullException(nameof(streamOutputDeclaration));
        }

        return CreateGeometryShaderWithStreamOutput(
            shaderBytecode.AsSpan(),
            streamOutputDeclaration.AsSpan(),
            bufferStrides.AsSpan(),
            rasterizedStream,
            classLinkage);
    }

    /// <summary>
    /// Creates a geometry shader that can write to streaming output buffers.
    /// </summary>
    /// <param name="shaderBytecode">The compiled geometry shader for a standard geometry shader plus stream output.</param>
    /// <param name="streamOutputDeclaration">A <see cref="D3D11StreamOutputDeclarationEntry"/> array.</param>
    /// <param name="rasterizedStream">The index number of the stream to be sent to the rasterizer stage.</param>
    /// <returns>The created geometry shader.</returns>
    public D3D11GeometryShader CreateGeometryShaderWithStreamOutput(
        ReadOnlySpan<byte> shaderBytecode,
        ReadOnlySpan<D3D11StreamOutputDeclarationEntry> streamOutputDeclaration,
        uint rasterizedStream)
    {
        return CreateGeometryShaderWithStreamOutput(
            shaderBytecode,
            streamOutputDeclaration,
            new ReadOnlySpan<uint>(null, 0),
            rasterizedStream,
            null);
    }

    /// <summary>
    /// Creates a geometry shader that can write to streaming output buffers.
    /// </summary>
    /// <param name="shaderBytecode">The compiled geometry shader for a standard geometry shader plus stream output.</param>
    /// <param name="streamOutputDeclaration">A <see cref="D3D11StreamOutputDeclarationEntry"/> array.</param>
    /// <param name="bufferStrides">An array of buffer strides; each stride is the size of an element for that buffer.</param>
    /// <param name="rasterizedStream">The index number of the stream to be sent to the rasterizer stage.</param>
    /// <returns>The created geometry shader.</returns>
    public D3D11GeometryShader CreateGeometryShaderWithStreamOutput(
        ReadOnlySpan<byte> shaderBytecode,
        ReadOnlySpan<D3D11StreamOutputDeclarationEntry> streamOutputDeclaration,
        ReadOnlySpan<uint> bufferStrides,
        uint rasterizedStream)
    {
        return CreateGeometryShaderWithStreamOutput(shaderBytecode, streamOutputDeclaration, bufferStrides, rasterizedStream, null);
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
    public D3D11GeometryShader CreateGeometryShaderWithStreamOutput(
        ReadOnlySpan<byte> shaderBytecode,
        ReadOnlySpan<D3D11StreamOutputDeclarationEntry> streamOutputDeclaration,
        ReadOnlySpan<uint> bufferStrides,
        uint rasterizedStream,
        D3D11ClassLinkage? classLinkage)
    {
        if (shaderBytecode.Length == 0)
        {
            throw new ArgumentNullException(nameof(shaderBytecode));
        }

        if (streamOutputDeclaration.Length == 0)
        {
            throw new ArgumentNullException(nameof(streamOutputDeclaration));
        }

        fixed (byte* shaderBytecodePtr = shaderBytecode)
        fixed (uint* bufferStridesPtr = bufferStrides)
        {
            int streamOutputDeclarationSize = D3D11StreamOutputDeclarationEntry.NativeRequiredSize(streamOutputDeclaration.Length);
            byte* streamOutputDeclarationPtr = stackalloc byte[streamOutputDeclarationSize];
            D3D11StreamOutputDeclarationEntry.NativeWriteTo((nint)streamOutputDeclarationPtr, streamOutputDeclaration);
            nint ptr;
            int hr = _comImpl->CreateGeometryShaderWithStreamOutput(
                _comPtr,
                streamOutputDeclarationPtr,
                (nuint)shaderBytecode.Length,
                streamOutputDeclarationPtr,
                (uint)streamOutputDeclaration.Length,
                bufferStrides.Length == 0 ? null : bufferStridesPtr,
                (uint)bufferStrides.Length,
                rasterizedStream,
                classLinkage is null ? 0 : classLinkage.Handle,
                &ptr);
            Marshal.ThrowExceptionForHR(hr);
            return new D3D11GeometryShader(ptr);
        }
    }

    /// <summary>
    /// Create a pixel shader.
    /// </summary>
    /// <param name="shaderBytecode">The compiled shader.</param>
    /// <returns>The created pixel shader.</returns>
    public D3D11PixelShader CreatePixelShader(byte[]? shaderBytecode)
    {
        return CreatePixelShader(shaderBytecode, null);
    }

    /// <summary>
    /// Create a pixel shader.
    /// </summary>
    /// <param name="shaderBytecode">The compiled shader.</param>
    /// <param name="classLinkage">A class linkage interface.</param>
    /// <returns>The created pixel shader.</returns>
    public D3D11PixelShader CreatePixelShader(byte[]? shaderBytecode, D3D11ClassLinkage? classLinkage)
    {
        if (shaderBytecode is null)
        {
            throw new ArgumentNullException(nameof(shaderBytecode));
        }

        return CreatePixelShader(shaderBytecode.AsSpan(), classLinkage);
    }

    /// <summary>
    /// Create a pixel shader.
    /// </summary>
    /// <param name="shaderBytecode">The compiled shader.</param>
    /// <returns>The created pixel shader.</returns>
    public D3D11PixelShader CreatePixelShader(ReadOnlySpan<byte> shaderBytecode)
    {
        return CreatePixelShader(shaderBytecode, null);
    }

    /// <summary>
    /// Create a pixel shader.
    /// </summary>
    /// <param name="shaderBytecode">The compiled shader.</param>
    /// <param name="classLinkage">A class linkage interface.</param>
    /// <returns>The created pixel shader.</returns>
    public D3D11PixelShader CreatePixelShader(ReadOnlySpan<byte> shaderBytecode, D3D11ClassLinkage? classLinkage)
    {
        if (shaderBytecode.Length == 0)
        {
            throw new ArgumentNullException(nameof(shaderBytecode));
        }

        fixed (byte* data = shaderBytecode)
        {
            nint ptr;
            int hr = _comImpl->CreatePixelShader(
                _comPtr,
                data,
                (nuint)shaderBytecode.Length,
                classLinkage is null ? 0 : classLinkage.Handle,
                &ptr);
            Marshal.ThrowExceptionForHR(hr);
            return new D3D11PixelShader(ptr);
        }
    }

    /// <summary>
    /// Create a hull shader.
    /// </summary>
    /// <param name="shaderBytecode">The compiled shader.</param>
    /// <returns>The created hull shader.</returns>
    public D3D11HullShader CreateHullShader(byte[]? shaderBytecode)
    {
        return CreateHullShader(shaderBytecode, null);
    }

    /// <summary>
    /// Create a hull shader.
    /// </summary>
    /// <param name="shaderBytecode">The compiled shader.</param>
    /// <param name="classLinkage">A class linkage interface.</param>
    /// <returns>The created hull shader.</returns>
    public D3D11HullShader CreateHullShader(byte[]? shaderBytecode, D3D11ClassLinkage? classLinkage)
    {
        if (shaderBytecode is null)
        {
            throw new ArgumentNullException(nameof(shaderBytecode));
        }

        return CreateHullShader(shaderBytecode.AsSpan(), classLinkage);
    }

    /// <summary>
    /// Create a hull shader.
    /// </summary>
    /// <param name="shaderBytecode">The compiled shader.</param>
    /// <returns>The created hull shader.</returns>
    public D3D11HullShader CreateHullShader(ReadOnlySpan<byte> shaderBytecode)
    {
        return CreateHullShader(shaderBytecode, null);
    }

    /// <summary>
    /// Create a hull shader.
    /// </summary>
    /// <param name="shaderBytecode">The compiled shader.</param>
    /// <param name="classLinkage">A class linkage interface.</param>
    /// <returns>The created hull shader.</returns>
    public D3D11HullShader CreateHullShader(ReadOnlySpan<byte> shaderBytecode, D3D11ClassLinkage? classLinkage)
    {
        if (shaderBytecode.Length == 0)
        {
            throw new ArgumentNullException(nameof(shaderBytecode));
        }

        fixed (byte* data = shaderBytecode)
        {
            nint ptr;
            int hr = _comImpl->CreateHullShader(
                _comPtr,
                data,
                (nuint)shaderBytecode.Length,
                classLinkage is null ? 0 : classLinkage.Handle,
                &ptr);
            Marshal.ThrowExceptionForHR(hr);
            return new D3D11HullShader(ptr);
        }
    }

    /// <summary>
    /// Create a domain shader.
    /// </summary>
    /// <param name="shaderBytecode">The compiled shader.</param>
    /// <returns>The created domain shader.</returns>
    public D3D11DomainShader CreateDomainShader(byte[]? shaderBytecode)
    {
        return CreateDomainShader(shaderBytecode, null);
    }

    /// <summary>
    /// Create a domain shader.
    /// </summary>
    /// <param name="shaderBytecode">The compiled shader.</param>
    /// <param name="classLinkage">A class linkage interface.</param>
    /// <returns>The created domain shader.</returns>
    public D3D11DomainShader CreateDomainShader(byte[]? shaderBytecode, D3D11ClassLinkage? classLinkage)
    {
        if (shaderBytecode is null)
        {
            throw new ArgumentNullException(nameof(shaderBytecode));
        }

        return CreateDomainShader(shaderBytecode.AsSpan(), classLinkage);
    }

    /// <summary>
    /// Create a domain shader.
    /// </summary>
    /// <param name="shaderBytecode">The compiled shader.</param>
    /// <returns>The created domain shader.</returns>
    public D3D11DomainShader CreateDomainShader(ReadOnlySpan<byte> shaderBytecode)
    {
        return CreateDomainShader(shaderBytecode, null);
    }

    /// <summary>
    /// Create a domain shader.
    /// </summary>
    /// <param name="shaderBytecode">The compiled shader.</param>
    /// <param name="classLinkage">A class linkage interface.</param>
    /// <returns>The created domain shader.</returns>
    public D3D11DomainShader CreateDomainShader(ReadOnlySpan<byte> shaderBytecode, D3D11ClassLinkage? classLinkage)
    {
        if (shaderBytecode.Length == 0)
        {
            throw new ArgumentNullException(nameof(shaderBytecode));
        }

        fixed (byte* data = shaderBytecode)
        {
            nint ptr;
            int hr = _comImpl->CreateDomainShader(
                _comPtr,
                data,
                (nuint)shaderBytecode.Length,
                classLinkage is null ? 0 : classLinkage.Handle,
                &ptr);
            Marshal.ThrowExceptionForHR(hr);
            return new D3D11DomainShader(ptr);
        }
    }

    /// <summary>
    /// Create a compute shader.
    /// </summary>
    /// <param name="shaderBytecode">The compiled shader.</param>
    /// <returns>The created compute shader.</returns>
    public D3D11ComputeShader CreateComputeShader(byte[]? shaderBytecode)
    {
        return CreateComputeShader(shaderBytecode, null);
    }

    /// <summary>
    /// Create a compute shader.
    /// </summary>
    /// <param name="shaderBytecode">The compiled shader.</param>
    /// <param name="classLinkage">A class linkage interface.</param>
    /// <returns>The created compute shader.</returns>
    public D3D11ComputeShader CreateComputeShader(byte[]? shaderBytecode, D3D11ClassLinkage? classLinkage)
    {
        if (shaderBytecode is null)
        {
            throw new ArgumentNullException(nameof(shaderBytecode));
        }

        return CreateComputeShader(shaderBytecode.AsSpan(), classLinkage);
    }

    /// <summary>
    /// Create a compute shader.
    /// </summary>
    /// <param name="shaderBytecode">The compiled shader.</param>
    /// <returns>The created compute shader.</returns>
    public D3D11ComputeShader CreateComputeShader(ReadOnlySpan<byte> shaderBytecode)
    {
        return CreateComputeShader(shaderBytecode, null);
    }

    /// <summary>
    /// Create a compute shader.
    /// </summary>
    /// <param name="shaderBytecode">The compiled shader.</param>
    /// <param name="classLinkage">A class linkage interface.</param>
    /// <returns>The created compute shader.</returns>
    public D3D11ComputeShader CreateComputeShader(ReadOnlySpan<byte> shaderBytecode, D3D11ClassLinkage? classLinkage)
    {
        if (shaderBytecode.Length == 0)
        {
            throw new ArgumentNullException(nameof(shaderBytecode));
        }

        fixed (byte* data = shaderBytecode)
        {
            nint ptr;
            int hr = _comImpl->CreateComputeShader(
                _comPtr,
                data,
                (nuint)shaderBytecode.Length,
                classLinkage is null ? 0 : classLinkage.Handle,
                &ptr);
            Marshal.ThrowExceptionForHR(hr);
            return new D3D11ComputeShader(ptr);
        }
    }

    /// <summary>
    /// Creates class linkage libraries to enable dynamic shader linkage.
    /// </summary>
    /// <returns>The created class linkage.</returns>
    public D3D11ClassLinkage CreateClassLinkage()
    {
        nint ptr;
        int hr = _comImpl->CreateClassLinkage(_comPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D3D11ClassLinkage(ptr);
    }

    /// <summary>
    /// Create a blend-state object that encapsules blend state for the output-merger stage.
    /// </summary>
    /// <param name="desc">A blend-state description.</param>
    /// <returns>The created blend-state object.</returns>
    public D3D11BlendState CreateBlendState(in D3D11BlendDesc desc)
    {
        int size = D3D11BlendDesc.NativeRequiredSize();
        byte* descPtr = stackalloc byte[size];
        D3D11BlendDesc.NativeWriteTo((nint)descPtr, desc);
        nint ptr;
        int hr = _comImpl->CreateBlendState(_comPtr, descPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D3D11BlendState(ptr);
    }

    /// <summary>
    /// Create a depth-stencil state object that encapsulates depth-stencil test information for the output-merger stage.
    /// </summary>
    /// <param name="desc">A depth-stencil state description.</param>
    /// <returns>The created depth-stencil state object.</returns>
    public D3D11DepthStencilState CreateDepthStencilState(in D3D11DepthStencilDesc desc)
    {
        int size = D3D11DepthStencilDesc.NativeRequiredSize();
        byte* descPtr = stackalloc byte[size];
        D3D11DepthStencilDesc.NativeWriteTo((nint)descPtr, desc);
        nint ptr;
        int hr = _comImpl->CreateDepthStencilState(_comPtr, descPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D3D11DepthStencilState(ptr);
    }

    /// <summary>
    /// Create a rasterizer state object that tells the rasterizer stage how to behave.
    /// </summary>
    /// <param name="desc">A rasterizer state description.</param>
    /// <returns>The created rasterizer state object.</returns>
    public D3D11RasterizerState CreateRasterizerState(in D3D11RasterizerDesc desc)
    {
        int size = D3D11RasterizerDesc.NativeRequiredSize();
        byte* descPtr = stackalloc byte[size];
        D3D11RasterizerDesc.NativeWriteTo((nint)descPtr, desc);
        nint ptr;
        int hr = _comImpl->CreateRasterizerState(_comPtr, descPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D3D11RasterizerState(ptr);
    }

    /// <summary>
    /// Create a sampler-state object that encapsulates sampling information for a texture.
    /// </summary>
    /// <param name="desc">A sampler state description.</param>
    /// <returns>The created sampler-state object.</returns>
    public D3D11SamplerState CreateSamplerState(in D3D11SamplerDesc desc)
    {
        int size = D3D11SamplerDesc.NativeRequiredSize();
        byte* descPtr = stackalloc byte[size];
        D3D11SamplerDesc.NativeWriteTo((nint)descPtr, desc);
        nint ptr;
        int hr = _comImpl->CreateSamplerState(_comPtr, descPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D3D11SamplerState(ptr);
    }

    /// <summary>
    /// Creates an object for querying information from the GPU.
    /// </summary>
    /// <param name="desc">A query description.</param>
    /// <returns>The created query.</returns>
    public D3D11Query CreateQuery(in D3D11QueryDesc desc)
    {
        int size = D3D11QueryDesc.NativeRequiredSize();
        byte* descPtr = stackalloc byte[size];
        D3D11QueryDesc.NativeWriteTo((nint)descPtr, desc);
        nint ptr;
        int hr = _comImpl->CreateQuery(_comPtr, descPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D3D11Query(ptr);
    }

    /// <summary>
    /// Creates a predicate.
    /// </summary>
    /// <param name="desc">A query description for a predicate.</param>
    /// <returns>The created predicate.</returns>
    public D3D11Predicate CreatePredicate(in D3D11QueryDesc desc)
    {
        int size = D3D11QueryDesc.NativeRequiredSize();
        byte* descPtr = stackalloc byte[size];
        D3D11QueryDesc.NativeWriteTo((nint)descPtr, desc);
        nint ptr;
        int hr = _comImpl->CreatePredicate(_comPtr, descPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D3D11Predicate(ptr);
    }

    /// <summary>
    /// Create a counter object for measuring GPU performance.
    /// </summary>
    /// <param name="desc">A counter description.</param>
    /// <returns>The created counter.</returns>
    public D3D11Counter CreateCounter(in D3D11CounterDesc desc)
    {
        int size = D3D11CounterDesc.NativeRequiredSize();
        byte* descPtr = stackalloc byte[size];
        D3D11CounterDesc.NativeWriteTo((nint)descPtr, desc);
        nint ptr;
        int hr = _comImpl->CreateCounter(_comPtr, descPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D3D11Counter(ptr);
    }

    /// <summary>
    /// Creates a deferred context, which can record command lists.
    /// </summary>
    /// <returns>The created deferred context.</returns>
    public D3D11DeviceContext CreateDeferredContext()
    {
        nint ptr;
        int hr = _comImpl->CreateDeferredContext(_comPtr, 0, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D3D11DeviceContext(ptr);
    }

    /// <summary>
    /// Give a device access to a shared resource created on a different device.
    /// </summary>
    /// <param name="resourceHandle">A resource handle.</param>
    /// <param name="returnedInterface">The globally unique identifier (GUID) for the resource interface.</param>
    /// <returns>A pointer to the resource we are gaining access to.</returns>
    public nint OpenSharedResource(nint resourceHandle, in Guid returnedInterface)
    {
        nint ptr;
        int hr = _comImpl->OpenSharedResource(_comPtr, resourceHandle, returnedInterface, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return ptr;
    }

    /// <summary>
    /// Give a device access to a shared resource created on a different device.
    /// </summary>
    /// <param name="resourceHandle">A resource handle.</param>
    /// <returns>A pointer to the resource we are gaining access to.</returns>
    public D3D11Buffer OpenSharedBuffer(nint resourceHandle)
    {
        nint ptr = OpenSharedResource(resourceHandle, D3D11Buffer.D3D11BufferGuid);
        return new D3D11Buffer(ptr);
    }

    /// <summary>
    /// Give a device access to a shared resource created on a different device.
    /// </summary>
    /// <param name="resourceHandle">A resource handle.</param>
    /// <returns>A pointer to the resource we are gaining access to.</returns>
    public D3D11Texture1D OpenSharedTexture1D(nint resourceHandle)
    {
        nint ptr = OpenSharedResource(resourceHandle, D3D11Texture1D.D3D11Texture1DGuid);
        return new D3D11Texture1D(ptr);
    }

    /// <summary>
    /// Give a device access to a shared resource created on a different device.
    /// </summary>
    /// <param name="resourceHandle">A resource handle.</param>
    /// <returns>A pointer to the resource we are gaining access to.</returns>
    public D3D11Texture2D OpenSharedTexture2D(nint resourceHandle)
    {
        nint ptr = OpenSharedResource(resourceHandle, D3D11Texture2D.D3D11Texture2DGuid);
        return new D3D11Texture2D(ptr);
    }

    /// <summary>
    /// Give a device access to a shared resource created on a different device.
    /// </summary>
    /// <param name="resourceHandle">A resource handle.</param>
    /// <returns>A pointer to the resource we are gaining access to.</returns>
    public D3D11Texture3D OpenSharedTexture3D(nint resourceHandle)
    {
        nint ptr = OpenSharedResource(resourceHandle, D3D11Texture3D.D3D11Texture3DGuid);
        return new D3D11Texture3D(ptr);
    }

    /// <summary>
    /// Get the support of a given format on the installed video device.
    /// </summary>
    /// <param name="format">A format for which to check for support.</param>
    /// <param name="formatSupport">Describes how the specified format is supported on the installed device.</param>
    /// <returns>A boolean value.</returns>
    public bool CheckFormatSupport(DxgiFormat format, out D3D11FormatSupport formatSupport)
    {
        D3D11FormatSupport support;
        int hr = _comImpl->CheckFormatSupport(_comPtr, format, &support);
        formatSupport = support;
        return hr == 0;
    }

    /// <summary>
    /// Get the number of quality levels available during multisampling.
    /// </summary>
    /// <param name="format">The texture format.</param>
    /// <param name="sampleCount">The number of samples during multisampling.</param>
    /// <param name="numQualityLevels">The number of quality levels supported by the adapter.</param>
    /// <returns>A boolean value.</returns>
    public bool CheckMultisampleQualityLevels(DxgiFormat format, uint sampleCount, out uint numQualityLevels)
    {
        uint num;
        int hr = _comImpl->CheckMultisampleQualityLevels(_comPtr, format, sampleCount, &num);
        numQualityLevels = num;
        return hr == 0;
    }

    /// <summary>
    /// Get a counter's information.
    /// </summary>
    /// <returns>A counter information.</returns>
    public D3D11CounterInfo CheckCounterInfo()
    {
        int size = D3D11CounterInfo.NativeRequiredSize();
        byte* ptr = stackalloc byte[size];
        _comImpl->CheckCounterInfo(_comPtr, ptr);
        return D3D11CounterInfo.NativeReadFrom((nint)ptr);
    }

    /// <summary>
    /// Get the type, name, units of measure, and a description of an existing counter.
    /// </summary>
    /// <param name="desc">A counter description.</param>
    /// <param name="type">The data type of a counter.</param>
    /// <param name="activeCounters">The number of hardware counters that are needed for this counter type to be created. All instances of the same counter type use the same hardware counters.</param>
    /// <returns>A boolean value.</returns>
    public bool CheckCounter(in D3D11CounterDesc desc, out D3D11CounterDataType type, out uint activeCounters)
    {
        int size = D3D11CounterDesc.NativeRequiredSize();
        byte* descPtr = stackalloc byte[size];
        D3D11CounterDesc.NativeWriteTo((nint)descPtr, desc);
        D3D11CounterDataType dataType;
        uint counters;
        int hr = _comImpl->CheckCounter(_comPtr, descPtr, &dataType, &counters, null, null, null, null, null, null);
        type = dataType;
        activeCounters = counters;
        return hr == 0;
    }

    /// <summary>
    /// Get the type, name, units of measure, and a description of an existing counter.
    /// </summary>
    /// <param name="desc">A counter description.</param>
    /// <param name="type">The data type of a counter.</param>
    /// <param name="activeCounters">The number of hardware counters that are needed for this counter type to be created. All instances of the same counter type use the same hardware counters.</param>
    /// <param name="nameSize"></param>
    /// <param name="unitsSize"></param>
    /// <param name="descriptionSize"></param>
    /// <returns>A boolean value.</returns>
    /// <returns></returns>
    public bool CheckCounter(in D3D11CounterDesc desc, out D3D11CounterDataType type, out uint activeCounters, out uint nameSize, out uint unitsSize, out uint descriptionSize)
    {
        int size = D3D11CounterDesc.NativeRequiredSize();
        byte* descPtr = stackalloc byte[size];
        D3D11CounterDesc.NativeWriteTo((nint)descPtr, desc);
        D3D11CounterDataType dataType;
        uint counters;

        uint nameLength = 1;
        uint unitsLength = 1;
        uint descriptionLength = 1;
        int hr = _comImpl->CheckCounter(_comPtr, descPtr, &dataType, &counters, null, &nameLength, null, &unitsLength, null, &descriptionLength);
        type = dataType;
        activeCounters = counters;
        nameSize = nameLength;
        unitsSize = unitsLength;
        descriptionSize = descriptionLength;
        return hr == 0;
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
    public bool CheckCounter(
        in D3D11CounterDesc desc,
        out D3D11CounterDataType type,
        out uint activeCounters,
        Span<char> name,
        Span<char> units,
        Span<char> description)
    {
        int size = D3D11CounterDesc.NativeRequiredSize();
        byte* descPtr = stackalloc byte[size];
        D3D11CounterDesc.NativeWriteTo((nint)descPtr, desc);
        D3D11CounterDataType dataType;
        uint counters;
        int hr;

        uint nameLength = 1;
        uint unitsLength = 1;
        uint descriptionLength = 1;
        hr = _comImpl->CheckCounter(_comPtr, descPtr, &dataType, &counters, null, &nameLength, null, &unitsLength, null, &descriptionLength);
        type = dataType;
        activeCounters = counters;

        if (hr != 0)
        {
            return false;
        }

        byte* namePtr = stackalloc byte[(int)nameLength];
        byte* unitsPtr = stackalloc byte[(int)unitsLength];
        byte* descriptionPtr = stackalloc byte[(int)descriptionLength];

        hr = _comImpl->CheckCounter(_comPtr, descPtr, &dataType, &counters, namePtr, &nameLength, unitsPtr, &unitsLength, descriptionPtr, &descriptionLength);

        if (hr != 0)
        {
            return false;
        }

        fixed (char* pName = name)
        {
            Encoding.ASCII.GetChars(namePtr, (int)nameLength - 1, pName, name.Length);
        }

        fixed (char* pUnits = units)
        {
            Encoding.ASCII.GetChars(unitsPtr, (int)unitsLength - 1, pUnits, units.Length);
        }

        fixed (char* pDescription = description)
        {
            Encoding.ASCII.GetChars(descriptionPtr, (int)descriptionLength - 1, pDescription, description.Length);
        }

        return true;
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
    public bool CheckCounter(
        in D3D11CounterDesc desc,
        out D3D11CounterDataType type,
        out uint activeCounters,
        out string name,
        out string units,
        out string description)
    {
        int size = D3D11CounterDesc.NativeRequiredSize();
        byte* descPtr = stackalloc byte[size];
        D3D11CounterDesc.NativeWriteTo((nint)descPtr, desc);
        D3D11CounterDataType dataType;
        uint counters;
        int hr;

        uint nameLength = 1;
        uint unitsLength = 1;
        uint descriptionLength = 1;
        hr = _comImpl->CheckCounter(_comPtr, descPtr, &dataType, &counters, null, &nameLength, null, &unitsLength, null, &descriptionLength);
        type = dataType;
        activeCounters = counters;

        if (hr != 0)
        {
            name = string.Empty;
            units = string.Empty;
            description = string.Empty;
            return false;
        }

        byte* namePtr = stackalloc byte[(int)nameLength];
        byte* unitsPtr = stackalloc byte[(int)unitsLength];
        byte* descriptionPtr = stackalloc byte[(int)descriptionLength];

        hr = _comImpl->CheckCounter(_comPtr, descPtr, &dataType, &counters, namePtr, &nameLength, unitsPtr, &unitsLength, descriptionPtr, &descriptionLength);

        if (hr != 0)
        {
            name = string.Empty;
            units = string.Empty;
            description = string.Empty;
            return false;
        }

        name = Encoding.ASCII.GetString(namePtr, (int)nameLength - 1);
        units = Encoding.ASCII.GetString(unitsPtr, (int)unitsLength - 1);
        description = Encoding.ASCII.GetString(descriptionPtr, (int)descriptionLength - 1);

        return true;
    }

    /// <summary>
    /// Gets information about the features that are supported by the current graphics driver.
    /// </summary>
    /// <typeparam name="T">The type of structure to return.</typeparam>
    /// <param name="feature">Describes which feature to query for support.</param>
    /// <returns>A structure filled with data that describes the feature support.</returns>
    private T CheckFeatureSupport<T>(D3D11Feature feature)
        where T : unmanaged
    {
        T data;
        int dataSize = DXMarshal.SizeOf<T>();
        int hr = _comImpl->CheckFeatureSupport(_comPtr, feature, &data, (uint)dataSize);
        Marshal.ThrowExceptionForHR(hr);
        return data;
    }

    /// <summary>
    /// Gets information about the features that are supported by the current graphics driver.
    /// </summary>
    /// <param name="feature">Describes which feature to query for support.</param>
    /// <returns>A structure filled with data that describes the feature support.</returns>
    public object CheckFeatureSupport(D3D11Feature feature)
    {
        return feature switch
        {
            D3D11Feature.Threading => CheckFeatureSupport<D3D11FeatureDataThreading>(D3D11Feature.Threading),
            D3D11Feature.Doubles => CheckFeatureSupport<D3D11FeatureDataDoubles>(D3D11Feature.Doubles),
            D3D11Feature.FormatSupport => CheckFeatureSupport<D3D11FeatureDataFormatSupport>(D3D11Feature.FormatSupport),
            D3D11Feature.FormatSupport2 => CheckFeatureSupport<D3D11FeatureDataFormatSupport2>(D3D11Feature.FormatSupport2),
            D3D11Feature.D3D10XHardwareOptions => CheckFeatureSupport<D3D11FeatureDataD3D10XHardwareOptions>(D3D11Feature.D3D10XHardwareOptions),
            D3D11Feature.D3D11Options => CheckFeatureSupport<D3D11FeatureDataD3D11Options>(D3D11Feature.D3D11Options),
            D3D11Feature.ArchitectureInfo => CheckFeatureSupport<D3D11FeatureDataArchitectureInfo>(D3D11Feature.ArchitectureInfo),
            D3D11Feature.D3D9Options => CheckFeatureSupport<D3D11FeatureDataD3D9Options>(D3D11Feature.D3D9Options),
            D3D11Feature.ShaderMinPrecisionSupport => CheckFeatureSupport<D3D11FeatureDataShaderMinPrecisionSupport>(D3D11Feature.ShaderMinPrecisionSupport),
            D3D11Feature.D3D9ShadowSupport => CheckFeatureSupport<D3D11FeatureDataD3D9ShadowSupport>(D3D11Feature.D3D9ShadowSupport),
            D3D11Feature.D3D11Options1 => CheckFeatureSupport<D3D11FeatureDataD3D11Options1>(D3D11Feature.D3D11Options1),
            D3D11Feature.D3D9SimpleInstancingSupport => CheckFeatureSupport<D3D11FeatureDataD3D9SimpleInstancingSupport>(D3D11Feature.D3D9SimpleInstancingSupport),
            D3D11Feature.MarkerSupport => CheckFeatureSupport<D3D11FeatureDataMarkerSupport>(D3D11Feature.MarkerSupport),
            D3D11Feature.D3D9Options1 => CheckFeatureSupport<D3D11FeatureDataD3D9Options1>(D3D11Feature.D3D9Options1),
            _ => throw new ArgumentOutOfRangeException(nameof(feature)),
        };
    }

    /// <summary>
    /// Gets information about the features that are supported by the current graphics driver.
    /// </summary>
    /// <returns>A structure filled with data that describes the feature support.</returns>
    public D3D11FeatureDataThreading CheckFeatureSupportThreading()
    {
        return CheckFeatureSupport<D3D11FeatureDataThreading>(D3D11Feature.Threading);
    }

    /// <summary>
    /// Gets information about the features that are supported by the current graphics driver.
    /// </summary>
    /// <returns>A structure filled with data that describes the feature support.</returns>
    public D3D11FeatureDataDoubles CheckFeatureSupportDoubles()
    {
        return CheckFeatureSupport<D3D11FeatureDataDoubles>(D3D11Feature.Doubles);
    }

    /// <summary>
    /// Gets information about the features that are supported by the current graphics driver.
    /// </summary>
    /// <returns>A structure filled with data that describes the feature support.</returns>
    public D3D11FeatureDataFormatSupport CheckFeatureSupportFormatSupport()
    {
        return CheckFeatureSupport<D3D11FeatureDataFormatSupport>(D3D11Feature.FormatSupport);
    }

    /// <summary>
    /// Gets information about the features that are supported by the current graphics driver.
    /// </summary>
    /// <returns>A structure filled with data that describes the feature support.</returns>
    public D3D11FeatureDataFormatSupport2 CheckFeatureSupportFormatSupport2()
    {
        return CheckFeatureSupport<D3D11FeatureDataFormatSupport2>(D3D11Feature.FormatSupport2);
    }

    /// <summary>
    /// Gets information about the features that are supported by the current graphics driver.
    /// </summary>
    /// <returns>A structure filled with data that describes the feature support.</returns>
    public D3D11FeatureDataD3D10XHardwareOptions CheckFeatureSupportD3D10XHardwareOptions()
    {
        return CheckFeatureSupport<D3D11FeatureDataD3D10XHardwareOptions>(D3D11Feature.D3D10XHardwareOptions);
    }

    /// <summary>
    /// Gets information about the features that are supported by the current graphics driver.
    /// </summary>
    /// <returns>A structure filled with data that describes the feature support.</returns>
    public D3D11FeatureDataD3D11Options CheckFeatureSupportD3D11Options()
    {
        return CheckFeatureSupport<D3D11FeatureDataD3D11Options>(D3D11Feature.D3D11Options);
    }

    /// <summary>
    /// Gets information about the features that are supported by the current graphics driver.
    /// </summary>
    /// <returns>A structure filled with data that describes the feature support.</returns>
    public D3D11FeatureDataArchitectureInfo CheckFeatureSupportArchitectureInfo()
    {
        return CheckFeatureSupport<D3D11FeatureDataArchitectureInfo>(D3D11Feature.ArchitectureInfo);
    }

    /// <summary>
    /// Gets information about the features that are supported by the current graphics driver.
    /// </summary>
    /// <returns>A structure filled with data that describes the feature support.</returns>
    public D3D11FeatureDataD3D9Options CheckFeatureSupportD3D9Options()
    {
        return CheckFeatureSupport<D3D11FeatureDataD3D9Options>(D3D11Feature.D3D9Options);
    }

    /// <summary>
    /// Gets information about the features that are supported by the current graphics driver.
    /// </summary>
    /// <returns>A structure filled with data that describes the feature support.</returns>
    public D3D11FeatureDataShaderMinPrecisionSupport CheckFeatureSupportShaderMinPrecisionSupport()
    {
        return CheckFeatureSupport<D3D11FeatureDataShaderMinPrecisionSupport>(D3D11Feature.ShaderMinPrecisionSupport);
    }

    /// <summary>
    /// Gets information about the features that are supported by the current graphics driver.
    /// </summary>
    /// <returns>A structure filled with data that describes the feature support.</returns>
    public D3D11FeatureDataD3D9ShadowSupport CheckFeatureSupportD3D9ShadowSupport()
    {
        return CheckFeatureSupport<D3D11FeatureDataD3D9ShadowSupport>(D3D11Feature.D3D9ShadowSupport);
    }

    /// <summary>
    /// Gets information about the features that are supported by the current graphics driver.
    /// </summary>
    /// <returns>A structure filled with data that describes the feature support.</returns>
    public D3D11FeatureDataD3D11Options1 CheckFeatureSupportD3D11Options1()
    {
        return CheckFeatureSupport<D3D11FeatureDataD3D11Options1>(D3D11Feature.D3D11Options1);
    }

    /// <summary>
    /// Gets information about the features that are supported by the current graphics driver.
    /// </summary>
    /// <returns>A structure filled with data that describes the feature support.</returns>
    public D3D11FeatureDataD3D9SimpleInstancingSupport CheckFeatureSupportD3D9SimpleInstancingSupport()
    {
        return CheckFeatureSupport<D3D11FeatureDataD3D9SimpleInstancingSupport>(D3D11Feature.D3D9SimpleInstancingSupport);
    }

    /// <summary>
    /// Gets information about the features that are supported by the current graphics driver.
    /// </summary>
    /// <returns>A structure filled with data that describes the feature support.</returns>
    public D3D11FeatureDataMarkerSupport CheckFeatureSupportMarkerSupport()
    {
        return CheckFeatureSupport<D3D11FeatureDataMarkerSupport>(D3D11Feature.MarkerSupport);
    }

    /// <summary>
    /// Gets information about the features that are supported by the current graphics driver.
    /// </summary>
    /// <returns>A structure filled with data that describes the feature support.</returns>
    public D3D11FeatureDataD3D9Options1 CheckFeatureSupportD3D9Options1()
    {
        return CheckFeatureSupport<D3D11FeatureDataD3D9Options1>(D3D11Feature.D3D9Options1);
    }

    /// <summary>
    /// Get the reason why the device was removed.
    /// </summary>
    /// <returns>The removed reason exception.</returns>
    public Exception? GetDeviceRemovedReason()
    {
        int hr = _comImpl->GetDeviceRemovedReason(_comPtr);
        return Marshal.GetExceptionForHR(hr);
    }

    /// <summary>
    /// Throw a device removed reason exception.
    /// </summary>
    public void ThrowDeviceRemovedReason()
    {
        Exception? reason = GetDeviceRemovedReason();

        if (reason is not null)
        {
            throw reason;
        }
    }

    /// <summary>
    /// Gets an immediate context, which can play back command lists.
    /// </summary>
    /// <returns>An immediate context.</returns>
    public D3D11DeviceContext GetImmediateContext()
    {
        nint ptr;
        _comImpl->GetImmediateContext(_comPtr, &ptr);
        return new D3D11DeviceContext(ptr);
    }
}
