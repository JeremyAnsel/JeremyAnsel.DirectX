// <copyright file="DxgiScaling.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    /// <summary>
    /// Identifies resize behavior when the back-buffer size does not match the size of the target output.
    /// </summary>
    public enum DxgiScaling
    {
        /// <summary>
        /// Directs DXGI to make the back-buffer contents scale to fit the presentation target size.
        /// </summary>
        Stretch,

        /// <summary>
        /// Directs DXGI to make the back-buffer contents appear without any scaling when the presentation target size is not equal to the back-buffer size. The top edges of the back buffer and presentation target are aligned together.
        /// </summary>
        None,
        
        /// <summary>
        /// DXGI to make the back-buffer contents scale to fit the presentation target size, while preserving the aspect ratio of the back-buffer. If the scaled back-buffer does not fill the presentation area, it will be centered with black borders.
        /// </summary>
        AspectRatioStretch
    }
}
