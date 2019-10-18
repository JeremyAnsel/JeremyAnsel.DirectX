// <copyright file="DWriteScriptShape.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite
{
    /// <summary>
    /// Indicates additional shaping requirements for text.
    /// </summary>
    public enum DWriteScriptShape
    {
        /// <summary>
        /// No additional shaping requirement. Text is shaped with the writing system default behavior.
        /// </summary>
        Default = 0,

        /// <summary>
        /// Text should leave no visual on display i.e. control or format control characters.
        /// </summary>
        NoVisual = 1
    }
}
