// <copyright file="D2D1PathSegmentOptions.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System;

    /// <summary>
    /// Indicates whether a segment should be stroked and whether the join between this segment and the previous one should be smooth.
    /// </summary>
    [Flags]
    public enum D2D1PathSegmentOptions
    {
        /// <summary>
        /// The segment is joined as specified by the <see cref="D2D1StrokeStyle"/> interface, and it is stroked.
        /// </summary>
        None = 0x00000000,

        /// <summary>
        /// The segment is not stroked.
        /// </summary>
        ForceUnstroked = 0x00000001,

        /// <summary>
        /// The segment is always joined with the one preceding it using a round line join.
        /// </summary>
        ForceRoundLineJoin = 0x00000002,
    }
}
