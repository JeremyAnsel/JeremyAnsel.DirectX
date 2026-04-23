// <copyright file="XMComparisonRecord.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.DXMath;

/// <summary>
/// A comparison value.
/// </summary>
[SkipLocalsInit]
public struct XMComparisonRecord : IEquatable<XMComparisonRecord>
{
    /// <summary>
    /// Mask to get a comparison result.
    /// </summary>
    public const uint Mask = 0x000000F0;

    /// <summary>
    /// Mask to get a comparison result, and verify if it is a logical true.
    /// </summary>
    public const uint MaskTrue = 0x00000080;

    /// <summary>
    /// Mask to get a comparison result, and verify if it is a logical false.
    /// </summary>
    public const uint MaskFalse = 0x00000020;

    /// <summary>
    /// Mask to get a comparison result, and verify if the result indicates that some of the inputs were out of bounds.
    /// </summary>
    public const uint MaskBounds = MaskFalse;

    /// <summary>
    /// The comparison record.
    /// </summary>
    private readonly uint record;

    /// <summary>
    /// Initializes a new instance of the <see cref="XMComparisonRecord"/> struct.
    /// </summary>
    /// <param name="record">A comparison record.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public XMComparisonRecord(uint record)
    {
        this.record = record;
    }

    /// <summary>
    /// Gets a value indicating whether all of the compared components are true.
    /// </summary>
    public bool IsAllTrue
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { return (this.record & MaskTrue) == MaskTrue; }
    }

    /// <summary>
    /// Gets a value indicating whether any of the compared components are true
    /// </summary>
    public bool IsAnyTrue
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { return (this.record & MaskFalse) != MaskFalse; }
    }

    /// <summary>
    /// Gets a value indicating whether all of the compared components are false.
    /// </summary>
    public bool IsAllFalse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { return (this.record & MaskFalse) == MaskFalse; }
    }

    /// <summary>
    /// Gets a value indicating whether any of the compared components are false.
    /// </summary>
    public bool IsAnyFalse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { return (this.record & MaskTrue) != MaskTrue; }
    }

    /// <summary>
    /// Gets a value indicating whether the compared components had mixed results: some true and some false.
    /// </summary>
    public bool IsMixed
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { return (this.record & Mask) == 0; }
    }

    /// <summary>
    /// Gets a value indicating whether all of the compared components are within set bounds.
    /// </summary>
    public bool IsAllInBounds
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { return (this.record & MaskBounds) == MaskBounds; }
    }

    /// <summary>
    /// Gets a value indicating whether any of the compared components are outside the set bounds.
    /// </summary>
    public bool IsAnyOutOfBounds
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { return (this.record & MaskBounds) != MaskBounds; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(XMComparisonRecord left, XMComparisonRecord right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(XMComparisonRecord left, XMComparisonRecord right)
    {
        return !(left == right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public readonly override bool Equals(object? obj)
    {
        return obj is XMComparisonRecord record && Equals(record);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(XMComparisonRecord other)
    {
        return record == other.record;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        return 1307964588 + record.GetHashCode();
    }
}
