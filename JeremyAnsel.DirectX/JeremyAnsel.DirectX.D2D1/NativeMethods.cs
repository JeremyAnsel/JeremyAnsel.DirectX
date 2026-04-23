// <copyright file="NativeMethods.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D2D1.ComInterfaces;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.D2D1;

/// <summary>
/// Native methods.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
internal static unsafe partial class NativeMethods
{
    /// <summary>
    /// Creates a factory object that can be used to create Direct2D resources.
    /// </summary>
    /// <param name="factoryType">The threading model of the factory and the resources it creates.</param>
    /// <param name="riid">A reference to the IID of <see cref="ID2D1Factory"/></param>
    /// <param name="factoryOptions">The level of detail provided to the debugging layer.</param>
    /// <param name="factory">The new factory.</param>
#if NET8_0_OR_GREATER
    [LibraryImport("D2d1.dll", EntryPoint = "D2D1CreateFactory")]
    public static partial int D2D1CreateFactory(
#else
    [DllImport("D2d1.dll", EntryPoint = "D2D1CreateFactory")]
    public static extern int D2D1CreateFactory(
#endif
        D2D1FactoryType factoryType,
        in Guid riid,
        void* factoryOptions,
        nint* factory);

    /// <summary>
    /// Creates a rotation transformation that rotates by the specified angle about the specified point.
    /// </summary>
    /// <param name="angle">The clockwise rotation angle, in degrees.</param>
    /// <param name="center">The point about which to rotate.</param>
    /// <param name="matrix">The new rotation transformation.</param>
#if NET8_0_OR_GREATER
    [LibraryImport("D2d1.dll", EntryPoint = "D2D1MakeRotateMatrix")]
    public static partial void D2D1MakeRotateMatrix(
#else
    [DllImport("D2d1.dll", EntryPoint = "D2D1MakeRotateMatrix")]
    public static extern void D2D1MakeRotateMatrix(
#endif
        float angle,
        D2D1Point2F center,
        out D2D1Matrix3X2F matrix);

    /// <summary>
    /// Creates a skew transformation that has the specified x-axis angle, y-axis angle, and center point.
    /// </summary>
    /// <param name="angleX">The x-axis skew angle, which is measured in degrees counterclockwise from the y-axis.</param>
    /// <param name="angleY">The y-axis skew angle, which is measured in degrees counterclockwise from the x-axis.</param>
    /// <param name="center">The center point of the skew operation.</param>
    /// <param name="matrix">The rotation transformation.</param>
#if NET8_0_OR_GREATER
    [LibraryImport("D2d1.dll", EntryPoint = "D2D1MakeSkewMatrix")]
    public static partial void D2D1MakeSkewMatrix(
#else
    [DllImport("D2d1.dll", EntryPoint = "D2D1MakeSkewMatrix")]
    public static extern void D2D1MakeSkewMatrix(
#endif
        float angleX,
        float angleY,
        D2D1Point2F center,
        out D2D1Matrix3X2F matrix);

    /// <summary>
    /// Indicates whether the specified matrix is invertible.
    /// </summary>
    /// <param name="matrix">The matrix to test.</param>
    /// <returns>true if the matrix was inverted; otherwise, false.</returns>
#if NET8_0_OR_GREATER
    [LibraryImport("D2d1.dll", EntryPoint = "D2D1IsMatrixInvertible")]
    public static partial int D2D1IsMatrixInvertible(
#else
    [DllImport("D2d1.dll", EntryPoint = "D2D1IsMatrixInvertible")]
    public static extern int D2D1IsMatrixInvertible(
#endif
        in D2D1Matrix3X2F matrix);

    /// <summary>
    /// Tries to invert the specified matrix.
    /// </summary>
    /// <param name="matrix">The matrix to invert.</param>
    /// <returns>true if the matrix was inverted; otherwise, false.</returns>
#if NET8_0_OR_GREATER
    [LibraryImport("D2d1.dll", EntryPoint = "D2D1InvertMatrix")]
    public static partial int D2D1InvertMatrix(
#else
    [DllImport("D2d1.dll", EntryPoint = "D2D1InvertMatrix")]
    public static extern int D2D1InvertMatrix(
#endif
        ref D2D1Matrix3X2F matrix);
}
