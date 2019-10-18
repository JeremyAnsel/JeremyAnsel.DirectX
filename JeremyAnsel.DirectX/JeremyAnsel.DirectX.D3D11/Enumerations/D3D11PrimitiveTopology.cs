// <copyright file="D3D11PrimitiveTopology.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    /// <summary>
    /// How the pipeline interprets vertex data that is bound to the input-assembler stage. These primitive topology values determine how the vertex data is rendered on screen.
    /// </summary>
    public enum D3D11PrimitiveTopology
    {
        /// <summary>
        /// The IA stage has not been initialized with a primitive topology. The IA stage will not function properly unless a primitive topology is defined.
        /// </summary>
        Undefined = 0,

        /// <summary>
        /// Interpret the vertex data as a list of points.
        /// </summary>
        PointList = 1,

        /// <summary>
        /// Interpret the vertex data as a list of lines.
        /// </summary>
        LineList = 2,

        /// <summary>
        /// Interpret the vertex data as a line strip.
        /// </summary>
        LineStrip = 3,

        /// <summary>
        /// Interpret the vertex data as a list of triangles.
        /// </summary>
        TriangleList = 4,

        /// <summary>
        /// Interpret the vertex data as a triangle strip.
        /// </summary>
        TriangleStrip = 5,

        /// <summary>
        /// Interpret the vertex data as list of lines with adjacency data.
        /// </summary>
        LineListAdj = 10,

        /// <summary>
        /// Interpret the vertex data as line strip with adjacency data.
        /// </summary>
        LineStripAdj = 11,

        /// <summary>
        /// Interpret the vertex data as list of triangles with adjacency data.
        /// </summary>
        TriangleListAdj = 12,

        /// <summary>
        /// Interpret the vertex data as triangle strip with adjacency data.
        /// </summary>
        TriangleStripAdj = 13,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        PatchList1ControlPoint = 33,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        PatchList2ControlPoint = 34,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        PatchList3ControlPoint = 35,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        PatchList4ControlPoint = 36,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        PatchList5ControlPoint = 37,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        PatchList6ControlPoint = 38,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        PatchList7ControlPoint = 39,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        PatchList8ControlPoint = 40,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        PatchList9ControlPoint = 41,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        PatchList10ControlPoint = 42,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        PatchList11ControlPoint = 43,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        PatchList12ControlPoint = 44,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        PatchList13ControlPoint = 45,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        PatchList14ControlPoint = 46,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        PatchList15ControlPoint = 47,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        PatchList16ControlPoint = 48,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        PatchList17ControlPoint = 49,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        PatchList18ControlPoint = 50,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        PatchList19ControlPoint = 51,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        PatchList20ControlPoint = 52,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        PatchList21ControlPoint = 53,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        PatchList22ControlPoint = 54,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        PatchList23ControlPoint = 55,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        PatchList24ControlPoint = 56,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        PatchList25ControlPoint = 57,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        PatchList26ControlPoint = 58,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        PatchList27ControlPoint = 59,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        PatchList28ControlPoint = 60,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        PatchList29ControlPoint = 61,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        PatchList30ControlPoint = 62,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        PatchList31ControlPoint = 63,

        /// <summary>
        /// Interpret the vertex data as a patch list.
        /// </summary>
        PatchList32ControlPoint = 64,
    }
}
