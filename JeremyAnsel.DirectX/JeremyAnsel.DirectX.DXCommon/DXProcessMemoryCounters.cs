using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.DXCommon;

/// <summary>
/// 
/// </summary>
[SkipLocalsInit]
public struct DXProcessMemoryCounters
{
    /// <summary>
    /// 
    /// </summary>
    public int cb;

    /// <summary>
    /// 
    /// </summary>
    public int PageFaultCount;

    /// <summary>
    /// 
    /// </summary>
    public nint PeakWorkingSetSize;

    /// <summary>
    /// 
    /// </summary>
    public nint WorkingSetSize;

    /// <summary>
    /// 
    /// </summary>
    public nint QuotaPeakPagedPoolUsage;

    /// <summary>
    /// 
    /// </summary>
    public nint QuotaPagedPoolUsage;

    /// <summary>
    /// 
    /// </summary>
    public nint QuotaPeakNonPagedPoolUsage;

    /// <summary>
    /// 
    /// </summary>
    public nint QuotaNonPagedPoolUsage;

    /// <summary>
    /// 
    /// </summary>
    public nint PagefileUsage;

    /// <summary>
    /// 
    /// </summary>
    public nint PeakPagefileUsage;

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static DXProcessMemoryCounters GetCurrent()
    {
        nint process = NativeMethods.GetCurrentProcess();
        DXProcessMemoryCounters counters = default;
        counters.cb = DXMarshal.SizeOf<DXProcessMemoryCounters>();
        NativeMethods.GetProcessMemoryInfo(process, ref counters, counters.cb);
        return counters;
    }
}
