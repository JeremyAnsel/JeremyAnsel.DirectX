// <copyright file="D3D11GeometryShader.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System.Runtime.CompilerServices;
    using JeremyAnsel.DirectX.D3D11.ComInterfaces;

    /// <summary>
    /// A geometry shader interface manages an executable program (a geometry shader) that controls the geometry shader stage.
    /// </summary>
    public sealed class D3D11GeometryShader : D3D11DeviceChild
    {
        /// <summary>
        /// The D3D11 geometry shader interface.
        /// </summary>
        private ID3D11GeometryShader geometryShader;

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11GeometryShader"/> class.
        /// </summary>
        /// <param name="geometryShader">A D3D11 geometry shader interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D3D11GeometryShader(ID3D11GeometryShader geometryShader)
        {
            this.geometryShader = geometryShader;
        }

        /// <summary>
        /// Gets an handle representing the D3D11 object interface.
        /// </summary>
        public override object Handle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.geometryShader; }
        }
    }
}
