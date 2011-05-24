/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;

namespace NSynth.Imaging
{
    /// <summary>
    /// Provides a way to manage the way color/pixel values are stored and represented, and allows conversion between supported formats.
    /// </summary>
    public abstract class ColorFormat
    {
        #region Properties
        /// <summary>
        /// Gets the <see cref="ColorFormat"/> for 160-bit CMYK color.
        /// </summary>
        public static ColorFormat CMYK160Float
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets the default <see cref="ColorFormat"/>.
        /// </summary>
        public static ColorFormat Default
        {
            get
            {
                return ColorFormatRGB.Instance;
            }
        }

        /// <summary>
        /// Gets the <see cref="ColorFormat"/> for 128-bit floating-point RGB color; 96-bit floating-point RGB plus 32-bit floating-point Alpha channel.
        /// </summary>
        public static ColorFormat RGB
        {
            get
            {
                return ColorFormatRGB.Instance;
            }
        }

        /// <summary>
        /// Gets the <see cref="ColorFormat"/> for 24-bit RGB color.
        /// </summary>
        public static ColorFormat RGB24
        {
            get
            {
                return ColorFormatRGB24.Instance;
            }
        }

        /// <summary>
        /// Gets the <see cref="ColorFormat"/> for 32-bit RGB color; 24-bit RGB plus 8-bit Alpha channel.
        /// </summary>
        public static ColorFormat RGB32
        {
            get
            {
                return ColorFormatRGBA32.Instance;
            }
        }

        /// <summary>
        /// Gets the <see cref="ColorFormat"/> for 48-bit RGB color.
        /// </summary>
        public static ColorFormat RGB48
        {
            get
            {
                return ColorFormatRGB48.Instance;
            }
        }

        /// <summary>
        /// Gets the <see cref="ColorFormat"/> for 64-bit RGB color; 48-bit RGB plus 16-bit Alpha channel.
        /// </summary>
        public static ColorFormat RGB64
        {
            get
            {
                return ColorFormatRGBA64.Instance;
            }
        }

        /// <summary>
        /// Gets the <see cref="ColorFormat"/> for 96-bit floating-point RGB color.
        /// </summary>
        public static ColorFormat RGB96
        {
            get
            {
                return ColorFormatRGB96.Instance;
            }
        }

        /// <summary>
        /// Gets the number of bits required to represent a color with the current format.
        /// </summary>
        public abstract int BitsPerPixel
        {
            get;
        }

        /// <summary>
        /// Gets the <see cref="ColorChannels"/> used by the current <see cref="ColorFormat"/>.
        /// </summary>
        public abstract ColorChannels Channels
        {
            get;
        }

        /// <summary>
        /// Gets a value indicating whether all the color channels are represented using an equal number of bits.
        /// </summary>
        public virtual bool IsHomogenous
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets a value indicating whether pixels in the current format start on octet-aligned boundaries,
        /// when multiple pixels are packed as a series of bytes.
        /// </summary>
        public virtual bool IsOctetAligned
        {
            get
            {
                return (this.BitsPerPixel % 8) == 0;
            }
        }

        /// <summary>
        /// Gets a value indicating whether transparency is supported via the Alpha channel.
        /// </summary>
        public virtual bool SupportsTransparency
        {
            get
            {
                return (this.Channels & ColorChannels.Alpha) == ColorChannels.Alpha;
            }
        }
        #endregion
        #region Methods
        /// <summary>
        /// Gets the number of bits used by the specified <see cref="ColorChannels"/> configuration.
        /// </summary>
        /// <param name="channel">The channel or channels to query.</param>
        /// <returns>The number of bits used by the <see cref="ColorChannels"/> specified.</returns>
        public abstract int BitsPerChannel(ColorChannels channel);

        /// <summary>
        /// Creates a bitmap with the specified dimensions.
        /// </summary>
        /// <param name="width">The width (in pixels) of the new bitmap.</param>
        /// <param name="height">The height (in pixels) of the new bitmap.</param>
        /// <returns>A new <see cref="IBitmap"/> with the specified dimensions.</returns>
        public IBitmap CreateBitmap(int width, int height)
        {
            return this.CreateBitmap(new Size(width, height));
        }

        /// <summary>
        /// Creates a bitmap with the specified dimensions.
        /// </summary>
        /// <param name="size">The dimensions (in pixels) of the new bitmap.</param>
        /// <returns>A new <see cref="IBitmap"/> with the specified dimensions.</returns>
        public abstract IBitmap CreateBitmap(Size size);

