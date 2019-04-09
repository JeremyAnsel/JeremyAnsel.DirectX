// <copyright file="D3D11QueryType.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    /// <summary>
    /// Query types.
    /// </summary>
    public enum D3D11QueryType
    {
        /// <summary>
        /// Determines whether or not the GPU is finished processing commands.
        /// </summary>
        Event,

        /// <summary>
        /// Get the number of samples that passed the depth and stencil tests in between <see cref="D3D11DeviceContext.Begin"/> and <see cref="D3D11DeviceContext.End"/>.
        /// </summary>
        Occlusion,

        /// <summary>
        /// Get a timestamp value.
        /// </summary>
        Timestamp,

        /// <summary>
        /// Determines whether or not a <see cref="D3D11QueryType.Timestamp"/> is returning reliable values, and also gives the frequency of the processor enabling you to convert the number of elapsed ticks into seconds.
        /// </summary>
        TimestampDisjoint,

        /// <summary>
        /// Get pipeline statistics, such as the number of pixel shader invocations in between <see cref="D3D11DeviceContext.Begin"/> and <see cref="D3D11DeviceContext.End"/>.
        /// </summary>
        PipelineStatistics,

        /// <summary>
        /// Similar to <see cref="D3D11QueryType.Occlusion"/>, except <see cref="D3D11DeviceContext.GetData"/> returns a BOOL indicating whether or not any samples passed the depth and stencil tests - <c>TRUE</c> meaning at least one passed, <c>FALSE</c> meaning none passed.
        /// </summary>
        OcclusionPredicate,

        /// <summary>
        /// Get streaming output statistics.
        /// </summary>
        StreamOutputStatistics,

        /// <summary>
        /// Determines whether or not any of the streaming output buffers overflowed in between <see cref="D3D11DeviceContext.Begin"/> and <see cref="D3D11DeviceContext.End"/>.
        /// </summary>
        StreamOutputOverflowPredicate,

        /// <summary>
        /// Get streaming output statistics for stream 0.
        /// </summary>
        StreamOutputStatisticsStream0,

        /// <summary>
        /// Determines whether or not the stream 0 output buffers overflowed in between <see cref="D3D11DeviceContext.Begin"/> and <see cref="D3D11DeviceContext.End"/>.
        /// </summary>
        StreamOutputOverflowPredicateStream0,

        /// <summary>
        /// Get streaming output statistics for stream 1.
        /// </summary>
        StreamOutputStatisticsStream1,

        /// <summary>
        /// Determines whether or not the stream 1 output buffers overflowed in between <see cref="D3D11DeviceContext.Begin"/> and <see cref="D3D11DeviceContext.End"/>.
        /// </summary>
        StreamOutputOverflowPredicateStream1,

        /// <summary>
        /// Get streaming output statistics for stream 2.
        /// </summary>
        StreamOutputStatisticsStream2,

        /// <summary>
        /// Determines whether or not the stream 2 output buffers overflowed in between <see cref="D3D11DeviceContext.Begin"/> and <see cref="D3D11DeviceContext.End"/>.
        /// </summary>
        StreamOutputOverflowPredicateStream2,

        /// <summary>
        /// Get streaming output statistics for stream 3.
        /// </summary>
        StreamOutputStatisticsStream3,

        /// <summary>
        /// Determines whether or not the stream 3 output buffers overflowed in between <see cref="D3D11DeviceContext.Begin"/> and <see cref="D3D11DeviceContext.End"/>.
        /// </summary>
        StreamOutputOverflowPredicateStream3,
    }
}
