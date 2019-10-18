// <copyright file="DWriteBreakCondition.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite
{
    /// <summary>
    /// Condition at the edges of inline object or text used to determine
    /// line-breaking behavior.
    /// </summary>
    public enum DWriteBreakCondition
    {
        /// <summary>
        /// Whether a break is allowed is determined by the condition of the
        /// neighboring text span or inline object.
        /// </summary>
        Neutral,

        /// <summary>
        /// A break is allowed, unless overruled by the condition of the
        /// neighboring text span or inline object, either prohibited by a
        /// May Not or forced by a Must.
        /// </summary>
        CanBreak,

        /// <summary>
        /// There should be no break, unless overruled by a Must condition from
        /// the neighboring text span or inline object.
        /// </summary>
        MayNotBreak,

        /// <summary>
        /// The break must happen, regardless of the condition of the adjacent
        /// text span or inline object.
        /// </summary>
        MustBreak
    }
}