        /// <summary>
        /// Creates a new color instance in the current format.
        /// </summary>
        /// <param name="original">An <see cref="IColor"/> instance representing the color to convert from.</param>
        /// <returns>A new color instance that is the conversion of the original color to the current format.</returns>
        public abstract IColor CreateColor(IColor original);

        /// <summary>
        /// Gets a bit mask that indicates which portions of a pixel are occupied by the specified color channels.
        /// </summary>
        /// <param name="channels">The color channel(s) to get the mask for.</param>
        /// <returns>A new byte array that is the same number of bytes as required to represent a single pixel.</returns>
        public abstract byte[] GetBitMask(ColorChannels channels);

        /// <summary>
        /// Gets the number of bytes required to represent a hypothetical bitmap with the specified size.
        /// </summary>
        /// <param name="size">The size of the hypothetical bitmap.</param>
        /// <returns>The number of bytes that would be required to fully represent a bitmap with the specified size.</returns>
        public virtual int GetByteCount(Size size)
        {
            return (size.Elements * this.BitsPerPixel) / 8;
        }

        /// <summary>
        /// Gets the number of bytes required to represent a hypothetical bitmap with the specified width and height.
        /// </summary>
        /// <param name="width">The width of the hypothetical bitmap.</param>
        /// <param name="height">The height of the hypothetical bitmap.</param>
        /// <returns>The number of bytes that would be required to fully represent a bitmap with the specified width and height.</returns>
        public int GetByteCount(int width, int height)
        {
            return this.GetByteCount(new Size(width, height));
        }

        /// <summary>
        /// Gets a value indicating whether a conversion from the current <see cref="ColorFormat"/> to the target format might result in a loss of data.
        /// </summary>
        /// <param name="target">The target <see cref="ColorFormat"/> to convert to.</param>
        /// <returns>true if a color or bitmap conversion from the current format to the target format would result in a loss of data or precision,
        /// otherwise false.</returns>
        /// <remarks>
        /// This method can be overriden to change the default behavior. The default behavior assumes a lossy conversion:
        /// If the target format does not support alpha channels, but the current format does.
        /// OR
        /// If the target format has a lesser bit depth than the current format.
        /// OR
        /// If the colorspace of the target format is different from the current format.
        /// </remarks>
        public virtual bool IsLossyConversionTo(ColorFormat target)
        {
            if (target.BitsPerPixel < this.BitsPerPixel)
                return true;

            return true;
        }
        #endregion
        #region Inner Types
        /// <summary>
        /// Provides a <see cref="ColorFormat"/> implementation which supports 24-bit RGB color.
        /// </summary>
        internal sealed class ColorFormatRGB24 : ColorFormat
        {
            #region Fields
            /// <summary>
            /// Holds the singleton instance of the <see cref="ColorFormatRGB24"/> class.
            /// </summary>
            internal static readonly ColorFormat Instance = new ColorFormatRGB24();
            #endregion
            #region Constructors
            /// <summary>
            /// Prevents a default instance of the <see cref="ColorFormatRGB24"/> class from being created.
            /// </summary>
            private ColorFormatRGB24()
            {
            }
            #endregion
            #region Properties
            /// <summary>
            /// Gets the bits required to represent a <see cref="ColorRGB24"/> (24).
            /// </summary>
            public override int BitsPerPixel
            {
                get
                {
                    return 24;
                }
            }

            /// <summary>
            /// Gets the <see cref="ColorChannels"/> used by the current <see cref="ColorFormat"/>.
            /// </summary>
            public override ColorChannels Channels
            {
                get
                {
                    return ColorChannels.RGB;
                }
            }
            #endregion
            #region Methods
            public override int BitsPerChannel(ColorChannels channel)
            {
                return (channel & ColorChannels.Red) == ColorChannels.Red ? 8 : 0
                     + (channel & ColorChannels.Green) == ColorChannels.Green ? 8 : 0
                     + (channel & ColorChannels.Blue) == ColorChannels.Blue ? 8 : 0;
            }

            public override IBitmap CreateBitmap(Size size)
            {
                return new BitmapRGB24(size);
            }

            public override IColor CreateColor(IColor original)
            {
                return new ColorRGB24((byte)(original.Red * original.Alpha * 255), (byte)(original.Green * original.Alpha * 255), (byte)(original.Blue * original.Alpha * 255));
            }

