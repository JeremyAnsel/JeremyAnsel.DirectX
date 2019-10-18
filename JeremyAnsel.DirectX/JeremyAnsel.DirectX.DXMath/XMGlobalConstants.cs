// <copyright file="XMGlobalConstants.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DXMath
{
    /// <summary>
    /// Internal constants.
    /// </summary>
    internal static class XMGlobalConstants
    {
        /// <summary>
        /// The identity r0 vector.
        /// </summary>
        public static readonly XMVector IdentityR0 = XMVector.FromFloat(1.0f, 0.0f, 0.0f, 0.0f);

        /// <summary>
        /// The identity r1 vector.
        /// </summary>
        public static readonly XMVector IdentityR1 = XMVector.FromFloat(0.0f, 1.0f, 0.0f, 0.0f);

        /// <summary>
        /// The identity r2 vector.
        /// </summary>
        public static readonly XMVector IdentityR2 = XMVector.FromFloat(0.0f, 0.0f, 1.0f, 0.0f);

        /// <summary>
        /// The identity r3 vector.
        /// </summary>
        public static readonly XMVector IdentityR3 = XMVector.FromFloat(0.0f, 0.0f, 0.0f, 1.0f);

        /// <summary>
        /// The tan est coefficients.
        /// </summary>
        public static readonly XMVector TanEstCoefficients = XMVector.FromFloat(2.484f, -1.954923183e-1f, 2.467401101f, XMMath.OneDivPI);

        /// <summary>
        /// The negative zero vector.
        /// </summary>
        public static readonly XMVector NegativeZero = XMVector.FromInt(0x80000000U, 0x80000000U, 0x80000000U, 0x80000000U);

        /// <summary>
        /// The one vector.
        /// </summary>
        public static readonly XMVector One = XMVector.FromFloat(1.0f, 1.0f, 1.0f, 1.0f);

        /// <summary>
        /// The zero vector.
        /// </summary>
        public static readonly XMVector Zero = XMVector.FromFloat(0.0f, 0.0f, 0.0f, 0.0f);

        /// <summary>
        /// The two vector.
        /// </summary>
        public static readonly XMVector Two = XMVector.FromFloat(2.0f, 2.0f, 2.0f, 2.0f);

        /// <summary>
        /// The four vector.
        /// </summary>
        public static readonly XMVector Four = XMVector.FromFloat(4.0f, 4.0f, 4.0f, 4.0f);

        /// <summary>
        /// The six vector.
        /// </summary>
        public static readonly XMVector Six = XMVector.FromFloat(6.0f, 6.0f, 6.0f, 6.0f);

        /// <summary>
        /// The negative one vector.
        /// </summary>
        public static readonly XMVector NegativeOne = XMVector.FromFloat(-1.0f, -1.0f, -1.0f, -1.0f);

        /// <summary>
        /// The one half vector.
        /// </summary>
        public static readonly XMVector OneHalf = XMVector.FromFloat(0.5f, 0.5f, 0.5f, 0.5f);

        /// <summary>
        /// The negative two pi vector.
        /// </summary>
        public static readonly XMVector NegativeTwoPI = XMVector.FromFloat(-XMMath.TwoPI, -XMMath.TwoPI, -XMMath.TwoPI, -XMMath.TwoPI);

        /// <summary>
        /// The negative pi vector.
        /// </summary>
        public static readonly XMVector NegativePI = XMVector.FromFloat(-XMMath.PI, -XMMath.PI, -XMMath.PI, -XMMath.PI);

        /// <summary>
        /// The pi vector.
        /// </summary>
        public static readonly XMVector PI = XMVector.FromFloat(XMMath.PI, XMMath.PI, XMMath.PI, XMMath.PI);

        /// <summary>
        /// The two pi vector.
        /// </summary>
        public static readonly XMVector TwoPI = XMVector.FromFloat(XMMath.TwoPI, XMMath.TwoPI, XMMath.TwoPI, XMMath.TwoPI);

        /// <summary>
        /// The reciprocal twi pi vector.
        /// </summary>
        public static readonly XMVector ReciprocalTwoPI = XMVector.FromFloat(XMMath.OneDivTwoPI, XMMath.OneDivTwoPI, XMMath.OneDivTwoPI, XMMath.OneDivTwoPI);

        /// <summary>
        /// the epsilon vector.
        /// </summary>
        public static readonly XMVector Epsilon = XMVector.FromFloat(1.192092896e-7f, 1.192092896e-7f, 1.192092896e-7f, 1.192092896e-7f);

        /// <summary>
        /// The infinity vector.
        /// </summary>
        public static readonly XMVector Infinity = XMVector.FromInt(0x7F800000, 0x7F800000, 0x7F800000, 0x7F800000);

        /// <summary>
        /// The QNaN vector.
        /// </summary>
        public static readonly XMVector QNaN = XMVector.FromInt(0x7FC00000, 0x7FC00000, 0x7FC00000, 0x7FC00000);

        /// <summary>
        /// The select 1000 vector.
        /// </summary>
        public static readonly XMVector Select1000 = XMVector.FromInt((uint)XMSelection.Select1, (uint)XMSelection.Select0, (uint)XMSelection.Select0, (uint)XMSelection.Select0);

        /// <summary>
        /// The select 1100 vector.
        /// </summary>
        public static readonly XMVector Select1100 = XMVector.FromInt((uint)XMSelection.Select1, (uint)XMSelection.Select1, (uint)XMSelection.Select0, (uint)XMSelection.Select0);

        /// <summary>
        /// The select 1110 vector.
        /// </summary>
        public static readonly XMVector Select1110 = XMVector.FromInt((uint)XMSelection.Select1, (uint)XMSelection.Select1, (uint)XMSelection.Select1, (uint)XMSelection.Select0);

        /// <summary>
        /// The select 1011 vector.
        /// </summary>
        public static readonly XMVector Select1011 = XMVector.FromInt((uint)XMSelection.Select1, (uint)XMSelection.Select0, (uint)XMSelection.Select1, (uint)XMSelection.Select1);

        /// <summary>
        /// The msrgb scale.
        /// </summary>
        public static readonly XMVector MsrgbScale = XMVector.FromFloat(12.92f, 12.92f, 12.92f, 1.0f);

        /// <summary>
        /// The msrgb A.
        /// </summary>
        public static readonly XMVector MsrgbA = XMVector.FromFloat(0.055f, 0.055f, 0.055f, 0.0f);

        /// <summary>
        /// The msrgb A1.
        /// </summary>
        public static readonly XMVector MsrgbA1 = XMVector.FromFloat(1.055f, 1.055f, 1.055f, 1.0f);

        /// <summary>
        /// Thee UByte max.
        /// </summary>
        public static readonly XMVector UByteMax = XMVector.FromFloat(255.0f, 255.0f, 255.0f, 255.0f);

        /// <summary>
        /// The Byte min.
        /// </summary>
        public static readonly XMVector ByteMin = XMVector.FromFloat(-127.0f, -127.0f, -127.0f, -127.0f);

        /// <summary>
        /// The Byte max.
        /// </summary>
        public static readonly XMVector ByteMax = XMVector.FromFloat(127.0f, 127.0f, 127.0f, 127.0f);

        /// <summary>
        /// the Shirt min.
        /// </summary>
        public static readonly XMVector ShortMin = XMVector.FromFloat(-32767.0f, -32767.0f, -32767.0f, -32767.0f);

        /// <summary>
        /// The Short max.
        /// </summary>
        public static readonly XMVector ShortMax = XMVector.FromFloat(32767.0f, 32767.0f, 32767.0f, 32767.0f);

        /// <summary>
        /// The UShort max.
        /// </summary>
        public static readonly XMVector UShortMax = XMVector.FromFloat(65535.0f, 65535.0f, 65535.0f, 65535.0f);
    }
}
