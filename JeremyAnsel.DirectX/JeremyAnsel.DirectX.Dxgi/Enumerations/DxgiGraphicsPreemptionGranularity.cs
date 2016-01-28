// <copyright file="DxgiGraphicsPreemptionGranularity.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    /// <summary>
    /// Identifies the granularity at which the graphics processing unit (GPU) can be preempted from performing its current graphics rendering task.
    /// </summary>
    public enum DxgiGraphicsPreemptionGranularity
    {
        /// <summary>
        /// Indicates the preemption granularity as a DMA buffer.
        /// </summary>
        DmaBufferBoundary,

        /// <summary>
        /// Indicates the preemption granularity as a graphics primitive. A primitive is a section in a DMA buffer and can be a group of triangles.
        /// </summary>
        PrimitiveBoundary,

        /// <summary>
        /// Indicates the preemption granularity as a triangle. A triangle is a part of a primitive.
        /// </summary>
        TriangleBoundary,

        /// <summary>
        /// Indicates the preemption granularity as a pixel. A pixel is a part of a triangle.
        /// </summary>
        PixelBoundary,
        
        /// <summary>
        /// Indicates the preemption granularity as a graphics instruction. A graphics instruction operates on a pixel.
        /// </summary>
        InstructionBoundary
    }
}
