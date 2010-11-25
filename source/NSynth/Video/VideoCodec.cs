/* NSynth - A Managed Multimedia API. http://nsynth.codeplex.com/
 * Copyright © 2009-2010 Will 'cathode' Shelley. All Rights Reserved. */

namespace NSynth.Video
{
    /// <summary>
    /// Provides shared functionality for <see cref="Codec"/> implementations that encode or decode video content.
    /// </summary>
    public abstract class VideoCodec : Codec
    {
        public abstract bool SupportsInterlacing
        {
            get;
        }
        public abstract int MaxBitDepth
        {
            get;
        }
        public abstract int MaxFrameWidth
        {
            get;
        }
        public abstract int MaxFrameHeight
        {
            get;
        }
        public abstract SampleRate MaxFrameRate
        {
            get;
        }
    }
}
