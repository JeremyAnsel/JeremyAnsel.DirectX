// <copyright file="IWicPixelFormatInfo2.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec.ComInterfaces;

/// <remarks>Inherited from <see cref="IWicPixelFormatInfo"/></remarks>
[Guid("A9DB33A2-AF5F-43C7-B679-74F5984B5AA4")]
internal unsafe readonly struct IWicPixelFormatInfo2
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

    public readonly delegate* unmanaged[Stdcall]<nint, Guid*, int> GetFormatGUID;

    public readonly delegate* unmanaged[Stdcall]<nint, nint*, int> GetColorContext;

    public readonly delegate* unmanaged[Stdcall]<nint, uint*, int> GetBitsPerPixel;

    public readonly delegate* unmanaged[Stdcall]<nint, uint*, int> GetChannelCount;

    public readonly delegate* unmanaged[Stdcall]<nint, int> GetChannelMask;

    public readonly delegate* unmanaged[Stdcall]<nint, int*, int> SupportsTransparency;

    public readonly delegate* unmanaged[Stdcall]<nint, WicPixelFormatNumericRepresentation*, int> GetNumericRepresentation;
}
