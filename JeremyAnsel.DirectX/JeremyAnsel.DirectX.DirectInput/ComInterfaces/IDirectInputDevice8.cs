// <copyright file="IDirectInputDevice8.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DirectInput;

internal delegate int LPDIENUMDEVICEOBJECTSCALLBACK(nint lpddoi, nint pvRef);

internal delegate int LPDIENUMEFFECTSCALLBACK(nint pdei, nint pvRef);

internal delegate int LPDIENUMCREATEDEFFECTOBJECTSCALLBACK(nint peff, nint pvRef);

[Guid(DirectInputGuids.IDirectInputDevice8WString)]
internal unsafe readonly struct IDirectInputDevice8
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;

    public readonly delegate* unmanaged[Stdcall]<nint, void*, int> GetCapabilities;

    public readonly delegate* unmanaged[Stdcall]<nint, LPDIENUMDEVICEOBJECTSCALLBACK, nint, uint, int> EnumObjects;

    public readonly delegate* unmanaged[Stdcall]<nint, nint, void*, int> GetProperty;

    public readonly delegate* unmanaged[Stdcall]<nint, nint, void*, int> SetProperty;

    public readonly delegate* unmanaged[Stdcall]<nint, int> Acquire;

    public readonly delegate* unmanaged[Stdcall]<nint, int> Unacquire;

    public readonly delegate* unmanaged[Stdcall]<nint, int, void*, int> GetDeviceState;

    public readonly delegate* unmanaged[Stdcall]<nint, int, void*, int*, uint, int> GetDeviceData;

    public readonly delegate* unmanaged[Stdcall]<nint, nint, int> SetDataFormat;

    public readonly delegate* unmanaged[Stdcall]<nint, nint, int> SetEventNotification;

    public readonly delegate* unmanaged[Stdcall]<nint, nint, uint, int> SetCooperativeLevel;

    public readonly delegate* unmanaged[Stdcall]<nint, void*, uint, uint, int> GetObjectInfo;

    public readonly delegate* unmanaged[Stdcall]<nint, void*, int> GetDeviceInfo;

    public readonly delegate* unmanaged[Stdcall]<nint, nint, int, int> RunControlPanel;

    public readonly delegate* unmanaged[Stdcall]<nint, int> Initialize;

    public readonly delegate* unmanaged[Stdcall]<nint, in Guid, nint, nint*, nint, int> CreateEffect;

    public readonly delegate* unmanaged[Stdcall]<nint, LPDIENUMEFFECTSCALLBACK, nint, uint, int> EnumEffects;

    public readonly delegate* unmanaged[Stdcall]<nint, void*, in Guid, int> GetEffectInfo;

    public readonly delegate* unmanaged[Stdcall]<nint, uint*, int> GetForceFeedbackState;

    public readonly delegate* unmanaged[Stdcall]<nint, uint, int> SendForceFeedbackCommand;

    public readonly delegate* unmanaged[Stdcall]<nint, LPDIENUMCREATEDEFFECTOBJECTSCALLBACK, nint, int, int> EnumCreatedEffectObjects;

    public readonly delegate* unmanaged[Stdcall]<nint, void*, int> Escape;

    public readonly delegate* unmanaged[Stdcall]<nint, int> Poll;

    public readonly delegate* unmanaged[Stdcall]<nint, int> SendDeviceData;

    public readonly delegate* unmanaged[Stdcall]<nint, int> EnumEffectsInFile;

    public readonly delegate* unmanaged[Stdcall]<nint, int> WriteEffectToFile;

    public readonly delegate* unmanaged[Stdcall]<nint, int> BuildActionMap;

    public readonly delegate* unmanaged[Stdcall]<nint, int> SetActionMap;

    public readonly delegate* unmanaged[Stdcall]<nint, int> GetImageInfo;
}
