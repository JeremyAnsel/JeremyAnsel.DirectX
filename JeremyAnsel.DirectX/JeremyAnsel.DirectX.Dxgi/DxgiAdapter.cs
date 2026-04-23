// <copyright file="DxgiAdapter.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using JeremyAnsel.DirectX.Dxgi.ComInterfaces;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.Dxgi;

/// <summary>
/// The <c>IDXGIAdapter</c> interface represents a display sub-system (including one or more GPU's, DACs and video memory).
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class DxgiAdapter : DxgiObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid DxgiAdapterGuid = typeof(IDxgiAdapter).GUID;

    private readonly nint _comPtr;
    private readonly IDxgiAdapter* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="DxgiAdapter"/> class.
    /// </summary>
    public DxgiAdapter(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IDxgiAdapter**)comPtr;
    }

    /// <summary>
    /// Gets a DXGI 1.0 description of an adapter (or video card).
    /// </summary>
    public DxgiAdapterDesc Description
    {
        get
        {
            int size = DxgiAdapterDesc.NativeRequiredSize();
            byte* ptr = stackalloc byte[size];
            int hr = _comImpl->GetDesc(_comPtr, ptr);
            Marshal.ThrowExceptionForHR(hr);
            return DxgiAdapterDesc.NativeReadFrom((nint)ptr);
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
    /// <returns>An IEnumerable of <see cref="DxgiOutput"/>.</returns>
    public IEnumerable<DxgiOutput> EnumOutputs()
    {
        DxgiOutput? output;
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
    public DxgiOutput? EnumOutputs(uint i)
    {
        nint ptr;
        int hr = _comImpl->EnumOutputs(_comPtr, i, &ptr);
        return hr != 0 ? null : new DxgiOutput(ptr);
    }

    /// <summary>
    /// Enumerate adapter (video card) outputs.
    /// </summary>
    /// <param name="i"></param>
    /// <returns>An output</returns>
    public DxgiOutput GetOutput(uint i)
    {
        nint ptr;
        int hr = _comImpl->EnumOutputs(_comPtr, i, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new DxgiOutput(ptr);
    }

    /// <summary>
    /// Gets the parent of the object.
    /// </summary>
    /// <returns>The parent of the object.</returns>
    public DxgiFactory GetParent()
    {
        nint parent = GetParent(DxgiFactory.DxgiFactoryGuid);
        return new DxgiFactory(parent);
    }
}
