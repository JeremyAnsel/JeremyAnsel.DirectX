// <copyright file="XMVector4.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DXMath
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// The 4D vector functions provided by DirectXMath.
    /// </summary>
    public static unsafe class XMVector4
    {
        /// <summary>
        /// Tests whether two 4D vectors are equal.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns true if the 4D vectors are equal and false otherwise.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Equal(XMVector v1, XMVector v2)
        {
            return v1.X == v2.X && v1.Y == v2.Y && v1.Z == v2.Z && v1.W == v2.W;
        }

        /// <summary>
        /// Tests whether two 4D vectors are equal. In addition, this function returns a comparison value.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns a comparison value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMComparisonRecord EqualR(XMVector v1, XMVector v2)
        {
            uint cr = 0;

            if (v1.X == v2.X && v1.Y == v2.Y && v1.Z == v2.Z && v1.W == v2.W)
            {
                cr = XMComparisonRecord.MaskTrue;
            }
            else if (v1.X != v2.X && v1.Y != v2.Y && v1.Z != v2.Z && v1.W != v2.W)
            {
                cr = XMComparisonRecord.MaskFalse;
            }

            return new XMComparisonRecord(cr);
        }

        /// <summary>
        /// Tests whether two 4D vectors are equal, treating each component as an unsigned integer.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns true if the 4D vectors are equal and false otherwise.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EqualInt(XMVector v1, XMVector v2)
        {
            return ((uint*)&v1)[0] == ((uint*)&v2)[0]
                && ((uint*)&v1)[1] == ((uint*)&v2)[1]
                && ((uint*)&v1)[2] == ((uint*)&v2)[2]
                && ((uint*)&v1)[3] == ((uint*)&v2)[3];
        }

        /// <summary>
        /// Tests whether two 4D vectors are equal, treating each component as an unsigned integer. In addition, this function returns a comparison value.
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
                && ((uint*)&v1)[2] == ((uint*)&v2)[2]
                && ((uint*)&v1)[3] == ((uint*)&v2)[3])
            {
                cr = XMComparisonRecord.MaskTrue;
            }
            else if (((uint*)&v1)[0] != ((uint*)&v2)[0]
                && ((uint*)&v1)[1] != ((uint*)&v2)[1]
                && ((uint*)&v1)[2] != ((uint*)&v2)[2]
                && ((uint*)&v1)[3] != ((uint*)&v2)[3])
            {
                cr = XMComparisonRecord.MaskFalse;
            }

            return new XMComparisonRecord(cr);
        }

        /// <summary>
        /// Tests whether one 4D vector is near another 4D vector.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <param name="epsilon">The tolerance value used for judging equality.</param>
        /// <returns>Returns true if V1 is near V2 and false otherwise.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NearEqual(XMVector v1, XMVector v2, XMVector epsilon)
        {
            float dx = Math.Abs(v1.X - v2.X);
            float dy = Math.Abs(v1.Y - v2.Y);
            float dz = Math.Abs(v1.Z - v2.Z);
            float dw = Math.Abs(v1.W - v2.W);

            return dx <= epsilon.X && dy <= epsilon.Y && dz <= epsilon.Z && dw <= epsilon.W;
        }

        /// <summary>
        /// Tests whether two 4D vectors are not equal.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns true if the 4D vectors are not equal and false otherwise.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NotEqual(XMVector v1, XMVector v2)
        {
            return v1.X != v2.X || v1.Y != v2.Y || v1.Z != v2.Z || v1.W != v2.W;
        }

        /// <summary>
        /// Test whether two 4D vectors are not equal, treating each component as an unsigned integer.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns true if the 4D vectors are not equal and false otherwise.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NotEqualInt(XMVector v1, XMVector v2)
        {
            return ((uint*)&v1)[0] != ((uint*)&v2)[0]
                || ((uint*)&v1)[1] != ((uint*)&v2)[1]
                || ((uint*)&v1)[2] != ((uint*)&v2)[2]
                || ((uint*)&v1)[3] != ((uint*)&v2)[3];
        }

        /// <summary>
        /// Tests whether one 4D vector is greater than another 4D vector.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns true if V1 is greater than V2 and false otherwise.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Greater(XMVector v1, XMVector v2)
        {
            return v1.X > v2.X && v1.Y > v2.Y && v1.Z > v2.Z && v1.W > v2.W;
        }

        /// <summary>
        /// Tests whether one 4D vector is greater than another 4D vector and returns a comparison value.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns a comparison value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMComparisonRecord GreaterR(XMVector v1, XMVector v2)
        {
            uint cr = 0;

            if (v1.X > v2.X && v1.Y > v2.Y && v1.Z > v2.Z && v1.W > v2.W)
            {
                cr = XMComparisonRecord.MaskTrue;
            }
            else if (v1.X <= v2.X && v1.Y <= v2.Y && v1.Z <= v2.Z && v1.W <= v2.W)
            {
                cr = XMComparisonRecord.MaskFalse;
            }

            return new XMComparisonRecord(cr);
        }

        /// <summary>
        /// Tests whether one 4D vector is greater-than-or-equal-to another 4D vector.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns true if V1 is greater-than-or-equal-to V2 and false otherwise.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool GreaterOrEqual(XMVector v1, XMVector v2)
        {
            return v1.X >= v2.X && v1.Y >= v2.Y && v1.Z >= v2.Z && v1.W >= v2.W;
        }

        /// <summary>
        /// Tests whether one 4D vector is greater-than-or-equal-to another 4D vector and returns a comparison value.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns a comparison value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMComparisonRecord GreaterOrEqualR(XMVector v1, XMVector v2)
        {
            uint cr = 0;

            if (v1.X >= v2.X && v1.Y >= v2.Y && v1.Z >= v2.Z && v1.W >= v2.W)
            {
                cr = XMComparisonRecord.MaskTrue;
            }
            else if (v1.X < v2.X && v1.Y < v2.Y && v1.Z < v2.Z && v1.W < v2.W)
            {
                cr = XMComparisonRecord.MaskFalse;
            }

            return new XMComparisonRecord(cr);
        }

        /// <summary>
        /// Tests whether one 4D vector is less than another 4D vector.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns true if V1 is less than V2 and false otherwise.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Less(XMVector v1, XMVector v2)
        {
            return v1.X < v2.X && v1.Y < v2.Y && v1.Z < v2.Z && v1.W < v2.W;
        }

        /// <summary>
        /// Tests whether one 4D vector is less-than-or-equal-to another 4D vector.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns true if V1 is less-than-or-equal-to V2, and false otherwise.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool LessOrEqual(XMVector v1, XMVector v2)
        {
            return v1.X <= v2.X && v1.Y <= v2.Y && v1.Z <= v2.Z && v1.W <= v2.W;
        }

        /// <summary>
        /// Tests whether the components of a 4D vector are within set bounds.
        /// </summary>
        /// <param name="v">The vector to test.</param>
        /// <param name="bounds">The vector that determines the bounds.</param>
        /// <returns>Returns true if all of the components of V are within the set bounds, and false otherwise.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool InBounds(XMVector v, XMVector bounds)
        {
            return v.X <= bounds.X && v.X >= -bounds.X
                && v.Y <= bounds.Y && v.Y >= -bounds.Y
                && v.Z <= bounds.Z && v.Z >= -bounds.Z
                && v.W <= bounds.W && v.W >= -bounds.W;
        }

        /// <summary>
        /// Tests whether any component of a 4D vector is a NaN.
        /// </summary>
        /// <param name="v">The vector.</param>
        /// <returns>Returns true if any component of V is a NaN, and false otherwise.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNaN(XMVector v)
        {
            return XMVector.IsNaN(v.X)
                || XMVector.IsNaN(v.Y)
                || XMVector.IsNaN(v.Z)
                || XMVector.IsNaN(v.W);
        }

        /// <summary>
        /// Tests whether any component of a 4D vector is positive or negative infinity.
        /// </summary>
        /// <param name="v">The vector.</param>
        /// <returns>Returns true if any component of V is positive or negative infinity, and false otherwise.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsInfinite(XMVector v)
        {
            return XMVector.IsInfinite(v.X)
                || XMVector.IsInfinite(v.Y)
                || XMVector.IsInfinite(v.Z)
                || XMVector.IsInfinite(v.W);
        }

        /// <summary>
        /// Computes the dot product between 4D vectors.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns a vector. The dot product between V1 and V2 is replicated into each component.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Dot(XMVector v1, XMVector v2)
        {
            return XMVector.Replicate((v1.X * v2.X) + (v1.Y * v2.Y) + (v1.Z * v2.Z) + (v1.W * v2.W));
        }

        /// <summary>
        /// Computes the 4D cross product.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <param name="v3">The third vector.</param>
        /// <returns>Returns the 4D cross product of V1, V2, and V3.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Cross(XMVector v1, XMVector v2, XMVector v3)
        {
            //// [ ((v2.z*v3.w-v2.w*v3.z)*v1.y)-((v2.y*v3.w-v2.w*v3.y)*v1.z)+((v2.y*v3.z-v2.z*v3.y)*v1.w),
            ////   ((v2.w*v3.z-v2.z*v3.w)*v1.x)-((v2.w*v3.x-v2.x*v3.w)*v1.z)+((v2.z*v3.x-v2.x*v3.z)*v1.w),
            ////   ((v2.y*v3.w-v2.w*v3.y)*v1.x)-((v2.x*v3.w-v2.w*v3.x)*v1.y)+((v2.x*v3.y-v2.y*v3.x)*v1.w),
            ////   ((v2.z*v3.y-v2.y*v3.z)*v1.x)-((v2.z*v3.x-v2.x*v3.z)*v1.y)+((v2.y*v3.x-v2.x*v3.y)*v1.z) ]

            return new XMVector(
                (((v2.Z * v3.W) - (v2.W * v3.Z)) * v1.Y) - (((v2.Y * v3.W) - (v2.W * v3.Y)) * v1.Z) + (((v2.Y * v3.Z) - (v2.Z * v3.Y)) * v1.W),
                (((v2.W * v3.Z) - (v2.Z * v3.W)) * v1.X) - (((v2.W * v3.X) - (v2.X * v3.W)) * v1.Z) + (((v2.Z * v3.X) - (v2.X * v3.Z)) * v1.W),
                (((v2.Y * v3.W) - (v2.W * v3.Y)) * v1.X) - (((v2.X * v3.W) - (v2.W * v3.X)) * v1.Y) + (((v2.X * v3.Y) - (v2.Y * v3.X)) * v1.W),
                (((v2.Z * v3.Y) - (v2.Y * v3.Z)) * v1.X) - (((v2.Z * v3.X) - (v2.X * v3.Z)) * v1.Y) + (((v2.Y * v3.X) - (v2.X * v3.Y)) * v1.Z));
        }

        /// <summary>
        /// Computes the square of the length of a 4D vector.
        /// </summary>
        /// <param name="v">The vector.</param>
        /// <returns>Returns a vector. The square of the length of V is replicated into each component.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector LengthSquare(XMVector v)
        {
            return XMVector4.Dot(v, v);
        }

        /// <summary>
        /// Estimates the reciprocal of the length of a 4D vector.
        /// </summary>
        /// <param name="v">The vector.</param>
        /// <returns>Returns a vector, each of whose components are estimates of the reciprocal of the length of V.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector ReciprocalLengthEst(XMVector v)
        {
            return XMVector4
                .LengthSquare(v)
                .ReciprocalSqrtEst();
        }

        /// <summary>
        /// Computes the reciprocal of the length of a 4D vector.
        /// </summary>
        /// <param name="v">he vector.</param>
        /// <returns>Returns the reciprocal of the length of V.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector ReciprocalLength(XMVector v)
        {
            return XMVector4
                .LengthSquare(v)
                .ReciprocalSqrt();
        }

        /// <summary>
        /// Estimates the length of a 4D vector.
        /// </summary>
        /// <param name="v">The vector.</param>
        /// <returns>Returns a vector, each of whose components are estimates of the length of V.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector LengthEst(XMVector v)
        {
            return XMVector4
                .LengthSquare(v)
                .SqrtEst();
        }

        /// <summary>
        /// Computes the length of a 4D vector.
        /// </summary>
        /// <param name="v">The vector.</param>
        /// <returns>Returns a vector. The length of V is replicated into each component.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Length(XMVector v)
        {
            return XMVector4
                .LengthSquare(v)
                .Sqrt();
        }

        /// <summary>
        /// Estimates the normalized version of a 4D vector.
        /// </summary>
        /// <param name="v">The vector.</param>
        /// <returns>Returns an estimate of the normalized version of V.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector NormalizeEst(XMVector v)
        {
            //// XMVector4NormalizeEst uses a reciprocal estimate and
            //// returns QNaN on zero and infinite vectors.

            XMVector result;
            result = XMVector4.ReciprocalLength(v);
            result = XMVector.Multiply(v, result);

            return result;
        }

        /// <summary>
        /// Returns the normalized version of a 4D vector.
        /// </summary>
        /// <param name="v">The vector.</param>
        /// <returns>Returns the normalized version of V.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Normalize(XMVector v)
        {
            XMVector result = XMVector4.Length(v);
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
        /// Clamps the length of a 4D vector to a given range.
        /// </summary>
        /// <param name="v">The vector.</param>
        /// <param name="lengthMin">The minimum clamp length.</param>
        /// <param name="lengthMax">The maximum clamp length.</param>
        /// <returns>Returns a 4D vector whose length is clamped to the specified minimum and maximum.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector ClampLength(XMVector v, float lengthMin, float lengthMax)
        {
            XMVector clampMax = XMVector.Replicate(lengthMax);
            XMVector clampMin = XMVector.Replicate(lengthMin);

            return XMVector4.ClampLengthV(v, clampMin, clampMax);
        }

        /// <summary>
        /// Clamps the length of a 4D vector to a given range.
        /// </summary>
        /// <param name="v">The vector.</param>
        /// <param name="lengthMin">A 4D vector, all of whose components are equal to the minimum clamp length. The components must be greater-than-or-equal to zero.</param>
        /// <param name="lengthMax">A 4D vector, all of whose components are equal to the maximum clamp length. The components must be greater-than-or-equal to zero.</param>
        /// <returns>Returns a 4D vector whose length is clamped to the specified minimum and maximum.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector ClampLengthV(XMVector v, XMVector lengthMin, XMVector lengthMax)
        {
            Debug.Assert(lengthMin.Y == lengthMin.X && lengthMin.Z == lengthMin.X && lengthMin.W == lengthMin.X, "Reviewed");
            Debug.Assert(lengthMax.Y == lengthMax.X && lengthMax.Z == lengthMax.X && lengthMax.W == lengthMax.X, "Reviewed");
            Debug.Assert(XMVector4.GreaterOrEqual(lengthMin, XMGlobalConstants.Zero), "Reviewed");
            Debug.Assert(XMVector4.GreaterOrEqual(lengthMax, XMGlobalConstants.Zero), "Reviewed");
            Debug.Assert(XMVector4.GreaterOrEqual(lengthMax, lengthMin), "Reviewed");

            XMVector lengthSq = XMVector4.LengthSquare(v);
            XMVector zero = XMVector.Zero;
            XMVector reciprocalLength = lengthSq.ReciprocalSqrt();

            XMVector infiniteLength = XMVector.EqualInt(lengthSq, XMGlobalConstants.Infinity);
            XMVector zeroLength = XMVector.Equal(lengthSq, zero);

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
        /// Reflects an incident 4D vector across a 4D normal vector.
        /// </summary>
        /// <param name="incident">The incident vector to reflect.</param>
        /// <param name="normal">The normal vector to reflect the incident vector across.</param>
        /// <returns>Returns the reflected incident angle.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Reflect(XMVector incident, XMVector normal)
        {
            //// Result = Incident - (2 * dot(Incident, Normal)) * Normal

            XMVector result = XMVector4.Dot(incident, normal);
            result = XMVector.Add(result, result);
            result = XMVector.NegativeMultiplySubtract(result, normal, incident);

            return result;
        }

        /// <summary>
        /// Refracts an incident 4D vector across a 4D normal vector.
        /// </summary>
        /// <param name="incident">The incident vector to refract.</param>
        /// <param name="normal">The normal vector to refract the incident vector through.</param>
        /// <param name="refractionIndex">The index of refraction.</param>
        /// <returns>Returns the refracted incident vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Refract(XMVector incident, XMVector normal, float refractionIndex)
        {
            XMVector index = XMVector.Replicate(refractionIndex);

            return XMVector4.RefractV(incident, normal, index);
        }

        /// <summary>
        /// Refracts an incident 4D vector across a 4D normal vector.
        /// </summary>
        /// <param name="incident">The incident vector to refract.</param>
        /// <param name="normal">The normal vector to refract the incident vector through.</param>
        /// <param name="refractionIndex">A 4D vector, all of whose components are equal to the index of refraction.</param>
        /// <returns>Returns the refracted incident vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector RefractV(XMVector incident, XMVector normal, XMVector refractionIndex)
        {
            //// Result = RefractionIndex * Incident - Normal * (RefractionIndex * dot(Incident, Normal) + 
            //// sqrt(1 - RefractionIndex * RefractionIndex * (1 - dot(Incident, Normal) * dot(Incident, Normal))))

            XMVector zero = XMVector.Zero;
            XMVector incidentDotNormal = XMVector4.Dot(incident, normal);

            // R = 1.0f - RefractionIndex * RefractionIndex * (1.0f - IDotN * IDotN)
            XMVector r = XMVector.NegativeMultiplySubtract(incidentDotNormal, incidentDotNormal, XMGlobalConstants.One);
            r = XMVector.Multiply(r, refractionIndex);
            r = XMVector.NegativeMultiplySubtract(r, refractionIndex, XMGlobalConstants.One);

            if (XMVector4.LessOrEqual(r, zero))
            {
                // Total internal reflection
                return zero;
            }
            else
            {
                // R = RefractionIndex * IDotN + sqrt(R)
                r = r.Sqrt();
                r = XMVector.MultiplyAdd(refractionIndex, incidentDotNormal, r);

                // Result = RefractionIndex * Incident - Normal * R
                XMVector result = XMVector.Multiply(refractionIndex, incident);
                result = XMVector.NegativeMultiplySubtract(normal, r, result);

                return result;
            }
        }

        /// <summary>
        /// Computes a vector perpendicular to a 4D vector.
        /// </summary>
        /// <param name="v">The vector.</param>
        /// <returns>Returns the 4D vector orthogonal to V.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Orthogonal(XMVector v)
        {
            return new XMVector(v.Z, v.W, -v.X, -v.Y);
        }

        /// <summary>
        /// Estimates the radian angle between two normalized 4D vectors.
        /// </summary>
        /// <param name="n1">The first normalized vector.</param>
        /// <param name="n2">The second normalized vector.</param>
        /// <returns>Returns a vector. The estimate of the radian angle (between N1 and N2) is replicated to each of the components.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector AngleBetweenNormalsEst(XMVector n1, XMVector n2)
        {
            return XMVector4
                .Dot(n1, n2)
                .Clamp(XMGlobalConstants.NegativeOne, XMGlobalConstants.One)
                .ACosEst();
        }

        /// <summary>
        /// Compute the radian angle between two normalized 4D vectors.
        /// </summary>
        /// <param name="n1">The first normalized vector.</param>
        /// <param name="n2">The second normalized vector.</param>
        /// <returns>Returns a vector. The radian angle between N1 and N2 is replicated to each of the components.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector AngleBetweenNormals(XMVector n1, XMVector n2)
        {
            return XMVector4
                .Dot(n1, n2)
                .Clamp(XMGlobalConstants.NegativeOne, XMGlobalConstants.One)
                .ACos();
        }

        /// <summary>
        /// Compute the radian angle between two 4D vectors.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns a vector. The radian angle between V1 and V2 is replicated to each of the components.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector AngleBetweenVectors(XMVector v1, XMVector v2)
        {
            XMVector l1 = XMVector4.ReciprocalLength(v1);
            XMVector l2 = XMVector4.ReciprocalLength(v2);
            XMVector dot = XMVector4.Dot(v1, v2);

            l1 = XMVector.Multiply(l1, l2);

            return XMVector
                .Multiply(dot, l1)
                .Clamp(XMGlobalConstants.NegativeOne, XMGlobalConstants.One)
                .ACos();
        }

        /// <summary>
        /// Transforms a 4D vector by a matrix.
        /// </summary>
        /// <param name="v">The vector.</param>
        /// <param name="m">The transformation matrix.</param>
        /// <returns>Returns the transformed vector.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "m", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Transform(XMVector v, XMMatrix m)
        {
            float fx = (m.M11 * v.X) + (m.M21 * v.Y) + (m.M31 * v.Z) + (m.M41 * v.W);
            float fy = (m.M12 * v.X) + (m.M21 * v.Y) + (m.M31 * v.Z) + (m.M41 * v.W);
            float fz = (m.M13 * v.X) + (m.M21 * v.Y) + (m.M31 * v.Z) + (m.M41 * v.W);
            float fw = (m.M14 * v.X) + (m.M21 * v.Y) + (m.M31 * v.Z) + (m.M41 * v.W);

            return new XMVector(fx, fy, fz, fw);
        }
    }
}
