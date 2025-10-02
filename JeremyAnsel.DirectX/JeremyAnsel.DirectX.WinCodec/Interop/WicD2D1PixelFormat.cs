using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec;

/// <summary>
/// Contains the data format and alpha mode for a bitmap or render target.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct WicD2D1PixelFormat : IEquatable<WicD2D1PixelFormat>
{
    /// <summary>
    /// A value that specifies the size and arrangement of channels in each pixel.
    /// </summary>
    private WicDxgiFormat format;

    /// <summary>
    /// A value that specifies whether the alpha channel is using pre-multiplied alpha, straight alpha, whether it should be ignored and considered opaque, or whether it is unknown.
    /// </summary>
    private WicD2D1AlphaMode alphaMode;

    /// <summary>
    /// Initializes a new instance of the <see cref="WicD2D1PixelFormat"/> struct.
    /// </summary>
    /// <param name="format">A value that specifies the size and arrangement of channels in each pixel.</param>
    /// <param name="alphaMode">A value that specifies whether the alpha channel is using pre-multiplied alpha, straight alpha, whether it should be ignored and considered opaque, or whether it is unknown.</param>
    public WicD2D1PixelFormat(WicDxgiFormat format, WicD2D1AlphaMode alphaMode)
    {
        this.format = format;
        this.alphaMode = alphaMode;
    }

    /// <summary>
    /// Gets default format (Unknown, Unknown).
    /// </summary>
    public static WicD2D1PixelFormat Default
    {
        get { return new WicD2D1PixelFormat(WicDxgiFormat.Unknown, WicD2D1AlphaMode.Unknown); }
    }

    /// <summary>
    /// Gets or sets a value that specifies the size and arrangement of channels in each pixel.
    /// </summary>
    public WicDxgiFormat Format
    {
        get { return this.format; }
        set { this.format = value; }
    }

    /// <summary>
    /// Gets or sets a value that specifies whether the alpha channel is using pre-multiplied alpha, straight alpha, whether it should be ignored and considered opaque, or whether it is unknown.
    /// </summary>
    public WicD2D1AlphaMode AlphaMode
    {
        get { return this.alphaMode; }
        set { this.alphaMode = value; }
    }

    /// <summary>
    /// Compares two <see cref="WicD2D1PixelFormat"/> objects. The result specifies whether the values of the two objects are equal.
    /// </summary>
    /// <param name="left">The left <see cref="WicD2D1PixelFormat"/> to compare.</param>
    /// <param name="right">The right <see cref="WicD2D1PixelFormat"/> to compare.</param>
    /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
    public static bool operator ==(WicD2D1PixelFormat left, WicD2D1PixelFormat right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// Compares two <see cref="D2D1PixelFormat"/> objects. The result specifies whether the values of the two objects are unequal.
    /// </summary>
    /// <param name="left">The left <see cref="D2D1PixelFormat"/> to compare.</param>
    /// <param name="right">The right <see cref="D2D1PixelFormat"/> to compare.</param>
    /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
    public static bool operator !=(WicD2D1PixelFormat left, WicD2D1PixelFormat right)
    {
        return !(left == right);
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current object.
    /// </summary>
    /// <param name="obj">The object to compare with the current object.</param>
    /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
    public override bool Equals(object? obj)
    {
        if (obj is not WicD2D1PixelFormat)
        {
            return false;
        }

        return this.Equals((WicD2D1PixelFormat)obj);
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current object.
    /// </summary>
    /// <param name="other">The object to compare with the current object.</param>
    /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
    public bool Equals(WicD2D1PixelFormat other)
    {
        return this.format == other.format
            && this.alphaMode == other.alphaMode;
    }

    /// <summary>
    /// Returns the hash code for this instance.
    /// </summary>
    /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
    public override int GetHashCode()
    {
        return new
        {
            this.format,
            this.alphaMode
        }
        .GetHashCode();
    }
}
