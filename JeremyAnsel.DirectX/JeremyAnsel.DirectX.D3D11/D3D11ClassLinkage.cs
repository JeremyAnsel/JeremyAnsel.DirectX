// <copyright file="D3D11ClassLinkage.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System.Runtime.CompilerServices;
    using JeremyAnsel.DirectX.D3D11.ComInterfaces;

    /// <summary>
    /// This interface encapsulates an HLSL dynamic linkage.
    /// </summary>
    public sealed class D3D11ClassLinkage : D3D11DeviceChild
    {
        /// <summary>
        /// The D3D11 class linkage interface.
        /// </summary>
        private readonly ID3D11ClassLinkage classLinkage;

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11ClassLinkage"/> class.
        /// </summary>
        /// <param name="classLinkage">A D3D11 class linkage interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D3D11ClassLinkage(ID3D11ClassLinkage classLinkage)
        {
            this.classLinkage = classLinkage;
        }

        /// <summary>
        /// Gets an handle representing the D3D11 object interface.
        /// </summary>
        public override object Handle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.classLinkage; }
        }

        /// <summary>
        /// Gets the class-instance object that represents the specified HLSL class.
        /// </summary>
        /// <param name="name">The name of a class for which to get the class instance.</param>
        /// <param name="index">The index of the class instance.</param>
        /// <returns>A class instance interface.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11ClassInstance GetClassInstance(string name, uint index)
        {
            return new D3D11ClassInstance(this.classLinkage.GetClassInstance(name, index));
        }

        /// <summary>
        /// Initializes a class-instance object that represents an HLSL class instance.
        /// </summary>
        /// <param name="classTypeName">The type name of a class to initialize.</param>
        /// <param name="constantBufferOffset">Identifies the constant buffer that contains the class data.</param>
        /// <param name="constantVectorOffset">The four-component vector offset from the start of the constant buffer where the class data will begin. Consequently, this is not a byte offset.</param>
        /// <param name="textureOffset">The texture slot for the first texture; there may be multiple textures following the offset.</param>
        /// <param name="samplerOffset">The sampler slot for the first sampler; there may be multiple samplers following the offset.</param>
        /// <returns>A class instance interface.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11ClassInstance CreateClassInstance(
            string classTypeName,
            uint constantBufferOffset,
            uint constantVectorOffset,
            uint textureOffset,
            uint samplerOffset)
        {
            return new D3D11ClassInstance(this.classLinkage.CreateClassInstance(
                classTypeName,
                constantBufferOffset,
                constantVectorOffset,
                textureOffset,
                samplerOffset));
        }
    }
}
