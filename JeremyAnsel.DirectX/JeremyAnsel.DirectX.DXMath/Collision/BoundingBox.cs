// <copyright file="BoundingBox.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DXMath.Collision
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    /// <summary>
    /// A bounding axis-aligned object.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BoundingBox : IEquatable<BoundingBox>
    {
        /// <summary>
        /// The number of points defining the <see cref="BoundingBox"/>.
        /// </summary>
        public const int CornerCount = 8;

        /// <summary>
        /// The center of the <see cref="BoundingBox"/>.
        /// </summary>
        private XMFloat3 center;

        /// <summary>
        /// The extents of the <see cref="BoundingBox"/>.
        /// </summary>
        private XMFloat3 extents;

        /// <summary>
        /// Initializes a new instance of the <see cref="BoundingBox"/> struct.
        /// </summary>
        /// <param name="center">The coordinate of the center of the box.</param>
        /// <param name="extents">The extents of the box.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public BoundingBox(XMFloat3 center, XMFloat3 extents)
        {
            Debug.Assert(extents.X >= 0 && extents.Y >= 0 && extents.Z >= 0, "Reviewed");

            this.center = center;
            this.extents = extents;
        }

        /// <summary>
        /// Gets or sets the center of the <see cref="BoundingBox"/>.
        /// </summary>
        public XMFloat3 Center
        {
            get { return this.center; }
            set { this.center = value; }
        }

        /// <summary>
        /// Gets or sets the extents of the <see cref="BoundingBox"/>.
        /// </summary>
        public XMFloat3 Extents
        {
            get
            {
                return this.extents;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                Debug.Assert(value.X >= 0 && value.Y >= 0 && value.Z >= 0, "Reviewed");
                this.extents = value;
            }
        }

        /// <summary>
        /// Compares two <see cref="BoundingBox"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="BoundingBox"/> to compare.</param>
        /// <param name="right">The right <see cref="BoundingBox"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(BoundingBox left, BoundingBox right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="BoundingBox"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="BoundingBox"/> to compare.</param>
        /// <param name="right">The right <see cref="BoundingBox"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(BoundingBox left, BoundingBox right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Creates a <see cref="BoundingBox"/> large enough to contains two specified <see cref="BoundingBox"/> instances.
        /// </summary>
        /// <param name="b1">The first <see cref="BoundingBox"/> that should be contained in the new <see cref="BoundingBox"/>.</param>
        /// <param name="b2">The second <see cref="BoundingBox"/> that should be contained in the new <see cref="BoundingBox"/>.</param>
        /// <returns>The merged <see cref="BoundingBox"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BoundingBox CreateMerged(BoundingBox b1, BoundingBox b2)
        {
            XMVector b1_Center = b1.center;
            XMVector b1_Extents = b1.extents;

            XMVector b2_Center = b2.center;
            XMVector b2_Extents = b2.extents;

            XMVector min = XMVector.Subtract(b1_Center, b1_Extents);
            min = XMVector.Min(min, XMVector.Subtract(b2_Center, b2_Extents));

            XMVector max = XMVector.Add(b1_Center, b1_Extents);
            max = XMVector.Max(max, XMVector.Add(b2_Center, b2_Extents));

            Debug.Assert(XMVector3.LessOrEqual(min, max), "Reviewed");

            return new BoundingBox((min + max) * 0.5f, (max - min) * 0.5f);
        }

        /// <summary>
        /// Creates a <see cref="BoundingBox"/> large enough to contain the a specified <see cref="BoundingSphere"/>.
        /// </summary>
        /// <param name="sh">The <see cref="BoundingSphere"/> the new <see cref="BoundingBox"/> should contain.</param>
        /// <returns>The new <see cref="BoundingBox"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BoundingBox CreateFromSphere(BoundingSphere sh)
        {
            XMVector sp_Center = sh.Center;
            XMVector sh_Radius = XMVector.Replicate(sh.Radius);

            XMVector min = XMVector.Subtract(sp_Center, sh_Radius);
            XMVector max = XMVector.Add(sp_Center, sh_Radius);

            Debug.Assert(XMVector3.LessOrEqual(min, max), "Reviewed");

            return new BoundingBox((min + max) * 0.5f, (max - min) * 0.5f);
        }

        /// <summary>
        /// Creates a <see cref="BoundingBox"/> from two points.
        /// </summary>
        /// <param name="pt1">The first point the new <see cref="BoundingBox"/> should contain.</param>
        /// <param name="pt2">The second point the new <see cref="BoundingBox"/> should contain.</param>
        /// <returns>The new <see cref="BoundingBox"/> containing the two specified points.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BoundingBox CreateFromPoints(XMVector pt1, XMVector pt2)
        {
            XMVector min = XMVector.Min(pt1, pt2);
            XMVector max = XMVector.Max(pt1, pt2);

            // Store center and extents.
            return new BoundingBox((min + max) * 0.5f, (max - min) * 0.5f);
        }

        /// <summary>
        /// Creates a <see cref="BoundingBox"/> from a list of points.
        /// </summary>
        /// <param name="points">The points to create the <see cref="BoundingBox"/> from.</param>
        /// <returns>The new <see cref="BoundingBox"/> containing the specified points.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BoundingBox CreateFromPoints(XMFloat3[] points)
        {
            if (points == null)
            {
                throw new ArgumentNullException("points");
            }

            if (points.Length == 0)
            {
                throw new ArgumentOutOfRangeException("points");
            }

            // Find the minimum and maximum x, y, and z
            XMVector v_min, v_max;

            v_min = v_max = points[0];

            for (int i = 1; i < points.Length; i++)
            {
                XMVector point = points[i];

                v_min = XMVector.Min(v_min, point);
                v_max = XMVector.Max(v_max, point);
            }

            // Store center and extents.
            return new BoundingBox((v_min + v_max) * 0.5f, (v_max - v_min) * 0.5f);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is BoundingBox))
            {
                return false;
            }

            return this.Equals((BoundingBox)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(BoundingBox other)
        {
            return this.center == other.center
                && this.extents == other.extents;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.center,
                this.extents
            }
            .GetHashCode();
        }

        /// <summary>
        /// Transforms the <see cref="BoundingBox"/>.
        /// </summary>
        /// <param name="m">The matrix to transform the <see cref="BoundingBox"/> by.</param>
        /// <returns>The transformed <see cref="BoundingBox"/>.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "m", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public BoundingBox Transform(XMMatrix m)
        {
            // Load center and extents.
            XMVector boxCenter = this.center;
            XMVector boxExtents = this.extents;

            // Compute and transform the corners and find new min/max bounds.
            XMVector corner = XMVector.MultiplyAdd(boxExtents, CollisionGlobalConstants.BoxOffsets[0], boxCenter);
            corner = XMVector3.Transform(corner, m);

            XMVector min, max;
            min = max = corner;

            for (int i = 1; i < BoundingBox.CornerCount; i++)
            {
                corner = XMVector.MultiplyAdd(boxExtents, CollisionGlobalConstants.BoxOffsets[i], boxCenter);
                corner = XMVector3.Transform(corner, m);

                min = XMVector.Min(min, corner);
                max = XMVector.Max(max, corner);
            }

            // Store center and extents.
            return new BoundingBox((min + max) * 0.5f, (max - min) * 0.5f);
        }

        /// <summary>
        /// Transforms the <see cref="BoundingBox"/>.
        /// </summary>
        /// <param name="scale">The value to scale the <see cref="BoundingBox"/> by.</param>
        /// <param name="rotation">The value to rotate the <see cref="BoundingBox"/> by.</param>
        /// <param name="translation">The value to translate the <see cref="BoundingBox"/> by.</param>
        /// <returns>The transformed <see cref="BoundingBox"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public BoundingBox Transform(float scale, XMVector rotation, XMVector translation)
        {
            Debug.Assert(Internal.XMQuaternionIsUnit(rotation), "Reviewed");

            // Load center and extents.
            XMVector boxCenter = this.center;
            XMVector boxExtents = this.extents;

            XMVector vectorScale = XMVector.Replicate(scale);

            // Compute and transform the corners and find new min/max bounds.
            XMVector corner = XMVector.MultiplyAdd(boxExtents, CollisionGlobalConstants.BoxOffsets[0], boxCenter);
            corner = XMVector3.Rotate(corner * vectorScale, rotation) + translation;

            XMVector min, max;
            min = max = corner;

            for (int i = 1; i < BoundingBox.CornerCount; i++)
            {
                corner = XMVector.MultiplyAdd(boxExtents, CollisionGlobalConstants.BoxOffsets[i], boxCenter);
                corner = XMVector3.Rotate(corner * vectorScale, rotation) + translation;

                min = XMVector.Min(min, corner);
                max = XMVector.Max(max, corner);
            }

            // Store center and extents.
            return new BoundingBox((min + max) * 0.5f, (max - min) * 0.5f);
        }

        /// <summary>
        /// Retrieves the corners of the <see cref="BoundingBox"/>.
        /// </summary>
        /// <returns>The corners of the <see cref="BoundingBox"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMFloat3[] GetCorners()
        {
            XMFloat3[] corners = new XMFloat3[BoundingBox.CornerCount];

            // Load the box
            XMVector boxCenter = this.center;
            XMVector boxExtents = this.extents;

            for (int i = 0; i < BoundingBox.CornerCount; i++)
            {
                corners[i] = XMVector.MultiplyAdd(boxExtents, CollisionGlobalConstants.BoxOffsets[i], boxCenter);
            }

            return corners;
        }

        /// <summary>
        /// Tests the whether the <see cref="BoundingBox"/> contains a specified point.
        /// </summary>
        /// <param name="point">The point to test against.</param>
        /// <returns>A <see cref="ContainmentType"/> value indicating whether the point is contained in the <see cref="BoundingBox"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ContainmentType Contains(XMVector point)
        {
            XMVector boxCenter = this.center;
            XMVector boxExtents = this.extents;

            return XMVector3.InBounds(point - boxCenter, boxExtents) ? ContainmentType.Contains : ContainmentType.Disjoint;
        }

        /// <summary>
        /// Test whether the <see cref="BoundingBox"/> contains a specified triangle.
        /// </summary>
        /// <param name="v0">The first corner of the triangle.</param>
        /// <param name="v1">The second corner of the triangle.</param>
        /// <param name="v2">The third corner of the triangle.</param>
        /// <returns>A <see cref="ContainmentType"/> value indicating whether the <see cref="BoundingBox"/> contains the specified triangle.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ContainmentType Contains(XMVector v0, XMVector v1, XMVector v2)
        {
            if (!this.Intersects(v0, v1, v2))
            {
                return ContainmentType.Disjoint;
            }

            XMVector boxCenter = this.center;
            XMVector boxExtents = this.extents;

            XMVector d = XMVector.Subtract(v0, boxCenter).Abs();
            XMVector inside = XMVector.LessOrEqual(d, boxExtents);

            d = XMVector.Subtract(v1, boxCenter).Abs();
            inside = XMVector.AndInt(inside, XMVector.LessOrEqual(d, boxExtents));

            d = XMVector.Subtract(v2, boxCenter).Abs();
            inside = XMVector.AndInt(inside, XMVector.LessOrEqual(d, boxExtents));

            return XMVector3.EqualInt(inside, XMVector.TrueInt) ? ContainmentType.Contains : ContainmentType.Intersects;
        }

        /// <summary>
        /// Tests whether the <see cref="BoundingBox"/> contains a specified <see cref="BoundingSphere"/>.
        /// </summary>
        /// <param name="sh">The <see cref="BoundingSphere"/> to test against.</param>
        /// <returns>A <see cref="ContainmentType"/> value indicating whether the <see cref="BoundingBox"/> contains the <see cref="BoundingSphere"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ContainmentType Contains(BoundingSphere sh)
        {
            XMVector sphereCenter = sh.Center;
            XMVector sphereRadius = XMVector.Replicate(sh.Radius);

            XMVector boxCenter = this.center;
            XMVector boxExtents = this.extents;

            XMVector boxMin = boxCenter - boxExtents;
            XMVector boxMax = boxCenter + boxExtents;

            //// Find the distance to the nearest point on the box.
            //// for each i in (x, y, z)
            //// if (SphereCenter(i) < BoxMin(i)) d2 += (SphereCenter(i) - BoxMin(i)) ^ 2
            //// else if (SphereCenter(i) > BoxMax(i)) d2 += (SphereCenter(i) - BoxMax(i)) ^ 2

            XMVector d = XMGlobalConstants.Zero;

            // Compute d for each dimension.
            XMVector lessThanMin = XMVector.Less(sphereCenter, boxMin);
            XMVector greaterThanMax = XMVector.Greater(sphereCenter, boxMax);

            XMVector minDelta = sphereCenter - boxMin;
            XMVector maxDelta = sphereCenter - boxMax;

            // Choose value for each dimension based on the comparison.
            d = XMVector.Select(d, minDelta, lessThanMin);
            d = XMVector.Select(d, maxDelta, greaterThanMax);

            // Use a dot-product to square them and sum them together.
            XMVector d2 = XMVector3.Dot(d, d);

            if (XMVector3.Greater(d2, XMVector.Multiply(sphereRadius, sphereRadius)))
            {
                return ContainmentType.Disjoint;
            }

            XMVector insideAll = XMVector.LessOrEqual(boxMin + sphereRadius, sphereCenter);
            insideAll = XMVector.AndInt(insideAll, XMVector.LessOrEqual(sphereCenter, boxMax - sphereRadius));
            insideAll = XMVector.AndInt(insideAll, XMVector.Greater(boxMax - boxMin, sphereRadius));

            return XMVector3.EqualInt(insideAll, XMVector.TrueInt) ? ContainmentType.Contains : ContainmentType.Intersects;
        }

        /// <summary>
        /// Tests whether the <see cref="BoundingBox"/> contains another <see cref="BoundingBox"/>.
        /// </summary>
        /// <param name="box">The <see cref="BoundingBox"/> to test against.</param>
        /// <returns>A <see cref="ContainmentType"/> value indicating whether the <see cref="BoundingBox"/> contains the specified <see cref="BoundingBox"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ContainmentType Contains(BoundingBox box)
        {
            XMVector centerA = this.center;
            XMVector extentsA = this.extents;

            XMVector centerB = box.center;
            XMVector extentsB = box.extents;

            XMVector minA = centerA - extentsA;
            XMVector maxA = centerA + extentsA;

            XMVector minB = centerB - extentsB;
            XMVector maxB = centerB + extentsB;

            // for each i in (x, y, z) if a_min(i) > b_max(i) or b_min(i) > a_max(i) then return false
            XMVector disjoint = XMVector.OrInt(XMVector.Greater(minA, maxB), XMVector.Greater(minB, maxA));

            if (Internal.XMVector3AnyTrue(disjoint))
            {
                return ContainmentType.Disjoint;
            }

            // for each i in (x, y, z) if a_min(i) <= b_min(i) and b_max(i) <= a_max(i) then A contains B
            XMVector inside = XMVector.AndInt(XMVector.LessOrEqual(minA, minB), XMVector.LessOrEqual(maxB, maxA));

            return Internal.XMVector3AllTrue(inside) ? ContainmentType.Contains : ContainmentType.Intersects;
        }

        /// <summary>
        /// Tests whether the <see cref="BoundingBox"/> contains the specified <see cref="BoundingOrientedBox"/>.
        /// </summary>
        /// <param name="box">The <see cref="BoundingOrientedBox"/> to test against.</param>
        /// <returns>A <see cref="ContainmentType"/> value indicating whether the <see cref="BoundingOrientedBox"/> is contained in the <see cref="BoundingBox"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ContainmentType Contains(BoundingOrientedBox box)
        {
            if (!box.Intersects(this))
            {
                return ContainmentType.Disjoint;
            }

            XMVector boxCenter = this.center;
            XMVector boxExtents = this.extents;

            // Subtract off the AABB center to remove a subtract below
            XMVector o_center = box.Center - boxCenter;

            XMVector o_extents = box.Extents;
            XMVector o_orientation = box.Orientation;

            Debug.Assert(Internal.XMQuaternionIsUnit(o_orientation), "Reviewed");

            XMVector inside = XMVector.TrueInt;

            for (int i = 0; i < BoundingOrientedBox.CornerCount; i++)
            {
                XMVector c = XMVector3.Rotate(o_extents * CollisionGlobalConstants.BoxOffsets[i], o_orientation) + o_center;
                XMVector d = c.Abs();
                inside = XMVector.AndInt(inside, XMVector.LessOrEqual(d, boxExtents));
            }

            return XMVector3.EqualInt(inside, XMVector.TrueInt) ? ContainmentType.Contains : ContainmentType.Intersects;
        }

        /// <summary>
        /// Tests whether the <see cref="BoundingBox"/> contains the specified <see cref="BoundingFrustum"/>.
        /// </summary>
        /// <param name="fr">The <see cref="BoundingFrustum"/> to test against.</param>
        /// <returns>A <see cref="ContainmentType"/> value indicating whether the <see cref="BoundingFrustum"/> is contained in the <see cref="BoundingBox"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ContainmentType Contains(BoundingFrustum fr)
        {
            if (!fr.Intersects(this))
            {
                return ContainmentType.Disjoint;
            }

            XMFloat3[] corners = fr.GetCorners();

            XMVector v_center = this.center;
            XMVector v_extents = this.extents;

            XMVector inside = XMVector.TrueInt;

            for (int i = 0; i < BoundingFrustum.CornerCount; i++)
            {
                XMVector point = corners[i];
                XMVector d = XMVector.Subtract(point, v_center).Abs();
                inside = XMVector.AndInt(inside, XMVector.LessOrEqual(d, v_extents));
            }

            return XMVector3.EqualInt(inside, XMVector.TrueInt) ? ContainmentType.Contains : ContainmentType.Intersects;
        }

        /// <summary>
        /// Tests the <see cref="BoundingBox"/> for intersection with a <see cref="BoundingSphere"/>.
        /// </summary>
        /// <param name="sh">The <see cref="BoundingSphere"/> to test for intersection.</param>
        /// <returns>A boolean value indicating whether the <see cref="BoundingBox"/> intersects the specified <see cref="BoundingSphere"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Intersects(BoundingSphere sh)
        {
            XMVector sphereCenter = sh.Center;
            XMVector sphereRadius = XMVector.Replicate(sh.Radius);

            XMVector boxCenter = this.center;
            XMVector boxExtents = this.extents;

            XMVector boxMin = boxCenter - boxExtents;
            XMVector boxMax = boxCenter + boxExtents;

            //// Find the distance to the nearest point on the box.
            //// for each i in (x, y, z)
            //// if (SphereCenter(i) < BoxMin(i)) d2 += (SphereCenter(i) - BoxMin(i)) ^ 2
            //// else if (SphereCenter(i) > BoxMax(i)) d2 += (SphereCenter(i) - BoxMax(i)) ^ 2

            XMVector d = XMGlobalConstants.Zero;

            // Compute d for each dimension.
            XMVector lessThanMin = XMVector.Less(sphereCenter, boxMin);
            XMVector greaterThanMax = XMVector.Greater(sphereCenter, boxMax);

            XMVector minDelta = sphereCenter - boxMin;
            XMVector maxDelta = sphereCenter - boxMax;

            // Choose value for each dimension based on the comparison.
            d = XMVector.Select(d, minDelta, lessThanMin);
            d = XMVector.Select(d, maxDelta, greaterThanMax);

            // Use a dot-product to square them and sum them together.
            XMVector d2 = XMVector3.Dot(d, d);

            return XMVector3.LessOrEqual(d2, XMVector.Multiply(sphereRadius, sphereRadius));
        }

        /// <summary>
        /// Tests the <see cref="BoundingBox"/> for intersection with another <see cref="BoundingBox"/>.
        /// </summary>
        /// <param name="box">The <see cref="BoundingBox"/> to test for intersection.</param>
        /// <returns>A boolean value indicating whether the <see cref="BoundingBox"/> intersects the specified <see cref="BoundingBox"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Intersects(BoundingBox box)
        {
            XMVector centerA = this.center;
            XMVector extentsA = this.extents;

            XMVector centerB = box.center;
            XMVector extentsB = box.extents;

            XMVector minA = centerA - extentsA;
            XMVector maxA = centerA + extentsA;

            XMVector minB = centerB - extentsB;
            XMVector maxB = centerB + extentsB;

            // for each i in (x, y, z) if a_min(i) > b_max(i) or b_min(i) > a_max(i) then return false
            XMVector disjoint = XMVector.OrInt(XMVector.Greater(minA, maxB), XMVector.Greater(minB, maxA));

            return !Internal.XMVector3AnyTrue(disjoint);
        }

        /// <summary>
        /// Test the <see cref="BoundingBox"/> for intersection with a <see cref="BoundingOrientedBox"/>.
        /// </summary>
        /// <param name="box">The <see cref="BoundingOrientedBox"/> to test for intersection.</param>
        /// <returns>A boolean value indicating whether the <see cref="BoundingBox"/> intersects the specified <see cref="BoundingOrientedBox"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Intersects(BoundingOrientedBox box)
        {
            return box.Intersects(this);
        }

        /// <summary>
        /// Test the <see cref="BoundingBox"/> for intersection with a <see cref="BoundingFrustum"/>.
        /// </summary>
        /// <param name="fr">The <see cref="BoundingFrustum"/> to test for intersection.</param>
        /// <returns>A boolean value indicating whether the <see cref="BoundingBox"/> intersects the specified <see cref="BoundingFrustum"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Intersects(BoundingFrustum fr)
        {
            return fr.Intersects(this);
        }

        /// <summary>
        /// Test the <see cref="BoundingBox"/> for intersection with a triangle.
        /// </summary>
        /// <param name="v0">The first vector describing the triangle.</param>
        /// <param name="v1">The second vector describing the triangle.</param>
        /// <param name="v2">The third vector describing the triangle.</param>
        /// <returns>A boolean value indicating whether the <see cref="BoundingBox"/> intersects the triangle.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Intersects(XMVector v0, XMVector v1, XMVector v2)
        {
            XMVector zero = XMGlobalConstants.Zero;

            // Load the box.
            XMVector v_center = this.center;
            XMVector v_extents = this.extents;

            XMVector boxMin = v_center - v_extents;
            XMVector boxMax = v_center + v_extents;

            // Test the axes of the box (in effect test the AAB against the minimal AAB 
            // around the triangle).
            XMVector triMin = XMVector.Min(XMVector.Min(v0, v1), v2);
            XMVector triMax = XMVector.Max(XMVector.Max(v0, v1), v2);

            // for each i in (x, y, z) if a_min(i) > b_max(i) or b_min(i) > a_max(i) then disjoint
            XMVector disjoint = XMVector.OrInt(XMVector.Greater(triMin, boxMax), XMVector.Greater(boxMin, triMax));

            if (Internal.XMVector3AnyTrue(disjoint))
            {
                return false;
            }

            // Test the plane of the triangle.
            XMVector normal = XMVector3.Cross(v1 - v0, v2 - v0);
            XMVector dist = XMVector3.Dot(normal, v0);

            // Assert that the triangle is not degenerate.
            Debug.Assert(!XMVector3.Equal(normal, zero), "Reviewed");

            // for each i in (x, y, z) if n(i) >= 0 then v_min(i)=b_min(i), v_max(i)=b_max(i)
            // else v_min(i)=b_max(i), v_max(i)=b_min(i)
            XMVector normalSelect = XMVector.Greater(normal, zero);
            XMVector v_min = XMVector.Select(boxMax, boxMin, normalSelect);
            XMVector v_max = XMVector.Select(boxMin, boxMax, normalSelect);

            // if n dot v_min + d > 0 || n dot v_max + d < 0 then disjoint
            XMVector minDist = XMVector3.Dot(v_min, normal);
            XMVector maxDist = XMVector3.Dot(v_max, normal);

            XMVector noIntersection = XMVector.Greater(minDist, dist);
            noIntersection = XMVector.OrInt(noIntersection, XMVector.Less(maxDist, dist));

            // Move the box center to zero to simplify the following tests.
            XMVector tV0 = v0 - v_center;
            XMVector tV1 = v1 - v_center;
            XMVector tV2 = v2 - v_center;

            // Test the edge/edge axes (3*3).
            XMVector e0 = tV1 - tV0;
            XMVector e1 = tV2 - tV1;
            XMVector e2 = tV0 - tV2;

            // Make w zero.
            e0.W = zero.W;
            e1.W = zero.W;
            e2.W = zero.W;

            XMVector axis;
            XMVector p0, p1, p2;
            XMVector min, max;
            XMVector radius;

            //// Axis == (1,0,0) x e0 = (0, -e0.z, e0.y)
            axis = new XMVector(e1.W, -e0.Z, e1.Y, e1.X);
            p0 = XMVector3.Dot(tV0, axis);
            //// p1 = XMVector3Dot( V1, Axis ); // p1 = p0;
            p2 = XMVector3.Dot(tV2, axis);
            min = XMVector.Min(p0, p2);
            max = XMVector.Max(p0, p2);
            radius = XMVector3.Dot(v_extents, axis.Abs());
            noIntersection = XMVector.OrInt(noIntersection, XMVector.Greater(min, radius));
            noIntersection = XMVector.OrInt(noIntersection, XMVector.Less(max, -radius));

            //// Axis == (1,0,0) x e1 = (0, -e1.z, e1.y)
            axis = new XMVector(e1.W, -e1.Z, e1.Y, e1.X);
            p0 = XMVector3.Dot(tV0, axis);
            p1 = XMVector3.Dot(tV1, axis);
            //// p2 = XMVector3Dot( V2, Axis ); // p2 = p1;
            min = XMVector.Min(p0, p1);
            max = XMVector.Max(p0, p1);
            radius = XMVector3.Dot(v_extents, axis.Abs());
            noIntersection = XMVector.OrInt(noIntersection, XMVector.Greater(min, radius));
            noIntersection = XMVector.OrInt(noIntersection, XMVector.Less(max, -radius));

            //// Axis == (1,0,0) x e2 = (0, -e2.z, e2.y)
            axis = new XMVector(e2.W, -e2.Z, e2.Y, e2.X);
            p0 = XMVector3.Dot(tV0, axis);
            p1 = XMVector3.Dot(tV1, axis);
            //// p2 = XMVector3Dot( V2, Axis ); // p2 = p0;
            min = XMVector.Min(p0, p1);
            max = XMVector.Max(p0, p1);
            radius = XMVector3.Dot(v_extents, axis.Abs());
            noIntersection = XMVector.OrInt(noIntersection, XMVector.Greater(min, radius));
            noIntersection = XMVector.OrInt(noIntersection, XMVector.Less(max, -radius));

            //// Axis == (0,1,0) x e0 = (e0.z, 0, -e0.x)
            axis = new XMVector(e0.Z, e0.W, -e0.X, e0.Y);
            p0 = XMVector3.Dot(tV0, axis);
            //// p1 = XMVector3Dot( V1, Axis ); // p1 = p0;
            p2 = XMVector3.Dot(tV2, axis);
            min = XMVector.Min(p0, p2);
            max = XMVector.Max(p0, p2);
            radius = XMVector3.Dot(v_extents, axis.Abs());
            noIntersection = XMVector.OrInt(noIntersection, XMVector.Greater(min, radius));
            noIntersection = XMVector.OrInt(noIntersection, XMVector.Less(max, -radius));

            //// Axis == (0,1,0) x e1 = (e1.z, 0, -e1.x)
            axis = new XMVector(e1.Z, e1.W, -e1.X, e1.Y);
            p0 = XMVector3.Dot(tV0, axis);
            p1 = XMVector3.Dot(tV1, axis);
            //// p2 = XMVector3Dot( V2, Axis ); // p2 = p1;
            min = XMVector.Min(p0, p1);
            max = XMVector.Max(p0, p1);
            radius = XMVector3.Dot(v_extents, axis.Abs());
            noIntersection = XMVector.OrInt(noIntersection, XMVector.Greater(min, radius));
            noIntersection = XMVector.OrInt(noIntersection, XMVector.Less(max, -radius));

            //// Axis == (0,0,1) x e2 = (e2.z, 0, -e2.x)
            axis = new XMVector(e2.Z, e2.W, -e2.X, e2.Y);
            p0 = XMVector3.Dot(tV0, axis);
            p1 = XMVector3.Dot(tV1, axis);
            //// p2 = XMVector3Dot( V2, Axis ); // p2 = p0;
            min = XMVector.Min(p0, p1);
            max = XMVector.Max(p0, p1);
            radius = XMVector3.Dot(v_extents, axis.Abs());
            noIntersection = XMVector.OrInt(noIntersection, XMVector.Greater(min, radius));
            noIntersection = XMVector.OrInt(noIntersection, XMVector.Less(max, -radius));

            //// Axis == (0,0,1) x e0 = (-e0.y, e0.x, 0)
            axis = new XMVector(-e0.Y, e0.X, e0.W, e0.Z);
            p0 = XMVector3.Dot(tV0, axis);
            //// p1 = XMVector3Dot( V1, Axis ); // p1 = p0;
            p2 = XMVector3.Dot(tV2, axis);
            min = XMVector.Min(p0, p2);
            max = XMVector.Max(p0, p2);
            radius = XMVector3.Dot(v_extents, axis.Abs());
            noIntersection = XMVector.OrInt(noIntersection, XMVector.Greater(min, radius));
            noIntersection = XMVector.OrInt(noIntersection, XMVector.Less(max, -radius));

            //// Axis == (0,0,1) x e1 = (-e1.y, e1.x, 0)
            axis = new XMVector(-e1.Y, e1.X, e1.W, e1.Z);
            p0 = XMVector3.Dot(tV0, axis);
            p1 = XMVector3.Dot(tV1, axis);
            //// p2 = XMVector3Dot( V2, Axis ); // p2 = p1;
            min = XMVector.Min(p0, p1);
            max = XMVector.Max(p0, p1);
            radius = XMVector3.Dot(v_extents, axis.Abs());
            noIntersection = XMVector.OrInt(noIntersection, XMVector.Greater(min, radius));
            noIntersection = XMVector.OrInt(noIntersection, XMVector.Less(max, -radius));

            //// Axis == (0,0,1) x e2 = (-e2.y, e2.x, 0)
            axis = new XMVector(-e2.Y, e2.X, e2.W, e2.Z);
            p0 = XMVector3.Dot(tV0, axis);
            p1 = XMVector3.Dot(tV1, axis);
            //// p2 = XMVector3Dot( V2, Axis ); // p2 = p0;
            min = XMVector.Min(p0, p1);
            max = XMVector.Max(p0, p1);
            radius = XMVector3.Dot(v_extents, axis.Abs());
            noIntersection = XMVector.OrInt(noIntersection, XMVector.Greater(min, radius));
            noIntersection = XMVector.OrInt(noIntersection, XMVector.Less(max, -radius));

            return XMVector4.NotEqualInt(noIntersection, XMVector.TrueInt);
        }

        /// <summary>
        /// Test the <see cref="BoundingBox"/> for intersection with a plane.
        /// </summary>
        /// <param name="plane">A vector describing the plane.</param>
        /// <returns>A <see cref="PlaneIntersectionType"/> value indicating the intersection status.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public PlaneIntersectionType Intersects(XMVector plane)
        {
            Debug.Assert(Internal.XMPlaneIsUnit(plane), "Reviewed");

            // Load the box.
            XMVector v_center = this.center;
            XMVector v_extents = this.extents;

            // Set w of the center to one so we can dot4 with a plane.
            v_center.W = 1.0f;

            XMVector outside, inside;
            Internal.FastIntersectAxisAlignedBoxPlane(v_center, v_extents, plane, out outside, out inside);

            // If the box is outside any plane it is outside.
            if (XMVector4.EqualInt(outside, XMVector.TrueInt))
            {
                return PlaneIntersectionType.Front;
            }

            // If the box is inside all planes it is inside.
            if (XMVector4.EqualInt(inside, XMVector.TrueInt))
            {
                return PlaneIntersectionType.Back;
            }

            // The box is not inside all planes or outside a plane it intersects.
            return PlaneIntersectionType.Intersecting;
        }

        /// <summary>
        /// Test the <see cref="BoundingBox"/> for intersection with a ray.
        /// </summary>
        /// <param name="origin">The origin of the ray.</param>
        /// <param name="direction">The direction of the ray.</param>
        /// <returns>A boolean value indicating whether the <see cref="BoundingBox"/> intersects the ray.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Intersects(XMVector origin, XMVector direction)
        {
            float distance;
            return this.Intersects(origin, direction, out distance);
        }

        /// <summary>
        /// Test the <see cref="BoundingBox"/> for intersection with a ray.
        /// </summary>
        /// <param name="origin">The origin of the ray.</param>
        /// <param name="direction">The direction of the ray.</param>
        /// <param name="distance">The length of the ray.</param>
        /// <returns>A boolean value indicating whether the <see cref="BoundingBox"/> intersects the ray.</returns>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "2#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Intersects(XMVector origin, XMVector direction, out float distance)
        {
            Debug.Assert(Internal.XMVector3IsUnit(direction), "Reviewed");

            // Load the box.
            XMVector v_center = this.center;
            XMVector v_extents = this.extents;

            // Adjust ray origin to be relative to center of the box.
            XMVector t_origin = v_center - origin;

            // Compute the dot product againt each axis of the box.
            // Since the axii are (1,0,0), (0,1,0), (0,0,1) no computation is necessary.
            XMVector axisDotOrigin = t_origin;
            XMVector axisDotDirection = direction;

            // if (fabs(AxisDotDirection) <= Epsilon) the ray is nearly parallel to the slab.
            XMVector isParallel = XMVector.LessOrEqual(axisDotDirection.Abs(), CollisionGlobalConstants.RayEpsilon);

            // Test against all three axii simultaneously.
            XMVector inverseAxisDotDirection = axisDotDirection.Reciprocal();
            XMVector t1 = (axisDotOrigin - v_extents) * inverseAxisDotDirection;
            XMVector t2 = (axisDotOrigin + v_extents) * inverseAxisDotDirection;

            // Compute the max of min(t1,t2) and the min of max(t1,t2) ensuring we don't
            // use the results from any directions parallel to the slab.
            XMVector t_min = XMVector.Select(XMVector.Min(t1, t2), CollisionGlobalConstants.FltMin, isParallel);
            XMVector t_max = XMVector.Select(XMVector.Max(t1, t2), CollisionGlobalConstants.FltMax, isParallel);

            // t_min.x = maximum( t_min.x, t_min.y, t_min.z );
            // t_max.x = minimum( t_max.x, t_max.y, t_max.z );
            t_min = XMVector.Max(t_min, XMVector.SplatY(t_min));  // x = max(x,y)
            t_min = XMVector.Max(t_min, XMVector.SplatZ(t_min));  // x = max(max(x,y),z)
            t_max = XMVector.Min(t_max, XMVector.SplatY(t_max));  // x = min(x,y)
            t_max = XMVector.Min(t_max, XMVector.SplatZ(t_max));  // x = min(min(x,y),z)

            // if ( t_min > t_max ) return false;
            XMVector noIntersection = XMVector.Greater(XMVector.SplatX(t_min), XMVector.SplatX(t_max));

            // if ( t_max < 0.0f ) return false;
            noIntersection = XMVector.OrInt(noIntersection, XMVector.Less(XMVector.SplatX(t_max), XMGlobalConstants.Zero));

            // if (IsParallel && (-Extents > AxisDotOrigin || Extents < AxisDotOrigin)) return false;
            XMVector parallelOverlap = axisDotOrigin.InBounds(v_extents);
            noIntersection = XMVector.OrInt(noIntersection, XMVector.AndComplementInt(isParallel, parallelOverlap));

            if (!Internal.XMVector3AnyTrue(noIntersection))
            {
                // Store the x-component to *pDist
                t_min.StoreFloat(out distance);
                return true;
            }

            distance = 0.0f;
            return false;
        }

        /// <summary>
        /// Tests whether the <see cref="BoundingBox"/> is contained by the specified frustum.
        /// </summary>
        /// <param name="planes">The planes describing the frustum.</param>
        /// <returns>A <see cref="ContainmentType"/> value indicating whether the frustum contains the <see cref="BoundingBox"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ContainmentType ContainedBy(XMVector[] planes)
        {
            if (planes == null)
            {
                throw new ArgumentNullException("planes");
            }

            if (planes.Length != 6)
            {
                throw new ArgumentOutOfRangeException("planes");
            }

            return this.ContainedBy(planes[0], planes[1], planes[2], planes[3], planes[4], planes[5]);
        }

        /// <summary>
        /// Tests whether the <see cref="BoundingBox"/> is contained by the specified frustum.
        /// </summary>
        /// <param name="plane0">The first plane describing the frustum.</param>
        /// <param name="plane1">The second plane describing the frustum.</param>
        /// <param name="plane2">The third plane describing the frustum.</param>
        /// <param name="plane3">The fourth plane describing the frustum.</param>
        /// <param name="plane4">The fifth plane describing the frustum.</param>
        /// <param name="plane5">The sixth plane describing the frustum.</param>
        /// <returns>A <see cref="ContainmentType"/> value indicating whether the frustum contains the <see cref="BoundingBox"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ContainmentType ContainedBy(
            XMVector plane0,
            XMVector plane1,
            XMVector plane2,
            XMVector plane3,
            XMVector plane4,
            XMVector plane5)
        {
            // Load the box.
            XMVector v_center = this.center;
            XMVector v_extents = this.extents;

            // Set w of the center to one so we can dot4 with a plane.
            v_center.W = 1.0f;

            XMVector outside, inside;

            // Test against each plane.
            Internal.FastIntersectAxisAlignedBoxPlane(v_center, v_extents, plane0, out outside, out inside);

            XMVector anyOutside = outside;
            XMVector allInside = inside;

            Internal.FastIntersectAxisAlignedBoxPlane(v_center, v_extents, plane1, out outside, out inside);
            anyOutside = XMVector.OrInt(anyOutside, outside);
            allInside = XMVector.AndInt(allInside, inside);

            Internal.FastIntersectAxisAlignedBoxPlane(v_center, v_extents, plane2, out outside, out inside);
            anyOutside = XMVector.OrInt(anyOutside, outside);
            allInside = XMVector.AndInt(allInside, inside);

            Internal.FastIntersectAxisAlignedBoxPlane(v_center, v_extents, plane3, out outside, out inside);
            anyOutside = XMVector.OrInt(anyOutside, outside);
            allInside = XMVector.AndInt(allInside, inside);

            Internal.FastIntersectAxisAlignedBoxPlane(v_center, v_extents, plane4, out outside, out inside);
            anyOutside = XMVector.OrInt(anyOutside, outside);
            allInside = XMVector.AndInt(allInside, inside);

            Internal.FastIntersectAxisAlignedBoxPlane(v_center, v_extents, plane5, out outside, out inside);
            anyOutside = XMVector.OrInt(anyOutside, outside);
            allInside = XMVector.AndInt(allInside, inside);

            // If the box is outside any plane it is outside.
            if (XMVector4.EqualInt(anyOutside, XMVector.TrueInt))
            {
                return ContainmentType.Disjoint;
            }

            // If the box is inside all planes it is inside.
            if (XMVector4.EqualInt(allInside, XMVector.TrueInt))
            {
                return ContainmentType.Contains;
            }

            // The box is not inside all planes or outside a plane, it may intersect.
            return ContainmentType.Intersects;
        }
    }
}
