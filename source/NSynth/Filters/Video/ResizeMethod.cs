/* NSynth - A Managed Multimedia API. http://nsynth.codeplex.com/
 * Copyright © 2009-2011 Will 'cathode' Shelley. All Rights Reserved. */

namespace NSynth.Filters.Internal.Video
{
    /// <summary>
    /// Enumerates supported image resizing algorithms for the <see cref="Resize"/> filter.
    /// </summary>
    public enum ResizeMethod
    {
        /// <summary>
        /// Indicates nearest-neighbor resize method. Very fast, poor quality.
        /// </summary>
        NearestNeighbor = 0x0,

        /// <summary>
        /// Indicates bilinear resize method. Provides good speed.
        /// </summary>
        Bilinear,

        /// <summary>
        /// Indicates trilinear resize method. Provides decent speed.
        /// </summary>
        Trilinear,

        /// <summary>
        /// Indicates bicubic resize method. Better quality than bilinear or trilinear.
        /// </summary>
        Bicubic,
    }
}
