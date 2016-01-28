// <copyright file="DxgiSwapEffect.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    /// <summary>
    /// Options for handling pixels in a display surface.
    /// </summary>
    public enum DxgiSwapEffect
    {
        /// <summary>
        /// Use this flag to specify the bit-block transfer model and to specify that DXGI discard the contents of the back buffer. This flag is valid for a swap chain with more than one back buffer, although, applications only have read and write access to buffer 0. Use this flag to enable the display driver to select the most efficient presentation technique for the swap chain.
        /// </summary>
        Discard = 0,

        /// <summary>
        /// Use this flag to specify the bit-block transfer model and to specify that DXGI persist the contents of the back buffer. Use this option to present the contents of the swap chain in order, from the first buffer (buffer 0) to the last buffer. This flag cannot be used with multisampling.
        /// </summary>
        Sequential = 1,

        /// <summary>
        /// Use this flag to specify the flip presentation model and to specify that DXGI persist the contents of the back buffer. This flag cannot be used with multisampling.
        /// </summary>
        FlipSequential = 3
    }
}
