// <copyright file="D2D1GeometrySimplificationOption.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    /// <summary>
    /// Specifies how simple the output of a simplified geometry sink should be.
    /// </summary>
    public enum D2D1GeometrySimplificationOption
    {
        /// <summary>
        /// The output can contain cubic Bezier curves and line segments.
        /// </summary>
        CubicsAndLines = 0,

        /// <summary>
        /// The output is flattened so that it contains only line segments.
        /// </summary>
        Lines = 1,
    }
}
