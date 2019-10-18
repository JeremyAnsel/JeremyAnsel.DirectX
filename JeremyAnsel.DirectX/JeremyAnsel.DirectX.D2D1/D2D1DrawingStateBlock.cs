// <copyright file="D2D1DrawingStateBlock.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using JeremyAnsel.DirectX.D2D1.ComInterfaces;
    using JeremyAnsel.DirectX.D2D1.ComInteropInterfaces;
    using JeremyAnsel.DirectX.DWrite;

    /// <summary>
    /// Represents the drawing state of a render target: the antialiasing mode, transform, tags, and text-rendering options.
    /// </summary>
    public sealed class D2D1DrawingStateBlock : D2D1Resource
    {
        /// <summary>
        /// The D2D1 drawing state block interface.
        /// </summary>
        private readonly ID2D1DrawingStateBlock drawingStateBlock;

        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1DrawingStateBlock"/> class.
        /// </summary>
        /// <param name="drawingStateBlock">A D2D1 drawing state block interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D2D1DrawingStateBlock(ID2D1DrawingStateBlock drawingStateBlock)
        {
            this.drawingStateBlock = drawingStateBlock;
        }

        /// <summary>
        /// Gets an handle representing the D2D1 object interface.
        /// </summary>
        public override object Handle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.drawingStateBlock; }
        }

        /// <summary>
        /// Gets or sets the antialiasing mode, transform, and tags portion of the drawing state.
        /// </summary>
        public D2D1DrawingStateDescription Description
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
            get
            {
                D2D1DrawingStateDescription stateDescription;
                this.drawingStateBlock.GetDescription(out stateDescription);
                return stateDescription;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
            set
            {
                this.drawingStateBlock.SetDescription(ref value);
            }
        }

        /// <summary>
        /// Gets or sets the text-rendering configuration of the drawing state.
        /// </summary>
        public DWriteRenderingParams TextRenderingParams
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
            get
            {
                IDWriteRenderingParams textRenderingParams;
                this.drawingStateBlock.GetTextRenderingParams(out textRenderingParams);

                if (textRenderingParams == null)
                {
                    return null;
                }

                return new DWriteRenderingParams(textRenderingParams);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
            set
            {
                this.drawingStateBlock.SetTextRenderingParams(value == null ? null : (IDWriteRenderingParams)value.Handle);
            }
        }
    }
}
