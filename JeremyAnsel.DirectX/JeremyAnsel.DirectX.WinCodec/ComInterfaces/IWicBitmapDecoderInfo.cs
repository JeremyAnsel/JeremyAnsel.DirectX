// <copyright file="IWicBitmapDecoderInfo.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec.ComInterfaces;

/// <remarks>Inherited from <see cref="IWicBitmapCodecInfo"/></remarks>
[Guid("D8CD007F-D08F-4191-9BFC-236EA7F0E4B5")]
internal unsafe readonly struct IWicBitmapDecoderInfo
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
    private readonly nint GetContainerFormat;
    private readonly nint GetPixelFormats;
    private readonly nint GetColorManagementVersion;
    private readonly nint GetDeviceManufacturer;
    private readonly nint GetDeviceModels;
    private readonly nint GetMimeTypes;
    private readonly nint GetFileExtensions;
    private readonly nint DoesSupportAnimation;
    private readonly nint DoesSupportChromakey;
    private readonly nint DoesSupportLossless;
    private readonly nint DoesSupportMultiframe;
    private readonly nint MatchesMimeType;

    public readonly delegate* unmanaged[Stdcall]<nint, int> GetPatterns;

    public readonly delegate* unmanaged[Stdcall]<nint, int> Remote_GetPatterns;

    public readonly delegate* unmanaged[Stdcall]<nint, nint, int*, int> MatchesPattern;

    public readonly delegate* unmanaged[Stdcall]<nint, nint*, int> CreateInstance;
}
