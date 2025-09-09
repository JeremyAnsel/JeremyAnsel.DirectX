// <copyright file="XMVector.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DXMath
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using JeremyAnsel.DirectX.DXMath.PackedVector;

    /// <summary>
    /// A vector of four 32-bit floating-point or integer components.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct XMVector : IEquatable<XMVector>
    {
        /// <summary>
        /// The x component.
        /// </summary>
        private float x;

        /// <summary>
        /// The y component.
        /// </summary>
        private float y;

        /// <summary>
        /// The z component.
        /// </summary>
        private float z;

        /// <summary>
        /// The w component.
        /// </summary>
        private float w;

        /// <summary>
        /// Initializes a new instance of the <see cref="XMVector"/> struct.
        /// </summary>
        /// <param name="x">The x component.</param>
        /// <param name="y">The y component.</param>
        /// <param name="z">The z component.</param>
        /// <param name="w">The w component.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "x", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "y", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "z", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "w", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XMVector"/> struct.
        /// </summary>
        /// <param name="array">The components.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector(float[]? array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length != 4)
            {
                throw new ArgumentOutOfRangeException(nameof(array));
            }

            this.x = array[0];
            this.y = array[1];
            this.z = array[2];
            this.w = array[3];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XMVector"/> struct.
        /// </summary>
        /// <param name="array">The components.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector(int[]? array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length != 4)
            {
                throw new ArgumentOutOfRangeException(nameof(array));
            }

            fixed (XMVector* v = &this)
            {
                ((int*)v)[0] = array[0];
                ((int*)v)[1] = array[1];
                ((int*)v)[2] = array[2];
                ((int*)v)[3] = array[3];
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XMVector"/> struct.
        /// </summary>
        /// <param name="array">The components.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector(uint[]? array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length != 4)
            {
                throw new ArgumentOutOfRangeException(nameof(array));
            }

            fixed (XMVector* v = &this)
            {
                ((uint*)v)[0] = array[0];
                ((uint*)v)[1] = array[1];
                ((uint*)v)[2] = array[2];
                ((uint*)v)[3] = array[3];
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XMVector"/> struct.
        /// </summary>
        /// <param name="array">The components.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector(byte[]? array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length != 16)
            {
                throw new ArgumentOutOfRangeException(nameof(array));
            }

            fixed (XMVector* v = &this)
            {
                ((byte*)v)[0] = array[0];
                ((byte*)v)[1] = array[1];
                ((byte*)v)[2] = array[2];
                ((byte*)v)[3] = array[3];
                ((byte*)v)[4] = array[4];
                ((byte*)v)[5] = array[5];
                ((byte*)v)[6] = array[6];
                ((byte*)v)[7] = array[7];
                ((byte*)v)[8] = array[8];
                ((byte*)v)[9] = array[9];
                ((byte*)v)[10] = array[10];
                ((byte*)v)[11] = array[11];
                ((byte*)v)[12] = array[12];
                ((byte*)v)[13] = array[13];
                ((byte*)v)[14] = array[14];
                ((byte*)v)[15] = array[15];
            }
        }

        /// <summary>
        /// Gets the zero vector.
        /// </summary>
        public static XMVector Zero
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return new XMVector(0.0f, 0.0f, 0.0f, 0.0f);
            }
        }

        /// <summary>
        /// Gets a vector, each of whose components represents true (0xFFFFFFFF).
        /// </summary>
        public static XMVector TrueInt
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return XMVector.FromInt(0xFFFFFFFFU, 0xFFFFFFFFU, 0xFFFFFFFFU, 0xFFFFFFFFU);
            }
        }

        /// <summary>
        /// Gets the zero (false) vector.
        /// </summary>
        public static XMVector FalseInt
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return XMVector.FromInt(0U, 0U, 0U, 0U);
            }
        }

        /// <summary>
        /// Gets a vector, each of whose components are one.
        /// </summary>
        public static XMVector One
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return new XMVector(1.0f, 1.0f, 1.0f, 1.0f);
            }
        }

        /// <summary>
        /// Gets a vector, each of whose components are infinity (0x7F800000).
        /// </summary>
        public static XMVector Infinity
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return XMVector.FromInt(0x7F800000U, 0x7F800000U, 0x7F800000U, 0x7F800000U);
            }
        }

        /// <summary>
        /// Gets a vector, each of whose components are QNaN (0x7CF00000).
        /// </summary>
        public static XMVector QNaN
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return XMVector.FromInt(0x7FC00000U, 0x7FC00000U, 0x7FC00000U, 0x7FC00000U);
            }
        }

        /// <summary>
        /// Gets a vector, each of whose components are epsilon (1.192092896e-7).
        /// </summary>
        public static XMVector Epsilon
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return XMVector.FromInt(0x34000000U, 0x34000000U, 0x34000000U, 0x34000000U);
            }
        }

        /// <summary>
        /// Gets a vector, each of whose components are the sign mask (0x80000000).
        /// </summary>
        public static XMVector SignMask
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return XMVector.FromInt(0x80000000U, 0x80000000U, 0x80000000U, 0x80000000U);
            }
        }

        /// <summary>
        /// Gets or sets the x component.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "X", Justification = "Reviewed")]
        public float X
        {
            get { return this.x; }
            set { this.x = value; }
        }

        /// <summary>
        /// Gets or sets the y component.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Y", Justification = "Reviewed")]
        public float Y
        {
            get { return this.y; }
            set { this.y = value; }
        }

        /// <summary>
        /// Gets or sets the z component.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Z", Justification = "Reviewed")]
        public float Z
        {
            get { return this.z; }
            set { this.z = value; }
        }

        /// <summary>
        /// Gets or sets the w component.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "W", Justification = "Reviewed")]
        public float W
        {
            get { return this.w; }
            set { this.w = value; }
        }

        /// <summary>
        /// Gets or sets the x component.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "int", Justification = "Reviewed")]
        public uint IntX
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                fixed (XMVector* v = &this)
                {
                    return ((uint*)v)[0];
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                fixed (XMVector* v = &this)
                {
                    ((uint*)v)[0] = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the y component.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "int", Justification = "Reviewed")]
        public uint IntY
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                fixed (XMVector* v = &this)
                {
                    return ((uint*)v)[1];
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                fixed (XMVector* v = &this)
                {
                    ((uint*)v)[1] = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the z component.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "int", Justification = "Reviewed")]
        public uint IntZ
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                fixed (XMVector* v = &this)
                {
                    return ((uint*)v)[2];
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                fixed (XMVector* v = &this)
                {
                    ((uint*)v)[2] = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the w component.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "int", Justification = "Reviewed")]
        public uint IntW
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                fixed (XMVector* v = &this)
                {
                    return ((uint*)v)[3];
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                fixed (XMVector* v = &this)
                {
                    ((uint*)v)[3] = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets a component by index.
        /// </summary>
        /// <param name="index">The index of the component.</param>
        /// <returns>A float value.</returns>
        public float this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (index < 0 || index >= 4)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }

                fixed (XMVector* v = &this)
                {
                    return ((float*)v)[index];
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (index < 0 || index >= 4)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }

                fixed (XMVector* v = &this)
                {
                    ((float*)v)[index] = value;
                }
            }
        }

        /// <summary>
        /// Performance an identity operation on a vector.
        /// </summary>
        /// <param name="v">The vector.</param>
        /// <returns>Returns the vector.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector operator +(XMVector v)
        {
            return v;
        }

        /// <summary>
        /// Computes the negation of a vector.
        /// </summary>
        /// <param name="v">The vector.</param>
        /// <returns>Returns the negation of the vector.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector operator -(XMVector v)
        {
            return v.Negate();
        }

        /// <summary>
        /// Computes the sum of two vectors.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns a vector that is the sum of V1 and V2.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector operator +(XMVector v1, XMVector v2)
        {
            return XMVector.Add(v1, v2);
        }

        /// <summary>
        /// Computes the difference of two vectors.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns a vector that is the difference of V1 and V2.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector operator -(XMVector v1, XMVector v2)
        {
            return XMVector.Subtract(v1, v2);
        }

        /// <summary>
        /// Computes the per-component product of two vectors.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns a vector, each of whose components is the product of the corresponding components of V1 and V2.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector operator *(XMVector v1, XMVector v2)
        {
            return XMVector.Multiply(v1, v2);
        }

        /// <summary>
        /// Divides one instance of XMVECTOR by a second instance, returning the result in a third instance.
        /// </summary>
        /// <param name="v1">The dividends.</param>
        /// <param name="v2">The divisors.</param>
        /// <returns>The quotient.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector operator /(XMVector v1, XMVector v2)
        {
            return XMVector.Divide(v1, v2);
        }

        /// <summary>
        /// Scalar multiplies a vector by a floating-point value.
        /// </summary>
        /// <param name="v">The vector.</param>
        /// <param name="s">A scalar value.</param>
        /// <returns>Returns the scaled vector.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "s", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector operator *(XMVector v, float s)
        {
            return v.Scale(s);
        }

        /// <summary>
        /// Scalar multiplies a vector by a floating-point value.
        /// </summary>
        /// <param name="s">A scalar value.</param>
        /// <param name="v">The vector.</param>
        /// <returns>Returns the scaled vector.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "s", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector operator *(float s, XMVector v)
        {
            return v.Scale(s);
        }

        /// <summary>
        /// Divides a vector by a scalar value, returning the result in a third instance.
        /// </summary>
        /// <param name="v">The vector.</param>
        /// <param name="s">A scalar value.</param>
        /// <returns>The quotient.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "s", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector operator /(XMVector v, float s)
        {
            return XMVector.Divide(v, XMVector.Replicate(s));
        }

        /// <summary>
        /// Convert a vector to an array of float.
        /// </summary>
        /// <param name="value">The vector.</param>
        /// <returns>An array of float.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Usage", "CA2225:Les surcharges d'opérateur offrent d'autres méthodes nommées", Justification = "Reviewed.")]
        public static implicit operator float[](XMVector value)
        {
            return value.ToArray();
        }

        /// <summary>
        /// Compares two <see cref="XMVector"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="XMVector"/> to compare.</param>
        /// <param name="right">The right <see cref="XMVector"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(XMVector left, XMVector right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="XMVector"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="XMVector"/> to compare.</param>
        /// <param name="right">The right <see cref="XMVector"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(XMVector left, XMVector right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Creates a vector, each of whose components is either 0.0f or 1.0f.
        /// </summary>
        /// <param name="c0">This parameter must be a number (an immediate value, either 0 or 1) and not a variable. If C0 is 0, the x-component of the returned vector will be 0.0f. Otherwise, the x-component will be 1.0f.</param>
        /// <param name="c1">This parameter must be a number (an immediate value, either 0 or 1) and not a variable. If C1 is 0, the y-component of the returned vector will be 0.0f. Otherwise, the y-component will be 1.0f.</param>
        /// <param name="c2">This parameter must be a number (an immediate value, either 0 or 1) and not a variable. If C2 is 0, the z-component of the returned vector will be 0.0f. Otherwise, the z-component will be 1.0f.</param>
        /// <param name="c3">This parameter must be a number (an immediate value, either 0 or 1) and not a variable. If C3 is 0, the w-component of the returned vector will be 0.0f. Otherwise, the w-component will be 1.0f.</param>
        /// <returns>Returns a vector, each of whose components is either 0.0f or 1.0f.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector FromBinaryConstant(uint c0, uint c1, uint c2, uint c3)
        {
            XMVector result;

            ((uint*)&result)[0] = (0 - (c0 & 1)) & 0x3F800000;
            ((uint*)&result)[1] = (0 - (c1 & 1)) & 0x3F800000;
            ((uint*)&result)[2] = (0 - (c2 & 1)) & 0x3F800000;
            ((uint*)&result)[3] = (0 - (c3 & 1)) & 0x3F800000;

            return result;
        }

        /// <summary>
        /// Creates a vector, each of whose components is either 0.0f or 1.0f.
        /// </summary>
        /// <param name="constants">An array of binary number.</param>
        /// <returns>Returns a vector, each of whose components is either 0.0f or 1.0f.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector FromBinaryConstant(uint[]? constants)
        {
            if (constants == null)
            {
                throw new ArgumentNullException(nameof(constants));
            }

            if (constants.Length != 4)
            {
                throw new ArgumentOutOfRangeException(nameof(constants));
            }

            XMVector result;

            ((uint*)&result)[0] = (0 - (constants[0] & 1)) & 0x3F800000;
            ((uint*)&result)[1] = (0 - (constants[1] & 1)) & 0x3F800000;
            ((uint*)&result)[2] = (0 - (constants[2] & 1)) & 0x3F800000;
            ((uint*)&result)[3] = (0 - (constants[3] & 1)) & 0x3F800000;

            return result;
        }

        /// <summary>
        /// Creates a vector with identical floating-point components. Each component is a constant divided by two raised to an integer exponent.
        /// </summary>
        /// <param name="intConstant">This value will be converted to a floating-point number and divided by two raised to the <paramref name="divExponent"/> power. The result is replicated to each component of the returned vector.</param>
        /// <param name="divExponent">Describes the exponent applied to the quotient. This parameter must be a number (an immediate value) and not a variable.</param>
        /// <returns>Returns a vector with identical floating-point components. Each component is a constant divided by two raised to an integer exponent.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "int", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector FromSplatConstant(int intConstant, uint divExponent)
        {
            if (intConstant < -16 || intConstant > 15)
            {
                throw new ArgumentOutOfRangeException(nameof(intConstant));
            }

            if (divExponent >= 32)
            {
                throw new ArgumentOutOfRangeException(nameof(divExponent));
            }

            XMVector v;
            ((int*)&v)[0] = intConstant;
            ((int*)&v)[1] = intConstant;
            ((int*)&v)[2] = intConstant;
            ((int*)&v)[3] = intConstant;

            return v.ConvertIntToFloat(divExponent);
        }

        /// <summary>
        /// Creates a vector with identical integer components.
        /// </summary>
        /// <param name="intConstant">Value to replicate to each component of the returned vector.</param>
        /// <returns>Returns a vector, each of whose components is <paramref name="intConstant"/>.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "int", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector FromSplatConstantInt(int intConstant)
        {
            if (intConstant < -16 || intConstant > 15)
            {
                throw new ArgumentOutOfRangeException(nameof(intConstant));
            }

            XMVector v;
            ((int*)&v)[0] = intConstant;
            ((int*)&v)[1] = intConstant;
            ((int*)&v)[2] = intConstant;
            ((int*)&v)[3] = intConstant;

            return v;
        }

        /// <summary>
        /// Loads a scalar value into an <see cref="XMVector"/>.
        /// </summary>
        /// <param name="source">The scalar data to load.</param>
        /// <returns>Returns a vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector LoadInt(uint source)
        {
            XMVector v;
            ((uint*)&v)[0] = source;
            ((uint*)&v)[1] = 0;
            ((uint*)&v)[2] = 0;
            ((uint*)&v)[3] = 0;

            return v;
        }

        /// <summary>
        /// Loads a floating-point scalar value into an <see cref="XMVector"/>.
        /// </summary>
        /// <param name="source">The scalar data to load.</param>
        /// <returns>Returns a vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector LoadFloat(float source)
        {
            XMVector v;
            v.x = source;
            v.y = 0.0f;
            v.z = 0.0f;
            v.w = 0.0f;

            return v;
        }

        /// <summary>
        /// Loads data into the x and y components of an <see cref="XMVector"/>.
        /// </summary>
        /// <param name="source">The data to load.</param>
        /// <returns>Returns a vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector LoadInt2(uint[]? source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (source.Length != 2)
            {
                throw new ArgumentOutOfRangeException(nameof(source));
            }

            XMVector v;
            ((uint*)&v)[0] = source[0];
            ((uint*)&v)[1] = source[1];
            ((uint*)&v)[2] = 0;
            ((uint*)&v)[3] = 0;

            return v;
        }

        /// <summary>
        /// Loads an <see cref="XMFloat2"/> into an <see cref="XMVector"/>.
        /// </summary>
        /// <param name="source">The struct to load.</param>
        /// <returns>Returns a vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector LoadFloat2(XMFloat2 source)
        {
            XMVector v;
            v.x = source.X;
            v.y = source.Y;
            v.z = 0.0f;
            v.w = 0.0f;

            return v;
        }

        /// <summary>
        /// Loads an <see cref="XMInt2"/> into an <see cref="XMVector"/>.
        /// </summary>
        /// <param name="source">The struct to load.</param>
        /// <returns>Returns a vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector LoadSInt2(XMInt2 source)
        {
            XMVector v;
            v.x = source.X;
            v.y = source.Y;
            v.z = 0.0f;
            v.w = 0.0f;

            return v;
        }

        /// <summary>
        /// Loads an <see cref="XMUInt2"/> into an <see cref="XMVector"/>.
        /// </summary>
        /// <param name="source">The struct to load.</param>
        /// <returns>Returns a vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector LoadUInt2(XMUInt2 source)
        {
            XMVector v;
            v.x = source.X;
            v.y = source.Y;
            v.z = 0.0f;
            v.w = 0.0f;

            return v;
        }

        /// <summary>
        /// Loads data into the x, y, and z components of an <see cref="XMVector"/>.
        /// </summary>
        /// <param name="source">The data to load.</param>
        /// <returns>Returns a vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector LoadInt3(uint[]? source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (source.Length != 3)
            {
                throw new ArgumentOutOfRangeException(nameof(source));
            }

            XMVector v;
            ((uint*)&v)[0] = source[0];
            ((uint*)&v)[1] = source[1];
            ((uint*)&v)[2] = source[2];
            ((uint*)&v)[3] = 0;

            return v;
        }

        /// <summary>
        /// Loads an <see cref="XMFloat3"/> into an <see cref="XMVector"/>.
        /// </summary>
        /// <param name="source">The struct to load.</param>
        /// <returns>Returns a vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector LoadFloat3(XMFloat3 source)
        {
            XMVector v;
            v.x = source.X;
            v.y = source.Y;
            v.z = source.Z;
            v.w = 0.0f;

            return v;
        }

        /// <summary>
        /// Loads an <see cref="XMInt3"/> into an <see cref="XMVector"/>.
        /// </summary>
        /// <param name="source">The struct to load.</param>
        /// <returns>Returns a vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector LoadSInt3(XMInt3 source)
        {
            XMVector v;
            v.x = source.X;
            v.y = source.Y;
            v.z = source.Z;
            v.w = 0.0f;

            return v;
        }

        /// <summary>
        /// Loads an <see cref="XMUInt3"/> into an <see cref="XMVector"/>.
        /// </summary>
        /// <param name="source">The struct to load.</param>
        /// <returns>Returns a vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector LoadUInt3(XMUInt3 source)
        {
            XMVector v;
            v.x = source.X;
            v.y = source.Y;
            v.z = source.Z;
            v.w = 0.0f;

            return v;
        }

        /// <summary>
        /// Loads data into the x, y, z, and w components of an <see cref="XMVector"/>.
        /// </summary>
        /// <param name="source">The data to load.</param>
        /// <returns>Returns a vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector LoadInt4(uint[]? source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (source.Length != 4)
            {
                throw new ArgumentOutOfRangeException(nameof(source));
            }

            XMVector v;
            ((uint*)&v)[0] = source[0];
            ((uint*)&v)[1] = source[1];
            ((uint*)&v)[2] = source[2];
            ((uint*)&v)[3] = source[3];

            return v;
        }

        /// <summary>
        /// Loads an <see cref="XMFloat4"/> into an <see cref="XMVector"/>.
        /// </summary>
        /// <param name="source">The struct to load.</param>
        /// <returns>Returns a vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector LoadFloat4(XMFloat4 source)
        {
            XMVector v;
            v.x = source.X;
            v.y = source.Y;
            v.z = source.Z;
            v.w = source.W;

            return v;
        }

        /// <summary>
        /// Loads an <see cref="XMInt4"/> into an <see cref="XMVector"/>.
        /// </summary>
        /// <param name="source">The struct to load.</param>
        /// <returns>Returns a vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector LoadSInt4(XMInt4 source)
        {
            XMVector v;
            v.x = source.X;
            v.y = source.Y;
            v.z = source.Z;
            v.w = source.W;

            return v;
        }

        /// <summary>
        /// Loads an <see cref="XMUInt4"/> into an <see cref="XMVector"/>.
        /// </summary>
        /// <param name="source">The struct to load.</param>
        /// <returns>Returns a vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector LoadUInt4(XMUInt4 source)
        {
            XMVector v;
            v.x = source.X;
            v.y = source.Y;
            v.z = source.Z;
            v.w = source.W;

            return v;
        }

        /// <summary>
        /// Creates a vector using four floating-point values.
        /// </summary>
        /// <param name="x">The x component.</param>
        /// <param name="y">The y component.</param>
        /// <param name="z">The z component.</param>
        /// <param name="w">The w component.</param>
        /// <returns>Returns a vector.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "x", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "y", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "z", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "w", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector FromFloat(float x, float y, float z, float w)
        {
            return new XMVector(x, y, z, w);
        }

        /// <summary>
        /// Creates a vector with unsigned integer components.
        /// </summary>
        /// <param name="x">The x component.</param>
        /// <param name="y">The y component.</param>
        /// <param name="z">The z component.</param>
        /// <param name="w">The w component.</param>
        /// <returns>Returns a vector.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "x", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "y", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "z", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "w", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector FromInt(uint x, uint y, uint z, uint w)
        {
            XMVector result;
            ((uint*)&result)[0] = x;
            ((uint*)&result)[1] = y;
            ((uint*)&result)[2] = z;
            ((uint*)&result)[3] = w;

            return result;
        }

        /// <summary>
        /// Replicates a floating-point value into all four components of a vector.
        /// </summary>
        /// <param name="value">The value to replicate.</param>
        /// <returns>Returns a vector, all of whose components are equal to Value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Replicate(float value)
        {
            return new XMVector(value, value, value, value);
        }

        /// <summary>
        /// Replicates an integer value into all four components of a vector.
        /// </summary>
        /// <param name="value">The value to replicate.</param>
        /// <returns>Returns a vector, all of whose components are equal to Value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector ReplicateInt(uint value)
        {
            XMVector result;
            ((uint*)&result)[0] = value;
            ((uint*)&result)[1] = value;
            ((uint*)&result)[2] = value;
            ((uint*)&result)[3] = value;

            return result;
        }

        /// <summary>
        /// Replicates the x component of a vector to all of the components.
        /// </summary>
        /// <param name="v">Vector from which to select the x component.</param>
        /// <returns>Returns a vector, all of whose components are equal to the x component of V.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector SplatX(XMVector v)
        {
            return new XMVector(v.x, v.x, v.x, v.x);
        }

        /// <summary>
        /// Replicates the y component of a vector to all of the components.
        /// </summary>
        /// <param name="v">Vector from which to select the y component.</param>
        /// <returns>Returns a vector, all of whose components are equal to the y component of V.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector SplatY(XMVector v)
        {
            return new XMVector(v.y, v.y, v.y, v.y);
        }

        /// <summary>
        /// Replicates the z component of a vector to all of the components.
        /// </summary>
        /// <param name="v">Vector from which to select the z component.</param>
        /// <returns>Returns a vector, all of whose components are equal to the z component of V.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector SplatZ(XMVector v)
        {
            return new XMVector(v.z, v.z, v.z, v.z);
        }

        /// <summary>
        /// Replicates the w component of a vector to all of the components.
        /// </summary>
        /// <param name="v">Vector from which to select the w component.</param>
        /// <returns>Returns a vector, all of whose components are equal to the w component of V.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "v", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector SplatW(XMVector v)
        {
            return new XMVector(v.w, v.w, v.w, v.w);
        }

        /// <summary>
        /// Permutes the components of two vectors to create a new vector.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <param name="permuteX">Index indicating where the X component of the new vector should be copied from.</param>
        /// <param name="permuteY">Index indicating where the Y component of the new vector should be copied from.</param>
        /// <param name="permuteZ">Index indicating where the Z component of the new vector should be copied from.</param>
        /// <param name="permuteW">Index indicating where the W component of the new vector should be copied from.</param>
        /// <returns>Returns the permuted vector that resulted from combining the source vectors.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Permute(XMVector v1, XMVector v2, XMPermutation permuteX, XMPermutation permuteY, XMPermutation permuteZ, XMPermutation permuteW)
        {
            if ((uint)permuteX > 7)
            {
                throw new ArgumentOutOfRangeException(nameof(permuteX));
            }

            if ((uint)permuteY > 7)
            {
                throw new ArgumentOutOfRangeException(nameof(permuteY));
            }

            if ((uint)permuteZ > 7)
            {
                throw new ArgumentOutOfRangeException(nameof(permuteZ));
            }

            if ((uint)permuteW > 7)
            {
                throw new ArgumentOutOfRangeException(nameof(permuteW));
            }

            uint*[] a_ptr = new uint*[] { (uint*)&v1, (uint*)&v2 };

            XMVector result;

            ((uint*)&result)[0] = a_ptr[(uint)permuteX >> 2][(uint)permuteX & 3U];
            ((uint*)&result)[1] = a_ptr[(uint)permuteY >> 2][(uint)permuteY & 3U];
            ((uint*)&result)[2] = a_ptr[(uint)permuteZ >> 2][(uint)permuteZ & 3U];
            ((uint*)&result)[3] = a_ptr[(uint)permuteW >> 2][(uint)permuteW & 3U];

            return result;
        }

        /// <summary>
        /// Defines a control vector for use in <see cref="XMVector.Select"/>.
        /// </summary>
        /// <param name="index0">Index that determines which vector will be selected to set the X component.</param>
        /// <param name="index1">Index that determines which vector will be selected to set the Y component.</param>
        /// <param name="index2">Index that determines which vector will be selected to set the Z component.</param>
        /// <param name="index3">Index that determines which vector will be selected to set the W component.</param>
        /// <returns>Returns the control vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector SelectControl(uint index0, uint index1, uint index2, uint index3)
        {
            if (index0 >= 2)
            {
                throw new ArgumentOutOfRangeException(nameof(index0));
            }

            if (index1 >= 2)
            {
                throw new ArgumentOutOfRangeException(nameof(index1));
            }

            if (index2 >= 2)
            {
                throw new ArgumentOutOfRangeException(nameof(index2));
            }

            if (index3 >= 2)
            {
                throw new ArgumentOutOfRangeException(nameof(index3));
            }

            return XMVector.FromInt(
                index0 == 0 ? (uint)XMSelection.Select0 : (uint)XMSelection.Select1,
                index1 == 0 ? (uint)XMSelection.Select0 : (uint)XMSelection.Select1,
                index2 == 0 ? (uint)XMSelection.Select0 : (uint)XMSelection.Select1,
                index3 == 0 ? (uint)XMSelection.Select0 : (uint)XMSelection.Select1);
        }

        /// <summary>
        /// Defines a control vector for use in <see cref="XMVector.Select"/>.
        /// </summary>
        /// <param name="indexes">Indexes that determines which vector will be selected.</param>
        /// <returns>Returns the control vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector SelectControl(uint[]? indexes)
        {
            if (indexes == null)
            {
                throw new ArgumentNullException(nameof(indexes));
            }

            if (indexes.Length != 4)
            {
                throw new ArgumentOutOfRangeException(nameof(indexes));
            }

            return XMVector.SelectControl(indexes[0], indexes[1], indexes[2], indexes[3]);
        }

        /// <summary>
        /// Performs a per-component selection between two input vectors and returns the resulting vector.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <param name="control">Vector mask used to select a vector component from either V1 or V2.</param>
        /// <returns>Returns the result of the per-component selection.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Select(XMVector v1, XMVector v2, XMVector control)
        {
            XMVector result;

            ((uint*)&result)[0] = (((uint*)&v1)[0] & ~((uint*)&control)[0]) | (((uint*)&v2)[0] & ((uint*)&control)[0]);
            ((uint*)&result)[1] = (((uint*)&v1)[1] & ~((uint*)&control)[1]) | (((uint*)&v2)[1] & ((uint*)&control)[1]);
            ((uint*)&result)[2] = (((uint*)&v1)[2] & ~((uint*)&control)[2]) | (((uint*)&v2)[2] & ((uint*)&control)[2]);
            ((uint*)&result)[3] = (((uint*)&v1)[3] & ~((uint*)&control)[3]) | (((uint*)&v2)[3] & ((uint*)&control)[3]);

            return result;
        }

        /// <summary>
        /// Creates a new vector by combining the x and y-components of two vectors.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns the merged vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector MergeXY(XMVector v1, XMVector v2)
        {
            XMVector result;
            ((uint*)&result)[0] = ((uint*)&v1)[0];
            ((uint*)&result)[1] = ((uint*)&v2)[0];
            ((uint*)&result)[2] = ((uint*)&v1)[1];
            ((uint*)&result)[3] = ((uint*)&v2)[1];

            return result;
        }

        /// <summary>
        /// Creates a new vector by combining the z and w-components of two vectors.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns the merged vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector MergeZW(XMVector v1, XMVector v2)
        {
            XMVector result;
            ((uint*)&result)[0] = ((uint*)&v1)[2];
            ((uint*)&result)[1] = ((uint*)&v2)[2];
            ((uint*)&result)[2] = ((uint*)&v1)[3];
            ((uint*)&result)[3] = ((uint*)&v2)[3];

            return result;
        }

        /// <summary>
        /// Shifts a vector left by a given number of 32-bit elements, filling the vacated elements with elements from a second vector.
        /// </summary>
        /// <param name="v1">Vector to shift left.</param>
        /// <param name="v2">Vector used to fill in the vacated components of V1 after it is shifted left.</param>
        /// <param name="elements">Number of 32-bit elements by which to shift V left. This parameter must be 0, 1, 2, or 3.</param>
        /// <returns>Returns the shifted and filled in vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector ShiftLeft(XMVector v1, XMVector v2, uint elements)
        {
            if (elements >= 4)
            {
                throw new ArgumentOutOfRangeException(nameof(elements));
            }

            return XMVector.Permute(
                v1,
                v2,
                (XMPermutation)elements,
                (XMPermutation)(elements + 1U),
                (XMPermutation)(elements + 2U),
                (XMPermutation)(elements + 3U));
        }

        /// <summary>
        /// Rotates a vector left by a given number of 32-bit components and insert selected elements of that result into another vector.
        /// </summary>
        /// <param name="vd">Vector to insert into.</param>
        /// <param name="vs">Vector to rotate left.</param>
        /// <param name="leftRotateElements">Number of 32-bit components by which to rotate VS left.</param>
        /// <param name="select0">Either 0 or 1. If one, the x-component of the rotated vector will be inserted into the corresponding component of VD. Otherwise, the x-component of VD is left alone.</param>
        /// <param name="select1">Either 0 or 1. If one, the y-component of the rotated vector will be inserted into the corresponding component of VD. Otherwise, the y-component of VD is left alone.</param>
        /// <param name="select2">Either 0 or 1. If one, the z-component of the rotated vector will be inserted into the corresponding component of VD. Otherwise, the z-component of VD is left alone.</param>
        /// <param name="select3">Either 0 or 1. If one, the w-component of the rotated vector will be inserted into the corresponding component of VD. Otherwise, the w-component of VD is left alone.</param>
        /// <returns>Returns the vector that results from the rotation and insertion.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Insert(XMVector vd, XMVector vs, uint leftRotateElements, uint select0, uint select1, uint select2, uint select3)
        {
            XMVector control = XMVector.SelectControl(select0 & 1U, select1 & 1U, select2 & 1U, select3 & 1U);
            return XMVector.Select(vd, vs.RotateLeft(leftRotateElements), control);
        }

        /// <summary>
        /// Performs a per-component test for equality of two vectors.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns a vector containing the results of each component test.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Equal(XMVector v1, XMVector v2)
        {
            XMVector control;
            ((uint*)&control)[0] = v1.x == v2.x ? 0xFFFFFFFFU : 0U;
            ((uint*)&control)[1] = v1.y == v2.y ? 0xFFFFFFFFU : 0U;
            ((uint*)&control)[2] = v1.z == v2.z ? 0xFFFFFFFFU : 0U;
            ((uint*)&control)[3] = v1.w == v2.w ? 0xFFFFFFFFU : 0U;

            return control;
        }

        /// <summary>
        /// Performs a per-component test for equality of two vectors and sets a comparison value.
        /// </summary>
        /// <param name="record">A comparison value.</param>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns a vector containing the results of each component test.</returns>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector EqualR(out XMComparisonRecord record, XMVector v1, XMVector v2)
        {
            uint ux = v1.x == v2.x ? 0xFFFFFFFFU : 0U;
            uint uy = v1.y == v2.y ? 0xFFFFFFFFU : 0U;
            uint uz = v1.z == v2.z ? 0xFFFFFFFFU : 0U;
            uint uw = v1.w == v2.w ? 0xFFFFFFFFU : 0U;

            uint cr = 0U;

            if ((ux & uy & uz & uw) != 0U)
            {
                // All elements are greater
                cr = XMComparisonRecord.MaskTrue;
            }
            else if ((ux | uy | uz | uw) == 0U)
            {
                // All elements are not greater
                cr = XMComparisonRecord.MaskFalse;
            }

            record = new XMComparisonRecord(cr);

            return XMVector.FromInt(ux, uy, uz, uw);
        }

        /// <summary>
        /// Performs a per-component test for the equality of two vectors, treating each component as an unsigned integer.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns a vector containing the results of each component test.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector EqualInt(XMVector v1, XMVector v2)
        {
            XMVector control;
            ((uint*)&control)[0] = ((uint*)&v1)[0] == ((uint*)&v2)[0] ? 0xFFFFFFFFU : 0U;
            ((uint*)&control)[1] = ((uint*)&v1)[1] == ((uint*)&v2)[1] ? 0xFFFFFFFFU : 0U;
            ((uint*)&control)[2] = ((uint*)&v1)[2] == ((uint*)&v2)[2] ? 0xFFFFFFFFU : 0U;
            ((uint*)&control)[3] = ((uint*)&v1)[3] == ((uint*)&v2)[3] ? 0xFFFFFFFFU : 0U;

            return control;
        }

        /// <summary>
        /// Performs a per-component test for equality of two vectors, treating each component as an unsigned integer. In addition, this function sets a comparison value.
        /// </summary>
        /// <param name="record">A comparison value.</param>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns a vector containing the results of each component test.</returns>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector EqualIntR(out XMComparisonRecord record, XMVector v1, XMVector v2)
        {
            uint ux = ((uint*)&v1)[0] == ((uint*)&v2)[0] ? 0xFFFFFFFFU : 0U;
            uint uy = ((uint*)&v1)[1] == ((uint*)&v2)[1] ? 0xFFFFFFFFU : 0U;
            uint uz = ((uint*)&v1)[2] == ((uint*)&v2)[2] ? 0xFFFFFFFFU : 0U;
            uint uw = ((uint*)&v1)[3] == ((uint*)&v2)[3] ? 0xFFFFFFFFU : 0U;

            uint cr = 0U;

            if ((ux & uy & uz & uw) == 0xFFFFFFFFU)
            {
                // All elements are equal
                cr |= XMComparisonRecord.MaskTrue;
            }
            else if ((ux | uy | uz | uw) == 0U)
            {
                // All elements are not equal
                cr |= XMComparisonRecord.MaskFalse;
            }

            record = new XMComparisonRecord(cr);

            return XMVector.FromInt(ux, uy, uz, uw);
        }

        /// <summary>
        /// Performs a per-component test for equality of two vectors within a given threshold.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <param name="epsilon">Tolerance value used for judging equality.</param>
        /// <returns>Returns a vector containing the results of each component test.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector NearEqual(XMVector v1, XMVector v2, XMVector epsilon)
        {
            float deltaX = Math.Abs(v1.x - v2.x);
            float deltaY = Math.Abs(v1.y - v2.y);
            float deltaZ = Math.Abs(v1.z - v2.z);
            float deltaW = Math.Abs(v1.w - v2.w);

            XMVector control;
            ((uint*)&control)[0] = deltaX <= epsilon.x ? 0xFFFFFFFFU : 0U;
            ((uint*)&control)[1] = deltaY <= epsilon.y ? 0xFFFFFFFFU : 0U;
            ((uint*)&control)[2] = deltaZ <= epsilon.z ? 0xFFFFFFFFU : 0U;
            ((uint*)&control)[3] = deltaW <= epsilon.w ? 0xFFFFFFFFU : 0U;

            return control;
        }

        /// <summary>
        /// Performs a per-component test for the inequality of two vectors.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns a vector containing the results of each component test.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector NotEqual(XMVector v1, XMVector v2)
        {
            XMVector control;
            ((uint*)&control)[0] = v1.x != v2.x ? 0xFFFFFFFF : 0U;
            ((uint*)&control)[1] = v1.y != v2.y ? 0xFFFFFFFF : 0U;
            ((uint*)&control)[2] = v1.z != v2.z ? 0xFFFFFFFF : 0U;
            ((uint*)&control)[3] = v1.w != v2.w ? 0xFFFFFFFF : 0U;

            return control;
        }

        /// <summary>
        /// Performs a per-component test for the inequality of two vectors, treating each component as an unsigned integer.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns a vector containing the results of each component test.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector NotEqualInt(XMVector v1, XMVector v2)
        {
            XMVector control;
            ((uint*)&control)[0] = ((uint*)&v1)[0] != ((uint*)&v2)[0] ? 0xFFFFFFFFU : 0U;
            ((uint*)&control)[1] = ((uint*)&v1)[1] != ((uint*)&v2)[1] ? 0xFFFFFFFFU : 0U;
            ((uint*)&control)[2] = ((uint*)&v1)[2] != ((uint*)&v2)[2] ? 0xFFFFFFFFU : 0U;
            ((uint*)&control)[3] = ((uint*)&v1)[3] != ((uint*)&v2)[3] ? 0xFFFFFFFFU : 0U;

            return control;
        }

        /// <summary>
        /// Performs a per-component test for greater-than between two vectors.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns a vector containing the results of each component test.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Greater(XMVector v1, XMVector v2)
        {
            XMVector control;
            ((uint*)&control)[0] = v1.x > v2.x ? 0xFFFFFFFF : 0U;
            ((uint*)&control)[1] = v1.y > v2.y ? 0xFFFFFFFF : 0U;
            ((uint*)&control)[2] = v1.z > v2.z ? 0xFFFFFFFF : 0U;
            ((uint*)&control)[3] = v1.w > v2.w ? 0xFFFFFFFF : 0U;

            return control;
        }

        /// <summary>
        /// Performs a per-component test for greater-than between two vectors and sets a comparison value.
        /// </summary>
        /// <param name="record">A comparison value.</param>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns a vector containing the results of each component test.</returns>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector GreaterR(out XMComparisonRecord record, XMVector v1, XMVector v2)
        {
            uint ux = v1.x > v2.x ? 0xFFFFFFFFU : 0U;
            uint uy = v1.y > v2.y ? 0xFFFFFFFFU : 0U;
            uint uz = v1.z > v2.z ? 0xFFFFFFFFU : 0U;
            uint uw = v1.w > v2.w ? 0xFFFFFFFFU : 0U;

            uint cr = 0U;

            if ((ux & uy & uz & uw) != 0U)
            {
                // All elements are greater
                cr = XMComparisonRecord.MaskTrue;
            }
            else if ((ux | uy | uz | uw) == 0U)
            {
                // All elements are not greater
                cr = XMComparisonRecord.MaskFalse;
            }

            record = new XMComparisonRecord(cr);

            return XMVector.FromInt(ux, uy, uz, uw);
        }

        /// <summary>
        /// Performs a per-component test for greater-than-or-equal between two vectors.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns a vector containing the results of each component test.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector GreaterOrEqual(XMVector v1, XMVector v2)
        {
            XMVector control;
            ((uint*)&control)[0] = v1.x >= v2.x ? 0xFFFFFFFF : 0U;
            ((uint*)&control)[1] = v1.y >= v2.y ? 0xFFFFFFFF : 0U;
            ((uint*)&control)[2] = v1.z >= v2.z ? 0xFFFFFFFF : 0U;
            ((uint*)&control)[3] = v1.w >= v2.w ? 0xFFFFFFFF : 0U;

            return control;
        }

        /// <summary>
        /// Performs a per-component test for greater-than-or-equal between two vectors and sets a comparison value.
        /// </summary>
        /// <param name="record">A comparison value.</param>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns a vector containing the results of each component test.</returns>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector GreaterOrEqualR(out XMComparisonRecord record, XMVector v1, XMVector v2)
        {
            uint ux = v1.x >= v2.x ? 0xFFFFFFFFU : 0U;
            uint uy = v1.y >= v2.y ? 0xFFFFFFFFU : 0U;
            uint uz = v1.z >= v2.z ? 0xFFFFFFFFU : 0U;
            uint uw = v1.w >= v2.w ? 0xFFFFFFFFU : 0U;

            uint cr = 0U;

            if ((ux & uy & uz & uw) != 0U)
            {
                // All elements are greater
                cr = XMComparisonRecord.MaskTrue;
            }
            else if ((ux | uy | uz | uw) == 0U)
            {
                // All elements are not greater
                cr = XMComparisonRecord.MaskFalse;
            }

            record = new XMComparisonRecord(cr);

            return XMVector.FromInt(ux, uy, uz, uw);
        }

        /// <summary>
        /// Performs a per-component test for less-than between two vectors.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns a vector containing the results of each component test.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Less(XMVector v1, XMVector v2)
        {
            XMVector control;
            ((uint*)&control)[0] = v1.x < v2.x ? 0xFFFFFFFF : 0U;
            ((uint*)&control)[1] = v1.y < v2.y ? 0xFFFFFFFF : 0U;
            ((uint*)&control)[2] = v1.z < v2.z ? 0xFFFFFFFF : 0U;
            ((uint*)&control)[3] = v1.w < v2.w ? 0xFFFFFFFF : 0U;

            return control;
        }

        /// <summary>
        /// Performs a per-component test for less-than-or-equal between two vectors.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns a vector containing the results of each component test.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector LessOrEqual(XMVector v1, XMVector v2)
        {
            XMVector control;
            ((uint*)&control)[0] = v1.x <= v2.x ? 0xFFFFFFFF : 0U;
            ((uint*)&control)[1] = v1.y <= v2.y ? 0xFFFFFFFF : 0U;
            ((uint*)&control)[2] = v1.z <= v2.z ? 0xFFFFFFFF : 0U;
            ((uint*)&control)[3] = v1.w <= v2.w ? 0xFFFFFFFF : 0U;

            return control;
        }

        /// <summary>
        /// Makes a per-component comparison between two vectors, and returns a vector containing the smallest components.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns a vector containing the smallest components between the two vectors.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Min(XMVector v1, XMVector v2)
        {
            XMVector result;
            result.x = v1.x < v2.x ? v1.x : v2.x;
            result.y = v1.y < v2.y ? v1.y : v2.y;
            result.z = v1.z < v2.z ? v1.z : v2.z;
            result.w = v1.w < v2.w ? v1.w : v2.w;

            return result;
        }

        /// <summary>
        /// Makes a per-component comparison between two vectors, and returns a vector containing the largest components.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns a vector containing the largest components between the two vectors.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Max(XMVector v1, XMVector v2)
        {
            XMVector result;
            result.x = v1.x > v2.x ? v1.x : v2.x;
            result.y = v1.y > v2.y ? v1.y : v2.y;
            result.z = v1.z > v2.z ? v1.z : v2.z;
            result.w = v1.w > v2.w ? v1.w : v2.w;

            return result;
        }

        /// <summary>
        /// Computes the logical AND of two vectors, treating each component as an unsigned integer.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns a vector each of whose components are the logical AND of the corresponding components of V1 and V2.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector AndInt(XMVector v1, XMVector v2)
        {
            XMVector result;
            ((uint*)&result)[0] = ((uint*)&v1)[0] & ((uint*)&v2)[0];
            ((uint*)&result)[1] = ((uint*)&v1)[1] & ((uint*)&v2)[1];
            ((uint*)&result)[2] = ((uint*)&v1)[2] & ((uint*)&v2)[2];
            ((uint*)&result)[3] = ((uint*)&v1)[3] & ((uint*)&v2)[3];

            return result;
        }

        /// <summary>
        /// Computes the logical AND of one vector with the negation of a second vector, treating each component as an unsigned integer.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns a vector whose components are the logical AND of each of the components of V1 with the negation of the corresponding components of V2.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector AndComplementInt(XMVector v1, XMVector v2)
        {
            XMVector result;
            ((uint*)&result)[0] = ((uint*)&v1)[0] & ~((uint*)&v2)[0];
            ((uint*)&result)[1] = ((uint*)&v1)[1] & ~((uint*)&v2)[1];
            ((uint*)&result)[2] = ((uint*)&v1)[2] & ~((uint*)&v2)[2];
            ((uint*)&result)[3] = ((uint*)&v1)[3] & ~((uint*)&v2)[3];

            return result;
        }

        /// <summary>
        /// Computes the logical OR of two vectors, treating each component as an unsigned integer.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns a vector, each of whose components are the logical OR of the corresponding components of V1 and V2.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector OrInt(XMVector v1, XMVector v2)
        {
            XMVector result;
            ((uint*)&result)[0] = ((uint*)&v1)[0] | ((uint*)&v2)[0];
            ((uint*)&result)[1] = ((uint*)&v1)[1] | ((uint*)&v2)[1];
            ((uint*)&result)[2] = ((uint*)&v1)[2] | ((uint*)&v2)[2];
            ((uint*)&result)[3] = ((uint*)&v1)[3] | ((uint*)&v2)[3];

            return result;
        }

        /// <summary>
        /// Computes the logical NOR of two vectors, treating each component as an unsigned integer.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns a vector, each of whose components are the logical NOR of the corresponding components of V1 and V2.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector NorInt(XMVector v1, XMVector v2)
        {
            XMVector result;
            ((uint*)&result)[0] = ~(((uint*)&v1)[0] | ((uint*)&v2)[0]);
            ((uint*)&result)[1] = ~(((uint*)&v1)[1] | ((uint*)&v2)[1]);
            ((uint*)&result)[2] = ~(((uint*)&v1)[2] | ((uint*)&v2)[2]);
            ((uint*)&result)[3] = ~(((uint*)&v1)[3] | ((uint*)&v2)[3]);

            return result;
        }

        /// <summary>
        /// Computes the logical XOR of two vectors, treating each component as an unsigned integer.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns a vector, each of whose components are the logical XOR of the corresponding components of V1 and V2.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector XorInt(XMVector v1, XMVector v2)
        {
            XMVector result;
            ((uint*)&result)[0] = ((uint*)&v1)[0] ^ ((uint*)&v2)[0];
            ((uint*)&result)[1] = ((uint*)&v1)[1] ^ ((uint*)&v2)[1];
            ((uint*)&result)[2] = ((uint*)&v1)[2] ^ ((uint*)&v2)[2];
            ((uint*)&result)[3] = ((uint*)&v1)[3] ^ ((uint*)&v2)[3];

            return result;
        }

        /// <summary>
        /// Computes the sum of two vectors.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns a vector that is the sum of V1 and V2.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Add(XMVector v1, XMVector v2)
        {
            XMVector result;
            result.x = v1.x + v2.x;
            result.y = v1.y + v2.y;
            result.z = v1.z + v2.z;
            result.w = v1.w + v2.w;

            return result;
        }

        /// <summary>
        /// Adds two vectors representing angles.
        /// </summary>
        /// <param name="v1">First vector of angles. Each angle must satisfy <c>-XM_PI &lt;= V1 &lt; XM_PI.</c></param>
        /// <param name="v2">Second vector of angles. Each angle must satisfy -XM_2PI &lt;= V2 &lt; XM_2PI.</param>
        /// <returns>Returns a vector whose components are the sums of the angles of the corresponding components. Each component of the returned vector will be an angle less than XM_PI and greater than or equal to -XM_PI.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector AddAngles(XMVector v1, XMVector v2)
        {
            //// Add the given angles together.  If the range of V1 is such
            //// that -Pi <= V1 < Pi and the range of V2 is such that
            //// -2Pi <= V2 <= 2Pi, then the range of the resulting angle
            //// will be -Pi <= Result < Pi.

            XMVector result = XMVector.Add(v1, v2);

            XMVector mask = XMVector.Less(result, XMGlobalConstants.NegativePI);
            XMVector offset = XMVector.Select(XMGlobalConstants.Zero, XMGlobalConstants.TwoPI, mask);

            mask = XMVector.GreaterOrEqual(result, XMGlobalConstants.PI);
            offset = XMVector.Select(offset, XMGlobalConstants.NegativeTwoPI, mask);

            result = XMVector.Add(result, offset);

            return result;
        }

        /// <summary>
        /// Computes the difference of two vectors.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns a vector that is the difference of V1 and V2.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Subtract(XMVector v1, XMVector v2)
        {
            XMVector result;
            result.x = v1.x - v2.x;
            result.y = v1.y - v2.y;
            result.z = v1.z - v2.z;
            result.w = v1.w - v2.w;

            return result;
        }

        /// <summary>
        /// Subtracts two vectors representing angles.
        /// </summary>
        /// <param name="v1">First vector of angles. Each angle must satisfy -XM_PI &lt;= V1 &lt; XM_PI.</param>
        /// <param name="v2">Second vector of angles. Each angle must satisfy -XM_2PI &lt;= V1 &lt; XM_2PI.</param>
        /// <returns>Returns a vector whose components are the differences of the angles of the corresponding components. Each component of the returned vector will be an angle less than XM_PI and greater than or equal to -XM_PI.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector SubtractAngles(XMVector v1, XMVector v2)
        {
            //// Subtract the given angles.  If the range of V1 is such
            //// that -Pi <= V1 < Pi and the range of V2 is such that
            //// -2Pi <= V2 <= 2Pi, then the range of the resulting angle
            //// will be -Pi <= Result < Pi.

            XMVector result = XMVector.Subtract(v1, v2);

            XMVector mask = XMVector.Less(result, XMGlobalConstants.NegativePI);
            XMVector offset = XMVector.Select(XMGlobalConstants.Zero, XMGlobalConstants.TwoPI, mask);

            mask = XMVector.GreaterOrEqual(result, XMGlobalConstants.PI);
            offset = XMVector.Select(offset, XMGlobalConstants.NegativeTwoPI, mask);

            result = XMVector.Add(result, offset);

            return result;
        }

        /// <summary>
        /// Computes the per-component product of two vectors.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns a vector, each of whose components is the product of the corresponding components of V1 and V2.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Multiply(XMVector v1, XMVector v2)
        {
            return new XMVector(
                v1.x * v2.x,
                v1.y * v2.y,
                v1.z * v2.z,
                v1.w * v2.w);
        }

        /// <summary>
        /// Computes the product of the first two vectors added to the third vector.
        /// </summary>
        /// <param name="v1">The vector multiplier.</param>
        /// <param name="v2">The vector multiplicand.</param>
        /// <param name="v3">The vector addend.</param>
        /// <returns>Returns the product-sum of the vectors.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector MultiplyAdd(XMVector v1, XMVector v2, XMVector v3)
        {
            return new XMVector(
                (v1.x * v2.x) + v3.x,
                (v1.y * v2.y) + v3.y,
                (v1.z * v2.z) + v3.z,
                (v1.w * v2.w) + v3.w);
        }

        /// <summary>
        /// Divides one instance of XMVECTOR by a second instance, returning the result in a third instance.
        /// </summary>
        /// <param name="v1">The dividends.</param>
        /// <param name="v2">The divisors.</param>
        /// <returns>The quotient.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Divide(XMVector v1, XMVector v2)
        {
            XMVector result;
            result.x = v1.x / v2.x;
            result.y = v1.y / v2.y;
            result.z = v1.z / v2.z;
            result.w = v1.w / v2.w;

            return result;
        }

        /// <summary>
        /// Computes the difference of a third vector and the product of the first two vectors.
        /// </summary>
        /// <param name="v1">The vector multiplier.</param>
        /// <param name="v2">The vector multiplicand.</param>
        /// <param name="v3">The vector subtrahend.</param>
        /// <returns>Returns the resulting vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector NegativeMultiplySubtract(XMVector v1, XMVector v2, XMVector v3)
        {
            XMVector result;
            result.x = v3.x - (v1.x * v2.x);
            result.y = v3.y - (v1.y * v2.y);
            result.z = v3.z - (v1.z * v2.z);
            result.w = v3.w - (v1.w * v2.w);

            return result;
        }

        /// <summary>
        /// Computes V1 raised to the power of V2.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns a vector. Each component is the corresponding component of V1 raised to the power of the corresponding component in V2.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Pow(XMVector v1, XMVector v2)
        {
            XMVector result;
            result.x = (float)Math.Pow(v1.x, v2.x);
            result.y = (float)Math.Pow(v1.y, v2.y);
            result.z = (float)Math.Pow(v1.z, v2.z);
            result.w = (float)Math.Pow(v1.w, v2.w);

            return result;
        }

        /// <summary>
        /// Computes the per-component floating-point remainder of the quotient of two vectors.
        /// </summary>
        /// <param name="v1">The vector dividend.</param>
        /// <param name="v2">The vector divisor.</param>
        /// <returns>Returns a vector whose components are the floating-point remainders of the divisions.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Mod(XMVector v1, XMVector v2)
        {
            //// V1 % V2 = V1 - V2 * truncate(V1 / V2)

            XMVector quotient = XMVector
                .Divide(v1, v2)
                .Truncate();

            return XMVector.NegativeMultiplySubtract(v2, quotient, v1);
        }

        /// <summary>
        /// Computes the per-component angle modulo 2PI.
        /// </summary>
        /// <param name="angles">The vector of angle components.</param>
        /// <returns>Returns a vector whose components are the corresponding components of Angles modulo 2PI.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector ModAngles(XMVector angles)
        {
            // Modulo the range of the given angles such that -XM_PI <= Angles < XM_PI
            XMVector v = XMVector
                .Multiply(angles, XMGlobalConstants.ReciprocalTwoPI)
                .Round();

            return XMVector.NegativeMultiplySubtract(XMGlobalConstants.TwoPI, v, angles);
        }

        /// <summary>
        /// Computes the arctangent of Y/ X.
        /// </summary>
        /// <param name="y">The first vector.</param>
        /// <param name="x">The second vector.</param>
        /// <returns>Returns a vector. Each component is the arctangent of the corresponding Y component divided by the corresponding X component. Each component is in the range (-PI/2, PI/2).</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "y", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "x", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector ATan2(XMVector y, XMVector x)
        {
            // Return the inverse tangent of Y / X in the range of -Pi to Pi with the following exceptions:

            ////     Y == 0 and X is Negative         -> Pi with the sign of Y
            ////     y == 0 and x is positive         -> 0 with the sign of y
            ////     Y != 0 and X == 0                -> Pi / 2 with the sign of Y
            ////     Y != 0 and X is Negative         -> atan(y/x) + (PI with the sign of Y)
            ////     X == -Infinity and Finite Y      -> Pi with the sign of Y
            ////     X == +Infinity and Finite Y      -> 0 with the sign of Y
            ////     Y == Infinity and X is Finite    -> Pi / 2 with the sign of Y
            ////     Y == Infinity and X == -Infinity -> 3Pi / 4 with the sign of Y
            ////     Y == Infinity and X == +Infinity -> Pi / 4 with the sign of Y

            XMVector atan2Constants = XMVector.FromFloat(XMMath.PI, XMMath.PIDivTwo, XMMath.PIDivFour, XMMath.PI * 3.0f / 4.0f);
            XMVector zero = XMVector.Zero;
            XMVector atanResultValid = XMVector.TrueInt;
            XMVector pi = XMVector.SplatX(atan2Constants);
            XMVector onePIOverTwo = XMVector.SplatY(atan2Constants);
            XMVector onePIOverFour = XMVector.SplatZ(atan2Constants);
            XMVector threePIOverFour = XMVector.SplatW(atan2Constants);

            XMVector y_equalsZero = XMVector.Equal(y, zero);
            XMVector x_equalsZero = XMVector.Equal(x, zero);

            XMVector x_isPositive = XMVector.EqualInt(XMVector.AndInt(x, XMGlobalConstants.NegativeZero), zero);
            XMVector y_equalsInfinity = y.IsInfinite();
            XMVector x_equalsInfinity = x.IsInfinite();

            XMVector y_sign = XMVector.AndInt(y, XMGlobalConstants.NegativeZero);

            pi = XMVector.OrInt(pi, y_sign);
            onePIOverTwo = XMVector.OrInt(onePIOverTwo, y_sign);
            onePIOverFour = XMVector.OrInt(onePIOverFour, y_sign);
            threePIOverFour = XMVector.OrInt(threePIOverFour, y_sign);

            XMVector r1 = XMVector.Select(pi, y_sign, x_isPositive);
            XMVector r2 = XMVector.Select(atanResultValid, onePIOverTwo, x_equalsZero);
            XMVector r3 = XMVector.Select(r2, r1, y_equalsZero);
            XMVector r4 = XMVector.Select(threePIOverFour, onePIOverFour, x_isPositive);
            XMVector r5 = XMVector.Select(onePIOverTwo, r4, x_equalsInfinity);
            XMVector result = XMVector.Select(r3, r5, y_equalsInfinity);

            atanResultValid = XMVector.EqualInt(result, atanResultValid);

            XMVector v = XMVector.Divide(y, x);
            XMVector r0 = v.ATan();

            r1 = XMVector.Select(pi, XMGlobalConstants.NegativeZero, x_isPositive);
            r2 = XMVector.Add(r0, r1);

            return XMVector.Select(result, r2, atanResultValid);
        }

        /// <summary>
        /// Estimates the arctangent of Y/ X.
        /// </summary>
        /// <param name="y">The first vector.</param>
        /// <param name="x">The second vector.</param>
        /// <returns>Returns a vector. Each component is an estimate of the arctangent of the corresponding Y component divided by the corresponding X component. Each component is in the range (-PI/2, PI/2).</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "y", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "x", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector ATan2Est(XMVector y, XMVector x)
        {
            XMVector atan2Constants = XMVector.FromFloat(XMMath.PI, XMMath.PIDivTwo, XMMath.PIDivFour, 2.3561944905f /* Pi*3/4 */);
            XMVector zero = XMVector.Zero;
            XMVector atanResultValid = XMVector.TrueInt;

            XMVector pi = XMVector.SplatX(atan2Constants);
            XMVector onePIOverTwo = XMVector.SplatY(atan2Constants);
            XMVector onePIOverFour = XMVector.SplatZ(atan2Constants);
            XMVector threePIOverFour = XMVector.SplatW(atan2Constants);

            XMVector y_equalsZero = XMVector.Equal(y, zero);
            XMVector x_equalsZero = XMVector.Equal(x, zero);
            XMVector x_isPositive = XMVector.EqualInt(XMVector.AndInt(x, XMGlobalConstants.NegativeZero), zero);
            XMVector y_equalsInfinity = y.IsInfinite();
            XMVector x_equalsInfinity = x.IsInfinite();
            XMVector y_sign = XMVector.AndInt(y, XMGlobalConstants.NegativeZero);

            pi = XMVector.OrInt(pi, y_sign);
            onePIOverTwo = XMVector.OrInt(onePIOverTwo, y_sign);
            onePIOverFour = XMVector.OrInt(onePIOverFour, y_sign);
            threePIOverFour = XMVector.OrInt(threePIOverFour, y_sign);

            XMVector r1 = XMVector.Select(pi, y_sign, x_isPositive);
            XMVector r2 = XMVector.Select(atanResultValid, onePIOverTwo, x_equalsZero);
            XMVector r3 = XMVector.Select(r2, r1, y_equalsZero);
            XMVector r4 = XMVector.Select(threePIOverFour, onePIOverFour, x_isPositive);
            XMVector r5 = XMVector.Select(onePIOverTwo, r4, x_equalsInfinity);
            XMVector result = XMVector.Select(r3, r5, y_equalsInfinity);

            atanResultValid = XMVector.EqualInt(result, atanResultValid);

            XMVector reciprocal = x.ReciprocalEst();
            XMVector v = XMVector.Multiply(y, reciprocal);
            XMVector r0 = v.ATanEst();

            r1 = XMVector.Select(pi, XMGlobalConstants.NegativeZero, x_isPositive);
            r2 = XMVector.Add(r0, r1);

            return XMVector.Select(result, r2, atanResultValid);
        }

        /// <summary>
        /// Performs a linear interpolation between two vectors.
        /// </summary>
        /// <param name="v0">The first vector.</param>
        /// <param name="v1">The second vector.</param>
        /// <param name="t">The interpolation control factor.</param>
        /// <returns>Returns a vector containing the interpolation.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "t", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Lerp(XMVector v0, XMVector v1, float t)
        {
            //// V0 + t * (V1 - V0)

            XMVector scale = XMVector.Replicate(t);
            XMVector length = XMVector.Subtract(v1, v0);

            return XMVector.MultiplyAdd(length, scale, v0);
        }

        /// <summary>
        /// Performs a linear interpolation between two vectors.
        /// </summary>
        /// <param name="v0">The first vector.</param>
        /// <param name="v1">The second vector.</param>
        /// <param name="t">The interpolating control factor for the corresponding components of the position.</param>
        /// <returns>Returns a vector containing the interpolation.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "t", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector LerpV(XMVector v0, XMVector v1, XMVector t)
        {
            //// V0 + T * (V1 - V0)

            XMVector length = XMVector.Subtract(v1, v0);
            return XMVector.MultiplyAdd(length, t, v0);
        }

        /// <summary>
        /// Performs a Hermite spline interpolation, using the specified vectors.
        /// </summary>
        /// <param name="position0">First position to interpolate from.</param>
        /// <param name="tangent0">Tangent vector for the first position.</param>
        /// <param name="position1">Second position to interpolate from.</param>
        /// <param name="tangent1">Tangent vector for the second position.</param>
        /// <param name="t">Interpolation control factor.</param>
        /// <returns>Returns a vector containing the interpolation.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "t", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Hermite(
            XMVector position0,
            XMVector tangent0,
            XMVector position1,
            XMVector tangent1,
            float t)
        {
            //// Result = (2 * t^3 - 3 * t^2 + 1) * Position0 +
            ////          (t^3 - 2 * t^2 + t) * Tangent0 +
            ////          (-2 * t^3 + 3 * t^2) * Position1 +
            ////          (t^3 - t^2) * Tangent1

            float t2 = t * t;
            float t3 = t * t2;

            XMVector p0 = XMVector.Replicate((2.0f * t3) - (3.0f * t2) + 1.0f);
            XMVector t0 = XMVector.Replicate(t3 - (2.0f * t2) + t);
            XMVector p1 = XMVector.Replicate((-2.0f * t3) + (3.0f * t2));
            XMVector t1 = XMVector.Replicate(t3 - t2);

            XMVector result = XMVector.Multiply(p0, position0);
            result = XMVector.MultiplyAdd(t0, tangent0, result);
            result = XMVector.MultiplyAdd(p1, position1, result);
            result = XMVector.MultiplyAdd(t1, tangent1, result);

            return result;
        }

        /// <summary>
        /// Performs a Hermite spline interpolation, using the specified vectors.
        /// </summary>
        /// <param name="position0">First position to interpolate from.</param>
        /// <param name="tangent0">Tangent vector for the first position.</param>
        /// <param name="position1">Second position to interpolate from.</param>
        /// <param name="tangent1">Tangent vector for the second position.</param>
        /// <param name="t">Interpolating control factor for the corresponding components of the position.</param>
        /// <returns>Returns a vector containing the interpolation.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "t", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector HermiteV(
            XMVector position0,
            XMVector tangent0,
            XMVector position1,
            XMVector tangent1,
            XMVector t)
        {
            //// Result = (2 * t^3 - 3 * t^2 + 1) * Position0 +
            ////          (t^3 - 2 * t^2 + t) * Tangent0 +
            ////          (-2 * t^3 + 3 * t^2) * Position1 +
            ////          (t^3 - t^2) * Tangent1

            XMVector t2 = XMVector.Multiply(t, t);
            XMVector t3 = XMVector.Multiply(t, t2);

            XMVector p0 = XMVector.Replicate((2.0f * t3.x) - (3.0f * t2.x) + 1.0f);
            XMVector t0 = XMVector.Replicate(t3.y - (2.0f * t2.y) + t.y);
            XMVector p1 = XMVector.Replicate((-2.0f * t3.z) + (3.0f * t2.z));
            XMVector t1 = XMVector.Replicate(t3.w - t2.w);

            XMVector result = XMVector.Multiply(p0, position0);
            result = XMVector.MultiplyAdd(t0, tangent0, result);
            result = XMVector.MultiplyAdd(p1, position1, result);
            result = XMVector.MultiplyAdd(t1, tangent1, result);

            return result;
        }

        /// <summary>
        /// Performs a Catmull-Rom interpolation, using the specified position vectors.
        /// </summary>
        /// <param name="position0">The first position.</param>
        /// <param name="position1">The second position.</param>
        /// <param name="position2">The third position.</param>
        /// <param name="position3">The fourth position.</param>
        /// <param name="t">The interpolating control factor.</param>
        /// <returns>Returns the results of the Catmull-Rom interpolation.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "t", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector CatmullRom(
            XMVector position0,
            XMVector position1,
            XMVector position2,
            XMVector position3,
            float t)
        {
            //// Result = ((-t^3 + 2 * t^2 - t) * Position0 +
            ////           (3 * t^3 - 5 * t^2 + 2) * Position1 +
            ////           (-3 * t^3 + 4 * t^2 + t) * Position2 +
            ////           (t^3 - t^2) * Position3) * 0.5

            float t2 = t * t;
            float t3 = t * t2;

            XMVector p0 = XMVector.Replicate((-t3 + (2.0f * t2) - t) * 0.5f);
            XMVector p1 = XMVector.Replicate(((3.0f * t3) - (5.0f * t2) + 2.0f) * 0.5f);
            XMVector p2 = XMVector.Replicate(((-3.0f * t3) + (4.0f * t2) + t) * 0.5f);
            XMVector p3 = XMVector.Replicate((t3 - t2) * 0.5f);

            XMVector result = XMVector.Multiply(p0, position0);
            result = XMVector.MultiplyAdd(p1, position1, result);
            result = XMVector.MultiplyAdd(p2, position2, result);
            result = XMVector.MultiplyAdd(p3, position3, result);

            return result;
        }

        /// <summary>
        /// Performs a Catmull-Rom interpolation, using the specified position vectors.
        /// </summary>
        /// <param name="position0">The first position.</param>
        /// <param name="position1">The second position.</param>
        /// <param name="position2">The third position.</param>
        /// <param name="position3">The fourth position.</param>
        /// <param name="t">The interpolating control factor for the corresponding components of the position.</param>
        /// <returns>Returns the results of the Catmull-Rom interpolation.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "t", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector CatmullRomV(
            XMVector position0,
            XMVector position1,
            XMVector position2,
            XMVector position3,
            XMVector t)
        {
            float fx = t.x;
            float fy = t.y;
            float fz = t.z;
            float fw = t.w;

            XMVector result;

            result.x = 0.5f * (
                (((-fx * fx * fx) + (2 * fx * fx) - fx) * position0.x)
                + (((3 * fx * fx * fx) - (5 * fx * fx) + 2) * position1.x)
                + (((-3 * fx * fx * fx) + (4 * fx * fx) + fx) * position2.x)
                + (((fx * fx * fx) - (fx * fx)) * position3.x));

            result.y = 0.5f * (
                (((-fy * fy * fy) + (2 * fy * fy) - fy) * position0.y)
                + (((3 * fy * fy * fy) - (5 * fy * fy) + 2) * position1.y)
                + (((-3 * fy * fy * fy) + (4 * fy * fy) + fy) * position2.y)
                + (((fy * fy * fy) - (fy * fy)) * position3.y));

            result.z = 0.5f * (
                (((-fz * fz * fz) + (2 * fz * fz) - fz) * position0.z)
                + (((3 * fz * fz * fz) - (5 * fz * fz) + 2) * position1.z)
                + (((-3 * fz * fz * fz) + (4 * fz * fz) + fz) * position2.z)
                + (((fz * fz * fz) - (fz * fz)) * position2.z));

            result.w = 0.5f * (
                (((-fw * fw * fw) + (2 * fw * fw) - fw) * position0.w)
                + (((3 * fw * fw * fw) - (5 * fw * fw) + 2) * position1.w)
                + (((-3 * fw * fw * fw) + (4 * fw * fw) + fw) * position2.w)
                + (((fw * fw * fw) - (fw * fw)) * position3.w));

            return result;
        }

        /// <summary>
        /// Returns a point in Barycentric coordinates, using the specified position vectors.
        /// </summary>
        /// <param name="position0">The first position.</param>
        /// <param name="position1">The second position.</param>
        /// <param name="position2">The third position.</param>
        /// <param name="f">The first weighting factor.</param>
        /// <param name="g">The second weighting factor.</param>
        /// <returns>Returns the Barycentric coordinates.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "f", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "g", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector BaryCentric(
            XMVector position0,
            XMVector position1,
            XMVector position2,
            float f,
            float g)
        {
            //// Result = Position0 + f * (Position1 - Position0) + g * (Position2 - Position0)

            XMVector p10 = XMVector.Subtract(position1, position0);
            XMVector scaleF = XMVector.Replicate(f);

            XMVector p20 = XMVector.Subtract(position2, position0);
            XMVector scaleG = XMVector.Replicate(g);

            XMVector result = XMVector.MultiplyAdd(p10, scaleF, position0);
            result = XMVector.MultiplyAdd(p20, scaleG, result);

            return result;
        }

        /// <summary>
        /// Returns a point in Barycentric coordinates, using the specified position vectors.
        /// </summary>
        /// <param name="position0">The first position.</param>
        /// <param name="position1">The second position.</param>
        /// <param name="position2">The third position.</param>
        /// <param name="f">The first weighting factors.</param>
        /// <param name="g">The second weighting factors.</param>
        /// <returns>Returns the Barycentric coordinates.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "f", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "g", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector BaryCentricV(
            XMVector position0,
            XMVector position1,
            XMVector position2,
            XMVector f,
            XMVector g)
        {
            //// Result = Position0 + f * (Position1 - Position0) + g * (Position2 - Position0)

            XMVector p10 = XMVector.Subtract(position1, position0);
            XMVector p20 = XMVector.Subtract(position2, position0);

            XMVector result = XMVector.MultiplyAdd(p10, f, position0);
            result = XMVector.MultiplyAdd(p20, g, result);

            return result;
        }

        /// <summary>
        /// Loads an <see cref="XMColorRgba"/> into an <see cref="XMVector"/>.
        /// </summary>
        /// <param name="value">The structure to load.</param>
        /// <returns>Returns a vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Load(XMColorRgba value)
        {
            return value;
        }

        /// <summary>
        /// Loads an <see cref="XMHalf2"/> into an <see cref="XMVector"/>.
        /// </summary>
        /// <param name="value">The structure to load.</param>
        /// <returns>Returns a vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Load(XMHalf2 value)
        {
            return value;
        }

        /// <summary>
        /// Loads an <see cref="XMShortN2"/> into an <see cref="XMVector"/>.
        /// </summary>
        /// <param name="value">The structure to load.</param>
        /// <returns>Returns a vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Load(XMShortN2 value)
        {
            return value;
        }

        /// <summary>
        /// Loads an <see cref="XMShort2"/> into an <see cref="XMVector"/>.
        /// </summary>
        /// <param name="value">The structure to load.</param>
        /// <returns>Returns a vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Load(XMShort2 value)
        {
            return value;
        }

        /// <summary>
        /// Loads an <see cref="XMUShortN2"/> into an <see cref="XMVector"/>.
        /// </summary>
        /// <param name="value">The structure to load.</param>
        /// <returns>Returns a vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Load(XMUShortN2 value)
        {
            return value;
        }

        /// <summary>
        /// Loads an <see cref="XMUShort2"/> into an <see cref="XMVector"/>.
        /// </summary>
        /// <param name="value">The structure to load.</param>
        /// <returns>Returns a vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Load(XMUShort2 value)
        {
            return value;
        }

        /// <summary>
        /// Loads an <see cref="XMByteN2"/> into an <see cref="XMVector"/>.
        /// </summary>
        /// <param name="value">The structure to load.</param>
        /// <returns>Returns a vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Load(XMByteN2 value)
        {
            return value;
        }

        /// <summary>
        /// Loads an <see cref="XMByte2"/> into an <see cref="XMVector"/>.
        /// </summary>
        /// <param name="value">The structure to load.</param>
        /// <returns>Returns a vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Load(XMByte2 value)
        {
            return value;
        }

        /// <summary>
        /// Loads an <see cref="XMUByteN2"/> into an <see cref="XMVector"/>.
        /// </summary>
        /// <param name="value">The structure to load.</param>
        /// <returns>Returns a vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Load(XMUByteN2 value)
        {
            return value;
        }

        /// <summary>
        /// Loads an <see cref="XMUByte2"/> into an <see cref="XMVector"/>.
        /// </summary>
        /// <param name="value">The structure to load.</param>
        /// <returns>Returns a vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Load(XMUByte2 value)
        {
            return value;
        }

        /// <summary>
        /// Loads an <see cref="XMU565"/> into an <see cref="XMVector"/>.
        /// </summary>
        /// <param name="value">The structure to load.</param>
        /// <returns>Returns a vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Load(XMU565 value)
        {
            return value;
        }

        /// <summary>
        /// Loads an <see cref="XMFloat3Packed"/> into an <see cref="XMVector"/>.
        /// </summary>
        /// <param name="value">The structure to load.</param>
        /// <returns>Returns a vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Load(XMFloat3Packed value)
        {
            return value;
        }

        /// <summary>
        /// Loads an <see cref="XMFloat3SharedExponent"/> into an <see cref="XMVector"/>.
        /// </summary>
        /// <param name="value">The structure to load.</param>
        /// <returns>Returns a vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Load(XMFloat3SharedExponent value)
        {
            return value;
        }

        /// <summary>
        /// Loads an <see cref="XMHalf4"/> into an <see cref="XMVector"/>.
        /// </summary>
        /// <param name="value">The structure to load.</param>
        /// <returns>Returns a vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Load(XMHalf4 value)
        {
            return value;
        }

        /// <summary>
        /// Loads an <see cref="XMShortN4"/> into an <see cref="XMVector"/>.
        /// </summary>
        /// <param name="value">The structure to load.</param>
        /// <returns>Returns a vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Load(XMShortN4 value)
        {
            return value;
        }

        /// <summary>
        /// Loads an <see cref="XMShort4"/> into an <see cref="XMVector"/>.
        /// </summary>
        /// <param name="value">The structure to load.</param>
        /// <returns>Returns a vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Load(XMShort4 value)
        {
            return value;
        }

        /// <summary>
        /// Loads an <see cref="XMUShortN4"/> into an <see cref="XMVector"/>.
        /// </summary>
        /// <param name="value">The structure to load.</param>
        /// <returns>Returns a vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Load(XMUShortN4 value)
        {
            return value;
        }

        /// <summary>
        /// Loads an <see cref="XMUShort4"/> into an <see cref="XMVector"/>.
        /// </summary>
        /// <param name="value">The structure to load.</param>
        /// <returns>Returns a vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Load(XMUShort4 value)
        {
            return value;
        }

        /// <summary>
        /// Loads an <see cref="XMXDecN4"/> into an <see cref="XMVector"/>.
        /// </summary>
        /// <param name="value">The structure to load.</param>
        /// <returns>Returns a vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Load(XMXDecN4 value)
        {
            return value;
        }

        /// <summary>
        /// Loads an <see cref="XMXDec4"/> into an <see cref="XMVector"/>.
        /// </summary>
        /// <param name="value">The structure to load.</param>
        /// <returns>Returns a vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Load(XMXDec4 value)
        {
            return value;
        }

        /// <summary>
        /// Loads an <see cref="XMDecN4"/> into an <see cref="XMVector"/>.
        /// </summary>
        /// <param name="value">The structure to load.</param>
        /// <returns>Returns a vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Load(XMDecN4 value)
        {
            return value;
        }

        /// <summary>
        /// Loads an <see cref="XMDec4"/> into an <see cref="XMVector"/>.
        /// </summary>
        /// <param name="value">The structure to load.</param>
        /// <returns>Returns a vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Load(XMDec4 value)
        {
            return value;
        }

        /// <summary>
        /// Loads an <see cref="XMUDecN4"/> into an <see cref="XMVector"/>.
        /// </summary>
        /// <param name="value">The structure to load.</param>
        /// <returns>Returns a vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Load(XMUDecN4 value)
        {
            return value;
        }

        /// <summary>
        /// Loads an <see cref="XMUDecN4XR"/> into an <see cref="XMVector"/>.
        /// </summary>
        /// <param name="value">The structure to load.</param>
        /// <returns>Returns a vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Load(XMUDecN4XR value)
        {
            return value;
        }

        /// <summary>
        /// Loads an <see cref="XMUDec4"/> into an <see cref="XMVector"/>.
        /// </summary>
        /// <param name="value">The structure to load.</param>
        /// <returns>Returns a vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Load(XMUDec4 value)
        {
            return value;
        }

        /// <summary>
        /// Loads an <see cref="XMByteN4"/> into an <see cref="XMVector"/>.
        /// </summary>
        /// <param name="value">The structure to load.</param>
        /// <returns>Returns a vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Load(XMByteN4 value)
        {
            return value;
        }

        /// <summary>
        /// Loads an <see cref="XMByte4"/> into an <see cref="XMVector"/>.
        /// </summary>
        /// <param name="value">The structure to load.</param>
        /// <returns>Returns a vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Load(XMByte4 value)
        {
            return value;
        }

        /// <summary>
        /// Loads an <see cref="XMUByteN4"/> into an <see cref="XMVector"/>.
        /// </summary>
        /// <param name="value">The structure to load.</param>
        /// <returns>Returns a vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Load(XMUByteN4 value)
        {
            return value;
        }

        /// <summary>
        /// Loads an <see cref="XMUByte4"/> into an <see cref="XMVector"/>.
        /// </summary>
        /// <param name="value">The structure to load.</param>
        /// <returns>Returns a vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Load(XMUByte4 value)
        {
            return value;
        }

        /// <summary>
        /// Loads an <see cref="XMUNibble4"/> into an <see cref="XMVector"/>.
        /// </summary>
        /// <param name="value">The structure to load.</param>
        /// <returns>Returns a vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Load(XMUNibble4 value)
        {
            return value;
        }

        /// <summary>
        /// Loads an <see cref="XMU555"/> into an <see cref="XMVector"/>.
        /// </summary>
        /// <param name="value">The structure to load.</param>
        /// <returns>Returns a vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMVector Load(XMU555 value)
        {
            return value;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public override bool Equals(object? obj)
        {
            if (!(obj is XMVector))
            {
                return false;
            }

            return this.Equals((XMVector)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(XMVector other)
        {
            return this.x == other.x
                && this.y == other.y
                && this.z == other.z
                && this.w == other.w;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.x,
                this.y,
                this.z,
                this.w
            }
            .GetHashCode();
        }

        /// <summary>
        /// Convert a vector to an array of float.
        /// </summary>
        /// <returns>An array of float.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float[] ToArray()
        {
            return new float[] { this.x, this.y, this.z, this.w };
        }

        /// <summary>
        /// Gets the value of one component by index.
        /// </summary>
        /// <param name="index">The index of the component.</param>
        /// <returns>The component.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float GetByIndex(int index)
        {
            if (index < 0 || index >= 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            fixed (XMVector* v = &this)
            {
                return ((float*)v)[index];
            }
        }

        /// <summary>
        /// Sets the value of one component by index.
        /// </summary>
        /// <param name="value">The value of the component.</param>
        /// <param name="index">The index of the component.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetByIndex(float value, int index)
        {
            if (index < 0 || index >= 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            fixed (XMVector* v = &this)
            {
                ((float*)v)[index] = value;
            }
        }

        /// <summary>
        /// Gets the value of one component by index.
        /// </summary>
        /// <param name="index">The index of the component.</param>
        /// <returns>The component.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "int", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint GetIntByIndex(int index)
        {
            if (index < 0 || index >= 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            fixed (XMVector* v = &this)
            {
                return ((uint*)v)[index];
            }
        }

        /// <summary>
        /// Sets the value of one component by index.
        /// </summary>
        /// <param name="value">The value of the component.</param>
        /// <param name="index">The index of the component.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetIntByIndex(uint value, int index)
        {
            if (index < 0 || index >= 4)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            fixed (XMVector* v = &this)
            {
                ((uint*)v)[index] = value;
            }
        }

        /// <summary>
        /// Converts an <see cref="XMVector"/> with <c>int</c> components to an <see cref="XMVector"/> with <c>float</c> components and applies a uniform bias.
        /// </summary>
        /// <param name="divExponent">Each component of the vector will be converted to a float and then divided by two raised to the <paramref name="divExponent"/> power.</param>
        /// <returns>Returns the converted vector, where each component has been divided by two raised to the <paramref name="divExponent"/> power.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector ConvertIntToFloat(uint divExponent)
        {
            if (divExponent >= 32)
            {
                throw new ArgumentOutOfRangeException(nameof(divExponent));
            }

            float scale = 1.0f / (float)(1U << (int)divExponent);

            fixed (XMVector* v = &this)
            {
                XMVector result;

                result.x = ((int*)v)[0] * scale;
                result.y = ((int*)v)[1] * scale;
                result.z = ((int*)v)[2] * scale;
                result.w = ((int*)v)[3] * scale;

                return result;
            }
        }

        /// <summary>
        /// Converts an <see cref="XMVector"/> with <c>float</c> components to an <see cref="XMVector"/> with <c>int</c> components and applies a uniform bias.
        /// </summary>
        /// <param name="mulExponent">Each component of the vector will be converted to a <c>int</c> and then multiplied by two raised to the <paramref name="mulExponent"/> power.</param>
        /// <returns>Returns the converted vector, where each component has been multiplied by two raised to the <paramref name="mulExponent"/> power.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector ConvertFloatToInt(uint mulExponent)
        {
            if (mulExponent >= 32)
            {
                throw new ArgumentOutOfRangeException(nameof(mulExponent));
            }

            float scale = (float)(1U << (int)mulExponent);

            XMVector result;

            float tempX = this.x * scale;
            ((int*)&result)[0] = (tempX <= -(65536.0f * 32768.0f)) ?
                ((-0x7FFFFFFF) - 1) :
                (tempX > (65536.0f * 32768.0f) - 128.0f) ?
                0x7FFFFFFF :
                (int)tempX;

            float tempY = this.y * scale;
            ((int*)&result)[1] = (tempY <= -(65536.0f * 32768.0f)) ?
                ((-0x7FFFFFFF) - 1) :
                (tempY > (65536.0f * 32768.0f) - 128.0f) ?
                0x7FFFFFFF :
                (int)tempY;

            float tempZ = this.z * scale;
            ((int*)&result)[2] = (tempZ <= -(65536.0f * 32768.0f)) ?
                ((-0x7FFFFFFF) - 1) :
                (tempZ > (65536.0f * 32768.0f) - 128.0f) ?
                0x7FFFFFFF :
                (int)tempZ;

            float tempW = this.w * scale;
            ((int*)&result)[3] = (tempW <= -(65536.0f * 32768.0f)) ?
                ((-0x7FFFFFFF) - 1) :
                (tempW > (65536.0f * 32768.0f) - 128.0f) ?
                0x7FFFFFFF :
                (int)tempW;

            return result;
        }

        /// <summary>
        /// Converts an <see cref="XMVector"/> with <c>uint</c> components to an <see cref="XMVector"/> with <c>float</c> components and applies a uniform bias.
        /// </summary>
        /// <param name="divExponent">Each component of the vector will be converted to a <c>float</c> and then divided by two raised to the <paramref name="divExponent"/> power.</param>
        /// <returns>Returns the converted vector, where each component has been divided by two raised to the <paramref name="divExponent"/> power.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector ConvertUIntToFloat(uint divExponent)
        {
            if (divExponent >= 32)
            {
                throw new ArgumentOutOfRangeException(nameof(divExponent));
            }

            float scale = 1.0f / (float)(1U << (int)divExponent);

            fixed (XMVector* v = &this)
            {
                XMVector result;

                result.x = ((uint*)v)[0] * scale;
                result.y = ((uint*)v)[1] * scale;
                result.z = ((uint*)v)[2] * scale;
                result.w = ((uint*)v)[3] * scale;

                return result;
            }
        }

        /// <summary>
        /// Converts an <see cref="XMVector"/> with <c>float</c> components to an <see cref="XMVector"/> with <c>uint</c> components and applies a uniform bias.
        /// </summary>
        /// <param name="mulExponent">Each component of the vector will be converted to a <c>int</c> and then multiplied by two raised to the <paramref name="mulExponent"/> power.</param>
        /// <returns>Returns the converted vector, where each component has been multiplied by two raised to the <paramref name="mulExponent"/> power.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector ConvertFloatToUInt(uint mulExponent)
        {
            if (mulExponent >= 32)
            {
                throw new ArgumentOutOfRangeException(nameof(mulExponent));
            }

            float scale = (float)(1U << (int)mulExponent);

            XMVector result;

            float tempX = this.x * scale;
            ((uint*)&result)[0] = (tempX <= 0.0f) ? 0 : (tempX >= (65536.0f * 65536.0f)) ? 0xFFFFFFFFU : (uint)tempX;

            float tempY = this.y * scale;
            ((uint*)&result)[1] = (tempY <= 0.0f) ? 0 : (tempY >= (65536.0f * 65536.0f)) ? 0xFFFFFFFFU : (uint)tempY;

            float tempZ = this.x * scale;
            ((uint*)&result)[2] = (tempZ <= 0.0f) ? 0 : (tempZ >= (65536.0f * 65536.0f)) ? 0xFFFFFFFFU : (uint)tempZ;

            float tempW = this.x * scale;
            ((uint*)&result)[3] = (tempW <= 0.0f) ? 0 : (tempW >= (65536.0f * 65536.0f)) ? 0xFFFFFFFFU : (uint)tempW;

            return result;
        }

        /// <summary>
        /// Stores an <see cref="XMVector"/> in a <c>uint</c>.
        /// </summary>
        /// <param name="destination">The data.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void StoreInt(out uint destination)
        {
            destination = this.IntX;
        }

        /// <summary>
        /// Stores an <see cref="XMVector"/> in a float.
        /// </summary>
        /// <param name="destination">The data.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void StoreFloat(out float destination)
        {
            destination = this.x;
        }

        /// <summary>
        /// Stores an <see cref="XMVector"/> in a 2-element <c>uint</c> array.
        /// </summary>
        /// <param name="destination">The data.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void StoreInt2(out uint[] destination)
        {
            destination = new uint[] { this.IntX, this.IntY };
        }

        /// <summary>
        /// Stores an <see cref="XMVector"/> in an <see cref="XMFloat2"/>.
        /// </summary>
        /// <param name="destination">The data</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void StoreFloat2(out XMFloat2 destination)
        {
            destination = new XMFloat2(this.x, this.y);
        }

        /// <summary>
        /// Stores an <see cref="XMVector"/> in an <see cref="XMInt2"/>.
        /// </summary>
        /// <param name="destination">The data</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void StoreSInt2(out XMInt2 destination)
        {
            destination = new XMInt2((int)this.x, (int)this.y);
        }

        /// <summary>
        /// Stores an <see cref="XMVector"/> in an <see cref="XMUInt2"/>.
        /// </summary>
        /// <param name="destination">The data</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void StoreUInt2(out XMUInt2 destination)
        {
            destination = new XMUInt2((uint)this.x, (uint)this.y);
        }

        /// <summary>
        /// Stores an <see cref="XMVector"/> in a 3-element <c>uint</c> array.
        /// </summary>
        /// <param name="destination">The data.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void StoreInt3(out uint[] destination)
        {
            destination = new uint[] { this.IntX, this.IntY, this.IntZ };
        }

        /// <summary>
        /// Stores an <see cref="XMVector"/> in an <see cref="XMFloat3"/>.
        /// </summary>
        /// <param name="destination">The data</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void StoreFloat3(out XMFloat3 destination)
        {
            destination = new XMFloat3(this.x, this.y, this.z);
        }

        /// <summary>
        /// Stores an <see cref="XMVector"/> in an <see cref="XMInt3"/>.
        /// </summary>
        /// <param name="destination">The data</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void StoreSInt3(out XMInt3 destination)
        {
            destination = new XMInt3((int)this.x, (int)this.y, (int)this.z);
        }

        /// <summary>
        /// Stores an <see cref="XMVector"/> in an <see cref="XMUInt3"/>.
        /// </summary>
        /// <param name="destination">The data</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void StoreUInt3(out XMUInt3 destination)
        {
            destination = new XMUInt3((uint)this.x, (uint)this.y, (uint)this.z);
        }

        /// <summary>
        /// Stores an <see cref="XMVector"/> in a 4-element <c>uint</c> array.
        /// </summary>
        /// <param name="destination">The data.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void StoreInt4(out uint[] destination)
        {
            destination = new uint[] { this.IntX, this.IntY, this.IntZ, this.IntW };
        }

        /// <summary>
        /// Stores an <see cref="XMVector"/> in an <see cref="XMFloat4"/>.
        /// </summary>
        /// <param name="destination">The data</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void StoreFloat4(out XMFloat4 destination)
        {
            destination = new XMFloat4(this.x, this.y, this.z, this.w);
        }

        /// <summary>
        /// Stores an <see cref="XMVector"/> in an <see cref="XMInt4"/>.
        /// </summary>
        /// <param name="destination">The data</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void StoreSInt4(out XMInt4 destination)
        {
            destination = new XMInt4((int)this.x, (int)this.y, (int)this.z, (int)this.w);
        }

        /// <summary>
        /// Stores an <see cref="XMVector"/> in an <see cref="XMUInt4"/>.
        /// </summary>
        /// <param name="destination">The data</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void StoreUInt4(out XMUInt4 destination)
        {
            destination = new XMUInt4((uint)this.x, (uint)this.y, (uint)this.z, (uint)this.w);
        }

        /// <summary>
        /// Swizzles a vector.
        /// </summary>
        /// <param name="e0">Index that describes which component of V to place in the x-component of the swizzled vector.</param>
        /// <param name="e1">Index that describes which component of V to place in the y-component of the swizzled vector.</param>
        /// <param name="e2">Index that describes which component of V to place in the z-component of the swizzled vector.</param>
        /// <param name="e3">Index that describes which component of V to place in the w-component of the swizzled vector.</param>
        /// <returns>Returns the swizzled vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector Swizzle(XMSwizzle e0, XMSwizzle e1, XMSwizzle e2, XMSwizzle e3)
        {
            if ((uint)e0 >= 4)
            {
                throw new ArgumentOutOfRangeException(nameof(e0));
            }

            if ((uint)e1 >= 4)
            {
                throw new ArgumentOutOfRangeException(nameof(e1));
            }

            if ((uint)e2 >= 4)
            {
                throw new ArgumentOutOfRangeException(nameof(e2));
            }

            if ((uint)e3 >= 4)
            {
                throw new ArgumentOutOfRangeException(nameof(e3));
            }

            return new XMVector(this[(int)e0], this[(int)e1], this[(int)e2], this[(int)e3]);
        }

        /// <summary>
        /// Swizzles a vector.
        /// </summary>
        /// <param name="elements">The swizzle indexes.</param>
        /// <returns>Returns the swizzled vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector Swizzle(XMSwizzle[]? elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException(nameof(elements));
            }

            if (elements.Length != 4)
            {
                throw new ArgumentOutOfRangeException(nameof(elements));
            }

            return new XMVector(this[(int)elements[0]], this[(int)elements[1]], this[(int)elements[2]], this[(int)elements[3]]);
        }

        /// <summary>
        /// Rotates the vector left by a given number of 32-bit elements.
        /// </summary>
        /// <param name="elements">Number of 32-bit elements by which to rotate V left. This parameter must be 0, 1, 2, or 3.</param>
        /// <returns>Returns the rotated vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector RotateLeft(uint elements)
        {
            if (elements >= 4)
            {
                throw new ArgumentOutOfRangeException(nameof(elements));
            }

            return this.Swizzle(
                (XMSwizzle)(elements & 3U),
                (XMSwizzle)((elements + 1U) & 3U),
                (XMSwizzle)((elements + 2U) & 3U),
                (XMSwizzle)((elements + 3U) & 3U));
        }

        /// <summary>
        /// Rotates the vector right by a given number of 32-bit elements.
        /// </summary>
        /// <param name="elements">Number of 32-bit elements by which to rotate V right. This parameter must be 0, 1, 2, or 3.</param>
        /// <returns>Returns the rotated  vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector RotateRight(uint elements)
        {
            if (elements >= 4)
            {
                throw new ArgumentOutOfRangeException(nameof(elements));
            }

            return this.Swizzle(
                (XMSwizzle)((4U - elements) & 3U),
                (XMSwizzle)((5U - elements) & 3U),
                (XMSwizzle)((6U - elements) & 3U),
                (XMSwizzle)((7U - elements) & 3U));
        }

        /// <summary>
        /// Tests whether the components of a given vector are within set bounds.
        /// </summary>
        /// <param name="bounds">Vector that determines the bounds.</param>
        /// <returns>Returns a vector containing the results of each component test.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector InBounds(XMVector bounds)
        {
            XMVector control;
            ((uint*)&control)[0] = (this.x <= bounds.x && this.x >= -bounds.x) ? 0xFFFFFFFF : 0U;
            ((uint*)&control)[1] = (this.y <= bounds.y && this.y >= -bounds.y) ? 0xFFFFFFFF : 0U;
            ((uint*)&control)[2] = (this.z <= bounds.z && this.z >= -bounds.z) ? 0xFFFFFFFF : 0U;
            ((uint*)&control)[3] = (this.w <= bounds.w && this.w >= -bounds.w) ? 0xFFFFFFFF : 0U;

            return control;
        }

        /// <summary>
        /// Tests whether the components of a given vector are within certain bounds and sets a comparison value.
        /// </summary>
        /// <param name="record">A comparison value.</param>
        /// <param name="bounds">Vector that determines the bounds.</param>
        /// <returns>Returns a vector containing the results of each component test.</returns>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector InBoundsR(out XMComparisonRecord record, XMVector bounds)
        {
            uint ux = (this.x <= bounds.x && this.x >= -bounds.x) ? 0xFFFFFFFF : 0U;
            uint uy = (this.y <= bounds.y && this.y >= -bounds.y) ? 0xFFFFFFFF : 0U;
            uint uz = (this.z <= bounds.z && this.z >= -bounds.z) ? 0xFFFFFFFF : 0U;
            uint uw = (this.w <= bounds.w && this.w >= -bounds.w) ? 0xFFFFFFFF : 0U;

            uint cr = 0U;

            if ((ux & uy & uz & uw) != 0U)
            {
                // All elements are in bounds
                cr = XMComparisonRecord.MaskBounds;
            }

            record = new XMComparisonRecord(cr);

            return XMVector.FromInt(ux, uy, uz, uw);
        }

        /// <summary>
        /// Performs a per-component NaN test on a vector.
        /// </summary>
        /// <returns>Returns a vector containing the results of each component test.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector IsNaN()
        {
            XMVector control;
            ((uint*)&control)[0] = XMVector.IsNaN(this.x) ? 0xFFFFFFFFU : 0U;
            ((uint*)&control)[1] = XMVector.IsNaN(this.y) ? 0xFFFFFFFFU : 0U;
            ((uint*)&control)[2] = XMVector.IsNaN(this.z) ? 0xFFFFFFFFU : 0U;
            ((uint*)&control)[3] = XMVector.IsNaN(this.w) ? 0xFFFFFFFFU : 0U;

            return control;
        }

        /// <summary>
        /// Performs a per-component test for +/- infinity on a vector.
        /// </summary>
        /// <returns>Returns a vector containing the results of each component test.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector IsInfinite()
        {
            XMVector control;
            ((uint*)&control)[0] = XMVector.IsInfinite(this.x) ? 0xFFFFFFFFU : 0U;
            ((uint*)&control)[1] = XMVector.IsInfinite(this.y) ? 0xFFFFFFFFU : 0U;
            ((uint*)&control)[2] = XMVector.IsInfinite(this.z) ? 0xFFFFFFFFU : 0U;
            ((uint*)&control)[3] = XMVector.IsInfinite(this.w) ? 0xFFFFFFFFU : 0U;

            return control;
        }

        /// <summary>
        /// Rounds each component of a vector to the nearest integer.
        /// </summary>
        /// <returns>Returns a vector, each of whose components are rounded to the nearest integer.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector Round()
        {
            return new XMVector(
                XMVector.RoundToNearest(this.x),
                XMVector.RoundToNearest(this.y),
                XMVector.RoundToNearest(this.z),
                XMVector.RoundToNearest(this.w));
        }

        /// <summary>
        /// Rounds each component of a vector to the nearest integer value in the direction of zero.
        /// </summary>
        /// <returns>Returns a vector whose components are rounded to the nearest integer value in the direction of zero.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector Truncate()
        {
            XMVector result;

            if (XMVector.IsNaN(this.x))
            {
                ((uint*)&result)[0] = 0x7FC00000U;
            }
            else if (Math.Abs(this.x) < 8388608.0f)
            {
                result.x = (int)this.x;
            }
            else
            {
                result.x = this.x;
            }

            if (XMVector.IsNaN(this.y))
            {
                ((uint*)&result)[1] = 0x7FC00000U;
            }
            else if (Math.Abs(this.y) < 8388608.0f)
            {
                result.y = (int)this.y;
            }
            else
            {
                result.y = this.y;
            }

            if (XMVector.IsNaN(this.z))
            {
                ((uint*)&result)[2] = 0x7FC00000U;
            }
            else if (Math.Abs(this.z) < 8388608.0f)
            {
                result.z = (int)this.z;
            }
            else
            {
                result.z = this.z;
            }

            if (XMVector.IsNaN(this.w))
            {
                ((uint*)&result)[3] = 0x7FC00000U;
            }
            else if (Math.Abs(this.w) < 8388608.0f)
            {
                result.w = (int)this.w;
            }
            else
            {
                result.w = this.w;
            }

            return result;
        }

        /// <summary>
        /// Computes the floor of each component of a vector.
        /// </summary>
        /// <returns>Returns a vector whose components are the floor of the corresponding components of V.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector Floor()
        {
            return new XMVector(
                (float)Math.Floor(this.x),
                (float)Math.Floor(this.y),
                (float)Math.Floor(this.z),
                (float)Math.Floor(this.w));
        }

        /// <summary>
        /// Computes the ceiling of each component of a vector.
        /// </summary>
        /// <returns>Returns a vector whose components are the ceiling of the corresponding components of V.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector Ceiling()
        {
            return new XMVector(
                (float)Math.Ceiling(this.x),
                (float)Math.Ceiling(this.y),
                (float)Math.Ceiling(this.z),
                (float)Math.Ceiling(this.w));
        }

        /// <summary>
        /// Clamps the components of a vector to a specified minimum and maximum range.
        /// </summary>
        /// <param name="min">Minimum range vector.</param>
        /// <param name="max">Maximum range vector.</param>
        /// <returns>Returns a vector whose components are clamped to the specified minimum and maximum values.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector Clamp(XMVector min, XMVector max)
        {
            XMVector result;
            result = XMVector.Max(min, this);
            result = XMVector.Min(max, result);
            return result;
        }

        /// <summary>
        /// Saturates each component of a vector to the range 0.0f to 1.0f.
        /// </summary>
        /// <returns>Returns a vector, each of whose components are saturated.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector Saturate()
        {
            return this.Clamp(XMGlobalConstants.Zero, XMGlobalConstants.One);
        }

        /// <summary>
        /// Performance an identity operation on a vector.
        /// </summary>
        /// <returns>Returns the vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector Plus()
        {
            return this;
        }

        /// <summary>
        /// Computes the negation of a vector.
        /// </summary>
        /// <returns>Returns the negation of the vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector Negate()
        {
            XMVector result;
            result.x = -this.x;
            result.y = -this.y;
            result.z = -this.z;
            result.w = -this.w;

            return result;
        }

        /// <summary>
        /// Scalar multiplies a vector by a floating-point value.
        /// </summary>
        /// <param name="factor">A scalar value.</param>
        /// <returns>Returns the scaled vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector Scale(float factor)
        {
            return new XMVector(this.x * factor, this.y * factor, this.z * factor, this.w * factor);
        }

        /// <summary>
        /// Estimates the per-component reciprocal of a vector.
        /// </summary>
        /// <returns>Returns a vector. Each component is an estimate of the reciprocal of the corresponding component of V.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector ReciprocalEst()
        {
            XMVector result;
            result.x = 1.0f / this.x;
            result.y = 1.0f / this.y;
            result.z = 1.0f / this.z;
            result.w = 1.0f / this.w;

            return result;
        }

        /// <summary>
        /// Computes the per-component reciprocal of a vector.
        /// </summary>
        /// <returns>Returns a vector. Each component is the reciprocal of the corresponding component of V.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector Reciprocal()
        {
            XMVector result;
            result.x = 1.0f / this.x;
            result.y = 1.0f / this.y;
            result.z = 1.0f / this.z;
            result.w = 1.0f / this.w;

            return result;
        }

        /// <summary>
        /// Estimates the per-component square root of a vector.
        /// </summary>
        /// <returns>Returns a vector. Each component is an estimate of the square-root of the corresponding component of V.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector SqrtEst()
        {
            XMVector result;
            result.x = (float)Math.Sqrt(this.x);
            result.y = (float)Math.Sqrt(this.y);
            result.z = (float)Math.Sqrt(this.z);
            result.w = (float)Math.Sqrt(this.w);

            return result;
        }

        /// <summary>
        /// Computes the per-component square root of a vector.
        /// </summary>
        /// <returns>Returns a vector. Each component is the square-root of the corresponding component of V.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector Sqrt()
        {
            XMVector result;
            result.x = (float)Math.Sqrt(this.x);
            result.y = (float)Math.Sqrt(this.y);
            result.z = (float)Math.Sqrt(this.z);
            result.w = (float)Math.Sqrt(this.w);

            return result;
        }

        /// <summary>
        /// Estimates the per-component reciprocal square root of a vector.
        /// </summary>
        /// <returns>Returns a vector. Each component is an estimate of the reciprocal square-root of the corresponding component of V.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector ReciprocalSqrtEst()
        {
            XMVector result;
            result.x = 1.0f / (float)Math.Sqrt(this.x);
            result.y = 1.0f / (float)Math.Sqrt(this.y);
            result.z = 1.0f / (float)Math.Sqrt(this.z);
            result.w = 1.0f / (float)Math.Sqrt(this.w);

            return result;
        }

        /// <summary>
        /// Computes the per-component reciprocal square root of a vector.
        /// </summary>
        /// <returns>Returns a vector. Each component is the reciprocal square-root of the corresponding component of V.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector ReciprocalSqrt()
        {
            XMVector result;
            result.x = 1.0f / (float)Math.Sqrt(this.x);
            result.y = 1.0f / (float)Math.Sqrt(this.y);
            result.z = 1.0f / (float)Math.Sqrt(this.z);
            result.w = 1.0f / (float)Math.Sqrt(this.w);

            return result;
        }

        /// <summary>
        /// Computes two raised to the power for each component.
        /// </summary>
        /// <returns>Returns a vector whose components are two raised to the power of the corresponding component of V.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector Exp2()
        {
            XMVector result;
            result.x = (float)Math.Pow(2.0f, this.x);
            result.y = (float)Math.Pow(2.0f, this.y);
            result.z = (float)Math.Pow(2.0f, this.z);
            result.w = (float)Math.Pow(2.0f, this.w);

            return result;
        }

        /// <summary>
        /// Computes e (~2.71828) raised to the power for each component.
        /// </summary>
        /// <returns>Returns a vector whose components are e raised to the power of the corresponding component of V.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector ExpE()
        {
            XMVector result;
            result.x = (float)Math.Exp(this.x);
            result.y = (float)Math.Exp(this.y);
            result.z = (float)Math.Exp(this.z);
            result.w = (float)Math.Exp(this.w);

            return result;
        }

        /// <summary>
        /// Computes two raised to the power for each component.
        /// </summary>
        /// <returns>Returns a vector whose components are two raised to the power of the corresponding component of V.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector Exp()
        {
            return this.Exp2();
        }

        /// <summary>
        /// Computes the base two logarithm of each component of a vector.
        /// </summary>
        /// <returns>Returns a vector whose components are base two logarithm of the corresponding components of V.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector Log2()
        {
            // (1.0f / logf(2.0f))
            float scale = 1.4426950f;

            XMVector result;
            result.x = (float)Math.Log(this.x) * scale;
            result.y = (float)Math.Log(this.y) * scale;
            result.z = (float)Math.Log(this.z) * scale;
            result.w = (float)Math.Log(this.w) * scale;

            return result;
        }

        /// <summary>
        /// Computes the base e logarithm of each component of a vector. The base e logarithm is also known as the natural logarithm.
        /// </summary>
        /// <returns>Returns a vector whose components are base e logarithm of the corresponding components of V.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector LogE()
        {
            XMVector result;
            result.x = (float)Math.Log(this.x);
            result.y = (float)Math.Log(this.y);
            result.z = (float)Math.Log(this.z);
            result.w = (float)Math.Log(this.w);

            return result;
        }

        /// <summary>
        /// Computes the base two logarithm of each component of a vector.
        /// </summary>
        /// <returns>Returns a vector whose components are base two logarithm of the corresponding components of V.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector Log()
        {
            return this.Log2();
        }

        /// <summary>
        /// Computes the absolute value of each component of a vector.
        /// </summary>
        /// <returns>Returns a vector whose components are the absolute value of the corresponding components of V.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector Abs()
        {
            return new XMVector(Math.Abs(this.x), Math.Abs(this.y), Math.Abs(this.z), Math.Abs(this.w));
        }

        /// <summary>
        /// Computes the sine of each component of a vector.
        /// </summary>
        /// <returns>Returns a vector. Each component is the sine of the corresponding component of V.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector Sin()
        {
            //// 11-degree minimax approximation

            XMVector result;
            result.x = XMScalar.Sin(this.x);
            result.y = XMScalar.Sin(this.y);
            result.z = XMScalar.Sin(this.z);
            result.w = XMScalar.Sin(this.w);

            return result;
        }

        /// <summary>
        /// Estimates the sine of each component of a vector.
        /// </summary>
        /// <returns>Returns a vector. Each component is an estimate of the sine of the corresponding component of V.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector SinEst()
        {
            //// 7-degree minimax approximation

            XMVector result;
            result.x = XMScalar.SinEst(this.x);
            result.y = XMScalar.SinEst(this.y);
            result.z = XMScalar.SinEst(this.z);
            result.w = XMScalar.SinEst(this.w);

            return result;
        }

        /// <summary>
        /// Computes the cosine of each component of a vector.
        /// </summary>
        /// <returns>Returns a vector. Each component is the cosine of the corresponding component of V.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector Cos()
        {
            //// 10-degree minimax approximation

            XMVector result;
            result.x = XMScalar.Cos(this.x);
            result.y = XMScalar.Cos(this.y);
            result.z = XMScalar.Cos(this.z);
            result.w = XMScalar.Cos(this.w);

            return result;
        }

        /// <summary>
        /// Estimates the cosine of each component of a vector.
        /// </summary>
        /// <returns>Returns a vector. Each component is an estimate of the cosine of the corresponding component of V.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector CosEst()
        {
            //// 6-degree minimax approximation

            XMVector result;
            result.x = XMScalar.CosEst(this.x);
            result.y = XMScalar.CosEst(this.y);
            result.z = XMScalar.CosEst(this.z);
            result.w = XMScalar.CosEst(this.w);

            return result;
        }

        /// <summary>
        /// Computes the sine and cosine of each component of a vector.
        /// </summary>
        /// <param name="sin">A vector, each of whose components is the sine of the corresponding component of V.</param>
        /// <param name="cos">A vector, each of whose components is the cosine of the corresponding component of V.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SinCos(out XMVector sin, out XMVector cos)
        {
            //// 11/10-degree minimax approximation

            XMScalar.SinCos(out sin.x, out cos.x, this.x);
            XMScalar.SinCos(out sin.y, out cos.y, this.y);
            XMScalar.SinCos(out sin.z, out cos.z, this.z);
            XMScalar.SinCos(out sin.w, out cos.w, this.w);
        }

        /// <summary>
        /// Estimates the sine and cosine of each component of a vector.
        /// </summary>
        /// <param name="sin">A vector, each of whose components is an estimate of the sine of the corresponding component of V.</param>
        /// <param name="cos">A vector, each of whose components is an estimate of the cosine of the corresponding component of V.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SinCosEst(out XMVector sin, out XMVector cos)
        {
            //// 7/6-degree minimax approximation

            XMScalar.SinCosEst(out sin.x, out cos.x, this.x);
            XMScalar.SinCosEst(out sin.y, out cos.y, this.y);
            XMScalar.SinCosEst(out sin.z, out cos.z, this.z);
            XMScalar.SinCosEst(out sin.w, out cos.w, this.w);
        }

        /// <summary>
        /// Computes the tangent of each component of a vector.
        /// </summary>
        /// <returns>Returns a vector. Each component is the tangent of the corresponding component of V.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector Tan()
        {
            XMVector result;
            result.x = (float)Math.Tan(this.x);
            result.y = (float)Math.Tan(this.y);
            result.z = (float)Math.Tan(this.z);
            result.w = (float)Math.Tan(this.w);

            return result;
        }

        /// <summary>
        /// Estimates the tangent of each component of a vector.
        /// </summary>
        /// <returns>Returns a vector. Each component is an estimate of the tangent of the corresponding component of V.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector TanEst()
        {
            XMVector oneOverPI = XMVector.SplatW(XMGlobalConstants.TanEstCoefficients);

            XMVector v1 = XMVector
                .Multiply(this, oneOverPI)
                .Round();

            v1 = XMVector.NegativeMultiplySubtract(XMGlobalConstants.PI, v1, this);

            XMVector t0 = XMVector.SplatX(XMGlobalConstants.TanEstCoefficients);
            XMVector t1 = XMVector.SplatY(XMGlobalConstants.TanEstCoefficients);
            XMVector t2 = XMVector.SplatZ(XMGlobalConstants.TanEstCoefficients);

            XMVector v2t2 = XMVector.NegativeMultiplySubtract(v1, v1, t2);
            XMVector v2 = XMVector.Multiply(v1, v1);
            XMVector v1t0 = XMVector.Multiply(v1, t0);
            XMVector v1t1 = XMVector.Multiply(v1, t1);

            XMVector d = v2t2.ReciprocalEst();
            XMVector n = XMVector.MultiplyAdd(v2, v1t1, v1t0);

            return XMVector.Multiply(n, d);
        }

        /// <summary>
        /// Computes the hyperbolic sine of each component of a vector.
        /// </summary>
        /// <returns>Returns a vector. Each component is the hyperbolic sine of the corresponding component of V.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector SinH()
        {
            XMVector result;
            result.x = (float)Math.Sinh(this.x);
            result.y = (float)Math.Sinh(this.y);
            result.z = (float)Math.Sinh(this.z);
            result.w = (float)Math.Sinh(this.w);

            return result;
        }

        /// <summary>
        /// Computes the hyperbolic cosine of each component of a vector.
        /// </summary>
        /// <returns>Returns a vector. Each component is the hyperbolic cosine of the corresponding component of V.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector CosH()
        {
            XMVector result;
            result.x = (float)Math.Cosh(this.x);
            result.y = (float)Math.Cosh(this.y);
            result.z = (float)Math.Cosh(this.z);
            result.w = (float)Math.Cosh(this.w);

            return result;
        }

        /// <summary>
        /// Computes the hyperbolic tangent of each component of a vector.
        /// </summary>
        /// <returns>Returns a vector. Each component is the hyperbolic tangent of the corresponding component of V.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector TanH()
        {
            XMVector result;
            result.x = (float)Math.Tanh(this.x);
            result.y = (float)Math.Tanh(this.y);
            result.z = (float)Math.Tanh(this.z);
            result.w = (float)Math.Tanh(this.w);

            return result;
        }

        /// <summary>
        /// Computes the arcsine of each component of a vector.
        /// </summary>
        /// <returns>Returns a vector whose components are the arcsine of the corresponding components of V.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector ASin()
        {
            //// 7-degree minimax approximation

            XMVector result;
            result.x = XMScalar.ASin(this.x);
            result.y = XMScalar.ASin(this.y);
            result.z = XMScalar.ASin(this.z);
            result.w = XMScalar.ASin(this.w);

            return result;
        }

        /// <summary>
        /// Estimates the arcsine of each component of a vector.
        /// </summary>
        /// <returns>Returns a vector whose components are estimates of the arcsine of the corresponding components of V.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector ASinEst()
        {
            //// 3-degree minimax approximation

            XMVector result;
            result.x = XMScalar.ASinEst(this.x);
            result.y = XMScalar.ASinEst(this.y);
            result.z = XMScalar.ASinEst(this.z);
            result.w = XMScalar.ASinEst(this.w);

            return result;
        }

        /// <summary>
        /// Computes the arccosine of each component of a vector.
        /// </summary>
        /// <returns>Returns a vector whose components are the arccosine of the corresponding components of V.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector ACos()
        {
            //// 7-degree minimax approximation

            XMVector result;
            result.x = XMScalar.ACos(this.x);
            result.y = XMScalar.ACos(this.y);
            result.z = XMScalar.ACos(this.z);
            result.w = XMScalar.ACos(this.w);

            return result;
        }

        /// <summary>
        /// Estimates the arccosine of each component of a vector.
        /// </summary>
        /// <returns>Returns a vector whose components are estimates of the arccosine of the corresponding components of V.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector ACosEst()
        {
            //// 3-degree minimax approximation

            XMVector result;
            result.x = XMScalar.ACosEst(this.x);
            result.y = XMScalar.ACosEst(this.y);
            result.z = XMScalar.ACosEst(this.z);
            result.w = XMScalar.ACosEst(this.w);

            return result;
        }

        /// <summary>
        /// Computes the arctangent of each component of a vector.
        /// </summary>
        /// <returns>Returns a vector whose components are the arctangent of the corresponding components of V.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector ATan()
        {
            XMVector result;
            result.x = (float)Math.Atan(this.x);
            result.y = (float)Math.Atan(this.y);
            result.z = (float)Math.Atan(this.z);
            result.w = (float)Math.Atan(this.w);

            return result;
        }

        /// <summary>
        /// Estimates the arctangent of each component of a vector.
        /// </summary>
        /// <returns>Returns a vector whose components are estimates of the arctangent of the corresponding components of V.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector ATanEst()
        {
            //// 9-degree minimax approximation

            XMVector result;
            result.x = XMVector.ScalarATanEst(this.x);
            result.y = XMVector.ScalarATanEst(this.y);
            result.z = XMVector.ScalarATanEst(this.z);
            result.w = XMVector.ScalarATanEst(this.w);

            return result;
        }

        /// <summary>
        /// Stores an <see cref="XMVector"/> in an <see cref="XMColorRgba"/>.
        /// </summary>
        /// <param name="value">The structure at which to store the data</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Store(out XMColorRgba value)
        {
            value = this;
        }

        /// <summary>
        /// Stores an <see cref="XMVector"/> in an <see cref="XMHalf2"/>.
        /// </summary>
        /// <param name="value">The structure at which to store the data</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Store(out XMHalf2 value)
        {
            value = this;
        }

        /// <summary>
        /// Stores an <see cref="XMVector"/> in an <see cref="XMShortN2"/>.
        /// </summary>
        /// <param name="value">The structure at which to store the data</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Store(out XMShortN2 value)
        {
            value = this;
        }

        /// <summary>
        /// Stores an <see cref="XMVector"/> in an <see cref="XMShort2"/>.
        /// </summary>
        /// <param name="value">The structure at which to store the data</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Store(out XMShort2 value)
        {
            value = this;
        }

        /// <summary>
        /// Stores an <see cref="XMVector"/> in an <see cref="XMUShortN2"/>.
        /// </summary>
        /// <param name="value">The structure at which to store the data</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Store(out XMUShortN2 value)
        {
            value = this;
        }

        /// <summary>
        /// Stores an <see cref="XMVector"/> in an <see cref="XMUShort2"/>.
        /// </summary>
        /// <param name="value">The structure at which to store the data</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Store(out XMUShort2 value)
        {
            value = this;
        }

        /// <summary>
        /// Stores an <see cref="XMVector"/> in an <see cref="XMByteN2"/>.
        /// </summary>
        /// <param name="value">The structure at which to store the data</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Store(out XMByteN2 value)
        {
            value = this;
        }

        /// <summary>
        /// Stores an <see cref="XMVector"/> in an <see cref="XMByte2"/>.
        /// </summary>
        /// <param name="value">The structure at which to store the data</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Store(out XMByte2 value)
        {
            value = this;
        }

        /// <summary>
        /// Stores an <see cref="XMVector"/> in an <see cref="XMUByteN2"/>.
        /// </summary>
        /// <param name="value">The structure at which to store the data</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Store(out XMUByteN2 value)
        {
            value = this;
        }

        /// <summary>
        /// Stores an <see cref="XMVector"/> in an <see cref="XMUByte2"/>.
        /// </summary>
        /// <param name="value">The structure at which to store the data</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Store(out XMUByte2 value)
        {
            value = this;
        }

        /// <summary>
        /// Stores an <see cref="XMVector"/> in an <see cref="XMU565"/>.
        /// </summary>
        /// <param name="value">The structure at which to store the data</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Store(out XMU565 value)
        {
            value = this;
        }

        /// <summary>
        /// Stores an <see cref="XMVector"/> in an <see cref="XMFloat3Packed"/>.
        /// </summary>
        /// <param name="value">The structure at which to store the data</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Store(out XMFloat3Packed value)
        {
            value = this;
        }

        /// <summary>
        /// Stores an <see cref="XMVector"/> in an <see cref="XMFloat3SharedExponent"/>.
        /// </summary>
        /// <param name="value">The structure at which to store the data</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Store(out XMFloat3SharedExponent value)
        {
            value = this;
        }

        /// <summary>
        /// Stores an <see cref="XMVector"/> in an <see cref="XMHalf4"/>.
        /// </summary>
        /// <param name="value">The structure at which to store the data</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Store(out XMHalf4 value)
        {
            value = this;
        }

        /// <summary>
        /// Stores an <see cref="XMVector"/> in an <see cref="XMShortN4"/>.
        /// </summary>
        /// <param name="value">The structure at which to store the data</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Store(out XMShortN4 value)
        {
            value = this;
        }

        /// <summary>
        /// Stores an <see cref="XMVector"/> in an <see cref="XMShort4"/>.
        /// </summary>
        /// <param name="value">The structure at which to store the data</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Store(out XMShort4 value)
        {
            value = this;
        }

        /// <summary>
        /// Stores an <see cref="XMVector"/> in an <see cref="XMUShortN4"/>.
        /// </summary>
        /// <param name="value">The structure at which to store the data</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Store(out XMUShortN4 value)
        {
            value = this;
        }

        /// <summary>
        /// Stores an <see cref="XMVector"/> in an <see cref="XMUShort4"/>.
        /// </summary>
        /// <param name="value">The structure at which to store the data</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Store(out XMUShort4 value)
        {
            value = this;
        }

        /// <summary>
        /// Stores an <see cref="XMVector"/> in an <see cref="XMXDecN4"/>.
        /// </summary>
        /// <param name="value">The structure at which to store the data</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Store(out XMXDecN4 value)
        {
            value = this;
        }

        /// <summary>
        /// Stores an <see cref="XMVector"/> in an <see cref="XMXDec4"/>.
        /// </summary>
        /// <param name="value">The structure at which to store the data</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Store(out XMXDec4 value)
        {
            value = this;
        }

        /// <summary>
        /// Stores an <see cref="XMVector"/> in an <see cref="XMDecN4"/>.
        /// </summary>
        /// <param name="value">The structure at which to store the data</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Store(out XMDecN4 value)
        {
            value = this;
        }

        /// <summary>
        /// Stores an <see cref="XMVector"/> in an <see cref="XMDec4"/>.
        /// </summary>
        /// <param name="value">The structure at which to store the data</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Store(out XMDec4 value)
        {
            value = this;
        }

        /// <summary>
        /// Stores an <see cref="XMVector"/> in an <see cref="XMUDecN4"/>.
        /// </summary>
        /// <param name="value">The structure at which to store the data</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Store(out XMUDecN4 value)
        {
            value = this;
        }

        /// <summary>
        /// Stores an <see cref="XMVector"/> in an <see cref="XMUDecN4XR"/>.
        /// </summary>
        /// <param name="value">The structure at which to store the data</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Store(out XMUDecN4XR value)
        {
            value = this;
        }

        /// <summary>
        /// Stores an <see cref="XMVector"/> in an <see cref="XMUDec4"/>.
        /// </summary>
        /// <param name="value">The structure at which to store the data</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Store(out XMUDec4 value)
        {
            value = this;
        }

        /// <summary>
        /// Stores an <see cref="XMVector"/> in an <see cref="XMByteN4"/>.
        /// </summary>
        /// <param name="value">The structure at which to store the data</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Store(out XMByteN4 value)
        {
            value = this;
        }

        /// <summary>
        /// Stores an <see cref="XMVector"/> in an <see cref="XMByte4"/>.
        /// </summary>
        /// <param name="value">The structure at which to store the data</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Store(out XMByte4 value)
        {
            value = this;
        }

        /// <summary>
        /// Stores an <see cref="XMVector"/> in an <see cref="XMUByteN4"/>.
        /// </summary>
        /// <param name="value">The structure at which to store the data</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Store(out XMUByteN4 value)
        {
            value = this;
        }

        /// <summary>
        /// Stores an <see cref="XMVector"/> in an <see cref="XMUByte4"/>.
        /// </summary>
        /// <param name="value">The structure at which to store the data</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Store(out XMUByte4 value)
        {
            value = this;
        }

        /// <summary>
        /// Stores an <see cref="XMVector"/> in an <see cref="XMUNibble4"/>.
        /// </summary>
        /// <param name="value">The structure at which to store the data</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Store(out XMUNibble4 value)
        {
            value = this;
        }

        /// <summary>
        /// Stores an <see cref="XMVector"/> in an <see cref="XMU555"/>.
        /// </summary>
        /// <param name="value">The structure at which to store the data</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Store(out XMU555 value)
        {
            value = this;
        }

        /// <summary>
        /// Indicates if the value is NaN.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>A boolean value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsNaN(float value)
        {
            return ((*(uint*)&value & 0x7F800000U) == 0x7F800000U) && ((*(uint*)&value & 0x7FFFFFU) != 0);
        }

        /// <summary>
        /// Indicates if the value is infinite.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>A boolean value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsInfinite(float value)
        {
            return (*(uint*)&value & 0x7FFFFFFFU) == 0x7F800000U;
        }

        /// <summary>
        /// Rounds the value to nearest.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static float RoundToNearest(float value)
        {
            float i = (float)Math.Floor(value);

            value -= i;

            if (value < 0.5f)
            {
                return i;
            }

            if (value > 0.5f)
            {
                return i + 1.0f;
            }

            float intPart = (float)Math.Truncate(i / 2.0f);

            if (2.0f * intPart == i)
            {
                return i;
            }

            return i + 1.0f;
        }

        /// <summary>
        /// Returns the arc tan of a scalar value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static float ScalarATanEst(float value)
        {
            float y;
            float sign;

            if (Math.Abs(value) <= 1.0f)
            {
                y = value;
                sign = 0.0f;
            }
            else if (value > 1.0f)
            {
                y = 1.0f / value;
                sign = 1.0f;
            }
            else
            {
                y = 1.0f / value;
                sign = -1.0f;
            }

            // 9-degree minimax approximation
            float y2 = y * y;
            float poly = ((((((((0.0208351f * y2) - 0.085133f) * y2) + 0.180141f) * y2) - 0.3302995f) * y2) + 0.999866f) * y;

            return sign == 0.0f ? poly : ((sign * XMMath.PIDivTwo) - poly);
        }
    }
}
