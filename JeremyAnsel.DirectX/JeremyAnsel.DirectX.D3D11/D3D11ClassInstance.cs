﻿// <copyright file="D3D11ClassInstance.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
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
        private readonly ID3D11ClassInstance classInstance;

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
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public D3D11ClassInstanceDesc Description
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                this.classInstance.GetDesc(out D3D11ClassInstanceDesc desc);
                return desc;
            }
        }

        /// <summary>
        /// Gets the instance name of the current HLSL class.
        /// </summary>
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
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
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
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
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11ClassLinkage GetClassLinkage()
        {
            this.classInstance.GetClassLinkage(out ID3D11ClassLinkage linkage);

            if (linkage == null)
            {
                return null;
            }

            return new D3D11ClassLinkage(linkage);
        }
    }
}
