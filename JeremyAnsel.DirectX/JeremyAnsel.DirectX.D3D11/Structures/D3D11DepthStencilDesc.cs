// <copyright file="D3D11DepthStencilDesc.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Describes depth-stencil state.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11DepthStencilDesc : IEquatable<D3D11DepthStencilDesc>
    {
        /// <summary>
        /// Enable depth testing.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        private bool isDepthEnabled;

        /// <summary>
        /// Identify a portion of the depth-stencil buffer that can be modified by depth data.
        /// </summary>
        private D3D11DepthWriteMask depthWriteMask;

        /// <summary>
        /// A function that compares depth data against existing depth data.
        /// </summary>
        private D3D11ComparisonFunction depthFunction;

        /// <summary>
        /// Enable stencil testing.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        private bool isStencilEnabled;

        /// <summary>
        /// Identify a portion of the depth-stencil buffer for reading stencil data.
        /// </summary>
        private byte stencilReadMask;

        /// <summary>
        /// Identify a portion of the depth-stencil buffer for writing stencil data.
        /// </summary>
        private byte stencilWriteMask;

        /// <summary>
        /// Identify how to use the results of the depth test and the stencil test for pixels whose surface normal is facing towards the camera.
        /// </summary>
        private D3D11DepthStencilOperationDesc frontFace;

        /// <summary>
        /// Identify how to use the results of the depth test and the stencil test for pixels whose surface normal is facing away from the camera.
        /// </summary>
        private D3D11DepthStencilOperationDesc backFace;

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11DepthStencilDesc"/> struct.
        /// </summary>
        /// <param name="isDepthEnabled">Enable depth testing.</param>
        /// <param name="depthWriteMask">Identify a portion of the depth-stencil buffer that can be modified by depth data.</param>
        /// <param name="depthFunction">A function that compares depth data against existing depth data.</param>
        /// <param name="isStencilEnabled">Enable stencil testing.</param>
        /// <param name="stencilReadMask">Identify a portion of the depth-stencil buffer for reading stencil data.</param>
        /// <param name="stencilWriteMask">Identify a portion of the depth-stencil buffer for writing stencil data.</param>
        /// <param name="frontStencilFailOperation">The stencil operation to perform when stencil testing fails for pixels whose surface normal is facing towards the camera.</param>
        /// <param name="frontStencilDepthFailOperation">The stencil operation to perform when stencil testing passes and depth testing fails for pixels whose surface normal is facing towards the camera.</param>
        /// <param name="frontStencilPassOperation">The stencil operation to perform when stencil testing and depth testing both pass for pixels whose surface normal is facing towards the camera.</param>
        /// <param name="frontStencilFunction">A function that compares stencil data against existing stencil data for pixels whose surface normal is facing towards the camera.</param>
        /// <param name="backStencilFailOperation">The stencil operation to perform when stencil testing fails for pixels whose surface normal is facing away from the camera.</param>
        /// <param name="backStencilDepthFailOperation">The stencil operation to perform when stencil testing passes and depth testing fails for pixels whose surface normal is facing away from the camera.</param>
        /// <param name="backStencilPassOperation">The stencil operation to perform when stencil testing and depth testing both pass for pixels whose surface normal is facing away from the camera.</param>
        /// <param name="backStencilFunction">A function that compares stencil data against existing stencil data for pixels whose surface normal is facing away from the camera.</param>
        public D3D11DepthStencilDesc(
            bool isDepthEnabled,
            D3D11DepthWriteMask depthWriteMask,
            D3D11ComparisonFunction depthFunction,
            bool isStencilEnabled,
            byte stencilReadMask,
            byte stencilWriteMask,
            D3D11StencilOperation frontStencilFailOperation,
            D3D11StencilOperation frontStencilDepthFailOperation,
            D3D11StencilOperation frontStencilPassOperation,
            D3D11ComparisonFunction frontStencilFunction,
            D3D11StencilOperation backStencilFailOperation,
            D3D11StencilOperation backStencilDepthFailOperation,
            D3D11StencilOperation backStencilPassOperation,
            D3D11ComparisonFunction backStencilFunction)
        {
            this.isDepthEnabled = isDepthEnabled;
            this.depthWriteMask = depthWriteMask;
            this.depthFunction = depthFunction;
            this.isStencilEnabled = isStencilEnabled;
            this.stencilReadMask = stencilReadMask;
            this.stencilWriteMask = stencilWriteMask;

            this.frontFace = new D3D11DepthStencilOperationDesc
            {
                StencilFailOperation = frontStencilFailOperation,
                StencilDepthFailOperation = frontStencilDepthFailOperation,
                StencilPassOperation = frontStencilPassOperation,
                StencilFunction = frontStencilFunction
            };

            this.backFace = new D3D11DepthStencilOperationDesc
            {
                StencilFailOperation = backStencilFailOperation,
                StencilDepthFailOperation = backStencilDepthFailOperation,
                StencilPassOperation = backStencilPassOperation,
                StencilFunction = backStencilFunction
            };
        }

        /// <summary>
        /// Gets default depth-stencil-state values
        /// </summary>
        public static D3D11DepthStencilDesc Default
        {
            get
            {
                return new D3D11DepthStencilDesc(
                    true,
                    D3D11DepthWriteMask.All,
                    D3D11ComparisonFunction.Less,
                    false,
                    0xff,
                    0xff,
                    D3D11StencilOperation.Keep,
                    D3D11StencilOperation.Keep,
                    D3D11StencilOperation.Keep,
                    D3D11ComparisonFunction.Always,
                    D3D11StencilOperation.Keep,
                    D3D11StencilOperation.Keep,
                    D3D11StencilOperation.Keep,
                    D3D11ComparisonFunction.Always);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether depth testing is enabled.
        /// </summary>
        public bool IsDepthEnabled
        {
            get { return this.isDepthEnabled; }
            set { this.isDepthEnabled = value; }
        }

        /// <summary>
        /// Gets or sets a portion of the depth-stencil buffer that can be modified by depth data.
        /// </summary>
        public D3D11DepthWriteMask DepthWriteMask
        {
            get { return this.depthWriteMask; }
            set { this.depthWriteMask = value; }
        }

        /// <summary>
        /// Gets or sets a function that compares depth data against existing depth data.
        /// </summary>
        public D3D11ComparisonFunction DepthFunction
        {
            get { return this.depthFunction; }
            set { this.depthFunction = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether stencil testing is enabled.
        /// </summary>
        public bool IsStencilEnabled
        {
            get { return this.isStencilEnabled; }
            set { this.isStencilEnabled = value; }
        }

        /// <summary>
        /// Gets or sets a portion of the depth-stencil buffer for reading stencil data.
        /// </summary>
        public byte StencilReadMask
        {
            get { return this.stencilReadMask; }
            set { this.stencilReadMask = value; }
        }

        /// <summary>
        /// Gets or sets a portion of the depth-stencil buffer for writing stencil data.
        /// </summary>
        public byte StencilWriteMask
        {
            get { return this.stencilWriteMask; }
            set { this.stencilWriteMask = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating how to use the results of the depth test and the stencil test for pixels whose surface normal is facing towards the camera.
        /// </summary>
        public D3D11DepthStencilOperationDesc FrontFace
        {
            get { return this.frontFace; }
            set { this.frontFace = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating how to use the results of the depth test and the stencil test for pixels whose surface normal is facing away from the camera.
        /// </summary>
        public D3D11DepthStencilOperationDesc BackFace
        {
            get { return this.backFace; }
            set { this.backFace = value; }
        }

        /// <summary>
        /// Compares two <see cref="D3D11DepthStencilDesc"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11DepthStencilDesc"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11DepthStencilDesc"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D3D11DepthStencilDesc left, D3D11DepthStencilDesc right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D3D11DepthStencilDesc"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11DepthStencilDesc"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11DepthStencilDesc"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D3D11DepthStencilDesc left, D3D11DepthStencilDesc right)
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
            if (!(obj is D3D11DepthStencilDesc))
            {
                return false;
            }

            return this.Equals((D3D11DepthStencilDesc)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D3D11DepthStencilDesc other)
        {
            return this.isDepthEnabled == other.isDepthEnabled
                && this.depthWriteMask == other.depthWriteMask
                && this.depthFunction == other.depthFunction
                && this.isStencilEnabled == other.isStencilEnabled
                && this.stencilReadMask == other.stencilReadMask
                && this.stencilWriteMask == other.stencilWriteMask
                && this.frontFace == other.frontFace
                && this.backFace == other.backFace;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.isDepthEnabled,
                this.depthWriteMask,
                this.depthFunction,
                this.isStencilEnabled,
                this.stencilReadMask,
                this.stencilWriteMask,
                this.frontFace,
                this.backFace
            }
            .GetHashCode();
        }
    }
}
