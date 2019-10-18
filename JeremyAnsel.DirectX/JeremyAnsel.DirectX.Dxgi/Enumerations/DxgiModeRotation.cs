// <copyright file="DxgiModeRotation.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    /// <summary>
    /// Indicate how the back buffers should be rotated to fit the physical rotation of a monitor.
    /// </summary>
    public enum DxgiModeRotation
    {
        /// <summary>
        /// Unspecified rotation.
        /// </summary>
        Unspecified,

        /// <summary>
        /// Specifies no rotation.
        /// </summary>
        Identity,

        /// <summary>
        /// Specifies 90 degrees of rotation.
        /// </summary>
        Rotate90,

        /// <summary>
        /// Specifies 180 degrees of rotation.
        /// </summary>
        Rotate180,

        /// <summary>
        /// Specifies 270 degrees of rotation.
        /// </summary>
        Rotate270
    }
}
