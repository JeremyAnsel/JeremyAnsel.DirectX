using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.DirectSound;

[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class DirectSoundBuffer : DXComObject
{
    private readonly nint _comPtr;
    private readonly IDirectSoundBuffer* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="DirectSoundBuffer"/> class.
    /// </summary>
    public DirectSoundBuffer(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IDirectSoundBuffer**)comPtr;
    }

    public DsBufferCaps GetCaps()
    {
        DsBufferCaps caps = default;
        caps.dwSize = sizeof(DsBufferCaps);
        int hr = _comImpl->GetCaps(_comPtr, &caps);
        Marshal.ThrowExceptionForHR(hr);
        return caps;
    }

    public void GetCurrentPosition(out int currentPlayCursor, out int currentWriteCurso)
    {
        int play;
        int write;
        int hr = _comImpl->GetCurrentPosition(_comPtr, &play, &write);
        Marshal.ThrowExceptionForHR(hr);
        currentPlayCursor = play;
        currentWriteCurso = write;
    }

    public DsWaveFormatEx GetFormat()
    {
        DsWaveFormatEx format;
        int hr = _comImpl->GetFormat(_comPtr, &format, sizeof(DsWaveFormatEx), null);
        Marshal.ThrowExceptionForHR(hr);
        return format;
    }

    public int GetVolume()
    {
        int volume;
        int hr = _comImpl->GetVolume(_comPtr, &volume);
        Marshal.ThrowExceptionForHR(hr);
        return volume;
    }

    public int GetPan()
    {
        int pan;
        int hr = _comImpl->GetPan(_comPtr, &pan);
        Marshal.ThrowExceptionForHR(hr);
        return pan;
    }

    public int GetFrequency()
    {
        int frequency;
        int hr = _comImpl->GetFrequency(_comPtr, &frequency);
        Marshal.ThrowExceptionForHR(hr);
        return frequency;
    }

    public DsBufferStatus GetStatus()
    {
        int value;
        int hr = _comImpl->GetStatus(_comPtr, &value);
        Marshal.ThrowExceptionForHR(hr);
        return (DsBufferStatus)value;
    }

    public void Lock(int dwWriteCursor, int dwWriteBytes, nint* lplpvAudioPtr1, int* lpdwAudioBytes1, nint* lplpvAudioPtr2, int* lpdwAudioBytes2, DsBufferLock flags)
    {
        int hr = _comImpl->Lock(_comPtr, dwWriteCursor, dwWriteBytes, lplpvAudioPtr1, lpdwAudioBytes1, lplpvAudioPtr2, lpdwAudioBytes2, (int)flags);
        Marshal.ThrowExceptionForHR(hr);
    }

    public void Play(DsBufferPlayOptions options)
    {
        int hr = _comImpl->Play(_comPtr, 0, 0, (int)options);
        Marshal.ThrowExceptionForHR(hr);
    }

    public void SetCurrentPosition(int position)
    {
        int hr = _comImpl->SetCurrentPosition(_comPtr, position);
        Marshal.ThrowExceptionForHR(hr);
    }

    public void SetFormat(in DsWaveFormatEx waveFormat)
    {
        DsWaveFormatEx format = waveFormat;
        int hr = _comImpl->SetFormat(_comPtr, &format);
        Marshal.ThrowExceptionForHR(hr);
    }

    public void SetVolume(int volume)
    {
        int hr = _comImpl->SetVolume(_comPtr, volume);
        Marshal.ThrowExceptionForHR(hr);
    }

    public void SetPan(int pan)
    {
        int hr = _comImpl->SetPan(_comPtr, pan);
        Marshal.ThrowExceptionForHR(hr);
    }

    public void SetFrequency(int frequency)
    {
        int hr = _comImpl->SetFrequency(_comPtr, frequency);
        Marshal.ThrowExceptionForHR(hr);
    }

    public void Stop()
    {
        int hr = _comImpl->Stop(_comPtr);
        Marshal.ThrowExceptionForHR(hr);
    }

    public void Unlock(nint lplpvAudioPtr1, int lpdwAudioBytes1, nint lplpvAudioPtr2, int lpdwAudioBytes2)
    {
        int hr = _comImpl->Unlock(_comPtr, lplpvAudioPtr1, lpdwAudioBytes1, lplpvAudioPtr2, lpdwAudioBytes2);
        Marshal.ThrowExceptionForHR(hr);

    }

    public void Restore()
    {
        int hr = _comImpl->Restore(_comPtr);
        Marshal.ThrowExceptionForHR(hr);
    }

    public void ResetPlaying()
    {
        Stop();
        SetCurrentPosition(0);
    }

    public DirectSound3DListener Create3DListener()
    {
        nint ptr = QueryInterface(DirectSound3DListener.IID_IDirectSound3DListener);
        return new DirectSound3DListener(ptr);
    }

    public DirectSound3DBuffer Create3DBuffer()
    {
        nint ptr = QueryInterface(DirectSound3DBuffer.IID_IDirectSound3DBuffer);
        return new DirectSound3DBuffer(ptr);
    }

    public void UpdateBuffer(int position, byte[] bytes)
    {
        UpdateBuffer(position, bytes.AsSpan());
    }

    public void UpdateBuffer(int position, ReadOnlySpan<byte> bytes)
    {
        position = (position * GetFormat().nBlockAlign) % GetCaps().dwBufferBytes;
        nint ptr1;
        int count1;
        nint ptr2;
        int count2;
        Lock(position, bytes.Length, &ptr1, &count1, &ptr2, &count2, DsBufferLock.None);
        bytes.CopyTo(new Span<byte>((void*)ptr1, count1));
        Unlock(ptr1, count1, ptr2, count2);
    }
}
