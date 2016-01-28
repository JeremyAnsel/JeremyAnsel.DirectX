// <copyright file="DxgiPresentOptions.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    using System;

    /// <summary>
    /// Options for presenting frames to the output.
    /// </summary>
    [Flags]
    public enum DxgiPresentOptions
    {
        /// <summary>
        /// Present a frame from each buffer (starting with the current buffer) to the output.
        /// </summary>
        None,

        /// <summary>
        /// Do not present the frame to the output. The status of the swap chain will be tested and appropriate errors returned. <value>Test</value> is intended for use only when switching from the idle state; do not use it to determine when to switch to the idle state because doing so can leave the swap chain unable to exit full-screen mode.
        /// </summary>
        Test = 1 << 0,

        /// <summary>
        /// Present a frame from the current buffer to the output. Use this flag so that the presentation can use vertical-blank synchronization instead of sequencing buffers in the chain in the usual manner.
        /// </summary>
        DoNotSequence = 1 << 1,

        /// <summary>
        /// Specifies that the runtime will discard outstanding queued presents.
        /// </summary>
        Restart = 1 << 2,

        /// <summary>
        /// Specifies that the runtime will fail the presentation with the <value>DXGI_ERROR_WAS_STILL_DRAWING</value> error code if the calling thread is blocked; the runtime returns <value>DXGI_ERROR_WAS_STILL_DRAWING</value> instead of sleeping until the dependency is resolved.
        /// </summary>
        DoNotWait = 1 << 3,

        /// <summary>
        /// Indicates that if the stereo present must be reduced to mono, right-eye viewing is used rather than left-eye viewing.
        /// </summary>
        StereoPreferRight = 1 << 4,

        /// <summary>
        /// Indicates that the presentation should use the left buffer as a mono buffer.
        /// </summary>
        StereoTemporaryMono = 1 << 5,

        /// <summary>
        /// Indicates that presentation content will be shown only on the particular output. The content will not be visible on other outputs. For example, if the user tries to relocate video content on another output, the video content will not be visible.
        /// </summary>
        RestrictToOutput = 1 << 6,

        /// <summary>
        /// Must be set by media apps that are currently using a custom present duration (custom refresh rate).
        /// </summary>
        UseDuration = 1 << 8
    }
}
