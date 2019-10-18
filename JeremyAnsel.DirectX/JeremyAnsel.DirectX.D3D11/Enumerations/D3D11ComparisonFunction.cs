// <copyright file="D3D11ComparisonFunction.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    /// <summary>
    /// Comparison options.
    /// </summary>
    public enum D3D11ComparisonFunction
    {
        /// <summary>
        /// No value.
        /// </summary>
        None = 0,

        /// <summary>
        /// Never pass the comparison.
        /// </summary>
        Never = 1,

        /// <summary>
        /// If the source data is less than the destination data, the comparison passes.
        /// </summary>
        Less = 2,

        /// <summary>
        /// If the source data is equal to the destination data, the comparison passes.
        /// </summary>
        Equal = 3,

        /// <summary>
        /// If the source data is less than or equal to the destination data, the comparison passes.
        /// </summary>
        LessEqual = 4,

        /// <summary>
        /// If the source data is greater than the destination data, the comparison passes.
        /// </summary>
        Greater = 5,

        /// <summary>
        /// If the source data is not equal to the destination data, the comparison passes.
        /// </summary>
        NotEqual = 6,

        /// <summary>
        /// If the source data is greater than or equal to the destination data, the comparison passes.
        /// </summary>
        GreaterEqual = 7,

        /// <summary>
        /// Always pass the comparison.
        /// </summary>
        Always = 8
    }
}
