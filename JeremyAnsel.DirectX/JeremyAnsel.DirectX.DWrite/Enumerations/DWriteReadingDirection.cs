// <copyright file="DWriteReadingDirection.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite
{
    /// <summary>
    /// Direction for how reading progresses.
    /// </summary>
    public enum DWriteReadingDirection
    {
        /// <summary>
        /// Reading progresses from left to right.
        /// </summary>
        LeftToRight = 0,

        /// <summary>
        /// Reading progresses from right to left.
        /// </summary>
        RightToLeft = 1,

        /// <summary>
        /// Reading progresses from top to bottom.
        /// </summary>
        TopToBottom = 2,

        /// <summary>
        /// Reading progresses from bottom to top.
        /// </summary>
        BottomToTop = 3,
    }
}
