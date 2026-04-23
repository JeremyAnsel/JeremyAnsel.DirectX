// <copyright file="IWicBitmapCodecInfo.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec.ComInterfaces;

/// <remarks>Inherited from <see cref="IWicComponentInfo"/></remarks>
[Guid("E87A44C4-B76E-4c47-8B09-298EB12A2714")]
internal unsafe readonly struct IWicBitmapCodecInfo
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
    private readonly nint GetComponentType;
    private readonly nint GetCLSID;
    private readonly nint GetSigningStatus;
    private readonly nint GetAuthor;
    private readonly nint GetVendorGUID;
    private readonly nint GetVersion;
    private readonly nint GetSpecVersion;
    private readonly nint GetFriendlyName;

    public readonly delegate* unmanaged[Stdcall]<nint, Guid*, int> GetContainerFormat;

    public readonly delegate* unmanaged[Stdcall]<nint, uint, Guid*, uint*, int> GetPixelFormats;

    public readonly delegate* unmanaged[Stdcall]<nint, uint, char*, uint*, int> GetColorManagementVersion;

    public readonly delegate* unmanaged[Stdcall]<nint, uint, char*, uint*, int> GetDeviceManufacturer;

    public readonly delegate* unmanaged[Stdcall]<nint, uint, char*, uint*, int> GetDeviceModels;

    public readonly delegate* unmanaged[Stdcall]<nint, uint, char*, uint*, int> GetMimeTypes;

    public readonly delegate* unmanaged[Stdcall]<nint, uint, char*, uint*, int> GetFileExtensions;

    public readonly delegate* unmanaged[Stdcall]<nint, int*, int> DoesSupportAnimation;

    public readonly delegate* unmanaged[Stdcall]<nint, int*, int> DoesSupportChromakey;

    public readonly delegate* unmanaged[Stdcall]<nint, int*, int> DoesSupportLossless;

    public readonly delegate* unmanaged[Stdcall]<nint, int*, int> DoesSupportMultiframe;

    public readonly delegate* unmanaged[Stdcall]<nint, char*, int*, int> MatchesMimeType;
}
