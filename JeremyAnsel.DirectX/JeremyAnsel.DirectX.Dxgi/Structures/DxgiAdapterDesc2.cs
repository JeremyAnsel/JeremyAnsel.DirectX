// <copyright file="DxgiAdapterDesc.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;
using System.Text;

namespace JeremyAnsel.DirectX.Dxgi;

/// <summary>
/// Describes an adapter (or video card) that uses Microsoft DirectX Graphics Infrastructure (DXGI) 1.2.
/// </summary>
[SkipLocalsInit]
public unsafe struct DxgiAdapterDesc2 : IEquatable<DxgiAdapterDesc2>
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
        size += Buffer128.TotalSize;
        size += sizeof(uint) * 4;
        size += sizeof(nuint) * 3;
        size += sizeof(ulong);
        size += sizeof(int) * 3;
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in DxgiAdapterDesc2 obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<DxgiAdapterDesc2>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<DxgiAdapterDesc2> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            fixed (char* ptr = obj.adapterDescription.Buffer)
            {
                DXMarshal.Write(ref buffer, new ReadOnlySpan<char>(ptr, Buffer128.Length));
            }

            DXMarshal.Write(ref buffer, obj.vendorId);
            DXMarshal.Write(ref buffer, obj.deviceId);
            DXMarshal.Write(ref buffer, obj.subSysId);
            DXMarshal.Write(ref buffer, obj.revision);
            DXMarshal.Write(ref buffer, obj.dedicatedVideoMemory);
            DXMarshal.Write(ref buffer, obj.dedicatedSystemMemory);
            DXMarshal.Write(ref buffer, obj.sharedSystemMemory);
            DXMarshal.Write(ref buffer, obj.adapterLuid);
            DXMarshal.Write(ref buffer, (int)obj.adapterType);
            DXMarshal.Write(ref buffer, (int)obj.graphicsPreemptionGranularity);
            DXMarshal.Write(ref buffer, (int)obj.computePreemptionGranularity);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static DxgiAdapterDesc2 NativeReadFrom(nint buffer)
    {
        DxgiAdapterDesc2 obj;
        DXMarshal.ReadSpanChar(ref buffer, new Span<char>(obj.adapterDescription.Buffer, Buffer128.Length));
        obj.vendorId = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.deviceId = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.subSysId = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.revision = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.dedicatedVideoMemory = DXMarshal.ReadUnsignedIntPtr(ref buffer);
        obj.dedicatedSystemMemory = DXMarshal.ReadUnsignedIntPtr(ref buffer);
        obj.sharedSystemMemory = DXMarshal.ReadUnsignedIntPtr(ref buffer);
        obj.adapterLuid = DXMarshal.ReadUnsignedInt64(ref buffer);
        obj.adapterType = (DxgiAdapterType)DXMarshal.ReadInt32(ref buffer);
        obj.graphicsPreemptionGranularity = (DxgiGraphicsPreemptionGranularity)DXMarshal.ReadInt32(ref buffer);
        obj.computePreemptionGranularity = (DxgiComputePreemptionGranularity)DXMarshal.ReadInt32(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<DxgiAdapterDesc2> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    private struct Buffer128
    {
        public fixed char Buffer[Length];
        public const int Length = 128;
        public const int TotalSize = sizeof(char) * Length;
    }

    /// <summary>
    /// A string that contains the adapter description. On feature level 9 graphics hardware, “Software Adapter”.
    /// </summary>
    private Buffer128 adapterDescription;

    /// <summary>
    /// The PCI ID of the hardware vendor. On feature level 9 graphics hardware, 0.
    /// </summary>
    private uint vendorId;

    /// <summary>
    /// The PCI ID of the hardware device. On feature level 9 graphics hardware, 0.
    /// </summary>
    private uint deviceId;

    /// <summary>
    /// The PCI ID of the sub system. On feature level 9 graphics hardware, 0.
    /// </summary>
    private uint subSysId;

    /// <summary>
    /// The PCI ID of the revision number of the adapter. On feature level 9 graphics hardware, 0.
    /// </summary>
    private uint revision;

    /// <summary>
    /// The number of bytes of dedicated video memory that are not shared with the CPU.
    /// </summary>
    private nuint dedicatedVideoMemory;

    /// <summary>
    /// The number of bytes of dedicated system memory that are not shared with the CPU. This memory is allocated from available system memory at boot time.
    /// </summary>
    private nuint dedicatedSystemMemory;

    /// <summary>
    /// The number of bytes of shared system memory. This is the maximum value of system memory that may be consumed by the adapter during operation. Any incidental memory consumed by the driver as it manages and uses video memory is additional.
    /// </summary>
    private nuint sharedSystemMemory;

    /// <summary>
    /// A unique value that identifies the adapter.
    /// </summary>
    private ulong adapterLuid;

    /// <summary>
    /// A value of the <see cref="DxgiAdapterType"/> enumeration that describes the adapter type.
    /// </summary>
    private DxgiAdapterType adapterType;

    /// <summary>
    /// A value of the <see cref="DxgiGraphicsPreemptionGranularity"/> enumeration that describes the granularity level at which the GPU can be preempted from performing its current graphics rendering task.
    /// </summary>
    private DxgiGraphicsPreemptionGranularity graphicsPreemptionGranularity;

    /// <summary>
    /// A value of the <see cref="DxgiComputePreemptionGranularity"/> enumeration that describes the granularity level at which the GPU can be preempted from performing its current compute task.
    /// </summary>
    private DxgiComputePreemptionGranularity computePreemptionGranularity;

    /// <summary>
    /// Gets a string that contains the adapter description. On feature level 9 graphics hardware, “Software Adapter”.
    /// </summary>
    public readonly string AdapterDescription
    {
        get
        {
            fixed (char* ptr = this.adapterDescription.Buffer)
            {
                return new string(ptr);
            }
        }
    }

    /// <summary>
    /// Gets a string as span that contains the adapter description. On feature level 9 graphics hardware, “Software Adapter”.
    /// </summary>
    public readonly ReadOnlySpan<char> GetAdapterDescriptionAsSpan()
    {
        fixed (char* ptrThis = adapterDescription.Buffer)
        {
            int count = DXMarshal.GetNullTerminatedStringCountUni((nint)ptrThis);
            return new ReadOnlySpan<char>(ptrThis, count);
        }
    }

    /// <summary>
    /// Gets the maximum char count of the string that contains the adapter description.
    /// </summary>
    public const int AdapterDescriptionMaxLength = Buffer128.Length;

    /// <summary>
    /// Gets the char count of the string that contains the adapter description. On feature level 9 graphics hardware, “Software Adapter”.
    /// </summary>
    /// <returns></returns>
    public readonly int GetAdapterDescriptionCharCount()
    {
        fixed (char* ptr = this.adapterDescription.Buffer)
        {
            return DXMarshal.GetNullTerminatedStringCountUni((nint)ptr);
        }
    }

    /// <summary>
    /// Gets the chars of the string that contains the adapter description. On feature level 9 graphics hardware, “Software Adapter”.
    /// </summary>
    /// <param name="desc"></param>
    public readonly void GetAdapterDescriptionChars(Span<char> desc)
    {
        fixed (char* ptr = this.adapterDescription.Buffer)
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
    /// Gets the PCI ID of the hardware vendor. On feature level 9 graphics hardware, 0.
    /// </summary>
    public readonly uint VendorId
    {
        get { return this.vendorId; }
    }

    /// <summary>
    /// Gets the PCI ID of the hardware device. On feature level 9 graphics hardware, 0.
    /// </summary>
    public readonly uint DeviceId
    {
        get { return this.deviceId; }
    }

    /// <summary>
    /// Gets the PCI ID of the sub system. On feature level 9 graphics hardware, 0.
    /// </summary>
    public readonly uint SubSysId
    {
        get { return this.subSysId; }
    }

    /// <summary>
    /// Gets the PCI ID of the revision number of the adapter. On feature level 9 graphics hardware, 0.
    /// </summary>
    public readonly uint Revision
    {
        get { return this.revision; }
    }

    /// <summary>
    /// Gets the number of bytes of dedicated video memory that are not shared with the CPU.
    /// </summary>
    public readonly ulong DedicatedVideoMemory
    {
        get { return this.dedicatedVideoMemory; }
    }

    /// <summary>
    /// Gets the number of bytes of dedicated system memory that are not shared with the CPU. This memory is allocated from available system memory at boot time.
    /// </summary>
    public readonly ulong DedicatedSystemMemory
    {
        get { return this.dedicatedSystemMemory; }
    }

    /// <summary>
    /// Gets the number of bytes of shared system memory. This is the maximum value of system memory that may be consumed by the adapter during operation. Any incidental memory consumed by the driver as it manages and uses video memory is additional.
    /// </summary>
    public readonly ulong SharedSystemMemory
    {
        get { return this.sharedSystemMemory; }
    }

    /// <summary>
    /// Gets a unique value that identifies the adapter.
    /// </summary>
    public readonly ulong AdapterLuid
    {
        get { return this.adapterLuid; }
    }

    /// <summary>
    /// Gets a value of the <see cref="DxgiAdapterType"/> enumeration that describes the adapter type.
    /// </summary>
    public readonly DxgiAdapterType AdapterType
    {
        get { return this.adapterType; }
    }

    /// <summary>
    /// Gets a value of the <see cref="DxgiGraphicsPreemptionGranularity"/> enumeration that describes the granularity level at which the GPU can be preempted from performing its current graphics rendering task.
    /// </summary>
    public readonly DxgiGraphicsPreemptionGranularity GraphicsPreemptionGranularity
    {
        get { return this.graphicsPreemptionGranularity; }
    }

    /// <summary>
    /// Gets a value of the <see cref="DxgiComputePreemptionGranularity"/> enumeration that describes the granularity level at which the GPU can be preempted from performing its current compute task.
    /// </summary>
    public readonly DxgiComputePreemptionGranularity ComputePreemptionGranularity
    {
        get { return this.computePreemptionGranularity; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(DxgiAdapterDesc2 left, DxgiAdapterDesc2 right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(DxgiAdapterDesc2 left, DxgiAdapterDesc2 right)
    {
        return !(left == right);
    }

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public readonly override string ToString()
    {
        return this.AdapterDescription;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public readonly override bool Equals(object? obj)
    {
        return obj is DxgiAdapterDesc2 desc && Equals(desc);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(DxgiAdapterDesc2 other)
    {
        fixed (char* ptrThis = adapterDescription.Buffer)
        {
            ReadOnlySpan<char> spanThis = new(ptrThis, Buffer128.Length);
            ReadOnlySpan<char> spanOther = new(other.adapterDescription.Buffer, Buffer128.Length);

            return MemoryExtensions.Equals(spanThis, spanOther, StringComparison.Ordinal) &&
                vendorId == other.vendorId &&
                deviceId == other.deviceId &&
                subSysId == other.subSysId &&
                revision == other.revision &&
                dedicatedVideoMemory == other.dedicatedVideoMemory &&
                dedicatedSystemMemory == other.dedicatedSystemMemory &&
                sharedSystemMemory == other.sharedSystemMemory &&
                adapterLuid == other.adapterLuid &&
                adapterType == other.adapterType &&
                graphicsPreemptionGranularity == other.graphicsPreemptionGranularity &&
                computePreemptionGranularity == other.computePreemptionGranularity;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = 772228019;
        hashCode = hashCode * -1521134295 + adapterDescription.GetHashCode();
        hashCode = hashCode * -1521134295 + vendorId.GetHashCode();
        hashCode = hashCode * -1521134295 + deviceId.GetHashCode();
        hashCode = hashCode * -1521134295 + subSysId.GetHashCode();
        hashCode = hashCode * -1521134295 + revision.GetHashCode();
        hashCode = hashCode * -1521134295 + dedicatedVideoMemory.GetHashCode();
        hashCode = hashCode * -1521134295 + dedicatedSystemMemory.GetHashCode();
        hashCode = hashCode * -1521134295 + sharedSystemMemory.GetHashCode();
        hashCode = hashCode * -1521134295 + adapterLuid.GetHashCode();
        hashCode = hashCode * -1521134295 + adapterType.GetHashCode();
        hashCode = hashCode * -1521134295 + graphicsPreemptionGranularity.GetHashCode();
        hashCode = hashCode * -1521134295 + computePreemptionGranularity.GetHashCode();
        return hashCode;
    }
}
