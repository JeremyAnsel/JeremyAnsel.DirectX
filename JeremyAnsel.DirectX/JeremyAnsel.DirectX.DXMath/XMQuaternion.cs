// <copyright file="XMQuaternion.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DXMath
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// The quaternion functions provided by DirectXMath.
    /// </summary>
    public static class XMQuaternion
    {
        /// <summary>
        /// Gets the identity quaternion.
        /// </summary>
        public static XMVector Identity
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return XMGlobalConstants.IdentityR3;
            }
        }

        /// <summary>
        /// Tests whether two quaternions are equal.
        /// </summary>
        /// <param name="q1">The first quaternion to test.</param>
        /// <param name="q2">The second quaternion to test.</param>
        /// <returns>Returns true if the quaternions are equal and false otherwise.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Equal(XMVector q1, XMVector q2)
        {
            return XMVector4.Equal(q1, q2);
        }

        /// <summary>
        /// Tests whether two quaternions are not equal.
        /// </summary>
        /// <param name="q1">The first quaternion to test.</param>
        /// <param name="q2">The second quaternion to test.</param>
        /// <returns>Returns true if the quaternions are unequal and false otherwise.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NotEqual(XMVector q1, XMVector q2)
        {
            return XMVector4.NotEqual(q1, q2);
        }

        /// <summary>
        /// Test whether any component of a quaternion is a NaN.
        /// </summary>
        /// <param name="q">The quaternion to test.</param>
        /// <returns>Returns true if any component of Q is a NaN, and false otherwise.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "q", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNaN(XMVector q)
        {
            return XMVector4.IsNaN(q);
        }

        /// <summary>
        /// Test whether any component of a quaternion is either positive or negative infinity.
        /// </summary>
        /// <param name="q">The quaternion to test.</param>
        /// <returns>Returns true if any component of Q is positive or negative infinity,and false otherwise.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "q", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsInfinite(XMVector q)
        {
            return XMVector4.IsInfinite(q);
        }

        /// <summary>
        /// Tests whether a specific quaternion is the identity quaternion.
        /// </summary>
        /// <param name="q">The quaternion to test.</param>
        /// <returns>Returns true if Q is the identity quaternion, or false otherwise.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "q", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsIdentity(XMVector q)
        {
            return XMVector4.Equal(q, XMGlobalConstants.IdentityR3);
        }

        /// <summary>
        /// Computes the dot product of two quaternions.
        /// </summary>
        /// <param name="q1">The first quaternion.</param>
        /// <param name="q2">The second quaternion.</param>
        /// <returns>Returns a vector. The dot product between Q1 and Q2 is replicated into each component.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Dot(XMVector q1, XMVector q2)
        {
            return XMVector4.Dot(q1, q2);
        }

        /// <summary>
        /// Computes the product of two quaternions.
        /// </summary>
        /// <param name="q1">The first quaternion.</param>
        /// <param name="q2">The second quaternion.</param>
        /// <returns>Returns the product of the two quaternions.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Multiply(XMVector q1, XMVector q2)
        {
            //// Returns the product Q2*Q1 (which is the concatenation of a rotation Q1 followed by the rotation Q2)

            //// [ (Q2.w * Q1.x) + (Q2.x * Q1.w) + (Q2.y * Q1.z) - (Q2.z * Q1.y),
            ////   (Q2.w * Q1.y) - (Q2.x * Q1.z) + (Q2.y * Q1.w) + (Q2.z * Q1.x),
            ////   (Q2.w * Q1.z) + (Q2.x * Q1.y) - (Q2.y * Q1.x) + (Q2.z * Q1.w),
            ////   (Q2.w * Q1.w) - (Q2.x * Q1.x) - (Q2.y * Q1.y) - (Q2.z * Q1.z) ]

            return new XMVector(
                (q2.W * q1.X) + (q2.X * q1.W) + (q2.Y * q1.Z) - (q2.Z * q1.Y),
                (q2.W * q1.Y) - (q2.X * q1.Z) + (q2.Y * q1.W) + (q2.Z * q1.X),
                (q2.W * q1.Z) + (q2.X * q1.Y) - (q2.Y * q1.X) + (q2.Z * q1.W),
                (q2.W * q1.W) - (q2.X * q1.X) - (q2.Y * q1.Y) - (q2.Z * q1.Z));
        }

        /// <summary>
        /// Computes the square of the magnitude of a quaternion.
        /// </summary>
        /// <param name="q">The quaternion to measure.</param>
        /// <returns>Returns a vector. The square of the magnitude is replicated into each component.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "q", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector LengthSquare(XMVector q)
        {
            return XMVector4.LengthSquare(q);
        }

        /// <summary>
        /// Computes the reciprocal of the magnitude of a quaternion.
        /// </summary>
        /// <param name="q">The quaternion to measure.</param>
        /// <returns>Returns the reciprocal of the magnitude of Q.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "q", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector ReciprocalLength(XMVector q)
        {
            return XMVector4.ReciprocalLength(q);
        }

        /// <summary>
        /// Computes the magnitude of a quaternion.
        /// </summary>
        /// <param name="q">The quaternion to measure.</param>
        /// <returns>Returns a vector. The magnitude of Q is replicated into each component.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "q", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Length(XMVector q)
        {
            return XMVector4.Length(q);
        }

        /// <summary>
        /// Estimates the normalized version of a quaternion.
        /// </summary>
        /// <param name="q">The quaternion.</param>
        /// <returns>The estimate of the normalized version of a quaternion.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "q", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector NormalizeEst(XMVector q)
        {
            return XMVector4.NormalizeEst(q);
        }

        /// <summary>
        /// Normalizes a quaternion.
        /// </summary>
        /// <param name="q">The quaternion.</param>
        /// <returns>The normalized form of the quaternion.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "q", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Normalize(XMVector q)
        {
            return XMVector4.Normalize(q);
        }

        /// <summary>
        /// Computes the conjugate of a quaternion.
        /// </summary>
        /// <param name="q">The quaternion to conjugate.</param>
        /// <returns>The conjugate of the quaternion.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "q", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Conjugate(XMVector q)
        {
            return new XMVector(-q.X, -q.Y, -q.Z, q.W);
        }

        /// <summary>
        /// Computes the inverse of a quaternion.
        /// </summary>
        /// <param name="q">The quaternion to invert.</param>
        /// <returns>The inverse of Q.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "q", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Inverse(XMVector q)
        {
            XMVector zero = XMVector.Zero;

            XMVector l = XMVector4.LengthSquare(q);
            XMVector conjugate = XMQuaternion.Conjugate(q);

            XMVector control = XMVector.LessOrEqual(l, XMGlobalConstants.Epsilon);

            XMVector result = XMVector.Divide(conjugate, l);
            result = XMVector.Select(result, zero, control);

            return result;
        }

        /// <summary>
        /// Computes the natural logarithm of a given unit quaternion.
        /// </summary>
        /// <param name="q">Unit quaternion for which to calculate the natural logarithm. If Q is not a unit quaternion, the returned value is undefined.</param>
        /// <returns>The natural logarithm of Q.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Ln", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "q", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Ln(XMVector q)
        {
            XMVector oneMinusEpsilon = XMVector.FromFloat(1.0f - 0.00001f, 1.0f - 0.00001f, 1.0f - 0.00001f, 1.0f - 0.00001f);

            XMVector qw = XMVector.SplatW(q);
            XMVector q0 = XMVector.Select(XMGlobalConstants.Select1110, q, XMGlobalConstants.Select1110);
            XMVector controlW = qw.InBounds(oneMinusEpsilon);

            XMVector theta = qw.ACos();
            XMVector sinTheta = theta.Sin();

            XMVector s = XMVector.Divide(theta, sinTheta);

            XMVector result = XMVector.Multiply(q0, s);
            result = XMVector.Select(q0, result, controlW);

            return result;
        }

        /// <summary>
        /// Computes the exponential of a given pure quaternion.
        /// </summary>
        /// <param name="q">Pure quaternion for which to compute the exponential. The w-component of the input quaternion is ignored in the calculation.</param>
        /// <returns>Returns the exponential of Q.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "q", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Exp(XMVector q)
        {
            XMVector theta = XMVector3.Length(q);

            theta.SinCos(out XMVector sinTheta, out XMVector cosTheta);

            XMVector s = XMVector.Divide(sinTheta, theta);
            XMVector result = XMVector.Multiply(q, s);

            XMVector zero = XMVector.Zero;
            XMVector control = XMVector.NearEqual(theta, zero, XMGlobalConstants.Epsilon);
            result = XMVector.Select(result, q, control);
            result = XMVector.Select(cosTheta, result, XMGlobalConstants.Select1110);

            return result;
        }

        /// <summary>
        /// Interpolates between two unit quaternions, using spherical linear interpolation.
        /// </summary>
        /// <param name="q0">An unit quaternion to interpolate from.</param>
        /// <param name="q1">An unit quaternion to interpolate to.</param>
        /// <param name="t">The interpolation control factor.</param>
        /// <returns>Returns the interpolated quaternion. If Q0 and Q1 are not unit quaternions, the resulting interpolation is undefined.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "t", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Slerp(XMVector q0, XMVector q1, float t)
        {
            XMVector tV = XMVector.Replicate(t);
            return XMQuaternion.SlerpV(q0, q1, tV);
        }

        /// <summary>
        /// Interpolates between two unit quaternions, using spherical linear interpolation.
        /// </summary>
        /// <param name="q0">An unit quaternion to interpolate from.</param>
        /// <param name="q1">An unit quaternion to interpolate to.</param>
        /// <param name="t">The interpolation control factor. All components of this vector must be the same.</param>
        /// <returns>Returns the interpolated quaternion. If Q0 and Q1 are not unit quaternions, the resulting interpolation is undefined.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "t", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector SlerpV(XMVector q0, XMVector q1, XMVector t)
        {
            Debug.Assert(t.Y == t.X && t.Z == t.X && t.W == t.X, "Reviewed");

            //// Result = Q0 * sin((1.0 - t) * Omega) / sin(Omega) + Q1 * sin(t * Omega) / sin(Omega)

            XMVector oneMinusEpsilon = XMVector.FromFloat(1.0f - 0.00001f, 1.0f - 0.00001f, 1.0f - 0.00001f, 1.0f - 0.00001f);

            XMVector cosOmega = XMQuaternion.Dot(q0, q1);
            XMVector zero = XMVector.Zero;
            XMVector control = XMVector.Less(cosOmega, zero);
            XMVector sign = XMVector.Select(XMGlobalConstants.One, XMGlobalConstants.NegativeOne, control);

            cosOmega = XMVector.Multiply(cosOmega, sign);
            control = XMVector.Less(cosOmega, oneMinusEpsilon);

            XMVector sinOmega = XMVector
                .NegativeMultiplySubtract(cosOmega, cosOmega, XMGlobalConstants.One)
                .Sqrt();

            XMVector omega = XMVector.ATan2(sinOmega, cosOmega);

            XMVector signMask = XMVector.SignMask;
            XMVector v01 = XMVector.ShiftLeft(t, zero, 2);
            signMask = XMVector.ShiftLeft(signMask, zero, 3);
            v01 = XMVector.XorInt(v01, signMask);
            v01 = XMVector.Add(XMGlobalConstants.IdentityR0, v01);

            XMVector invSinOmega = sinOmega.Reciprocal();

            XMVector s0 = XMVector
                .Multiply(v01, omega)
                .Sin();
            s0 = XMVector.Multiply(s0, invSinOmega);
            s0 = XMVector.Select(v01, s0, control);

            XMVector s1 = XMVector.SplatY(s0);
            s0 = XMVector.SplatX(s0);
            s1 = XMVector.Multiply(s1, sign);

            XMVector result = XMVector.Multiply(q0, s0);
            result = XMVector.MultiplyAdd(q1, s1, result);

            return result;
        }

        /// <summary>
        /// Interpolates between four unit quaternions, using spherical quadrangle interpolation.
        /// </summary>
        /// <param name="q0">The first unit quaternion.</param>
        /// <param name="q1">The second unit quaternion.</param>
        /// <param name="q2">The third unit quaternion.</param>
        /// <param name="q3">The fourth unit quaternion.</param>
        /// <param name="t">The interpolation control factor.</param>
        /// <returns>Returns the interpolated quaternion. If Q0, Q1, Q2, and Q3 are not all unit quaternions, the returned quaternion is undefined.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "t", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Squad(XMVector q0, XMVector q1, XMVector q2, XMVector q3, float t)
        {
            XMVector tV = XMVector.Replicate(t);

            return XMQuaternion.SquadV(q0, q1, q2, q3, tV);
        }

        /// <summary>
        /// Interpolates between four unit quaternions, using spherical quadrangle interpolation.
        /// </summary>
        /// <param name="q0">The first unit quaternion.</param>
        /// <param name="q1">The second unit quaternion.</param>
        /// <param name="q2">The third unit quaternion.</param>
        /// <param name="q3">The fourth unit quaternion.</param>
        /// <param name="t">The interpolation control factor. All components of this vector must be the same.</param>
        /// <returns>Returns the interpolated quaternion. If Q0, Q1, Q2, and Q3 are not unit quaternions, the resulting interpolation is undefined.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "t", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector SquadV(XMVector q0, XMVector q1, XMVector q2, XMVector q3, XMVector t)
        {
            Debug.Assert(t.Y == t.X && t.Z == t.X && t.W == t.X, "Reviewed");

            XMVector tp = t;
            XMVector two = XMVector.FromSplatConstant(2, 0);

            XMVector q03 = XMQuaternion.SlerpV(q0, q3, t);
            XMVector q12 = XMQuaternion.SlerpV(q1, q2, t);

            tp = XMVector.NegativeMultiplySubtract(tp, tp, tp);
            tp = XMVector.Multiply(tp, two);

            return XMQuaternion.SlerpV(q03, q12, tp);
        }

        /// <summary>
        /// Provides addresses of setup control points for spherical quadrangle interpolation.
        /// </summary>
        /// <param name="a">The first setup quaternion.</param>
        /// <param name="b">The second setup quaternion.</param>
        /// <param name="c">The third setup quaternion.</param>
        /// <param name="q0">The first quaternion.</param>
        /// <param name="q1">The second quaternion.</param>
        /// <param name="q2">The third quaternion.</param>
        /// <param name="q3">The fourth quaternion.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "a", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "b", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "c", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "2#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SquadSetup(out XMVector a, out XMVector b, out XMVector c, XMVector q0, XMVector q1, XMVector q2, XMVector q3)
        {
            XMVector ls12 = XMQuaternion.LengthSquare(XMVector.Add(q1, q2));
            XMVector ld12 = XMQuaternion.LengthSquare(XMVector.Subtract(q1, q2));
            XMVector sq2 = q2.Negate();

            XMVector control1 = XMVector.Less(ls12, ld12);
            sq2 = XMVector.Select(q2, sq2, control1);

            XMVector ls01 = XMQuaternion.LengthSquare(XMVector.Add(q0, q1));
            XMVector ld01 = XMQuaternion.LengthSquare(XMVector.Subtract(q0, q1));
            XMVector sq0 = q0.Negate();

            XMVector ls23 = XMQuaternion.LengthSquare(XMVector.Add(sq2, q3));
            XMVector ld23 = XMQuaternion.LengthSquare(XMVector.Subtract(sq2, q3));
            XMVector sq3 = q3.Negate();

            XMVector control0 = XMVector.Less(ls01, ld01);
            XMVector control2 = XMVector.Less(ls23, ld23);

            sq0 = XMVector.Select(q0, sq0, control0);
            sq3 = XMVector.Select(q3, sq3, control2);

            XMVector invQ1 = XMQuaternion.Inverse(q1);
            XMVector invQ2 = XMQuaternion.Inverse(sq2);

            XMVector ln_q0 = XMQuaternion.Ln(XMQuaternion.Multiply(invQ1, sq0));
            XMVector ln_q2 = XMQuaternion.Ln(XMQuaternion.Multiply(invQ1, sq2));
            XMVector ln_q1 = XMQuaternion.Ln(XMQuaternion.Multiply(invQ2, q1));
            XMVector ln_q3 = XMQuaternion.Ln(XMQuaternion.Multiply(invQ2, sq3));

            XMVector negativeOneQuarter = XMVector.FromSplatConstant(-1, 2);

            XMVector expQ02 = XMVector.Multiply(XMVector.Add(ln_q0, ln_q2), negativeOneQuarter);
            XMVector expQ13 = XMVector.Multiply(XMVector.Add(ln_q1, ln_q3), negativeOneQuarter);
            expQ02 = XMQuaternion.Exp(expQ02);
            expQ13 = XMQuaternion.Exp(expQ13);

            a = XMQuaternion.Multiply(q1, expQ02);
            b = XMQuaternion.Multiply(sq2, expQ13);
            c = sq2;
        }

        /// <summary>
        /// Returns a point in barycentric coordinates, using the specified quaternions.
        /// </summary>
        /// <param name="q0">The first quaternion in the triangle.</param>
        /// <param name="q1">The second quaternion in the triangle.</param>
        /// <param name="q2">The third quaternion in the triangle.</param>
        /// <param name="f">The first weighting factor.</param>
        /// <param name="g">The second weighting factor.</param>
        /// <returns>Returns a quaternion in barycentric coordinates.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "f", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "g", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector BaryCentric(XMVector q0, XMVector q1, XMVector q2, float f, float g)
        {
            float s = f + g;

            XMVector result;

            if (s < 0.00001f && s > -0.00001f)
            {
                result = q0;
            }
            else
            {
                XMVector q01 = XMQuaternion.Slerp(q0, q1, s);
                XMVector q02 = XMQuaternion.Slerp(q0, q2, s);

                result = XMQuaternion.Slerp(q01, q02, g / s);
            }

            return result;
        }

        /// <summary>
        /// Returns a point in barycentric coordinates, using the specified quaternions.
        /// </summary>
        /// <param name="q0">The first quaternion in the triangle.</param>
        /// <param name="q1">The second quaternion in the triangle.</param>
        /// <param name="q2">The third quaternion in the triangle.</param>
        /// <param name="f">The first weighting factor. All components of this vector must be the same.</param>
        /// <param name="g">The second weighting factor. All components of this vector must be the same.</param>
        /// <returns>Returns a quaternion in barycentric coordinates.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "f", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "g", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector BaryCentricV(XMVector q0, XMVector q1, XMVector q2, XMVector f, XMVector g)
        {
            Debug.Assert(f.Y == f.X && f.Z == f.X && f.W == f.X, "Reviewed");
            Debug.Assert(g.Y == g.X && g.Z == g.X && g.W == g.X, "Reviewed");

            XMVector epsilon = XMVector.FromSplatConstant(1, 16);
            XMVector s = XMVector.Add(f, g);

            XMVector result;

            if (XMVector4.InBounds(s, epsilon))
            {
                result = q0;
            }
            else
            {
                XMVector q01 = XMQuaternion.SlerpV(q0, q1, s);
                XMVector q02 = XMQuaternion.SlerpV(q0, q2, s);
                XMVector gs = s.Reciprocal();
                gs = XMVector.Multiply(g, gs);

                result = XMQuaternion.SlerpV(q01, q02, gs);
            }

            return result;
        }

        /// <summary>
        /// Computes a rotation quaternion based on the pitch, yaw, and roll (Euler angles).
        /// </summary>
        /// <param name="pitch">Angle of rotation around the x-axis, in radians.</param>
        /// <param name="yaw">Angle of rotation around the y-axis, in radians.</param>
        /// <param name="roll">Angle of rotation around the z-axis, in radians.</param>
        /// <returns>Returns the rotation quaternion.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector RotationRollPitchYaw(float pitch, float yaw, float roll)
        {
            XMVector angles = new XMVector(pitch, yaw, roll, 0.0f);
            return XMQuaternion.RotationRollPitchYawFromVector(angles);
        }

        /// <summary>
        /// Computes a rotation quaternion based on a vector containing the Euler angles (pitch, yaw, and roll).
        /// </summary>
        /// <param name="angles">A 3D vector containing the Euler angles in the order pitch, yaw, roll.</param>
        /// <returns>Returns the rotation quaternion.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector RotationRollPitchYawFromVector(XMVector angles)
        {
            XMVector sign = XMVector.FromFloat(1.0f, -1.0f, -1.0f, 1.0f);
            XMVector halfAngles = XMVector.Multiply(angles, XMGlobalConstants.OneHalf);

            halfAngles.SinCos(out XMVector sinAngles, out XMVector cosAngles);

            XMVector p0 = new XMVector(sinAngles.X, cosAngles.X, cosAngles.X, cosAngles.X);
            XMVector y0 = new XMVector(cosAngles.Y, sinAngles.Y, cosAngles.Y, cosAngles.Y);
            XMVector r0 = new XMVector(cosAngles.Z, cosAngles.Z, sinAngles.Z, cosAngles.Z);
            XMVector p1 = new XMVector(cosAngles.X, sinAngles.X, sinAngles.X, sinAngles.X);
            XMVector y1 = new XMVector(sinAngles.Y, cosAngles.Y, sinAngles.Y, sinAngles.Y);
            XMVector r1 = new XMVector(sinAngles.Z, sinAngles.Z, cosAngles.Z, sinAngles.Z);

            XMVector q1 = XMVector.Multiply(p1, sign);
            XMVector q0 = XMVector.Multiply(p0, y0);
            q1 = XMVector.Multiply(q1, y1);
            q0 = XMVector.Multiply(q0, r0);

            return XMVector.MultiplyAdd(q1, r1, q0);
        }

        /// <summary>
        /// Computes rotation about y-axis (y), then x-axis (x), then z-axis (z).
        /// </summary>
        /// <param name="quaternion">A quaternion.</param>
        /// <returns>The Euler angles.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector ToEuler(XMVector quaternion)
        {
            float xx = quaternion.X * quaternion.X;
            float yy = quaternion.Y * quaternion.Y;
            float zz = quaternion.Z * quaternion.Z;

            float m31 = 2.0f * quaternion.X * quaternion.Z + 2.0f * quaternion.Y * quaternion.W;
            float m32 = 2.0f * quaternion.Y * quaternion.Z - 2.0f * quaternion.X * quaternion.W;
            float m33 = 1.0f - 2.0f * xx - 2.0f * yy;

            float cy = (float)Math.Sqrt(m33 * m33 + m31 * m31);
            float cx = (float)Math.Atan2(-m32, cy);

            if (cy > 0.00001f)
            {
                float m12 = 2.0f * quaternion.X * quaternion.Y + 2.0f * quaternion.Z * quaternion.W;
                float m22 = 1.0f - 2.0f * xx - 2.0f * zz;

                return new XMVector(cx, (float)Math.Atan2(m31, m33), (float)Math.Atan2(m12, m22), 0.0f);
            }
            else
            {
                float m11 = 1.0f - 2.0f * yy - 2.0f * zz;
                float m21 = 2.0f * quaternion.X * quaternion.Y - 2.0f * quaternion.Z * quaternion.W;

                return new XMVector(cx, 0.0f, (float)Math.Atan2(-m21, m11), 0.0f);
            }
        }

        /// <summary>
        /// Computes the rotation quaternion about a normal vector.
        /// </summary>
        /// <param name="normalAxis">Normal vector describing the axis of rotation.</param>
        /// <param name="angle">Angle of rotation in radians. Angles are measured clockwise when looking along the rotation axis toward the origin.</param>
        /// <returns>Returns the rotation quaternion.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector RotationNormal(XMVector normalAxis, float angle)
        {
            XMVector n = XMVector.Select(XMGlobalConstants.One, normalAxis, XMGlobalConstants.Select1110);

            XMScalar.SinCos(out float sinV, out float cosV, 0.5f * angle);

            XMVector scale = new XMVector(sinV, sinV, sinV, cosV);
            return XMVector.Multiply(n, scale);
        }

        /// <summary>
        /// Computes a rotation quaternion about an axis.
        /// </summary>
        /// <param name="axis">3D vector describing the axis of rotation.</param>
        /// <param name="angle">Angle of rotation in radians. Angles are measured clockwise when looking along the rotation axis toward the origin.</param>
        /// <returns>Returns the rotation quaternion.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector RotationAxis(XMVector axis, float angle)
        {
            Debug.Assert(!XMVector3.Equal(axis, XMGlobalConstants.Zero), "Reviewed");
            Debug.Assert(!XMVector3.IsInfinite(axis), "Reviewed");

            XMVector normal = XMVector3.Normalize(axis);
            return XMQuaternion.RotationNormal(normal, angle);
        }

        /// <summary>
        /// Computes a rotation quaternion from a rotation matrix.
        /// </summary>
        /// <param name="m">The rotation matrix.</param>
        /// <returns>Returns the rotation quaternion.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "m", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector RotationMatrix(XMMatrix m)
        {
            XMVector q;
            float r22 = m.M33;

            if (r22 <= 0.0f)
            {
                //// x^2 + y^2 >= z^2 + w^2

                float dif10 = m.M22 - m.M11;
                float omr22 = 1.0f - r22;

                if (dif10 <= 0.0f)
                {
                    //// x^2 >= y^2

                    float fourXSqr = omr22 - dif10;
                    float inv4x = 0.5f / (float)Math.Sqrt(fourXSqr);
                    q = new XMVector(
                        fourXSqr * inv4x,
                        (m.M12 + m.M21) * inv4x,
                        (m.M13 + m.M31) * inv4x,
                        (m.M23 - m.M32) * inv4x);
                }
                else
                {
                    //// y^2 >= x^2

                    float fourYSqr = omr22 + dif10;
                    float inv4y = 0.5f / (float)Math.Sqrt(fourYSqr);
                    q = new XMVector(
                        (m.M12 + m.M21) * inv4y,
                        fourYSqr * inv4y,
                        (m.M23 + m.M32) * inv4y,
                        (m.M31 - m.M13) * inv4y);
                }
            }
            else
            {
                //// z^2 + w^2 >= x^2 + y^2

                float sum10 = m.M22 + m.M11;
                float opr22 = 1.0f + r22;

                if (sum10 <= 0.0f)
                {
                    //// z^2 >= w^2

                    float fourZSqr = opr22 - sum10;
                    float inv4z = 0.5f / (float)Math.Sqrt(fourZSqr);
                    q = new XMVector(
                        (m.M13 + m.M31) * inv4z,
                        (m.M23 + m.M32) * inv4z,
                        fourZSqr * inv4z,
                        (m.M12 - m.M21) * inv4z);
                }
                else
                {
                    //// w^2 >= z^2

                    float fourWSqr = opr22 + sum10;
                    float inv4w = 0.5f / (float)Math.Sqrt(fourWSqr);
                    q = new XMVector(
                        (m.M23 - m.M32) * inv4w,
                        (m.M31 - m.M13) * inv4w,
                        (m.M12 - m.M21) * inv4w,
                        fourWSqr * inv4w);
                }
            }

            return q;
        }

        /// <summary>
        /// Computes an axis and angle of rotation about that axis for a given quaternion.
        /// </summary>
        /// <param name="axis">A 3D vector describing the axis of rotation for the quaternion Q.</param>
        /// <param name="angle">The radian angle of rotation for the quaternion Q.</param>
        /// <param name="q">The quaternion to measure.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "q", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToAxisAngle(out XMVector axis, out float angle, XMVector q)
        {
            axis = q;
            angle = 2.0f * XMScalar.ACos(q.W);
        }
    }
}
