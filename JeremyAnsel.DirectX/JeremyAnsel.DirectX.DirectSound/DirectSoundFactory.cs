using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.DirectSound;

[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class DirectSoundFactory : DXComObject
{
    private readonly nint _comPtr;
    private readonly IDirectSound* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="DirectSoundFactory"/> class.
    /// </summary>
    public DirectSoundFactory(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IDirectSound**)comPtr;
    }

    public static DirectSoundFactory Create()
    {
        nint ptr;
        int hr = NativeMethods.DirectSoundCreate(0, &ptr, 0);
        Marshal.ThrowExceptionForHR(hr);
        return new DirectSoundFactory(ptr);
    }

    public static DirectSoundFactory Create(nint hwnd, DsCooperativeLevel level)
    {
        DirectSoundFactory factory = Create();
        factory.SetCooperativeLevel(hwnd, level);
        return factory;
    }

    public DirectSoundBuffer CreateSoundBuffer(in DsBufferDesc bufferDesc)
    {
        nint ptr;
        DsBufferDesc desc = bufferDesc;
        desc.dwSize = sizeof(DsBufferDesc);
        int hr = _comImpl->CreateSoundBuffer(_comPtr, &desc, &ptr, 0);
        Marshal.ThrowExceptionForHR(hr);
        return new DirectSoundBuffer(ptr);
    }

    public DirectSoundBuffer CreateSoundBuffer(in DsBufferDesc bufferDesc, in DsWaveFormatEx wfxFormat)
    {
        nint ptr;
        DsWaveFormatEx format = wfxFormat;
        DsBufferDesc desc = bufferDesc;
        desc.dwSize = sizeof(DsBufferDesc);
        desc.lpwfxFormat = (nint)(void*)&format;
        int hr = _comImpl->CreateSoundBuffer(_comPtr, &desc, &ptr, 0);
        Marshal.ThrowExceptionForHR(hr);
        return new DirectSoundBuffer(ptr);
    }

    public DsCaps GetCaps()
    {
        DsCaps caps = default;
        caps.dwSize = sizeof(DsCaps);
        int hr = _comImpl->GetCaps(_comPtr, &caps);
        Marshal.ThrowExceptionForHR(hr);
        return caps;
    }

    public DirectSoundBuffer DuplicateSoundBuffer(DirectSoundBuffer buffer)
    {
        nint ptr;
        int hr = _comImpl->DuplicateSoundBuffer(_comPtr, buffer.Handle, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new DirectSoundBuffer(ptr);
    }

    public void SetCooperativeLevel(nint hwnd, DsCooperativeLevel level)
    {
        int hr = _comImpl->SetCooperativeLevel(_comPtr, hwnd, (int)level);
        Marshal.ThrowExceptionForHR(hr);
    }

    public void Compact()
    {
        int hr = _comImpl->Compact(_comPtr);
        Marshal.ThrowExceptionForHR(hr);
    }

    public (DsSpeakerConfig speakerConfig, DsSpeakerGeometryConfig speakerGeometryConfig) GetSpeakerConfig()
    {
        int value;
        int hr = _comImpl->GetSpeakerConfig(_comPtr, &value);
        Marshal.ThrowExceptionForHR(hr);
        DsSpeakerConfig config = (DsSpeakerConfig)(value & 0xff);
        DsSpeakerGeometryConfig geometry = (DsSpeakerGeometryConfig)((value >> 16) & 0xff);
        return (config, geometry);
    }

    public void SetSpeakerConfig(DsSpeakerConfig speakerConfig, DsSpeakerGeometryConfig speakerGeometryConfig)
    {
        int value = (byte)speakerConfig | ((byte)speakerGeometryConfig) >> 16;
        int hr = _comImpl->SetSpeakerConfig(_comPtr, value);
        Marshal.ThrowExceptionForHR(hr);
    }

    public DirectSoundBuffer CreatePrimaryBuffer(short nChannels, int nSamplesPerSec, short wBitsPerSample)
    {
        return CreatePrimaryBuffer(DsBufferCapsFlags.None, nChannels, nSamplesPerSec, wBitsPerSample);
    }

    public DirectSoundBuffer CreatePrimaryBuffer(DsBufferCapsFlags flags, short nChannels, int nSamplesPerSec, short wBitsPerSample)
    {
        DsBufferDesc dsbdesc = new()
        {
            dwFlags = DsBufferCapsFlags.PrimaryBuffer | flags
        };

        DirectSoundBuffer primary = CreateSoundBuffer(dsbdesc);

        DsWaveFormatEx wfx = default;
        wfx.wFormatTag = 1;
        wfx.nChannels = nChannels;
        wfx.nSamplesPerSec = nSamplesPerSec;
        wfx.wBitsPerSample = wBitsPerSample;
        wfx.nBlockAlign = (short)(wfx.wBitsPerSample / 8 * wfx.nChannels);
        wfx.nAvgBytesPerSec = wfx.nSamplesPerSec * wfx.nBlockAlign;
        primary.SetFormat(wfx);

        return primary;
    }

    public DirectSoundBuffer CreateSoundBuffer(DsBufferCapsFlags flags, int dwBufferBytes, short nChannels, int nSamplesPerSec, short wBitsPerSample)
    {
        DsBufferDesc dsbdesc = new()
        {
            dwFlags = flags,
            dwBufferBytes = dwBufferBytes,
        };

        DsWaveFormatEx wfx = default;
        wfx.wFormatTag = 1;
        wfx.nChannels = nChannels;
        wfx.nSamplesPerSec = nSamplesPerSec;
        wfx.wBitsPerSample = wBitsPerSample;
        wfx.nBlockAlign = (short)(wfx.wBitsPerSample / 8 * wfx.nChannels);
        wfx.nAvgBytesPerSec = wfx.nSamplesPerSec * wfx.nBlockAlign;

        DirectSoundBuffer buffer = CreateSoundBuffer(dsbdesc, wfx);
        return buffer;
    }

    public DirectSoundBuffer CreateSoundBufferFromWaveFile(DsBufferCapsFlags flags, string filename)
    {
        DsWaveFile wav = DsWaveFile.FromFile(filename);

        DirectSoundBuffer sound = CreateSoundBuffer(
            flags,
            wav.Data.Length,
            (short)wav.Channels,
            wav.SampleRate,
            (short)wav.BitsPerSample);

        nint ptr1;
        int count1;
        nint ptr2;
        int count2;
        sound.Lock(0, wav.Data.Length, &ptr1, &count1, &ptr2, &count2, DsBufferLock.None);
        Marshal.Copy(wav.Data, 0, ptr1, wav.Data.Length);
        sound.Unlock(ptr1, count1, ptr2, count2);

        return sound;
    }

    public DirectSoundBuffer CreateSoundBufferFromWaveFile(DsBufferCapsFlags flags, Stream stream)
    {
        DsWaveFile wav = DsWaveFile.FromStream(stream);

        DirectSoundBuffer sound = CreateSoundBuffer(
            flags,
            wav.Data.Length,
            (short)wav.Channels,
            wav.SampleRate,
            (short)wav.BitsPerSample);

        nint ptr1;
        int count1;
        nint ptr2;
        int count2;
        sound.Lock(0, wav.Data.Length, &ptr1, &count1, &ptr2, &count2, DsBufferLock.None);
        Marshal.Copy(wav.Data, 0, ptr1, wav.Data.Length);
        sound.Unlock(ptr1, count1, ptr2, count2);

        return sound;
    }
}
