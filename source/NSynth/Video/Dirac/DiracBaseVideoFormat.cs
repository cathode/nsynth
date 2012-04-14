/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2012 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using NSynth.Imaging;

namespace NSynth.Video.Dirac
{
    /// <summary>
    /// Represents base video formats for the Dirac video codec. This class is immutable.
    /// </summary>
    public sealed class DiracBaseVideoFormat
    {
        #region Fields
        /// <summary>
        /// Holds instances of supported base video formats.
        /// </summary>
        private static readonly DiracBaseVideoFormat[] predefined;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes static members of the <see cref="DiracBaseVideoFormat"/> class.
        /// </summary>
        static DiracBaseVideoFormat()
        {
            var formats = new DiracBaseVideoFormat[20];

            formats[(int)DiracPredefinedVideoFormats.Custom] = new DiracBaseVideoFormat()
            {
                Name = "Custom",
                Dimensions = new FrameDimensions()
                {
                    Width = 640,
                    Height = 640,
                },
                ChromaSamplingFormat = SubsamplingMode.J420,
                SourceSampling = false,
                TopFieldFirst = false,
                FrameRateIndex = 1,
                FrameRate = new SampleRate(24000, 1001),
                PixelAspectRatioIndex = 1,
                PixelAspectRatioNumerator = 1,
                PixelAspectRatioDenominator = 1,
                SignalRangeIndex = 1,
                LumaOffset = 0,
                LumaExcursion = 255,
                ChromaOffset = 128,
                ChromaExcursion = 255,
                ColorSpecificationIndex = DiracColorSpecification.Custom,
                ColorPrimariesIndex = DiracColorPrimaries.HDTV,
                ColorMatrixIndex = DiracColorMatrix.HDTV,
                TransferFunctionIndex = DiracTransferFunction.TVGamma,
            };
            formats[(int)DiracPredefinedVideoFormats.QSIF525] = new DiracBaseVideoFormat()
            {
                Name = "QSIF525",
                Dimensions = new FrameDimensions()
                {
                    Width = 176,
                    Height = 120,
                },
                ChromaSamplingFormat = SubsamplingMode.J420,
                SourceSampling = false,
                TopFieldFirst = false,
                FrameRateIndex = 9,
                FrameRate = new SampleRate(15000, 1001),
                PixelAspectRatioIndex = 2,
                PixelAspectRatioNumerator = 10,
                PixelAspectRatioDenominator = 11,
                SignalRangeIndex = 1,
                LumaOffset = 0,
                LumaExcursion = 255,
                ChromaOffset = 128,
                ChromaExcursion = 255,
                ColorSpecificationIndex = DiracColorSpecification.SDTV525,
                ColorPrimariesIndex = DiracColorPrimaries.SDTV525,
                ColorMatrixIndex = DiracColorMatrix.SDTV,
                TransferFunctionIndex = DiracTransferFunction.TVGamma,
            };
            formats[(int)DiracPredefinedVideoFormats.QCIF] = new DiracBaseVideoFormat()
            {
                Name = "QCIF",
                Dimensions = new FrameDimensions()
                {
                    Width = 176,
                    Height = 144,
                },
                ChromaSamplingFormat = SubsamplingMode.J420,
                SourceSampling = false,
                TopFieldFirst = true,
                FrameRateIndex = 10,
                FrameRate = new SampleRate(25, 2),
                PixelAspectRatioIndex = 3,
                PixelAspectRatioNumerator = 12,
                PixelAspectRatioDenominator = 11,
                SignalRangeIndex = 1,
                LumaOffset = 0,
                LumaExcursion = 255,
                ChromaOffset = 128,
                ChromaExcursion = 255,
                ColorSpecificationIndex = DiracColorSpecification.SDTV625,
                ColorPrimariesIndex = DiracColorPrimaries.SDTV625,
                ColorMatrixIndex = DiracColorMatrix.SDTV,
                TransferFunctionIndex = DiracTransferFunction.TVGamma,
            };
            formats[(int)DiracPredefinedVideoFormats.SIF525] = new DiracBaseVideoFormat()
            {
                Name = "SIF525",
                Dimensions = new FrameDimensions()
                {
                    Width = 352,
                    Height = 249,
                },
                ChromaSamplingFormat = SubsamplingMode.J420,
                SourceSampling = false,
                TopFieldFirst = false,
                FrameRateIndex = 9,
                FrameRate = new SampleRate(15000, 1001),
                PixelAspectRatioIndex = 2,
                PixelAspectRatioNumerator = 10,
                PixelAspectRatioDenominator = 11,
                SignalRangeIndex = 1,
                LumaOffset = 0,
                LumaExcursion = 255,
                ChromaOffset = 128,
                ChromaExcursion = 255,
                ColorSpecificationIndex = DiracColorSpecification.SDTV525,
                ColorPrimariesIndex = DiracColorPrimaries.SDTV525,
                ColorMatrixIndex = DiracColorMatrix.SDTV,
                TransferFunctionIndex = DiracTransferFunction.TVGamma,
            };
            formats[(int)DiracPredefinedVideoFormats.CIF] = new DiracBaseVideoFormat()
            {
                Name = "CIF",
                Dimensions = new FrameDimensions()
                {
                    Width = 352,
                    Height = 288,
                },
                ChromaSamplingFormat = SubsamplingMode.J420,
                SourceSampling = false,
                TopFieldFirst = true,
                FrameRateIndex = 10,
                FrameRate = new SampleRate(25, 2),
                PixelAspectRatioIndex = 3,
                PixelAspectRatioNumerator = 12,
                PixelAspectRatioDenominator = 11,
                SignalRangeIndex = 1,
                LumaOffset = 0,
                LumaExcursion = 255,
                ChromaOffset = 128,
                ChromaExcursion = 255,
                ColorSpecificationIndex = DiracColorSpecification.SDTV625,
                ColorPrimariesIndex = DiracColorPrimaries.SDTV625,
                ColorMatrixIndex = DiracColorMatrix.SDTV,
                TransferFunctionIndex = DiracTransferFunction.TVGamma,
            };
            formats[(int)DiracPredefinedVideoFormats.X4SIF525] = new DiracBaseVideoFormat()
            {
                Name = "4SIF525",
                Dimensions = new FrameDimensions()
                {
                    Width = 704,
                    Height = 480,
                },
                ChromaSamplingFormat = SubsamplingMode.J420,
                SourceSampling = false,
                TopFieldFirst = false,
                FrameRateIndex = 9,
                FrameRate = new SampleRate(15000, 1001),
                PixelAspectRatioIndex = 2,
                PixelAspectRatioNumerator = 10,
                PixelAspectRatioDenominator = 11,
                SignalRangeIndex = 1,
                LumaOffset = 0,
                LumaExcursion = 255,
                ChromaOffset = 128,
                ChromaExcursion = 255,
                ColorSpecificationIndex = DiracColorSpecification.SDTV525,
                ColorPrimariesIndex = DiracColorPrimaries.SDTV525,
                ColorMatrixIndex = DiracColorMatrix.SDTV,
                TransferFunctionIndex = DiracTransferFunction.TVGamma,
            };
            formats[(int)DiracPredefinedVideoFormats.X4CIF] = new DiracBaseVideoFormat()
            {
                Name = "4CIF",
                Dimensions = new FrameDimensions()
                {
                    Width = 704,
                    Height = 576,
                },
                ChromaSamplingFormat = SubsamplingMode.J420,
                SourceSampling = false,
                TopFieldFirst = true,
                FrameRateIndex = 10,
                FrameRate = new SampleRate(25, 2),
                PixelAspectRatioIndex = 3,
                PixelAspectRatioNumerator = 12,
                PixelAspectRatioDenominator = 11,
                SignalRangeIndex = 1,
                LumaOffset = 0,
                LumaExcursion = 255,
                ChromaOffset = 128,
                ChromaExcursion = 255,
                ColorSpecificationIndex = DiracColorSpecification.SDTV625,
                ColorPrimariesIndex = DiracColorPrimaries.SDTV625,
                ColorMatrixIndex = DiracColorMatrix.SDTV,
                TransferFunctionIndex = DiracTransferFunction.TVGamma,
            };
            formats[(int)DiracPredefinedVideoFormats.SD480I60] = new DiracBaseVideoFormat()
            {
                Name = "SD480-60I",
                Dimensions = new FrameDimensions()
                {
                    Width = 720,
                    Height = 480,
                    CleanWidth = 704,
                    CleanHeight = 480,
                },
                ChromaSamplingFormat = SubsamplingMode.J422,
                SourceSampling = true,
                TopFieldFirst = false,
                FrameRateIndex = 4,
                FrameRate = new SampleRate(30000, 1001),
                PixelAspectRatioIndex = 2,
                PixelAspectRatioNumerator = 10,
                PixelAspectRatioDenominator = 11,
                SignalRangeIndex = 3,
                LumaOffset = 64,
                LumaExcursion = 876,
                ChromaOffset = 512,
                ChromaExcursion = 896,
                ColorSpecificationIndex = DiracColorSpecification.SDTV525,
                ColorPrimariesIndex = DiracColorPrimaries.SDTV525,
                ColorMatrixIndex = DiracColorMatrix.SDTV,
                TransferFunctionIndex = DiracTransferFunction.TVGamma,
            };
            formats[(int)DiracPredefinedVideoFormats.SD576I50] = new DiracBaseVideoFormat()
            {
                Name = "SD576-50I",
                Dimensions = new FrameDimensions()
                {
                    Width = 720,
                    Height = 576,
                    CleanWidth = 704,
                    CleanHeight = 576,
                },
                ChromaSamplingFormat = SubsamplingMode.J422,
                SourceSampling = true,
                TopFieldFirst = true,
                FrameRateIndex = 3,
                FrameRate = new SampleRate(25, 1),
                PixelAspectRatioIndex = 3,
                PixelAspectRatioNumerator = 12,
                PixelAspectRatioDenominator = 11,
                SignalRangeIndex = 3,
                LumaOffset = 64,
                LumaExcursion = 876,
                ChromaOffset = 512,
                ChromaExcursion = 896,
                ColorSpecificationIndex = DiracColorSpecification.SDTV625,
                ColorPrimariesIndex = DiracColorPrimaries.SDTV625,
                ColorMatrixIndex = DiracColorMatrix.SDTV,
                TransferFunctionIndex = DiracTransferFunction.TVGamma,
            };
            formats[(int)DiracPredefinedVideoFormats.HD720P50] = new DiracBaseVideoFormat()
            {
                Name = "HD720P-60",
                Dimensions = new FrameDimensions()
                {
                    Width = 1280,
                    Height = 720,
                },
                ChromaSamplingFormat = SubsamplingMode.J422,
                SourceSampling = false,
                TopFieldFirst = true,
                FrameRateIndex = 7,
                FrameRate = new SampleRate(60000, 1001),
                PixelAspectRatioIndex = 1,
                PixelAspectRatioNumerator = 1,
                PixelAspectRatioDenominator = 1,
                SignalRangeIndex = 3,
                LumaOffset = 64,
                LumaExcursion = 876,
                ChromaOffset = 512,
                ChromaExcursion = 896,
                ColorSpecificationIndex = DiracColorSpecification.HDTV,
                ColorPrimariesIndex = DiracColorPrimaries.HDTV,
                ColorMatrixIndex = DiracColorMatrix.HDTV,
                TransferFunctionIndex = DiracTransferFunction.TVGamma,
            };
            formats[(int)DiracPredefinedVideoFormats.HD720P50] = new DiracBaseVideoFormat()
            {
                Name = "HD720P-50",
                Dimensions = new FrameDimensions()
                {
                    Width = 1280,
                    Height = 720,
                },
                ChromaSamplingFormat = SubsamplingMode.J422,
                SourceSampling = false,
                TopFieldFirst = true,
                FrameRateIndex = 6,
                FrameRate = new SampleRate(50, 1),
                PixelAspectRatioIndex = 1,
                PixelAspectRatioNumerator = 1,
                PixelAspectRatioDenominator = 1,
                SignalRangeIndex = 3,
                LumaOffset = 64,
                LumaExcursion = 876,
                ChromaOffset = 512,
                ChromaExcursion = 896,
                ColorSpecificationIndex = DiracColorSpecification.HDTV,
                ColorPrimariesIndex = DiracColorPrimaries.HDTV,
                ColorMatrixIndex = DiracColorMatrix.HDTV,
                TransferFunctionIndex = DiracTransferFunction.TVGamma,
            };
            formats[(int)DiracPredefinedVideoFormats.HD1080I60] = new DiracBaseVideoFormat()
            {
                Name = "HD1080I-60",
                Dimensions = new FrameDimensions()
                {
                    Width = 1920,
                    Height = 1080,
                },
                ChromaSamplingFormat = SubsamplingMode.J422,
                SourceSampling = true,
                TopFieldFirst = true,
                FrameRateIndex = 4,
                FrameRate = new SampleRate(30000, 1001),
                PixelAspectRatioIndex = 1,
                PixelAspectRatioNumerator = 1,
                PixelAspectRatioDenominator = 1,
                SignalRangeIndex = 3,
                LumaOffset = 64,
                LumaExcursion = 876,
                ChromaOffset = 512,
                ChromaExcursion = 896,
                ColorSpecificationIndex = DiracColorSpecification.HDTV,
                ColorPrimariesIndex = DiracColorPrimaries.HDTV,
                ColorMatrixIndex = DiracColorMatrix.HDTV,
                TransferFunctionIndex = DiracTransferFunction.TVGamma,
            };
            formats[(int)DiracPredefinedVideoFormats.HD1080I50] = new DiracBaseVideoFormat()
            {
                Name = "HD1080I-50",
                Dimensions = new FrameDimensions()
                {
                    Width = 1920,
                    Height = 1080,
                },
                ChromaSamplingFormat = SubsamplingMode.J422,
                SourceSampling = true,
                TopFieldFirst = true,
                FrameRateIndex = 3,
                FrameRate = new SampleRate(25, 1),
                PixelAspectRatioIndex = 1,
                PixelAspectRatioNumerator = 1,
                PixelAspectRatioDenominator = 1,
                SignalRangeIndex = 3,
                LumaOffset = 64,
                LumaExcursion = 876,
                ChromaOffset = 512,
                ChromaExcursion = 896,
                ColorSpecificationIndex = DiracColorSpecification.HDTV,
                ColorPrimariesIndex = DiracColorPrimaries.HDTV,
                ColorMatrixIndex = DiracColorMatrix.HDTV,
                TransferFunctionIndex = DiracTransferFunction.TVGamma,
            };
            formats[(int)DiracPredefinedVideoFormats.HD1080P60] = new DiracBaseVideoFormat()
            {
                Name = "HD1080P-60",
                Dimensions = new FrameDimensions()
                {
                    Width = 1920,
                    Height = 1080,
                },
                ChromaSamplingFormat = SubsamplingMode.J422,
                SourceSampling = false,
                TopFieldFirst = true,
                FrameRateIndex = 7,
                FrameRate = new SampleRate(60000, 1001),
                PixelAspectRatioIndex = 1,
                PixelAspectRatioNumerator = 1,
                PixelAspectRatioDenominator = 1,
                SignalRangeIndex = 3,
                LumaOffset = 64,
                LumaExcursion = 876,
                ChromaOffset = 512,
                ChromaExcursion = 896,
                ColorSpecificationIndex = DiracColorSpecification.HDTV,
                ColorPrimariesIndex = DiracColorPrimaries.HDTV,
                ColorMatrixIndex = DiracColorMatrix.HDTV,
                TransferFunctionIndex = DiracTransferFunction.TVGamma,
            };
            formats[(int)DiracPredefinedVideoFormats.HD1080P50] = new DiracBaseVideoFormat()
            {
                Name = "HD1080P-50",
                Dimensions = new FrameDimensions()
                {
                    Width = 1920,
                    Height = 1080,
                },
                ChromaSamplingFormat = SubsamplingMode.J422,
                SourceSampling = false,
                TopFieldFirst = true,
                FrameRateIndex = 6,
                FrameRate = new SampleRate(50, 1),
                PixelAspectRatioIndex = 1,
                PixelAspectRatioNumerator = 1,
                PixelAspectRatioDenominator = 1,
                SignalRangeIndex = 3,
                LumaOffset = 64,
                LumaExcursion = 876,
                ChromaOffset = 512,
                ChromaExcursion = 896,
                ColorSpecificationIndex = DiracColorSpecification.HDTV,
                ColorPrimariesIndex = DiracColorPrimaries.HDTV,
                ColorMatrixIndex = DiracColorMatrix.HDTV,
                TransferFunctionIndex = DiracTransferFunction.TVGamma,
            };
            formats[(int)DiracPredefinedVideoFormats.DC2K24] = new DiracBaseVideoFormat()
            {
                Name = "DC2K",
                Dimensions = new FrameDimensions()
                {
                    Width = 2048,
                    Height = 1080,
                },
                ChromaSamplingFormat = SubsamplingMode.J444,
                SourceSampling = false,
                TopFieldFirst = true,
                FrameRateIndex = 2,
                FrameRate = new SampleRate(24, 1),
                PixelAspectRatioIndex = 1,
                PixelAspectRatioNumerator = 1,
                PixelAspectRatioDenominator = 1,
                SignalRangeIndex = 4,
                LumaOffset = 256,
                LumaExcursion = 3504,
                ChromaOffset = 2048,
                ChromaExcursion = 3584,
                ColorSpecificationIndex = DiracColorSpecification.Cinema,
                ColorPrimariesIndex = DiracColorPrimaries.Cinema,
                ColorMatrixIndex = DiracColorMatrix.HDTV,
                TransferFunctionIndex = DiracTransferFunction.TVGamma,
            };
            formats[(int)DiracPredefinedVideoFormats.DC4K24] = new DiracBaseVideoFormat()
            {
                Name = "DC4K",
                Dimensions = new FrameDimensions()
                {
                    Width = 4096,
                    Height = 2160,
                },
                ChromaSamplingFormat = SubsamplingMode.J444,
                SourceSampling = false,
                TopFieldFirst = true,
                FrameRateIndex = 2,
                FrameRate = new SampleRate(24, 1),
                PixelAspectRatioIndex = 1,
                PixelAspectRatioNumerator = 1,
                PixelAspectRatioDenominator = 1,
                SignalRangeIndex = 4,
                LumaOffset = 256,
                LumaExcursion = 3504,
                ChromaOffset = 2048,
                ChromaExcursion = 3584,
                ColorSpecificationIndex = DiracColorSpecification.Cinema,
                ColorPrimariesIndex = DiracColorPrimaries.Cinema,
                ColorMatrixIndex = DiracColorMatrix.HDTV,
                TransferFunctionIndex = DiracTransferFunction.TVGamma,
            };
            formats[(int)DiracPredefinedVideoFormats.UHDTV4K60] = new DiracBaseVideoFormat()
            {
                Name = "UHDTV 4K-60",
                Dimensions = new FrameDimensions()
                {
                    Width = 3840,
                    Height = 2160,
                },
                ChromaSamplingFormat = SubsamplingMode.J422,
                SourceSampling = false,
                TopFieldFirst = true,
                FrameRateIndex = 7,
                FrameRate = new SampleRate(60000, 1001),
                PixelAspectRatioIndex = 1,
                PixelAspectRatioNumerator = 1,
                PixelAspectRatioDenominator = 1,
                SignalRangeIndex = 3,
                LumaOffset = 64,
                LumaExcursion = 876,
                ChromaOffset = 512,
                ChromaExcursion = 896,
                ColorSpecificationIndex = DiracColorSpecification.HDTV,
                ColorPrimariesIndex = DiracColorPrimaries.HDTV,
                ColorMatrixIndex = DiracColorMatrix.HDTV,
                TransferFunctionIndex = DiracTransferFunction.TVGamma,
            };
            formats[(int)DiracPredefinedVideoFormats.UHDTV4K50] = new DiracBaseVideoFormat()
            {
                Name = "UHDTV 4K-50",
                Dimensions = new FrameDimensions()
                {
                    Width = 3840,
                    Height = 2160,
                },
                ChromaSamplingFormat = SubsamplingMode.J422,
                SourceSampling = false,
                TopFieldFirst = true,
                FrameRateIndex = 6,
                FrameRate = new SampleRate(50, 1),
                PixelAspectRatioIndex = 1,
                PixelAspectRatioNumerator = 1,
                PixelAspectRatioDenominator = 1,
                SignalRangeIndex = 3,
                LumaOffset = 64,
                LumaExcursion = 876,
                ChromaOffset = 512,
                ChromaExcursion = 896,
                ColorSpecificationIndex = DiracColorSpecification.HDTV,
                ColorPrimariesIndex = DiracColorPrimaries.HDTV,
                ColorMatrixIndex = DiracColorMatrix.HDTV,
                TransferFunctionIndex = DiracTransferFunction.TVGamma,
            };
            formats[(int)DiracPredefinedVideoFormats.UHDTV8K60] = new DiracBaseVideoFormat()
            {
                Name = "UHDTV 8K-60",
                Dimensions = new FrameDimensions()
                {
                    Width = 7680,
                    Height = 4320,
                },
                ChromaSamplingFormat = SubsamplingMode.J420,
                SourceSampling = false,
                TopFieldFirst = true,
                FrameRateIndex = 7,
                FrameRate = new SampleRate(60000, 1001),
                PixelAspectRatioIndex = 1,
                PixelAspectRatioNumerator = 1,
                PixelAspectRatioDenominator = 1,
                SignalRangeIndex = 3,
                LumaOffset = 64,
                LumaExcursion = 876,
                ChromaOffset = 512,
                ChromaExcursion = 896,
                ColorSpecificationIndex = DiracColorSpecification.HDTV,
                ColorPrimariesIndex = DiracColorPrimaries.HDTV,
                ColorMatrixIndex = DiracColorMatrix.HDTV,
                TransferFunctionIndex = DiracTransferFunction.TVGamma,
            };
            formats[(int)DiracPredefinedVideoFormats.UHDTV8K50] = new DiracBaseVideoFormat()
            {
                Name = "UHDTV 8K-50",
                Dimensions = new FrameDimensions()
                {
                    Width = 7680,
                    Height = 4320,
                },
                ChromaSamplingFormat = SubsamplingMode.J422,
                SourceSampling = false,
                TopFieldFirst = true,
                FrameRateIndex = 6,
                FrameRate = new SampleRate(50, 1),
                PixelAspectRatioIndex = 1,
                PixelAspectRatioNumerator = 1,
                PixelAspectRatioDenominator = 1,
                SignalRangeIndex = 3,
                LumaOffset = 64,
                LumaExcursion = 876,
                ChromaOffset = 512,
                ChromaExcursion = 896,
                ColorSpecificationIndex = DiracColorSpecification.HDTV,
                ColorPrimariesIndex = DiracColorPrimaries.HDTV,
                ColorMatrixIndex = DiracColorMatrix.HDTV,
                TransferFunctionIndex = DiracTransferFunction.TVGamma,
            };

            DiracBaseVideoFormat.predefined = formats;
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="DiracBaseVideoFormat"/> class from being created.
        /// </summary>
        private DiracBaseVideoFormat()
        {
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets the name of the video format.
        /// </summary>
        public string Name
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the <see cref="FrameDimensions"/> of the video format.
        /// </summary>
        public FrameDimensions Dimensions
        {
            get;
            private set;
        }
        
        /// <summary>
        /// Gets the <see cref="SubsamplingMode"/> of chroma data.
        /// </summary>
        public SubsamplingMode ChromaSamplingFormat
        {
            get;
            private set;
        }

        public bool SourceSampling
        {
            get;
            private set;
        }
        public bool TopFieldFirst
        {
            get;
            private set;
        }
        public int FrameRateIndex
        {
            get;
            private set;
        }
        public SampleRate FrameRate
        {
            get;
            private set;
        }
        public int PixelAspectRatioIndex
        {
            get;
            private set;
        }
        public int PixelAspectRatioNumerator
        {
            get;
            private set;
        }
        public int PixelAspectRatioDenominator
        {
            get;
            private set;
        }
        public int SignalRangeIndex
        {
            get;
            private set;
        }
        public int LumaOffset
        {
            get;
            private set;
        }
        public int LumaExcursion
        {
            get;
            private set;
        }
        public int ChromaOffset
        {
            get;
            private set;
        }
        public int ChromaExcursion
        {
            get;
            private set;
        }
        public DiracColorSpecification ColorSpecificationIndex
        {
            get;
            private set;
        }
        public DiracColorPrimaries ColorPrimariesIndex
        {
            get;
            private set;
        }
        public DiracColorMatrix ColorMatrixIndex
        {
            get;
            private set;
        }
        public DiracTransferFunction TransferFunctionIndex
        {
            get;
            private set;
        }
        #endregion
    }
}
