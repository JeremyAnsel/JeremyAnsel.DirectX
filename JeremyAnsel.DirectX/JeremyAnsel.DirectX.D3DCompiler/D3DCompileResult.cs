// <copyright file="D3DCompileResult.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D3DCompiler.ComInterfaces;
using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.D3DCompiler;

/// <summary>
/// A pointer to the compiled code.
/// </summary>
[SecurityCritical]
[SkipLocalsInit]
public readonly unsafe ref struct D3DCompileResult
{
    private readonly nint _comPtr;
    private readonly ID3DBlob* _comImpl;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="comPtr"></param>
    internal D3DCompileResult(nint comPtr)
    {
        _comPtr = comPtr;
        _comImpl = comPtr == 0 ? null : *(ID3DBlob**)comPtr;
    }

    /// <summary>
    /// 
    /// </summary>
    public void Dispose()
    {
        DXUtils.Release(_comPtr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public int GetDataLength()
    {
        if (_comPtr == 0)
        {
            return 0;
        }

        int length = (int)_comImpl->GetBufferSize(_comPtr);
        return length;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public byte[] GetData()
    {
        if (_comPtr == 0)
        {
            return [];
        }

        nint ptr = _comImpl->GetBufferPointer(_comPtr);
        int length = (int)_comImpl->GetBufferSize(_comPtr);

        var bytes = new byte[length];
        Marshal.Copy(ptr, bytes, 0, length);
        return bytes;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public ReadOnlySpan<byte> GetDataAsSpan()
    {
        if (_comPtr == 0)
        {
            return [];
        }

        nint ptr = _comImpl->GetBufferPointer(_comPtr);
        int length = (int)_comImpl->GetBufferSize(_comPtr);

        return new ReadOnlySpan<byte>((void*)ptr, length);
    }
}
