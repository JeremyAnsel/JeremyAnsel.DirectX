// <copyright file="DxgiAdapter1.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using JeremyAnsel.DirectX.Dxgi.ComInterfaces;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.Dxgi;

/// <summary>
/// The <c>IDXGIAdapter1</c> interface represents a display sub-system (including one or more GPU's, DACs and video memory).
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class DxgiAdapter1 : DxgiObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid DxgiAdapter1Guid = typeof(IDxgiAdapter1).GUID;

    private readonly nint _comPtr;
    private readonly IDxgiAdapter1* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="DxgiAdapter1"/> class.
    /// </summary>
    public DxgiAdapter1(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IDxgiAdapter1**)comPtr;
    }

    /// <summary>
    /// Gets a DXGI 1.1 description of an adapter (or video card).
    /// </summary>
    public DxgiAdapterDesc1 Description
    {
        get
        {
            int size = DxgiAdapterDesc1.NativeRequiredSize();
            byte* ptr = stackalloc byte[size];
            int hr = _comImpl->GetDesc1(_comPtr, ptr);
            Marshal.ThrowExceptionForHR(hr);
            return DxgiAdapterDesc1.NativeReadFrom((nint)ptr);
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
    /// <returns>An IEnumerable of <see cref="DxgiOutput1"/>.</returns>
    public IEnumerable<DxgiOutput1> EnumOutputs()
    {
        DxgiOutput1? output;
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
    public DxgiOutput1? EnumOutputs(uint i)
    {
        nint ptr;
        int hr = _comImpl->EnumOutputs(_comPtr, i, &ptr);
        if (hr != 0)
        {
            return null;
        }

        try
        {
            return new DxgiOutput1(DXUtils.QueryInterface(ptr, DxgiOutput1.DxgiOutput1Guid));
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
    public DxgiOutput1 GetOutput(uint i)
    {
        nint ptr;
        int hr = _comImpl->EnumOutputs(_comPtr, i, &ptr);
        Marshal.ThrowExceptionForHR(hr);

        try
        {
            return new DxgiOutput1(DXUtils.QueryInterface(ptr, DxgiOutput1.DxgiOutput1Guid));
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
    public DxgiFactory1 GetParent()
    {
        nint parent = GetParent(DxgiFactory1.DxgiFactory1Guid);
        return new DxgiFactory1(parent);
    }
}
