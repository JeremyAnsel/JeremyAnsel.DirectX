// <copyright file="D3D11StreamOutputDeclarationEntry.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Description of a vertex element in a vertex buffer in an output slot.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11StreamOutputDeclarationEntry : IEquatable<D3D11StreamOutputDeclarationEntry>
    {
        /// <summary>
        /// The stream number.
        /// </summary>
        private uint stream;

        /// <summary>
        /// The type of output element.
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        private string semanticName;

        /// <summary>
        /// The output element's index.
        /// </summary>
        private uint semanticIndex;

        /// <summary>
        /// Which component of the entry to begin writing out to. Valid values are 0 to 3.
        /// </summary>
        private byte startComponent;

        /// <summary>
        /// The number of components of the entry to write out to. Valid values are 1 to 4.
        /// </summary>
        private byte componentCount;

        /// <summary>
        /// The associated stream output buffer that is bound to the pipeline.
        /// </summary>
        private byte outputSlot;

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11StreamOutputDeclarationEntry"/> struct.
        /// </summary>
        /// <param name="stream">The stream number.</param>
        /// <param name="semanticName">The type of output element.</param>
        /// <param name="semanticIndex">The output element's index.</param>
        /// <param name="startComponent">Which component of the entry to begin writing out to. Valid values are 0 to 3.</param>
        /// <param name="componentCount">The number of components of the entry to write out to. Valid values are 1 to 4.</param>
        /// <param name="outputSlot">The associated stream output buffer that is bound to the pipeline.</param>
        public D3D11StreamOutputDeclarationEntry(
            uint stream,
            string semanticName,
            uint semanticIndex,
            byte startComponent,
            byte componentCount,
            byte outputSlot)
        {
            this.stream = stream;
            this.semanticName = semanticName;
            this.semanticIndex = semanticIndex;
            this.startComponent = startComponent;
            this.componentCount = componentCount;
            this.outputSlot = outputSlot;
        }

        /// <summary>
        /// Gets or sets the stream number.
        /// </summary>
        public uint Stream
        {
            get { return this.stream; }
            set { this.stream = value; }
        }

        /// <summary>
        /// Gets or sets the type of output element.
        /// </summary>
        public string SemanticName
        {
            get { return this.semanticName; }
            set { this.semanticName = value; }
        }

        /// <summary>
        /// Gets or sets the output element's index.
        /// </summary>
        public uint SemanticIndex
        {
            get { return this.semanticIndex; }
            set { this.semanticIndex = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating which component of the entry to begin writing out to. Valid values are 0 to 3.
        /// </summary>
        public byte StartComponent
        {
            get { return this.startComponent; }
            set { this.startComponent = value; }
        }

        /// <summary>
        /// Gets or sets the number of components of the entry to write out to. Valid values are 1 to 4.
        /// </summary>
        public byte ComponentCount
        {
            get { return this.componentCount; }
            set { this.componentCount = value; }
        }

        /// <summary>
        /// Gets or sets the associated stream output buffer that is bound to the pipeline.
        /// </summary>
        public byte OutputSlot
        {
            get { return this.outputSlot; }
            set { this.outputSlot = value; }
        }

        /// <summary>
        /// Compares two <see cref="D3D11StreamOutputDeclarationEntry"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11StreamOutputDeclarationEntry"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11StreamOutputDeclarationEntry"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D3D11StreamOutputDeclarationEntry left, D3D11StreamOutputDeclarationEntry right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D3D11StreamOutputDeclarationEntry"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11StreamOutputDeclarationEntry"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11StreamOutputDeclarationEntry"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D3D11StreamOutputDeclarationEntry left, D3D11StreamOutputDeclarationEntry right)
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
            if (!(obj is D3D11StreamOutputDeclarationEntry))
            {
                return false;
            }

            return this.Equals((D3D11StreamOutputDeclarationEntry)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D3D11StreamOutputDeclarationEntry other)
        {
            return this.stream == other.stream
                && this.semanticName == other.semanticName
                && this.semanticIndex == other.semanticIndex
                && this.startComponent == other.startComponent
                && this.componentCount == other.componentCount
                && this.outputSlot == other.outputSlot;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.stream,
                this.semanticName,
                this.semanticIndex,
                this.startComponent,
                this.componentCount,
                this.outputSlot
            }
            .GetHashCode();
        }
    }
}
