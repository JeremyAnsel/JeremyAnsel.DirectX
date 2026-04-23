// <copyright file="IWicPixelFormatInfo.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec.ComInterfaces;

/// <remarks>Inherited from <see cref="IWicComponentInfo"/></remarks>
[Guid("E8EDA601-3D48-431a-AB44-69059BE88BBE")]
internal unsafe readonly struct IWicPixelFormatInfo
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
}
