// <copyright file="DxgiOutputDesc.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

namespace JeremyAnsel.DirectX.Dxgi;

/// <summary>
/// Describes an output or physical connection between the adapter (video card) and a device.
/// </summary>
[SkipLocalsInit]
public unsafe struct DxgiOutputDesc : IEquatable<DxgiOutputDesc>
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static int NativeRequiredSize()
    {
        return NativeRequiredSize(1);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="count"></param>
    /// <returns></returns>
    public static int NativeRequiredSize(int count)
    {
        int size = 0;
        size += Buffer32.TotalSize;
        size += DxgiRect.NativeRequiredSize();
        size += sizeof(int); // bool
        size += sizeof(int); // enum
        size += sizeof(nint);
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in DxgiOutputDesc obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<DxgiOutputDesc>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<DxgiOutputDesc> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            fixed (char* ptr = obj.deviceName.Buffer)
            {
                DXMarshal.Write(ref buffer, new ReadOnlySpan<char>(ptr, Buffer32.Length));
            }

            DxgiRect.NativeWriteTo(buffer, obj.desktopCoordinates);
            buffer += DxgiRect.NativeRequiredSize();
            DXMarshal.Write(ref buffer, obj.isAttachedToDesktop);
            DXMarshal.Write(ref buffer, (int)obj.rotation);
            DXMarshal.Write(ref buffer, obj.monitor);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static DxgiOutputDesc NativeReadFrom(nint buffer)
    {
        DxgiOutputDesc obj;
        DXMarshal.ReadSpanChar(ref buffer, new Span<char>(obj.deviceName.Buffer, Buffer32.Length));
        obj.desktopCoordinates = DxgiRect.NativeReadFrom(buffer);
        buffer += DxgiRect.NativeRequiredSize();
        obj.isAttachedToDesktop = DXMarshal.ReadBool(ref buffer);
        obj.rotation = (DxgiModeRotation)DXMarshal.ReadInt32(ref buffer);
        obj.monitor = DXMarshal.ReadIntPtr(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<DxgiOutputDesc> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    private struct Buffer32
    {
        public fixed char Buffer[Length];
        public const int Length = 32;
        public const int TotalSize = sizeof(char) * Length;
    }

    /// <summary>
    /// A string that contains the name of the output device.
    /// </summary>
    private Buffer32 deviceName;

    /// <summary>
    /// A <see cref="DxgiRect"/> structure containing the bounds of the output in desktop coordinates. Desktop coordinates depend on the dots per inch (DPI) of the desktop.
    /// </summary>
    private DxgiRect desktopCoordinates;

    /// <summary>
    /// <value>true</value> if the output is attached to the desktop; otherwise, <value>false</value>.
    /// </summary>
    private bool isAttachedToDesktop;

    /// <summary>
    /// A member of the <see cref="DxgiModeRotation"/> enumeration describing on how an image is rotated by the output.
    /// </summary>
    private DxgiModeRotation rotation;

    /// <summary>
    /// An handle that represents the display monitor.
    /// </summary>
    private nint monitor;

    /// <summary>
    /// Gets a string that contains the name of the output device.
    /// </summary>
    public readonly string DeviceName
    {
        get
        {
            fixed (char* ptr = this.deviceName.Buffer)
            {
                return new string(ptr);
            }
        }
    }

    /// <summary>
    /// Gets a string as span that contains the name of the output device.
    /// </summary>
    public readonly ReadOnlySpan<char> GetDeviceNameAsSpan()
    {
        fixed (char* ptrThis = deviceName.Buffer)
        {
            int count = DXMarshal.GetNullTerminatedStringCountUni((nint)ptrThis);
            return new ReadOnlySpan<char>(ptrThis, count);
        }
    }

    /// <summary>
    /// Gets the maximum char count of the string that contains the adapter description.
    /// </summary>
    public const int DeviceNameMaxLength = Buffer32.Length;

    /// <summary>
    /// Gets the char count of the string that contains the adapter description. On feature level 9 graphics hardware, “Software Adapter”.
    /// </summary>
    /// <returns></returns>
    public readonly int GetDeviceNameCharCount()
    {
        fixed (char* ptr = this.deviceName.Buffer)
        {
            return DXMarshal.GetNullTerminatedStringCountUni((nint)ptr);
        }
    }

    /// <summary>
    /// Gets the chars of the string that contains the adapter description. On feature level 9 graphics hardware, “Software Adapter”.
    /// </summary>
    /// <param name="desc"></param>
    public readonly void GetDeviceNameChars(Span<char> desc)
    {
        fixed (char* ptr = this.deviceName.Buffer)
        fixed (char* descPtr = desc)
        {
            int count = DXMarshal.GetNullTerminatedStringCountUni((nint)ptr);
            count = Math.Min(count, desc.Length);
            int length = Encoding.Unicode.GetChars((byte*)ptr, count * 2, descPtr, desc.Length);
            for (int i = length; i < desc.Length; i++)
            {
                descPtr[i] = (char)0;
            }
        }
    }

    /// <summary>
    /// Gets a <see cref="DxgiRect"/> structure containing the bounds of the output in desktop coordinates. Desktop coordinates depend on the dots per inch (DPI) of the desktop.
    /// </summary>
    public readonly DxgiRect DesktopCoordinates
    {
        get { return this.desktopCoordinates; }
    }

    /// <summary>
    /// Gets a value indicating whether the output is attached to the desktop.
    /// </summary>
    public readonly bool IsAttachedToDesktop
    {
        get { return this.isAttachedToDesktop; }
    }

    /// <summary>
    /// Gets a member of the <see cref="DxgiModeRotation"/> enumeration describing on how an image is rotated by the output.
    /// </summary>
    public readonly DxgiModeRotation Rotation
    {
        get { return this.rotation; }
    }

    /// <summary>
    /// Gets an handle that represents the display monitor.
    /// </summary>
    public readonly nint Monitor
    {
        get { return this.monitor; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(DxgiOutputDesc left, DxgiOutputDesc right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(DxgiOutputDesc left, DxgiOutputDesc right)
    {
        return !(left == right);
    }

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public readonly override string ToString()
    {
        return string.Format(
            CultureInfo.InvariantCulture,
            "{0} {1} {2} {3}",
            this.deviceName,
            this.isAttachedToDesktop ? "AttachedToDesktop" : "NotAttachedToDesktop",
            this.desktopCoordinates,
            this.rotation);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public readonly override bool Equals(object? obj)
    {
        return obj is DxgiOutputDesc desc && Equals(desc);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(DxgiOutputDesc other)
    {
        fixed (char* ptrThis = deviceName.Buffer)
        {
            ReadOnlySpan<char> spanThis = new(ptrThis, Buffer32.Length);
            ReadOnlySpan<char> spanOther = new(other.deviceName.Buffer, Buffer32.Length);

            return MemoryExtensions.Equals(spanThis, spanOther, StringComparison.Ordinal) &&
                desktopCoordinates.Equals(other.desktopCoordinates) &&
                isAttachedToDesktop == other.isAttachedToDesktop &&
                rotation == other.rotation &&
                monitor == other.monitor;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = -1207797634;
        hashCode = hashCode * -1521134295 + deviceName.GetHashCode();
        hashCode = hashCode * -1521134295 + desktopCoordinates.GetHashCode();
        hashCode = hashCode * -1521134295 + isAttachedToDesktop.GetHashCode();
        hashCode = hashCode * -1521134295 + rotation.GetHashCode();
        hashCode = hashCode * -1521134295 + monitor.GetHashCode();
        return hashCode;
    }
}
