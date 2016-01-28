// <copyright file="D2D1DebugLevel.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    /// <summary>
    /// Indicates the type of information provided by the Direct2D Debug Layer.
    /// </summary>
    public enum D2D1DebugLevel
    {
        /// <summary>
        /// Direct2D does not produce any debugging output.
        /// </summary>
        None = 0,

        /// <summary>
        /// Direct2D sends error messages to the debug layer.
        /// </summary>
        Error = 1,

        /// <summary>
        /// Direct2D sends error messages and warnings to the debug layer.
        /// </summary>
        Warning = 2,

        /// <summary>
        /// Direct2D sends error messages, warnings, and additional diagnostic information that can help improve performance to the debug layer.
        /// </summary>
        Information = 3,
    }
}
