// <copyright file="XMSwizzle.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DXMath
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Constants used as an element index with <see cref="XMVector.Swizzle(XMSwizzle,XMSwizzle,XMSwizzle,XMSwizzle)"/>.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1028:EnumStorageShouldBeInt32", Justification = "Reviewed")]
    public enum XMSwizzle : uint
    {
        /// <summary>
        /// Indicates that the X component of the vector argument is to be copied to the index location in a result vector corresponding to the specified element.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "X", Justification = "Reviewed")]
        X = 0,

        /// <summary>
        /// Indicates that the Y component of the vector argument is to be copied to the index location in a result vector corresponding to the specified element.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Y", Justification = "Reviewed")]
        Y = 1,

        /// <summary>
        /// Indicates that the Z component of the vector argument is to be copied to the index location in a result vector corresponding to the specified element.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Z", Justification = "Reviewed")]
        Z = 2,

        /// <summary>
        /// Indicates that the W component of the vector argument is to be copied to the index location in a result vector corresponding to the specified element.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "W", Justification = "Reviewed")]
        W = 3
    }
}
