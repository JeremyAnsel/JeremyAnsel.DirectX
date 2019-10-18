// <copyright file="D3D11QueryDataPipelineStatistics.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Query information about graphics-pipeline activity in between calls to <see cref="D3D11DeviceContext.Begin"/> and <see cref="D3D11DeviceContext.End"/>.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11QueryDataPipelineStatistics : IEquatable<D3D11QueryDataPipelineStatistics>
    {
        /// <summary>
        /// The number of vertices read by input assembler.
        /// </summary>
        private ulong inputAssemblerVertices;

        /// <summary>
        /// The number of primitives read by the input assembler.
        /// </summary>
        private ulong inputAssemblerPrimitives;

        /// <summary>
        /// The number of times a vertex shader was invoked.
        /// </summary>
        private ulong vertexShaderInvocations;

        /// <summary>
        /// The number of times a geometry shader was invoked.
        /// </summary>
        private ulong geometryShaderInvocations;

        /// <summary>
        /// The number of primitives output by a geometry shader.
        /// </summary>
        private ulong geometryShaderPrimitives;

        /// <summary>
        /// The number of primitives that were sent to the rasterizer.
        /// </summary>
        private ulong rasterizerInvocations;

        /// <summary>
        /// The number of primitives that were rendered.
        /// </summary>
        private ulong rasterizerPrimitives;

        /// <summary>
        /// The number of times a pixel shader was invoked.
        /// </summary>
        private ulong pixelShaderInvocations;

        /// <summary>
        /// The number of times a hull shader was invoked.
        /// </summary>
        private ulong hullShaderInvocations;

        /// <summary>
        /// The number of times a domain shader was invoked.
        /// </summary>
        private ulong domainShaderInvocations;

        /// <summary>
        /// The number of times a compute shader was invoked.
        /// </summary>
        private ulong computeShaderInvocations;

        /// <summary>
        /// Gets the number of vertices read by input assembler.
        /// </summary>
        public ulong InputAssemblerVertices
        {
            get { return this.inputAssemblerVertices; }
        }

        /// <summary>
        /// Gets the number of primitives read by the input assembler.
        /// </summary>
        public ulong InputAssemblerPrimitives
        {
            get { return this.inputAssemblerPrimitives; }
        }

        /// <summary>
        /// Gets the number of times a vertex shader was invoked.
        /// </summary>
        public ulong VertexShaderInvocations
        {
            get { return this.vertexShaderInvocations; }
        }

        /// <summary>
        /// Gets the number of times a geometry shader was invoked.
        /// </summary>
        public ulong GeometryShaderInvocations
        {
            get { return this.vertexShaderInvocations; }
        }

        /// <summary>
        /// Gets the number of primitives output by a geometry shader.
        /// </summary>
        public ulong GeometryShaderPrimitives
        {
            get { return this.geometryShaderPrimitives; }
        }

        /// <summary>
        /// Gets the number of primitives that were sent to the rasterizer.
        /// </summary>
        public ulong RasterizerInvocations
        {
            get { return this.rasterizerInvocations; }
        }

        /// <summary>
        /// Gets the number of primitives that were rendered.
        /// </summary>
        public ulong RasterizerPrimitives
        {
            get { return this.rasterizerPrimitives; }
        }

        /// <summary>
        /// Gets the number of times a pixel shader was invoked.
        /// </summary>
        public ulong PixelShaderInvocations
        {
            get { return this.pixelShaderInvocations; }
        }

        /// <summary>
        /// Gets the number of times a hull shader was invoked.
        /// </summary>
        public ulong HullShaderInvocations
        {
            get { return this.hullShaderInvocations; }
        }

        /// <summary>
        /// Gets the number of times a domain shader was invoked.
        /// </summary>
        public ulong DomainShaderInvocations
        {
            get { return this.domainShaderInvocations; }
        }

        /// <summary>
        /// Gets the number of times a compute shader was invoked.
        /// </summary>
        public ulong ComputeShaderInvocations
        {
            get { return this.computeShaderInvocations; }
        }

        /// <summary>
        /// Compares two <see cref="D3D11QueryDataPipelineStatistics"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11QueryDataPipelineStatistics"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11QueryDataPipelineStatistics"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D3D11QueryDataPipelineStatistics left, D3D11QueryDataPipelineStatistics right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D3D11QueryDataPipelineStatistics"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11QueryDataPipelineStatistics"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11QueryDataPipelineStatistics"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D3D11QueryDataPipelineStatistics left, D3D11QueryDataPipelineStatistics right)
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
            if (!(obj is D3D11QueryDataPipelineStatistics))
            {
                return false;
            }

            return this.Equals((D3D11QueryDataPipelineStatistics)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D3D11QueryDataPipelineStatistics other)
        {
            return this.inputAssemblerVertices == other.inputAssemblerVertices
                && this.inputAssemblerPrimitives == other.inputAssemblerPrimitives
                && this.vertexShaderInvocations == other.vertexShaderInvocations
                && this.geometryShaderInvocations == other.geometryShaderInvocations
                && this.geometryShaderPrimitives == other.geometryShaderPrimitives
                && this.rasterizerInvocations == other.rasterizerInvocations
                && this.rasterizerPrimitives == other.rasterizerPrimitives
                && this.pixelShaderInvocations == other.pixelShaderInvocations
                && this.hullShaderInvocations == other.hullShaderInvocations
                && this.domainShaderInvocations == other.domainShaderInvocations
                && this.computeShaderInvocations == other.computeShaderInvocations;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.inputAssemblerVertices,
                this.inputAssemblerPrimitives,
                this.vertexShaderInvocations,
                this.geometryShaderInvocations,
                this.geometryShaderPrimitives,
                this.rasterizerInvocations,
                this.rasterizerPrimitives,
                this.pixelShaderInvocations,
                this.hullShaderInvocations,
                this.domainShaderInvocations,
                this.computeShaderInvocations
            }
            .GetHashCode();
        }
    }
}
