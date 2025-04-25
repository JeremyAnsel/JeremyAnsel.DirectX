// <copyright file="D3D11Texture3D.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using JeremyAnsel.DirectX.D3D11.ComInterfaces;
    using JeremyAnsel.DirectX.Dxgi;

    /// <summary>
    /// A 3D texture interface accesses texel data, which is structured memory.
    /// </summary>
    public sealed class D3D11Texture3D : D3D11Resource
    {
        /// <summary>
        /// The D3D11 texture 3D interface.
        /// </summary>
        private readonly ID3D11Texture3D texture3D;

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11Texture3D"/> class.
        /// </summary>
        /// <param name="resource">A resource interface which implements the <c>ID3D11Texture3D</c> interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11Texture3D(object resource)
        {
            IntPtr ptr = Marshal.GetIUnknownForObject(resource);

            try
            {
                this.texture3D = (ID3D11Texture3D)Marshal.GetObjectForIUnknown(ptr);
            }
            finally
            {
                Marshal.Release(ptr);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11Texture3D"/> class.
        /// </summary>
        /// <param name="texture3D">A D3D11 texture 3D interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D3D11Texture3D(ID3D11Texture3D texture3D)
        {
            this.texture3D = texture3D;
        }

        /// <summary>
        /// Gets an handle representing the D3D11 object interface.
        /// </summary>
        public override object Handle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.texture3D; }
        }

        /// <summary>
        /// Gets the properties of the texture resource.
        /// </summary>
        public D3D11Texture3DDesc Description
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
            get
            {
                this.texture3D.GetDesc(out D3D11Texture3DDesc desc);
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
            var resource = new DxgiResource(this.texture3D);
            IntPtr handle = resource.GetSharedHandle();
            return handle;
        }
    }
}