            public override byte[] GetBitMask(ColorChannels channels)
            {
                var result = new byte[3];
                if ((channels & ColorChannels.Red) == ColorChannels.Red)
                    result[0] = 0xFF;
                if ((channels & ColorChannels.Green) == ColorChannels.Green)
                    result[1] = 0xFF;
                if ((channels & ColorChannels.Blue) == ColorChannels.Blue)
                    result[2] = 0xFF;

                return result;
            }
            #endregion
        }

        /// <summary>
        /// Provides a <see cref="ColorFormat"/> implementation which supports 48-bit RGB color.
        /// </summary>
        internal sealed class ColorFormatRGB48 : ColorFormat
        {
            #region Fields
            /// <summary>
            /// Holds the singleton instance of the <see cref="ColorFormatRGB48"/> class.
            /// </summary>
            internal static readonly ColorFormat Instance = new ColorFormatRGB48();
            #endregion
            #region Constructors
            /// <summary>
            /// Prevents a default instance of the <see cref="ColorFormatRGB48"/> class from being created.
            /// </summary>
            private ColorFormatRGB48()
            {
            }
            #endregion
            #region Properties
            /// <summary>
            /// Gets the bits required to represent a <see cref="ColorRGB48"/> (48).
            /// </summary>
            public override int BitsPerPixel
            {
                get
                {
                    return 48;
                }
            }

            /// <summary>
            /// Gets the <see cref="ColorChannels"/> used by the current <see cref="ColorFormat"/>.
            /// </summary>
            public override ColorChannels Channels
            {
                get
                {
                    return ColorChannels.RGB;
                }
            }
            public override bool IsHomogenous
            {
                get
                {
                    return true;
                }
            }
            public override bool SupportsTransparency
            {
                get
                {
                    return false;
                }
            }
            #endregion
            #region Methods
            public override int BitsPerChannel(ColorChannels channel)
            {
                return (channel & ColorChannels.Red) == ColorChannels.Red ? 16 : 0
                     + (channel & ColorChannels.Green) == ColorChannels.Green ? 16 : 0
                     + (channel & ColorChannels.Blue) == ColorChannels.Blue ? 16 : 0;
            }

            public override IBitmap CreateBitmap(Size size)
            {
                return new BitmapRGB48(size);
            }

            public override IColor CreateColor(IColor original)
            {
                return new ColorRGB48(
                    (ushort)(original.Red * original.Alpha * ushort.MaxValue),
                    (ushort)(original.Green * original.Alpha * ushort.MaxValue),
                    (ushort)(original.Blue * original.Alpha * ushort.MaxValue));
            }

            public override byte[] GetBitMask(ColorChannels channels)
            {
                var result = new byte[6];
                if ((channels & ColorChannels.Red) == ColorChannels.Red)
                    result[0] = result[1] = 0xFF;
                if ((channels & ColorChannels.Green) == ColorChannels.Green)
                    result[2] = result[3] = 0xFF;
                if ((channels & ColorChannels.Blue) == ColorChannels.Blue)
                    result[4] = result[5] = 0xFF;

                return result;
            }
            #endregion
        }

        /// <summary>
        /// Provides a <see cref="ColorFormat"/> implementation which supports 96-bit RGB color.
        /// </summary>
        internal sealed class ColorFormatRGB96 : ColorFormat
        {
            #region Fields
            /// <summary>
            /// Holds the singleton instance of the <see cref="ColorFormatRGB96"/> class.
            /// </summary>
            internal static readonly ColorFormat Instance = new ColorFormatRGB96();
            #endregion
            #region Constructors
            /// <summary>
            /// Prevents a default instance of the <see cref="ColorFormatRGB96"/> class from being created.
            /// </summary>
            private ColorFormatRGB96()
            {
            }
            #endregion
            #region Properties
            /// <summary>
            /// Gets the bits required to represent a <see cref="ColorRGB96"/> (96).
            /// </summary>
            public override int BitsPerPixel
            {
                get
                {
                    return 96;
                }
            }

