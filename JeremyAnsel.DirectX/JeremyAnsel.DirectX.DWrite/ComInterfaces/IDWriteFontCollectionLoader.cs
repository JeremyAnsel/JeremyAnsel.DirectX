// <copyright file="IDWriteFontCollectionLoader.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DWrite.ComInterfaces;

/// <summary>
/// The font collection loader interface is used to construct a collection of fonts given a particular type of key.
/// The font collection loader interface is recommended to be implemented by a singleton object.
/// IMPORTANT: font collection loader implementations must not register themselves with a DirectWrite factory
/// inside their constructors and must not unregister themselves in their destructors, because
/// registration and unregistration operations increment and decrement the object reference count respectively.
/// Instead, registration and unregistration of font file loaders with DirectWrite factory should be performed
/// outside of the font file loader implementation as a separate step.
/// </summary>
[Guid("cca920e4-52f0-492b-bfa8-29c72ee0a468")]
internal unsafe readonly struct IDWriteFontCollectionLoader
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;

    /// <summary>
    /// Creates a font file enumerator object that encapsulates a collection of font files.
    /// The font system calls back to this interface to create a font collection.
    /// </summary>
    /// <param name="factory">Factory associated with the loader.</param>
    /// <param name="collectionKey">Font collection key that uniquely identifies the collection of font files within
    /// the scope of the font collection loader being used.</param>
    /// <param name="collectionKeySize">Size of the font collection key in bytes.</param>
    /// <param name="fontFileEnumerator">Pointer to the newly created font file enumerator.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, void*, uint, nint*, int> CreateEnumeratorFromKey;
}
