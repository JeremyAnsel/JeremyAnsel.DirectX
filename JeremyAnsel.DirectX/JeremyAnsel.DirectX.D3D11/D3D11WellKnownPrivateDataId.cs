// <copyright file="D3D11WellKnownPrivateDataId.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;

    /// <summary>
    /// Well-Known Private Data IDs
    /// </summary>
    public static class D3D11WellKnownPrivateDataId
    {
        /// <summary>
        /// Provides a unique name to objects in order to assist the developer during debugging.
        /// </summary>
        public static readonly Guid DebugObjectName = new Guid(0x429b8c22, 0x9188, 0x4b0c, 0x87, 0x42, 0xac, 0xb0, 0xbf, 0x85, 0xc2, 0x00);
    }
}
