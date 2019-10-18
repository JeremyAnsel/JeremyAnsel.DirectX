// <copyright file="DxgiSwapChainOptions.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    using System;

    /// <summary>
    /// Options for swap-chain behavior.
    /// </summary>
    [Flags]
    public enum DxgiSwapChainOptions
    {
        /// <summary>
        /// No option.
        /// </summary>
        None,

        /// <summary>
        /// Set this flag to turn off automatic image rotation; that is, do not perform a rotation when transferring the contents of the front buffer to the monitor. Use this flag to avoid a bandwidth penalty when an application expects to handle rotation. This option is valid only during full-screen mode.
        /// </summary>
        NonPrerotated = 1 << 0,

        /// <summary>
        /// Set this flag to enable an application to switch modes. When switching from windowed to full-screen mode, the display mode (or monitor resolution) will be changed to match the dimensions of the application window.
        /// </summary>
        AllowModeSwitch = 1 << 1,

        /// <summary>
        /// Set this flag to enable an application to render using GDI on a swap chain or a surface.
        /// </summary>
        GdiCompatible = 1 << 2,

        /// <summary>
        /// Set this flag to indicate that the swap chain might contain protected content; therefore, the operating system supports the creation of the swap chain only when driver and hardware protection is used. If the driver and hardware do not support content protection, the call to create a resource for the swap chain fails.
        /// </summary>
        RestrictedContent = 1 << 3,

        /// <summary>
        /// Set this flag to indicate that shared resources that are created within the swap chain must be protected by using the driver’s mechanism for restricting access to shared surfaces.
        /// </summary>
        RestrictSharedResourceDriver = 1 << 4,

        /// <summary>
        /// Set this flag to restrict presented content to the local displays. Therefore, the presented content is not accessible via remote accessing or through the desktop duplication APIs.
        /// This flag supports the window content protection features of Windows. Applications can use this flag to protect their own onscreen window content from being captured or copied through a specific set of public operating system features and APIs.
        /// </summary>
        DisplayOnly = 1 << 5,

        /// <summary>
        /// Set this flag to create a waitable object you can use to ensure rendering does not begin while a frame is still being presented.
        /// </summary>
        FrameLatencyWaitableObject = 1 << 6,

        /// <summary>
        /// Set this flag to create a swap chain in the foreground layer for multi-plane rendering.
        /// </summary>
        ForegroundLayer = 1 << 7,

        /// <summary>
        /// Full screen video.
        /// </summary>
        FullscreenVideo = 1 << 8
    }
}
