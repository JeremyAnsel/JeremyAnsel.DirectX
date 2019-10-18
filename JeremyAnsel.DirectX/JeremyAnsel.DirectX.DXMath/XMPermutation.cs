// <copyright file="XMPermutation.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DXMath
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Constants used as an element index with <see cref="XMVector.Permute"/>.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1028:EnumStorageShouldBeInt32", Justification = "Reviewed")]
    public enum XMPermutation : uint
    {
        /// <summary>
        /// indicates that the X component of the first of the vector arguments is to be copied to the index location in a result vector corresponding to the specified element.
        /// </summary>
        Permute0X = 0,

        /// <summary>
        /// This indicates that the Y component of the first of the vector arguments is to be copied to the index location in a result vector corresponding to the specified element.
        /// </summary>
        Permute0Y = 1,

        /// <summary>
        /// This indicates that the Z component of the first of the vector arguments is to be copied to the index location in a result vector corresponding to the specified element.
        /// </summary>
        Permute0Z = 2,

        /// <summary>
        /// This indicates that the W component of the first of the vector arguments is to be copied to the index location in a result vector corresponding to the specified element.
        /// </summary>
        Permute0W = 3,

        /// <summary>
        /// This indicates that the X component of the second of the vector arguments is to be copied to the index location in a result vector corresponding to the specified element.
        /// </summary>
        Permute1X = 4,

        /// <summary>
        /// This indicates that the Y component of the second of the vector arguments is to be copied to the index location in a result vector corresponding to the specified element.
        /// </summary>
        Permute1Y = 5,

        /// <summary>
        /// This indicates that the Z component of the second of the vector arguments is to be copied to the index location in a result vector corresponding to the specified element.
        /// </summary>
        Permute1Z = 6,

        /// <summary>
        /// This indicates that the W component of the second of the vector arguments is to be copied to the index location in a result vector corresponding to the specified element.
        /// </summary>
        Permute1W = 7
    }
}
