// <copyright file="XMVector2.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DXMath
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// The 2D vector functions provided by DirectXMath.
    /// </summary>
    public static unsafe class XMVector2
    {
        /// <summary>
        /// Tests whether two 2D vectors are equal.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns true if the 2D vectors are equal and false otherwise.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Equal(XMVector v1, XMVector v2)
        {
            return v1.X == v2.X && v1.Y == v2.Y;
        }

        /// <summary>
        /// Tests whether two 2D vectors are equal. In addition, this function returns a comparison value.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns a comparison value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMComparisonRecord EqualR(XMVector v1, XMVector v2)
        {
            uint cr = 0;

            if (v1.X == v2.X && v1.Y == v2.Y)
            {
                cr = XMComparisonRecord.MaskTrue;
            }
            else if (v1.X != v2.X && v1.Y != v2.Y)
            {
                cr = XMComparisonRecord.MaskFalse;
            }

            return new XMComparisonRecord(cr);
        }

        /// <summary>
        /// Tests whether two 2D vectors are equal, treating each component as an unsigned integer.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns true if the 2D vectors are equal and false otherwise.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EqualInt(XMVector v1, XMVector v2)
        {
            return ((uint*)&v1)[0] == ((uint*)&v2)[0]
                && ((uint*)&v1)[1] == ((uint*)&v2)[1];
        }

        /// <summary>
        /// Tests whether two 2D vectors are equal, treating each component as an unsigned integer. In addition, this function returns a comparison.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns a comparison value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMComparisonRecord EqualIntR(XMVector v1, XMVector v2)
        {
            uint cr = 0;

            if (((uint*)&v1)[0] == ((uint*)&v2)[0]
                && ((uint*)&v1)[1] == ((uint*)&v2)[1])
            {
                cr = XMComparisonRecord.MaskTrue;
            }
            else if (((uint*)&v1)[0] != ((uint*)&v2)[0]
                && ((uint*)&v1)[1] != ((uint*)&v2)[1])
            {
                cr = XMComparisonRecord.MaskFalse;
            }

            return new XMComparisonRecord(cr);
        }

        /// <summary>
        /// Tests whether one 2D vector is near another 2D vector.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <param name="epsilon">The tolerance value used for judging equality.</param>
        /// <returns>Returns true if the difference between components is less than Epsilon; returns false otherwise.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NearEqual(XMVector v1, XMVector v2, XMVector epsilon)
        {
            float dx = Math.Abs(v1.X - v2.X);
            float dy = Math.Abs(v1.Y - v2.Y);

            return dx <= epsilon.X
                && dy <= epsilon.Y;
        }

        /// <summary>
        /// Tests whether two 2D vectors are not equal.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns true if the 2D vectors are not equal and false otherwise.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NotEqual(XMVector v1, XMVector v2)
        {
            return v1.X != v2.X
                || v1.Y != v2.Y;
        }

        /// <summary>
        /// Test whether two vectors are not equal, treating each component as an unsigned integer.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns true if the 2D vectors are not equal and false otherwise.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NotEqualInt(XMVector v1, XMVector v2)
        {
            return ((uint*)&v1)[0] != ((uint*)&v2)[0]
                || ((uint*)&v1)[1] != ((uint*)&v2)[1];
        }

        /// <summary>
        /// Tests whether one 2D vector is greater than another 2D vector.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns true if V1 is greater than V2, and false otherwise. See the remarks section.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Greater(XMVector v1, XMVector v2)
        {
            return v1.X > v2.X
                && v1.Y > v2.Y;
        }

        /// <summary>
        /// Tests whether one 2D vector is greater than another 2D vector and returns a comparison value.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns a comparison value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMComparisonRecord GreaterR(XMVector v1, XMVector v2)
        {
            uint cr = 0;

            if (v1.X > v2.X && v1.Y > v2.Y)
            {
                cr = XMComparisonRecord.MaskTrue;
            }
            else if (v1.X <= v2.X && v1.Y <= v2.Y)
            {
                cr = XMComparisonRecord.MaskFalse;
            }

            return new XMComparisonRecord(cr);
        }

        /// <summary>
        /// Tests whether one 2D vector is greater-than-or-equal-to another 2D vector.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns true if V1 is greater-than-or-equal-to V2, and false otherwise.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool GreaterOrEqual(XMVector v1, XMVector v2)
        {
            return v1.X >= v2.X && v1.Y >= v2.Y;
        }

        /// <summary>
        /// Tests whether one 2D vector is greater-than-or-equal-to another 2D vector and returns a comparison value.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns a comparison value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMComparisonRecord GreaterOrEqualR(XMVector v1, XMVector v2)
        {
            uint cr = 0;

            if (v1.X >= v2.X && v1.Y >= v2.Y)
            {
                cr = XMComparisonRecord.MaskTrue;
            }
            else if (v1.X < v2.X && v1.Y < v2.Y)
            {
                cr = XMComparisonRecord.MaskFalse;
            }

            return new XMComparisonRecord(cr);
        }

        /// <summary>
        /// Tests whether one 2D vector is less than another 2D vector.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns true if V1 is less than V2 and false otherwise.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Less(XMVector v1, XMVector v2)
        {
            return v1.X < v2.X && v1.Y < v2.Y;
        }

        /// <summary>
        /// Tests whether one 2D vector is less-than-or-equal-to another 2D vector.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns true if V1 is less-than-or-equal to V2, and false otherwise.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool LessOrEqual(XMVector v1, XMVector v2)
        {
            return v1.X <= v2.X && v1.Y <= v2.Y;
        }

        /// <summary>
        /// Tests whether the components of a 2D vector are within set bounds.
        /// </summary>
        /// <param name="v">The 2D vector to test.</param>
        /// <param name="bounds">The 2D vector that determines the bounds.</param>
        /// <returns>Returns true if both the x and y-components of V are within the set bounds, and false otherwise.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool InBounds(XMVector v, XMVector bounds)
        {
            return v.X <= bounds.X && v.X >= -bounds.X
                && v.Y <= bounds.Y && v.Y >= -bounds.Y;
        }

        /// <summary>
        /// Tests whether any component of a 2D vector is a NaN.
        /// </summary>
        /// <param name="v">The vector.</param>
        /// <returns>Returns true if any component of V is a NaN, and false otherwise.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNaN(XMVector v)
        {
            return XMVector.IsNaN(v.X) || XMVector.IsNaN(v.Y);
        }

        /// <summary>
        /// Tests whether any component of a 2D vector is positive or negative infinity.
        /// </summary>
        /// <param name="v">The vector.</param>
        /// <returns>Returns true if any component of V is positive or negative infinity, and false otherwise.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsInfinite(XMVector v)
        {
            return XMVector.IsInfinite(v.X) || XMVector.IsInfinite(v.Y);
        }

        /// <summary>
        /// Computes the dot product between 2D vectors.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns a vector. The dot product between V1 and V2 is replicated into each component.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Dot(XMVector v1, XMVector v2)
        {
            return XMVector.Replicate((v1.X * v2.X) + (v1.Y * v2.Y));
        }

        /// <summary>
        /// Computes the 2D cross product.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns a vector. The 2D cross product is replicated into each component.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Cross(XMVector v1, XMVector v2)
        {
            //// [ V1.x*V2.y - V1.y*V2.x, V1.x*V2.y - V1.y*V2.x ]

            float cross = (v1.X * v2.Y) - (v1.Y - v2.X);

            return XMVector.Replicate(cross);
        }

        /// <summary>
        /// Computes the square of the length of a 2D vector.
        /// </summary>
        /// <param name="v">The 2D vector.</param>
        /// <returns>Returns a vector. The square of the length of V is replicated into each component.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector LengthSquare(XMVector v)
        {
            return XMVector2.Dot(v, v);
        }

        /// <summary>
        /// Estimates the reciprocal of the length of a 2D vector.
        /// </summary>
        /// <param name="v">The 2D vector.</param>
        /// <returns>Returns a vector, each of whose components are estimates of the reciprocal of the length of V.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector ReciprocalLengthEst(XMVector v)
        {
            return XMVector2.LengthSquare(v)
                .ReciprocalSqrtEst();
        }

        /// <summary>
        /// Computes the reciprocal of the length of a 2D vector.
        /// </summary>
        /// <param name="v">The 2D vector.</param>
        /// <returns>Returns the reciprocal of the length of V.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector ReciprocalLength(XMVector v)
        {
            return XMVector2.LengthSquare(v)
                .ReciprocalSqrt();
        }

        /// <summary>
        /// Estimates the length of a 2D vector.
        /// </summary>
        /// <param name="v">The 2D vector.</param>
        /// <returns>Returns a vector, each of whose components are estimates of the length of V.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector LengthEst(XMVector v)
        {
            return XMVector2.LengthSquare(v)
                .SqrtEst();
        }

        /// <summary>
        /// Computes the length of a 2D vector.
        /// </summary>
        /// <param name="v">The 2D vector.</param>
        /// <returns>Returns a vector. The length of V is replicated into each component.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Length(XMVector v)
        {
            return XMVector2.LengthSquare(v)
                .Sqrt();
        }

        /// <summary>
        /// Estimates the normalized version of a 2D vector.
        /// </summary>
        /// <param name="v">The 2D vector.</param>
        /// <returns>Returns an estimate of the normalized version of V.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector NormalizeEst(XMVector v)
        {
            //// XMVector2NormalizeEst uses a reciprocal estimate and
            //// returns QNaN on zero and infinite vectors.

            XMVector result;
            result = XMVector2.ReciprocalLength(v);
            result = XMVector.Multiply(v, result);
            return result;
        }

        /// <summary>
        /// Returns the normalized version of a 2D vector.
        /// </summary>
        /// <param name="v">The 2D vector.</param>
        /// <returns>Returns the normalized version of V.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Normalize(XMVector v)
        {
            XMVector result = XMVector2.Length(v);
            float length = result.X;

            // Prevent divide by zero
            if (length > 0)
            {
                length = 1.0f / length;
            }

            result.X = v.X * length;
            result.Y = v.Y * length;
            result.Z = v.Z * length;
            result.W = v.W * length;

            return result;
        }

        /// <summary>
        /// Clamps the length of a 2D vector to a given range.
        /// </summary>
        /// <param name="v">The 2D vector.</param>
        /// <param name="lengthMin">Minimum clamp length.</param>
        /// <param name="lengthMax">Maximum clamp length.</param>
        /// <returns>Returns a 2D vector whose length is clamped to the specified minimum and maximum.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector ClampLength(XMVector v, float lengthMin, float lengthMax)
        {
            XMVector clampMax = XMVector.Replicate(lengthMax);
            XMVector clampMin = XMVector.Replicate(lengthMin);

            return XMVector2.ClampLengthV(v, clampMin, clampMax);
        }

        /// <summary>
        /// Clamps the length of a 2D vector to a given range.
        /// </summary>
        /// <param name="v">The 2D vector to clamp.</param>
        /// <param name="lengthMin">The 2D vector whose x and y-components are both equal to the minimum clamp length. The x and y-components must be greater-than-or-equal to zero.</param>
        /// <param name="lengthMax">The 2D vector whose x and y-components are both equal to the maximum clamp length. The x and y-components must be greater-than-or-equal to zero.</param>
        /// <returns>Returns a 2D vector whose length is clamped to the specified minimum and maximum.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector ClampLengthV(XMVector v, XMVector lengthMin, XMVector lengthMax)
        {
            Debug.Assert(lengthMin.Y == lengthMin.X, "Reviewed");
            Debug.Assert(lengthMax.Y == lengthMax.X, "Reviewed");
            Debug.Assert(XMVector2.GreaterOrEqual(lengthMin, XMGlobalConstants.Zero), "Reviewed");
            Debug.Assert(XMVector2.GreaterOrEqual(lengthMax, XMGlobalConstants.Zero), "Reviewed");
            Debug.Assert(XMVector2.GreaterOrEqual(lengthMax, lengthMin), "Reviewed");

            XMVector lengthSq = XMVector2.LengthSquare(v);
            XMVector zero = XMVector.Zero;
            XMVector reciprocalLength = lengthSq.ReciprocalSqrt();

            XMVector infiniteLength = XMVector.EqualInt(lengthSq, XMGlobalConstants.Infinity);
            XMVector zeroLength = XMVector.Equal(lengthSq, zero);

            XMVector length = XMVector.Multiply(lengthSq, reciprocalLength);
            XMVector normal = XMVector.Multiply(v, reciprocalLength);

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
        /// Reflects an incident 2D vector across a 2D normal vector.
        /// </summary>
        /// <param name="incident">The 2D incident vector to reflect.</param>
        /// <param name="normal">The 2D normal vector to reflect the incident vector across.</param>
        /// <returns>Returns the reflected incident angle.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Reflect(XMVector incident, XMVector normal)
        {
            //// Result = Incident - (2 * dot(Incident, Normal)) * Normal

            XMVector result;
            result = XMVector2.Dot(incident, normal);
            result = XMVector.Add(result, result);
            result = XMVector.NegativeMultiplySubtract(result, normal, incident);
            return result;
        }

        /// <summary>
        /// Refracts an incident 2D vector across a 2D normal vector.
        /// </summary>
        /// <param name="incident">The 2D incident vector to refract.</param>
        /// <param name="normal">The 2D normal vector to refract the incident vector through.</param>
        /// <param name="refractionIndex">The index of refraction.</param>
        /// <returns>Returns the refracted incident vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Refract(XMVector incident, XMVector normal, float refractionIndex)
        {
            XMVector index = XMVector.Replicate(refractionIndex);
            return XMVector2.RefractV(incident, normal, index);
        }

        /// <summary>
        /// Refracts an incident 2D vector across a 2D normal vector.
        /// </summary>
        /// <param name="incident">The 2D incident vector to refract.</param>
        /// <param name="normal">The 2D normal vector to refract the incident vector through.</param>
        /// <param name="refractionIndex">The 2D vector whose x and y-components are both equal to the index of refraction.</param>
        /// <returns>Returns the refracted incident vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector RefractV(XMVector incident, XMVector normal, XMVector refractionIndex)
        {
            //// Result = RefractionIndex * Incident - Normal * (RefractionIndex * dot(Incident, Normal) + 
            //// sqrt(1 - RefractionIndex * RefractionIndex * (1 - dot(Incident, Normal) * dot(Incident, Normal))))

            float incidentDotNormal = (incident.X * normal.X) + (incident.Y * normal.Y);

            // R = 1.0f - RefractionIndex * RefractionIndex * (1.0f - IDotN * IDotN)
            float rY = 1.0f - (incidentDotNormal * incidentDotNormal);
            float rX = 1.0f - (rY * refractionIndex.X * refractionIndex.X);
            rY = 1.0f - (rY * refractionIndex.Y * refractionIndex.Y);

            if (rX >= 0.0f)
            {
                rX = (refractionIndex.X * refractionIndex.X) - (normal.X * ((refractionIndex.X * incidentDotNormal) + (float)Math.Sqrt(rX)));
            }
            else
            {
                rX = 0.0f;
            }

            if (rY >= 0.0f)
            {
                rY = (refractionIndex.Y * incident.Y) - (normal.Y * ((refractionIndex.Y * incidentDotNormal) + (float)Math.Sqrt(rY)));
            }
            else
            {
                rY = 0.0f;
            }

            return new XMVector(rX, rY, 0.0f, 0.0f);
        }

        /// <summary>
        /// Computes a vector perpendicular to a 2D vector.
        /// </summary>
        /// <param name="v">The 2D vector.</param>
        /// <returns>Returns the 2D vector orthogonal to V.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Orthogonal(XMVector v)
        {
            return new XMVector(-v.Y, v.X, 0.0f, 0.0f);
        }

        /// <summary>
        /// Estimates the radian angle between two normalized 2D vectors.
        /// </summary>
        /// <param name="n1">The first vector.</param>
        /// <param name="n2">The second vector.</param>
        /// <returns>Returns a vector. The estimate of the radian angle (between N1 and N2) is replicated to each of the components.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector AngleBetweenNormalsEst(XMVector n1, XMVector n2)
        {
            return XMVector2.Dot(n1, n2)
                .Clamp(XMGlobalConstants.NegativeOne, XMGlobalConstants.One)
                .ACosEst();
        }

        /// <summary>
        /// Computes the radian angle between two normalized 2D vectors.
        /// </summary>
        /// <param name="n1">The first vector.</param>
        /// <param name="n2">The second vector.</param>
        /// <returns>Returns a vector. The radian angle between N1 and N2 is replicated to each of the components.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector AngleBetweenNormals(XMVector n1, XMVector n2)
        {
            return XMVector2.Dot(n1, n2)
                .Clamp(XMGlobalConstants.NegativeOne, XMGlobalConstants.One)
                .ACos();
        }

        /// <summary>
        /// Computes the radian angle between two 2D vectors.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns a vector. The radian angle between V1 and V2 is replicated to each of the components.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector AngleBetweenVectors(XMVector v1, XMVector v2)
        {
            XMVector l1 = XMVector2.ReciprocalLength(v1);
            XMVector l2 = XMVector2.ReciprocalLength(v2);
            XMVector dot = XMVector2.Dot(v1, v2);

            l1 = XMVector.Multiply(l1, l2);

            return XMVector.Multiply(dot, l1)
                .Clamp(XMGlobalConstants.NegativeOne, XMGlobalConstants.One)
                .ACos();
        }

        /// <summary>
        /// Computes the minimum distance between a line and a point.
        /// </summary>
        /// <param name="linePoint1">2D vector describing a first point on the line.</param>
        /// <param name="linePoint2">2D vector describing a second point on the line.</param>
        /// <param name="point">2D vector describing the reference point.</param>
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

            XMVector lengthSq = XMVector2.LengthSquare(lineVector);

            XMVector pointProjectionScale = XMVector2.Dot(pointVector, lineVector);
            pointProjectionScale = XMVector.Divide(pointProjectionScale, lengthSq);

            XMVector distanceVector = XMVector.Multiply(lineVector, pointProjectionScale);
            distanceVector = XMVector.Subtract(pointVector, distanceVector);

            return XMVector2.Length(distanceVector);
        }

        /// <summary>
        /// Finds the intersection of two lines.
        /// </summary>
        /// <param name="line1Point1">2D vector describing the first point on the first line.</param>
        /// <param name="line1Point2">2D vector describing a second point on the first line.</param>
        /// <param name="line2Point1">2D vector describing the first point on the second line.</param>
        /// <param name="line2Point2">2D vector describing a second point on the second line.</param>
        /// <returns>Returns the intersection point. If the lines are parallel, the returned vector will be a NaN. If the two lines are coincident, the returned vector will be positive infinity.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector IntersectLine(XMVector line1Point1, XMVector line1Point2, XMVector line2Point1, XMVector line2Point2)
        {
            XMVector v1 = XMVector.Subtract(line1Point2, line1Point1);
            XMVector v2 = XMVector.Subtract(line2Point2, line2Point1);
            XMVector v3 = XMVector.Subtract(line1Point1, line2Point1);

            XMVector c1 = XMVector2.Cross(v1, v2);
            XMVector c2 = XMVector2.Cross(v2, v3);

            XMVector result;
            XMVector zero = XMVector.Zero;

            if (XMVector2.NearEqual(c1, zero, XMGlobalConstants.Epsilon))
            {
                if (XMVector2.NearEqual(c2, zero, XMGlobalConstants.Epsilon))
                {
                    // Coincident
                    result = XMGlobalConstants.Infinity;
                }
                else
                {
                    // Parallel
                    result = XMGlobalConstants.QNaN;
                }
            }
            else
            {
                //// Intersection point = Line1Point1 + V1 * (C2 / C1)

                XMVector scale = c1.Reciprocal();
                scale = XMVector.Multiply(c2, scale);

                result = XMVector.MultiplyAdd(v1, scale, line1Point1);
            }

            return result;
        }

        /// <summary>
        /// Transforms a 2D vector by a matrix.
        /// </summary>
        /// <param name="v">The 2D vector.</param>
        /// <param name="m">The transformation matrix.</param>
        /// <returns>Returns the transformed vector.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "m", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Transform(XMVector v, XMMatrix m)
        {
            XMVector y = XMVector.SplatY(v);
            XMVector x = XMVector.SplatX(v);

            XMVector result = XMVector.MultiplyAdd(y, ((XMVector*)&m)[1], ((XMVector*)&m)[3]);
            result = XMVector.MultiplyAdd(x, ((XMVector*)&m)[0], result);

            return result;
        }

        /// <summary>
        /// Transforms a 2D vector by a given matrix, projecting the result back into w = 1.
        /// </summary>
        /// <param name="v">The 2D vector.</param>
        /// <param name="m">The transformation matrix.</param>
        /// <returns>Returns the transformed vector.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "m", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector TransformCoord(XMVector v, XMMatrix m)
        {
            XMVector y = XMVector.SplatY(v);
            XMVector x = XMVector.SplatX(v);

            XMVector result = XMVector.MultiplyAdd(y, ((XMVector*)&m)[1], ((XMVector*)&m)[3]);
            result = XMVector.MultiplyAdd(x, ((XMVector*)&m)[0], result);

            XMVector w = XMVector.SplatW(result);
            return XMVector.Divide(result, w);
        }

        /// <summary>
        /// Transforms the 2D vector normal by the given matrix.
        /// </summary>
        /// <param name="v">The 2D normal vector.</param>
        /// <param name="m">The transformation matrix.</param>
        /// <returns>Returns the transformed vector.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "m", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector TransformNormal(XMVector v, XMMatrix m)
        {
            XMVector y = XMVector.SplatY(v);
            XMVector x = XMVector.SplatX(v);

            XMVector result = XMVector.Multiply(y, ((XMVector*)&m)[1]);
            result = XMVector.MultiplyAdd(x, ((XMVector*)&m)[0], result);

            return result;
        }
    }
}
