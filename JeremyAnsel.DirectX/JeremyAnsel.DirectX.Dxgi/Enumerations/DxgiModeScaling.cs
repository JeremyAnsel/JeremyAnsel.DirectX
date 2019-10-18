// <copyright file="DxgiModeScaling.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    /// <summary>
    /// Indicate how an image is stretched to fit a given monitor's resolution.
    /// </summary>
    public enum DxgiModeScaling
    {
        /// <summary>
        /// Unspecified scaling.
        /// </summary>
        Unspecified,

        /// <summary>
        /// Specifies no scaling. The image is centered on the display.
        /// </summary>
        Centered,

        /// <summary>
        /// Specifies stretched scaling.
        /// </summary>
        Stretched
    }
}
