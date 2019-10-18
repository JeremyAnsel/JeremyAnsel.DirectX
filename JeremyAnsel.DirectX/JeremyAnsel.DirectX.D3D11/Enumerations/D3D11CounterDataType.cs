// <copyright file="D3D11CounterDataType.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

using System.Diagnostics.CodeAnalysis;

namespace JeremyAnsel.DirectX.D3D11
{
    /// <summary>
    /// Data type of a performance counter.
    /// </summary>
    [SuppressMessage("Naming", "CA1720:L'identificateur contient le nom de type", Justification = "Reviewed.")]
    public enum D3D11CounterDataType
    {
        /// <summary>
        /// 32-bit floating point.
        /// </summary>
        Float32,

        /// <summary>
        /// 16-bit unsigned integer.
        /// </summary>
        UInt16,

        /// <summary>
        /// 32-bit unsigned integer.
        /// </summary>
        UInt32,

        /// <summary>
        /// 64-bit unsigned integer.
        /// </summary>
        UInt64,
    }
}
