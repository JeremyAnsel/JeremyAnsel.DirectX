// <copyright file="TriangleTest.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DXMath.Collision
{
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Triangle test functions.
    /// </summary>
    public static class TriangleTest
    {
        /// <summary>
        /// Test whether a triangle intersects with a ray.
        /// </summary>
        /// <param name="origin">The origin of the ray.</param>
        /// <param name="direction">The direction of the ray.</param>
        /// <param name="v0">The first vector defining the triangle.</param>
        /// <param name="v1">The second vector defining the triangle.</param>
        /// <param name="v2">The third vector defining the triangle.</param>
        /// <returns>A boolean value indicating whether the triangle intersects with the ray.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Intersects(XMVector origin, XMVector direction, XMVector v0, XMVector v1, XMVector v2)
        {
            float coordinateU;
            float coordinateV;
            float distance;
            return TriangleTest.Intersects(origin, direction, v0, v1, v2, out coordinateU, out coordinateV, out distance);
        }

        /// <summary>
        /// Test whether a triangle intersects with a ray.
        /// </summary>
        /// <param name="origin">The origin of the ray.</param>
        /// <param name="direction">The direction of the ray.</param>
        /// <param name="v0">The first vector defining the triangle.</param>
        /// <param name="v1">The second vector defining the triangle.</param>
        /// <param name="v2">The third vector defining the triangle.</param>
        /// <param name="distance">The distance along the ray where the intersection occurs.</param>
        /// <returns>A boolean value indicating whether the triangle intersects with the ray.</returns>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "5#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Intersects(XMVector origin, XMVector direction, XMVector v0, XMVector v1, XMVector v2, out float distance)
        {
            float coordinateU;
            float coordinateV;
            return TriangleTest.Intersects(origin, direction, v0, v1, v2, out coordinateU, out coordinateV, out distance);
        }

        /// <summary>
        /// Test whether a triangle intersects with a ray.
        /// </summary>
        /// <param name="origin">The origin of the ray.</param>
        /// <param name="direction">The direction of the ray.</param>
        /// <param name="v0">The first vector defining the triangle.</param>
        /// <param name="v1">The second vector defining the triangle.</param>
        /// <param name="v2">The third vector defining the triangle.</param>
        /// <param name="coordinateU">The first barycentric hit coordinate.</param>
        /// <param name="coordinateV">The second barycentric hit coordinate.</param>
        /// <param name="distance">The distance along the ray where the intersection occurs.</param>
        /// <returns>A boolean value indicating whether the triangle intersects with the ray.</returns>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "5#", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "6#", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "7#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Intersects(XMVector origin, XMVector direction, XMVector v0, XMVector v1, XMVector v2, out float coordinateU, out float coordinateV, out float distance)
        {
            Debug.Assert(Internal.XMVector3IsUnit(direction), "Reviewed");

            XMVector zero = XMGlobalConstants.Zero;

            XMVector e1 = v1 - v0;
            XMVector e2 = v2 - v0;

            // p = Direction ^ e2;
            XMVector p = XMVector3.Cross(direction, e2);

            // det = e1 * p;
            XMVector det = XMVector3.Dot(e1, p);

            XMVector u, v, t;

            if (XMVector3.GreaterOrEqual(det, CollisionGlobalConstants.RayEpsilon))
            {
                // Determinate is positive (front side of the triangle).
                XMVector s = origin - v0;

                // u = s * p;
                u = XMVector3.Dot(s, p);

                XMVector noIntersection = XMVector.Less(u, zero);
                noIntersection = XMVector.OrInt(noIntersection, XMVector.Greater(u, det));

                // q = s ^ e1;
                XMVector q = XMVector3.Cross(s, e1);

                // v = Direction * q;
                v = XMVector3.Dot(direction, q);

                noIntersection = XMVector.OrInt(noIntersection, XMVector.Less(v, zero));
                noIntersection = XMVector.OrInt(noIntersection, XMVector.Greater(u + v, det));

                // t = e2 * q;
                t = XMVector3.Dot(e2, q);

                noIntersection = XMVector.OrInt(noIntersection, XMVector.Less(t, zero));

                if (XMVector4.EqualInt(noIntersection, XMVector.TrueInt))
                {
                    coordinateU = 0.0f;
                    coordinateV = 0.0f;
                    distance = 0.0f;
                    return false;
                }
            }
            else if (XMVector3.LessOrEqual(det, CollisionGlobalConstants.RayNegEpsilon))
            {
                // Determinate is negative (back side of the triangle).
                XMVector s = origin - v0;

                // u = s * p;
                u = XMVector3.Dot(s, p);

                XMVector noIntersection = XMVector.Greater(u, zero);
                noIntersection = XMVector.OrInt(noIntersection, XMVector.Less(u, det));

                // q = s ^ e1;
                XMVector q = XMVector3.Cross(s, e1);

                // v = Direction * q;
                v = XMVector3.Dot(direction, q);

                noIntersection = XMVector.OrInt(noIntersection, XMVector.Greater(v, zero));
                noIntersection = XMVector.OrInt(noIntersection, XMVector.Less(u + v, det));

                // t = e2 * q;
                t = XMVector3.Dot(e2, q);

                noIntersection = XMVector.OrInt(noIntersection, XMVector.Greater(t, zero));

                if (XMVector4.EqualInt(noIntersection, XMVector.TrueInt))
                {
                    coordinateU = 0.0f;
                    coordinateV = 0.0f;
                    distance = 0.0f;
                    return false;
                }
            }
            else
            {
                // Parallel ray.
                coordinateU = 0.0f;
                coordinateV = 0.0f;
                distance = 0.0f;
                return false;
            }

            // (u / det) and (v / det) are the barycentric coordinates of the intersection.
            u = XMVector.Divide(u, det);
            v = XMVector.Divide(v, det);
            t = XMVector.Divide(t, det);

            // Store the x-component to *pDist
            u.StoreFloat(out coordinateU);
            v.StoreFloat(out coordinateV);
            t.StoreFloat(out distance);

            return true;
        }

        /// <summary>
        /// Test whether two triangles intersect.
        /// </summary>
        /// <param name="a0">The first vector defining triangle A.</param>
        /// <param name="a1">The second vector defining triangle A.</param>
        /// <param name="a2">The third vector defining triangle A.</param>
        /// <param name="b0">The first vector defining triangle B.</param>
        /// <param name="b1">The second vector defining triangle B.</param>
        /// <param name="b2">The third vector defining triangle B.</param>
        /// <returns>A boolean value indicating whether the triangles intersect.</returns>
        [SuppressMessage("Microsoft.Performance", "CA1809:AvoidExcessiveLocals", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Intersects(XMVector a0, XMVector a1, XMVector a2, XMVector b0, XMVector b1, XMVector b2)
        {
            XMVector selectY = XMVector.FromInt((uint)XMSelection.Select0, (uint)XMSelection.Select1, (uint)XMSelection.Select0, (uint)XMSelection.Select0);
            XMVector selectZ = XMVector.FromInt((uint)XMSelection.Select0, (uint)XMSelection.Select0, (uint)XMSelection.Select1, (uint)XMSelection.Select0);
            XMVector select0111 = XMVector.FromInt((uint)XMSelection.Select0, (uint)XMSelection.Select1, (uint)XMSelection.Select1, (uint)XMSelection.Select1);
            XMVector select1011 = XMVector.FromInt((uint)XMSelection.Select1, (uint)XMSelection.Select0, (uint)XMSelection.Select1, (uint)XMSelection.Select1);
            XMVector select1101 = XMVector.FromInt((uint)XMSelection.Select1, (uint)XMSelection.Select1, (uint)XMSelection.Select0, (uint)XMSelection.Select1);

            XMVector zero = XMGlobalConstants.Zero;

            // Compute the normal of triangle A.
            XMVector n1 = XMVector3.Cross(a1 - a0, a2 - a0);

            // Assert that the triangle is not degenerate.
            Debug.Assert(!XMVector3.Equal(n1, zero), "Reviewed");

            // Test points of B against the plane of A.
            XMVector b_dist = XMVector3.Dot(n1, b0 - a0);
            b_dist = XMVector.Select(b_dist, XMVector3.Dot(n1, b1 - a0), selectY);
            b_dist = XMVector.Select(b_dist, XMVector3.Dot(n1, b2 - a0), selectZ);

            // Ensure robustness with co-planar triangles by zeroing small distances.
            XMComparisonRecord b_distIsZeroCR;
            XMVector b_distIsZero = XMVector.GreaterR(out b_distIsZeroCR, CollisionGlobalConstants.RayEpsilon, b_dist.Abs());
            b_dist = XMVector.Select(b_dist, zero, b_distIsZero);

            XMComparisonRecord b_distIsLessCR;
            XMVector b_distIsLess = XMVector.GreaterR(out b_distIsLessCR, zero, b_dist);

            XMComparisonRecord b_distIsGreaterCR;
            XMVector b_distIsGreater = XMVector.GreaterR(out b_distIsGreaterCR, b_dist, zero);

            // If all the points are on the same side we don't intersect.
            if (b_distIsLessCR.IsAllTrue || b_distIsGreaterCR.IsAllTrue)
            {
                return false;
            }

            // Compute the normal of triangle B.
            XMVector n2 = XMVector3.Cross(b1 - b0, b2 - b0);

            // Assert that the triangle is not degenerate.
            Debug.Assert(!XMVector3.Equal(n2, zero), "Reviewed");

            // Test points of A against the plane of B.
            XMVector a_dist = XMVector3.Dot(n2, a0 - b0);
            a_dist = XMVector.Select(a_dist, XMVector3.Dot(n2, a1 - b0), selectY);
            a_dist = XMVector.Select(a_dist, XMVector3.Dot(n2, a2 - b0), selectZ);

            // Ensure robustness with co-planar triangles by zeroing small distances.
            XMComparisonRecord a_distIsZeroCR;
            XMVector a_distIsZero = XMVector.GreaterR(out a_distIsZeroCR, CollisionGlobalConstants.RayEpsilon, b_dist.Abs());
            a_dist = XMVector.Select(a_dist, zero, a_distIsZero);

            XMComparisonRecord a_distIsLessCR;
            XMVector a_distIsLess = XMVector.GreaterR(out a_distIsLessCR, zero, a_dist);

            XMComparisonRecord a_distIsGreaterCR;
            XMVector a_distIsGreater = XMVector.GreaterR(out a_distIsGreaterCR, a_dist, zero);

            // If all the points are on the same side we don't intersect.
            if (a_distIsLessCR.IsAllTrue || a_distIsGreaterCR.IsAllTrue)
            {
                return false;
            }

            // Special case for co-planar triangles.
            if (a_distIsZeroCR.IsAllTrue || b_distIsZeroCR.IsAllTrue)
            {
                XMVector axis, dist, minDist;

                // Compute an axis perpindicular to the edge (points out).
                axis = XMVector3.Cross(n1, a1 - a0);
                dist = XMVector3.Dot(axis, a0);

                // Test points of B against the axis.
                minDist = XMVector3.Dot(b0, axis);
                minDist = XMVector.Min(minDist, XMVector3.Dot(b1, axis));
                minDist = XMVector.Min(minDist, XMVector3.Dot(b2, axis));
                if (XMVector4.GreaterOrEqual(minDist, dist))
                {
                    return false;
                }

                // Edge (A1, A2)
                axis = XMVector3.Cross(n1, a2 - a1);
                dist = XMVector3.Dot(axis, a1);

                minDist = XMVector3.Dot(b0, axis);
                minDist = XMVector.Min(minDist, XMVector3.Dot(b1, axis));
                minDist = XMVector.Min(minDist, XMVector3.Dot(b2, axis));
                if (XMVector4.GreaterOrEqual(minDist, dist))
                {
                    return false;
                }

                // Edge (A2, A0)
                axis = XMVector3.Cross(n1, a0 - a2);
                dist = XMVector3.Dot(axis, a2);

                minDist = XMVector3.Dot(b0, axis);
                minDist = XMVector.Min(minDist, XMVector3.Dot(b1, axis));
                minDist = XMVector.Min(minDist, XMVector3.Dot(b2, axis));
                if (XMVector4.GreaterOrEqual(minDist, dist))
                {
                    return false;
                }

                // Edge (B0, B1)
                axis = XMVector3.Cross(n2, b1 - b0);
                dist = XMVector3.Dot(axis, b0);

                minDist = XMVector3.Dot(a0, axis);
                minDist = XMVector.Min(minDist, XMVector3.Dot(a1, axis));
                minDist = XMVector.Min(minDist, XMVector3.Dot(a2, axis));
                if (XMVector4.GreaterOrEqual(minDist, dist))
                {
                    return false;
                }

                // Edge (B1, B2)
                axis = XMVector3.Cross(n2, b2 - b1);
                dist = XMVector3.Dot(axis, b1);

                minDist = XMVector3.Dot(a0, axis);
                minDist = XMVector.Min(minDist, XMVector3.Dot(a1, axis));
                minDist = XMVector.Min(minDist, XMVector3.Dot(a2, axis));
                if (XMVector4.GreaterOrEqual(minDist, dist))
                {
                    return false;
                }

                // Edge (B2,B0)
                axis = XMVector3.Cross(n2, b0 - b2);
                dist = XMVector3.Dot(axis, b2);

                minDist = XMVector3.Dot(a0, axis);
                minDist = XMVector.Min(minDist, XMVector3.Dot(a1, axis));
                minDist = XMVector.Min(minDist, XMVector3.Dot(a2, axis));
                if (XMVector4.GreaterOrEqual(minDist, dist))
                {
                    return false;
                }

                return true;
            }

            //// Find the single vertex of A and B (ie the vertex on the opposite side
            //// of the plane from the other two) and reorder the edges so we can compute 
            //// the signed edge/edge distances.
            ////
            //// if ( (V0 >= 0 && V1 <  0 && V2 <  0) ||
            ////      (V0 >  0 && V1 <= 0 && V2 <= 0) ||
            ////      (V0 <= 0 && V1 >  0 && V2 >  0) ||
            ////      (V0 <  0 && V1 >= 0 && V2 >= 0) ) then V0 is singular;
            ////
            //// If our singular vertex is not on the positive side of the plane we reverse
            //// the triangle winding so that the overlap comparisons will compare the 
            //// correct edges with the correct signs.

            XMVector a_distIsLessEqual = XMVector.OrInt(a_distIsLess, a_distIsZero);
            XMVector a_distIsGreaterEqual = XMVector.OrInt(a_distIsGreater, a_distIsZero);

            XMVector aa0, aa1, aa2;
            bool b_positiveA;

            if (Internal.XMVector3AllTrue(XMVector.Select(a_distIsGreaterEqual, a_distIsLess, select0111)) ||
                Internal.XMVector3AllTrue(XMVector.Select(a_distIsGreater, a_distIsLessEqual, select0111)))
            {
                // A0 is singular, crossing from positive to negative.
                aa0 = a0;
                aa1 = a1;
                aa2 = a2;
                b_positiveA = true;
            }
            else if (Internal.XMVector3AllTrue(XMVector.Select(a_distIsLessEqual, a_distIsGreater, select0111)) ||
                     Internal.XMVector3AllTrue(XMVector.Select(a_distIsLess, a_distIsGreaterEqual, select0111)))
            {
                // A0 is singular, crossing from negative to positive.
                aa0 = a0;
                aa1 = a2;
                aa2 = a1;
                b_positiveA = false;
            }
            else if (Internal.XMVector3AllTrue(XMVector.Select(a_distIsGreaterEqual, a_distIsLess, select1011)) ||
                     Internal.XMVector3AllTrue(XMVector.Select(a_distIsGreater, a_distIsLessEqual, select1011)))
            {
                // A1 is singular, crossing from positive to negative.
                aa0 = a1;
                aa1 = a2;
                aa2 = a0;
                b_positiveA = true;
            }
            else if (Internal.XMVector3AllTrue(XMVector.Select(a_distIsLessEqual, a_distIsGreater, select1011)) ||
                     Internal.XMVector3AllTrue(XMVector.Select(a_distIsLess, a_distIsGreaterEqual, select1011)))
            {
                // A1 is singular, crossing from negative to positive.
                aa0 = a1;
                aa1 = a0;
                aa2 = a2;
                b_positiveA = false;
            }
            else if (Internal.XMVector3AllTrue(XMVector.Select(a_distIsGreaterEqual, a_distIsLess, select1101)) ||
                     Internal.XMVector3AllTrue(XMVector.Select(a_distIsGreater, a_distIsLessEqual, select1101)))
            {
                // A2 is singular, crossing from positive to negative.
                aa0 = a2;
                aa1 = a0;
                aa2 = a1;
                b_positiveA = true;
            }
            else if (Internal.XMVector3AllTrue(XMVector.Select(a_distIsLessEqual, a_distIsGreater, select1101)) ||
                     Internal.XMVector3AllTrue(XMVector.Select(a_distIsLess, a_distIsGreaterEqual, select1101)))
            {
                // A2 is singular, crossing from negative to positive.
                aa0 = a2;
                aa1 = a1;
                aa2 = a0;
                b_positiveA = false;
            }
            else
            {
                Debug.Assert(false, "Reviewed");
                return false;
            }

            XMVector b_distIsLessEqual = XMVector.OrInt(b_distIsLess, b_distIsZero);
            XMVector b_distIsGreaterEqual = XMVector.OrInt(b_distIsGreater, b_distIsZero);

            XMVector bb0, bb1, bb2;
            bool b_positiveB;

            if (Internal.XMVector3AllTrue(XMVector.Select(b_distIsGreaterEqual, b_distIsLess, select0111)) ||
                Internal.XMVector3AllTrue(XMVector.Select(b_distIsGreater, b_distIsLessEqual, select0111)))
            {
                // B0 is singular, crossing from positive to negative.
                bb0 = b0;
                bb1 = b1;
                bb2 = b2;
                b_positiveB = true;
            }
            else if (Internal.XMVector3AllTrue(XMVector.Select(b_distIsLessEqual, b_distIsGreater, select0111)) ||
                     Internal.XMVector3AllTrue(XMVector.Select(b_distIsLess, b_distIsGreaterEqual, select0111)))
            {
                // B0 is singular, crossing from negative to positive.
                bb0 = b0;
                bb1 = b2;
                bb2 = b1;
                b_positiveB = false;
            }
            else if (Internal.XMVector3AllTrue(XMVector.Select(b_distIsGreaterEqual, b_distIsLess, select1011)) ||
                     Internal.XMVector3AllTrue(XMVector.Select(b_distIsGreater, b_distIsLessEqual, select1011)))
            {
                // B1 is singular, crossing from positive to negative.
                bb0 = b1;
                bb1 = b2;
                bb2 = b0;
                b_positiveB = true;
            }
            else if (Internal.XMVector3AllTrue(XMVector.Select(b_distIsLessEqual, b_distIsGreater, select1011)) ||
                     Internal.XMVector3AllTrue(XMVector.Select(b_distIsLess, b_distIsGreaterEqual, select1011)))
            {
                // B1 is singular, crossing from negative to positive.
                bb0 = b1;
                bb1 = b0;
                bb2 = b2;
                b_positiveB = false;
            }
            else if (Internal.XMVector3AllTrue(XMVector.Select(b_distIsGreaterEqual, b_distIsLess, select1101)) ||
                     Internal.XMVector3AllTrue(XMVector.Select(b_distIsGreater, b_distIsLessEqual, select1101)))
            {
                // B2 is singular, crossing from positive to negative.
                bb0 = b2;
                bb1 = b0;
                bb2 = b1;
                b_positiveB = true;
            }
            else if (Internal.XMVector3AllTrue(XMVector.Select(b_distIsLessEqual, b_distIsGreater, select1101)) ||
                     Internal.XMVector3AllTrue(XMVector.Select(b_distIsLess, b_distIsGreaterEqual, select1101)))
            {
                // B2 is singular, crossing from negative to positive.
                bb0 = b2;
                bb1 = b1;
                bb2 = b0;
                b_positiveB = false;
            }
            else
            {
                Debug.Assert(false, "Reviewed");
                return false;
            }

            XMVector delta0, delta1;

            // Reverse the direction of the test depending on whether the singular vertices are
            // the same sign or different signs.
            if (b_positiveA ^ b_positiveB)
            {
                delta0 = bb0 - aa0;
                delta1 = aa0 - bb0;
            }
            else
            {
                delta0 = aa0 - bb0;
                delta1 = bb0 - aa0;
            }

            // Check if the triangles overlap on the line of intersection between the
            // planes of the two triangles by finding the signed line distances.
            XMVector dist0 = XMVector3.Dot(delta0, XMVector3.Cross(bb2 - bb0, aa2 - aa0));
            if (XMVector4.Greater(dist0, zero))
            {
                return false;
            }

            XMVector dist1 = XMVector3.Dot(delta1, XMVector3.Cross(bb1 - bb0, aa1 - aa0));
            if (XMVector4.Greater(dist1, zero))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Tests whether a triangle and a plane intersect.
        /// </summary>
        /// <param name="v0">The first vector defining a triangle.</param>
        /// <param name="v1">The second vector defining a triangle.</param>
        /// <param name="v2">The third vector defining a triangle.</param>
        /// <param name="plane">A vector defining a plane.</param>
        /// <returns>A <see cref="PlaneIntersectionType"/> value indicating whether the triangle intersects the plane.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PlaneIntersectionType Intersects(XMVector v0, XMVector v1, XMVector v2, XMVector plane)
        {
            XMVector one = XMGlobalConstants.One;

            Debug.Assert(Internal.XMPlaneIsUnit(plane), "Reviewed");

            // Set w of the points to one so we can dot4 with a plane.
            XMVector tV0 = new XMVector(v0.X, v0.Y, v0.Z, one.W);
            XMVector tV1 = new XMVector(v1.X, v1.Y, v1.Z, one.W);
            XMVector tV2 = new XMVector(v2.X, v2.Y, v2.Z, one.W);

            XMVector outside, inside;
            Internal.FastIntersectTrianglePlane(tV0, tV1, tV2, plane, out outside, out inside);

            // If the triangle is outside any plane it is outside.
            if (XMVector4.EqualInt(outside, XMVector.TrueInt))
            {
                return PlaneIntersectionType.Front;
            }

            // If the triangle is inside all planes it is inside.
            if (XMVector4.EqualInt(inside, XMVector.TrueInt))
            {
                return PlaneIntersectionType.Back;
            }

            // The triangle is not inside all planes or outside a plane it intersects.
            return PlaneIntersectionType.Intersecting;
        }

        /// <summary>
        /// Tests whether a triangle is contained within six planes (typically a frustum).
        /// </summary>
        /// <param name="v0">The first vector defining the triangle.</param>
        /// <param name="v1">The second vector defining the triangle.</param>
        /// <param name="v2">The third vector defining the triangle.</param>
        /// <param name="plane0">A vector defining the first plane.</param>
        /// <param name="plane1">A vector defining the second plane.</param>
        /// <param name="plane2">A vector defining the third plane.</param>
        /// <param name="plane3">A vector defining the fourth plane.</param>
        /// <param name="plane4">A vector defining the fifth plane.</param>
        /// <param name="plane5">A vector defining the sixth plane.</param>
        /// <returns>A <see cref="ContainmentType"/> value indicating whether the triangle is contained within the planes.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ContainmentType ContainedBy(
            XMVector v0,
            XMVector v1,
            XMVector v2,
            XMVector plane0,
            XMVector plane1,
            XMVector plane2,
            XMVector plane3,
            XMVector plane4,
            XMVector plane5)
        {
            XMVector one = XMGlobalConstants.One;

            // Set w of the points to one so we can dot4 with a plane.
            XMVector tV0 = new XMVector(v0.X, v0.Y, v0.Z, one.W);
            XMVector tV1 = new XMVector(v1.X, v1.Y, v1.Z, one.W);
            XMVector tV2 = new XMVector(v2.X, v2.Y, v2.Z, one.W);

            XMVector outside, inside;

            // Test against each plane.
            Internal.FastIntersectTrianglePlane(tV0, tV1, tV2, plane0, out outside, out inside);

            XMVector anyOutside = outside;
            XMVector allInside = inside;

            Internal.FastIntersectTrianglePlane(tV0, tV1, tV2, plane1, out outside, out inside);
            anyOutside = XMVector.OrInt(anyOutside, outside);
            allInside = XMVector.AndInt(allInside, inside);

            Internal.FastIntersectTrianglePlane(tV0, tV1, tV2, plane2, out outside, out inside);
            anyOutside = XMVector.OrInt(anyOutside, outside);
            allInside = XMVector.AndInt(allInside, inside);

            Internal.FastIntersectTrianglePlane(tV0, tV1, tV2, plane3, out outside, out inside);
            anyOutside = XMVector.OrInt(anyOutside, outside);
            allInside = XMVector.AndInt(allInside, inside);

            Internal.FastIntersectTrianglePlane(tV0, tV1, tV2, plane4, out outside, out inside);
            anyOutside = XMVector.OrInt(anyOutside, outside);
            allInside = XMVector.AndInt(allInside, inside);

            Internal.FastIntersectTrianglePlane(tV0, tV1, tV2, plane5, out outside, out inside);
            anyOutside = XMVector.OrInt(anyOutside, outside);
            allInside = XMVector.AndInt(allInside, inside);

            // If the triangle is outside any plane it is outside.
            if (XMVector4.EqualInt(anyOutside, XMVector.TrueInt))
            {
                return ContainmentType.Disjoint;
            }

            // If the triangle is inside all planes it is inside.
            if (XMVector4.EqualInt(allInside, XMVector.TrueInt))
            {
                return ContainmentType.Contains;
            }

            // The triangle is not inside all planes or outside a plane, it may intersect.
            return ContainmentType.Intersects;
        }
    }
}
