// <copyright file="D2D1DCInitializeMode.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    /// <summary>
    /// Specifies how a device context is initialized for GDI rendering when it is retrieved from the render target.
    /// </summary>
    public enum D2D1DCInitializeMode
    {
        /// <summary>
        /// The current contents of the render target are copied to the device context when it is initialized.
        /// </summary>
        Copy = 0,

        /// <summary>
        /// The device context is cleared to transparent black when it is initialized.
        /// </summary>
        Clear = 1,
    }
}
