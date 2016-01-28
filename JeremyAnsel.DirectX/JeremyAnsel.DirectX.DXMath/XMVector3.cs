// <copyright file="XMVector3.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DXMath
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// The 3D vector functions provided by DirectXMath.
    /// </summary>
    public static unsafe class XMVector3
    {
        /// <summary>
        /// Tests whether two 3D vectors are equal.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns true if the 3D vectors are equal and false otherwise.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Equal(XMVector v1, XMVector v2)
        {
            return v1.X == v2.X && v1.Y == v2.Y && v1.Z == v2.Z;
        }

        /// <summary>
        /// Tests whether two 3D vectors are equal. In addition, this function returns a comparison value.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns a comparison value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMComparisonRecord EqualR(XMVector v1, XMVector v2)
        {
            uint cr = 0;

            if (v1.X == v2.X && v1.Y == v2.Y && v1.Z == v2.Z)
            {
                cr = XMComparisonRecord.MaskTrue;
            }
            else if (v1.X != v2.X && v1.Y != v2.Y && v1.Z != v2.Z)
            {
                cr = XMComparisonRecord.MaskFalse;
            }

            return new XMComparisonRecord(cr);
        }

        /// <summary>
        /// Tests whether two 3D vectors are equal, treating each component as an unsigned integer.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns true if the 3D vectors are equal and false otherwise.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EqualInt(XMVector v1, XMVector v2)
        {
            return ((uint*)&v1)[0] == ((uint*)&v2)[0]
                && ((uint*)&v1)[1] == ((uint*)&v2)[1]
                && ((uint*)&v1)[2] == ((uint*)&v2)[2];
        }

        /// <summary>
        /// Tests whether two 3D vectors are equal, treating each component as an unsigned integer. In addition, this function returns a comparison value.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns a comparison value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMComparisonRecord EqualIntR(XMVector v1, XMVector v2)
        {
            uint cr = 0;

            if (((uint*)&v1)[0] == ((uint*)&v2)[0]
                && ((uint*)&v1)[1] == ((uint*)&v2)[1]
                && ((uint*)&v1)[2] == ((uint*)&v2)[2])
            {
                cr = XMComparisonRecord.MaskTrue;
            }
            else if (((uint*)&v1)[0] != ((uint*)&v2)[0]
                && ((uint*)&v1)[1] != ((uint*)&v2)[1]
                && ((uint*)&v1)[2] != ((uint*)&v2)[2])
            {
                cr = XMComparisonRecord.MaskFalse;
            }

            return new XMComparisonRecord(cr);
        }

        /// <summary>
        /// Tests whether one 3D vector is near another 3D vector.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <param name="epsilon">Tolerance value used for judging equality.</param>
        /// <returns>Returns true if V1 is near V2 and false otherwise.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NearEqual(XMVector v1, XMVector v2, XMVector epsilon)
        {
            float dx = Math.Abs(v1.X - v2.X);
            float dy = Math.Abs(v1.Y - v2.Y);
            float dz = Math.Abs(v1.Z - v2.Z);

            return dx <= epsilon.X && dy <= epsilon.Y && dz <= epsilon.Z;
        }

        /// <summary>
        /// Tests whether two 3D vectors are not equal.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns true if the 3D vectors are not equal and false otherwise.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NotEqual(XMVector v1, XMVector v2)
        {
            return v1.X != v2.X || v1.Y != v2.Y || v1.Z != v2.Z;
        }

        /// <summary>
        /// Test whether two 3D vectors are not equal, treating each component as an unsigned integer.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns true if the 3D vectors are not equal and false otherwise.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NotEqualInt(XMVector v1, XMVector v2)
        {
            return ((uint*)&v1)[0] != ((uint*)&v2)[0]
                || ((uint*)&v1)[1] != ((uint*)&v2)[1]
                || ((uint*)&v1)[2] != ((uint*)&v2)[2];
        }

        /// <summary>
        /// Tests whether one 3D vector is greater than another 3D vector.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns true if V1 is greater than V2 and false otherwise.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Greater(XMVector v1, XMVector v2)
        {
            return v1.X > v2.X && v1.Y > v2.Y && v1.Z > v2.Z;
        }

        /// <summary>
        /// Tests whether one 3D vector is greater than another 3D vector and returns a comparison value.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns a comparison value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMComparisonRecord GreaterR(XMVector v1, XMVector v2)
        {
            uint cr = 0;

            if (v1.X > v2.X && v1.Y > v2.Y && v1.Z > v2.Z)
            {
                cr = XMComparisonRecord.MaskTrue;
            }
            else if (v1.X <= v2.X && v1.Y <= v2.Y && v1.Z <= v2.Z)
            {
                cr = XMComparisonRecord.MaskFalse;
            }

            return new XMComparisonRecord(cr);
        }

        /// <summary>
        /// Tests whether one 3D vector is greater-than-or-equal-to another 3D vector.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns true if V1 is greater-than-or-equal-to V2 and false otherwise.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool GreaterOrEqual(XMVector v1, XMVector v2)
        {
            return v1.X >= v2.X && v1.Y >= v2.Y && v1.Z >= v2.Z;
        }

        /// <summary>
        /// Tests whether one 3D vector is greater-than-or-equal-to another 3D vector and returns a comparison value.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns a comparison value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMComparisonRecord GreaterOrEqualR(XMVector v1, XMVector v2)
        {
            uint cr = 0;

            if (v1.X >= v2.X && v1.Y >= v2.Y && v1.Z >= v2.Z)
            {
                cr = XMComparisonRecord.MaskTrue;
            }
            else if (v1.X < v2.X && v1.Y < v2.Y && v1.Z < v2.Z)
            {
                cr = XMComparisonRecord.MaskFalse;
            }

            return new XMComparisonRecord(cr);
        }

        /// <summary>
        /// Tests whether one 3D vector is less than another 3D vector.
        /// </summary>
        /// <param name="v1">The fist vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns true if V1 is less than V2 and false otherwise.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Less(XMVector v1, XMVector v2)
        {
            return v1.X < v2.X && v1.Y < v2.Y && v1.Z < v2.Z;
        }

        /// <summary>
        /// Tests whether one 3D vector is less-than-or-equal-to another 3D vector.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns true if V1 is less-than-or-equal-to V2 and false otherwise.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool LessOrEqual(XMVector v1, XMVector v2)
        {
            return v1.X <= v2.X && v1.Y <= v2.Y && v1.Z <= v2.Z;
        }

        /// <summary>
        /// Tests whether the components of a 3D vector are within set bounds.
        /// </summary>
        /// <param name="v">The vector to test.</param>
        /// <param name="bounds">The vector that determines the bounds.</param>
        /// <returns>Returns true if both the x, y, and z-components of V are within the set bounds, and false otherwise.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool InBounds(XMVector v, XMVector bounds)
        {
            return v.X <= bounds.X && v.X >= -bounds.X
                && v.Y <= bounds.Y && v.Y >= -bounds.Y
                && v.Z <= bounds.Z && v.Z >= -bounds.Z;
        }

        /// <summary>
        /// Tests whether any component of a 3D vector is a NaN.
        /// </summary>
        /// <param name="v">The vector.</param>
        /// <returns>Returns true if any component of V is a NaN, and false otherwise.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNaN(XMVector v)
        {
            return XMVector.IsNaN(v.X)
                || XMVector.IsNaN(v.Y)
                || XMVector.IsNaN(v.Z);
        }

        /// <summary>
        /// Tests whether any component of a 3D vector is positive or negative infinity.
        /// </summary>
        /// <param name="v">The vector.</param>
        /// <returns>Returns true if any component of V is positive or negative infinity, and false otherwise.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsInfinite(XMVector v)
        {
            return XMVector.IsInfinite(v.X)
                || XMVector.IsInfinite(v.Y)
                || XMVector.IsInfinite(v.Z);
        }

        /// <summary>
        /// Computes the dot product between 3D vectors.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns a vector. The dot product between V1 and V2 is replicated into each component.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Dot(XMVector v1, XMVector v2)
        {
            return XMVector.Replicate((v1.X * v2.X) + (v1.Y * v2.Y) + (v1.Z * v2.Z));
        }

        /// <summary>
        /// Computes the cross product between two 3D vectors.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns the cross product of V1 and V2.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Cross(XMVector v1, XMVector v2)
        {
            //// [ V1.y*V2.z - V1.z*V2.y, V1.z*V2.x - V1.x*V2.z, V1.x*V2.y - V1.y*V2.x ]

            return new XMVector(
                (v1.Y * v2.Z) - (v1.Z * v2.Y),
                (v1.Z * v2.X) - (v1.X * v2.Z),
                (v1.X * v2.Y) - (v1.Y * v2.X),
                0.0f);
        }

        /// <summary>
        /// Computes the square of the length of a 3D vector.
        /// </summary>
        /// <param name="v">The vector.</param>
        /// <returns>Returns a vector. The square of the length of V is replicated into each component.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector LengthSquare(XMVector v)
        {
            return XMVector3.Dot(v, v);
        }

        /// <summary>
        /// Estimates the reciprocal of the length of a 3D vector.
        /// </summary>
        /// <param name="v">The vector.</param>
        /// <returns>Returns a vector, each of whose components are estimates of the reciprocal of the length of V.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector ReciprocalLengthEst(XMVector v)
        {
            return XMVector3
                .LengthSquare(v)
                .ReciprocalSqrtEst();
        }

        /// <summary>
        /// Computes the reciprocal of the length of a 3D vector.
        /// </summary>
        /// <param name="v">The vector.</param>
        /// <returns>Returns a vector. The reciprocal of the length of V is replicated into each of the returned vector's components.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector ReciprocalLength(XMVector v)
        {
            return XMVector3
                .LengthSquare(v)
                .ReciprocalSqrt();
        }

        /// <summary>
        /// Estimates the length of a 3D vector.
        /// </summary>
        /// <param name="v">The vector.</param>
        /// <returns>Returns a vector, each of whose components are estimates of the length of V.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector LengthEst(XMVector v)
        {
            return XMVector3
                .LengthSquare(v)
                .SqrtEst();
        }

        /// <summary>
        /// Computes the length of a 3D vector.
        /// </summary>
        /// <param name="v">The vector.</param>
        /// <returns>Returns a vector. The length of V is replicated into each component.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Length(XMVector v)
        {
            return XMVector3
                .LengthSquare(v)
                .Sqrt();
        }

        /// <summary>
        /// Estimates the normalized version of a 3D vector.
        /// </summary>
        /// <param name="v">The vector.</param>
        /// <returns>Returns an estimate of the normalized version of V.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector NormalizeEst(XMVector v)
        {
            //// XMVector3NormalizeEst uses a reciprocal estimate and
            //// returns QNaN on zero and infinite vectors.

            XMVector result;
            result = XMVector3.ReciprocalLength(v);
            result = XMVector.Multiply(v, result);
            return result;
        }

        /// <summary>
        /// Returns the normalized version of a 3D vector.
        /// </summary>
        /// <param name="v">The vector.</param>
        /// <returns>Returns the normalized version of V.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Normalize(XMVector v)
        {
            XMVector result = XMVector3.Length(v);
            float length = result.X;

            // Prevent divide by zero
            if (length > 0)
            {
                length = 1.0f / length;
            }

            return new XMVector(
                v.X * length,
                v.Y * length,
                v.Z * length,
                v.W * length);
        }

        /// <summary>
        /// Clamps the length of a 3D vector to a given range.
        /// </summary>
        /// <param name="v">The vector.</param>
        /// <param name="lengthMin">The minimum clamp length.</param>
        /// <param name="lengthMax">The maximum clamp length.</param>
        /// <returns>Returns a 3D vector whose length is clamped to the specified minimum and maximum.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector ClampLength(XMVector v, float lengthMin, float lengthMax)
        {
            XMVector clampMax = XMVector.Replicate(lengthMax);
            XMVector clampMin = XMVector.Replicate(lengthMin);

            return XMVector3.ClampLengthV(v, clampMin, clampMax);
        }

        /// <summary>
        /// Clamps the length of a 3D vector to a given range.
        /// </summary>
        /// <param name="v">The vector.</param>
        /// <param name="lengthMin">A 3D vector whose x, y, and z-components are equal to the minimum clamp length. The x, y, and z-components must be greater-than-or-equal to zero.</param>
        /// <param name="lengthMax">A 3D vector whose x, y, and z-components are equal to the maximum clamp length. The x, y, and z-components must be greater-than-or-equal to zero.</param>
        /// <returns>Returns a 3D vector whose length is clamped to the specified minimum and maximum.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector ClampLengthV(XMVector v, XMVector lengthMin, XMVector lengthMax)
        {
            Debug.Assert(lengthMin.Y == lengthMin.X && lengthMin.Z == lengthMin.X, "Reviewed");
            Debug.Assert(lengthMax.Y == lengthMax.X && lengthMax.Z == lengthMax.X, "Reviewed");
            Debug.Assert(XMVector3.GreaterOrEqual(lengthMin, XMGlobalConstants.Zero), "Reviewed");
            Debug.Assert(XMVector3.GreaterOrEqual(lengthMax, XMGlobalConstants.Zero), "Reviewed");
            Debug.Assert(XMVector3.GreaterOrEqual(lengthMax, lengthMin), "Reviewed");

            XMVector lengthSq = XMVector3.LengthSquare(v);
            XMVector zero = XMVector.Zero;
            XMVector reciprocalLength = lengthSq.ReciprocalSqrt();

            XMVector infiniteLength = XMVector.EqualInt(lengthSq, XMGlobalConstants.Infinity);
            XMVector zeroLength = XMVector.EqualInt(lengthSq, zero);

            XMVector normal = XMVector.Multiply(v, reciprocalLength);
            XMVector length = XMVector.Multiply(lengthSq, reciprocalLength);

            XMVector select = XMVector.EqualInt(infiniteLength, zeroLength);
            length = XMVector.Select(lengthSq, length, select);
            normal = XMVector.Select(lengthSq, normal, select);

            XMVector controlMax = XMVector.Greater(length, lengthMax);
            XMVector controlMin = XMVector.Less(length, lengthMin);

            XMVector clampLength = XMVector.Select(length, lengthMax, controlMax);
            clampLength = XMVector.Select(clampLength, lengthMin, controlMin);

            XMVector result = XMVector.Multiply(normal, clampLength);

            // Preserve the original vector (with no precision loss) if the length falls within the given range
            XMVector control = XMVector.EqualInt(controlMax, controlMin);
            result = XMVector.Select(result, v, control);

            return result;
        }

        /// <summary>
        /// Reflects an incident 3D vector across a 3D normal vector.
        /// </summary>
        /// <param name="incident">The incident vector to reflect.</param>
        /// <param name="normal">The normal vector to reflect the incident vector across.</param>
        /// <returns>Returns the reflected incident angle.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Reflect(XMVector incident, XMVector normal)
        {
            //// Result = Incident - (2 * dot(Incident, Normal)) * Normal

            XMVector result = XMVector3.Dot(incident, normal);
            result = XMVector.Add(result, result);
            result = XMVector.NegativeMultiplySubtract(result, normal, incident);

            return result;
        }

        /// <summary>
        /// Refracts an incident 3D vector across a 3D normal vector.
        /// </summary>
        /// <param name="incident">The incident vector to refract.</param>
        /// <param name="normal">The normal vector to refract the incident vector through.</param>
        /// <param name="refractionIndex">The index of refraction.</param>
        /// <returns>Returns the refracted incident vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Refract(XMVector incident, XMVector normal, float refractionIndex)
        {
            XMVector index = XMVector.Replicate(refractionIndex);

            return XMVector3.RefractV(incident, normal, index);
        }

        /// <summary>
        /// Refracts an incident 3D vector across a 3D normal vector.
        /// </summary>
        /// <param name="incident">The incident vector to refract.</param>
        /// <param name="normal">The normal vector to refract the incident vector through.</param>
        /// <param name="refractionIndex">A vector whose x, y, and z-components are equal to the index of refraction.</param>
        /// <returns>Returns the refracted incident vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector RefractV(XMVector incident, XMVector normal, XMVector refractionIndex)
        {
            //// Result = RefractionIndex * Incident - Normal * (RefractionIndex * dot(Incident, Normal) + 
            //// sqrt(1 - RefractionIndex * RefractionIndex * (1 - dot(Incident, Normal) * dot(Incident, Normal))))

            XMVector zero = XMVector.Zero;
            XMVector incidentDotNornal = XMVector3.Dot(incident, normal);

            // R = 1.0f - RefractionIndex * RefractionIndex * (1.0f - IDotN * IDotN)
            XMVector r = XMVector.NegativeMultiplySubtract(incidentDotNornal, incidentDotNornal, XMGlobalConstants.One);
            r = XMVector.Multiply(r, refractionIndex);
            r = XMVector.NegativeMultiplySubtract(r, refractionIndex, XMGlobalConstants.One);

            if (r.X <= zero.X && r.Y <= zero.Y && r.Z <= zero.Z && r.W <= zero.W)
            {
                // Total internal reflection
                return zero;
            }
            else
            {
                // R = RefractionIndex * IDotN + sqrt(R)
                r = r.Sqrt();
                r = XMVector.MultiplyAdd(refractionIndex, incidentDotNornal, r);

                // Result = RefractionIndex * Incident - Normal * R
                XMVector result = XMVector.Multiply(refractionIndex, incident);
                result = XMVector.NegativeMultiplySubtract(normal, r, result);

                return result;
            }
        }

        /// <summary>
        /// Computes a vector perpendicular to a 3D vector.
        /// </summary>
        /// <param name="v">The vector.</param>
        /// <returns>Returns a 3D vector orthogonal to V.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Orthogonal(XMVector v)
        {
            XMVector zero = XMVector.Zero;
            XMVector z = XMVector.SplatZ(v);

            XMVector yzyy = new XMVector(v.Y, v.Z, v.Y, v.Y);
            XMVector negativeV = XMVector.Subtract(zero, v);

            XMVector z_isNegative = XMVector.Less(z, zero);
            XMVector yzyyIsNegative = XMVector.Less(yzyy, zero);

            XMVector s = XMVector.Add(yzyy, z);
            XMVector d = XMVector.Subtract(yzyy, z);

            XMVector select = XMVector.EqualInt(z_isNegative, yzyyIsNegative);

            XMVector r0 = new XMVector(s.X, negativeV.X, negativeV.X, negativeV.X);
            XMVector r1 = new XMVector(d.X, v.X, v.X, v.X);

            return XMVector.Select(r1, r0, select);
        }

        /// <summary>
        /// Estimates the radian angle between two normalized 3D vectors.
        /// </summary>
        /// <param name="n1">The first normalized vector.</param>
        /// <param name="n2">The second normalized vector.</param>
        /// <returns>Returns a vector. The estimate of the radian angle (between N1 and N2) is replicated to each of the components.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector AngleBetweenNormalsEst(XMVector n1, XMVector n2)
        {
            return XMVector3
                .Dot(n1, n2)
                .Clamp(XMGlobalConstants.NegativeOne, XMGlobalConstants.One)
                .ACosEst();
        }

        /// <summary>
        /// Computes the radian angle between two normalized 3D vectors.
        /// </summary>
        /// <param name="n1">The first normalized vector.</param>
        /// <param name="n2">The second normalized vector.</param>
        /// <returns>Returns a vector. The radian angle between N1 and N2 is replicated to each of the components.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector AngleBetweenNormals(XMVector n1, XMVector n2)
        {
            return XMVector3
                .Dot(n1, n2)
                .Clamp(XMGlobalConstants.NegativeOne, XMGlobalConstants.One)
                .ACos();
        }

        /// <summary>
        /// Computes the radian angle between two 3D vectors.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns a vector. The radian angle between V1 and V2 is replicated to each of the components.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector AngleBetweenVectors(XMVector v1, XMVector v2)
        {
            XMVector l1 = XMVector3.ReciprocalLength(v1);
            XMVector l2 = XMVector3.ReciprocalLength(v2);

            XMVector dot = XMVector3.Dot(v1, v2);

            l1 = XMVector.Multiply(l1, l2);

            return XMVector
                .Multiply(dot, l1)
                .Clamp(XMGlobalConstants.NegativeOne, XMGlobalConstants.One)
                .ACos();
        }

        /// <summary>
        /// Computes the minimum distance between a line and a point.
        /// </summary>
        /// <param name="linePoint1">The first point on the line.</param>
        /// <param name="linePoint2">The second point on the line.</param>
        /// <param name="point">The reference point.</param>
        /// <returns>Returns a vector. The minimum distance between the line and the point is replicated to each of the components.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector LinePointDistance(XMVector linePoint1, XMVector linePoint2, XMVector point)
        {
            //// Given a vector PointVector from LinePoint1 to Point and a vector
            //// LineVector from LinePoint1 to LinePoint2, the scaled distance 
            //// PointProjectionScale from LinePoint1 to the perpendicular projection
            //// of PointVector onto the line is defined as:
            ////
            ////     PointProjectionScale = dot(PointVector, LineVector) / LengthSq(LineVector)

            XMVector pointVector = XMVector.Subtract(point, linePoint1);
            XMVector lineVector = XMVector.Subtract(linePoint2, linePoint1);

            XMVector lengthSq = XMVector3.LengthSquare(lineVector);

            XMVector pointProjectionScale = XMVector3.Dot(pointVector, lineVector);
            pointProjectionScale = XMVector.Divide(pointProjectionScale, lengthSq);

            XMVector distanceVector = XMVector.Multiply(lineVector, pointProjectionScale);
            distanceVector = XMVector.Subtract(pointVector, distanceVector);

            return XMVector3.Length(distanceVector);
        }

        /// <summary>
        /// Using a reference normal vector, splits a 3D vector into components that are parallel and perpendicular to the normal.
        /// </summary>
        /// <param name="parallel">The component of V that is parallel to Normal.</param>
        /// <param name="perpendicular">The component of V that is perpendicular to Normal.</param>
        /// <param name="v">The vector to break into components.</param>
        /// <param name="normal">The reference normal vector.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ComponentsFromNormal(out XMVector parallel, out XMVector perpendicular, XMVector v, XMVector normal)
        {
            XMVector scale = XMVector3.Dot(v, normal);
            XMVector parallelV = XMVector.Multiply(normal, scale);

            parallel = parallelV;
            perpendicular = XMVector.Subtract(v, parallelV);
        }

        /// <summary>
        /// Rotates a 3D vector using a quaternion.
        /// </summary>
        /// <param name="v">The vector to rotate.</param>
        /// <param name="rotationQuaternion">The quaternion that describes the rotation to apply to the vector.</param>
        /// <returns>The rotated 3D vector.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Rotate(XMVector v, XMVector rotationQuaternion)
        {
            //// Transform a vector using a rotation expressed as a unit quaternion

            XMVector a = XMVector.Select(XMGlobalConstants.Select1110, v, XMGlobalConstants.Select1110);
            XMVector q = XMQuaternion.Conjugate(rotationQuaternion);
            XMVector result = XMQuaternion.Multiply(q, a);
            return XMQuaternion.Multiply(result, rotationQuaternion);
        }

        /// <summary>
        /// Rotates a 3D vector using the inverse of a quaternion.
        /// </summary>
        /// <param name="v">The vector to rotate.</param>
        /// <param name="rotationQuaternion">The quaternion that describes the inverse of the rotation to apply to the vector.</param>
        /// <returns>Returns the rotated 3D vector.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector InverseRotate(XMVector v, XMVector rotationQuaternion)
        {
            //// Transform a vector using the inverse of a rotation expressed as a unit quaternion

            XMVector a = XMVector.Select(XMGlobalConstants.Select1110, v, XMGlobalConstants.Select1110);
            XMVector result = XMQuaternion.Multiply(rotationQuaternion, a);
            XMVector q = XMQuaternion.Conjugate(rotationQuaternion);
            return XMQuaternion.Multiply(result, q);
        }

        /// <summary>
        /// Transforms a 3D vector by a matrix.
        /// </summary>
        /// <param name="v">The vector.</param>
        /// <param name="m">The transformation matrix.</param>
        /// <returns>Returns the transformed vector.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "m", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Transform(XMVector v, XMMatrix m)
        {
            XMVector z = XMVector.SplatZ(v);
            XMVector y = XMVector.SplatY(v);
            XMVector x = XMVector.SplatX(v);

            XMVector result = XMVector.MultiplyAdd(z, ((XMVector*)&m)[2], ((XMVector*)&m)[3]);
            result = XMVector.MultiplyAdd(y, ((XMVector*)&m)[1], result);
            result = XMVector.MultiplyAdd(x, ((XMVector*)&m)[0], result);

            return result;
        }

        /// <summary>
        /// Transforms a 3D vector by a given matrix, projecting the result back into w = 1.
        /// </summary>
        /// <param name="v">The vector.</param>
        /// <param name="m">The transformation matrix.</param>
        /// <returns>Returns the transformed vector.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "m", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector TransformCoord(XMVector v, XMMatrix m)
        {
            XMVector z = XMVector.SplatZ(v);
            XMVector y = XMVector.SplatY(v);
            XMVector x = XMVector.SplatX(v);

            XMVector result = XMVector.MultiplyAdd(z, ((XMVector*)&m)[2], ((XMVector*)&m)[3]);
            result = XMVector.MultiplyAdd(y, ((XMVector*)&m)[1], result);
            result = XMVector.MultiplyAdd(x, ((XMVector*)&m)[0], result);

            XMVector w = XMVector.SplatW(result);
            return XMVector.Divide(result, w);
        }

        /// <summary>
        /// Transforms the 3D vector normal by the given matrix.
        /// </summary>
        /// <param name="v">The normal vector.</param>
        /// <param name="m">The transformation matrix.</param>
        /// <returns>Returns the transformed vector.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "m", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector TransformNormal(XMVector v, XMMatrix m)
        {
            XMVector z = XMVector.SplatZ(v);
            XMVector y = XMVector.SplatY(v);
            XMVector x = XMVector.SplatX(v);

            XMVector result = XMVector.Multiply(z, ((XMVector*)&m)[2]);
            result = XMVector.MultiplyAdd(y, ((XMVector*)&m)[1], result);
            result = XMVector.MultiplyAdd(x, ((XMVector*)&m)[0], result);

            return result;
        }

        /// <summary>
        /// Project a 3D vector from object space into screen space.
        /// </summary>
        /// <param name="v">The vector in object space that will be projected into screen space.</param>
        /// <param name="viewportX">Pixel coordinate of the upper-left corner of the viewport. Unless you want to render to a subset of the surface, this parameter can be set to 0.</param>
        /// <param name="viewportY">Pixel coordinate of the upper-left corner of the viewport on the render-target surface. Unless you want to render to a subset of the surface, this parameter can be set to 0.</param>
        /// <param name="viewportWidth">Width dimension of the clip volume, in pixels. Unless you are rendering only to a subset of the surface, this parameter should be set to the width dimension of the render-target surface.</param>
        /// <param name="viewportHeight">Height dimension of the clip volume, in pixels. Unless you are rendering only to a subset of the surface, this parameter should be set to the height dimension of the render-target surface.</param>
        /// <param name="viewportMinZ">Together with ViewportMaxZ, value describing the range of depth values into which a scene is to be rendered, the minimum and maximum values of the clip volume. Most applications set this value to 0.0f. Clipping is performed after applying the projection matrix.</param>
        /// <param name="viewportMaxZ">Together with MinZ, value describing the range of depth values into which a scene is to be rendered, the minimum and maximum values of the clip volume. Most applications set this value to 1.0f. Clipping is performed after applying the projection matrix.</param>
        /// <param name="projection">Projection matrix.</param>
        /// <param name="view">View matrix.</param>
        /// <param name="world">World matrix.</param>
        /// <returns>Returns a vector in screen space.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Project(
            XMVector v,
            float viewportX,
            float viewportY,
            float viewportWidth,
            float viewportHeight,
            float viewportMinZ,
            float viewportMaxZ,
            XMMatrix projection,
            XMMatrix view,
            XMMatrix world)
        {
            float halfViewportWidth = viewportWidth * 0.5f;
            float halfViewportHeight = viewportHeight * 0.5f;

            XMVector scale = new XMVector(halfViewportWidth, -halfViewportHeight, viewportMaxZ - viewportMinZ, 0.0f);
            XMVector offset = new XMVector(viewportX + halfViewportWidth, viewportY + halfViewportHeight, viewportMinZ, 0.0f);

            XMMatrix transform = XMMatrix.Multiply(world, view);
            transform = XMMatrix.Multiply(transform, projection);

            XMVector result = XMVector3.TransformCoord(v, transform);
            result = XMVector.MultiplyAdd(result, scale, offset);

            return result;
        }

        /// <summary>
        /// Projects a 3D vector from screen space into object space.
        /// </summary>
        /// <param name="v">The vector in screen space that will be projected into object space.</param>
        /// <param name="viewportX">Pixel coordinate of the upper-left corner of the viewport. Unless you want to render to a subset of the surface, this parameter can be set to 0.</param>
        /// <param name="viewportY">Pixel coordinate of the upper-left corner of the viewport on the render-target surface. Unless you want to render to a subset of the surface, this parameter can be set to 0.</param>
        /// <param name="viewportWidth">Width dimension of the clip volume, in pixels. Unless you are rendering only to a subset of the surface, this parameter should be set to the width dimension of the render-target surface.</param>
        /// <param name="viewportHeight">Height dimension of the clip volume, in pixels. Unless you are rendering only to a subset of the surface, this parameter should be set to the height dimension of the render-target surface.</param>
        /// <param name="viewportMinZ">Together with ViewportMaxZ, value describing the range of depth values into which a scene is to be rendered, the minimum and maximum values of the clip volume. Most applications set this value to 0.0f. Clipping is performed after applying the projection matrix.</param>
        /// <param name="viewportMaxZ">Together with MinZ, value describing the range of depth values into which a scene is to be rendered, the minimum and maximum values of the clip volume. Most applications set this value to 1.0f. Clipping is performed after applying the projection matrix.</param>
        /// <param name="projection">Projection matrix.</param>
        /// <param name="view">View matrix.</param>
        /// <param name="world">World matrix.</param>
        /// <returns>Returns a vector in object space.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Unproject(
            XMVector v,
            float viewportX,
            float viewportY,
            float viewportWidth,
            float viewportHeight,
            float viewportMinZ,
            float viewportMaxZ,
            XMMatrix projection,
            XMMatrix view,
            XMMatrix world)
        {
            XMVector d = XMVector.FromFloat(-1.0f, 1.0f, 0.0f, 0.0f);

            XMVector scale = new XMVector(viewportWidth * 0.5f, -viewportHeight * 0.5f, viewportMaxZ - viewportMinZ, 1.0f);
            scale = scale.Reciprocal();

            XMVector offset = new XMVector(-viewportX, -viewportY, -viewportMinZ, 0.0f);
            offset = XMVector.MultiplyAdd(scale, offset, d);

            XMMatrix transform = XMMatrix.Multiply(world, view);
            transform = XMMatrix.Multiply(transform, projection);
            transform = transform.Inverse();

            XMVector result = XMVector.MultiplyAdd(v, scale, offset);

            return XMVector3.TransformCoord(result, transform);
        }
    }
}