            /// <summary>
            /// Gets the <see cref="ColorChannels"/> used by the current <see cref="ColorFormat"/>.
            /// </summary>
            public override ColorChannels Channels
            {
                get
                {
                    throw new NotImplementedException();
                }
            }
            public override bool IsHomogenous
            {
                get
                {
                    return true;
                }
            }
            public override bool SupportsTransparency
            {
                get
                {
                    return false;
                }
            }
            #endregion
            #region Methods
            public override int BitsPerChannel(ColorChannels channel)
            {
                return (channel & ColorChannels.Red) == ColorChannels.Red ? 32 : 0
                     + (channel & ColorChannels.Green) == ColorChannels.Green ? 32 : 0
                     + (channel & ColorChannels.Blue) == ColorChannels.Blue ? 32 : 0;
            }

            public override IBitmap CreateBitmap(Size size)
            {
                return new BitmapRGB96(size);
            }

            public override IColor CreateColor(IColor original)
            {
                return new ColorRGB96(original.Red * original.Alpha, original.Green * original.Alpha, original.Blue * original.Alpha);
            }

            public override byte[] GetBitMask(ColorChannels channels)
            {
                var result = new byte[6];
                if ((channels & ColorChannels.Red) == ColorChannels.Red)
                    result[0] = result[1] = result[2] = result[3] = 0xFF;
                if ((channels & ColorChannels.Green) == ColorChannels.Green)
                    result[4] = result[5] = result[6] = result[7] = 0xFF;
                if ((channels & ColorChannels.Blue) == ColorChannels.Blue)
                    result[8] = result[9] = result[10] = result[11] = 0xFF;

                return result;
            }
            #endregion
        }

        /// <summary>
        /// Provides a <see cref="ColorFormat"/> implementation which supports 32-bit RGBA color.
        /// </summary>
        internal sealed class ColorFormatRGBA32 : ColorFormat
        {
            #region Fields
            /// <summary>
            /// Holds the singleton instance of the <see cref="ColorFormatRGBA32"/> class.
            /// </summary>
            internal static readonly ColorFormat Instance = new ColorFormatRGBA32();
            #endregion
            #region Constructors
            /// <summary>
            /// Prevents a default instance of the <see cref="ColorFormatRGBA32"/> class from being created.
            /// </summary>
            private ColorFormatRGBA32()
            {
            }
            #endregion
            #region Properties

            /// <summary>
            /// Gets the bits required to represent a <see cref="ColorRGBA32"/> (32).
            /// </summary>
            public override int BitsPerPixel
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            /// <summary>
            /// Gets the <see cref="ColorChannels"/> used by the current <see cref="ColorFormat"/>.
            /// </summary>
            public override ColorChannels Channels
            {
                get
                {
                    throw new NotImplementedException();
                }
            }
            #endregion
            #region Methods
            public override int BitsPerChannel(ColorChannels channel)
            {
                return (channel & ColorChannels.Red) == ColorChannels.Red ? 8 : 0
                     + (channel & ColorChannels.Green) == ColorChannels.Green ? 8 : 0
                     + (channel & ColorChannels.Blue) == ColorChannels.Blue ? 8 : 0
                     + (channel & ColorChannels.Alpha) == ColorChannels.Alpha ? 8 : 0;
            }

            public override IBitmap CreateBitmap(Size size)
            {
                return new BitmapRGB32(size);
            }

            public override IColor CreateColor(IColor original)
            {
                throw new NotImplementedException();
            }

            public override byte[] GetBitMask(ColorChannels channels)
            {
                var result = new byte[4];
                if ((channels & ColorChannels.Red) == ColorChannels.Red)
                    result[0] = 0xFF;
                if ((channels & ColorChannels.Green) == ColorChannels.Green)
                    result[1] = 0xFF;
                if ((channels & ColorChannels.Blue) == ColorChannels.Blue)
                    result[2] = 0xFF;
                if ((channels & ColorChannels.Alpha) == ColorChannels.Alpha)
                    result[3] = 0xFF;

                return result;
            }
            #endregion
        }

        /// <summary>
        /// Provides a <see cref="ColorFormat"/> implementation which supports 64-bit RGBA color.
        /// </summary>
        internal sealed class ColorFormatRGBA64 : ColorFormat
        {
            #region Fields
            /// <summary>
            /// Holds the singleton instance of the <see cref="ColorFormatRGBA64"/> class.
            /// </summary>
            internal static readonly ColorFormat Instance = new ColorFormatRGBA64();
            #endregion
            #region Constructors
            /// <summary>
            /// Prevents a default instance of the <see cref="ColorFormatRGBA64"/> class from being created.
            /// </summary>
            private ColorFormatRGBA64()
            {
            }
            #endregion
            #region Properties
            /// <summary>
            /// Gets the bits required to represent a <see cref="ColorRGBA64"/> (64).
            /// </summary>
            public override int BitsPerPixel
            {
                get
                {
                    return 64;
                }
            }

