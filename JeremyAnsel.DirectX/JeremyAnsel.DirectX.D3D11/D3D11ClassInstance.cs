// <copyright file="D3D11ClassInstance.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using System.Text;
    using JeremyAnsel.DirectX.D3D11.ComInterfaces;

    /// <summary>
    /// This interface encapsulates an HLSL class.
    /// </summary>
    public sealed class D3D11ClassInstance : D3D11DeviceChild
    {
        /// <summary>
        /// The D3D11 class instance interface.
        /// </summary>
        private ID3D11ClassInstance classInstance;

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11ClassInstance"/> class.
        /// </summary>
        /// <param name="classInstance">A D3D11 class instance interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D3D11ClassInstance(ID3D11ClassInstance classInstance)
        {
            this.classInstance = classInstance;
        }

        /// <summary>
        /// Gets an handle representing the D3D11 object interface.
        /// </summary>
        public override object Handle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.classInstance; }
        }

        /// <summary>
        /// Gets a description of the current HLSL class.
        /// </summary>
        public D3D11ClassInstanceDesc Description
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                D3D11ClassInstanceDesc desc;
                this.classInstance.GetDesc(out desc);
                return desc;
            }
        }

        /// <summary>
        /// Gets the instance name of the current HLSL class.
        /// </summary>
        public string InstanceName
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                UIntPtr length = new UIntPtr(256);
                StringBuilder name = new StringBuilder(256);
                this.classInstance.GetInstanceName(name, ref length);
                return name.ToString();
            }
        }

        /// <summary>
        /// Gets the type of the current HLSL class.
        /// </summary>
        public string TypeName
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                UIntPtr length = new UIntPtr(256);
                StringBuilder name = new StringBuilder(256);
                this.classInstance.GetTypeName(name, ref length);
                return name.ToString();
            }
        }

        /// <summary>
        /// Gets the <see cref="D3D11ClassLinkage"/> object associated with the current HLSL class.
        /// </summary>
        /// <returns>A class linkage object.</returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11ClassLinkage GetClassLinkage()
        {
            ID3D11ClassLinkage linkage;
            this.classInstance.GetClassLinkage(out linkage);
            return new D3D11ClassLinkage(linkage);
        }
    }
}
