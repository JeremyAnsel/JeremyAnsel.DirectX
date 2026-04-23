// <copyright file="ID3D10Device1.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.D3D10.ComInterfaces;

/// <summary>
/// The device interface represents a virtual adapter for Direct3D 10.1; it is used to perform rendering and create Direct3D resources.
/// </summary>
[Guid("9B7E4C8F-342C-4106-A19F-4F2704F689F0")]
internal unsafe readonly struct ID3D10Device1
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint VSSetConstantBuffers;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint PSSetShaderResources;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint PSSetShader;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint PSSetSamplers;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint VSSetShader;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint DrawIndexed;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint Draw;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint PSSetConstantBuffers;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint IASetInputLayout;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint IASetVertexBuffers;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint IASetIndexBuffer;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint DrawIndexedInstanced;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint DrawInstanced;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint GSSetConstantBuffers;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint GSSetShader;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint IASetPrimitiveTopology;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint VSSetShaderResources;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint VSSetSamplers;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint SetPredication;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint GSSetShaderResources;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint GSSetSamplers;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint OMSetRenderTargets;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint OMSetBlendState;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint OMSetDepthStencilState;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint SOSetTargets;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint DrawAuto;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint RSSetState;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint RSSetViewports;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint RSSetScissorRects;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint CopySubresourceRegion;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint CopyResource;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint UpdateSubresource;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint ClearRenderTargetView;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint ClearDepthStencilView;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint GenerateMips;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint ResolveSubresource;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint VSGetConstantBuffers;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint PSGetShaderResources;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint PSGetShader;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint PSGetSamplers;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint VSGetShader;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint PSGetConstantBuffers;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint IAGetInputLayout;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint IAGetVertexBuffers;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint IAGetIndexBuffer;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint GSGetConstantBuffers;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint GSGetShader;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint IAGetPrimitiveTopology;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint VSGetShaderResources;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint VSGetSamplers;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint GetPredication;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint GSGetShaderResources;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint GSGetSamplers;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint OMGetRenderTargets;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint OMGetBlendState;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint OMGetDepthStencilState;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint SOGetTargets;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint RSGetState;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint RSGetViewports;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint RSGetScissorRects;

    /// <summary>
    /// Get the reason why the device was removed.
    /// </summary>
    /// <returns><see cref="uint"/></returns>
    public readonly delegate* unmanaged[Stdcall]<nint, uint> GetDeviceRemovedReason;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint SetExceptionMode;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint GetExceptionMode;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint GetPrivateData;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint SetPrivateData;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint SetPrivateDataInterface;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint ClearState;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint Flush;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint CreateBuffer;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint CreateTexture1D;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint CreateTexture2D;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint CreateTexture3D;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint CreateShaderResourceView;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint CreateRenderTargetView;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint CreateDepthStencilView;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint CreateInputLayout;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint CreateVertexShader;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint CreateGeometryShader;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint CreateGeometryShaderWithStreamOutput;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint CreatePixelShader;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint CreateBlendState;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint CreateDepthStencilState;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint CreateRasterizerState;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint CreateSamplerState;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint CreateQuery;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint CreatePredicate;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint CreateCounter;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint CheckFormatSupport;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint CheckMultisampleQualityLevels;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint CheckCounterInfo;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint CheckCounter;

    /// <summary>
    /// Get the flags used during the call to create the device.
    /// </summary>
    /// <returns><see cref="D3D10CreateDeviceOptions"/></returns>
    public readonly delegate* unmanaged[Stdcall]<nint, D3D10CreateDeviceOptions> GetCreationFlags;

    /// <summary>
    /// Give a device access to a shared resource created on a different Direct3d device.
    /// </summary>
    /// <param name="resourceHandle">A resource handle.</param>
    /// <param name="returnedInterface">The globally unique identifier (GUID) for the resource interface.</param>
    /// <returns>The resource we are gaining access to.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, in Guid, nint*, int> OpenSharedResource;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint SetTextFilterSize;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint GetTextFilterSize;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint CreateShaderResourceView1;

    /// <summary>
    /// Not Implemented.
    /// </summary>
    private readonly nint CreateBlendState1;

    /// <summary>
    /// Gets the feature level of the hardware device.
    /// </summary>
    /// <returns><see cref="D3D10FeatureLevel"/></returns>
    public readonly delegate* unmanaged[Stdcall]<nint, D3D10FeatureLevel> GetFeatureLevel;
}
