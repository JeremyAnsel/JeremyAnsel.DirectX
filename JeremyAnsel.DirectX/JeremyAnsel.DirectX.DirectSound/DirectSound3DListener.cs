using JeremyAnsel.DirectX.DXCommon;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.DirectSound;

[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class DirectSound3DListener : DXComObject
{
    public static readonly Guid IID_IDirectSound3DListener = new(0x279AFA84, 0x4981, 0x11CE, 0xA5, 0x21, 0x00, 0x20, 0xAF, 0x0B, 0xE5, 0x60);

    private readonly nint _comPtr;
    private readonly IDirectSound3DListener* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="DirectSound3DListener"/> class.
    /// </summary>
    public DirectSound3DListener(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IDirectSound3DListener**)comPtr;
    }

    public Ds3dListenerDesc GetAllParameters()
    {
        Ds3dListenerDesc data;
        int hr = _comImpl->GetAllParameters(_comPtr, &data);
        Marshal.ThrowExceptionForHR(hr);
        return data;
    }

    public float GetDistanceFactor()
    {
        float v;
        int hr = _comImpl->GetDistanceFactor(_comPtr, &v);
        Marshal.ThrowExceptionForHR(hr);
        return v;
    }

    public float GetDopplerFactor()
    {
        float v;
        int hr = _comImpl->GetDopplerFactor(_comPtr, &v);
        Marshal.ThrowExceptionForHR(hr);
        return v;
    }

    public void GetOrientation(out Vector3 front, out Vector3 top)
    {
        Vector3 f;
        Vector3 t;
        int hr = _comImpl->GetOrientation(_comPtr, &f, &t);
        Marshal.ThrowExceptionForHR(hr);
        front = f;
        top = t;
    }

    public Vector3 GetPosition()
    {
        Vector3 v;
        int hr = _comImpl->GetPosition(_comPtr, &v);
        Marshal.ThrowExceptionForHR(hr);
        return v;
    }

    public float GetRolloffFactor()
    {
        float v;
        int hr = _comImpl->GetRolloffFactor(_comPtr, &v);
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

    public void SetAllParameters(in Ds3dListenerDesc bufferDesc, Ds3dApply apply)
    {
        Ds3dListenerDesc desc = bufferDesc;
        int hr = _comImpl->SetAllParameters(_comPtr, &desc, (int)apply);
        Marshal.ThrowExceptionForHR(hr);
    }

    public void SetDistanceFactor(float factor, Ds3dApply apply)
    {
        int hr = _comImpl->SetDistanceFactor(_comPtr, factor, (int)apply);
        Marshal.ThrowExceptionForHR(hr);
    }

    public void SetDopplerFactor(float factor, Ds3dApply apply)
    {
        int hr = _comImpl->SetDopplerFactor(_comPtr, factor, (int)apply);
        Marshal.ThrowExceptionForHR(hr);
    }

    public void SetOrientation(float xFront, float yFront, float zFront, float xTop, float yTop, float zTop, Ds3dApply apply)
    {
        int hr = _comImpl->SetOrientation(_comPtr, xFront, yFront, zFront, xTop, yTop, zTop, (int)apply);
        Marshal.ThrowExceptionForHR(hr);
    }

    public void SetPosition(float x, float y, float z, Ds3dApply apply)
    {
        int hr = _comImpl->SetPosition(_comPtr, x, y, z, (int)apply);
        Marshal.ThrowExceptionForHR(hr);
    }

    public void SetRolloffFactor(float factor, Ds3dApply apply)
    {
        int hr = _comImpl->SetRolloffFactor(_comPtr, factor, (int)apply);
        Marshal.ThrowExceptionForHR(hr);
    }

    public void SetVelocity(float x, float y, float z, Ds3dApply apply)
    {
        int hr = _comImpl->SetVelocity(_comPtr, x, y, z, (int)apply);
        Marshal.ThrowExceptionForHR(hr);
    }

    public void CommitDeferredSettings()
    {
        int hr = _comImpl->CommitDeferredSettings(_comPtr);
        Marshal.ThrowExceptionForHR(hr);
    }
}
