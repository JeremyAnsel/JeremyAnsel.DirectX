// <copyright file="DxgiWindowAssociationOptions.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    using System;

    /// <summary>
    /// Options for window association.
    /// </summary>
    [Flags]
    public enum DxgiWindowAssociationOptions
    {
        /// <summary>
        /// No option.
        /// </summary>
        None,

        /// <summary>
        /// Prevent DXGI from monitoring an applications message queue; this makes DXGI unable to respond to mode changes.
        /// </summary>
        NoWindowChanges = 1 << 0,

        /// <summary>
        /// Prevent DXGI from responding to an alt-enter sequence.
        /// </summary>
        NoAltEnter = 1 << 1,

        /// <summary>
        /// Prevent DXGI from responding to a print-screen key.
        /// </summary>
        NoPrintScreen = 1 << 2
    }
}