            /// <summary>
            /// Gets the <see cref="ColorChannels"/> used by the current <see cref="ColorFormat"/>.
            /// </summary>
            public override ColorChannels Channels
            {
                get
                {
                    return ColorChannels.RGBA;
                }
            }
            #endregion
            #region Methods
            public override int BitsPerChannel(ColorChannels channel)
            {
                return (channel & ColorChannels.Red) == ColorChannels.Red ? 16 : 0
                     + (channel & ColorChannels.Green) == ColorChannels.Green ? 16 : 0
                     + (channel & ColorChannels.Blue) == ColorChannels.Blue ? 16 : 0
                     + (channel & ColorChannels.Alpha) == ColorChannels.Alpha ? 16 : 0;
            }

            public override IBitmap CreateBitmap(Size size)
            {
                return new BitmapRGB64(size);
            }

            public override IColor CreateColor(IColor original)
            {
                throw new NotImplementedException();
            }

            public override byte[] GetBitMask(ColorChannels channels)
            {
                var result = new byte[6];
                if ((channels & ColorChannels.Red) == ColorChannels.Red)
                    result[0] = result[1] = 0xFF;
                if ((channels & ColorChannels.Green) == ColorChannels.Green)
                    result[2] = result[3] = 0xFF;
                if ((channels & ColorChannels.Blue) == ColorChannels.Blue)
                    result[4] = result[5] = 0xFF;
                if ((channels & ColorChannels.Alpha) == ColorChannels.Alpha)
                    result[6] = result[7] = 0xFF;

                return result;
            }
            #endregion
        }

        /// <summary>
        /// Provides a <see cref="ColorFormat"/> implementation which supports 128-bit floating point RGBA color.
        /// </summary>
        internal sealed class ColorFormatRGB : ColorFormat
        {
            #region Fields
            /// <summary>
            /// Holds the singleton instance of the <see cref="ColorFormatRGB"/> class.
            /// </summary>
            internal static readonly ColorFormatRGB Instance = new ColorFormatRGB();
            #endregion
            #region Constructors
            /// <summary>
            /// Prevents a default instance of the <see cref="ColorFormatRGB"/> class from being created.
            /// </summary>
            private ColorFormatRGB()
            {
            }
            #endregion
            #region Properties
            /// <summary>
            /// Gets the bits required to represent a <see cref="ColorRGB"/> (128).
            /// </summary>
            public override int BitsPerPixel
            {
                get
                {
                    return 128;
                }
            }

            /// <summary>
            /// Gets the <see cref="ColorChannels"/> used by the current <see cref="ColorFormat"/>.
            /// </summary>
            public override ColorChannels Channels
            {
                get
                {
                    return ColorChannels.RGBA;
                }
            }
            #endregion
            #region Methods
            public override int BitsPerChannel(ColorChannels channel)
            {
                return (channel & ColorChannels.Red) == ColorChannels.Red ? 32 : 0
                     + (channel & ColorChannels.Green) == ColorChannels.Green ? 32 : 0
                     + (channel & ColorChannels.Blue) == ColorChannels.Blue ? 32 : 0
                     + (channel & ColorChannels.Alpha) == ColorChannels.Alpha ? 32 : 0;
            }
            public override IBitmap CreateBitmap(Size size)
            {
                return new BitmapRGB(size);
            }
            public override IColor CreateColor(IColor original)
            {
                throw new NotImplementedException();
            }
            public override byte[] GetBitMask(ColorChannels channels)
            {
                var result = new byte[16];

                if ((channels & ColorChannels.Red) == ColorChannels.Red)
                    result[0x0] = result[0x1] = result[0x2] = result[0x3] = 0xFF;
                if ((channels & ColorChannels.Green) == ColorChannels.Green)
                    result[0x4] = result[0x5] = result[0x6] = result[0x7] = 0xFF;
                if ((channels & ColorChannels.Blue) == ColorChannels.Blue)
                    result[0x8] = result[0x9] = result[0xA] = result[0xB] = 0xFF;
                if ((channels & ColorChannels.Alpha) == ColorChannels.Alpha)
                    result[0xC] = result[0xD] = result[0xE] = result[0xF] = 0xFF;

                return result;
            }
            #endregion
        }
        #endregion
    }
}
