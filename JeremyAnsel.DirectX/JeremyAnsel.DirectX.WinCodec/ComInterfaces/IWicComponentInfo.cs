// <copyright file="IWicComponentInfo.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec.ComInterfaces;

[Guid("23BC3F0A-698B-4357-886B-F24D50671334")]
internal unsafe readonly struct IWicComponentInfo
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;

    public readonly delegate* unmanaged[Stdcall]<nint, WicComponentType*, int> GetComponentType;

    public readonly delegate* unmanaged[Stdcall]<nint, Guid*, int> GetCLSID;

    public readonly delegate* unmanaged[Stdcall]<nint, WicComponentSigning*, int> GetSigningStatus;

    public readonly delegate* unmanaged[Stdcall]<nint, uint, char*, uint*, int> GetAuthor;

    public readonly delegate* unmanaged[Stdcall]<nint, Guid*, int> GetVendorGUID;

    public readonly delegate* unmanaged[Stdcall]<nint, uint, char*, uint*, int> GetVersion;

    public readonly delegate* unmanaged[Stdcall]<nint, uint, char*, uint*, int> GetSpecVersion;

    public readonly delegate* unmanaged[Stdcall]<nint, uint, char*, uint*, int> GetFriendlyName;
}
