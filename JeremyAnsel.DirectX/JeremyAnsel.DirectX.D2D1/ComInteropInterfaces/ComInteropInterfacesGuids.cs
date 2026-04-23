// <copyright file="ComInteropInterfacesGuids.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1.ComInteropInterfaces;

internal static class ComInteropInterfacesGuids
{
    /// <summary>
    /// WIC Bitmap cache interface
    /// </summary>
    public static readonly Guid WICBitmapGuid = new("00000121-a8f2-4877-ba0a-fd2b6645fb94");

    /// <summary>
    /// Source bitmap/imaging functionality
    /// </summary>
    public static readonly Guid WICBitmapSourceGuid = new("00000120-a8f2-4877-ba0a-fd2b6645fb94");
}
