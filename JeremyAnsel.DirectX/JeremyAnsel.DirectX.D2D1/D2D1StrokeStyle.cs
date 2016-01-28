// <copyright file="D2D1StrokeStyle.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using JeremyAnsel.DirectX.D2D1.ComInterfaces;

    /// <summary>
    /// Describes the caps, miter limit, line join, and dash information for a stroke.
    /// </summary>
    public sealed class D2D1StrokeStyle : D2D1Resource
    {
        /// <summary>
        /// The D2D1 stroke style interface.
        /// </summary>
        private ID2D1StrokeStyle strokeStyle;

        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1StrokeStyle"/> class.
        /// </summary>
        /// <param name="strokeStyle">A D2D1 stroke style interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D2D1StrokeStyle(ID2D1StrokeStyle strokeStyle)
        {
            this.strokeStyle = strokeStyle;
        }

        /// <summary>
        /// Gets an handle representing the D2D1 object interface.
        /// </summary>
        public override object Handle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.strokeStyle; }
        }

        /// <summary>
        /// Gets the type of shape used at the beginning of a stroke.
        /// </summary>
        public D2D1CapStyle StartCap
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.strokeStyle.GetStartCap(); }
        }

        /// <summary>
        /// Gets the type of shape used at the end of a stroke.
        /// </summary>
        public D2D1CapStyle EndCap
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.strokeStyle.GetEndCap(); }
        }

        /// <summary>
        /// Gets a value that specifies how the ends of each dash are drawn.
        /// </summary>
        public D2D1CapStyle DashCap
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.strokeStyle.GetDashCap(); }
        }

        /// <summary>
        /// Gets the limit on the ratio of the miter length to half the stroke's thickness.
        /// </summary>
        public float MiterLimit
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.strokeStyle.GetMiterLimit(); }
        }

        /// <summary>
        /// Gets the type of joint used at the vertices of a shape's outline.
        /// </summary>
        public D2D1LineJoin LineJoin
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.strokeStyle.GetLineJoin(); }
        }

        /// <summary>
        /// Gets a value that specifies how far in the dash sequence the stroke will start.
        /// </summary>
        public float DashOffset
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.strokeStyle.GetDashOffset(); }
        }

        /// <summary>
        /// Gets a value that describes the stroke's dash pattern.
        /// </summary>
        public D2D1DashStyle DashStyle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.strokeStyle.GetDashStyle(); }
        }

        /// <summary>
        /// Retrieves the number of entries in the dashes array.
        /// </summary>
        /// <returns>The number of entries in the dashes array if the stroke is dashed; otherwise, 0.</returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint GetDashesCount()
        {
            return this.strokeStyle.GetDashesCount();
        }

        /// <summary>
        /// Copies the dash pattern to the specified array.
        /// </summary>
        /// <returns>An array that will receive the dash pattern.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float[] GetDashes()
        {
            uint count = this.strokeStyle.GetDashesCount();

            float[] dashes = new float[count];
            this.strokeStyle.GetDashes(dashes, count);

            return dashes;
        }
    }
}
