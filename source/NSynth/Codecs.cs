/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/

namespace NSynth
{
    /// <summary>
    /// Provides instances of all built-in codecs.
    /// </summary>
    public static class Codecs
    {
        #region Fields
        /// <summary>
        /// Backing field for the <see cref="Codecs.AAC"/> property.
        /// </summary>
        private static Audio.AAC.AACCodec aac = new Audio.AAC.AACCodec();

        /// <summary>
        /// Backing field for the <see cref="Codecs.DTS"/> property.
        /// </summary>
        private static Audio.DTS.DTSCodec dts = new Audio.DTS.DTSCodec();

        /// <summary>
        /// Backing field for the <see cref="Codecs.FLAC"/> property.
        /// </summary>
        private static Audio.FLAC.FLACCodec flac = new Audio.FLAC.FLACCodec();

        /// <summary>
        /// Backing field for the <see cref="Codecs.LPCM"/> property.
        /// </summary>
        private static Audio.LPCM.LPCMCodec lpcm = new Audio.LPCM.LPCMCodec();

        /// <summary>
        /// Backing field for the <see cref="Codecs.Vorbis"/> property.
        /// </summary>
        private static Audio.Vorbis.VorbisCodec vorbis = new Audio.Vorbis.VorbisCodec();

        /// <summary>
        /// Backing field for the <see cref="Codecs.WAV"/> property.
        /// </summary>
        private static Audio.WAV.WAVCodec wav = new Audio.WAV.WAVCodec();

        /// <summary>
        /// Backing field for the <see cref="Codecs.AVI"/> property.
        /// </summary>
        private static Containers.AVI.AVIContainer avi = new Containers.AVI.AVIContainer();

        /// <summary>
        /// Backing field for the <see cref="Codecs.MKV"/> property.
        /// </summary>
        private static Containers.MKV.MKVContainer mkv = new Containers.MKV.MKVContainer();

        /// <summary>
        /// Backing field for the <see cref="Codecs.BMP"/> property.
        /// </summary>
        private static Imaging.BMP.BMPCodec bmp = new Imaging.BMP.BMPCodec();

        /// <summary>
        /// Backing field for the <see cref="Codecs.JPEG"/> property.
        /// </summary>
        private static Imaging.JPEG.JPEGCodec jpeg = new Imaging.JPEG.JPEGCodec();

        /// <summary>
        /// Backing field for the <see cref="Codecs.PNG"/> property.
        /// </summary>
        private static Imaging.PNG.PNGCodec png = new Imaging.PNG.PNGCodec();

        /// <summary>
        /// Backing field for the <see cref="Codecs.TGA"/> property.
        /// </summary>
        private static Imaging.TGA.TGACodec tga = new Imaging.TGA.TGACodec();

        /// <summary>
        /// Backing field for the <see cref="Codecs.TIFF"/> property.
        /// </summary>
        private static Imaging.TIFF.TIFFCodec tiff = new Imaging.TIFF.TIFFCodec();

        /// <summary>
        /// Backing field for the <see cref="Codecs.Dirac"/> property.
        /// </summary>
        private static Video.Dirac.DiracCodec dirac = new Video.Dirac.DiracCodec();

        /// <summary>
        /// Backing field for the <see cref="Codecs.H262"/> property.
        /// </summary>
        private static Video.H262.H262Codec h262 = new Video.H262.H262Codec();

        /// <summary>
        /// Backing field for the <see cref="Codecs.H264"/> property.
        /// </summary>
        private static Video.H264.H264Codec h264 = new Video.H264.H264Codec();

        /// <summary>
        /// Backing field for the <see cref="Codecs.VC1"/> property.
        /// </summary>
        private static Video.VC1.VC1Codec vc1 = new Video.VC1.VC1Codec();

        /// <summary>
        /// Backing field for the <see cref="Codecs.VP8"/> property.
        /// </summary>
        private static Video.VP8.VP8Codec vp8 = new Video.VP8.VP8Codec();
        #endregion
        #region Properties
        #region Audio Codecs
        /// <summary>
        /// Gets the codec for Advanced Audio Coding.
        /// </summary>
        public static Audio.AAC.AACCodec AAC
        {
            get
            {
                return Codecs.aac;
            }
        }

        /// <summary>
        /// Gets the codec for Digital Theater Systems Coherent Acoustics.
        /// </summary>
        public static Audio.DTS.DTSCodec DTS
        {
            get
            {
                return Codecs.dts;
            }
        }

        /// <summary>
        /// Gets the codec for Free Lossless Audio Codec.
        /// </summary>
        public static Audio.FLAC.FLACCodec FLAC
        {
            get
            {
                return Codecs.flac;
            }
        }

        /// <summary>
        /// Gets the codec for Linear Pulse Code Modulation.
        /// </summary>
        public static Audio.LPCM.LPCMCodec LPCM
        {
            get
            {
                return Codecs.lpcm;
            }
        }

        /// <summary>
        /// Gets the codec for Vorbis.
        /// </summary>
        public static Audio.Vorbis.VorbisCodec Vorbis
        {
            get
            {
                return Codecs.vorbis;
            }
        }

        /// <summary>
        /// Gets the codec for Microsoft WAVE.
        /// </summary>
        public static Audio.WAV.WAVCodec WAV
        {
            get
            {
                return Codecs.wav;
            }
        }
        #endregion
        #region Container Codecs
        public static Containers.AVI.AVIContainer AVI
        {
            get
            {
                return Codecs.avi;
            }
        }
        public static Containers.MKV.MKVContainer MKV
        {
            get
            {
                return Codecs.mkv;
            }
        }
        #endregion
        #region Image Codecs
        public static Imaging.BMP.BMPCodec BMP
        {
            get
            {
                return Codecs.bmp;
            }
        }

        public static Imaging.JPEG.JPEGCodec JPEG
        {
            get
            {
                return Codecs.jpeg;
            }
        }

        public static Imaging.PNG.PNGCodec PNG
        {
            get
            {
                return Codecs.png;
            }
        }
        public static Imaging.TGA.TGACodec TGA
        {
            get
            {
                return Codecs.tga;
            }
        }
        public static Imaging.TIFF.TIFFCodec TIFF
        {
            get
            {
                return Codecs.tiff;
            }
        }
        #endregion
        #region Video Codecs
        public static Video.Dirac.DiracCodec Dirac
        {
            get
            {
                return Codecs.dirac;
            }
        }
        public static Video.H262.H262Codec H262
        {
            get
            {
                return Codecs.h262;
            }
        }
        public static Video.H264.H264Codec H264
        {
            get
            {
                return Codecs.h264;
            }
        }
        public static Video.VC1.VC1Codec VC1
        {
            get
            {
                return Codecs.vc1;
            }
        }

        public static Video.VP8.VP8Codec VP8
        {
            get
            {
                return Codecs.vp8;
            }
        }
        #endregion
        #endregion
    }
}
