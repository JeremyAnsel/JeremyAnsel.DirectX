// <copyright file="BoundingOrientedBox.cs" company="Jérémy Ansel">
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
    /// An oriented bounding box object.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BoundingOrientedBox : IEquatable<BoundingOrientedBox>
    {
        /// <summary>
        /// The number of points defining the <see cref="BoundingOrientedBox"/>.
        /// </summary>
        public const int CornerCount = 8;

        /// <summary>
        /// The center of the <see cref="BoundingOrientedBox"/>.
        /// </summary>
        private XMFloat3 center;

        /// <summary>
        /// The extents of the <see cref="BoundingOrientedBox"/>.
        /// </summary>
        private XMFloat3 extents;

        /// <summary>
        /// The orientation of the <see cref="BoundingOrientedBox"/> represented as a quaternion.
        /// </summary>
        private XMFloat4 orientation;

        /// <summary>
        /// Initializes a new instance of the <see cref="BoundingOrientedBox"/> struct.
        /// </summary>
        /// <param name="center">The coordinates of the center.</param>
        /// <param name="extents">The extents.</param>
        /// <param name="orientation">The orientation.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public BoundingOrientedBox(XMFloat3 center, XMFloat3 extents, XMFloat4 orientation)
        {
            Debug.Assert(extents.X >= 0 && extents.Y >= 0 && extents.Z >= 0, "Reviewed");

            this.center = center;
            this.extents = extents;
            this.orientation = orientation;
        }

        /// <summary>
        /// Gets or sets the center of the <see cref="BoundingOrientedBox"/>.
        /// </summary>
        public XMFloat3 Center
        {
            get { return this.center; }
            set { this.center = value; }
        }

        /// <summary>
        /// Gets or sets the extents of the <see cref="BoundingOrientedBox"/>.
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
        /// Gets or sets the orientation of the <see cref="BoundingOrientedBox"/> represented as a quaternion.
        /// </summary>
        public XMFloat4 Orientation
        {
            get { return this.orientation; }
            set { this.orientation = value; }
        }

        /// <summary>
        /// Compares two <see cref="BoundingOrientedBox"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="BoundingOrientedBox"/> to compare.</param>
        /// <param name="right">The right <see cref="BoundingOrientedBox"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(BoundingOrientedBox left, BoundingOrientedBox right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="BoundingOrientedBox"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="BoundingOrientedBox"/> to compare.</param>
        /// <param name="right">The right <see cref="BoundingOrientedBox"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(BoundingOrientedBox left, BoundingOrientedBox right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Creates a <see cref="BoundingOrientedBox"/> from a <see cref="BoundingBox"/>.
        /// </summary>
        /// <param name="box">The <see cref="BoundingBox"/> the <see cref="BoundingOrientedBox"/> should contain.</param>
        /// <returns>The new <see cref="BoundingOrientedBox"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BoundingOrientedBox CreateFromBox(BoundingBox box)
        {
            return new BoundingOrientedBox(box.Center, box.Extents, new XMFloat4(0.0f, 0.0f, 0.0f, 1.0f));
        }

        /// <summary>
        /// Creates a <see cref="BoundingOrientedBox"/> from a collection of points.
        /// </summary>
        /// <param name="points">The points to create the <see cref="BoundingOrientedBox"/> from.</param>
        /// <returns>The new <see cref="BoundingOrientedBox"/> containing the specified points.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BoundingOrientedBox CreateFromPoints(XMFloat3[] points)
        {
            ////-----------------------------------------------------------------------------
            //// Find the approximate minimum oriented bounding box containing a set of 
            //// points.  Exact computation of minimum oriented bounding box is possible but 
            //// is slower and requires a more complex algorithm.
            //// The algorithm works by computing the inertia tensor of the points and then
            //// using the eigenvectors of the intertia tensor as the axes of the box.
            //// Computing the intertia tensor of the convex hull of the points will usually 
            //// result in better bounding box but the computation is more complex. 
            //// Exact computation of the minimum oriented bounding box is possible but the
            //// best know algorithm is O(N^3) and is significanly more complex to implement.
            ////-----------------------------------------------------------------------------

            if (points == null)
            {
                throw new ArgumentNullException("points");
            }

            if (points.Length == 0)
            {
                throw new ArgumentOutOfRangeException("points");
            }

            XMVector centerOfMass = XMGlobalConstants.Zero;

            // Compute the center of mass and inertia tensor of the points.
            for (int i = 0; i < points.Length; i++)
            {
                XMVector point = points[i];

                centerOfMass += point;
            }

            centerOfMass *= XMVector.Replicate(points.Length).Reciprocal();

            // Compute the inertia tensor of the points around the center of mass.
            // Using the center of mass is not strictly necessary, but will hopefully
            // improve the stability of finding the eigenvectors.
            XMVector xx_yy_zz = XMGlobalConstants.Zero;
            XMVector xy_xz_yz = XMGlobalConstants.Zero;

            for (int i = 0; i < points.Length; i++)
            {
                XMVector point = points[i] - centerOfMass;

                xx_yy_zz += point * point;

                XMVector xxy = new XMVector(point.X, point.X, point.Y, point.W);
                XMVector yzz = new XMVector(point.Y, point.Z, point.Z, point.W);

                xy_xz_yz += xxy * yzz;
            }

            XMVector v1, v2, v3;

            // Compute the eigenvectors of the inertia tensor.
            Internal.CalculateEigenVectorsFromCovarianceMatrix(
                xx_yy_zz.X,
                xx_yy_zz.Y,
                xx_yy_zz.Z,
                xy_xz_yz.X,
                xy_xz_yz.Y,
                xy_xz_yz.Z,
                out v1,
                out v2,
                out v3);

            // Put them in a matrix.
            XMMatrix r;

            ((XMVector*)&r)[0] = new XMVector(v1.X, v1.Y, v1.Z, 0.0f);
            ((XMVector*)&r)[1] = new XMVector(v2.X, v2.Y, v2.Z, 0.0f);
            ((XMVector*)&r)[2] = new XMVector(v3.X, v3.Y, v3.Z, 0.0f);
            ((XMVector*)&r)[3] = XMGlobalConstants.IdentityR3;

            // Multiply by -1 to convert the matrix into a right handed coordinate 
            // system (Det ~= 1) in case the eigenvectors form a left handed 
            // coordinate system (Det ~= -1) because XMQuaternionRotationMatrix only 
            // works on right handed matrices.
            XMVector det = r.Determinant();

            if (XMVector4.Less(det, XMGlobalConstants.Zero))
            {
                ((XMVector*)&r)[0] *= XMGlobalConstants.NegativeOne;
                ((XMVector*)&r)[1] *= XMGlobalConstants.NegativeOne;
                ((XMVector*)&r)[2] *= XMGlobalConstants.NegativeOne;
            }

            // Get the rotation quaternion from the matrix.
            XMVector v_orientation = XMQuaternion.RotationMatrix(r);

            // Make sure it is normal (in case the vectors are slightly non-orthogonal).
            v_orientation = XMQuaternion.Normalize(v_orientation);

            // Rebuild the rotation matrix from the quaternion.
            r = XMMatrix.RotationQuaternion(v_orientation);

            // Build the rotation into the rotated space.
            XMMatrix inverseR = r.Transpose();

            // Find the minimum OBB using the eigenvectors as the axes.
            XMVector v_min, v_max;

            v_min = v_max = XMVector3.TransformNormal(points[0], inverseR);

            for (int i = 1; i < points.Length; i++)
            {
                XMVector point = XMVector3.TransformNormal(points[i], inverseR);

                v_min = XMVector.Min(v_min, point);
                v_max = XMVector.Max(v_max, point);
            }

            // Rotate the center into world space.
            XMVector v_center = (v_min + v_max) * 0.5f;
            v_center = XMVector3.TransformNormal(v_center, r);

            // Store center, extents, and orientation.
            return new BoundingOrientedBox(v_center, (v_max - v_min) * 0.5f, v_orientation);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is BoundingOrientedBox))
            {
                return false;
            }

            return this.Equals((BoundingOrientedBox)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(BoundingOrientedBox other)
        {
            return this.center == other.center
                && this.extents == other.extents
                && this.orientation == other.orientation;
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
                this.extents,
                this.orientation
            }
            .GetHashCode();
        }

        /// <summary>
        /// Transforms the <see cref="BoundingOrientedBox"/>.
        /// </summary>
        /// <param name="m">The matrix to transform the <see cref="BoundingOrientedBox"/> with.</param>
        /// <returns>The transformed <see cref="BoundingOrientedBox"/>.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "m", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public BoundingOrientedBox Transform(XMMatrix m)
        {
            // Load the box.
            XMVector v_center = this.center;
            XMVector v_extents = this.extents;
            XMVector v_orientation = this.orientation;

            Debug.Assert(Internal.XMQuaternionIsUnit(v_orientation), "Reviewed");

            // Composite the box rotation and the transform rotation.
            XMMatrix nM;
            ((XMVector*)&nM)[0] = XMVector3.Normalize(((XMVector*)&m)[0]);
            ((XMVector*)&nM)[1] = XMVector3.Normalize(((XMVector*)&m)[1]);
            ((XMVector*)&nM)[2] = XMVector3.Normalize(((XMVector*)&m)[2]);
            ((XMVector*)&nM)[3] = XMGlobalConstants.IdentityR3;

            XMVector rotation = XMQuaternion.RotationMatrix(nM);
            v_orientation = XMQuaternion.Multiply(v_orientation, rotation);

            // Transform the center.
            v_center = XMVector3.Transform(v_center, m);

            // Scale the box extents.
            XMVector dX = XMVector3.Length(((XMVector*)&m)[0]);
            XMVector dY = XMVector3.Length(((XMVector*)&m)[1]);
            XMVector dZ = XMVector3.Length(((XMVector*)&m)[2]);

            XMVector vectorScale = XMVector.Select(dY, dX, XMGlobalConstants.Select1000);
            vectorScale = XMVector.Select(dZ, vectorScale, XMGlobalConstants.Select1100);
            v_extents = v_extents * vectorScale;

            // Store the box.
            return new BoundingOrientedBox(v_center, v_extents, v_orientation);
        }

        /// <summary>
        /// Transforms the <see cref="BoundingOrientedBox"/>.
        /// </summary>
        /// <param name="scale">The value to scale the <see cref="BoundingOrientedBox"/> by.</param>
        /// <param name="rotation">The value to rotate the <see cref="BoundingOrientedBox"/> by.</param>
        /// <param name="translation">The value to translate the <see cref="BoundingOrientedBox"/> by.</param>
        /// <returns>The transformed <see cref="BoundingOrientedBox"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public BoundingOrientedBox Transform(float scale, XMVector rotation, XMVector translation)
        {
            Debug.Assert(Internal.XMQuaternionIsUnit(rotation), "Reviewed");

            // Load the box.
            XMVector v_center = this.center;
            XMVector v_extents = this.extents;
            XMVector v_orientation = this.orientation;

            Debug.Assert(Internal.XMQuaternionIsUnit(v_orientation), "Reviewed");

            // Composite the box rotation and the transform rotation.
            v_orientation = XMQuaternion.Multiply(v_orientation, rotation);

            // Transform the center.
            XMVector vectorScale = XMVector.Replicate(scale);
            v_center = XMVector3.Rotate(v_center * vectorScale, rotation) + translation;

            // Scale the box extents.
            v_extents = v_extents * vectorScale;

            // Store the box.
            return new BoundingOrientedBox(v_center, v_extents, v_orientation);
        }

        /// <summary>
        /// Retrieves the corners of the <see cref="BoundingOrientedBox"/>.
        /// </summary>
        /// <returns>The corners.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMFloat3[] GetCorners()
        {
            XMFloat3[] corners = new XMFloat3[BoundingOrientedBox.CornerCount];

            // Load the box
            XMVector v_center = this.center;
            XMVector v_extents = this.extents;
            XMVector v_orientation = this.orientation;

            Debug.Assert(Internal.XMQuaternionIsUnit(v_orientation), "Reviewed");

            for (int i = 0; i < BoundingOrientedBox.CornerCount; i++)
            {
                corners[i] = XMVector3.Rotate(v_extents * CollisionGlobalConstants.BoxOffsets[i], v_orientation) + v_center;
            }

            return corners;
        }

        /// <summary>
        /// Tests whether the <see cref="BoundingOrientedBox"/> contains a specified point.
        /// </summary>
        /// <param name="point">The point to test against.</param>
        /// <returns>A <see cref="ContainmentType"/> indicating whether point is contained in the <see cref="BoundingOrientedBox"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ContainmentType Contains(XMVector point)
        {
            XMVector v_center = this.center;
            XMVector v_extents = this.extents;
            XMVector v_orientation = this.orientation;

            // Transform the point to be local to the box.
            XMVector t_point = XMVector3.InverseRotate(point - v_center, v_orientation);

            return XMVector3.InBounds(t_point, v_extents) ? ContainmentType.Contains : ContainmentType.Disjoint;
        }

        /// <summary>
        /// Tests whether the <see cref="BoundingOrientedBox"/> contains a triangle.
        /// </summary>
        /// <param name="v0">The first vector describing the triangle.</param>
        /// <param name="v1">The second vector describing the triangle.</param>
        /// <param name="v2">The third vector describing the triangle.</param>
        /// <returns>A <see cref="ContainmentType"/> indicating whether triangle is contained in the <see cref="BoundingOrientedBox"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ContainmentType Contains(XMVector v0, XMVector v1, XMVector v2)
        {
            // Load the box center & orientation.
            XMVector v_center = this.center;
            XMVector v_orientation = this.orientation;

            // Transform the triangle vertices into the space of the box.
            XMVector tV0 = XMVector3.InverseRotate(v0 - v_center, v_orientation);
            XMVector tV1 = XMVector3.InverseRotate(v1 - v_center, v_orientation);
            XMVector tV2 = XMVector3.InverseRotate(v2 - v_center, v_orientation);

            BoundingBox box = new BoundingBox(new XMFloat3(0.0f, 0.0f, 0.0f), this.extents);

            // Use the triangle vs axis aligned box intersection routine.
            return box.Contains(tV0, tV1, tV2);
        }

        /// <summary>
        /// Tests whether the <see cref="BoundingOrientedBox"/> contains a <see cref="BoundingSphere"/>.
        /// </summary>
        /// <param name="sh">The <see cref="BoundingSphere"/> to test against.</param>
        /// <returns>A <see cref="ContainmentType"/> indicating whether the <see cref="BoundingSphere"/> is contained in the <see cref="BoundingOrientedBox"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ContainmentType Contains(BoundingSphere sh)
        {
            XMVector sphereCenter = sh.Center;
            XMVector sphereRadius = XMVector.Replicate(sh.Radius);

            XMVector boxCenter = this.center;
            XMVector boxExtents = this.extents;
            XMVector boxOrientation = this.orientation;

            Debug.Assert(Internal.XMQuaternionIsUnit(boxOrientation), "Reviewed");

            // Transform the center of the sphere to be local to the box.
            // BoxMin = -BoxExtents
            // BoxMax = +BoxExtents
            sphereCenter = XMVector3.InverseRotate(sphereCenter - boxCenter, boxOrientation);

            //// Find the distance to the nearest point on the box.
            //// for each i in (x, y, z)
            //// if (SphereCenter(i) < BoxMin(i)) d2 += (SphereCenter(i) - BoxMin(i)) ^ 2
            //// else if (SphereCenter(i) > BoxMax(i)) d2 += (SphereCenter(i) - BoxMax(i)) ^ 2

            XMVector d = XMGlobalConstants.Zero;

            // Compute d for each dimension.
            XMVector lessThanMin = XMVector.Less(sphereCenter, -boxExtents);
            XMVector greaterThanMax = XMVector.Greater(sphereCenter, boxExtents);

            XMVector minDelta = sphereCenter + boxExtents;
            XMVector maxDelta = sphereCenter - boxExtents;

            // Choose value for each dimension based on the comparison.
            d = XMVector.Select(d, minDelta, lessThanMin);
            d = XMVector.Select(d, maxDelta, greaterThanMax);

            // Use a dot-product to square them and sum them together.
            XMVector d2 = XMVector3.Dot(d, d);
            XMVector sphereRadiusSq = XMVector.Multiply(sphereRadius, sphereRadius);

            if (XMVector4.Greater(d2, sphereRadiusSq))
            {
                return ContainmentType.Disjoint;
            }

            // See if we are completely inside the box
            XMVector s_min = sphereCenter - sphereRadius;
            XMVector s_max = sphereCenter + sphereRadius;

            return (XMVector3.InBounds(s_min, boxExtents) && XMVector3.InBounds(s_max, boxExtents)) ? ContainmentType.Contains : ContainmentType.Intersects;
        }

        /// <summary>
        /// Tests whether the <see cref="BoundingOrientedBox"/> contains a <see cref="BoundingBox"/>.
        /// </summary>
        /// <param name="box">The <see cref="BoundingBox"/> to test against.</param>
        /// <returns>A <see cref="ContainmentType"/> indicating whether the <see cref="BoundingBox"/> is contained in the <see cref="BoundingOrientedBox"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ContainmentType Contains(BoundingBox box)
        {
            // Make the axis aligned box oriented and do an OBB vs OBB test.
            BoundingOrientedBox obox = new BoundingOrientedBox(box.Center, box.Extents, new XMFloat4(0.0f, 0.0f, 0.0f, 1.0f));
            return this.Contains(obox);
        }

        /// <summary>
        /// Tests whether the <see cref="BoundingOrientedBox"/> contains a <see cref="BoundingOrientedBox"/>.
        /// </summary>
        /// <param name="box">The <see cref="BoundingOrientedBox"/> to test against.</param>
        /// <returns>A <see cref="ContainmentType"/> indicating whether the <see cref="BoundingOrientedBox"/> is contained in the <see cref="BoundingOrientedBox"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ContainmentType Contains(BoundingOrientedBox box)
        {
            if (!this.Intersects(box))
            {
                return ContainmentType.Disjoint;
            }

            // Load the boxes
            XMVector boxACenter = this.center;
            XMVector boxAExtents = this.extents;
            XMVector boxAOrientation = this.orientation;

            Debug.Assert(Internal.XMQuaternionIsUnit(boxAOrientation), "Reviewed");

            XMVector boxBCenter = box.center;
            XMVector boxBExtents = box.extents;
            XMVector boxBOrientation = box.orientation;

            Debug.Assert(Internal.XMQuaternionIsUnit(boxBOrientation), "Reviewed");

            XMVector offset = boxBCenter - boxACenter;

            for (int i = 0; i < BoundingOrientedBox.CornerCount; i++)
            {
                //// Cb = rotate( bExtents * corneroffset[i], bOrientation ) + bcenter
                //// Ca = invrotate( Cb - aCenter, aOrientation )

                XMVector c = XMVector3.Rotate(boxBExtents * CollisionGlobalConstants.BoxOffsets[i], boxBOrientation) + offset;
                c = XMVector3.InverseRotate(c, boxAOrientation);

                if (!XMVector3.InBounds(c, boxAExtents))
                {
                    return ContainmentType.Intersects;
                }
            }

            return ContainmentType.Contains;
        }

        /// <summary>
        /// Tests whether the <see cref="BoundingOrientedBox"/> contains a <see cref="BoundingFrustum"/>.
        /// </summary>
        /// <param name="fr">The <see cref="BoundingFrustum"/> to test against.</param>
        /// <returns>A <see cref="ContainmentType"/> indicating whether the <see cref="BoundingFrustum"/> is contained in the <see cref="BoundingOrientedBox"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ContainmentType Contains(BoundingFrustum fr)
        {
            if (!fr.Intersects(this))
            {
                return ContainmentType.Disjoint;
            }

            XMFloat3[] corners = fr.GetCorners();

            // Load the box
            XMVector v_center = this.center;
            XMVector v_extents = this.extents;
            XMVector v_orientation = this.orientation;

            Debug.Assert(Internal.XMQuaternionIsUnit(v_orientation), "Reviewed");

            for (int i = 0; i < BoundingFrustum.CornerCount; i++)
            {
                XMVector c = XMVector3.InverseRotate(corners[i] - v_center, v_orientation);

                if (!XMVector3.InBounds(c, v_extents))
                {
                    return ContainmentType.Intersects;
                }
            }

            return ContainmentType.Contains;
        }

        /// <summary>
        /// Tests the <see cref="BoundingOrientedBox"/> for intersection with a <see cref="BoundingSphere"/>.
        /// </summary>
        /// <param name="sh">The <see cref="BoundingSphere"/> to test for intersection.</param>
        /// <returns>A boolean value indicating whether the <see cref="BoundingOrientedBox"/> intersects the <see cref="BoundingSphere"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Intersects(BoundingSphere sh)
        {
            XMVector sphereCenter = sh.Center;
            XMVector sphereRadius = XMVector.Replicate(sh.Radius);

            XMVector boxCenter = this.center;
            XMVector boxExtents = this.extents;
            XMVector boxOrientation = this.orientation;

            Debug.Assert(Internal.XMQuaternionIsUnit(boxOrientation), "Reviewed");

            // Transform the center of the sphere to be local to the box.
            // BoxMin = -BoxExtents
            // BoxMax = +BoxExtents
            sphereCenter = XMVector3.InverseRotate(sphereCenter - boxCenter, boxOrientation);

            //// Find the distance to the nearest point on the box.
            //// for each i in (x, y, z)
            //// if (SphereCenter(i) < BoxMin(i)) d2 += (SphereCenter(i) - BoxMin(i)) ^ 2
            //// else if (SphereCenter(i) > BoxMax(i)) d2 += (SphereCenter(i) - BoxMax(i)) ^ 2

            XMVector d = XMGlobalConstants.Zero;

            // Compute d for each dimension.
            XMVector lessThanMin = XMVector.Less(sphereCenter, -boxExtents);
            XMVector greaterThanMax = XMVector.Greater(sphereCenter, boxExtents);

            XMVector minDelta = sphereCenter + boxExtents;
            XMVector maxDelta = sphereCenter - boxExtents;

            // Choose value for each dimension based on the comparison.
            d = XMVector.Select(d, minDelta, lessThanMin);
            d = XMVector.Select(d, maxDelta, greaterThanMax);

            // Use a dot-product to square them and sum them together.
            XMVector d2 = XMVector3.Dot(d, d);

            return XMVector4.LessOrEqual(d2, XMVector.Multiply(sphereRadius, sphereRadius)) ? true : false;
        }

        /// <summary>
        /// Tests the <see cref="BoundingOrientedBox"/> for intersection with a <see cref="BoundingBox"/>.
        /// </summary>
        /// <param name="box">The <see cref="BoundingBox"/> to test for intersection.</param>
        /// <returns>A boolean value indicating whether the <see cref="BoundingOrientedBox"/> intersects the <see cref="BoundingBox"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Intersects(BoundingBox box)
        {
            // Make the axis aligned box oriented and do an OBB vs OBB test.
            BoundingOrientedBox obox = new BoundingOrientedBox(box.Center, box.Extents, new XMFloat4(0.0f, 0.0f, 0.0f, 1.0f));
            return this.Intersects(obox);
        }

        /// <summary>
        /// Tests the <see cref="BoundingOrientedBox"/> for intersection with a <see cref="BoundingOrientedBox"/>.
        /// </summary>
        /// <param name="box">The <see cref="BoundingOrientedBox"/> to test for intersection.</param>
        /// <returns>A boolean value indicating whether the <see cref="BoundingOrientedBox"/> intersects the <see cref="BoundingOrientedBox"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Intersects(BoundingOrientedBox box)
        {
            // Build the 3x3 rotation matrix that defines the orientation of B relative to A.
            XMVector a_quat = this.orientation;
            XMVector b_quat = box.orientation;

            Debug.Assert(Internal.XMQuaternionIsUnit(a_quat), "Reviewed");
            Debug.Assert(Internal.XMQuaternionIsUnit(b_quat), "Reviewed");

            XMVector q = XMQuaternion.Multiply(a_quat, XMQuaternion.Conjugate(b_quat));
            XMMatrix r = XMMatrix.RotationQuaternion(q);

            // Compute the translation of B relative to A.
            XMVector a_cent = this.center;
            XMVector b_cent = box.center;
            XMVector t = XMVector3.InverseRotate(b_cent - a_cent, a_quat);

            //// h(A) = extents of A.
            //// h(B) = extents of B.
            ////
            //// a(u) = axes of A = (1,0,0), (0,1,0), (0,0,1)
            //// b(u) = axes of B relative to A = (r00,r10,r20), (r01,r11,r21), (r02,r12,r22)
            ////  
            //// For each possible separating axis l:
            ////   d(A) = sum (for i = u,v,w) h(A)(i) * abs( a(i) dot l )
            ////   d(B) = sum (for i = u,v,w) h(B)(i) * abs( b(i) dot l )
            ////   if abs( t dot l ) > d(A) + d(B) then disjoint

            // Load extents of A and B.
            XMVector h_A = this.extents;
            XMVector h_B = box.extents;

            // Rows. Note R[0,1,2]X.w = 0.
            XMVector r0X = ((XMVector*)&r)[0];
            XMVector r1X = ((XMVector*)&r)[1];
            XMVector r2X = ((XMVector*)&r)[2];

            r = r.Transpose();

            // Columns. Note RX[0,1,2].w = 0.
            XMVector rX0 = ((XMVector*)&r)[0];
            XMVector rX1 = ((XMVector*)&r)[1];
            XMVector rX2 = ((XMVector*)&r)[2];

            // Absolute value of rows.
            XMVector abs_R0X = r0X.Abs();
            XMVector abs_R1X = r1X.Abs();
            XMVector abs_R2X = r2X.Abs();

            // Absolute value of columns.
            XMVector abs_RX0 = rX0.Abs();
            XMVector abs_RX1 = rX1.Abs();
            XMVector abs_RX2 = rX2.Abs();

            // Test each of the 15 possible seperating axii.
            XMVector d, d_A, d_B;

            // l = a(u) = (1, 0, 0)
            // t dot l = t.x
            // d(A) = h(A).x
            // d(B) = h(B) dot abs(r00, r01, r02)
            d = XMVector.SplatX(t);
            d_A = XMVector.SplatX(h_A);
            d_B = XMVector3.Dot(h_B, abs_R0X);
            XMVector noIntersection = XMVector.Greater(d.Abs(), XMVector.Add(d_A, d_B));

            // l = a(v) = (0, 1, 0)
            // t dot l = t.y
            // d(A) = h(A).y
            // d(B) = h(B) dot abs(r10, r11, r12)
            d = XMVector.SplatY(t);
            d_A = XMVector.SplatY(h_A);
            d_B = XMVector3.Dot(h_B, abs_R1X);
            noIntersection = XMVector.OrInt(noIntersection, XMVector.Greater(d.Abs(), XMVector.Add(d_A, d_B)));

            // l = a(w) = (0, 0, 1)
            // t dot l = t.z
            // d(A) = h(A).z
            // d(B) = h(B) dot abs(r20, r21, r22)
            d = XMVector.SplatZ(t);
            d_A = XMVector.SplatZ(h_A);
            d_B = XMVector3.Dot(h_B, abs_R2X);
            noIntersection = XMVector.OrInt(noIntersection, XMVector.Greater(d.Abs(), XMVector.Add(d_A, d_B)));

            // l = b(u) = (r00, r10, r20)
            // d(A) = h(A) dot abs(r00, r10, r20)
            // d(B) = h(B).x
            d = XMVector3.Dot(t, rX0);
            d_A = XMVector3.Dot(h_A, abs_RX0);
            d_B = XMVector.SplatX(h_B);
            noIntersection = XMVector.OrInt(noIntersection, XMVector.Greater(d.Abs(), XMVector.Add(d_A, d_B)));

            // l = b(v) = (r01, r11, r21)
            // d(A) = h(A) dot abs(r01, r11, r21)
            // d(B) = h(B).y
            d = XMVector3.Dot(t, rX1);
            d_A = XMVector3.Dot(h_A, abs_RX1);
            d_B = XMVector.SplatY(h_B);
            noIntersection = XMVector.OrInt(noIntersection, XMVector.Greater(d.Abs(), XMVector.Add(d_A, d_B)));

            // l = b(w) = (r02, r12, r22)
            // d(A) = h(A) dot abs(r02, r12, r22)
            // d(B) = h(B).z
            d = XMVector3.Dot(t, rX2);
            d_A = XMVector3.Dot(h_A, abs_RX2);
            d_B = XMVector.SplatZ(h_B);
            noIntersection = XMVector.OrInt(noIntersection, XMVector.Greater(d.Abs(), XMVector.Add(d_A, d_B)));

            // l = a(u) x b(u) = (0, -r20, r10)
            // d(A) = h(A) dot abs(0, r20, r10)
            // d(B) = h(B) dot abs(0, r02, r01)
            d = XMVector3.Dot(t, new XMVector(rX0.W, -rX0.Z, rX0.Y, rX0.X));
            d_A = XMVector3.Dot(h_A, new XMVector(abs_RX0.W, abs_RX0.Z, abs_RX0.Y, abs_RX0.X));
            d_B = XMVector3.Dot(h_B, new XMVector(abs_R0X.W, abs_R0X.Z, abs_R0X.Y, abs_R0X.X));
            noIntersection = XMVector.OrInt(noIntersection, XMVector.Greater(d.Abs(), XMVector.Add(d_A, d_B)));

            // l = a(u) x b(v) = (0, -r21, r11)
            // d(A) = h(A) dot abs(0, r21, r11)
            // d(B) = h(B) dot abs(r02, 0, r00)
            d = XMVector3.Dot(t, new XMVector(rX1.W, -rX1.Z, rX1.Y, rX1.X));
            d_A = XMVector3.Dot(h_A, new XMVector(abs_RX1.W, abs_RX1.Z, abs_RX1.Y, abs_RX1.X));
            d_B = XMVector3.Dot(h_B, new XMVector(abs_R0X.Z, abs_R0X.W, abs_R0X.X, abs_R0X.Y));
            noIntersection = XMVector.OrInt(noIntersection, XMVector.Greater(d.Abs(), XMVector.Add(d_A, d_B)));

            // l = a(u) x b(w) = (0, -r22, r12)
            // d(A) = h(A) dot abs(0, r22, r12)
            // d(B) = h(B) dot abs(r01, r00, 0)
            d = XMVector3.Dot(t, new XMVector(rX2.W, -rX2.Z, rX2.Y, rX2.X));
            d_A = XMVector3.Dot(h_A, new XMVector(abs_RX2.W, abs_RX2.Z, abs_RX2.Y, abs_RX2.X));
            d_B = XMVector3.Dot(h_B, new XMVector(abs_R0X.Y, abs_R0X.X, abs_R0X.W, abs_R0X.Z));
            noIntersection = XMVector.OrInt(noIntersection, XMVector.Greater(d.Abs(), XMVector.Add(d_A, d_B)));

            // l = a(v) x b(u) = (r20, 0, -r00)
            // d(A) = h(A) dot abs(r20, 0, r00)
            // d(B) = h(B) dot abs(0, r12, r11)
            d = XMVector3.Dot(t, new XMVector(rX0.Z, rX0.W, -rX0.X, rX0.Y));
            d_A = XMVector3.Dot(h_A, new XMVector(abs_RX0.Z, abs_RX0.W, abs_RX0.X, abs_RX0.Y));
            d_B = XMVector3.Dot(h_B, new XMVector(abs_R1X.W, abs_R1X.Z, abs_R1X.Y, abs_R1X.X));
            noIntersection = XMVector.OrInt(noIntersection, XMVector.Greater(d.Abs(), XMVector.Add(d_A, d_B)));

            // l = a(v) x b(v) = (r21, 0, -r01)
            // d(A) = h(A) dot abs(r21, 0, r01)
            // d(B) = h(B) dot abs(r12, 0, r10)
            d = XMVector3.Dot(t, new XMVector(rX1.Z, rX1.W, -rX1.X, rX1.Y));
            d_A = XMVector3.Dot(h_A, new XMVector(abs_RX1.Z, abs_RX1.W, abs_RX1.X, abs_RX1.Y));
            d_B = XMVector3.Dot(h_B, new XMVector(abs_R1X.Z, abs_R1X.W, abs_R1X.X, abs_R1X.Y));
            noIntersection = XMVector.OrInt(noIntersection, XMVector.Greater(d.Abs(), XMVector.Add(d_A, d_B)));

            // l = a(v) x b(w) = (r22, 0, -r02)
            // d(A) = h(A) dot abs(r22, 0, r02)
            // d(B) = h(B) dot abs(r11, r10, 0)
            d = XMVector3.Dot(t, new XMVector(rX2.Z, rX2.W, -rX2.X, rX2.Y));
            d_A = XMVector3.Dot(h_A, new XMVector(abs_RX2.Z, abs_RX2.W, abs_RX2.X, abs_RX2.Y));
            d_B = XMVector3.Dot(h_B, new XMVector(abs_R1X.Y, abs_R1X.X, abs_R1X.W, abs_R1X.Z));
            noIntersection = XMVector.OrInt(noIntersection, XMVector.Greater(d.Abs(), XMVector.Add(d_A, d_B)));

            // l = a(w) x b(u) = (-r10, r00, 0)
            // d(A) = h(A) dot abs(r10, r00, 0)
            // d(B) = h(B) dot abs(0, r22, r21)
            d = XMVector3.Dot(t, new XMVector(-rX0.Y, rX0.X, rX0.W, rX0.Z));
            d_A = XMVector3.Dot(h_A, new XMVector(abs_RX0.Y, abs_RX0.X, abs_RX0.W, abs_RX0.Z));
            d_B = XMVector3.Dot(h_B, new XMVector(abs_R2X.W, abs_R2X.Z, abs_R2X.Y, abs_R2X.X));
            noIntersection = XMVector.OrInt(noIntersection, XMVector.Greater(d.Abs(), XMVector.Add(d_A, d_B)));

            // l = a(w) x b(v) = (-r11, r01, 0)
            // d(A) = h(A) dot abs(r11, r01, 0)
            // d(B) = h(B) dot abs(r22, 0, r20)
            d = XMVector3.Dot(t, new XMVector(-rX1.Y, rX1.X, rX1.W, rX1.Z));
            d_A = XMVector3.Dot(h_A, new XMVector(abs_RX1.Y, abs_RX1.X, abs_RX1.W, abs_RX1.Z));
            d_B = XMVector3.Dot(h_B, new XMVector(abs_R2X.Z, abs_R2X.W, abs_R2X.X, abs_R2X.Y));
            noIntersection = XMVector.OrInt(noIntersection, XMVector.Greater(d.Abs(), XMVector.Add(d_A, d_B)));

            // l = a(w) x b(w) = (-r12, r02, 0)
            // d(A) = h(A) dot abs(r12, r02, 0)
            // d(B) = h(B) dot abs(r21, r20, 0)
            d = XMVector3.Dot(t, new XMVector(-rX2.Y, rX2.X, rX2.W, rX2.Z));
            d_A = XMVector3.Dot(h_A, new XMVector(abs_RX2.Y, abs_RX2.X, abs_RX2.W, abs_RX2.Z));
            d_B = XMVector3.Dot(h_B, new XMVector(abs_R2X.Y, abs_R2X.X, abs_R2X.W, abs_R2X.Z));
            noIntersection = XMVector.OrInt(noIntersection, XMVector.Greater(d.Abs(), XMVector.Add(d_A, d_B)));

            // No seperating axis found, boxes must intersect.
            return XMVector4.NotEqualInt(noIntersection, XMVector.TrueInt) ? true : false;
        }

        /// <summary>
        /// Tests the <see cref="BoundingOrientedBox"/> for intersection with a <see cref="BoundingFrustum"/>.
        /// </summary>
        /// <param name="fr">The <see cref="BoundingFrustum"/> to test for intersection.</param>
        /// <returns>A boolean value indicating whether the <see cref="BoundingOrientedBox"/> intersects the <see cref="BoundingFrustum"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Intersects(BoundingFrustum fr)
        {
            return fr.Intersects(this);
        }

        /// <summary>
        /// Tests the <see cref="BoundingOrientedBox"/> for intersection with a triangle.
        /// </summary>
        /// <param name="v0">The first vector describing the triangle.</param>
        /// <param name="v1">The second vector describing the triangle.</param>
        /// <param name="v2">The third vector describing the triangle.</param>
        /// <returns>A boolean value indicating whether the <see cref="BoundingOrientedBox"/> intersects the triangle.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Intersects(XMVector v0, XMVector v1, XMVector v2)
        {
            // Load the box center & orientation.
            XMVector v_center = this.center;
            XMVector v_orientation = this.orientation;

            // Transform the triangle vertices into the space of the box.
            XMVector tV0 = XMVector3.InverseRotate(v0 - v_center, v_orientation);
            XMVector tV1 = XMVector3.InverseRotate(v1 - v_center, v_orientation);
            XMVector tV2 = XMVector3.InverseRotate(v2 - v_center, v_orientation);

            BoundingBox box = new BoundingBox(new XMFloat3(0.0f, 0.0f, 0.0f), this.extents);

            // Use the triangle vs axis aligned box intersection routine.
            return box.Intersects(tV0, tV1, tV2);
        }

        /// <summary>
        /// Tests the <see cref="BoundingOrientedBox"/> for intersection with a plane.
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
            XMVector boxOrientation = this.orientation;

            Debug.Assert(Internal.XMQuaternionIsUnit(boxOrientation), "Reviewed");

            // Set w of the center to one so we can dot4 with a plane.
            v_center.W = 1.0f;

            // Build the 3x3 rotation matrix that defines the box axes.
            XMMatrix r = XMMatrix.RotationQuaternion(boxOrientation);

            XMVector outside, inside;
            Internal.FastIntersectOrientedBoxPlane(v_center, v_extents, ((XMVector*)&r)[0], ((XMVector*)&r)[1], ((XMVector*)&r)[2], plane, out outside, out inside);

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
        /// Tests the <see cref="BoundingOrientedBox"/> for intersection with a ray.
        /// </summary>
        /// <param name="origin">The origin of the ray.</param>
        /// <param name="direction">The direction of the ray.</param>
        /// <returns>A boolean value indicating whether the <see cref="BoundingOrientedBox"/> intersects the ray.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Intersects(XMVector origin, XMVector direction)
        {
            float distance;
            return this.Intersects(origin, direction, out distance);
        }

        /// <summary>
        /// Tests the <see cref="BoundingOrientedBox"/> for intersection with a ray.
        /// </summary>
        /// <param name="origin">The origin of the ray.</param>
        /// <param name="direction">The direction of the ray.</param>
        /// <param name="distance">The length of the ray.</param>
        /// <returns>A boolean value indicating whether the <see cref="BoundingOrientedBox"/> intersects the ray.</returns>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "2#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Intersects(XMVector origin, XMVector direction, out float distance)
        {
            Debug.Assert(Internal.XMVector3IsUnit(direction), "Reviewed");

            XMVector selectY = XMVector.FromInt((uint)XMSelection.Select0, (uint)XMSelection.Select1, (uint)XMSelection.Select0, (uint)XMSelection.Select0);
            XMVector selectZ = XMVector.FromInt((uint)XMSelection.Select0, (uint)XMSelection.Select0, (uint)XMSelection.Select1, (uint)XMSelection.Select0);

            // Load the box.
            XMVector v_center = this.center;
            XMVector v_extents = this.extents;
            XMVector v_orientation = this.orientation;

            Debug.Assert(Internal.XMQuaternionIsUnit(v_orientation), "Reviewed");

            // Get the boxes normalized side directions.
            XMMatrix r = XMMatrix.RotationQuaternion(v_orientation);

            // Adjust ray origin to be relative to center of the box.
            XMVector t_origin = v_center - origin;

            // Compute the dot product againt each axis of the box.
            XMVector axisDotOrigin = XMVector3.Dot(((XMVector*)&r)[0], t_origin);
            axisDotOrigin = XMVector.Select(axisDotOrigin, XMVector3.Dot(((XMVector*)&r)[1], t_origin), selectY);
            axisDotOrigin = XMVector.Select(axisDotOrigin, XMVector3.Dot(((XMVector*)&r)[2], t_origin), selectZ);

            XMVector axisDotDirection = XMVector3.Dot(((XMVector*)&r)[0], direction);
            axisDotDirection = XMVector.Select(axisDotDirection, XMVector3.Dot(((XMVector*)&r)[1], direction), selectY);
            axisDotDirection = XMVector.Select(axisDotDirection, XMVector3.Dot(((XMVector*)&r)[2], direction), selectZ);

            // if (fabs(AxisDotDirection) <= Epsilon) the ray is nearly parallel to the slab.
            XMVector isParallel = XMVector.LessOrEqual(axisDotDirection.Abs(), CollisionGlobalConstants.RayEpsilon);

            // Test against all three axes simultaneously.
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
        /// Tests whether the <see cref="BoundingOrientedBox"/> is contained by a frustum.
        /// </summary>
        /// <param name="planes">The planes describing the frustum.</param>
        /// <returns>A <see cref="ContainmentType"/> indicating whether the frustum contains the <see cref="BoundingOrientedBox"/>.</returns>
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
        /// Tests whether the <see cref="BoundingOrientedBox"/> is contained by a frustum.
        /// </summary>
        /// <param name="plane0">The first plane describing the frustum.</param>
        /// <param name="plane1">The second plane describing the frustum.</param>
        /// <param name="plane2">The third plane describing the frustum.</param>
        /// <param name="plane3">The fourth plane describing the frustum.</param>
        /// <param name="plane4">The fifth plane describing the frustum.</param>
        /// <param name="plane5">The sixth plane describing the frustum.</param>
        /// <returns>A <see cref="ContainmentType"/> indicating whether the frustum contains the <see cref="BoundingOrientedBox"/>.</returns>
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
            XMVector boxOrientation = this.orientation;

            Debug.Assert(Internal.XMQuaternionIsUnit(boxOrientation), "Reviewed");

            // Set w of the center to one so we can dot4 with a plane.
            v_center.W = 1.0f;

            // Build the 3x3 rotation matrix that defines the box axes.
            XMMatrix r = XMMatrix.RotationQuaternion(boxOrientation);

            XMVector outside, inside;

            // Test against each plane.
            Internal.FastIntersectOrientedBoxPlane(v_center, v_extents, ((XMVector*)&r)[0], ((XMVector*)&r)[1], ((XMVector*)&r)[2], plane0, out outside, out inside);

            XMVector anyOutside = outside;
            XMVector allInside = inside;

            Internal.FastIntersectOrientedBoxPlane(v_center, v_extents, ((XMVector*)&r)[0], ((XMVector*)&r)[1], ((XMVector*)&r)[2], plane1, out outside, out inside);
            anyOutside = XMVector.OrInt(anyOutside, outside);
            allInside = XMVector.AndInt(allInside, inside);

            Internal.FastIntersectOrientedBoxPlane(v_center, v_extents, ((XMVector*)&r)[0], ((XMVector*)&r)[1], ((XMVector*)&r)[2], plane2, out outside, out inside);
            anyOutside = XMVector.OrInt(anyOutside, outside);
            allInside = XMVector.AndInt(allInside, inside);

            Internal.FastIntersectOrientedBoxPlane(v_center, v_extents, ((XMVector*)&r)[0], ((XMVector*)&r)[1], ((XMVector*)&r)[2], plane3, out outside, out inside);
            anyOutside = XMVector.OrInt(anyOutside, outside);
            allInside = XMVector.AndInt(allInside, inside);

            Internal.FastIntersectOrientedBoxPlane(v_center, v_extents, ((XMVector*)&r)[0], ((XMVector*)&r)[1], ((XMVector*)&r)[2], plane4, out outside, out inside);
            anyOutside = XMVector.OrInt(anyOutside, outside);
            allInside = XMVector.AndInt(allInside, inside);

            Internal.FastIntersectOrientedBoxPlane(v_center, v_extents, ((XMVector*)&r)[0], ((XMVector*)&r)[1], ((XMVector*)&r)[2], plane5, out outside, out inside);
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
