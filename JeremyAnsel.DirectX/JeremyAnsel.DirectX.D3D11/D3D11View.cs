// <copyright file="D3D11View.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using JeremyAnsel.DirectX.D3D11.ComInterfaces;

    /// <summary>
    /// A view interface specifies the parts of a resource the pipeline can access during rendering.
    /// </summary>
    public abstract class D3D11View : D3D11DeviceChild
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11View"/> class.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D3D11View()
        {
        }

        /// <summary>
        /// Gets the resource that is accessed through this view.
        /// </summary>
        /// <returns>The resource that is accessed through this view.</returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D3D11Resource GetResource()
        {
            ID3D11Resource resource;
            this.GetHandle<ID3D11View>().GetResource(out resource);

            D3D11ResourceDimension dimension;
            resource.GetDimension(out dimension);

            switch (dimension)
            {
                case D3D11ResourceDimension.Unknown:
                    return null;

                case D3D11ResourceDimension.Buffer:
                    return new D3D11Buffer((ID3D11Buffer)resource);

                case D3D11ResourceDimension.Texture1D:
                    return new D3D11Texture1D((ID3D11Texture1D)resource);

                case D3D11ResourceDimension.Texture2D:
                    return new D3D11Texture2D((ID3D11Texture2D)resource);

                case D3D11ResourceDimension.Texture3D:
                    return new D3D11Texture3D((ID3D11Texture3D)resource);

                default:
                    return null;
            }
        }
    }
}
