// <copyright file="D3D11ClassInstance.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D3D11.ComInterfaces;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// This interface encapsulates an HLSL class.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class D3D11ClassInstance : D3D11DeviceChild
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid D3D11ClassInstanceGuid = typeof(ID3D11ClassInstance).GUID;

    private readonly nint _comPtr;
    private readonly ID3D11ClassInstance* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11ClassInstance"/> class.
    /// </summary>
    public D3D11ClassInstance(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(ID3D11ClassInstance**)comPtr;
    }

    /// <summary>
    /// Gets a description of the current HLSL class.
    /// </summary>
    public D3D11ClassInstanceDesc Description
    {
        get
        {
            int size = D3D11ClassInstanceDesc.NativeRequiredSize();
            byte* ptr = stackalloc byte[size];
            _comImpl->GetDesc(_comPtr, ptr);
            return D3D11ClassInstanceDesc.NativeReadFrom((nint)ptr);
        }
    }

    /// <summary>
    /// Gets the instance name of the current HLSL class.
    /// </summary>
    public string InstanceName
    {
        get
        {
            nuint length = 256;
            byte* dataPtr = stackalloc byte[(int)length];
            _comImpl->GetInstanceName(_comPtr, dataPtr, &length);
            string text = Encoding.ASCII.GetString(dataPtr, (int)length);
            return text;
        }
    }

    /// <summary>
    /// Gets the instance name of the current HLSL class.
    /// </summary>
    /// <returns>The count.</returns>
    public int GetInstanceNameCharCount()
    {
        nuint dataSize = 0;
        _comImpl->GetInstanceName(_comPtr, null, &dataSize);
        return (int)dataSize;
    }

    /// <summary>
    /// Gets the instance name of the current HLSL class.
    /// </summary>
    /// <param name="text">A char buffer.</param>
    /// <returns>The object's text.</returns>
    public int GetInstanceNameChars(Span<char> text)
    {
        nuint dataSize = 256;
        byte* dataPtr = stackalloc byte[(int)dataSize];
        _comImpl->GetInstanceName(_comPtr, dataPtr, &dataSize);

        int count;
        fixed (char* textPtr = text)
        {
            count = Encoding.ASCII.GetChars(dataPtr, (int)dataSize, textPtr, text.Length);
        }

        return count;
    }

    /// <summary>
    /// Gets the type of the current HLSL class.
    /// </summary>
    public string TypeName
    {
        get
        {
            nuint length = 256;
            byte* dataPtr = stackalloc byte[(int)length];
            _comImpl->GetTypeName(_comPtr, dataPtr, &length);
            string text = Encoding.ASCII.GetString(dataPtr, (int)length);
            return text;
        }
    }

    /// <summary>
    /// Gets the type of the current HLSL class.
    /// </summary>
    /// <returns>The count.</returns>
    public int GetTypeNameCharCount()
    {
        nuint dataSize = 0;
        _comImpl->GetTypeName(_comPtr, null, &dataSize);
        return (int)dataSize;
    }

    /// <summary>
    /// Gets the type of the current HLSL class.
    /// </summary>
    /// <param name="text">A char buffer.</param>
    /// <returns>The object's text.</returns>
    public int GetTypeNameChars(Span<char> text)
    {
        nuint dataSize = 256;
        byte* dataPtr = stackalloc byte[(int)dataSize];
        _comImpl->GetTypeName(_comPtr, dataPtr, &dataSize);

        int count;
        fixed (char* textPtr = text)
        {
            count = Encoding.ASCII.GetChars(dataPtr, (int)dataSize, textPtr, text.Length);
        }

        return count;
    }

    /// <summary>
    /// Gets the <see cref="D3D11ClassLinkage"/> object associated with the current HLSL class.
    /// </summary>
    /// <returns>A class linkage object.</returns>
    public D3D11ClassLinkage GetClassLinkage()
    {
        nint ptr;
        _comImpl->GetClassLinkage(_comPtr, &ptr);
        return new D3D11ClassLinkage(ptr);
    }
}
