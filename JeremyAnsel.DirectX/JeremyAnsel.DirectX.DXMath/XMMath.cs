// <copyright file="XMMath.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DXMath
{
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Constants and functions provided by XMMath.
    /// </summary>
    public static class XMMath
    {
        /// <summary>
        /// An optimal representation of π.
        /// </summary>
        public const float PI = 3.141592654f;

        /// <summary>
        /// An optimal representation of 2*π.
        /// </summary>
        public const float TwoPI = 6.283185307f;

        /// <summary>
        /// An optimal representation of 1/π.
        /// </summary>
        public const float OneDivPI = 0.318309886f;

        /// <summary>
        /// An optimal representation of 2/π.
        /// </summary>
        public const float OneDivTwoPI = 0.159154943f;

        /// <summary>
        /// An optimal representation of π/2.
        /// </summary>
        public const float PIDivTwo = 1.570796327f;

        /// <summary>
        /// An optimal representation of π/4.
        /// </summary>
        public const float PIDivFour = 0.785398163f;

        /// <summary>
        /// Converts an angle measured in degrees into one measured in radians.
        /// </summary>
        /// <param name="degrees">Size of an angle in degrees.</param>
        /// <returns>Size of the angle in radians.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ConvertToRadians(float degrees)
        {
            return degrees * (XMMath.PI / 180.0f);
        }

        /// <summary>
        /// Converts an angle measured in radians into one measured in degrees.
        /// </summary>
        /// <param name="radians">Size of an angle in radians.</param>
        /// <returns>Size of the angle in degrees.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ConvertToDegrees(float radians)
        {
            return radians * (180.0f / XMMath.PI);
        }

        /// <summary>
        /// Calculates the Fresnel term for unpolarized light.
        /// </summary>
        /// <param name="cosIncidentAngle">Vector consisting of the cosines of the incident angles.</param>
        /// <param name="refractionIndex">Vector consisting of the refraction indices of the materials corresponding to the incident angles.</param>
        /// <returns>Returns a vector containing the Fresnel term of each component.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector FresnelTerm(XMVector cosIncidentAngle, XMVector refractionIndex)
        {
            Debug.Assert(!XMVector4.IsInfinite(cosIncidentAngle), "Reviewed");

            //// Result = 0.5f * (g - c)^2 / (g + c)^2 * ((c * (g + c) - 1)^2 / (c * (g - c) + 1)^2 + 1) where
            //// c = CosIncidentAngle
            //// g = sqrt(c^2 + RefractionIndex^2 - 1)

            XMVector g = XMVector.MultiplyAdd(refractionIndex, refractionIndex, XMGlobalConstants.NegativeOne);
            g = XMVector.MultiplyAdd(cosIncidentAngle, cosIncidentAngle, g);
            g = g.Abs().Sqrt();

            XMVector s = XMVector.Add(g, cosIncidentAngle);
            XMVector d = XMVector.Subtract(g, cosIncidentAngle);

            XMVector v0 = XMVector.Multiply(d, d);
            XMVector v1 = XMVector.Multiply(s, s).Reciprocal();
            v0 = XMVector.Multiply(XMGlobalConstants.OneHalf, v0);
            v0 = XMVector.Multiply(v0, v1);

            XMVector v2 = XMVector.MultiplyAdd(cosIncidentAngle, s, XMGlobalConstants.NegativeOne);
            XMVector v3 = XMVector.MultiplyAdd(cosIncidentAngle, d, XMGlobalConstants.One);
            v2 = XMVector.Multiply(v2, v2);
            v3 = XMVector.Multiply(v3, v3);
            v3 = v3.Reciprocal();
            v2 = XMVector.MultiplyAdd(v2, v3, XMGlobalConstants.One);

            return XMVector.Multiply(v0, v2).Saturate();
        }
    }
}
