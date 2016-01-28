// <copyright file="D2D1FactoryType.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    /// <summary>
    /// Specifies the threading model of the created factory and all of its derived resources.
    /// </summary>
    public enum D2D1FactoryType
    {
        /// <summary>
        /// The resulting factory and derived resources may only be invoked serially.
        /// Reference counts on resources are interlocked, however, resource and render
        /// target state is not protected from multi-threaded access.
        /// </summary>
        SingleThreaded = 0,

        /// <summary>
        /// The resulting factory may be invoked from multiple threads. Returned resources
        /// use interlocked reference counting and their state is protected.
        /// </summary>
        MultiThreaded = 1,
    }
}
