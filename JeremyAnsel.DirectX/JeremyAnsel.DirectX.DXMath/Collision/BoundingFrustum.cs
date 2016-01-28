// <copyright file="BoundingFrustum.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DXMath.Collision
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    /// <summary>
    /// A bounding frustum object.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BoundingFrustum : IEquatable<BoundingFrustum>
    {
        /// <summary>
        /// The number of corners defining the <see cref="BoundingFrustum"/>.
        /// </summary>
        public const int CornerCount = 8;

        /// <summary>
        /// The origin of the <see cref="BoundingFrustum"/>.
        /// </summary>
        private XMFloat3 origin;

        /// <summary>
        /// The orientation of the <see cref="BoundingFrustum"/> represented as a quaternion.
        /// </summary>
        private XMFloat4 orientation;

        /// <summary>
        /// The slope of the right side of the <see cref="BoundingFrustum"/>.
        /// </summary>
        private float rightSlope;

        /// <summary>
        /// The slope of the left side of the <see cref="BoundingFrustum"/>.
        /// </summary>
        private float leftSlope;

        /// <summary>
        /// The slope of the top of the <see cref="BoundingFrustum"/>.
        /// </summary>
        private float topSlope;

        /// <summary>
        /// The slope of the bottom of the <see cref="BoundingFrustum"/>.
        /// </summary>
        private float bottomSlope;

        /// <summary>
        /// The distance of the near plane of the <see cref="BoundingFrustum"/> from its origin.
        /// </summary>
        private float near;

        /// <summary>
        /// The distance of the far plane from the origin of the <see cref="BoundingFrustum"/>.
        /// </summary>
        private float far;

        /// <summary>
        /// Initializes a new instance of the <see cref="BoundingFrustum"/> struct.
        /// </summary>
        /// <param name="origin">The origin of the frustum.</param>
        /// <param name="orientation">The orientation of the frustum.</param>
        /// <param name="rightSlope">The slope of the right side of the frustum.</param>
        /// <param name="leftSlope">The slope of the left side of the frustum.</param>
        /// <param name="topSlope">The slope of the top of the frustum.</param>
        /// <param name="bottomSlope">The slope of the bottom of the frustum.</param>
        /// <param name="near">The distance of the near plane from the origin of the frustum.</param>
        /// <param name="far">The distance of the far plane from the origin of the frustum.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public BoundingFrustum(
            XMFloat3 origin,
            XMFloat4 orientation,
            float rightSlope,
            float leftSlope,
            float topSlope,
            float bottomSlope,
            float near,
            float far)
        {
            Debug.Assert(near <= far, "Reviewed");

            this.origin = origin;
            this.orientation = orientation;
            this.rightSlope = rightSlope;
            this.leftSlope = leftSlope;
            this.topSlope = topSlope;
            this.bottomSlope = bottomSlope;
            this.near = near;
            this.far = far;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BoundingFrustum"/> struct from a left-handed projection matrix..
        /// </summary>
        /// <param name="projection">The left-handed projection matrix to create the frustum from.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public BoundingFrustum(XMMatrix projection)
        {
            this = BoundingFrustum.CreateFromMatrix(projection);
        }

        /// <summary>
        /// Gets or sets the origin of the <see cref="BoundingFrustum"/>.
        /// </summary>
        public XMFloat3 Origin
        {
            get { return this.origin; }
            set { this.origin = value; }
        }

        /// <summary>
        /// Gets or sets the orientation of the <see cref="BoundingFrustum"/> represented as a quaternion.
        /// </summary>
        public XMFloat4 Orientation
        {
            get { return this.orientation; }
            set { this.orientation = value; }
        }

        /// <summary>
        /// Gets or sets the slope of the right side of the <see cref="BoundingFrustum"/>.
        /// </summary>
        public float RightSlope
        {
            get { return this.rightSlope; }
            set { this.rightSlope = value; }
        }

        /// <summary>
        /// Gets or sets the slope of the left side of the <see cref="BoundingFrustum"/>.
        /// </summary>
        public float LeftSlope
        {
            get { return this.leftSlope; }
            set { this.leftSlope = value; }
        }

        /// <summary>
        /// Gets or sets the slope of the top of the <see cref="BoundingFrustum"/>.
        /// </summary>
        public float TopSlope
        {
            get { return this.topSlope; }
            set { this.topSlope = value; }
        }

        /// <summary>
        /// Gets or sets the slope of the bottom of the <see cref="BoundingFrustum"/>.
        /// </summary>
        public float BottomSlope
        {
            get { return this.bottomSlope; }
            set { this.bottomSlope = value; }
        }

        /// <summary>
        /// Gets or sets the distance of the near plane of the <see cref="BoundingFrustum"/> from its origin.
        /// </summary>
        public float Near
        {
            get { return this.near; }
            set { this.near = value; }
        }

        /// <summary>
        /// Gets or sets the distance of the far plane from the origin of the <see cref="BoundingFrustum"/>.
        /// </summary>
        public float Far
        {
            get { return this.far; }
            set { this.far = value; }
        }

        /// <summary>
        /// Compares two <see cref="BoundingFrustum"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="BoundingFrustum"/> to compare.</param>
        /// <param name="right">The right <see cref="BoundingFrustum"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(BoundingFrustum left, BoundingFrustum right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="BoundingFrustum"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="BoundingFrustum"/> to compare.</param>
        /// <param name="right">The right <see cref="BoundingFrustum"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(BoundingFrustum left, BoundingFrustum right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Creates a <see cref="BoundingFrustum"/> from the specified projection matrix.
        /// </summary>
        /// <param name="projection">The left-handed projection matrix to create the <see cref="BoundingFrustum"/> from.</param>
        /// <returns>The new <see cref="BoundingFrustum"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BoundingFrustum CreateFromMatrix(XMMatrix projection)
        {
            // Corners of the projection frustum in homogenous space.
            XMVector[] homogenousPoints = new XMVector[6]
            {
                new XMVector(1.0f, 0.0f, 1.0f, 1.0f),   // right (at far plane)
                new XMVector(-1.0f, 0.0f, 1.0f, 1.0f),   // left
                new XMVector(0.0f, 1.0f, 1.0f, 1.0f),   // top
                new XMVector(0.0f, -1.0f, 1.0f, 1.0f),   // bottom

                new XMVector(0.0f, 0.0f, 0.0f, 1.0f),     // near
                new XMVector(0.0f, 0.0f, 1.0f, 1.0f)      // far
            };

            XMVector determinant;
            XMMatrix matInverse = projection.Inverse(out determinant);

            // Compute the frustum corners in world space.
            XMVector[] points = new XMVector[6];

            for (int i = 0; i < 6; i++)
            {
                // Transform point.
                points[i] = XMVector4.Transform(homogenousPoints[i], matInverse);
            }

            BoundingFrustum result;

            result.origin = new XMFloat3(0.0f, 0.0f, 0.0f);
            result.orientation = new XMFloat4(0.0f, 0.0f, 0.0f, 1.0f);

            // Compute the slopes.
            points[0] = points[0] * XMVector.SplatZ(points[0]).Reciprocal();
            points[1] = points[1] * XMVector.SplatZ(points[1]).Reciprocal();
            points[2] = points[2] * XMVector.SplatZ(points[2]).Reciprocal();
            points[3] = points[3] * XMVector.SplatZ(points[3]).Reciprocal();

            result.rightSlope = points[0].X;
            result.leftSlope = points[1].X;
            result.topSlope = points[2].Y;
            result.bottomSlope = points[3].Y;

            // Compute near and far.
            points[4] = points[4] * XMVector.SplatW(points[4]).Reciprocal();
            points[5] = points[5] * XMVector.SplatW(points[5]).Reciprocal();

            result.near = points[4].Z;
            result.far = points[5].Z;

            return result;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is BoundingFrustum))
            {
                return false;
            }

            return this.Equals((BoundingFrustum)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(BoundingFrustum other)
        {
            return this.origin == other.origin
                && this.orientation == other.orientation
                && this.rightSlope == other.rightSlope
                && this.leftSlope == other.leftSlope
                && this.topSlope == other.topSlope
                && this.bottomSlope == other.bottomSlope
                && this.near == other.near
                && this.far == other.far;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.origin,
                this.orientation,
                this.rightSlope,
                this.leftSlope,
                this.topSlope,
                this.bottomSlope,
                this.near,
                this.far
            }
            .GetHashCode();
        }

        /// <summary>
        /// Transforms the <see cref="BoundingFrustum"/> by the specified transformation matrix.
        /// </summary>
        /// <param name="m">The transformation matrix.</param>
        /// <returns>The transformed <see cref="BoundingFrustum"/>.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "m", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public BoundingFrustum Transform(XMMatrix m)
        {
            // Load the frustum.
            XMVector v_origin = this.origin;
            XMVector v_orientation = this.orientation;

            Debug.Assert(Internal.XMQuaternionIsUnit(v_orientation), "Reviewed");

            // Composite the frustum rotation and the transform rotation
            XMMatrix nM;
            ((XMVector*)&nM)[0] = XMVector3.Normalize(((XMVector*)&m)[0]);
            ((XMVector*)&nM)[1] = XMVector3.Normalize(((XMVector*)&m)[1]);
            ((XMVector*)&nM)[2] = XMVector3.Normalize(((XMVector*)&m)[2]);
            ((XMVector*)&nM)[3] = XMGlobalConstants.IdentityR3;
            XMVector rotation = XMQuaternion.RotationMatrix(nM);
            v_orientation = XMQuaternion.Multiply(v_orientation, rotation);

            // Transform the center.
            v_origin = XMVector3.Transform(v_origin, m);

            // Store the frustum.
            BoundingFrustum result;

            result.origin = v_origin;
            result.orientation = v_orientation;

            // Scale the near and far distances (the slopes remain the same).
            XMVector dX = XMVector3.Dot(((XMVector*)&m)[0], ((XMVector*)&m)[0]);
            XMVector dY = XMVector3.Dot(((XMVector*)&m)[1], ((XMVector*)&m)[1]);
            XMVector dZ = XMVector3.Dot(((XMVector*)&m)[2], ((XMVector*)&m)[2]);

            XMVector d = XMVector.Max(dX, XMVector.Max(dY, dZ));
            float scale = (float)Math.Sqrt(d.X);

            result.near = this.near * scale;
            result.far = this.far * scale;

            // Copy the slopes.
            result.rightSlope = this.rightSlope;
            result.leftSlope = this.leftSlope;
            result.topSlope = this.topSlope;
            result.bottomSlope = this.bottomSlope;

            return result;
        }

        /// <summary>
        /// Transforms the <see cref="BoundingFrustum"/> using the specified scale, rotation and translation vectors.
        /// </summary>
        /// <param name="scale">The value to scale the <see cref="BoundingFrustum"/> by.</param>
        /// <param name="rotation">The value to rotate the <see cref="BoundingFrustum"/> by.</param>
        /// <param name="translation">The value to translate the <see cref="BoundingFrustum"/> by.</param>
        /// <returns>The transformed <see cref="BoundingFrustum"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public BoundingFrustum Transform(float scale, XMVector rotation, XMVector translation)
        {
            Debug.Assert(Internal.XMQuaternionIsUnit(rotation), "Reviewed");

            // Load the frustum.
            XMVector v_origin = this.origin;
            XMVector v_orientation = this.orientation;

            Debug.Assert(Internal.XMQuaternionIsUnit(v_orientation), "Reviewed");

            // Composite the frustum rotation and the transform rotation.
            v_orientation = XMQuaternion.Multiply(v_orientation, rotation);

            // Transform the origin.
            v_origin = XMVector3.Rotate(v_origin * XMVector.Replicate(scale), rotation) + translation;

            // Store the frustum.
            BoundingFrustum result;

            result.origin = v_origin;
            result.orientation = v_orientation;

            // Scale the near and far distances (the slopes remain the same).
            result.near = this.near * scale;
            result.far = this.far * scale;

            // Copy the slopes.
            result.rightSlope = this.rightSlope;
            result.leftSlope = this.leftSlope;
            result.topSlope = this.topSlope;
            result.bottomSlope = this.bottomSlope;

            return result;
        }

        /// <summary>
        /// Gets the corners making up the <see cref="BoundingFrustum"/>.
        /// </summary>
        /// <returns>The corners.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMFloat3[] GetCorners()
        {
            // Load origin and orientation of the frustum.
            XMVector v_origin = this.origin;
            XMVector v_orientation = this.orientation;

            Debug.Assert(Internal.XMQuaternionIsUnit(v_orientation), "Reviewed");

            // Build the corners of the frustum.
            XMVector v_rightTop = new XMVector(this.rightSlope, this.topSlope, 1.0f, 0.0f);
            XMVector v_rightBottom = new XMVector(this.rightSlope, this.bottomSlope, 1.0f, 0.0f);
            XMVector v_leftTop = new XMVector(this.leftSlope, this.topSlope, 1.0f, 0.0f);
            XMVector v_leftBottom = new XMVector(this.leftSlope, this.bottomSlope, 1.0f, 0.0f);
            XMVector v_near = XMVector.Replicate(this.near);
            XMVector v_far = XMVector.Replicate(this.far);

            //// Returns 8 corners position of bounding frustum.
            ////     Near    Far
            ////    0----1  4----5
            ////    |    |  |    |
            ////    |    |  |    |
            ////    3----2  7----6

            XMVector[] v_corners = new XMVector[BoundingFrustum.CornerCount];

            v_corners[0] = v_leftTop * v_near;
            v_corners[1] = v_rightTop * v_near;
            v_corners[2] = v_rightBottom * v_near;
            v_corners[3] = v_leftBottom * v_near;
            v_corners[4] = v_leftTop * v_far;
            v_corners[5] = v_rightTop * v_far;
            v_corners[6] = v_rightBottom * v_far;
            v_corners[7] = v_leftBottom * v_far;

            XMFloat3[] corners = new XMFloat3[BoundingFrustum.CornerCount];

            for (int i = 0; i < BoundingFrustum.CornerCount; i++)
            {
                corners[i] = XMVector3.Rotate(v_corners[i], v_orientation) + v_origin;
            }

            return corners;
        }

        /// <summary>
        /// Tests whether the <see cref="BoundingFrustum"/> contains the specified point.
        /// </summary>
        /// <param name="point">The point to test against.</param>
        /// <returns>A <see cref="ContainmentType"/> value indicating whether the point is contained in the <see cref="BoundingFrustum"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ContainmentType Contains(XMVector point)
        {
            // Build frustum planes.
            XMVector[] planes = new XMVector[6];
            planes[0] = new XMVector(0.0f, 0.0f, -1.0f, this.near);
            planes[1] = new XMVector(0.0f, 0.0f, 1.0f, -this.far);
            planes[2] = new XMVector(1.0f, 0.0f, -this.rightSlope, 0.0f);
            planes[3] = new XMVector(-1.0f, 0.0f, this.leftSlope, 0.0f);
            planes[4] = new XMVector(0.0f, 1.0f, -this.topSlope, 0.0f);
            planes[5] = new XMVector(0.0f, -1.0f, this.bottomSlope, 0.0f);

            // Load origin and orientation.
            XMVector v_origin = this.origin;
            XMVector v_orientation = this.orientation;

            Debug.Assert(Internal.XMQuaternionIsUnit(v_orientation), "Reviewed");

            // Transform point into local space of frustum.
            XMVector t_point = XMVector3.InverseRotate(point - v_origin, v_orientation);

            // Set w to one.
            t_point.W = 1.0f;

            XMVector zero = XMGlobalConstants.Zero;
            XMVector outside = zero;

            // Test point against each plane of the frustum.
            for (int i = 0; i < 6; i++)
            {
                XMVector dot = XMVector4.Dot(t_point, planes[i]);
                outside = XMVector.OrInt(outside, XMVector.Greater(dot, zero));
            }

            return XMVector4.NotEqualInt(outside, XMVector.TrueInt) ? ContainmentType.Contains : ContainmentType.Disjoint;
        }

        /// <summary>
        /// Tests whether the <see cref="BoundingFrustum"/> contains the specified triangle.
        /// </summary>
        /// <param name="v0">The first corner of the triangle.</param>
        /// <param name="v1">The second corner of the triangle.</param>
        /// <param name="v2">The third corner of the triangle.</param>
        /// <returns>A <see cref="ContainmentType"/> value indicating whether the triangle is contained in the <see cref="BoundingFrustum"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ContainmentType Contains(XMVector v0, XMVector v1, XMVector v2)
        {
            // Load origin and orientation of the frustum.
            XMVector v_origin = this.origin;
            XMVector v_orientation = this.orientation;

            // Create 6 planes (do it inline to encourage use of registers)
            XMVector nearPlane = new XMVector(0.0f, 0.0f, -1.0f, this.near);
            nearPlane = Internal.XMPlaneTransform(nearPlane, v_orientation, v_origin);
            nearPlane = XMPlane.Normalize(nearPlane);

            XMVector farPlane = new XMVector(0.0f, 0.0f, 1.0f, -this.far);
            farPlane = Internal.XMPlaneTransform(farPlane, v_orientation, v_origin);
            farPlane = XMPlane.Normalize(farPlane);

            XMVector rightPlane = new XMVector(1.0f, 0.0f, -this.rightSlope, 0.0f);
            rightPlane = Internal.XMPlaneTransform(rightPlane, v_orientation, v_origin);
            rightPlane = XMPlane.Normalize(rightPlane);

            XMVector leftPlane = new XMVector(-1.0f, 0.0f, this.leftSlope, 0.0f);
            leftPlane = Internal.XMPlaneTransform(leftPlane, v_orientation, v_origin);
            leftPlane = XMPlane.Normalize(leftPlane);

            XMVector topPlane = new XMVector(0.0f, 1.0f, -this.topSlope, 0.0f);
            topPlane = Internal.XMPlaneTransform(topPlane, v_orientation, v_origin);
            topPlane = XMPlane.Normalize(topPlane);

            XMVector bottomPlane = new XMVector(0.0f, -1.0f, this.bottomSlope, 0.0f);
            bottomPlane = Internal.XMPlaneTransform(bottomPlane, v_orientation, v_origin);
            bottomPlane = XMPlane.Normalize(bottomPlane);

            return TriangleTest.ContainedBy(v0, v1, v2, nearPlane, farPlane, rightPlane, leftPlane, topPlane, bottomPlane);
        }

        /// <summary>
        /// Tests whether the <see cref="BoundingFrustum"/> contains the specified <see cref="BoundingSphere"/>.
        /// </summary>
        /// <param name="sh">The <see cref="BoundingSphere"/> to test against.</param>
        /// <returns>A <see cref="ContainmentType"/> value indicating whether the <see cref="BoundingSphere"/> is contained in the <see cref="BoundingFrustum"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ContainmentType Contains(BoundingSphere sh)
        {
            // Load origin and orientation of the frustum.
            XMVector v_origin = this.origin;
            XMVector v_orientation = this.orientation;

            // Create 6 planes (do it inline to encourage use of registers)
            XMVector nearPlane = new XMVector(0.0f, 0.0f, -1.0f, this.near);
            nearPlane = Internal.XMPlaneTransform(nearPlane, v_orientation, v_origin);
            nearPlane = XMPlane.Normalize(nearPlane);

            XMVector farPlane = new XMVector(0.0f, 0.0f, 1.0f, -this.far);
            farPlane = Internal.XMPlaneTransform(farPlane, v_orientation, v_origin);
            farPlane = XMPlane.Normalize(farPlane);

            XMVector rightPlane = new XMVector(1.0f, 0.0f, -this.rightSlope, 0.0f);
            rightPlane = Internal.XMPlaneTransform(rightPlane, v_orientation, v_origin);
            rightPlane = XMPlane.Normalize(rightPlane);

            XMVector leftPlane = new XMVector(-1.0f, 0.0f, this.leftSlope, 0.0f);
            leftPlane = Internal.XMPlaneTransform(leftPlane, v_orientation, v_origin);
            leftPlane = XMPlane.Normalize(leftPlane);

            XMVector topPlane = new XMVector(0.0f, 1.0f, -this.topSlope, 0.0f);
            topPlane = Internal.XMPlaneTransform(topPlane, v_orientation, v_origin);
            topPlane = XMPlane.Normalize(topPlane);

            XMVector bottomPlane = new XMVector(0.0f, -1.0f, this.bottomSlope, 0.0f);
            bottomPlane = Internal.XMPlaneTransform(bottomPlane, v_orientation, v_origin);
            bottomPlane = XMPlane.Normalize(bottomPlane);

            return sh.ContainedBy(nearPlane, farPlane, rightPlane, leftPlane, topPlane, bottomPlane);
        }

        /// <summary>
        /// Tests whether the <see cref="BoundingFrustum"/> contains the specified <see cref="BoundingBox"/>.
        /// </summary>
        /// <param name="box">The <see cref="BoundingBox"/> to test against.</param>
        /// <returns>A <see cref="ContainmentType"/> value indicating whether the <see cref="BoundingBox"/> is contained in the <see cref="BoundingFrustum"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ContainmentType Contains(BoundingBox box)
        {
            // Load origin and orientation of the frustum.
            XMVector v_origin = this.origin;
            XMVector v_orientation = this.orientation;

            // Create 6 planes (do it inline to encourage use of registers)
            XMVector nearPlane = new XMVector(0.0f, 0.0f, -1.0f, this.near);
            nearPlane = Internal.XMPlaneTransform(nearPlane, v_orientation, v_origin);
            nearPlane = XMPlane.Normalize(nearPlane);

            XMVector farPlane = new XMVector(0.0f, 0.0f, 1.0f, -this.far);
            farPlane = Internal.XMPlaneTransform(farPlane, v_orientation, v_origin);
            farPlane = XMPlane.Normalize(farPlane);

            XMVector rightPlane = new XMVector(1.0f, 0.0f, -this.rightSlope, 0.0f);
            rightPlane = Internal.XMPlaneTransform(rightPlane, v_orientation, v_origin);
            rightPlane = XMPlane.Normalize(rightPlane);

            XMVector leftPlane = new XMVector(-1.0f, 0.0f, this.leftSlope, 0.0f);
            leftPlane = Internal.XMPlaneTransform(leftPlane, v_orientation, v_origin);
            leftPlane = XMPlane.Normalize(leftPlane);

            XMVector topPlane = new XMVector(0.0f, 1.0f, -this.topSlope, 0.0f);
            topPlane = Internal.XMPlaneTransform(topPlane, v_orientation, v_origin);
            topPlane = XMPlane.Normalize(topPlane);

            XMVector bottomPlane = new XMVector(0.0f, -1.0f, this.bottomSlope, 0.0f);
            bottomPlane = Internal.XMPlaneTransform(bottomPlane, v_orientation, v_origin);
            bottomPlane = XMPlane.Normalize(bottomPlane);

            return box.ContainedBy(nearPlane, farPlane, rightPlane, leftPlane, topPlane, bottomPlane);
        }

        /// <summary>
        /// Tests whether the <see cref="BoundingFrustum"/> contains the specified <see cref="BoundingOrientedBox"/>.
        /// </summary>
        /// <param name="box">The <see cref="BoundingOrientedBox"/> to test against.</param>
        /// <returns>A <see cref="ContainmentType"/> value indicating whether the <see cref="BoundingOrientedBox"/> is contained in the <see cref="BoundingFrustum"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ContainmentType Contains(BoundingOrientedBox box)
        {
            // Load origin and orientation of the frustum.
            XMVector v_origin = this.origin;
            XMVector v_orientation = this.orientation;

            // Create 6 planes (do it inline to encourage use of registers)
            XMVector nearPlane = new XMVector(0.0f, 0.0f, -1.0f, this.near);
            nearPlane = Internal.XMPlaneTransform(nearPlane, v_orientation, v_origin);
            nearPlane = XMPlane.Normalize(nearPlane);

            XMVector farPlane = new XMVector(0.0f, 0.0f, 1.0f, -this.far);
            farPlane = Internal.XMPlaneTransform(farPlane, v_orientation, v_origin);
            farPlane = XMPlane.Normalize(farPlane);

            XMVector rightPlane = new XMVector(1.0f, 0.0f, -this.rightSlope, 0.0f);
            rightPlane = Internal.XMPlaneTransform(rightPlane, v_orientation, v_origin);
            rightPlane = XMPlane.Normalize(rightPlane);

            XMVector leftPlane = new XMVector(-1.0f, 0.0f, this.leftSlope, 0.0f);
            leftPlane = Internal.XMPlaneTransform(leftPlane, v_orientation, v_origin);
            leftPlane = XMPlane.Normalize(leftPlane);

            XMVector topPlane = new XMVector(0.0f, 1.0f, -this.topSlope, 0.0f);
            topPlane = Internal.XMPlaneTransform(topPlane, v_orientation, v_origin);
            topPlane = XMPlane.Normalize(topPlane);

            XMVector bottomPlane = new XMVector(0.0f, -1.0f, this.bottomSlope, 0.0f);
            bottomPlane = Internal.XMPlaneTransform(bottomPlane, v_orientation, v_origin);
            bottomPlane = XMPlane.Normalize(bottomPlane);

            return box.ContainedBy(nearPlane, farPlane, rightPlane, leftPlane, topPlane, bottomPlane);
        }

        /// <summary>
        /// Tests whether the <see cref="BoundingFrustum"/> contains the specified <see cref="BoundingFrustum"/>.
        /// </summary>
        /// <param name="fr">The <see cref="BoundingFrustum"/> to test against.</param>
        /// <returns>A <see cref="ContainmentType"/> value indicating whether the <see cref="BoundingFrustum"/> is contained in the <see cref="BoundingFrustum"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ContainmentType Contains(BoundingFrustum fr)
        {
            // Load origin and orientation of the frustum.
            XMVector v_origin = this.origin;
            XMVector v_orientation = this.orientation;

            // Create 6 planes (do it inline to encourage use of registers)
            XMVector nearPlane = new XMVector(0.0f, 0.0f, -1.0f, this.near);
            nearPlane = Internal.XMPlaneTransform(nearPlane, v_orientation, v_origin);
            nearPlane = XMPlane.Normalize(nearPlane);

            XMVector farPlane = new XMVector(0.0f, 0.0f, 1.0f, -this.far);
            farPlane = Internal.XMPlaneTransform(farPlane, v_orientation, v_origin);
            farPlane = XMPlane.Normalize(farPlane);

            XMVector rightPlane = new XMVector(1.0f, 0.0f, -this.rightSlope, 0.0f);
            rightPlane = Internal.XMPlaneTransform(rightPlane, v_orientation, v_origin);
            rightPlane = XMPlane.Normalize(rightPlane);

            XMVector leftPlane = new XMVector(-1.0f, 0.0f, this.leftSlope, 0.0f);
            leftPlane = Internal.XMPlaneTransform(leftPlane, v_orientation, v_origin);
            leftPlane = XMPlane.Normalize(leftPlane);

            XMVector topPlane = new XMVector(0.0f, 1.0f, -this.topSlope, 0.0f);
            topPlane = Internal.XMPlaneTransform(topPlane, v_orientation, v_origin);
            topPlane = XMPlane.Normalize(topPlane);

            XMVector bottomPlane = new XMVector(0.0f, -1.0f, this.bottomSlope, 0.0f);
            bottomPlane = Internal.XMPlaneTransform(bottomPlane, v_orientation, v_origin);
            bottomPlane = XMPlane.Normalize(bottomPlane);

            return fr.ContainedBy(nearPlane, farPlane, rightPlane, leftPlane, topPlane, bottomPlane);
        }

        /// <summary>
        /// Test the <see cref="BoundingFrustum"/> for intersection with a <see cref="BoundingSphere"/>.
        /// </summary>
        /// <param name="sh">The <see cref="BoundingSphere"/> to test for intersection.</param>
        /// <returns>A boolean value indicating whether the <see cref="BoundingFrustum"/> intersects the specified <see cref="BoundingSphere"/>.</returns>
        [SuppressMessage("Microsoft.Performance", "CA1814:PreferJaggedArraysOverMultidimensional", MessageId = "Body", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Intersects(BoundingSphere sh)
        {
            ////-----------------------------------------------------------------------------
            //// Exact sphere vs frustum test.  The algorithm first checks the sphere against
            //// the planes of the frustum, then if the plane checks were indeterminate finds
            //// the nearest feature (plane, line, point) on the frustum to the center of the
            //// sphere and compares the distance to the nearest feature to the radius of the 
            //// sphere
            ////-----------------------------------------------------------------------------

            XMVector zero = XMGlobalConstants.Zero;

            // Build the frustum planes.
            XMVector[] planes = new XMVector[6];
            planes[0] = new XMVector(0.0f, 0.0f, -1.0f, this.near);
            planes[1] = new XMVector(0.0f, 0.0f, 1.0f, -this.far);
            planes[2] = new XMVector(1.0f, 0.0f, -this.rightSlope, 0.0f);
            planes[3] = new XMVector(-1.0f, 0.0f, this.leftSlope, 0.0f);
            planes[4] = new XMVector(0.0f, 1.0f, -this.topSlope, 0.0f);
            planes[5] = new XMVector(0.0f, -1.0f, this.bottomSlope, 0.0f);

            // Normalize the planes so we can compare to the sphere radius.
            planes[2] = XMVector3.Normalize(planes[2]);
            planes[3] = XMVector3.Normalize(planes[3]);
            planes[4] = XMVector3.Normalize(planes[4]);
            planes[5] = XMVector3.Normalize(planes[5]);

            // Load origin and orientation of the frustum.
            XMVector v_origin = this.origin;
            XMVector v_orientation = this.orientation;

            Debug.Assert(Internal.XMQuaternionIsUnit(v_orientation), "Reviewed");

            // Load the sphere.
            XMVector v_center = sh.Center;
            XMVector v_radius = XMVector.Replicate(sh.Radius);

            // Transform the center of the sphere into the local space of frustum.
            v_center = XMVector3.InverseRotate(v_center - v_origin, v_orientation);

            // Set w of the center to one so we can dot4 with the plane.
            v_center.W = 1.0f;

            // Check against each plane of the frustum.
            XMVector outside = XMVector.FalseInt;
            XMVector insideAll = XMVector.TrueInt;
            XMVector centerInsideAll = XMVector.TrueInt;

            XMVector[] dist = new XMVector[6];

            for (int i = 0; i < 6; i++)
            {
                dist[i] = XMVector4.Dot(v_center, planes[i]);

                // Outside the plane?
                outside = XMVector.OrInt(outside, XMVector.Greater(dist[i], v_radius));

                // Fully inside the plane?
                insideAll = XMVector.AndInt(insideAll, XMVector.LessOrEqual(dist[i], -v_radius));

                // Check if the center is inside the plane.
                centerInsideAll = XMVector.AndInt(centerInsideAll, XMVector.LessOrEqual(dist[i], zero));
            }

            // If the sphere is outside any of the planes it is outside. 
            if (XMVector4.EqualInt(outside, XMVector.TrueInt))
            {
                return false;
            }

            // If the sphere is inside all planes it is fully inside.
            if (XMVector4.EqualInt(insideAll, XMVector.TrueInt))
            {
                return true;
            }

            // If the center of the sphere is inside all planes and the sphere intersects 
            // one or more planes then it must intersect.
            if (XMVector4.EqualInt(centerInsideAll, XMVector.TrueInt))
            {
                return true;
            }

            // The sphere may be outside the frustum or intersecting the frustum.
            // Find the nearest feature (face, edge, or corner) on the frustum 
            // to the sphere.

            // The faces adjacent to each face are:
            int[,] adjacent_faces = new int[6, 4]
            {
                { 2, 3, 4, 5 },    // 0
                { 2, 3, 4, 5 },    // 1
                { 0, 1, 4, 5 },    // 2
                { 0, 1, 4, 5 },    // 3
                { 0, 1, 2, 3 },    // 4
                { 0, 1, 2, 3 }
            };  // 5

            XMVector intersects = XMVector.FalseInt;

            // Check to see if the nearest feature is one of the planes.
            for (int i = 0; i < 6; i++)
            {
                // Find the nearest point on the plane to the center of the sphere.
                XMVector point = v_center - (planes[i] * dist[i]);

                // Set w of the point to one.
                point.W = 1.0f;

                // If the point is inside the face (inside the adjacent planes) then
                // this plane is the nearest feature.
                XMVector insideFace = XMVector.TrueInt;

                for (int j = 0; j < 4; j++)
                {
                    int plane_index = adjacent_faces[i, j];

                    insideFace = XMVector.AndInt(insideFace, XMVector.LessOrEqual(XMVector4.Dot(point, planes[plane_index]), zero));
                }

                // Since we have already checked distance from the plane we know that the
                // sphere must intersect if this plane is the nearest feature.
                intersects = XMVector.OrInt(intersects, XMVector.AndInt(XMVector.Greater(dist[i], zero), insideFace));
            }

            if (XMVector4.EqualInt(intersects, XMVector.TrueInt))
            {
                return true;
            }

            // Build the corners of the frustum.
            XMVector v_rightTop = new XMVector(this.rightSlope, this.topSlope, 1.0f, 0.0f);
            XMVector v_rightBottom = new XMVector(this.rightSlope, this.bottomSlope, 1.0f, 0.0f);
            XMVector v_lLeftTop = new XMVector(this.leftSlope, this.topSlope, 1.0f, 0.0f);
            XMVector v_leftBottom = new XMVector(this.leftSlope, this.bottomSlope, 1.0f, 0.0f);
            XMVector v_near = XMVector.Replicate(this.near);
            XMVector v_far = XMVector.Replicate(this.far);

            XMVector[] corners = new XMVector[BoundingFrustum.CornerCount];
            corners[0] = v_rightTop * v_near;
            corners[1] = v_rightBottom * v_near;
            corners[2] = v_lLeftTop * v_near;
            corners[3] = v_leftBottom * v_near;
            corners[4] = v_rightTop * v_far;
            corners[5] = v_rightBottom * v_far;
            corners[6] = v_lLeftTop * v_far;
            corners[7] = v_leftBottom * v_far;

            // The Edges are:
            int[,] edges = new int[12, 2]
            {
                { 0, 1 }, { 2, 3 }, { 0, 2 }, { 1, 3 },    // Near plane
                { 4, 5 }, { 6, 7 }, { 4, 6 }, { 5, 7 },    // Far plane
                { 0, 4 }, { 1, 5 }, { 2, 6 }, { 3, 7 },
            }; // Near to far

            XMVector radiusSq = v_radius * v_radius;

            // Check to see if the nearest feature is one of the edges (or corners).
            for (int i = 0; i < 12; i++)
            {
                int ei0 = edges[i, 0];
                int ei1 = edges[i, 1];

                // Find the nearest point on the edge to the center of the sphere.
                // The corners of the frustum are included as the endpoints of the edges.
                XMVector point = Internal.PointOnLineSegmentNearestPoint(corners[ei0], corners[ei1], v_center);

                XMVector delta = v_center - point;

                XMVector distSq = XMVector3.Dot(delta, delta);

                // If the distance to the center of the sphere to the point is less than 
                // the radius of the sphere then it must intersect.
                intersects = XMVector.OrInt(intersects, XMVector.LessOrEqual(distSq, radiusSq));
            }

            if (XMVector4.EqualInt(intersects, XMVector.TrueInt))
            {
                return true;
            }

            // The sphere must be outside the frustum.
            return false;
        }

        /// <summary>
        /// Test the <see cref="BoundingFrustum"/> for intersection with a <see cref="BoundingBox"/>.
        /// </summary>
        /// <param name="box">The <see cref="BoundingBox"/> to test for intersection.</param>
        /// <returns>A boolean value indicating whether the <see cref="BoundingFrustum"/> intersects the specified <see cref="BoundingBox"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Intersects(BoundingBox box)
        {
            // Make the axis aligned box oriented and do an OBB vs frustum test.
            BoundingOrientedBox obox = new BoundingOrientedBox(box.Center, box.Extents, new XMFloat4(0.0f, 0.0f, 0.0f, 1.0f));
            return this.Intersects(obox);
        }

        /// <summary>
        /// Test the <see cref="BoundingFrustum"/> for intersection with a <see cref="BoundingOrientedBox"/>.
        /// </summary>
        /// <param name="box">The <see cref="BoundingOrientedBox"/> to test for intersection.</param>
        /// <returns>A boolean value indicating whether the <see cref="BoundingFrustum"/> intersects the specified <see cref="BoundingOrientedBox"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Intersects(BoundingOrientedBox box)
        {
            XMVector selectY = XMVector.FromInt((uint)XMSelection.Select0, (uint)XMSelection.Select1, (uint)XMSelection.Select0, (uint)XMSelection.Select0);
            XMVector selectZ = XMVector.FromInt((uint)XMSelection.Select0, (uint)XMSelection.Select0, (uint)XMSelection.Select1, (uint)XMSelection.Select0);

            XMVector zero = XMGlobalConstants.Zero;

            // Build the frustum planes.
            XMVector[] planes = new XMVector[6];
            planes[0] = new XMVector(0.0f, 0.0f, -1.0f, this.near);
            planes[1] = new XMVector(0.0f, 0.0f, 1.0f, -this.far);
            planes[2] = new XMVector(1.0f, 0.0f, -this.rightSlope, 0.0f);
            planes[3] = new XMVector(-1.0f, 0.0f, this.leftSlope, 0.0f);
            planes[4] = new XMVector(0.0f, 1.0f, -this.topSlope, 0.0f);
            planes[5] = new XMVector(0.0f, -1.0f, this.bottomSlope, 0.0f);

            // Load origin and orientation of the frustum.
            XMVector v_origin = this.origin;
            XMVector frustumOrientation = this.orientation;

            Debug.Assert(Internal.XMQuaternionIsUnit(frustumOrientation), "Reviewed");

            // Load the box.
            XMVector center = box.Center;
            XMVector extents = box.Extents;
            XMVector boxOrientation = box.Orientation;

            Debug.Assert(Internal.XMQuaternionIsUnit(boxOrientation), "Reviewed");

            // Transform the oriented box into the space of the frustum in order to 
            // minimize the number of transforms we have to do.
            center = XMVector3.InverseRotate(center - v_origin, frustumOrientation);
            boxOrientation = XMQuaternion.Multiply(boxOrientation, XMQuaternion.Conjugate(frustumOrientation));

            // Set w of the center to one so we can dot4 with the plane.
            center.W = 1.0f;

            // Build the 3x3 rotation matrix that defines the box axes.
            XMMatrix r = XMMatrix.RotationQuaternion(boxOrientation);

            // Check against each plane of the frustum.
            XMVector outside = XMVector.FalseInt;
            XMVector insideAll = XMVector.TrueInt;
            XMVector centerInsideAll = XMVector.TrueInt;

            for (int i = 0; i < 6; i++)
            {
                // Compute the distance to the center of the box.
                XMVector dist = XMVector4.Dot(center, planes[i]);

                // Project the axes of the box onto the normal of the plane.  Half the
                // length of the projection (sometime called the "radius") is equal to
                // h(u) * abs(n dot b(u))) + h(v) * abs(n dot b(v)) + h(w) * abs(n dot b(w))
                // where h(i) are extents of the box, n is the plane normal, and b(i) are the 
                // axes of the box.
                XMVector radius = XMVector3.Dot(planes[i], ((XMVector*)&r)[0]);
                radius = XMVector.Select(radius, XMVector3.Dot(planes[i], ((XMVector*)&r)[1]), selectY);
                radius = XMVector.Select(radius, XMVector3.Dot(planes[i], ((XMVector*)&r)[2]), selectZ);
                radius = XMVector3.Dot(extents, radius.Abs());

                // Outside the plane?
                outside = XMVector.OrInt(outside, XMVector.Greater(dist, radius));

                // Fully inside the plane?
                insideAll = XMVector.AndInt(insideAll, XMVector.LessOrEqual(dist, -radius));

                // Check if the center is inside the plane.
                centerInsideAll = XMVector.AndInt(centerInsideAll, XMVector.LessOrEqual(dist, zero));
            }

            // If the box is outside any of the planes it is outside. 
            if (XMVector4.EqualInt(outside, XMVector.TrueInt))
            {
                return false;
            }

            // If the box is inside all planes it is fully inside.
            if (XMVector4.EqualInt(insideAll, XMVector.TrueInt))
            {
                return true;
            }

            // If the center of the box is inside all planes and the box intersects 
            // one or more planes then it must intersect.
            if (XMVector4.EqualInt(centerInsideAll, XMVector.TrueInt))
            {
                return true;
            }

            // Build the corners of the frustum.
            XMVector v_rightTop = new XMVector(this.rightSlope, this.topSlope, 1.0f, 0.0f);
            XMVector v_rightBottom = new XMVector(this.rightSlope, this.bottomSlope, 1.0f, 0.0f);
            XMVector v_leftTop = new XMVector(this.leftSlope, this.topSlope, 1.0f, 0.0f);
            XMVector v_leftBottom = new XMVector(this.leftSlope, this.bottomSlope, 1.0f, 0.0f);
            XMVector v_near = XMVector.Replicate(this.near);
            XMVector v_far = XMVector.Replicate(this.far);

            XMVector[] corners = new XMVector[BoundingOrientedBox.CornerCount];
            corners[0] = v_rightTop * v_near;
            corners[1] = v_rightBottom * v_near;
            corners[2] = v_leftTop * v_near;
            corners[3] = v_leftBottom * v_near;
            corners[4] = v_rightTop * v_far;
            corners[5] = v_rightBottom * v_far;
            corners[6] = v_leftTop * v_far;
            corners[7] = v_leftBottom * v_far;

            // Test against box axes (3)
            {
                // Find the min/max values of the projection of the frustum onto each axis.
                XMVector frustumMin, frustumMax;

                frustumMin = XMVector3.Dot(corners[0], ((XMVector*)&r)[0]);
                frustumMin = XMVector.Select(frustumMin, XMVector3.Dot(corners[0], ((XMVector*)&r)[1]), selectY);
                frustumMin = XMVector.Select(frustumMin, XMVector3.Dot(corners[0], ((XMVector*)&r)[2]), selectZ);
                frustumMax = frustumMin;

                for (int i = 1; i < BoundingOrientedBox.CornerCount; i++)
                {
                    XMVector temp = XMVector3.Dot(corners[i], ((XMVector*)&r)[0]);
                    temp = XMVector.Select(temp, XMVector3.Dot(corners[i], ((XMVector*)&r)[1]), selectY);
                    temp = XMVector.Select(temp, XMVector3.Dot(corners[i], ((XMVector*)&r)[2]), selectZ);

                    frustumMin = XMVector.Min(frustumMin, temp);
                    frustumMax = XMVector.Max(frustumMax, temp);
                }

                // Project the center of the box onto the axes.
                XMVector boxDist = XMVector3.Dot(center, ((XMVector*)&r)[0]);
                boxDist = XMVector.Select(boxDist, XMVector3.Dot(center, ((XMVector*)&r)[1]), selectY);
                boxDist = XMVector.Select(boxDist, XMVector3.Dot(center, ((XMVector*)&r)[2]), selectZ);

                // The projection of the box onto the axis is just its Center and Extents.
                // if (min > box_max || max < box_min) reject;
                XMVector result = XMVector.OrInt(
                    XMVector.Greater(frustumMin, boxDist + extents),
                    XMVector.Less(frustumMax, boxDist - extents));

                if (Internal.XMVector3AnyTrue(result))
                {
                    return false;
                }
            }

            // Test against edge/edge axes (3*6).
            XMVector[] frustumEdgeAxis = new XMVector[6];

            frustumEdgeAxis[0] = v_rightTop;
            frustumEdgeAxis[1] = v_rightBottom;
            frustumEdgeAxis[2] = v_leftTop;
            frustumEdgeAxis[3] = v_leftBottom;
            frustumEdgeAxis[4] = v_rightTop - v_leftTop;
            frustumEdgeAxis[5] = v_leftBottom - v_leftTop;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    // Compute the axis we are going to test.
                    XMVector axis = XMVector3.Cross(((XMVector*)&r)[i], frustumEdgeAxis[j]);

                    // Find the min/max values of the projection of the frustum onto the axis.
                    XMVector frustumMin, frustumMax;

                    frustumMin = frustumMax = XMVector3.Dot(axis, corners[0]);

                    for (int k = 1; k < BoundingBox.CornerCount; k++)
                    {
                        XMVector temp = XMVector3.Dot(axis, corners[k]);
                        frustumMin = XMVector.Min(frustumMin, temp);
                        frustumMax = XMVector.Max(frustumMax, temp);
                    }

                    // Project the center of the box onto the axis.
                    XMVector dist = XMVector3.Dot(center, axis);

                    // Project the axes of the box onto the axis to find the "radius" of the box.
                    XMVector radius = XMVector3.Dot(axis, ((XMVector*)&r)[0]);
                    radius = XMVector.Select(radius, XMVector3.Dot(axis, ((XMVector*)&r)[1]), selectY);
                    radius = XMVector.Select(radius, XMVector3.Dot(axis, ((XMVector*)&r)[2]), selectZ);
                    radius = XMVector3.Dot(extents, radius.Abs());

                    // if (center > max + radius || center < min - radius) reject;
                    outside = XMVector.OrInt(outside, XMVector.Greater(dist, frustumMax + radius));
                    outside = XMVector.OrInt(outside, XMVector.Less(dist, frustumMin - radius));
                }
            }

            if (XMVector4.EqualInt(outside, XMVector.TrueInt))
            {
                return false;
            }

            // If we did not find a separating plane then the box must intersect the frustum.
            return true;
        }

        /// <summary>
        /// Test the <see cref="BoundingFrustum"/> for intersection with another <see cref="BoundingFrustum"/>.
        /// </summary>
        /// <param name="fr">The <see cref="BoundingFrustum"/> to test for intersection.</param>
        /// <returns>A boolean value indicating whether the <see cref="BoundingFrustum"/> intersects the specified <see cref="BoundingFrustum"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Intersects(BoundingFrustum fr)
        {
            // Load origin and orientation of frustum B.
            XMVector originB = this.origin;
            XMVector orientationB = this.orientation;

            Debug.Assert(Internal.XMQuaternionIsUnit(orientationB), "Reviewed");

            // Build the planes of frustum B.
            XMVector[] axisB = new XMVector[6];
            axisB[0] = new XMVector(0.0f, 0.0f, -1.0f, 0.0f);
            axisB[1] = new XMVector(0.0f, 0.0f, 1.0f, 0.0f);
            axisB[2] = new XMVector(1.0f, 0.0f, -this.rightSlope, 0.0f);
            axisB[3] = new XMVector(-1.0f, 0.0f, this.leftSlope, 0.0f);
            axisB[4] = new XMVector(0.0f, 1.0f, -this.topSlope, 0.0f);
            axisB[5] = new XMVector(0.0f, -1.0f, this.bottomSlope, 0.0f);

            XMVector[] planeDistB = new XMVector[6];
            planeDistB[0] = -XMVector.Replicate(this.near);
            planeDistB[1] = XMVector.Replicate(this.far);
            planeDistB[2] = XMGlobalConstants.Zero;
            planeDistB[3] = XMGlobalConstants.Zero;
            planeDistB[4] = XMGlobalConstants.Zero;
            planeDistB[5] = XMGlobalConstants.Zero;

            // Load origin and orientation of frustum A.
            XMVector originA = fr.origin;
            XMVector orientationA = fr.orientation;

            Debug.Assert(Internal.XMQuaternionIsUnit(orientationA), "Reviewed");

            // Transform frustum A into the space of the frustum B in order to 
            // minimize the number of transforms we have to do.
            originA = XMVector3.InverseRotate(originA - originB, orientationB);
            orientationA = XMQuaternion.Multiply(orientationA, XMQuaternion.Conjugate(orientationB));

            // Build the corners of frustum A (in the local space of B).
            XMVector rightTopA = new XMVector(fr.rightSlope, fr.topSlope, 1.0f, 0.0f);
            XMVector rightBottomA = new XMVector(fr.rightSlope, fr.bottomSlope, 1.0f, 0.0f);
            XMVector leftTopA = new XMVector(fr.leftSlope, fr.topSlope, 1.0f, 0.0f);
            XMVector leftBottomA = new XMVector(fr.leftSlope, fr.bottomSlope, 1.0f, 0.0f);
            XMVector nearA = XMVector.Replicate(fr.near);
            XMVector farA = XMVector.Replicate(fr.far);

            rightTopA = XMVector3.Rotate(rightTopA, orientationA);
            rightBottomA = XMVector3.Rotate(rightBottomA, orientationA);
            leftTopA = XMVector3.Rotate(leftTopA, orientationA);
            leftBottomA = XMVector3.Rotate(leftBottomA, orientationA);

            XMVector[] cornersA = new XMVector[BoundingFrustum.CornerCount];
            cornersA[0] = originA + (rightTopA * nearA);
            cornersA[1] = originA + (rightBottomA * nearA);
            cornersA[2] = originA + (leftTopA * nearA);
            cornersA[3] = originA + (leftBottomA * nearA);
            cornersA[4] = originA + (rightTopA * farA);
            cornersA[5] = originA + (rightBottomA * farA);
            cornersA[6] = originA + (leftTopA * farA);
            cornersA[7] = originA + (leftBottomA * farA);

            // Check frustum A against each plane of frustum B.
            XMVector outside = XMVector.FalseInt;
            XMVector insideAll = XMVector.TrueInt;

            for (int i = 0; i < 6; i++)
            {
                // Find the min/max projection of the frustum onto the plane normal.
                XMVector min, max;

                min = max = XMVector3.Dot(axisB[i], cornersA[0]);

                for (int j = 1; j < BoundingFrustum.CornerCount; j++)
                {
                    XMVector temp = XMVector3.Dot(axisB[i], cornersA[j]);
                    min = XMVector.Min(min, temp);
                    max = XMVector.Max(max, temp);
                }

                // Outside the plane?
                outside = XMVector.OrInt(outside, XMVector.Greater(min, planeDistB[i]));

                // Fully inside the plane?
                insideAll = XMVector.AndInt(insideAll, XMVector.LessOrEqual(max, planeDistB[i]));
            }

            // If the frustum A is outside any of the planes of frustum B it is outside. 
            if (XMVector4.EqualInt(outside, XMVector.TrueInt))
            {
                return false;
            }

            // If frustum A is inside all planes of frustum B it is fully inside.
            if (XMVector4.EqualInt(insideAll, XMVector.TrueInt))
            {
                return true;
            }

            // Build the corners of frustum B.
            XMVector rightTopB = new XMVector(this.rightSlope, this.topSlope, 1.0f, 0.0f);
            XMVector rightBottomB = new XMVector(this.rightSlope, this.bottomSlope, 1.0f, 0.0f);
            XMVector leftTopB = new XMVector(this.leftSlope, this.topSlope, 1.0f, 0.0f);
            XMVector leftBottomB = new XMVector(this.leftSlope, this.bottomSlope, 1.0f, 0.0f);
            XMVector nearB = XMVector.Replicate(this.near);
            XMVector farB = XMVector.Replicate(this.far);

            XMVector[] cornersB = new XMVector[BoundingFrustum.CornerCount];
            cornersB[0] = rightTopB * nearB;
            cornersB[1] = rightBottomB * nearB;
            cornersB[2] = leftTopB * nearB;
            cornersB[3] = leftBottomB * nearB;
            cornersB[4] = rightTopB * farB;
            cornersB[5] = rightBottomB * farB;
            cornersB[6] = leftTopB * farB;
            cornersB[7] = leftBottomB * farB;

            // Build the planes of frustum A (in the local space of B).
            XMVector[] axisA = new XMVector[6];
            XMVector[] planeDistA = new XMVector[6];

            axisA[0] = new XMVector(0.0f, 0.0f, -1.0f, 0.0f);
            axisA[1] = new XMVector(0.0f, 0.0f, 1.0f, 0.0f);
            axisA[2] = new XMVector(1.0f, 0.0f, -fr.rightSlope, 0.0f);
            axisA[3] = new XMVector(-1.0f, 0.0f, fr.leftSlope, 0.0f);
            axisA[4] = new XMVector(0.0f, 1.0f, -fr.topSlope, 0.0f);
            axisA[5] = new XMVector(0.0f, -1.0f, fr.bottomSlope, 0.0f);

            axisA[0] = XMVector3.Rotate(axisA[0], orientationA);
            axisA[1] = -axisA[0];
            axisA[2] = XMVector3.Rotate(axisA[2], orientationA);
            axisA[3] = XMVector3.Rotate(axisA[3], orientationA);
            axisA[4] = XMVector3.Rotate(axisA[4], orientationA);
            axisA[5] = XMVector3.Rotate(axisA[5], orientationA);

            planeDistA[0] = XMVector3.Dot(axisA[0], cornersA[0]);  // Re-use corner on near plane.
            planeDistA[1] = XMVector3.Dot(axisA[1], cornersA[4]);  // Re-use corner on far plane.
            planeDistA[2] = XMVector3.Dot(axisA[2], originA);
            planeDistA[3] = XMVector3.Dot(axisA[3], originA);
            planeDistA[4] = XMVector3.Dot(axisA[4], originA);
            planeDistA[5] = XMVector3.Dot(axisA[5], originA);

            // Check each axis of frustum A for a seperating plane (5).
            for (int i = 0; i < 6; i++)
            {
                // Find the minimum projection of the frustum onto the plane normal.
                XMVector min;

                min = XMVector3.Dot(axisA[i], cornersB[0]);

                for (int j = 1; j < BoundingFrustum.CornerCount; j++)
                {
                    XMVector temp = XMVector3.Dot(axisA[i], cornersB[j]);
                    min = XMVector.Min(min, temp);
                }

                // Outside the plane?
                outside = XMVector.OrInt(outside, XMVector.Greater(min, planeDistA[i]));
            }

            // If the frustum B is outside any of the planes of frustum A it is outside. 
            if (XMVector4.EqualInt(outside, XMVector.TrueInt))
            {
                return false;
            }

            // Check edge/edge axes (6 * 6).
            XMVector[] frustumEdgeAxisA = new XMVector[6];
            frustumEdgeAxisA[0] = rightTopA;
            frustumEdgeAxisA[1] = rightBottomA;
            frustumEdgeAxisA[2] = leftTopA;
            frustumEdgeAxisA[3] = leftBottomA;
            frustumEdgeAxisA[4] = rightTopA - leftTopA;
            frustumEdgeAxisA[5] = leftBottomA - leftTopA;

            XMVector[] frustumEdgeAxisB = new XMVector[6];
            frustumEdgeAxisB[0] = rightTopB;
            frustumEdgeAxisB[1] = rightBottomB;
            frustumEdgeAxisB[2] = leftTopB;
            frustumEdgeAxisB[3] = leftBottomB;
            frustumEdgeAxisB[4] = rightTopB - leftTopB;
            frustumEdgeAxisB[5] = leftBottomB - leftTopB;

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    // Compute the axis we are going to test.
                    XMVector axis = XMVector3.Cross(frustumEdgeAxisA[i], frustumEdgeAxisB[j]);

                    // Find the min/max values of the projection of both frustums onto the axis.
                    XMVector minA, maxA;
                    XMVector minB, maxB;

                    minA = maxA = XMVector3.Dot(axis, cornersA[0]);
                    minB = maxB = XMVector3.Dot(axis, cornersB[0]);

                    for (int k = 1; k < BoundingFrustum.CornerCount; k++)
                    {
                        XMVector tempA = XMVector3.Dot(axis, cornersA[k]);
                        minA = XMVector.Min(minA, tempA);
                        maxA = XMVector.Max(maxA, tempA);

                        XMVector tempB = XMVector3.Dot(axis, cornersB[k]);
                        minB = XMVector.Min(minB, tempB);
                        maxB = XMVector.Max(maxB, tempB);
                    }

                    // if (MinA > MaxB || MinB > MaxA) reject
                    outside = XMVector.OrInt(outside, XMVector.Greater(minA, maxB));
                    outside = XMVector.OrInt(outside, XMVector.Greater(minB, maxA));
                }
            }

            // If there is a seperating plane, then the frustums do not intersect.
            if (XMVector4.EqualInt(outside, XMVector.TrueInt))
            {
                return false;
            }

            // If we did not find a separating plane then the frustums intersect.
            return true;
        }

        /// <summary>
        /// Test the <see cref="BoundingFrustum"/> for intersection with a triangle.
        /// </summary>
        /// <param name="v0">The first vector describing the triangle.</param>
        /// <param name="v1">The second vector describing the triangle.</param>
        /// <param name="v2">The third vector describing the triangle.</param>
        /// <returns>A boolean value indicating whether the <see cref="BoundingFrustum"/> intersects the triangle.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Intersects(XMVector v0, XMVector v1, XMVector v2)
        {
            // Build the frustum planes (NOTE: D is negated from the usual).
            XMVector[] planes = new XMVector[6];
            planes[0] = new XMVector(0.0f, 0.0f, -1.0f, -this.near);
            planes[1] = new XMVector(0.0f, 0.0f, 1.0f, this.far);
            planes[2] = new XMVector(1.0f, 0.0f, -this.rightSlope, 0.0f);
            planes[3] = new XMVector(-1.0f, 0.0f, this.leftSlope, 0.0f);
            planes[4] = new XMVector(0.0f, 1.0f, -this.topSlope, 0.0f);
            planes[5] = new XMVector(0.0f, -1.0f, this.bottomSlope, 0.0f);

            // Load origin and orientation of the frustum.
            XMVector v_origin = this.origin;
            XMVector v_orientation = this.orientation;

            Debug.Assert(Internal.XMQuaternionIsUnit(v_orientation), "Reviewed");

            // Transform triangle into the local space of frustum.
            XMVector tV0 = XMVector3.InverseRotate(v0 - v_origin, v_orientation);
            XMVector tV1 = XMVector3.InverseRotate(v1 - v_origin, v_orientation);
            XMVector tV2 = XMVector3.InverseRotate(v2 - v_origin, v_orientation);

            // Test each vertex of the triangle against the frustum planes.
            XMVector outside = XMVector.FalseInt;
            XMVector insideAll = XMVector.TrueInt;

            for (int i = 0; i < 6; i++)
            {
                XMVector dist0 = XMVector3.Dot(tV0, planes[i]);
                XMVector dist1 = XMVector3.Dot(tV1, planes[i]);
                XMVector dist2 = XMVector3.Dot(tV2, planes[i]);

                XMVector minDist = XMVector.Min(dist0, dist1);
                minDist = XMVector.Min(minDist, dist2);
                XMVector maxDist = XMVector.Max(dist0, dist1);
                maxDist = XMVector.Max(maxDist, dist2);

                XMVector planeDist = XMVector.SplatW(planes[i]);

                // Outside the plane?
                outside = XMVector.OrInt(outside, XMVector.Greater(minDist, planeDist));

                // Fully inside the plane?
                insideAll = XMVector.AndInt(insideAll, XMVector.LessOrEqual(maxDist, planeDist));
            }

            // If the triangle is outside any of the planes it is outside. 
            if (XMVector4.EqualInt(outside, XMVector.TrueInt))
            {
                return false;
            }

            // If the triangle is inside all planes it is fully inside.
            if (XMVector4.EqualInt(insideAll, XMVector.TrueInt))
            {
                return true;
            }

            // Build the corners of the frustum.
            XMVector v_rightTop = new XMVector(this.rightSlope, this.topSlope, 1.0f, 0.0f);
            XMVector v_rightBottom = new XMVector(this.rightSlope, this.bottomSlope, 1.0f, 0.0f);
            XMVector v_leftTop = new XMVector(this.leftSlope, this.topSlope, 1.0f, 0.0f);
            XMVector v_leftBottom = new XMVector(this.leftSlope, this.bottomSlope, 1.0f, 0.0f);
            XMVector v_near = XMVector.Replicate(this.near);
            XMVector v_far = XMVector.Replicate(this.far);

            XMVector[] corners = new XMVector[BoundingFrustum.CornerCount];
            corners[0] = v_rightTop * v_near;
            corners[1] = v_rightBottom * v_near;
            corners[2] = v_leftTop * v_near;
            corners[3] = v_leftBottom * v_near;
            corners[4] = v_rightTop * v_far;
            corners[5] = v_rightBottom * v_far;
            corners[6] = v_leftTop * v_far;
            corners[7] = v_leftBottom * v_far;

            // Test the plane of the triangle.
            XMVector normal = XMVector3.Cross(v1 - v0, v2 - v0);
            XMVector dist = XMVector3.Dot(normal, v0);

            {
                XMVector minDist, maxDist;
                minDist = maxDist = XMVector3.Dot(corners[0], normal);

                for (int i = 1; i < BoundingFrustum.CornerCount; i++)
                {
                    XMVector temp = XMVector3.Dot(corners[i], normal);
                    minDist = XMVector.Min(minDist, temp);
                    maxDist = XMVector.Max(maxDist, temp);
                }

                outside = XMVector.OrInt(XMVector.Greater(minDist, dist), XMVector.Less(maxDist, dist));

                if (XMVector4.EqualInt(outside, XMVector.TrueInt))
                {
                    return false;
                }
            }

            // Check the edge/edge axes (3*6).
            XMVector[] triangleEdgeAxis = new XMVector[3];
            triangleEdgeAxis[0] = v1 - v0;
            triangleEdgeAxis[1] = v2 - v1;
            triangleEdgeAxis[2] = v0 - v2;

            XMVector[] frustumEdgeAxis = new XMVector[6];
            frustumEdgeAxis[0] = v_rightTop;
            frustumEdgeAxis[1] = v_rightBottom;
            frustumEdgeAxis[2] = v_leftTop;
            frustumEdgeAxis[3] = v_leftBottom;
            frustumEdgeAxis[4] = v_rightTop - v_leftTop;
            frustumEdgeAxis[5] = v_leftBottom - v_leftTop;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    // Compute the axis we are going to test.
                    XMVector axis = XMVector3.Cross(triangleEdgeAxis[i], frustumEdgeAxis[j]);

                    // Find the min/max of the projection of the triangle onto the axis.
                    XMVector minA, maxA;

                    XMVector dist0 = XMVector3.Dot(v0, axis);
                    XMVector dist1 = XMVector3.Dot(v1, axis);
                    XMVector dist2 = XMVector3.Dot(v2, axis);

                    minA = XMVector.Min(dist0, dist1);
                    minA = XMVector.Min(minA, dist2);
                    maxA = XMVector.Max(dist0, dist1);
                    maxA = XMVector.Max(maxA, dist2);

                    // Find the min/max of the projection of the frustum onto the axis.
                    XMVector minB, maxB;

                    minB = maxB = XMVector3.Dot(axis, corners[0]);

                    for (int k = 1; k < BoundingFrustum.CornerCount; k++)
                    {
                        XMVector temp = XMVector3.Dot(axis, corners[k]);
                        minB = XMVector.Min(minB, temp);
                        maxB = XMVector.Max(maxB, temp);
                    }

                    // if (MinA > MaxB || MinB > MaxA) reject;
                    outside = XMVector.OrInt(outside, XMVector.Greater(minA, maxB));
                    outside = XMVector.OrInt(outside, XMVector.Greater(minB, maxA));
                }
            }

            if (XMVector4.EqualInt(outside, XMVector.TrueInt))
            {
                return false;
            }

            // If we did not find a separating plane then the triangle must intersect the frustum.
            return true;
        }

        /// <summary>
        /// Test the <see cref="BoundingFrustum"/> for intersection with a plane.
        /// </summary>
        /// <param name="plane">A vector describing the plane.</param>
        /// <returns>A <see cref="PlaneIntersectionType"/> value indicating the intersection status.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public PlaneIntersectionType Intersects(XMVector plane)
        {
            Debug.Assert(Internal.XMPlaneIsUnit(plane), "Reviewed");

            // Load origin and orientation of the frustum.
            XMVector v_origin = this.origin;
            XMVector v_orientation = this.orientation;

            Debug.Assert(Internal.XMQuaternionIsUnit(v_orientation), "Reviewed");

            // Set w of the origin to one so we can dot4 with a plane.
            v_origin.W = 1.0f;

            // Build the corners of the frustum (in world space).
            XMVector rightTop = new XMVector(this.rightSlope, this.topSlope, 1.0f, 0.0f);
            XMVector rightBottom = new XMVector(this.rightSlope, this.bottomSlope, 1.0f, 0.0f);
            XMVector leftTop = new XMVector(this.leftSlope, this.topSlope, 1.0f, 0.0f);
            XMVector leftBottom = new XMVector(this.leftSlope, this.bottomSlope, 1.0f, 0.0f);
            XMVector v_near = XMVector.Replicate(this.near);
            XMVector v_far = XMVector.Replicate(this.far);

            rightTop = XMVector3.Rotate(rightTop, v_orientation);
            rightBottom = XMVector3.Rotate(rightBottom, v_orientation);
            leftTop = XMVector3.Rotate(leftTop, v_orientation);
            leftBottom = XMVector3.Rotate(leftBottom, v_orientation);

            XMVector corners0 = v_origin + (rightTop * v_near);
            XMVector corners1 = v_origin + (rightBottom * v_near);
            XMVector corners2 = v_origin + (leftTop * v_near);
            XMVector corners3 = v_origin + (leftBottom * v_near);
            XMVector corners4 = v_origin + (rightTop * v_far);
            XMVector corners5 = v_origin + (rightBottom * v_far);
            XMVector corners6 = v_origin + (leftTop * v_far);
            XMVector corners7 = v_origin + (leftBottom * v_far);

            XMVector outside, inside;
            Internal.FastIntersectFrustumPlane(
                corners0,
                corners1,
                corners2,
                corners3,
                corners4,
                corners5,
                corners6,
                corners7,
                plane,
                out outside,
                out inside);

            // If the frustum is outside any plane it is outside.
            if (XMVector4.EqualInt(outside, XMVector.TrueInt))
            {
                return PlaneIntersectionType.Front;
            }

            // If the frustum is inside all planes it is inside.
            if (XMVector4.EqualInt(inside, XMVector.TrueInt))
            {
                return PlaneIntersectionType.Back;
            }

            // The frustum is not inside all planes or outside a plane it intersects.
            return PlaneIntersectionType.Intersecting;
        }

        /// <summary>
        /// Test the <see cref="BoundingFrustum"/> for intersection with a ray.
        /// </summary>
        /// <param name="rayOrigin">The origin of the ray.</param>
        /// <param name="direction">The direction of the ray.</param>
        /// <returns>A boolean value indicating whether the <see cref="BoundingFrustum"/> intersects with the ray.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Intersects(XMVector rayOrigin, XMVector direction)
        {
            float distance;
            return this.Intersects(rayOrigin, direction, out distance);
        }

        /// <summary>
        /// Test the <see cref="BoundingFrustum"/> for intersection with a ray.
        /// </summary>
        /// <param name="rayOrigin">The origin of the ray.</param>
        /// <param name="direction">The direction of the ray.</param>
        /// <param name="dist">The length of the ray.</param>
        /// <returns>A boolean value indicating whether the <see cref="BoundingFrustum"/> intersects with the ray.</returns>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "2#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Intersects(XMVector rayOrigin, XMVector direction, out float dist)
        {
            // If ray starts inside the frustum, return a distance of 0 for the hit
            if (this.Contains(rayOrigin) == ContainmentType.Contains)
            {
                dist = 0.0f;
                return true;
            }

            // Build the frustum planes.
            XMVector[] planes = new XMVector[6];
            planes[0] = new XMVector(0.0f, 0.0f, -1.0f, this.near);
            planes[1] = new XMVector(0.0f, 0.0f, 1.0f, -this.far);
            planes[2] = new XMVector(1.0f, 0.0f, -this.rightSlope, 0.0f);
            planes[3] = new XMVector(-1.0f, 0.0f, this.leftSlope, 0.0f);
            planes[4] = new XMVector(0.0f, 1.0f, -this.topSlope, 0.0f);
            planes[5] = new XMVector(0.0f, -1.0f, this.bottomSlope, 0.0f);

            // Load origin and orientation of the frustum.
            XMVector fr_origin = this.origin;
            XMVector fr_orientation = this.orientation;

            // This algorithm based on "Fast Ray-Convex Polyhedron Intersectin," in James Arvo, ed., Graphics Gems II pp. 247-250
            float tnear = float.MinValue;
            float tfar = float.MaxValue;

            for (int i = 0; i < 6; i++)
            {
                XMVector plane = Internal.XMPlaneTransform(planes[i], fr_orientation, fr_origin);
                plane = XMPlane.Normalize(plane);

                XMVector axisDotOrigin = XMPlane.DotCoord(plane, rayOrigin);
                XMVector axisDotDirection = XMVector3.Dot(plane, direction);

                if (XMVector3.LessOrEqual(axisDotDirection.Abs(), CollisionGlobalConstants.RayEpsilon))
                {
                    // Ray is parallel to plane - check if ray origin is inside plane's
                    if (XMVector3.Greater(axisDotOrigin, XMGlobalConstants.Zero))
                    {
                        // Ray origin is outside half-space.
                        dist = 0.0f;
                        return false;
                    }
                }
                else
                {
                    // Ray not parallel - get distance to plane.
                    float vd = axisDotDirection.X;
                    float vn = axisDotOrigin.X;
                    float t = -vn / vd;

                    if (vd < 0.0f)
                    {
                        // Front face - T is a near point.
                        if (t > tfar)
                        {
                            dist = 0.0f;
                            return false;
                        }

                        if (t > tnear)
                        {
                            // Hit near face.
                            tnear = t;
                        }
                    }
                    else
                    {
                        // back face - T is far point.
                        if (t < tnear)
                        {
                            dist = 0.0f;
                            return false;
                        }

                        if (t < tfar)
                        {
                            // Hit far face.
                            tfar = t;
                        }
                    }
                }
            }

            // Survived all tests.
            // Note: if ray originates on polyhedron, may want to change 0.0f to some
            // epsilon to avoid intersecting the originating face.
            float distance = (tnear >= 0.0f) ? tnear : tfar;

            if (distance >= 0.0f)
            {
                dist = distance;
                return true;
            }

            dist = 0.0f;
            return false;
        }

        /// <summary>
        /// Tests whether the <see cref="BoundingFrustum"/> is contained by the specified frustum.
        /// </summary>
        /// <param name="planes">The planes describing the frustum.</param>
        /// <returns>A <see cref="ContainmentType"/> value indicating whether the frustum contains the <see cref="BoundingFrustum"/>.</returns>
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
        /// Tests whether the <see cref="BoundingFrustum"/> is contained by the specified frustum.
        /// </summary>
        /// <param name="plane0">The first plane describing the frustum.</param>
        /// <param name="plane1">The second plane describing the frustum.</param>
        /// <param name="plane2">The third plane describing the frustum.</param>
        /// <param name="plane3">The fourth plane describing the frustum.</param>
        /// <param name="plane4">The fifth plane describing the frustum.</param>
        /// <param name="plane5">The sixth plane describing the frustum.</param>
        /// <returns>A <see cref="ContainmentType"/> value indicating whether the frustum contains the <see cref="BoundingFrustum"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ContainmentType ContainedBy(
            XMVector plane0,
            XMVector plane1,
            XMVector plane2,
            XMVector plane3,
            XMVector plane4,
            XMVector plane5)
        {
            // Load origin and orientation of the frustum.
            XMVector v_origin = this.origin;
            XMVector v_orientation = this.orientation;

            Debug.Assert(Internal.XMQuaternionIsUnit(v_orientation), "Reviewed");

            // Set w of the origin to one so we can dot4 with a plane.
            v_origin.W = 1.0f;

            // Build the corners of the frustum (in world space).
            XMVector rightTop = new XMVector(this.rightSlope, this.topSlope, 1.0f, 0.0f);
            XMVector rightBottom = new XMVector(this.rightSlope, this.bottomSlope, 1.0f, 0.0f);
            XMVector leftTop = new XMVector(this.leftSlope, this.topSlope, 1.0f, 0.0f);
            XMVector leftBottom = new XMVector(this.leftSlope, this.bottomSlope, 1.0f, 0.0f);
            XMVector v_near = XMVector.Replicate(this.near);
            XMVector v_far = XMVector.Replicate(this.far);

            rightTop = XMVector3.Rotate(rightTop, v_orientation);
            rightBottom = XMVector3.Rotate(rightBottom, v_orientation);
            leftTop = XMVector3.Rotate(leftTop, v_orientation);
            leftBottom = XMVector3.Rotate(leftBottom, v_orientation);

            XMVector corners0 = v_origin + (rightTop * v_near);
            XMVector corners1 = v_origin + (rightBottom * v_near);
            XMVector corners2 = v_origin + (leftTop * v_near);
            XMVector corners3 = v_origin + (leftBottom * v_near);
            XMVector corners4 = v_origin + (rightTop * v_far);
            XMVector corners5 = v_origin + (rightBottom * v_far);
            XMVector corners6 = v_origin + (leftTop * v_far);
            XMVector corners7 = v_origin + (leftBottom * v_far);

            XMVector outside, inside;

            // Test against each plane.
            Internal.FastIntersectFrustumPlane(
                corners0,
                corners1,
                corners2,
                corners3,
                corners4,
                corners5,
                corners6,
                corners7,
                plane0,
                out outside,
                out inside);

            XMVector anyOutside = outside;
            XMVector allInside = inside;

            Internal.FastIntersectFrustumPlane(
                corners0,
                corners1,
                corners2,
                corners3,
                corners4,
                corners5,
                corners6,
                corners7,
                plane1,
                out outside,
                out inside);

            anyOutside = XMVector.OrInt(anyOutside, outside);
            allInside = XMVector.AndInt(allInside, inside);

            Internal.FastIntersectFrustumPlane(
                corners0,
                corners1,
                corners2,
                corners3,
                corners4,
                corners5,
                corners6,
                corners7,
                plane2,
                out outside,
                out inside);

            anyOutside = XMVector.OrInt(anyOutside, outside);
            allInside = XMVector.AndInt(allInside, inside);

            Internal.FastIntersectFrustumPlane(
                corners0,
                corners1,
                corners2,
                corners3,
                corners4,
                corners5,
                corners6,
                corners7,
                plane3,
                out outside,
                out inside);

            anyOutside = XMVector.OrInt(anyOutside, outside);
            allInside = XMVector.AndInt(allInside, inside);

            Internal.FastIntersectFrustumPlane(
                corners0,
                corners1,
                corners2,
                corners3,
                corners4,
                corners5,
                corners6,
                corners7,
                plane4,
                out outside,
                out inside);

            anyOutside = XMVector.OrInt(anyOutside, outside);
            allInside = XMVector.AndInt(allInside, inside);

            Internal.FastIntersectFrustumPlane(
                corners0,
                corners1,
                corners2,
                corners3,
                corners4,
                corners5,
                corners6,
                corners7,
                plane5,
                out outside,
                out inside);

            anyOutside = XMVector.OrInt(anyOutside, outside);
            allInside = XMVector.AndInt(allInside, inside);

            // If the frustum is outside any plane it is outside.
            if (XMVector4.EqualInt(anyOutside, XMVector.TrueInt))
            {
                return ContainmentType.Disjoint;
            }

            // If the frustum is inside all planes it is inside.
            if (XMVector4.EqualInt(allInside, XMVector.TrueInt))
            {
                return ContainmentType.Contains;
            }

            // The frustum is not inside all planes or outside a plane, it may intersect.
            return ContainmentType.Intersects;
        }

        /// <summary>
        /// Gets the planes making up the <see cref="BoundingFrustum"/>.
        /// </summary>
        /// <param name="nearPlane">The near plane.</param>
        /// <param name="farPlane">The far plane.</param>
        /// <param name="rightPlane">The right plane.</param>
        /// <param name="leftPlane">The left plane.</param>
        /// <param name="topPlane">The top plane.</param>
        /// <param name="bottomPlane">The bottom plane.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "2#", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "3#", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "4#", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "5#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void GetPlanes(
            out XMVector nearPlane,
            out XMVector farPlane,
            out XMVector rightPlane,
            out XMVector leftPlane,
            out XMVector topPlane,
            out XMVector bottomPlane)
        {
            // Load origin and orientation of the frustum.
            XMVector v_origin = this.origin;
            XMVector v_orientation = this.orientation;

            XMVector v_nearPlane = new XMVector(0.0f, 0.0f, -1.0f, this.near);
            v_nearPlane = Internal.XMPlaneTransform(v_nearPlane, v_orientation, v_origin);
            nearPlane = XMPlane.Normalize(v_nearPlane);

            XMVector v_farPlane = new XMVector(0.0f, 0.0f, 1.0f, -this.far);
            v_farPlane = Internal.XMPlaneTransform(v_farPlane, v_orientation, v_origin);
            farPlane = XMPlane.Normalize(v_farPlane);

            XMVector v_rightPlane = new XMVector(1.0f, 0.0f, -this.rightSlope, 0.0f);
            v_rightPlane = Internal.XMPlaneTransform(v_rightPlane, v_orientation, v_origin);
            rightPlane = XMPlane.Normalize(v_rightPlane);

            XMVector v_leftPlane = new XMVector(-1.0f, 0.0f, this.leftSlope, 0.0f);
            v_leftPlane = Internal.XMPlaneTransform(v_leftPlane, v_orientation, v_origin);
            leftPlane = XMPlane.Normalize(v_leftPlane);

            XMVector v_topPlane = new XMVector(0.0f, 1.0f, -this.topSlope, 0.0f);
            v_topPlane = Internal.XMPlaneTransform(v_topPlane, v_orientation, v_origin);
            topPlane = XMPlane.Normalize(v_topPlane);

            XMVector v_bottomPlane = new XMVector(0.0f, -1.0f, this.bottomSlope, 0.0f);
            v_bottomPlane = Internal.XMPlaneTransform(v_bottomPlane, v_orientation, v_origin);
            bottomPlane = XMPlane.Normalize(v_bottomPlane);
        }
    }
}
