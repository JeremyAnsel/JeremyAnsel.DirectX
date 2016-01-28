// <copyright file="D3D11BufferDesc.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Describes a buffer resource.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11BufferDesc : IEquatable<D3D11BufferDesc>
    {
        /// <summary>
        /// Size of the buffer in bytes.
        /// </summary>
        private uint byteWidth;

        /// <summary>
        /// Identify how the buffer is expected to be read from and written to.
        /// </summary>
        private D3D11Usage usage;

        /// <summary>
        /// Identify how the buffer will be bound to the pipeline.
        /// </summary>
        private D3D11BindOptions bindOptions;

        /// <summary>
        /// CPU access flags or 0 if no CPU access is necessary.
        /// </summary>
        private D3D11CpuAccessOptions cpuAccessOptions;

        /// <summary>
        /// Miscellaneous flags or 0 if unused.
        /// </summary>
        private D3D11ResourceMiscOptions miscOptions;

        /// <summary>
        /// The size of each element in the buffer structure (in bytes) when the buffer represents a structured buffer.
        /// </summary>
        private uint structureByteStride;

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11BufferDesc"/> struct.
        /// </summary>
        /// <param name="byteWidth">Size of the buffer in bytes.</param>
        /// <param name="bindOptions">Identify how the buffer will be bound to the pipeline.</param>
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "byte", Justification = "Reviewed")]
        public D3D11BufferDesc(uint byteWidth, D3D11BindOptions bindOptions)
        {
            this.byteWidth = byteWidth;
            this.usage = D3D11Usage.Default;
            this.bindOptions = bindOptions;
            this.cpuAccessOptions = 0;
            this.miscOptions = D3D11ResourceMiscOptions.None;
            this.structureByteStride = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11BufferDesc"/> struct.
        /// </summary>
        /// <param name="byteWidth">Size of the buffer in bytes.</param>
        /// <param name="bindOptions">Identify how the buffer will be bound to the pipeline.</param>
        /// <param name="usage">Identify how the buffer is expected to be read from and written to.</param>
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "byte", Justification = "Reviewed")]
        public D3D11BufferDesc(uint byteWidth, D3D11BindOptions bindOptions, D3D11Usage usage)
        {
            this.byteWidth = byteWidth;
            this.usage = usage;
            this.bindOptions = bindOptions;
            this.cpuAccessOptions = 0;
            this.miscOptions = D3D11ResourceMiscOptions.None;
            this.structureByteStride = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11BufferDesc"/> struct.
        /// </summary>
        /// <param name="byteWidth">Size of the buffer in bytes.</param>
        /// <param name="bindOptions">Identify how the buffer will be bound to the pipeline.</param>
        /// <param name="usage">Identify how the buffer is expected to be read from and written to.</param>
        /// <param name="cpuAccessOptions">CPU access flags or 0 if no CPU access is necessary.</param>
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "byte", Justification = "Reviewed")]
        public D3D11BufferDesc(
            uint byteWidth,
            D3D11BindOptions bindOptions,
            D3D11Usage usage,
            D3D11CpuAccessOptions cpuAccessOptions)
        {
            this.byteWidth = byteWidth;
            this.usage = usage;
            this.bindOptions = bindOptions;
            this.cpuAccessOptions = cpuAccessOptions;
            this.miscOptions = D3D11ResourceMiscOptions.None;
            this.structureByteStride = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11BufferDesc"/> struct.
        /// </summary>
        /// <param name="byteWidth">Size of the buffer in bytes.</param>
        /// <param name="bindOptions">Identify how the buffer will be bound to the pipeline.</param>
        /// <param name="usage">Identify how the buffer is expected to be read from and written to.</param>
        /// <param name="cpuAccessOptions">CPU access flags or 0 if no CPU access is necessary.</param>
        /// <param name="miscOptions">Miscellaneous flags or 0 if unused.</param>
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "byte", Justification = "Reviewed")]
        public D3D11BufferDesc(
            uint byteWidth,
            D3D11BindOptions bindOptions,
            D3D11Usage usage,
            D3D11CpuAccessOptions cpuAccessOptions,
            D3D11ResourceMiscOptions miscOptions)
        {
            this.byteWidth = byteWidth;
            this.usage = usage;
            this.bindOptions = bindOptions;
            this.cpuAccessOptions = cpuAccessOptions;
            this.miscOptions = miscOptions;
            this.structureByteStride = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11BufferDesc"/> struct.
        /// </summary>
        /// <param name="byteWidth">Size of the buffer in bytes.</param>
        /// <param name="bindOptions">Identify how the buffer will be bound to the pipeline.</param>
        /// <param name="usage">Identify how the buffer is expected to be read from and written to.</param>
        /// <param name="cpuAccessOptions">CPU access flags or 0 if no CPU access is necessary.</param>
        /// <param name="miscOptions">Miscellaneous flags or 0 if unused.</param>
        /// <param name="structureByteStride">The size of each element in the buffer structure (in bytes) when the buffer represents a structured buffer.</param>
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "byte", Justification = "Reviewed")]
        public D3D11BufferDesc(
            uint byteWidth,
            D3D11BindOptions bindOptions,
            D3D11Usage usage,
            D3D11CpuAccessOptions cpuAccessOptions,
            D3D11ResourceMiscOptions miscOptions,
            uint structureByteStride)
        {
            this.byteWidth = byteWidth;
            this.usage = usage;
            this.bindOptions = bindOptions;
            this.cpuAccessOptions = cpuAccessOptions;
            this.miscOptions = miscOptions;
            this.structureByteStride = structureByteStride;
        }

        /// <summary>
        /// Gets or sets the size of the buffer in bytes.
        /// </summary>
        public uint ByteWidth
        {
            get { return this.byteWidth; }
            set { this.byteWidth = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating how the buffer is expected to be read from and written to.
        /// </summary>
        public D3D11Usage Usage
        {
            get { return this.usage; }
            set { this.usage = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating how the buffer will be bound to the pipeline.
        /// </summary>
        public D3D11BindOptions BindOptions
        {
            get { return this.bindOptions; }
            set { this.bindOptions = value; }
        }

        /// <summary>
        /// Gets or sets the CPU access flags or 0 if no CPU access is necessary.
        /// </summary>
        public D3D11CpuAccessOptions CpuAccessOptions
        {
            get { return this.cpuAccessOptions; }
            set { this.cpuAccessOptions = value; }
        }

        /// <summary>
        /// Gets or sets the miscellaneous flags or 0 if unused.
        /// </summary>
        public D3D11ResourceMiscOptions MiscOptions
        {
            get { return this.miscOptions; }
            set { this.miscOptions = value; }
        }

        /// <summary>
        /// Gets or sets the size of each element in the buffer structure (in bytes) when the buffer represents a structured buffer.
        /// </summary>
        public uint StructureByteStride
        {
            get { return this.structureByteStride; }
            set { this.structureByteStride = value; }
        }

        /// <summary>
        /// Compares two <see cref="D3D11BufferDesc"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11BufferDesc"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11BufferDesc"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D3D11BufferDesc left, D3D11BufferDesc right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D3D11BufferDesc"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11BufferDesc"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11BufferDesc"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D3D11BufferDesc left, D3D11BufferDesc right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Creates a <see cref="D3D11BufferDesc"/> struct from a struct.
        /// </summary>
        /// <typeparam name="T">A struct.</typeparam>
        /// <param name="data">The data.</param>
        /// <param name="bindOptions">Identify how the buffer will be bound to the pipeline.</param>
        /// <returns>A <see cref="D3D11BufferDesc"/> struct.</returns>
        public static D3D11BufferDesc From<T>(T[] data, D3D11BindOptions bindOptions)
            where T : struct
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }

            return new D3D11BufferDesc((uint)Marshal.SizeOf(typeof(T)) * (uint)data.Length, bindOptions);
        }

        /// <summary>
        /// Creates a <see cref="D3D11BufferDesc"/> struct from a struct.
        /// </summary>
        /// <typeparam name="T">A struct.</typeparam>
        /// <param name="data">The data.</param>
        /// <param name="bindOptions">Identify how the buffer will be bound to the pipeline.</param>
        /// <param name="usage">Identify how the buffer is expected to be read from and written to.</param>
        /// <returns>A <see cref="D3D11BufferDesc"/> struct.</returns>
        public static D3D11BufferDesc From<T>(T[] data, D3D11BindOptions bindOptions, D3D11Usage usage)
            where T : struct
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }

            return new D3D11BufferDesc((uint)Marshal.SizeOf(typeof(T)) * (uint)data.Length, bindOptions, usage);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is D3D11BufferDesc))
            {
                return false;
            }

            return this.Equals((D3D11BufferDesc)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D3D11BufferDesc other)
        {
            return this.byteWidth == other.byteWidth
                && this.usage == other.usage
                && this.bindOptions == other.bindOptions
                && this.cpuAccessOptions == other.cpuAccessOptions
                && this.miscOptions == other.miscOptions
                && this.structureByteStride == other.structureByteStride;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.byteWidth,
                this.usage,
                this.bindOptions,
                this.cpuAccessOptions,
                this.miscOptions,
                this.structureByteStride
            }
            .GetHashCode();
        }
    }
}
