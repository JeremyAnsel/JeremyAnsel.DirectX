// <copyright file="DxgiDeviceSubObject.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Inherited from objects that are tied to the device so that they can retrieve a pointer to it.
    /// </summary>
    public abstract class DxgiDeviceSubObject : DxgiObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DxgiDeviceSubObject"/> class.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal DxgiDeviceSubObject()
        {
        }
    }
}
