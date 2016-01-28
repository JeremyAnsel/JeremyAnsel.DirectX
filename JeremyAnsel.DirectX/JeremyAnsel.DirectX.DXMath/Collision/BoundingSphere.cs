// <copyright file="BoundingSphere.cs" company="Jérémy Ansel">
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
    /// A bounding sphere object.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BoundingSphere : IEquatable<BoundingSphere>
    {
        /// <summary>
        /// The center of the <see cref="BoundingSphere"/>.
        /// </summary>
        private XMFloat3 center;

        /// <summary>
        /// The radius of the <see cref="BoundingSphere"/>.
        /// </summary>
        private float radius;

        /// <summary>
        /// Initializes a new instance of the <see cref="BoundingSphere"/> struct.
        /// </summary>
        /// <param name="center">The center.</param>
        /// <param name="radius">The radius.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public BoundingSphere(XMFloat3 center, float radius)
        {
            if (radius < 0.0f)
            {
                throw new ArgumentOutOfRangeException("radius");
            }

            this.center = center;
            this.radius = radius;
        }

        /// <summary>
        /// Gets or sets the center of the <see cref="BoundingSphere"/>.
        /// </summary>
        public XMFloat3 Center
        {
            get { return this.center; }
            set { this.center = value; }
        }

        /// <summary>
        /// Gets or sets the radius of the <see cref="BoundingSphere"/>.
        /// </summary>
        public float Radius
        {
            get
            {
                return this.radius;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (value < 0.0f)
                {
                    throw new ArgumentOutOfRangeException("value");
                }

                this.radius = value;
            }
        }

        /// <summary>
        /// Compares two <see cref="BoundingSphere"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="BoundingSphere"/> to compare.</param>
        /// <param name="right">The right <see cref="BoundingSphere"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(BoundingSphere left, BoundingSphere right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="BoundingSphere"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="BoundingSphere"/> to compare.</param>
        /// <param name="right">The right <see cref="BoundingSphere"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(BoundingSphere left, BoundingSphere right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Creates a <see cref="BoundingSphere"/> that contains the two specified <see cref="BoundingSphere"/> objects.
        /// </summary>
        /// <param name="s1">The first <see cref="BoundingSphere"/> that the new <see cref="BoundingSphere"/> should contain.</param>
        /// <param name="s2">The second <see cref="BoundingSphere"/> that the new <see cref="BoundingSphere"/> should contain.</param>
        /// <returns>A new <see cref="BoundingSphere"/> containing the two specified <see cref="BoundingSphere"/> objects.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BoundingSphere CreateMerged(BoundingSphere s1, BoundingSphere s2)
        {
            XMVector center1 = s1.center;
            float r1 = s1.radius;

            XMVector center2 = s2.center;
            float r2 = s2.radius;

            XMVector v = XMVector.Subtract(center2, center1);

            XMVector dist = XMVector3.Length(v);

            float d = dist.X;

            if (r1 + r2 >= d)
            {
                if (r1 - r2 >= d)
                {
                    return s1;
                }
                else if (r2 - r1 >= d)
                {
                    return s2;
                }
            }

            XMVector n = XMVector.Divide(v, dist);

            float t1 = Math.Min(-r1, d - r2);
            float t2 = Math.Max(r1, d + r2);
            float t_5 = (t2 - t1) * 0.5f;

            XMVector n_center = XMVector.Add(center1, XMVector.Multiply(n, XMVector.Replicate(t_5 + t1)));

            return new BoundingSphere(n_center, t_5);
        }

        /// <summary>
        /// Creates a <see cref="BoundingSphere"/> containing the specified <see cref="BoundingBox"/>.
        /// </summary>
        /// <param name="box">The <see cref="BoundingBox"/> the new <see cref="BoundingSphere"/> should contain.</param>
        /// <returns>The new <see cref="BoundingSphere"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BoundingSphere CreateFromBox(BoundingBox box)
        {
            return new BoundingSphere(box.Center, XMVector3.Length(box.Extents).X);
        }

        /// <summary>
        /// Creates a <see cref="BoundingSphere"/> containing the specified <see cref="BoundingOrientedBox"/>.
        /// </summary>
        /// <param name="box">The <see cref="BoundingOrientedBox"/> the new <see cref="BoundingSphere"/> should contain.</param>
        /// <returns>The new <see cref="BoundingSphere"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BoundingSphere CreateFromOrientedBox(BoundingOrientedBox box)
        {
            // Bounding box orientation is irrelevant because a sphere is rotationally invariant
            return new BoundingSphere(box.Center, XMVector3.Length(box.Extents).X);
        }

        /// <summary>
        /// Creates a new <see cref="BoundingSphere"/> from a list of points.
        /// </summary>
        /// <param name="points">The points to create the new <see cref="BoundingSphere"/> from.</param>
        /// <returns>The new <see cref="BoundingSphere"/> containing the specified points.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BoundingSphere CreateFromPoints(XMFloat3[] points)
        {
            if (points == null)
            {
                throw new ArgumentNullException("points");
            }

            if (points.Length == 0)
            {
                throw new ArgumentOutOfRangeException("points");
            }

            // Find the points with minimum and maximum x, y, and z
            XMVector minX, maxX, minY, maxY, minZ, maxZ;

            minX = maxX = minY = maxY = minZ = maxZ = points[0];

            for (int i = 1; i < points.Length; i++)
            {
                XMVector point = points[i];

                float px = point.X;
                float py = point.Y;
                float pz = point.Z;

                if (px < minX.X)
                {
                    minX = point;
                }

                if (px > maxX.X)
                {
                    maxX = point;
                }

                if (py < minY.Y)
                {
                    minY = point;
                }

                if (py > maxY.Y)
                {
                    maxY = point;
                }

                if (pz < minZ.Z)
                {
                    minZ = point;
                }

                if (pz > maxZ.Z)
                {
                    maxZ = point;
                }
            }

            // Use the min/max pair that are farthest apart to form the initial sphere.
            XMVector deltaX = maxX - minX;
            XMVector distX = XMVector3.Length(deltaX);

            XMVector deltaY = maxY - minY;
            XMVector distY = XMVector3.Length(deltaY);

            XMVector deltaZ = maxZ - minZ;
            XMVector distZ = XMVector3.Length(deltaZ);

            XMVector v_center;
            XMVector v_radius;

            if (XMVector3.Greater(distX, distY))
            {
                if (XMVector3.Greater(distX, distZ))
                {
                    // Use min/max x.
                    v_center = XMVector.Lerp(maxX, minX, 0.5f);
                    v_radius = distX * 0.5f;
                }
                else
                {
                    // Use min/max z.
                    v_center = XMVector.Lerp(maxZ, minZ, 0.5f);
                    v_radius = distZ * 0.5f;
                }
            }
            else
            {
                //// Y >= X

                if (XMVector3.Greater(distY, distZ))
                {
                    // Use min/max y.
                    v_center = XMVector.Lerp(maxY, minY, 0.5f);
                    v_radius = distY * 0.5f;
                }
                else
                {
                    // Use min/max z.
                    v_center = XMVector.Lerp(maxZ, minZ, 0.5f);
                    v_radius = distZ * 0.5f;
                }
            }

            // Add any points not inside the sphere.
            for (int i = 0; i < points.Length; i++)
            {
                XMVector point = points[i];

                XMVector delta = point - v_center;

                XMVector dist = XMVector3.Length(delta);

                if (XMVector3.Greater(dist, v_radius))
                {
                    // Adjust sphere to include the new point.
                    v_radius = (v_radius + dist) * 0.5f;
                    v_center += (XMVector.Replicate(1.0f) - XMVector.Divide(v_radius, dist)) * delta;
                }
            }

            return new BoundingSphere(v_center, v_radius.X);
        }

        /// <summary>
        /// Creates a <see cref="BoundingSphere"/> containing the specified <see cref="BoundingFrustum"/>.
        /// </summary>
        /// <param name="fr">The <see cref="BoundingFrustum"/> the new <see cref="BoundingSphere"/> should contain.</param>
        /// <returns>The new <see cref="BoundingSphere"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BoundingSphere CreateFromFrustum(BoundingFrustum fr)
        {
            return BoundingSphere.CreateFromPoints(fr.GetCorners());
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is BoundingSphere))
            {
                return false;
            }

            return this.Equals((BoundingSphere)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(BoundingSphere other)
        {
            return this.center == other.center
                && this.radius == other.radius;
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
                this.radius
            }
            .GetHashCode();
        }

        /// <summary>
        /// Transforms the <see cref="BoundingSphere"/>.
        /// </summary>
        /// <param name="m">The transformation matrix.</param>
        /// <returns>The transformed <see cref="BoundingSphere"/>.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "m", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public BoundingSphere Transform(XMMatrix m)
        {
            // Load the center of the sphere.
            XMVector v_center = this.center;

            // Transform the center of the sphere.
            XMVector c = XMVector3.Transform(v_center, m);

            XMVector dX = XMVector3.Dot(((XMVector*)&m)[0], ((XMVector*)&m)[0]);
            XMVector dY = XMVector3.Dot(((XMVector*)&m)[1], ((XMVector*)&m)[1]);
            XMVector dZ = XMVector3.Dot(((XMVector*)&m)[2], ((XMVector*)&m)[2]);

            XMVector d = XMVector.Max(dX, XMVector.Max(dY, dZ));

            BoundingSphere result;

            // Store the center sphere.
            result.center = c;

            // Scale the radius of the pshere.
            float scale = (float)Math.Sqrt(d.X);
            result.radius = this.radius * scale;

            return result;
        }

        /// <summary>
        /// Transforms the <see cref="BoundingSphere"/> using the specified scale, rotation and translation vectors.
        /// </summary>
        /// <param name="scale">The value to scale the <see cref="BoundingSphere"/> by.</param>
        /// <param name="rotation">The value to rotate the <see cref="BoundingSphere"/> by.</param>
        /// <param name="translation">The value to translate the <see cref="BoundingSphere"/> by.</param>
        /// <returns>The transformed <see cref="BoundingSphere"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public BoundingSphere Transform(float scale, XMVector rotation, XMVector translation)
        {
            // Load the center of the sphere.
            XMVector v_center = this.center;

            // Transform the center of the sphere.
            v_center = XMVector3.Rotate(v_center * XMVector.Replicate(scale), rotation) + translation;

            BoundingSphere result;

            // Store the center sphere.
            result.center = v_center;

            // Scale the radius of the pshere.
            result.radius = this.radius * scale;

            return result;
        }

        /// <summary>
        /// Tests whether the <see cref="BoundingSphere"/> contains a specified point.
        /// </summary>
        /// <param name="point">The point to test against.</param>
        /// <returns>A <see cref="ContainmentType"/> value indicating whether the <see cref="BoundingSphere"/> contains the specified point.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ContainmentType Contains(XMVector point)
        {
            XMVector v_center = this.center;
            XMVector v_radius = XMVector.Replicate(this.radius);

            XMVector distanceSquared = XMVector3.LengthSquare(point - v_center);
            XMVector radiusSquared = XMVector.Multiply(v_radius, v_radius);

            return XMVector3.LessOrEqual(distanceSquared, radiusSquared) ? ContainmentType.Contains : ContainmentType.Disjoint;
        }

        /// <summary>
        /// Tests whether the <see cref="BoundingSphere"/> contains a specified triangle.
        /// </summary>
        /// <param name="v0">The first corner of the triangle.</param>
        /// <param name="v1">The second corner of the triangle.</param>
        /// <param name="v2">The third corner of the triangle.</param>
        /// <returns>A <see cref="ContainmentType"/> value indicating whether the <see cref="BoundingSphere"/> contains the specified triangle.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ContainmentType Contains(XMVector v0, XMVector v1, XMVector v2)
        {
            if (!this.Intersects(v0, v1, v2))
            {
                return ContainmentType.Disjoint;
            }

            XMVector v_center = this.center;
            XMVector v_radius = XMVector.Replicate(this.radius);
            XMVector radiusSquared = XMVector.Multiply(v_radius, v_radius);

            XMVector distanceSquared = XMVector3.LengthSquare(v0 - v_center);
            XMVector inside = XMVector.LessOrEqual(distanceSquared, radiusSquared);

            distanceSquared = XMVector3.LengthSquare(v1 - v_center);
            inside = XMVector.AndInt(inside, XMVector.LessOrEqual(distanceSquared, radiusSquared));

            distanceSquared = XMVector3.LengthSquare(v2 - v_center);
            inside = XMVector.AndInt(inside, XMVector.LessOrEqual(distanceSquared, radiusSquared));

            return XMVector3.EqualInt(inside, XMVector.TrueInt) ? ContainmentType.Contains : ContainmentType.Intersects;
        }

        /// <summary>
        /// Tests whether the <see cref="BoundingSphere"/> contains a specified <see cref="BoundingSphere"/>.
        /// </summary>
        /// <param name="sh">The <see cref="BoundingSphere"/> to test against.</param>
        /// <returns>A <see cref="ContainmentType"/> value indicating whether the <see cref="BoundingSphere"/> contains the specified <see cref="BoundingSphere"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ContainmentType Contains(BoundingSphere sh)
        {
            XMVector center1 = this.center;
            float r1 = this.radius;

            XMVector center2 = sh.center;
            float r2 = sh.radius;

            XMVector v = XMVector.Subtract(center2, center1);

            XMVector dist = XMVector3.Length(v);
            float d = dist.X;

            return (r1 + r2 >= d) ? ((r1 - r2 >= d) ? ContainmentType.Contains : ContainmentType.Intersects) : ContainmentType.Disjoint;
        }

        /// <summary>
        /// Tests whether the <see cref="BoundingSphere"/> contains a specified <see cref="BoundingBox"/>.
        /// </summary>
        /// <param name="box">The <see cref="BoundingBox"/> to test against.</param>
        /// <returns>A <see cref="ContainmentType"/> value indicating whether the <see cref="BoundingSphere"/> contains the specified <see cref="BoundingBox"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ContainmentType Contains(BoundingBox box)
        {
            if (!box.Intersects(this))
            {
                return ContainmentType.Disjoint;
            }

            XMVector v_center = this.center;
            XMVector v_radius = XMVector.Replicate(this.radius);
            XMVector radiusSq = v_radius * v_radius;

            XMVector boxCenter = box.Center;
            XMVector boxExtents = box.Extents;

            XMVector insideAll = XMVector.TrueInt;

            XMVector offset = boxCenter - v_center;

            for (int i = 0; i < BoundingBox.CornerCount; i++)
            {
                XMVector c = XMVector.MultiplyAdd(boxExtents, CollisionGlobalConstants.BoxOffsets[i], offset);
                XMVector d = XMVector3.LengthSquare(c);

                insideAll = XMVector.AndInt(insideAll, XMVector.LessOrEqual(d, radiusSq));
            }

            return XMVector3.EqualInt(insideAll, XMVector.TrueInt) ? ContainmentType.Contains : ContainmentType.Intersects;
        }

        /// <summary>
        /// Tests whether the <see cref="BoundingSphere"/> contains the specified <see cref="BoundingOrientedBox"/>.
        /// </summary>
        /// <param name="box">The <see cref="BoundingOrientedBox"/> to test against.</param>
        /// <returns>A <see cref="ContainmentType"/> value indicating whether the <see cref="BoundingOrientedBox"/> is contained in the <see cref="BoundingSphere"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ContainmentType Contains(BoundingOrientedBox box)
        {
            if (!box.Intersects(this))
            {
                return ContainmentType.Disjoint;
            }

            XMVector v_center = this.center;
            XMVector v_radius = XMVector.Replicate(this.radius);
            XMVector radiusSq = v_radius * v_radius;

            XMVector boxCenter = box.Center;
            XMVector boxExtents = box.Extents;
            XMVector boxOrientation = box.Orientation;

            Debug.Assert(Internal.XMQuaternionIsUnit(boxOrientation), "Reviewed");

            XMVector insideAll = XMVector.TrueInt;

            for (int i = 0; i < BoundingOrientedBox.CornerCount; i++)
            {
                XMVector c = XMVector3.Rotate(boxExtents * CollisionGlobalConstants.BoxOffsets[i], boxOrientation) + boxCenter;
                XMVector d = XMVector3.LengthSquare(XMVector.Subtract(v_center, c));
                insideAll = XMVector.AndInt(insideAll, XMVector.LessOrEqual(d, radiusSq));
            }

            return XMVector3.EqualInt(insideAll, XMVector.TrueInt) ? ContainmentType.Contains : ContainmentType.Intersects;
        }

        /// <summary>
        /// Tests whether the <see cref="BoundingSphere"/> contains the specified <see cref="BoundingFrustum"/>.
        /// </summary>
        /// <param name="fr">The <see cref="BoundingFrustum"/> to test against.</param>
        /// <returns>A <see cref="ContainmentType"/> value indicating whether the <see cref="BoundingFrustum"/> is contained in the <see cref="BoundingSphere"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ContainmentType Contains(BoundingFrustum fr)
        {
            if (!fr.Intersects(this))
            {
                return ContainmentType.Disjoint;
            }

            XMVector v_center = this.center;
            XMVector v_radius = XMVector.Replicate(this.radius);
            XMVector radiusSq = v_radius * v_radius;

            XMVector v_origin = fr.Origin;
            XMVector v_orientation = fr.Orientation;

            Debug.Assert(Internal.XMQuaternionIsUnit(v_orientation), "Reviewed");

            // Build the corners of the frustum.
            XMVector v_rightTop = new XMVector(fr.RightSlope, fr.TopSlope, 1.0f, 0.0f);
            XMVector v_rightBottom = new XMVector(fr.RightSlope, fr.BottomSlope, 1.0f, 0.0f);
            XMVector v_leftTop = new XMVector(fr.LeftSlope, fr.TopSlope, 1.0f, 0.0f);
            XMVector v_leftBottom = new XMVector(fr.LeftSlope, fr.BottomSlope, 1.0f, 0.0f);
            XMVector v_near = XMVector.Replicate(fr.Near);
            XMVector v_far = XMVector.Replicate(fr.Far);

            XMVector[] corners = new XMVector[BoundingFrustum.CornerCount];
            corners[0] = v_rightTop * v_near;
            corners[1] = v_rightBottom * v_near;
            corners[2] = v_leftTop * v_near;
            corners[3] = v_leftBottom * v_near;
            corners[4] = v_rightTop * v_far;
            corners[5] = v_rightBottom * v_far;
            corners[6] = v_leftTop * v_far;
            corners[7] = v_leftBottom * v_far;

            XMVector insideAll = XMVector.TrueInt;

            for (int i = 0; i < BoundingFrustum.CornerCount; i++)
            {
                XMVector c = XMVector3.Rotate(corners[i], v_orientation) + v_origin;
                XMVector d = XMVector3.LengthSquare(XMVector.Subtract(v_center, c));
                insideAll = XMVector.AndInt(insideAll, XMVector.LessOrEqual(d, radiusSq));
            }

            return XMVector3.EqualInt(insideAll, XMVector.TrueInt) ? ContainmentType.Contains : ContainmentType.Intersects;
        }

        /// <summary>
        /// Tests the <see cref="BoundingSphere"/> for intersection with a <see cref="BoundingSphere"/>.
        /// </summary>
        /// <param name="sh">The <see cref="BoundingSphere"/> to test against.</param>
        /// <returns>A boolean value indicating whether the <see cref="BoundingSphere"/> intersects the specified <see cref="BoundingSphere"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Intersects(BoundingSphere sh)
        {
            // Load A.
            XMVector v_centerA = this.center;
            XMVector v_radiusA = XMVector.Replicate(this.radius);

            // Load B.
            XMVector v_centerB = sh.center;
            XMVector v_radiusB = XMVector.Replicate(sh.radius);

            // Distance squared between centers.
            XMVector delta = v_centerB - v_centerA;
            XMVector distanceSquared = XMVector3.LengthSquare(delta);

            // Sum of the radii squared.
            XMVector radiusSquared = XMVector.Add(v_radiusA, v_radiusB);
            radiusSquared = XMVector.Multiply(radiusSquared, radiusSquared);

            return XMVector3.LessOrEqual(distanceSquared, radiusSquared);
        }

        /// <summary>
        /// Tests the <see cref="BoundingSphere"/> for intersection with a <see cref="BoundingBox"/>.
        /// </summary>
        /// <param name="box">The <see cref="BoundingBox"/> to test against.</param>
        /// <returns>A boolean value indicating whether the <see cref="BoundingSphere"/> intersects the specified <see cref="BoundingBox"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Intersects(BoundingBox box)
        {
            return box.Intersects(this);
        }

        /// <summary>
        /// Test the <see cref="BoundingSphere"/> for intersection with a <see cref="BoundingOrientedBox"/>.
        /// </summary>
        /// <param name="box">The <see cref="BoundingOrientedBox"/> to test for intersection.</param>
        /// <returns>A boolean value indicating whether the <see cref="BoundingSphere"/> intersects the specified <see cref="BoundingOrientedBox"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Intersects(BoundingOrientedBox box)
        {
            return box.Intersects(this);
        }

        /// <summary>
        /// Test the <see cref="BoundingSphere"/> for intersection with a <see cref="BoundingFrustum"/>.
        /// </summary>
        /// <param name="fr">The <see cref="BoundingFrustum"/> to test for intersection.</param>
        /// <returns>A boolean value indicating whether the <see cref="BoundingSphere"/> intersects the specified <see cref="BoundingFrustum"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Intersects(BoundingFrustum fr)
        {
            return fr.Intersects(this);
        }

        /// <summary>
        /// Tests the <see cref="BoundingSphere"/> for intersection with a triangle.
        /// </summary>
        /// <param name="v0">The first corner of the triangle.</param>
        /// <param name="v1">The second corner of the triangle.</param>
        /// <param name="v2">The third corner of the triangle.</param>
        /// <returns>A boolean value indicating whether the <see cref="BoundingSphere"/> intersects the specified triangle.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Intersects(XMVector v0, XMVector v1, XMVector v2)
        {
            // Load the sphere.    
            XMVector v_center = this.center;
            XMVector v_radius = XMVector.Replicate(this.radius);

            // Compute the plane of the triangle (has to be normalized).
            XMVector n = XMVector3.Normalize(XMVector3.Cross(v1 - v0, v2 - v0));

            // Assert that the triangle is not degenerate.
            Debug.Assert(!XMVector3.Equal(n, XMGlobalConstants.Zero), "Reviewed");

            // Find the nearest feature on the triangle to the sphere.
            XMVector dist = XMVector3.Dot(v_center - v0, n);

            // If the center of the sphere is farther from the plane of the triangle than
            // the radius of the sphere, then there cannot be an intersection.
            XMVector noIntersection = XMVector.Less(dist, -v_radius);
            noIntersection = XMVector.OrInt(noIntersection, XMVector.Greater(dist, v_radius));

            // Project the center of the sphere onto the plane of the triangle.
            XMVector point = v_center - (n * dist);

            // Is it inside all the edges? If so we intersect because the distance 
            // to the plane is less than the radius.
            XMVector intersection = Internal.PointOnPlaneInsideTriangle(point, v0, v1, v2);

            // Find the nearest point on each edge.
            XMVector radiusSq = v_radius * v_radius;

            // Edge 0,1
            point = Internal.PointOnLineSegmentNearestPoint(v0, v1, v_center);

            // If the distance to the center of the sphere to the point is less than 
            // the radius of the sphere then it must intersect.
            intersection = XMVector.OrInt(intersection, XMVector.LessOrEqual(XMVector3.LengthSquare(v_center - point), radiusSq));

            // Edge 1,2
            point = Internal.PointOnLineSegmentNearestPoint(v1, v2, v_center);

            // If the distance to the center of the sphere to the point is less than 
            // the radius of the sphere then it must intersect.
            intersection = XMVector.OrInt(intersection, XMVector.LessOrEqual(XMVector3.LengthSquare(v_center - point), radiusSq));

            // Edge 2,0
            point = Internal.PointOnLineSegmentNearestPoint(v2, v0, v_center);

            // If the distance to the center of the sphere to the point is less than 
            // the radius of the sphere then it must intersect.
            intersection = XMVector.OrInt(intersection, XMVector.LessOrEqual(XMVector3.LengthSquare(v_center - point), radiusSq));

            return XMVector4.EqualInt(XMVector.AndComplementInt(intersection, noIntersection), XMVector.TrueInt);
        }

        /// <summary>
        /// Tests the <see cref="BoundingSphere"/> for intersection with a plane.
        /// </summary>
        /// <param name="plane">A vector describing the plane.</param>
        /// <returns>A <see cref="PlaneIntersectionType"/> value indicating whether the <see cref="BoundingSphere"/> intersects the specified plane.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public PlaneIntersectionType Intersects(XMVector plane)
        {
            Debug.Assert(Internal.XMPlaneIsUnit(plane), "Reviewed");

            // Load the sphere.
            XMVector v_center = this.center;
            XMVector v_radius = XMVector.Replicate(this.radius);

            // Set w of the center to one so we can dot4 with a plane.
            v_center.W = 1.0f;

            XMVector outside, inside;
            Internal.FastIntersectSpherePlane(v_center, v_radius, plane, out outside, out inside);

            // If the sphere is outside any plane it is outside.
            if (XMVector4.EqualInt(outside, XMVector.TrueInt))
            {
                return PlaneIntersectionType.Front;
            }

            // If the sphere is inside all planes it is inside.
            if (XMVector4.EqualInt(inside, XMVector.TrueInt))
            {
                return PlaneIntersectionType.Back;
            }

            // The sphere is not inside all planes or outside a plane it intersects.
            return PlaneIntersectionType.Intersecting;
        }

        /// <summary>
        /// Tests the <see cref="BoundingSphere"/> for intersection with a ray.
        /// </summary>
        /// <param name="origin">The origin of the ray.</param>
        /// <param name="direction">The direction of the ray.</param>
        /// <returns>A boolean value indicating whether the <see cref="BoundingSphere"/> contains the specified ray.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Intersects(XMVector origin, XMVector direction)
        {
            float distance;
            return this.Intersects(origin, direction, out distance);
        }

        /// <summary>
        /// Tests the <see cref="BoundingSphere"/> for intersection with a ray.
        /// </summary>
        /// <param name="origin">The origin of the ray.</param>
        /// <param name="direction">The direction of the ray.</param>
        /// <param name="distance">The length of the ray.</param>
        /// <returns>A boolean value indicating whether the <see cref="BoundingSphere"/> contains the specified ray.</returns>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "2#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Intersects(XMVector origin, XMVector direction, out float distance)
        {
            Debug.Assert(Internal.XMVector3IsUnit(direction), "Reviewed");

            XMVector v_center = this.center;
            XMVector v_radius = XMVector.Replicate(this.radius);

            // l is the vector from the ray origin to the center of the sphere.
            XMVector l = v_center - origin;

            // s is the projection of the l onto the ray direction.
            XMVector s = XMVector3.Dot(l, direction);

            XMVector l2 = XMVector3.Dot(l, l);

            XMVector r2 = v_radius * v_radius;

            // m2 is squared distance from the center of the sphere to the projection.
            XMVector m2 = l2 - (s * s);

            XMVector noIntersection;

            // If the ray origin is outside the sphere and the center of the sphere is 
            // behind the ray origin there is no intersection.
            noIntersection = XMVector.AndInt(XMVector.Less(s, XMGlobalConstants.Zero), XMVector.Greater(l2, r2));

            // If the squared distance from the center of the sphere to the projection
            // is greater than the radius squared the ray will miss the sphere.
            noIntersection = XMVector.OrInt(noIntersection, XMVector.Greater(m2, r2));

            // The ray hits the sphere, compute the nearest intersection point.
            XMVector q = (r2 - m2).Sqrt();
            XMVector t1 = s - q;
            XMVector t2 = s + q;

            XMVector originInside = XMVector.LessOrEqual(l2, r2);
            XMVector t = XMVector.Select(t1, t2, originInside);

            if (XMVector4.NotEqualInt(noIntersection, XMVector.TrueInt))
            {
                // Store the x-component to *pDist.
                t.StoreFloat(out distance);
                return true;
            }

            distance = 0.0f;
            return false;
        }

        /// <summary>
        /// Tests whether the <see cref="BoundingSphere"/> is contained by the specified frustum.
        /// </summary>
        /// <param name="planes">The planes describing the frustum.</param>
        /// <returns>A <see cref="ContainmentType"/> value indicating whether the frustum contains the <see cref="BoundingSphere"/>.</returns>
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
        /// Tests whether the <see cref="BoundingSphere"/> is contained by the specified frustum.
        /// </summary>
        /// <param name="plane0">The first plane describing the frustum.</param>
        /// <param name="plane1">The second plane describing the frustum.</param>
        /// <param name="plane2">The third plane describing the frustum.</param>
        /// <param name="plane3">The fourth plane describing the frustum.</param>
        /// <param name="plane4">The fifth plane describing the frustum.</param>
        /// <param name="plane5">The sixth plane describing the frustum.</param>
        /// <returns>A <see cref="ContainmentType"/> value indicating whether the frustum contains the <see cref="BoundingSphere"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ContainmentType ContainedBy(
            XMVector plane0,
            XMVector plane1,
            XMVector plane2,
            XMVector plane3,
            XMVector plane4,
            XMVector plane5)
        {
            // Load the sphere.
            XMVector v_center = this.center;
            XMVector v_radius = XMVector.Replicate(this.radius);

            // Set w of the center to one so we can dot4 with a plane.
            v_center.W = 1.0f;

            XMVector outside, inside;

            // Test against each plane.
            Internal.FastIntersectSpherePlane(v_center, v_radius, plane0, out outside, out inside);

            XMVector anyOutside = outside;
            XMVector allInside = inside;

            Internal.FastIntersectSpherePlane(v_center, v_radius, plane1, out outside, out inside);
            anyOutside = XMVector.OrInt(anyOutside, outside);
            allInside = XMVector.AndInt(allInside, inside);

            Internal.FastIntersectSpherePlane(v_center, v_radius, plane2, out outside, out inside);
            anyOutside = XMVector.OrInt(anyOutside, outside);
            allInside = XMVector.AndInt(allInside, inside);

            Internal.FastIntersectSpherePlane(v_center, v_radius, plane3, out outside, out inside);
            anyOutside = XMVector.OrInt(anyOutside, outside);
            allInside = XMVector.AndInt(allInside, inside);

            Internal.FastIntersectSpherePlane(v_center, v_radius, plane4, out outside, out inside);
            anyOutside = XMVector.OrInt(anyOutside, outside);
            allInside = XMVector.AndInt(allInside, inside);

            Internal.FastIntersectSpherePlane(v_center, v_radius, plane5, out outside, out inside);
            anyOutside = XMVector.OrInt(anyOutside, outside);
            allInside = XMVector.AndInt(allInside, inside);

            // If the sphere is outside any plane it is outside.
            if (XMVector4.EqualInt(anyOutside, XMVector.TrueInt))
            {
                return ContainmentType.Disjoint;
            }

            // If the sphere is inside all planes it is inside.
            if (XMVector4.EqualInt(allInside, XMVector.TrueInt))
            {
                return ContainmentType.Contains;
            }

            // The sphere is not inside all planes or outside a plane, it may intersect.
            return ContainmentType.Intersects;
        }
    }
}
