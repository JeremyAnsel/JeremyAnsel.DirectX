// <copyright file="D3D11Filter.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    /// <summary>
    /// Filtering options during texture sampling.
    /// </summary>
    public enum D3D11Filter
    {
        /// <summary>
        /// Use point sampling for minification, magnification, and mip-level sampling.
        /// </summary>
        MinMagMipPoint = 0x00000000,

        /// <summary>
        /// Use point sampling for minification and magnification; use linear interpolation for mip-level sampling.
        /// </summary>
        MinMagPointMipLinear = 0x00000001,

        /// <summary>
        /// Use point sampling for minification; use linear interpolation for magnification; use point sampling for mip-level sampling.
        /// </summary>
        MinPointMagLinearMipPoint = 0x00000004,

        /// <summary>
        /// Use point sampling for minification; use linear interpolation for magnification and mip-level sampling.
        /// </summary>
        MinPointMagMipLinear = 0x00000005,

        /// <summary>
        /// Use linear interpolation for minification; use point sampling for magnification and mip-level sampling.
        /// </summary>
        MinLinearMagMipPoint = 0x00000010,

        /// <summary>
        /// Use linear interpolation for minification; use point sampling for magnification; use linear interpolation for mip-level sampling.
        /// </summary>
        MinLinearMagPointMipLinear = 0x00000011,

        /// <summary>
        /// Use linear interpolation for minification and magnification; use point sampling for mip-level sampling.
        /// </summary>
        MinMagLinearMipPoint = 0x00000014,

        /// <summary>
        /// Use linear interpolation for minification, magnification, and mip-level sampling.
        /// </summary>
        MinMagMipLinear = 0x00000015,

        /// <summary>
        /// Use anisotropic interpolation for minification, magnification, and mip-level sampling.
        /// </summary>
        Anisotropic = 0x00000055,

        /// <summary>
        /// Use point sampling for minification, magnification, and mip-level sampling. Compare the result to the comparison value.
        /// </summary>
        ComparisonMinMagMipPoint = 0x00000080,

        /// <summary>
        /// Use point sampling for minification and magnification; use linear interpolation for mip-level sampling. Compare the result to the comparison value.
        /// </summary>
        ComparisonMinMagPointMipLinear = 0x00000081,

        /// <summary>
        /// Use point sampling for minification; use linear interpolation for magnification; use point sampling for mip-level sampling. Compare the result to the comparison value.
        /// </summary>
        ComparisonMinPointMagLinearMipPoint = 0x00000084,

        /// <summary>
        /// Use point sampling for minification; use linear interpolation for magnification and mip-level sampling. Compare the result to the comparison value.
        /// </summary>
        ComparisonMinPointMagMipLinear = 0x00000085,

        /// <summary>
        /// Use linear interpolation for minification; use point sampling for magnification and mip-level sampling. Compare the result to the comparison value.
        /// </summary>
        ComparisonMinLinearMagMipPoint = 0x00000090,

        /// <summary>
        /// Use linear interpolation for minification; use point sampling for magnification; use linear interpolation for mip-level sampling. Compare the result to the comparison value.
        /// </summary>
        ComparisonMinLinearMagPointMipLinear = 0x00000091,

        /// <summary>
        /// Use linear interpolation for minification and magnification; use point sampling for mip-level sampling. Compare the result to the comparison value.
        /// </summary>
        ComparisonMinMagLinearMipPoint = 0x00000094,

        /// <summary>
        /// Use linear interpolation for minification, magnification, and mip-level sampling. Compare the result to the comparison value.
        /// </summary>
        ComparisonMinMagMipLinear = 0x00000095,

        /// <summary>
        /// Use anisotropic interpolation for minification, magnification, and mip-level sampling. Compare the result to the comparison value.
        /// </summary>
        ComparisonAnisotropic = 0x000000d5,

        /// <summary>
        /// Fetch the same set of texels as <c>D3D11_FILTER_MIN_MAG_MIP_POINT</c> and instead of filtering them return the minimum of the texels. Texels that are weighted 0 during filtering aren't counted towards the minimum.
        /// </summary>
        MinimumMinMagMipPoint = 0x00000100,

        /// <summary>
        /// Fetch the same set of texels as <c>D3D11_FILTER_MIN_MAG_POINT_MIP_LINEAR</c> and instead of filtering them return the minimum of the texels. Texels that are weighted 0 during filtering aren't counted towards the minimum.
        /// </summary>
        MinimumMinMagPointMipLinear = 0x00000101,

        /// <summary>
        /// Fetch the same set of texels as <c>D3D11_FILTER_MIN_POINT_MAG_LINEAR_MIP_POINT</c> and instead of filtering them return the minimum of the texels. Texels that are weighted 0 during filtering aren't counted towards the minimum.
        /// </summary>
        MinimumMinPointMagLinearMipPoint = 0x00000104,

        /// <summary>
        /// Fetch the same set of texels as <c>D3D11_FILTER_MIN_POINT_MAG_MIP_LINEAR</c> and instead of filtering them return the minimum of the texels. Texels that are weighted 0 during filtering aren't counted towards the minimum.
        /// </summary>
        MinimumMinPointMagMipLinear = 0x00000105,

        /// <summary>
        /// Fetch the same set of texels as <c>D3D11_FILTER_MIN_LINEAR_MAG_MIP_POINT</c> and instead of filtering them return the minimum of the texels. Texels that are weighted 0 during filtering aren't counted towards the minimum.
        /// </summary>
        MinimumMinLinearMagMipPoint = 0x00000110,

        /// <summary>
        /// Fetch the same set of texels as <c>D3D11_FILTER_MIN_LINEAR_MAG_POINT_MIP_LINEAR</c> and instead of filtering them return the minimum of the texels. Texels that are weighted 0 during filtering aren't counted towards the minimum.
        /// </summary>
        MinimumMinLinearMagPointMipLinear = 0x00000111,

        /// <summary>
        /// Fetch the same set of texels as <c>D3D11_FILTER_MIN_MAG_LINEAR_MIP_POINT</c> and instead of filtering them return the minimum of the texels. Texels that are weighted 0 during filtering aren't counted towards the minimum.
        /// </summary>
        MinimumMinMagLinearMipPoint = 0x00000114,

        /// <summary>
        /// Fetch the same set of texels as <c>D3D11_FILTER_MIN_MAG_MIP_LINEAR</c> and instead of filtering them return the minimum of the texels. Texels that are weighted 0 during filtering aren't counted towards the minimum.
        /// </summary>
        MinimumMinMagMipLinear = 0x00000115,

        /// <summary>
        /// Fetch the same set of texels as <c>D3D11_FILTER_ANISOTROPIC</c> and instead of filtering them return the minimum of the texels. Texels that are weighted 0 during filtering aren't counted towards the minimum.
        /// </summary>
        MinimumAnisotropic = 0x00000155,

        /// <summary>
        /// Fetch the same set of texels as <c>D3D11_FILTER_MIN_MAG_MIP_POINT</c> and instead of filtering them return the maximum of the texels. Texels that are weighted 0 during filtering aren't counted towards the maximum.
        /// </summary>
        MaximumMinMagMipPoint = 0x00000180,

        /// <summary>
        /// Fetch the same set of texels as <c>D3D11_FILTER_MIN_MAG_POINT_MIP_LINEAR</c> and instead of filtering them return the maximum of the texels. Texels that are weighted 0 during filtering aren't counted towards the maximum.
        /// </summary>
        MaximumMinMagPointMipLinear = 0x00000181,

        /// <summary>
        /// Fetch the same set of texels as <c>D3D11_FILTER_MIN_POINT_MAG_LINEAR_MIP_POINT</c> and instead of filtering them return the maximum of the texels. Texels that are weighted 0 during filtering aren't counted towards the maximum.
        /// </summary>
        MaximumMinPointMagLinearMipPoint = 0x00000184,

        /// <summary>
        /// Fetch the same set of texels as <c>D3D11_FILTER_MIN_POINT_MAG_MIP_LINEAR</c> and instead of filtering them return the maximum of the texels. Texels that are weighted 0 during filtering aren't counted towards the maximum.
        /// </summary>
        MaximumMinPointMagMipLinear = 0x00000185,

        /// <summary>
        /// Fetch the same set of texels as <c>D3D11_FILTER_MIN_LINEAR_MAG_MIP_POINT</c> and instead of filtering them return the maximum of the texels. Texels that are weighted 0 during filtering aren't counted towards the maximum.
        /// </summary>
        MaximumMinLinearMagMipPoint = 0x00000190,

        /// <summary>
        /// Fetch the same set of texels as <c>D3D11_FILTER_MIN_LINEAR_MAG_POINT_MIP_LINEAR</c> and instead of filtering them return the maximum of the texels. Texels that are weighted 0 during filtering aren't counted towards the maximum.
        /// </summary>
        MaximumMinLinearMagPointMipLinear = 0x00000191,

        /// <summary>
        /// Fetch the same set of texels as <c>D3D11_FILTER_MIN_MAG_LINEAR_MIP_POINT</c> and instead of filtering them return the maximum of the texels. Texels that are weighted 0 during filtering aren't counted towards the maximum.
        /// </summary>
        MaximumMinMagLinearMipPoint = 0x00000194,

        /// <summary>
        /// Fetch the same set of texels as <c>D3D11_FILTER_MIN_MAG_MIP_LINEAR</c> and instead of filtering them return the maximum of the texels. Texels that are weighted 0 during filtering aren't counted towards the maximum.
        /// </summary>
        MaximumMinMagMipLinear = 0x00000195,

        /// <summary>
        /// Fetch the same set of texels as <c>D3D11_FILTER_ANISOTROPIC</c> and instead of filtering them return the maximum of the texels. Texels that are weighted 0 during filtering aren't counted towards the maximum.
        /// </summary>
        MaximumAnisotropic = 0x000001d5
    }
}
