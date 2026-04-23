// <copyright file="IDxgiAdapter3.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.Dxgi.ComInterfaces;

/// <summary>
/// The <c>IDXGIAdapter3</c> interface represents a display sub-system, which includes one or more GPUs, DACs, and video memory.
/// </summary>
/// <remarks>Inherited from <see cref="IDxgiAdapter1"/></remarks>
[Guid("645967A4-1392-4310-A798-8053CE3E93FD")]
internal unsafe readonly struct IDxgiAdapter3
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
    private readonly nint SetPrivateData;
    private readonly nint SetPrivateDataInterface;
    private readonly nint GetPrivateData;
    private readonly nint GetParent;
    private readonly nint EnumOutputs;
    private readonly nint GetDesc;
    private readonly nint CheckInterfaceSupport;
    private readonly nint GetDesc1;
    private readonly nint GetDesc2;

    private readonly nint RegisterHardwareContentProtectionTeardownStatusEvent;
    private readonly nint UnregisterHardwareContentProtectionTeardownStatus;

    public readonly delegate* unmanaged[Stdcall]<nint, uint, DxgiMemorySegmentGroup, void*, int> QueryVideoMemoryInfo;

    private readonly nint SetVideoMemoryReservation;
    private readonly nint RegisterVideoMemoryBudgetChangeNotificationEvent;
    private readonly nint UnregisterVideoMemoryBudgetChangeNotification;
}
