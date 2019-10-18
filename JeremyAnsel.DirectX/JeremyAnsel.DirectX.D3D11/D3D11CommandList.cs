// <copyright file="D3D11CommandList.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System.Runtime.CompilerServices;
    using JeremyAnsel.DirectX.D3D11.ComInterfaces;

    /// <summary>
    /// Encapsulates a list of graphics commands for play back.
    /// </summary>
    public sealed class D3D11CommandList : D3D11DeviceChild
    {
        /// <summary>
        /// The D3D11 command list interface.
        /// </summary>
        private ID3D11CommandList commandList;

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11CommandList"/> class.
        /// </summary>
        /// <param name="commandList">A D3D11 command list interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D3D11CommandList(ID3D11CommandList commandList)
        {
            this.commandList = commandList;
        }

        /// <summary>
        /// Gets an handle representing the D3D11 object interface.
        /// </summary>
        public override object Handle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.commandList; }
        }
    }
}
