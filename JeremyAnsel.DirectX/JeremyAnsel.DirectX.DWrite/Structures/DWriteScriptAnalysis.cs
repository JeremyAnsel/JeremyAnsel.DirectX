// <copyright file="DWriteScriptAnalysis.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Association of text and its writing system script as well as some display attributes.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DWriteScriptAnalysis : IEquatable<DWriteScriptAnalysis>
    {
        /// <summary>
        /// Zero-based index representation of writing system script.
        /// </summary>
        private ushort script;

        /// <summary>
        /// Additional shaping requirement of text.
        /// </summary>
        private DWriteScriptShape shapes;

        /// <summary>
        /// Initializes a new instance of the <see cref="DWriteScriptAnalysis"/> struct.
        /// </summary>
        /// <param name="script">Zero-based index representation of writing system script.</param>
        /// <param name="shapes">Additional shaping requirement of text.</param>
        public DWriteScriptAnalysis(ushort script, DWriteScriptShape shapes)
        {
            this.script = script;
            this.shapes = shapes;
        }

        /// <summary>
        /// Gets or sets the zero-based index representation of writing system script.
        /// </summary>
        public ushort Script
        {
            get { return this.script; }
            set { this.script = value; }
        }

        /// <summary>
        /// Gets or sets the additional shaping requirement of text.
        /// </summary>
        public DWriteScriptShape Shapes
        {
            get { return this.shapes; }
            set { this.shapes = value; }
        }

        /// <summary>
        /// Compares two <see cref="DWriteScriptAnalysis"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="DWriteScriptAnalysis"/> to compare.</param>
        /// <param name="right">The right <see cref="DWriteScriptAnalysis"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(DWriteScriptAnalysis left, DWriteScriptAnalysis right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="DWriteScriptAnalysis"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="DWriteScriptAnalysis"/> to compare.</param>
        /// <param name="right">The right <see cref="DWriteScriptAnalysis"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(DWriteScriptAnalysis left, DWriteScriptAnalysis right)
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
            if (!(obj is DWriteScriptAnalysis))
            {
                return false;
            }

            return this.Equals((DWriteScriptAnalysis)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(DWriteScriptAnalysis other)
        {
            return this.script == other.script
                && this.shapes == other.shapes;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.script,
                this.shapes
            }
            .GetHashCode();
        }
    }
}
