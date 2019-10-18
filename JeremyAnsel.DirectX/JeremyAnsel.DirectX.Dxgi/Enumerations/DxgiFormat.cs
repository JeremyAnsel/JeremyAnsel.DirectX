// <copyright file="DxgiFormat.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    /// <summary>
    /// Resource data formats which includes fully-typed and typeless formats.
    /// </summary>
    public enum DxgiFormat
    {
        /// <summary>The format is not known.</summary>
        Unknown,

        /// <summary>A four-component, 128-bit typeless format that supports 32 bits per channel including alpha.</summary>
        R32G32B32A32Typeless,

        /// <summary>A four-component, 128-bit floating-point format that supports 32 bits per channel including alpha.</summary>
        R32G32B32A32Float,

        /// <summary>A four-component, 128-bit unsigned-integer format that supports 32 bits per channel including alpha.</summary>
        R32G32B32A32UInt,

        /// <summary>A four-component, 128-bit signed-integer format that supports 32 bits per channel including alpha.</summary>
        R32G32B32A32SInt,

        /// <summary>A three-component, 96-bit typeless format that supports 32 bits per color channel.</summary>
        R32G32B32Typeless,

        /// <summary>A three-component, 96-bit floating-point format that supports 32 bits per color channel.</summary>
        R32G32B32Float,

        /// <summary>A three-component, 96-bit unsigned-integer format that supports 32 bits per color channel.</summary>
        R32G32B32UInt,

        /// <summary>A three-component, 96-bit signed-integer format that supports 32 bits per color channel.</summary>
        R32G32B32SInt,

        /// <summary>A four-component, 64-bit typeless format that supports 16 bits per channel including alpha.</summary>
        R16G16B16A16Typeless,

        /// <summary>A four-component, 64-bit floating-point format that supports 16 bits per channel including alpha.</summary>
        R16G16B16A16Float,

        /// <summary>A four-component, 64-bit unsigned-normalized-integer format that supports 16 bits per channel including alpha.</summary>
        R16G16B16A16UNorm,

        /// <summary>A four-component, 64-bit unsigned-integer format that supports 16 bits per channel including alpha.</summary>
        R16G16B16A16UInt,

        /// <summary>A four-component, 64-bit signed-normalized-integer format that supports 16 bits per channel including alpha.</summary>
        R16G16B16A16SNorm,

        /// <summary>A four-component, 64-bit signed-integer format that supports 16 bits per channel including alpha.</summary>
        R16G16B16A16SInt,

        /// <summary>A two-component, 64-bit typeless format that supports 32 bits for the red channel and 32 bits for the green channel.</summary>
        R32G32Typeless,

        /// <summary>A two-component, 64-bit floating-point format that supports 32 bits for the red channel and 32 bits for the green channel.</summary>
        R32G32Float,

        /// <summary>A two-component, 64-bit unsigned-integer format that supports 32 bits for the red channel and 32 bits for the green channel.</summary>
        R32G32UInt,

        /// <summary>A two-component, 64-bit signed-integer format that supports 32 bits for the red channel and 32 bits for the green channel.</summary>
        R32G32SInt,

        /// <summary>A two-component, 64-bit typeless format that supports 32 bits for the red channel, 8 bits for the green channel, and 24 bits are unused.</summary>
        R32G8X24Typeless,

        /// <summary>A 32-bit floating-point component, and two unsigned-integer components (with an additional 32 bits). This format supports 32-bit depth, 8-bit stencil, and 24 bits are unused.</summary>
        D32FloatS8X24UInt,

        /// <summary>A 32-bit floating-point component, and two typeless components (with an additional 32 bits). This format supports 32-bit red channel, 8 bits are unused, and 24 bits are unused.</summary>
        R32FloatX8X24Typeless,

        /// <summary>A 32-bit typeless component, and two unsigned-integer components (with an additional 32 bits). This format has 32 bits unused, 8 bits for green channel, and 24 bits are unused.</summary>
        X32TypelessG8X24UInt,

        /// <summary>A four-component, 32-bit typeless format that supports 10 bits for each color and 2 bits for alpha.</summary>
        R10G10B10A2Typeless,

        /// <summary>A four-component, 32-bit unsigned-normalized-integer format that supports 10 bits for each color and 2 bits for alpha.</summary>
        R10G10B10A2UNorm,

        /// <summary>A four-component, 32-bit unsigned-integer format that supports 10 bits for each color and 2 bits for alpha.</summary>
        R10G10B10A2UInt,

        /// <summary>Three partial-precision floating-point numbers encoded into a single 32-bit value (a variant of s10e5, which is sign bit, 10-bit mantissa, and 5-bit biased (15) exponent). There are no sign bits, and there is a 5-bit biased (15) exponent for each channel, 6-bit mantissa for R and G, and a 5-bit mantissa for B.</summary>
        R11G11B10Float,

        /// <summary>A four-component, 32-bit typeless format that supports 8 bits per channel including alpha.</summary>
        R8G8B8A8Typeless,

        /// <summary>A four-component, 32-bit unsigned-normalized-integer format that supports 8 bits per channel including alpha.</summary>
        R8G8B8A8UNorm,

        /// <summary>A four-component, 32-bit unsigned-normalized integer sRGB format that supports 8 bits per channel including alpha.</summary>
        R8G8B8A8UNormSrgb,

        /// <summary>A four-component, 32-bit unsigned-integer format that supports 8 bits per channel including alpha.</summary>
        R8G8B8A8UInt,

        /// <summary>A four-component, 32-bit signed-normalized-integer format that supports 8 bits per channel including alpha.</summary>
        R8G8B8A8SNorm,

        /// <summary>A four-component, 32-bit signed-integer format that supports 8 bits per channel including alpha.</summary>
        R8G8B8A8SInt,

        /// <summary>A two-component, 32-bit typeless format that supports 16 bits for the red channel and 16 bits for the green channel.</summary>
        R16G16Typeless,

        /// <summary>A two-component, 32-bit floating-point format that supports 16 bits for the red channel and 16 bits for the green channel.</summary>
        R16G16Float,

        /// <summary>A two-component, 32-bit unsigned-normalized-integer format that supports 16 bits each for the green and red channels.</summary>
        R16G16UNorm,

        /// <summary>A two-component, 32-bit unsigned-integer format that supports 16 bits for the red channel and 16 bits for the green channel.</summary>
        R16G16UInt,

        /// <summary>A two-component, 32-bit signed-normalized-integer format that supports 16 bits for the red channel and 16 bits for the green channel.</summary>
        R16G16SNorm,

        /// <summary>A two-component, 32-bit signed-integer format that supports 16 bits for the red channel and 16 bits for the green channel.</summary>
        R16G16SInt,

        /// <summary>A single-component, 32-bit typeless format that supports 32 bits for the red channel.</summary>
        R32Typeless,

        /// <summary>A single-component, 32-bit floating-point format that supports 32 bits for depth.</summary>
        D32Float,

        /// <summary>A single-component, 32-bit floating-point format that supports 32 bits for the red channel.</summary>
        R32Float,

        /// <summary>A single-component, 32-bit unsigned-integer format that supports 32 bits for the red channel.</summary>
        R32UInt,

        /// <summary>A single-component, 32-bit signed-integer format that supports 32 bits for the red channel.</summary>
        R32SInt,

        /// <summary>A two-component, 32-bit typeless format that supports 24 bits for the red channel and 8 bits for the green channel.</summary>
        R24G8Typeless,

        /// <summary>A 32-bit z-buffer format that supports 24 bits for depth and 8 bits for stencil.</summary>
        D24UNormS8UInt,

        /// <summary>A 32-bit format, that contains a 24 bit, single-component, unsigned-normalized integer, with an additional typeless 8 bits. This format has 24 bits red channel and 8 bits unused.</summary>
        R24UNormX8Typeless,

        /// <summary>A 32-bit format, that contains a 24 bit, single-component, typeless format, with an additional 8 bit unsigned integer component. This format has 24 bits unused and 8 bits green channel.</summary>
        X24TypelessG8UInt,

        /// <summary>A two-component, 16-bit typeless format that supports 8 bits for the red channel and 8 bits for the green channel.</summary>
        R8G8Typeless,

        /// <summary>A two-component, 16-bit unsigned-normalized-integer format that supports 8 bits for the red channel and 8 bits for the green channel.</summary>
        R8G8UNorm,

        /// <summary>A two-component, 16-bit unsigned-integer format that supports 8 bits for the red channel and 8 bits for the green channel.</summary>
        R8G8UInt,

        /// <summary>A two-component, 16-bit signed-normalized-integer format that supports 8 bits for the red channel and 8 bits for the green channel.</summary>
        R8G8SNorm,

        /// <summary>A two-component, 16-bit signed-integer format that supports 8 bits for the red channel and 8 bits for the green channel.</summary>
        R8G8SInt,

        /// <summary>A single-component, 16-bit typeless format that supports 16 bits for the red channel.</summary>
        R16Typeless,

        /// <summary>A single-component, 16-bit floating-point format that supports 16 bits for the red channel.</summary>
        R16Float,

        /// <summary>A single-component, 16-bit unsigned-normalized-integer format that supports 16 bits for depth.</summary>
        D16UNorm,

        /// <summary>A single-component, 16-bit unsigned-normalized-integer format that supports 16 bits for the red channel.</summary>
        R16UNorm,

        /// <summary>A single-component, 16-bit unsigned-integer format that supports 16 bits for the red channel.</summary>
        R16UInt,

        /// <summary>A single-component, 16-bit signed-normalized-integer format that supports 16 bits for the red channel.</summary>
        R16SNorm,

        /// <summary>A single-component, 16-bit signed-integer format that supports 16 bits for the red channel.</summary>
        R16SInt,

        /// <summary>A single-component, 8-bit typeless format that supports 8 bits for the red channel.</summary>
        R8Typeless,

        /// <summary>A single-component, 8-bit unsigned-normalized-integer format that supports 8 bits for the red channel.</summary>
        R8UNorm,

        /// <summary>A single-component, 8-bit unsigned-integer format that supports 8 bits for the red channel.</summary>
        R8UInt,

        /// <summary>A single-component, 8-bit signed-normalized-integer format that supports 8 bits for the red channel.</summary>
        R8SNorm,

        /// <summary>A single-component, 8-bit signed-integer format that supports 8 bits for the red channel.</summary>
        R8SInt,

        /// <summary>A single-component, 8-bit unsigned-normalized-integer format for alpha only.</summary>
        A8UNorm,

        /// <summary>A single-component, 1-bit unsigned-normalized integer format that supports 1 bit for the red channel.</summary>
        R1UNorm,

        /// <summary>Three partial-precision floating-point numbers encoded into a single 32-bit value all sharing the same 5-bit exponent (variant of s10e5, which is sign bit, 10-bit mantissa, and 5-bit biased (15) exponent). There is no sign bit, and there is a shared 5-bit biased (15) exponent and a 9-bit mantissa for each channel.</summary>
        R9G9B9E5SharedExp,

        /// <summary>A four-component, 32-bit unsigned-normalized-integer format. This packed RGB format is analogous to the UYVY format. Each 32-bit block describes a pair of pixels: (R8, G8, B8) and (R8, G8, B8) where the R8/B8 values are repeated, and the G8 values are unique to each pixel.</summary>
        R8G8B8G8UNorm,

        /// <summary>A four-component, 32-bit unsigned-normalized-integer format. This packed RGB format is analogous to the YUY2 format. Each 32-bit block describes a pair of pixels: (R8, G8, B8) and (R8, G8, B8) where the R8/B8 values are repeated, and the G8 values are unique to each pixel.</summary>
        G8R8G8B8UNorm,

        /// <summary>Four-component typeless block-compression format.</summary>
        BC1Typeless,

        /// <summary>Four-component block-compression format.</summary>
        BC1UNorm,

        /// <summary>Four-component block-compression format for sRGB data.</summary>
        BC1UNormSrgb,

        /// <summary>Four-component typeless block-compression format.</summary>
        BC2Typeless,

        /// <summary>Four-component block-compression format.</summary>
        BC2UNorm,

        /// <summary>Four-component block-compression format for sRGB data.</summary>
        BC2UNormSrgb,

        /// <summary>Four-component typeless block-compression format.</summary>
        BC3Typeless,

        /// <summary>Four-component block-compression format.</summary>
        BC3UNorm,

        /// <summary>Four-component block-compression format for sRGB data.</summary>
        BC3UNormSrgb,

        /// <summary>One-component typeless block-compression format.</summary>
        BC4Typeless,

        /// <summary>One-component block-compression format.</summary>
        BC4UNorm,

        /// <summary>One-component block-compression format.</summary>
        BC4SNorm,

        /// <summary>Two-component typeless block-compression format.</summary>
        BC5Typeless,

        /// <summary>Two-component block-compression format.</summary>
        BC5UNorm,

        /// <summary>Two-component block-compression format.</summary>
        BC5SNorm,

        /// <summary>A three-component, 16-bit unsigned-normalized-integer format that supports 5 bits for blue, 6 bits for green, and 5 bits for red.</summary>
        B5G6R5UNorm,

        /// <summary>A four-component, 16-bit unsigned-normalized-integer format that supports 5 bits for each color channel and 1-bit alpha.</summary>
        B5G5R5A1UNorm,

        /// <summary>A four-component, 32-bit unsigned-normalized-integer format that supports 8 bits for each color channel and 8-bit alpha.</summary>
        B8G8R8A8UNorm,

        /// <summary>A four-component, 32-bit unsigned-normalized-integer format that supports 8 bits for each color channel and 8 bits unused.</summary>
        B8G8R8X8UNorm,

        /// <summary>A four-component, 32-bit 2.8-biased fixed-point format that supports 10 bits for each color channel and 2-bit alpha.</summary>
        R10G10B10XRBiasA2UNorm,

        /// <summary>A four-component, 32-bit typeless format that supports 8 bits for each channel including alpha.</summary>
        B8G8R8A8Typeless,

        /// <summary>A four-component, 32-bit unsigned-normalized standard RGB format that supports 8 bits for each channel including alpha.</summary>
        B8G8R8A8UNormSrgb,

        /// <summary>A four-component, 32-bit typeless format that supports 8 bits for each color channel, and 8 bits are unused.</summary>
        B8G8R8X8Typeless,

        /// <summary>A four-component, 32-bit unsigned-normalized standard RGB format that supports 8 bits for each color channel, and 8 bits are unused.</summary>
        B8G8R8X8UNormSrgb,

        /// <summary>A typeless block-compression format.</summary>
        BC6HalfTypeless,

        /// <summary>A block-compression format. </summary>
        BC6HalfUF16,

        /// <summary>A block-compression format.</summary>
        BC6HalfSF16,

        /// <summary>A typeless block-compression format.</summary>
        BC7Typeless,

        /// <summary>A block-compression format.</summary>
        BC7UNorm,

        /// <summary>A block-compression format.</summary>
        BC7UNormSrgb,

        /// <summary>Most common YUV 4:4:4 video resource format.</summary>
        AYuv,

        /// <summary>10-bit per channel packed YUV 4:4:4 video resource format.</summary>
        Y410,

        /// <summary>16-bit per channel packed YUV 4:4:4 video resource format.</summary>
        Y416,

        /// <summary>Most common YUV 4:2:0 video resource format.</summary>
        NV12,

        /// <summary>10-bit per channel planar YUV 4:2:0 video resource format.</summary>
        P010,

        /// <summary>16-bit per channel planar YUV 4:2:0 video resource format.</summary>
        P016,

        /// <summary>8-bit per channel planar YUV 4:2:0 video resource format. This format is subsampled where each pixel has its own Y value, but each 2x2 pixel block shares a single U and V value.</summary>
        P420Opaque,

        /// <summary>8-bit per channel planar YUV 4:2:0 video resource format.</summary>
        Yuy2,

        /// <summary>10-bit per channel packed YUV 4:2:2 video resource format.</summary>
        Y210,

        /// <summary>16-bit per channel packed YUV 4:2:2 video resource format.</summary>
        Y216,

        /// <summary>Most common planar YUV 4:1:1 video resource format.</summary>
        NV11,

        /// <summary>4-bit palletized YUV format that is commonly used for DVD sub-picture.</summary>
        AI44,

        /// <summary>4-bit palletized YUV format that is commonly used for DVD sub-picture.</summary>
        IA44,

        /// <summary>8-bit palletized format that is used for palletized RGB data when the processor processes ISDB-T data and for palletized YUV data when the processor processes Blu-Ray data.</summary>
        P8,

        /// <summary>8-bit palletized format with 8 bits of alpha that is used for palletized YUV data when the processor processes Blu-Ray data.</summary>
        A8P8,

        /// <summary>A four-component, 16-bit unsigned-normalized integer format that supports 4 bits for each channel including alpha.</summary>
        B4G4R4A4UNorm
    }
}
