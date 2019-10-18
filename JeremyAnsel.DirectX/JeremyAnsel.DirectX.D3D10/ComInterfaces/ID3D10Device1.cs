// <copyright file="ID3D10Device1.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D10.ComInterfaces
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    /// The device interface represents a virtual adapter for Direct3D 10.1; it is used to perform rendering and create Direct3D resources.
    /// </summary>
    [SecurityCritical, SuppressUnmanagedCodeSecurity]
    [ComImport, Guid("9B7E4C8F-342C-4106-A19F-4F2704F689F0")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ID3D10Device1
    {
        /// <summary>
        /// Not Implemented.
        /// </summary>
        void VSSetConstantBuffers();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void PSSetShaderResources();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void PSSetShader();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void PSSetSamplers();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void VSSetShader();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void DrawIndexed();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void Draw();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void PSSetConstantBuffers();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void IASetInputLayout();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void IASetVertexBuffers();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void IASetIndexBuffer();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void DrawIndexedInstanced();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void DrawInstanced();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void GSSetConstantBuffers();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void GSSetShader();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void IASetPrimitiveTopology();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void VSSetShaderResources();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void VSSetSamplers();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void SetPredication();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void GSSetShaderResources();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void GSSetSamplers();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void OMSetRenderTargets();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void OMSetBlendState();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void OMSetDepthStencilState();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void SOSetTargets();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void DrawAuto();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void RSSetState();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void RSSetViewports();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void RSSetScissorRects();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void CopySubresourceRegion();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void CopyResource();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void UpdateSubresource();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void ClearRenderTargetView();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void ClearDepthStencilView();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void GenerateMips();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void ResolveSubresource();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void VSGetConstantBuffers();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void PSGetShaderResources();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void PSGetShader();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void PSGetSamplers();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void VSGetShader();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void PSGetConstantBuffers();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void IAGetInputLayout();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void IAGetVertexBuffers();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void IAGetIndexBuffer();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void GSGetConstantBuffers();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void GSGetShader();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void IAGetPrimitiveTopology();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void VSGetShaderResources();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void VSGetSamplers();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void GetPredication();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void GSGetShaderResources();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void GSGetSamplers();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void OMGetRenderTargets();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void OMGetBlendState();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void OMGetDepthStencilState();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void SOGetTargets();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void RSGetState();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void RSGetViewports();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void RSGetScissorRects();

        /// <summary>
        /// Get the reason why the device was removed.
        /// </summary>
        /// <returns><see cref="uint"/></returns>
        [PreserveSig]
        uint GetDeviceRemovedReason();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void SetExceptionMode();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void GetExceptionMode();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void GetPrivateData();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void SetPrivateData();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void SetPrivateDataInterface();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void ClearState();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void Flush();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void CreateBuffer();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void CreateTexture1D();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void CreateTexture2D();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void CreateTexture3D();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void CreateShaderResourceView();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void CreateRenderTargetView();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void CreateDepthStencilView();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void CreateInputLayout();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void CreateVertexShader();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void CreateGeometryShader();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void CreateGeometryShaderWithStreamOutput();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void CreatePixelShader();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void CreateBlendState();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void CreateDepthStencilState();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void CreateRasterizerState();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void CreateSamplerState();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void CreateQuery();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void CreatePredicate();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void CreateCounter();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void CheckFormatSupport();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void CheckMultisampleQualityLevels();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void CheckCounterInfo();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void CheckCounter();

        /// <summary>
        /// Get the flags used during the call to create the device.
        /// </summary>
        /// <returns><see cref="D3D10CreateDeviceOptions"/></returns>
        [PreserveSig]
        D3D10CreateDeviceOptions GetCreationFlags();

        /// <summary>
        /// Give a device access to a shared resource created on a different Direct3d device.
        /// </summary>
        /// <param name="resourceHandle">A resource handle.</param>
        /// <param name="returnedInterface">The globally unique identifier (GUID) for the resource interface.</param>
        /// <returns>The resource we are gaining access to.</returns>
        [return: MarshalAs(UnmanagedType.IUnknown)]
        object OpenSharedResource(
            [In] IntPtr resourceHandle,
            [In] ref Guid returnedInterface);

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void SetTextFilterSize();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void GetTextFilterSize();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void CreateShaderResourceView1();

        /// <summary>
        /// Not Implemented.
        /// </summary>
        void CreateBlendState1();

        /// <summary>
        /// Gets the feature level of the hardware device.
        /// </summary>
        /// <returns><see cref="D3D10FeatureLevel"/></returns>
        [PreserveSig]
        D3D10FeatureLevel GetFeatureLevel();
    }
}
