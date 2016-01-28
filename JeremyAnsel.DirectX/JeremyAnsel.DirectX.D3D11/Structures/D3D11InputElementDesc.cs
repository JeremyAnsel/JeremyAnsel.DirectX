// <copyright file="D3D11InputElementDesc.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;
    using JeremyAnsel.DirectX.Dxgi;

    /// <summary>
    /// A description of a single element for the input-assembler stage.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11InputElementDesc : IEquatable<D3D11InputElementDesc>
    {
        /// <summary>
        /// The HLSL semantic associated with this element in a shader input-signature.
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        private string semanticName;

        /// <summary>
        /// The semantic index for the element.
        /// </summary>
        private uint semanticIndex;

        /// <summary>
        /// The data type of the element data.
        /// </summary>
        private DxgiFormat format;

        /// <summary>
        /// An integer value that identifies the input-assembler.
        /// </summary>
        private uint inputSlot;

        /// <summary>
        /// Offset (in bytes) between each element. Optional.
        /// </summary>
        private uint alignedByteOffset;

        /// <summary>
        /// Identifies the input data class for a single input slot.
        /// </summary>
        private D3D11InputClassification inputSlotClass;

        /// <summary>
        /// The number of instances to draw using the same per-instance data before advancing in the buffer by one element. This value must be 0 for an element that contains per-vertex data.
        /// </summary>
        private uint instanceDataStepRate;

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11InputElementDesc"/> struct.
        /// </summary>
        /// <param name="semanticName">The HLSL semantic associated with this element in a shader input-signature.</param>
        /// <param name="semanticIndex">The semantic index for the element.</param>
        /// <param name="format">The data type of the element data.</param>
        /// <param name="inputSlot">An integer value that identifies the input-assembler.</param>
        /// <param name="alignedByteOffset">Offset (in bytes) between each element. Optional.</param>
        /// <param name="inputSlotClass">Identifies the input data class for a single input slot.</param>
        /// <param name="instanceDataStepRate">The number of instances to draw using the same per-instance data before advancing in the buffer by one element. This value must be 0 for an element that contains per-vertex data.</param>
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "byte", Justification = "Reviewed")]
        public D3D11InputElementDesc(
            string semanticName,
            uint semanticIndex,
            DxgiFormat format,
            uint inputSlot,
            uint alignedByteOffset,
            D3D11InputClassification inputSlotClass,
            uint instanceDataStepRate)
        {
            this.semanticName = semanticName;
            this.semanticIndex = semanticIndex;
            this.format = format;
            this.inputSlot = inputSlot;
            this.alignedByteOffset = alignedByteOffset;
            this.inputSlotClass = inputSlotClass;
            this.instanceDataStepRate = instanceDataStepRate;
        }

        /// <summary>
        /// Gets or sets the HLSL semantic associated with this element in a shader input-signature.
        /// </summary>
        public string SemanticName
        {
            get { return this.semanticName; }
            set { this.semanticName = value; }
        }

        /// <summary>
        /// Gets or sets the semantic index for the element.
        /// </summary>
        public uint SemanticIndex
        {
            get { return this.semanticIndex; }
            set { this.semanticIndex = value; }
        }

        /// <summary>
        /// Gets or sets the data type of the element data.
        /// </summary>
        public DxgiFormat Format
        {
            get { return this.format; }
            set { this.format = value; }
        }

        /// <summary>
        /// Gets or sets an integer value that identifies the input-assembler.
        /// </summary>
        public uint InputSlot
        {
            get { return this.inputSlot; }
            set { this.inputSlot = value; }
        }

        /// <summary>
        /// Gets or sets the offset (in bytes) between each element. Optional.
        /// </summary>
        public uint AlignedByteOffset
        {
            get { return this.alignedByteOffset; }
            set { this.alignedByteOffset = value; }
        }

        /// <summary>
        /// Gets or sets the input data class for a single input slot.
        /// </summary>
        public D3D11InputClassification InputSlotClass
        {
            get { return this.inputSlotClass; }
            set { this.inputSlotClass = value; }
        }

        /// <summary>
        /// Gets or sets the number of instances to draw using the same per-instance data before advancing in the buffer by one element. This value must be 0 for an element that contains per-vertex data.
        /// </summary>
        public uint InstanceDataStepRate
        {
            get { return this.instanceDataStepRate; }
            set { this.instanceDataStepRate = value; }
        }

        /// <summary>
        /// Compares two <see cref="D3D11InputElementDesc"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11InputElementDesc"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11InputElementDesc"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D3D11InputElementDesc left, D3D11InputElementDesc right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D3D11InputElementDesc"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11InputElementDesc"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11InputElementDesc"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D3D11InputElementDesc left, D3D11InputElementDesc right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is D3D11InputElementDesc))
            {
                return false;
            }

            return this.Equals((D3D11InputElementDesc)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D3D11InputElementDesc other)
        {
            return this.semanticName == other.semanticName
                && this.semanticIndex == other.semanticIndex
                && this.format == other.format
                && this.inputSlot == other.inputSlot
                && this.alignedByteOffset == other.alignedByteOffset
                && this.inputSlotClass == other.inputSlotClass
                && this.instanceDataStepRate == other.instanceDataStepRate;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.semanticName,
                this.semanticIndex,
                this.format,
                this.inputSlot,
                this.alignedByteOffset,
                this.inputSlotClass,
                this.instanceDataStepRate
            }
            .GetHashCode();
        }
    }
}
