// <copyright file="DxgiCreateFactoryOptions.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    using System;

    /// <summary>
    /// Options for factory creation.
    /// </summary>
    [Flags]
    public enum DxgiCreateFactoryOptions
    {
        /// <summary>
        /// No option.
        /// </summary>
        None = 0,

        /// <summary>
        /// Debug factory.
        /// </summary>
        Debug = 1
    }
}
