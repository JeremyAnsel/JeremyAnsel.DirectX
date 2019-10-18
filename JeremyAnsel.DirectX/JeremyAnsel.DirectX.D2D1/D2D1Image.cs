// <copyright file="D2D1Image.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Represents a producer of pixels that can fill an arbitrary 2D plane.
    /// </summary>
    public abstract class D2D1Image : D2D1Resource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1Image"/> class.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D2D1Image()
        {
        }
    }
}
