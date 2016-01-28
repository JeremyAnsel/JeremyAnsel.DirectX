// <copyright file="D3D11Asynchronous.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System.Runtime.CompilerServices;
    using JeremyAnsel.DirectX.D3D11.ComInterfaces;

    /// <summary>
    /// This interface encapsulates methods for retrieving data from the GPU asynchronously.
    /// </summary>
    public abstract class D3D11Asynchronous : D3D11DeviceChild
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11Asynchronous"/> class.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D3D11Asynchronous()
        {
        }

        /// <summary>
        /// Gets the size of the data (in bytes) that is output when calling <c>GetData</c>.
        /// </summary>
        public uint DataSize
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.GetHandle<ID3D11Asynchronous>().GetDataSize(); }
        }
    }
}
