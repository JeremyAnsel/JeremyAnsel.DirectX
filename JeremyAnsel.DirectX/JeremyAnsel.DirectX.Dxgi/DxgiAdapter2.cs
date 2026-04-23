// <copyright file="DxgiAdapter2.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using JeremyAnsel.DirectX.Dxgi.ComInterfaces;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.Dxgi;

/// <summary>
/// The <c>IDXGIAdapter2</c> interface represents a display sub-system, which includes one or more GPUs, DACs, and video memory.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class DxgiAdapter2 : DxgiObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid DxgiAdapter2Guid = typeof(IDxgiAdapter2).GUID;

    private readonly nint _comPtr;
    private readonly IDxgiAdapter2* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="DxgiAdapter2"/> class.
    /// </summary>
    public DxgiAdapter2(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IDxgiAdapter2**)comPtr;
    }

    /// <summary>
    /// Gets a DXGI 1.2 description of an adapter (or video card).
    /// </summary>
    public DxgiAdapterDesc2 Description
    {
        get
        {
            int size = DxgiAdapterDesc2.NativeRequiredSize();
            byte* ptr = stackalloc byte[size];
            int hr = _comImpl->GetDesc2(_comPtr, ptr);
            Marshal.ThrowExceptionForHR(hr);
            return DxgiAdapterDesc2.NativeReadFrom((nint)ptr);
        }
    }

    /// <summary>
    /// Get the adapter (video card) outputs.
    /// </summary>
    /// <returns></returns>
    public int GetOutputsCount()
    {
        uint index = 0;

        while (true)
        {
            nint ptr;
            int hr = _comImpl->EnumOutputs(_comPtr, index, &ptr);

            if (hr != 0)
            {
                break;
            }

            DXUtils.Release(ptr);
            index++;
        }

        return (int)index;
    }

    /// <summary>
    /// Enumerate adapter (video card) outputs.
    /// </summary>
    /// <returns>An IEnumerable of <see cref="DxgiOutput2"/>.</returns>
    public IEnumerable<DxgiOutput2> EnumOutputs()
    {
        DxgiOutput2? output;
        for (uint i = 0; (output = EnumOutputs(i)) is not null; i++)
        {
            yield return output;
        }
    }

    /// <summary>
    /// Enumerate adapter (video card) outputs.
    /// </summary>
    /// <param name="i"></param>
    /// <returns>An output or null</returns>
    public DxgiOutput2? EnumOutputs(uint i)
    {
        nint ptr;
        int hr = _comImpl->EnumOutputs(_comPtr, i, &ptr);
        if (hr != 0)
        {
            return null;
        }

        try
        {
            return new DxgiOutput2(DXUtils.QueryInterface(ptr, DxgiOutput2.DxgiOutput2Guid));
        }
        finally
        {
            DXUtils.Release(ptr);
        }
    }

    /// <summary>
    /// Enumerate adapter (video card) outputs.
    /// </summary>
    /// <param name="i"></param>
    /// <returns>An output.</returns>
    public DxgiOutput2 GetOutput(uint i)
    {
        nint ptr;
        int hr = _comImpl->EnumOutputs(_comPtr, i, &ptr);
        Marshal.ThrowExceptionForHR(hr);

        try
        {
            return new DxgiOutput2(DXUtils.QueryInterface(ptr, DxgiOutput2.DxgiOutput2Guid));
        }
        finally
        {
            DXUtils.Release(ptr);
        }
    }

    /// <summary>
    /// Gets the parent of the object.
    /// </summary>
    /// <returns>The parent of the object.</returns>
    public DxgiFactory2 GetParent()
    {
        nint parent = GetParent(DxgiFactory2.DxgiFactory2Guid);
        return new DxgiFactory2(parent);
    }
}
