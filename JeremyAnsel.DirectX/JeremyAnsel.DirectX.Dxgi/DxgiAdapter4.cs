// <copyright file="DxgiAdapter4.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using JeremyAnsel.DirectX.Dxgi.ComInterfaces;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.Dxgi;

/// <summary>
/// The <c>IDXGIAdapter4</c> interface represents a display sub-system, which includes one or more GPUs, DACs, and video memory.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class DxgiAdapter4 : DxgiObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid DxgiAdapter4Guid = typeof(IDxgiAdapter3).GUID;

    private readonly nint _comPtr;
    private readonly IDxgiAdapter3* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="DxgiAdapter4"/> class.
    /// </summary>
    public DxgiAdapter4(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IDxgiAdapter3**)comPtr;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="adapter"></param>
    /// <returns></returns>
    public static DxgiAdapter4 FromAdapter(nint adapter)
    {
        nint ptr = DXUtils.QueryInterface(adapter, DxgiAdapter4Guid);
        return new DxgiAdapter4(ptr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="adapter"></param>
    /// <returns></returns>
    public static DxgiAdapter4 FromAdapter(DxgiAdapter adapter)
    {
        nint ptr = adapter.QueryInterface(DxgiAdapter4Guid);
        return new DxgiAdapter4(ptr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="adapter"></param>
    /// <returns></returns>
    public static DxgiAdapter4 FromAdapter(DxgiAdapter1 adapter)
    {
        nint ptr = adapter.QueryInterface(DxgiAdapter4Guid);
        return new DxgiAdapter4(ptr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="adapter"></param>
    /// <returns></returns>
    public static DxgiAdapter4 FromAdapter(DxgiAdapter2 adapter)
    {
        nint ptr = adapter.QueryInterface(DxgiAdapter4Guid);
        return new DxgiAdapter4(ptr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="adapter"></param>
    /// <returns></returns>
    public static DxgiAdapter4 FromAdapter(DxgiAdapter3 adapter)
    {
        nint ptr = adapter.QueryInterface(DxgiAdapter4Guid);
        return new DxgiAdapter4(ptr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public DxgiQueryVideoMemoryInfo QueryVideoMemoryInfo()
    {
        return QueryVideoMemoryInfo(0, DxgiMemorySegmentGroup.Local);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="nodeIndex"></param>
    /// <returns></returns>
    public DxgiQueryVideoMemoryInfo QueryVideoMemoryInfo(uint nodeIndex)
    {
        return QueryVideoMemoryInfo(nodeIndex, DxgiMemorySegmentGroup.Local);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="nodeIndex"></param>
    /// <param name="memorySegmentGroup"></param>
    /// <returns></returns>
    public DxgiQueryVideoMemoryInfo QueryVideoMemoryInfo(uint nodeIndex, DxgiMemorySegmentGroup memorySegmentGroup)
    {
        int size = DxgiQueryVideoMemoryInfo.NativeRequiredSize();
        byte* ptr = stackalloc byte[size];
        int hr = _comImpl->QueryVideoMemoryInfo(_comPtr, nodeIndex, memorySegmentGroup, ptr);
        Marshal.ThrowExceptionForHR(hr);
        return DxgiQueryVideoMemoryInfo.NativeReadFrom((nint)ptr);
    }
}
