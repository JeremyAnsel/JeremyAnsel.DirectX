// <copyright file="NativeMethods.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;
    using JeremyAnsel.DirectX.D2D1.ComInterfaces;

    /// <summary>
    /// Native methods.
    /// </summary>
    [SecurityCritical, SuppressUnmanagedCodeSecurity]
    internal static class NativeMethods
    {
        /// <summary>
        /// Creates a factory object that can be used to create Direct2D resources.
        /// </summary>
        /// <param name="factoryType">The threading model of the factory and the resources it creates.</param>
        /// <param name="riid">A reference to the IID of <see cref="ID2D1Factory"/></param>
        /// <param name="factoryOptions">The level of detail provided to the debugging layer.</param>
        /// <param name="factory">The new factory.</param>
        [DllImport("D2d1.dll", EntryPoint = "D2D1CreateFactory", PreserveSig = false)]
        public static extern void D2D1CreateFactory(
            [In] D2D1FactoryType factoryType,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid,
            [In] IntPtr factoryOptions,
            [Out] out ID2D1Factory factory);

        /// <summary>
        /// Creates a rotation transformation that rotates by the specified angle about the specified point.
        /// </summary>
        /// <param name="angle">The clockwise rotation angle, in degrees.</param>
        /// <param name="center">The point about which to rotate.</param>
        /// <param name="matrix">The new rotation transformation.</param>
        [DllImport("D2d1.dll", EntryPoint = "D2D1MakeRotateMatrix")]
        public static extern void D2D1MakeRotateMatrix(
            [In] float angle,
            [In] D2D1Point2F center,
            [Out] out D2D1Matrix3X2F matrix);

        /// <summary>
        /// Creates a skew transformation that has the specified x-axis angle, y-axis angle, and center point.
        /// </summary>
        /// <param name="angleX">The x-axis skew angle, which is measured in degrees counterclockwise from the y-axis.</param>
        /// <param name="angleY">The y-axis skew angle, which is measured in degrees counterclockwise from the x-axis.</param>
        /// <param name="center">The center point of the skew operation.</param>
        /// <param name="matrix">The rotation transformation.</param>
        [DllImport("D2d1.dll", EntryPoint = "D2D1MakeSkewMatrix")]
        public static extern void D2D1MakeSkewMatrix(
            [In] float angleX,
            [In] float angleY,
            [In] D2D1Point2F center,
            [Out] out D2D1Matrix3X2F matrix);

        /// <summary>
        /// Indicates whether the specified matrix is invertible.
        /// </summary>
        /// <param name="matrix">The matrix to test.</param>
        /// <returns>true if the matrix was inverted; otherwise, false.</returns>
        [DllImport("D2d1.dll", EntryPoint = "D2D1IsMatrixInvertible")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool D2D1IsMatrixInvertible(
            [In] ref D2D1Matrix3X2F matrix);

        /// <summary>
        /// Tries to invert the specified matrix.
        /// </summary>
        /// <param name="matrix">The matrix to invert.</param>
        /// <returns>true if the matrix was inverted; otherwise, false.</returns>
        [DllImport("D2d1.dll", EntryPoint = "D2D1InvertMatrix")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool D2D1InvertMatrix(
            [In, Out] ref D2D1Matrix3X2F matrix);
    }
}
