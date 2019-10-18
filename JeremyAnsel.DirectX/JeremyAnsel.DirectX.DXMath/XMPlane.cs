// <copyright file="XMPlane.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DXMath
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// The plane functions provided by DirectXMath.
    /// </summary>
    /// <remarks>
    /// These functions use an <see cref="XMVector"/> 4-vector to represent the coefficients of the plane equation, <c>Ax+By+Cz+D = 0</c>, where the X-component is A, the Y-component is B, the Z-component is C, and the W-component is D.
    /// </remarks>
    public static unsafe class XMPlane
    {
        /// <summary>
        /// Determines if two planes are equal.
        /// </summary>
        /// <param name="p1">The first plane.</param>
        /// <param name="p2">The second plane.</param>
        /// <returns>Returns true if the two planes are equal and false otherwise.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Equal(XMVector p1, XMVector p2)
        {
            return XMVector4.Equal(p1, p2);
        }

        /// <summary>
        /// Determines whether two planes are nearly equal.
        /// </summary>
        /// <param name="p1">The first plane.</param>
        /// <param name="p2">The second plane.</param>
        /// <param name="epsilon">the component-wise tolerance to use.</param>
        /// <returns>Returns true if P1 is nearly equal to P2 and false otherwise.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NearEqual(XMVector p1, XMVector p2, XMVector epsilon)
        {
            XMVector np1 = XMPlane.Normalize(p1);
            XMVector np2 = XMPlane.Normalize(p2);

            return XMVector4.NearEqual(np1, np2, epsilon);
        }

        /// <summary>
        /// Determines if two planes are unequal.
        /// </summary>
        /// <param name="p1">The first plane.</param>
        /// <param name="p2">The second plane.</param>
        /// <returns>Returns true if the two planes are unequal and false otherwise.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NotEqual(XMVector p1, XMVector p2)
        {
            return XMVector4.NotEqual(p1, p2);
        }

        /// <summary>
        /// Tests whether any of the coefficients of a plane is a NaN.
        /// </summary>
        /// <param name="p">The plane.</param>
        /// <returns>Returns true if any of the coefficients of the plane is a NaN, and false otherwise.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "p", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNaN(XMVector p)
        {
            return XMVector4.IsNaN(p);
        }

        /// <summary>
        /// Tests whether any of the coefficients of a plane is positive or negative infinity.
        /// </summary>
        /// <param name="p">The plane.</param>
        /// <returns>Returns true if any of the coefficients of the plane is positive or negative infinity, and false otherwise.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "p", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsInfinite(XMVector p)
        {
            return XMVector4.IsInfinite(p);
        }

        /// <summary>
        /// Calculates the dot product between an input plane and a 4D vector.
        /// </summary>
        /// <param name="p">The plane.</param>
        /// <param name="v">The 4D vector to use in the dot product.</param>
        /// <returns>Returns the dot product of P and V replicated into each of the four components of the returned <see cref="XMVector"/>.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "p", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Dot(XMVector p, XMVector v)
        {
            return XMVector4.Dot(p, v);
        }

        /// <summary>
        /// Calculates the dot product between an input plane and a 3D vector.
        /// </summary>
        /// <param name="p">The plane.</param>
        /// <param name="v">3D vector to use in the dot product. The w component of V is always treated as if is 1.0f.</param>
        /// <returns>Returns the dot product between P and V replicated into each of the four components of the returned <see cref="XMVector"/>.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "p", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector DotCoord(XMVector p, XMVector v)
        {
            //// Result = P[0] * V[0] + P[1] * V[1] + P[2] * V[2] + P[3]

            XMVector v3 = XMVector.Select(XMGlobalConstants.One, v, XMGlobalConstants.Select1110);
            return XMVector4.Dot(p, v3);
        }

        /// <summary>
        /// Calculates the dot product between the normal vector of a plane and a 3D vector.
        /// </summary>
        /// <param name="p">The plane.</param>
        /// <param name="v">3D vector to use in the dot product. The w component of V is always treated as if is 0.0f.</param>
        /// <returns>Returns the dot product between the normal vector of the plane and V replicated into each of the four components of the returned <see cref="XMVector"/>.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "p", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector DotNormal(XMVector p, XMVector v)
        {
            return XMVector3.Dot(p, v);
        }

        /// <summary>
        /// Estimates the coefficients of a plane so that coefficients of x, y, and z form a unit normal vector.
        /// </summary>
        /// <param name="p">The plane.</param>
        /// <returns>Returns an estimation of the normalized plane.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "p", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector NormalizeEst(XMVector p)
        {
            //// XMPlaneNormalizeEst uses a reciprocal estimate and
            //// returns QNaN on zero and infinite vectors.

            XMVector result = XMVector3.ReciprocalLengthEst(p);
            return XMVector.Multiply(p, result);
        }

        /// <summary>
        /// Normalizes the coefficients of a plane so that coefficients of x, y, and z form a unit normal vector.
        /// </summary>
        /// <param name="p">The plane.</param>
        /// <returns>Returns the normalized plane.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "p", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Normalize(XMVector p)
        {
            float lengthSq = (float)Math.Sqrt((p.X * p.X) + (p.Y * p.Y) + (p.Z * p.Z));

            // Prevent divide by zero
            if (lengthSq > 0)
            {
                lengthSq = 1.0f / lengthSq;
            }

            return new XMVector(
                p.X * lengthSq,
                p.Y * lengthSq,
                p.Z * lengthSq,
                p.W * lengthSq);
        }

        /// <summary>
        /// Finds the intersection between a plane and a line.
        /// </summary>
        /// <param name="p">The plane</param>
        /// <param name="linePoint1">The first point on the line.</param>
        /// <param name="linePoint2">The second point on the line.</param>
        /// <returns>Returns the intersection of the plane P and the line defined by LinePoint1 and LinePoint2. If the line is parallel to the plane, all components of the returned vector are equal to QNaN.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "p", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector IntersectLine(XMVector p, XMVector linePoint1, XMVector linePoint2)
        {
            XMVector v1 = XMVector3.Dot(p, linePoint1);
            XMVector v2 = XMVector3.Dot(p, linePoint2);
            XMVector d = XMVector.Subtract(v1, v2);

            XMVector vt = XMPlane.DotCoord(p, linePoint1);
            vt = XMVector.Divide(vt, d);

            XMVector point = XMVector.Subtract(linePoint2, linePoint1);
            point = XMVector.MultiplyAdd(point, vt, linePoint1);

            XMVector control = XMVector.NearEqual(d, XMGlobalConstants.Zero, XMGlobalConstants.Epsilon);
            return XMVector.Select(point, XMGlobalConstants.QNaN, control);
        }

        /// <summary>
        /// Finds the intersection of two planes.
        /// </summary>
        /// <param name="linePoint1">One point on the line of intersection.</param>
        /// <param name="linePoint2">A second point on the line of intersection.</param>
        /// <param name="p1">The first plane.</param>
        /// <param name="p2">The second plane.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IntersectPlane(out XMVector linePoint1, out XMVector linePoint2, XMVector p1, XMVector p2)
        {
            XMVector v1 = XMVector3.Cross(p2, p1);
            XMVector lengthSq = XMVector3.LengthSquare(v1);
            XMVector v2 = XMVector3.Cross(p2, v1);
            XMVector p1W = XMVector.SplatW(p1);
            XMVector point = XMVector.Multiply(v2, p1W);
            XMVector v3 = XMVector3.Cross(v1, p1);
            XMVector p2W = XMVector.SplatW(p2);
            point = XMVector.MultiplyAdd(v3, p2W, point);

            XMVector lineP1 = XMVector.Divide(point, lengthSq);
            XMVector lineP2 = XMVector.Add(lineP1, v1);

            XMVector control = XMVector.LessOrEqual(lengthSq, XMGlobalConstants.Epsilon);
            linePoint1 = XMVector.Select(lineP1, XMGlobalConstants.QNaN, control);
            linePoint2 = XMVector.Select(lineP2, XMGlobalConstants.QNaN, control);
        }

        /// <summary>
        /// Transforms a plane by a given matrix.
        /// </summary>
        /// <param name="p">The plane.</param>
        /// <param name="m">The transformation matrix.</param>
        /// <returns>Returns the transformed plane.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "p", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "m", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Transform(XMVector p, XMMatrix m)
        {
            XMVector w = XMVector.SplatW(p);
            XMVector z = XMVector.SplatZ(p);
            XMVector y = XMVector.SplatY(p);
            XMVector x = XMVector.SplatX(p);

            XMVector result = XMVector.Multiply(w, ((XMVector*)&m)[3]);
            result = XMVector.MultiplyAdd(z, ((XMVector*)&m)[2], result);
            result = XMVector.MultiplyAdd(y, ((XMVector*)&m)[1], result);
            result = XMVector.MultiplyAdd(x, ((XMVector*)&m)[0], result);

            return result;
        }

        /// <summary>
        /// Computes the equation of a plane constructed from a point in the plane and a normal vector.
        /// </summary>
        /// <param name="point">A point in the plane.</param>
        /// <param name="normal">The normal to the plane.</param>
        /// <returns>Returns a vector whose components are the coefficients of the plane.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector FromPointNormal(XMVector point, XMVector normal)
        {
            XMVector w = XMVector3
                .Dot(point, normal)
                .Negate();

            return XMVector.Select(w, normal, XMGlobalConstants.Select1110);
        }

        /// <summary>
        /// Computes the equation of a plane constructed from three points in the plane.
        /// </summary>
        /// <param name="point1">A first point in the plane.</param>
        /// <param name="point2">A second point in the plane.</param>
        /// <param name="point3">A third point in the plane.</param>
        /// <returns>Returns a vector whose components are the coefficients of the plane.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector FromPoints(XMVector point1, XMVector point2, XMVector point3)
        {
            XMVector v21 = XMVector.Subtract(point1, point2);
            XMVector v31 = XMVector.Subtract(point1, point3);

            XMVector n = XMVector3.Cross(v21, v31);
            n = XMVector3.Normalize(n);

            XMVector d = XMPlane
                .DotNormal(n, point1)
                .Negate();

            return XMVector.Select(d, n, XMGlobalConstants.Select1110);
        }
    }
}
