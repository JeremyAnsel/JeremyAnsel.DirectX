using JeremyAnsel.DirectX.DXCommon;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.DirectSound;

[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class DirectSound3DBuffer : DXComObject
{
    public static readonly Guid IID_IDirectSound3DBuffer = new(0x279AFA86, 0x4981, 0x11CE, 0xA5, 0x21, 0x00, 0x20, 0xAF, 0x0B, 0xE5, 0x60);

    private readonly nint _comPtr;
    private readonly IDirectSound3DBuffer* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="DirectSound3DBuffer"/> class.
    /// </summary>
    public DirectSound3DBuffer(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IDirectSound3DBuffer**)comPtr;
    }

    public Ds3dBufferDesc GetAllParameters()
    {
        Ds3dBufferDesc data;
        int hr = _comImpl->GetAllParameters(_comPtr, &data);
        Marshal.ThrowExceptionForHR(hr);
        return data;
    }

    public void GetConeAngles(out int inside, out int outside)
    {
        int i;
        int o;
        int hr = _comImpl->GetConeAngles(_comPtr, &i, &o);
        Marshal.ThrowExceptionForHR(hr);
        inside = i;
        outside = o;
    }

    public Vector3 GetConeOrientation()
    {
        Vector3 v;
        int hr = _comImpl->GetConeOrientation(_comPtr, &v);
        Marshal.ThrowExceptionForHR(hr);
        return v;
    }

    public int GetConeOutsideVolume()
    {
        int v;
        int hr = _comImpl->GetConeOutsideVolume(_comPtr, &v);
        Marshal.ThrowExceptionForHR(hr);
        return v;
    }

    public float GetMaxDistance()
    {
        float v;
        int hr = _comImpl->GetMaxDistance(_comPtr, &v);
        Marshal.ThrowExceptionForHR(hr);
        return v;
    }

    public float GetMinDistance()
    {
        float v;
        int hr = _comImpl->GetMinDistance(_comPtr, &v);
        Marshal.ThrowExceptionForHR(hr);
        return v;
    }

    public Ds3dMode GetMode()
    {
        int v;
        int hr = _comImpl->GetMode(_comPtr, &v);
        Marshal.ThrowExceptionForHR(hr);
        return (Ds3dMode)v;
    }

    public Vector3 GetPosition()
    {
        Vector3 v;
        int hr = _comImpl->GetPosition(_comPtr, &v);
        Marshal.ThrowExceptionForHR(hr);
        return v;
    }

    public Vector3 GetVelocity()
    {
        Vector3 v;
        int hr = _comImpl->GetVelocity(_comPtr, &v);
        Marshal.ThrowExceptionForHR(hr);
        return v;
    }

    public void SetAllParameters(in Ds3dBufferDesc bufferDesc, Ds3dApply apply)
    {
        Ds3dBufferDesc desc = bufferDesc;
        int hr = _comImpl->SetAllParameters(_comPtr, &desc, (int)apply);
        Marshal.ThrowExceptionForHR(hr);
    }

    public void SetConeAngles(int inside, int outside, Ds3dApply apply)
    {
        int hr = _comImpl->SetConeAngles(_comPtr, inside, outside, (int)apply);
        Marshal.ThrowExceptionForHR(hr);
    }

    public void SetConeOrientation(float x, float y, float z, Ds3dApply apply)
    {
        int hr = _comImpl->SetConeOrientation(_comPtr, x, y, z, (int)apply);
        Marshal.ThrowExceptionForHR(hr);
    }

    public void SetConeOutsideVolume(int volume, Ds3dApply apply)
    {
        int hr = _comImpl->SetConeOutsideVolume(_comPtr, volume, (int)apply);
        Marshal.ThrowExceptionForHR(hr);
    }

    public void SetMaxDistance(float distance, Ds3dApply apply)
    {
        int hr = _comImpl->SetMaxDistance(_comPtr, distance, (int)apply);
        Marshal.ThrowExceptionForHR(hr);
    }

    public void SetMinDistance(float distance, Ds3dApply apply)
    {
        int hr = _comImpl->SetMinDistance(_comPtr, distance, (int)apply);
        Marshal.ThrowExceptionForHR(hr);
    }

    public void SetMode(Ds3dMode mode, Ds3dApply apply)
    {
        int hr = _comImpl->SetMode(_comPtr, (int)mode, (int)apply);
        Marshal.ThrowExceptionForHR(hr);
    }

    public void SetPosition(float x, float y, float z, Ds3dApply apply)
    {
        int hr = _comImpl->SetPosition(_comPtr, x, y, z, (int)apply);
        Marshal.ThrowExceptionForHR(hr);
    }

    public void SetVelocity(float x, float y, float z, Ds3dApply apply)
    {
        int hr = _comImpl->SetVelocity(_comPtr, x, y, z, (int)apply);
        Marshal.ThrowExceptionForHR(hr);
    }
}
