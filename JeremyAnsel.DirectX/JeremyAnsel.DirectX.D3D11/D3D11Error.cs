// <copyright file="D3D11Error.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    /// <summary>
    /// D3D11 error codes.
    /// </summary>
    public static class D3D11Error
    {
        /// <summary>
        /// The application has exceeded the maximum number of unique state objects per Direct3D device.
        /// The limit is 4096 for feature levels up to 11.1.
        /// </summary>
        public const int TooManyUniqueStateObjects = unchecked((int)0x887C0001L);

        /// <summary>
        /// The specified file was not found.
        /// </summary>
        public const int FileNotFound = unchecked((int)0x887C0002L);

        /// <summary>
        /// The application has exceeded the maximum number of unique view objects per Direct3D device.
        /// The limit is 2^20 for feature levels up to 11.1.
        /// </summary>
        public const int TooManyUniqueViewObjects = unchecked((int)0x887C0003L);

        /// <summary>
        /// The application's first call per command list to Map on a deferred context did not use D3D11_MAP_WRITE_DISCARD.
        /// </summary>
        public const int DeferredContextMapWithoutInitialDiscard = unchecked((int)0x887C0004L);
    }
}
