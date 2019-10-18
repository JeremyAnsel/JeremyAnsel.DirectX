// <copyright file="D3D10Error.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D10
{
    /// <summary>
    /// D3D10 error codes.
    /// </summary>
    public static class D3D10Error
    {
        /// <summary>
        /// The application has exceeded the maximum number of unique state objects per Direct3D device.
        /// The limit is 4096 for feature levels up to 11.1.
        /// </summary>
        public const int TooManyUniqueStateObjects = unchecked((int)0x88790001L);

        /// <summary>
        /// The specified file was not found.
        /// </summary>
        public const int FileNotFound = unchecked((int)0x88790002L);
    }
}
