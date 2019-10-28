// <copyright file="D3DDisassembleOptions.cs" company="Jérémy Ansel">
// Copyright (c) 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3DCompiler
{
    using System;

    /// <summary>
    /// Flags affecting the behavior of <c>D3DDisassemble</c>.
    /// </summary>
    [Flags]
    public enum D3DDisassembleOptions
    {
        /// <summary>
        /// No option.
        /// </summary>
        None = 0,

        /// <summary>
        /// Enable the output of color codes.
        /// </summary>
        EnableColorCode = 1 << 0,

        /// <summary>
        /// Enable the output of default values.
        /// </summary>
        EnableDefaultValuePrints = 1 << 1,

        /// <summary>
        /// Enable instruction numbering.
        /// </summary>
        EnableInstructionNumbering = 1 << 2,

        /// <summary>
        /// No effect.
        /// </summary>
        EnableInstructionCycle = 1 << 3,

        /// <summary>
        /// Disable debug information.
        /// </summary>
        DisableDebugInfo = 1 << 4,

        /// <summary>
        /// Enable instruction offsets.
        /// </summary>
        EnableInstructionOffset = 1 << 5,

        /// <summary>
        /// Disassemble instructions only.
        /// </summary>
        InstructionOnly = 1 << 6,

        /// <summary>
        /// Use hex symbols in disassemblies.
        /// </summary>
        PrintHexLiterals = 1 << 7
    }
}
