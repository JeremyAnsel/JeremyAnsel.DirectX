// <copyright file="DxgiComputePreemptionGranularity.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    /// <summary>
    /// Identifies the granularity at which the graphics processing unit (GPU) can be preempted from performing its current compute task.
    /// </summary>
    public enum DxgiComputePreemptionGranularity
    {
        /// <summary>
        /// Indicates the preemption granularity as a compute packet.
        /// </summary>
        DmaBufferBoundary,

        /// <summary>
        /// Indicates the preemption granularity as a dispatch. A dispatch is a part of a compute packet.
        /// </summary>
        DispatchBoundary,

        /// <summary>
        /// Indicates the preemption granularity as a thread group. A thread group is a part of a dispatch.
        /// </summary>
        ThreadGroupBoundary,

        /// <summary>
        /// Indicates the preemption granularity as a thread in a thread group. A thread is a part of a thread group.
        /// </summary>
        ThreadBoundary,

        /// <summary>
        /// Indicates the preemption granularity as a compute instruction in a thread.
        /// </summary>
        InstructionBoundary
    }
}
