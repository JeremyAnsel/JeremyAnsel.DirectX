// <copyright file="IWicFormatConverterInfo.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec.ComInterfaces;

/// <remarks>Inherited from <see cref="IWicComponentInfo"/></remarks>
[Guid("9F34FB65-13F4-4f15-BC57-3726B5E53D9F")]
internal unsafe readonly struct IWicFormatConverterInfo
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

    public readonly delegate* unmanaged[Stdcall]<nint, uint, WicPixelFormatGuid*, uint*, int> GetPixelFormats;

    public readonly delegate* unmanaged[Stdcall]<nint, nint*, int> CreateInstance;
}
