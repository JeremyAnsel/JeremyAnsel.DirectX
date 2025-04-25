// <copyright file="D3D11Buffer.cs" company="Jérémy Ansel">
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
    /// A buffer interface accesses a buffer resource, which is unstructured memory.
    /// </summary>
    public sealed class D3D11Buffer : D3D11Resource
    {
        /// <summary>
        /// The D3D11 buffer interface.
        /// </summary>
        private readonly ID3D11Buffer buffer;

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11Buffer"/> class.
        /// </summary>
        /// <param name="resource">A resource interface which implements the <c>ID3D11Buffer</c> interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11Buffer(object resource)
        {
            IntPtr ptr = Marshal.GetIUnknownForObject(resource);

            try
            {
                this.buffer = (ID3D11Buffer)Marshal.GetObjectForIUnknown(ptr);
            }
            finally
            {
                Marshal.Release(ptr);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11Buffer"/> class.
        /// </summary>
        /// <param name="buffer">A D3D11 buffer interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D3D11Buffer(ID3D11Buffer buffer)
        {
            this.buffer = buffer;
        }

        /// <summary>
        /// Gets an handle representing the D3D11 object interface.
        /// </summary>
        public override object Handle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.buffer; }
        }

        /// <summary>
        /// Gets the properties of a buffer resource.
        /// </summary>
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public D3D11BufferDesc Description
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                this.buffer.GetDesc(out D3D11BufferDesc desc);
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
            var resource = new DxgiResource(this.buffer);
            IntPtr handle = resource.GetSharedHandle();
            return handle;
        }
    }
}
