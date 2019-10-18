// <copyright file="D2D1Brush.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using JeremyAnsel.DirectX.D2D1.ComInterfaces;

    /// <summary>
    /// The root brush interface. All brushes can be used to fill or pen a geometry.
    /// </summary>
    public abstract class D2D1Brush : D2D1Resource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1Brush"/> class.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D2D1Brush()
        {
        }

        /// <summary>
        /// Gets or sets the degree of opacity of this brush.
        /// </summary>
        public float Opacity
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.GetHandle<ID2D1Brush>().GetOpacity(); }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
            set { this.GetHandle<ID2D1Brush>().SetOpacity(value); }
        }

        /// <summary>
        /// Gets or sets the transform applied to this brush.
        /// </summary>
        public D2D1Matrix3X2F Transform
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
            get
            {
                D2D1Matrix3X2F transform;
                this.GetHandle<ID2D1Brush>().GetTransform(out transform);
                return transform;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
            set
            {
                this.GetHandle<ID2D1Brush>().SetTransform(ref value);
            }
        }
    }
}
