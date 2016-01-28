// <copyright file="XMSelection.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DXMath
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Constants used to construct a control vector used with <see cref="XMVector.Select"/>.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1028:EnumStorageShouldBeInt32", Justification = "Reviewed")]
    public enum XMSelection : uint
    {
        /// <summary>
        /// Indicates that the component of the first of the vector arguments is to be copied to the index location in a result vector corresponding to its index in the control vector.
        /// </summary>
        Select0 = 0x00000000U,

        /// <summary>
        /// Indicates that the component of the second of the vector arguments is to be copied to the index location in a result vector corresponding to its index in the control vector.
        /// </summary>
        Select1 = 0xFFFFFFFFU
    }
}
