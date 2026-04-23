// <copyright file="DirectInputEffect.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.DirectInput;

/// <summary>
/// 
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class DirectInputEffect : DXComObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid DirectInputEffectGuid = typeof(IDirectInputEffect).GUID;

    private readonly nint _comPtr;
    private readonly IDirectInputEffect* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="DirectInputEffect"/> class.
    /// </summary>
    public DirectInputEffect(nint comPtr, DirectInputEffectInfo infos)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IDirectInputEffect**)comPtr;
        Infos = infos;
    }

    /// <summary>
    /// 
    /// </summary>
    public DirectInputEffectInfo Infos { get; }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public Guid GetEffectGuid()
    {
        Guid guid;
        int hr = _comImpl->GetEffectGuid(_comPtr, &guid);
        Marshal.ThrowExceptionForHR(hr);
        return guid;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="options"></param>
    /// <returns></returns>
    public DirectInputEffectParametersData GetParameters(DirectInputEffectParameterOptions options)
    {
        DirectInputEffectParametersData data;
        nint ptr = DirectInputEffectParametersData.AllocRawData(options, Infos.EffectType);

        try
        {
            int hr = _comImpl->GetParameters(_comPtr, (void*)ptr, (uint)options);
            Marshal.ThrowExceptionForHR(hr);
            data = DirectInputEffectParametersData.FromRawData(ptr, options, Infos.EffectType);
        }
        finally
        {
            DirectInputEffectParametersData.FreeRawData(ptr);
        }

        return data;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="peff"></param>
    /// <param name="options"></param>
    /// <exception cref="ObjectDisposedException"></exception>
    public void SetParameters(DirectInputEffectParametersData peff, DirectInputEffectParameterOptions options)
    {
        nint ptr = peff.ToRawData(options);

        try
        {
            int hr = _comImpl->SetParameters(_comPtr, (void*)ptr, (uint)options);
            Marshal.ThrowExceptionForHR(hr);
        }
        finally
        {
            DirectInputEffectParametersData.FreeRawData(ptr);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="iterations"></param>
    /// <param name="options"></param>
    /// <exception cref="ObjectDisposedException"></exception>
    public void Start(int iterations, DirectInputEffectStartOptions options)
    {
        int hr = _comImpl->Start(_comPtr, iterations, (uint)options);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// 
    /// </summary>
    public void Stop()
    {
        int hr = _comImpl->Stop(_comPtr);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    /// <exception cref="ObjectDisposedException"></exception>
    public DirectInputEffectStatus GetEffectStatus()
    {
        uint status;
        int hr = _comImpl->GetEffectStatus(_comPtr, &status);
        Marshal.ThrowExceptionForHR(hr);
        return (DirectInputEffectStatus)status;
    }

    /// <summary>
    /// 
    /// </summary>
    public void Download()
    {
        int hr = _comImpl->Download(_comPtr);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <exception cref="ObjectDisposedException"></exception>
    public void Unload()
    {
        int hr = _comImpl->Unload(_comPtr);
        Marshal.ThrowExceptionForHR(hr);
    }
}
