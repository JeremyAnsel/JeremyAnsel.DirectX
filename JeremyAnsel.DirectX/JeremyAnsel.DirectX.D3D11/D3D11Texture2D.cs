// <copyright file="D3D11Texture2D.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using JeremyAnsel.DirectX.D3D11.ComInterfaces;
    using JeremyAnsel.DirectX.Dxgi;

    /// <summary>
    /// A 2D texture interface manages texel data, which is structured memory.
    /// </summary>
    public sealed class D3D11Texture2D : D3D11Resource
    {
        /// <summary>
        /// The D3D11 texture 2D interface.
        /// </summary>
        private readonly ID3D11Texture2D texture2D;

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11Texture2D"/> class.
        /// </summary>
        /// <param name="texture2D">A D3D11 texture 2D interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D3D11Texture2D(ID3D11Texture2D texture2D)
        {
            this.texture2D = texture2D;
        }

        /// <summary>
        /// Gets an handle representing the D3D11 object interface.
        /// </summary>
        public override object Handle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.texture2D; }
        }

        /// <summary>
        /// Gets the properties of the texture resource.
        /// </summary>
        public D3D11Texture2DDesc Description
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
            get
            {
                this.texture2D.GetDesc(out D3D11Texture2DDesc desc);
                return desc;
            }
        }

        /// <summary>
        /// Gets the handle to a shared resource.
        /// </summary>
        /// <returns>A handle.</returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Reviewed")]
        public IntPtr GetSharedHandle()
        {
            using var resource = new DxgiResource(this.texture2D);
            IntPtr handle = resource.GetSharedHandle();
            return handle;
        }
    }
}
