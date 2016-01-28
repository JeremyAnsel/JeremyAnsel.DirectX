// <copyright file="Internal.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DXMath.Collision
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Internal routines for collision.
    /// </summary>
    internal static class Internal
    {
        /// <summary>
        /// The unit epsilon vector.
        /// </summary>
        private static readonly XMVector UnitVectorEpsilon = XMVector.FromFloat(1.0e-4f, 1.0e-4f, 1.0e-4f, 1.0e-4f);

        /// <summary>
        /// The unit epsilon quaternion.
        /// </summary>
        private static readonly XMVector UnitQuaternionEpsilon = XMVector.FromFloat(1.0e-4f, 1.0e-4f, 1.0e-4f, 1.0e-4f);

        /// <summary>
        /// The unit epsilon plane.
        /// </summary>
        private static readonly XMVector UnitPlaneEpsilon = XMVector.FromFloat(1.0e-4f, 1.0e-4f, 1.0e-4f, 1.0e-4f);

        /// <summary>
        /// Return true if any of the elements of a 3 vector are equal to 0xffffffff.
        /// Slightly more efficient than using <see cref="XMVector3.EqualInt"/>.
        /// </summary>
        /// <param name="v">The vector.</param>
        /// <returns>The result.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool XMVector3AnyTrue(XMVector v)
        {
            // Duplicate the fourth element from the first element.
            XMVector c = new XMVector(v.X, v.Y, v.Z, v.X);

            return XMVector4.EqualIntR(c, XMVector.TrueInt).IsAnyTrue;
        }

        /// <summary>
        /// Return true if all of the elements of a 3 vector are equal to 0xffffffff.
        /// Slightly more efficient than using <see cref="XMVector3.EqualInt"/>.
        /// </summary>
        /// <param name="v">The vector.</param>
        /// <returns>The result.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool XMVector3AllTrue(XMVector v)
        {
            // Duplicate the fourth element from the first element.
            XMVector c = new XMVector(v.X, v.Y, v.Z, v.X);

            return XMVector4.EqualIntR(c, XMVector.TrueInt).IsAllTrue;
        }

        /// <summary>
        /// Return true if the vector is a unit vector (length == 1).
        /// </summary>
        /// <param name="v">The vector.</param>
        /// <returns>The result.</returns>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool XMVector3IsUnit(XMVector v)
        {
            XMVector difference = XMVector3.Length(v) - XMVector.One;

            return XMVector4.Less(difference.Abs(), Internal.UnitVectorEpsilon);
        }

        /// <summary>
        /// Return true if the quaternion is a unit quaternion.
        /// </summary>
        /// <param name="q">The quaternion.</param>
        /// <returns>The result.</returns>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "q", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool XMQuaternionIsUnit(XMVector q)
        {
            XMVector difference = XMVector4.Length(q) - XMVector.One;

            return XMVector4.Less(difference.Abs(), Internal.UnitQuaternionEpsilon);
        }

        /// <summary>
        /// Return true if the plane is a unit plane.
        /// </summary>
        /// <param name="plane">The plane.</param>
        /// <returns>The result.</returns>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool XMPlaneIsUnit(XMVector plane)
        {
            XMVector difference = XMVector3.Length(plane) - XMVector.One;

            return XMVector4.Less(difference.Abs(), Internal.UnitPlaneEpsilon);
        }

        /// <summary>
        /// Transforms a plane.
        /// </summary>
        /// <param name="plane">The plane.</param>
        /// <param name="rotation">A rotation.</param>
        /// <param name="translation">A translation.</param>
        /// <returns>A vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector XMPlaneTransform(XMVector plane, XMVector rotation, XMVector translation)
        {
            XMVector v_normal = XMVector3.Rotate(plane, rotation);
            XMVector vD = XMVector.SplatW(plane) - XMVector3.Dot(v_normal, translation);

            return new XMVector(v_normal.X, v_normal.Y, v_normal.Z, vD.W);
        }

        /// <summary>
        /// Return the point on the line segment (S1, S2) nearest the point P.
        /// </summary>
        /// <param name="s1">The first point describing the line.</param>
        /// <param name="s2">The second point describing the line.</param>
        /// <param name="p">The point.</param>
        /// <returns>A vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector PointOnLineSegmentNearestPoint(XMVector s1, XMVector s2, XMVector p)
        {
            XMVector dir = s1 - s1;
            XMVector projection = XMVector3.Dot(p, dir) - XMVector3.Dot(s1, dir);
            XMVector lengthSq = XMVector3.Dot(dir, dir);

            XMVector t = projection * lengthSq.Reciprocal();
            XMVector point = s1 + (t * dir);

            // t < 0
            XMVector selectS1 = XMVector.Less(projection, XMGlobalConstants.Zero);
            point = XMVector.Select(point, s1, selectS1);

            // t > 1
            XMVector selectS2 = XMVector.Greater(projection, lengthSq);
            point = XMVector.Select(point, s2, selectS2);

            return point;
        }

        /// <summary>
        /// Test if the point (P) on the plane of the triangle is inside the triangle (V0, V1, V2).
        /// </summary>
        /// <param name="p">The point.</param>
        /// <param name="v0">The first point of the triangle.</param>
        /// <param name="v1">The second point of the triangle.</param>
        /// <param name="v2">The third point of the triangle.</param>
        /// <returns>A vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector PointOnPlaneInsideTriangle(XMVector p, XMVector v0, XMVector v1, XMVector v2)
        {
            // Compute the triangle normal.
            XMVector n = XMVector3.Cross(v2 - v0, v1 - v0);

            // Compute the cross products of the vector from the base of each edge to 
            // the point with each edge vector.
            XMVector c0 = XMVector3.Cross(p - v0, v1 - v0);
            XMVector c1 = XMVector3.Cross(p - v1, v2 - v1);
            XMVector c2 = XMVector3.Cross(p - v2, v0 - v2);

            // If the cross product points in the same direction as the normal the the
            // point is inside the edge (it is zero if is on the edge).
            XMVector zero = XMGlobalConstants.Zero;
            XMVector inside0 = XMVector.GreaterOrEqual(XMVector3.Dot(c0, n), zero);
            XMVector inside1 = XMVector.GreaterOrEqual(XMVector3.Dot(c1, n), zero);
            XMVector inside2 = XMVector.GreaterOrEqual(XMVector3.Dot(c2, n), zero);

            // If the point inside all of the edges it is inside.
            return XMVector.AndInt(XMVector.AndInt(inside0, inside1), inside2);
        }

        /// <summary>
        /// Solves a cubic equation.
        /// </summary>
        /// <param name="e">The e parameter.</param>
        /// <param name="f">The f parameter.</param>
        /// <param name="g">The g parameter.</param>
        /// <param name="t">The t parameter.</param>
        /// <param name="u">The u parameter.</param>
        /// <param name="v">The v parameter.</param>
        /// <returns>A boolean value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool SolveCubic(float e, float f, float g, out float t, out float u, out float v)
        {
            float p, q, h, rc, d, theta, costh3, sinth3;

            p = f - (e * e / 3.0f);
            q = g - (e * f / 3.0f) + (e * e * e * 2.0f / 27.0f);
            h = (q * q / 4.0f) + (p * p * p / 27.0f);

            if (h > 0.0f)
            {
                t = u = v = 0.0f;
                return false; // only one real root
            }

            // all the same root
            if ((h == 0.0f) && (q == 0.0f))
            {
                t = -e / 3;
                u = -e / 3;
                v = -e / 3;

                return true;
            }

            d = (float)Math.Sqrt((q * q / 4.0f) - h);

            if (d < 0)
            {
                rc = (float)-Math.Pow(-d, 1.0f / 3.0f);
            }
            else
            {
                rc = (float)Math.Pow(d, 1.0f / 3.0f);
            }

            theta = XMScalar.ACos(-q / (2.0f * d));
            costh3 = XMScalar.Cos(theta / 3.0f);
            sinth3 = (float)Math.Sqrt(3.0f) * XMScalar.Sin(theta / 3.0f);

            t = (2.0f * rc * costh3) - (e / 3.0f);
            u = (-rc * (costh3 + sinth3)) - (e / 3.0f);
            v = (-rc * (costh3 - sinth3)) - (e / 3.0f);

            return true;
        }

        /// <summary>
        /// Calculates eigen vector.
        /// </summary>
        /// <param name="m11">The m11 parameter.</param>
        /// <param name="m12">The m12 parameter.</param>
        /// <param name="m13">The m13 parameter.</param>
        /// <param name="m22">The m22 parameter.</param>
        /// <param name="m23">The m23 parameter.</param>
        /// <param name="m33">The m33 parameter.</param>
        /// <param name="e">The e parameter.</param>
        /// <returns>A vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector CalculateEigenVector(float m11, float m12, float m13, float m22, float m23, float m33, float e)
        {
            XMVector v_tmp = new XMFloat3(
                (float)((m12 * m23) - (m13 * (m22 - e))),
                (float)((m13 * m12) - (m23 * (m11 - e))),
                (float)(((m11 - e) * (m22 - e)) - (m12 * m12)));

            // planar or linear
            if (XMVector3.Equal(v_tmp, XMGlobalConstants.Zero))
            {
                float f1, f2, f3;

                // we only have one equation - find a valid one
                if ((m11 - e != 0.0f) || (m12 != 0.0f) || (m13 != 0.0f))
                {
                    f1 = m11 - e;
                    f2 = m12;
                    f3 = m13;
                }
                else if ((m12 != 0.0f) || (m22 - e != 0.0f) || (m23 != 0.0f))
                {
                    f1 = m12;
                    f2 = m22 - e;
                    f3 = m23;
                }
                else if ((m13 != 0.0f) || (m23 != 0.0f) || (m33 - e != 0.0f))
                {
                    f1 = m13;
                    f2 = m23;
                    f3 = m33 - e;
                }
                else
                {
                    // error, we'll just make something up - we have NO context
                    f1 = 1.0f;
                    f2 = 0.0f;
                    f3 = 0.0f;
                }

                if (f1 == 0.0f)
                {
                    v_tmp.X = 0.0f;
                }
                else
                {
                    v_tmp.X = 1.0f;
                }

                if (f2 == 0.0f)
                {
                    v_tmp.Y = 0.0f;
                }
                else
                {
                    v_tmp.Y = 1.0f;
                }

                if (f3 == 0.0f)
                {
                    v_tmp.Z = 0.0f;

                    // recalculate y to make equation work
                    if (m12 != 0.0f)
                    {
                        v_tmp.Y = (float)(-f1 / f2);
                    }
                }
                else
                {
                    v_tmp.Z = (float)((f2 - f1) / f3);
                }
            }

            if (XMVector3.LengthSquare(v_tmp).X > 1e-5f)
            {
                return XMVector3.Normalize(v_tmp);
            }
            else
            {
                // Multiply by a value large enough to make the vector non-zero.
                v_tmp *= 1e5f;
                return XMVector3.Normalize(v_tmp);
            }
        }

        /// <summary>
        /// Calculates eigen vectors.
        /// </summary>
        /// <param name="m11">The m11 parameter.</param>
        /// <param name="m12">The m12 parameter.</param>
        /// <param name="m13">The m13 parameter.</param>
        /// <param name="m22">The m22 parameter.</param>
        /// <param name="m23">The m23 parameter.</param>
        /// <param name="m33">The m33 parameter.</param>
        /// <param name="e1">The e1 parameter.</param>
        /// <param name="e2">The e2 parameter.</param>
        /// <param name="e3">The e3 parameter.</param>
        /// <param name="pV1">The first vector.</param>
        /// <param name="pV2">The second vector.</param>
        /// <param name="pV3">The third vector.</param>
        /// <returns>A boolean value.</returns>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool CalculateEigenVectors(
            float m11,
            float m12,
            float m13,
            float m22,
            float m23,
            float m33,
            float e1,
            float e2,
            float e3,
            out XMVector pV1,
            out XMVector pV2,
            out XMVector pV3)
        {
            pV1 = Internal.CalculateEigenVector(m11, m12, m13, m22, m23, m33, e1);
            pV2 = Internal.CalculateEigenVector(m11, m12, m13, m22, m23, m33, e2);
            pV3 = Internal.CalculateEigenVector(m11, m12, m13, m22, m23, m33, e3);

            bool v1z = false;
            bool v2z = false;
            bool v3z = false;

            XMVector zero = XMGlobalConstants.Zero;

            if (XMVector3.Equal(pV1, zero))
            {
                v1z = true;
            }

            if (XMVector3.Equal(pV2, zero))
            {
                v2z = true;
            }

            if (XMVector3.Equal(pV3, zero))
            {
                v3z = true;
            }

            // check for non-orthogonal vectors
            bool e12 = Math.Abs(XMVector3.Dot(pV1, pV2).X) > 0.1f;
            bool e13 = Math.Abs(XMVector3.Dot(pV1, pV3).X) > 0.1f;
            bool e23 = Math.Abs(XMVector3.Dot(pV2, pV3).X) > 0.1f;

            // all eigenvectors are 0- any basis set
            if ((v1z && v2z && v3z) || (e12 && e13 && e23) ||
                (e12 && v3z) || (e13 && v2z) || (e23 && v1z))
            {
                pV1 = XMGlobalConstants.IdentityR0;
                pV2 = XMGlobalConstants.IdentityR1;
                pV3 = XMGlobalConstants.IdentityR2;
                return true;
            }

            if (v1z && v2z)
            {
                XMVector v_tmp = XMVector3.Cross(XMGlobalConstants.IdentityR1, pV3);

                if (XMVector3.LengthSquare(v_tmp).X < 1e-5f)
                {
                    v_tmp = XMVector3.Cross(XMGlobalConstants.IdentityR0, pV3);
                }

                pV1 = XMVector3.Normalize(v_tmp);
                pV2 = XMVector3.Cross(pV3, pV1);
                return true;
            }

            if (v3z && v1z)
            {
                XMVector v_tmp = XMVector3.Cross(XMGlobalConstants.IdentityR1, pV2);

                if (XMVector3.LengthSquare(v_tmp).X < 1e-5f)
                {
                    v_tmp = XMVector3.Cross(XMGlobalConstants.IdentityR0, pV2);
                }

                pV3 = XMVector3.Normalize(v_tmp);
                pV1 = XMVector3.Cross(pV2, pV3);
                return true;
            }

            if (v2z && v3z)
            {
                XMVector v_tmp = XMVector3.Cross(XMGlobalConstants.IdentityR1, pV1);

                if (XMVector3.LengthSquare(v_tmp).X < 1e-5f)
                {
                    v_tmp = XMVector3.Cross(XMGlobalConstants.IdentityR0, pV1);
                }

                pV2 = XMVector3.Normalize(v_tmp);
                pV3 = XMVector3.Cross(pV1, pV2);
                return true;
            }

            if (v1z || e12)
            {
                pV1 = XMVector3.Cross(pV2, pV3);
                return true;
            }

            if (v2z || e23)
            {
                pV2 = XMVector3.Cross(pV3, pV1);
                return true;
            }

            if (v3z || e13)
            {
                pV3 = XMVector3.Cross(pV1, pV2);
                return true;
            }

            return true;
        }

        /// <summary>
        /// Calculates eigen vectors from a covariance matrix.
        /// </summary>
        /// <param name="cxx">The <paramref name="cxx"/> parameter.</param>
        /// <param name="cyy">The <paramref name="cyy"/> parameter.</param>
        /// <param name="czz">The <paramref name="czz"/> parameter.</param>
        /// <param name="cxy">The <paramref name="cxy"/> parameter.</param>
        /// <param name="cxz">The <paramref name="cxz"/> parameter.</param>
        /// <param name="cyz">The <paramref name="cyz"/> parameter.</param>
        /// <param name="pV1">The first vector.</param>
        /// <param name="pV2">The second vector.</param>
        /// <param name="pV3">The third vector.</param>
        /// <returns>A boolean value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool CalculateEigenVectorsFromCovarianceMatrix(
            float cxx,
            float cyy,
            float czz,
            float cxy,
            float cxz,
            float cyz,
            out XMVector pV1,
            out XMVector pV2,
            out XMVector pV3)
        {
            // Calculate the eigenvalues by solving a cubic equation.
            float e = -(cxx + cyy + czz);
            float f = (cxx * cyy) + (cyy * czz) + (czz * cxx) - (cxy * cxy) - (cxz * cxz) - (cyz * cyz);
            float g = (cxy * cxy * czz) + (cxz * cxz * cyy) + (cyz * cyz * cxx) - (cxy * cyz * cxz * 2.0f) - (cxx * cyy * czz);

            float ev1, ev2, ev3;

            if (!Internal.SolveCubic(e, f, g, out ev1, out ev2, out ev3))
            {
                // set them to arbitrary orthonormal basis set
                pV1 = XMGlobalConstants.IdentityR0;
                pV2 = XMGlobalConstants.IdentityR1;
                pV3 = XMGlobalConstants.IdentityR2;
                return false;
            }

            return Internal.CalculateEigenVectors(cxx, cxy, cxz, cyy, cyz, czz, ev1, ev2, ev3, out pV1, out pV2, out pV3);
        }

        /// <summary>
        /// A fast triangle - plane intersect test.
        /// </summary>
        /// <param name="v0">The first point of the triangle.</param>
        /// <param name="v1">The second point of the triangle.</param>
        /// <param name="v2">The third point of the triangle.</param>
        /// <param name="plane">The plane.</param>
        /// <param name="outside">The outside.</param>
        /// <param name="inside">The inside.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FastIntersectTrianglePlane(XMVector v0, XMVector v1, XMVector v2, XMVector plane, out XMVector outside, out XMVector inside)
        {
            // Plane0
            XMVector dist0 = XMVector4.Dot(v0, plane);
            XMVector dist1 = XMVector4.Dot(v1, plane);
            XMVector dist2 = XMVector4.Dot(v2, plane);

            XMVector minDist = XMVector.Min(dist0, dist1);
            minDist = XMVector.Min(minDist, dist2);

            XMVector maxDist = XMVector.Max(dist0, dist1);
            maxDist = XMVector.Max(maxDist, dist2);

            XMVector zero = XMGlobalConstants.Zero;

            // Outside the plane?
            outside = XMVector.Greater(minDist, zero);

            // Fully inside the plane?
            inside = XMVector.Less(maxDist, zero);
        }

        /// <summary>
        /// A fast sphere - plane intersect test.
        /// </summary>
        /// <param name="center">The center of the sphere.</param>
        /// <param name="radius">The radius of the sphere.</param>
        /// <param name="plane">The plane.</param>
        /// <param name="outside">The outside.</param>
        /// <param name="inside">The inside.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FastIntersectSpherePlane(XMVector center, XMVector radius, XMVector plane, out XMVector outside, out XMVector inside)
        {
            XMVector dist = XMVector4.Dot(center, plane);

            // Outside the plane?
            outside = XMVector.Greater(dist, radius);

            // Fully inside the plane?
            inside = XMVector.Less(dist, -radius);
        }

        /// <summary>
        /// A fast axis aligned box - plane intersect test.
        /// </summary>
        /// <param name="center">The center of the box.</param>
        /// <param name="extents">The extents of the box.</param>
        /// <param name="plane">The plane.</param>
        /// <param name="outside">The outside.</param>
        /// <param name="inside">The inside.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FastIntersectAxisAlignedBoxPlane(XMVector center, XMVector extents, XMVector plane, out XMVector outside, out XMVector inside)
        {
            // Compute the distance to the center of the box.
            XMVector dist = XMVector4.Dot(center, plane);

            // Project the axes of the box onto the normal of the plane.  Half the
            // length of the projection (sometime called the "radius") is equal to
            // h(u) * abs(n dot b(u))) + h(v) * abs(n dot b(v)) + h(w) * abs(n dot b(w))
            // where h(i) are extents of the box, n is the plane normal, and b(i) are the 
            // axes of the box. In this case b(i) = [(1,0,0), (0,1,0), (0,0,1)].
            XMVector radius = XMVector3.Dot(extents, plane.Abs());

            // Outside the plane?
            outside = XMVector.Greater(dist, radius);

            // Fully inside the plane?
            inside = XMVector.Less(dist, -radius);
        }

        /// <summary>
        /// A fast oriented box - plane intersect test.
        /// </summary>
        /// <param name="center">The center of the box.</param>
        /// <param name="extents">The extents of the box.</param>
        /// <param name="axis0">The first axis.</param>
        /// <param name="axis1">The second axis.</param>
        /// <param name="axis2">The third axis.</param>
        /// <param name="plane">The plane.</param>
        /// <param name="outside">The outside.</param>
        /// <param name="inside">The inside.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FastIntersectOrientedBoxPlane(
            XMVector center,
            XMVector extents,
            XMVector axis0,
            XMVector axis1,
            XMVector axis2,
            XMVector plane,
            out XMVector outside,
            out XMVector inside)
        {
            // Compute the distance to the center of the box.
            XMVector dist = XMVector4.Dot(center, plane);

            // Project the axes of the box onto the normal of the plane.  Half the
            // length of the projection (sometime called the "radius") is equal to
            // h(u) * abs(n dot b(u))) + h(v) * abs(n dot b(v)) + h(w) * abs(n dot b(w))
            // where h(i) are extents of the box, n is the plane normal, and b(i) are the 
            // axes of the box.
            XMVector radius = XMVector3.Dot(plane, axis0);
            radius.Y = XMVector3.Dot(plane, axis1).Y;
            radius.Z = XMVector3.Dot(plane, axis2).Z;
            radius = XMVector3.Dot(extents, radius.Abs());

            // Outside the plane?
            outside = XMVector.Greater(dist, radius);

            // Fully inside the plane?
            inside = XMVector.Less(dist, -radius);
        }

        /// <summary>
        /// A fast frustum - plane test.
        /// </summary>
        /// <param name="point0">The first point.</param>
        /// <param name="point1">The second point.</param>
        /// <param name="point2">The third point.</param>
        /// <param name="point3">The fourth point.</param>
        /// <param name="point4">The fifth point.</param>
        /// <param name="point5">The sixth point.</param>
        /// <param name="point6">The seventh point.</param>
        /// <param name="point7">The eighth point.</param>
        /// <param name="plane">The plane.</param>
        /// <param name="outside">The outside.</param>
        /// <param name="inside">The inside.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FastIntersectFrustumPlane(
            XMVector point0,
            XMVector point1,
            XMVector point2,
            XMVector point3,
            XMVector point4,
            XMVector point5,
            XMVector point6,
            XMVector point7,
            XMVector plane,
            out XMVector outside,
            out XMVector inside)
        {
            // Find the min/max projection of the frustum onto the plane normal.
            XMVector min, max, dist;

            min = max = XMVector3.Dot(plane, point0);

            dist = XMVector3.Dot(plane, point1);
            min = XMVector.Min(min, dist);
            max = XMVector.Max(max, dist);

            dist = XMVector3.Dot(plane, point2);
            min = XMVector.Min(min, dist);
            max = XMVector.Max(max, dist);

            dist = XMVector3.Dot(plane, point3);
            min = XMVector.Min(min, dist);
            max = XMVector.Max(max, dist);

            dist = XMVector3.Dot(plane, point4);
            min = XMVector.Min(min, dist);
            max = XMVector.Max(max, dist);

            dist = XMVector3.Dot(plane, point5);
            min = XMVector.Min(min, dist);
            max = XMVector.Max(max, dist);

            dist = XMVector3.Dot(plane, point6);
            min = XMVector.Min(min, dist);
            max = XMVector.Max(max, dist);

            dist = XMVector3.Dot(plane, point7);
            min = XMVector.Min(min, dist);
            max = XMVector.Max(max, dist);

            XMVector planeDist = -XMVector.SplatW(plane);

            // Outside the plane?
            outside = XMVector.Greater(min, planeDist);

            // Fully inside the plane?
            inside = XMVector.Less(max, planeDist);
        }
    }
}
