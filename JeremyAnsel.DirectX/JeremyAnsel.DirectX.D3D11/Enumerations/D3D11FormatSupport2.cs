// <copyright file="D3D11FormatSupport2.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;

    /// <summary>
    /// Unordered resource support options for a compute shader resource.
    /// </summary>
    [Flags]
    public enum D3D11FormatSupport2
    {
        /// <summary>
        /// No value.
        /// </summary>
        None = 0,

        /// <summary>
        /// Format supports atomic add.
        /// </summary>
        UavAtomicAdd = 0x00000001,

        /// <summary>
        /// Format supports atomic bitwise operations.
        /// </summary>
        UavAtomicBitwiseOperations = 0x00000002,

        /// <summary>
        /// Format supports atomic compare with store or exchange.
        /// </summary>
        UavAtomicCompareStoreOrCompareExchange = 0x00000004,

        /// <summary>
        /// Format supports atomic exchange.
        /// </summary>
        UavAtomicExchange = 0x00000008,

        /// <summary>
        /// Format supports atomic min and max.
        /// </summary>
        UavAtomicSignedMinOrMax = 0x00000010,

        /// <summary>
        /// Format supports atomic unsigned min and max.
        /// </summary>
        UavAtomicUnsignedMinOrMax = 0x00000020,

        /// <summary>
        /// Format supports a typed load.
        /// </summary>
        UavTypedLoad = 0x00000040,

        /// <summary>
        /// Format supports a typed store.
        /// </summary>
        UavTypedStore = 0x00000080,

        /// <summary>
        /// Format supports logic operations in blend state.
        /// </summary>
        OutputMergerLogicOperation = 0x00000100,

        /// <summary>
        /// Format supports tiled resources.
        /// </summary>
        Tiled = 0x00000200,

        /// <summary>
        /// Format supports shareable resources.
        /// </summary>
        Shareable = 0x00000400,
    }
}
