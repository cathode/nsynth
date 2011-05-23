/* NSynth - A Managed Multimedia API. http://nsynth.codeplex.com/
 * Copyright © 2009-2011 Will 'cathode' Shelley. All Rights Reserved. */
using System;
using System.Collections.Generic;
using System.Text;
using NSynth.Imaging;

namespace NSynth.Video.Dirac
{
    public sealed class DiracBaseVideoFormat
    {
        #region Fields
        private static readonly DiracBaseVideoFormat[] predefined;
        private string name;
        private FrameDimensions dimensions;
        private SubsamplingMode chromaSamplingFormat;
        private bool sourceSampling;
        private bool topFieldFirst;
        private SampleRate frameRate;
        private int frameRateIndex;
        private int frameRateNumerator;
        private int frameRateDenominator;
        private int pixelAspectRatioIndex;
        private int pixelAspectRatioNumerator;
        private int pixelAspectRatioDenominator;
        private int signalRangeIndex;
        private int lumaOffset;
        private int lumaExcursion;
        private int chromaOffset;
        private int chromaExcursion;
        private DiracColorSpecification colorSpecificationIndex;
        private DiracColorPrimaries colorPrimariesIndex;
        private DiracColorMatrix colorMatrixIndex;
        private DiracTransferFunction transferFunctionIndex;
        #endregion
        #region Constructors
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

        private DiracBaseVideoFormat()
        {
        }
        #endregion
        #region Properties
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
        public FrameDimensions Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }
        public SubsamplingMode ChromaSamplingFormat
        {
            get
            {
                return this.chromaSamplingFormat;
            }
            set
            {
                this.chromaSamplingFormat = value;
            }
        }
        public bool SourceSampling
        {
            get
            {
                return this.sourceSampling;
            }
            set
            {
                this.sourceSampling = value;
            }
        }
        public bool TopFieldFirst
        {
            get
            {
                return this.topFieldFirst;
            }
            set
            {
                this.topFieldFirst = value;
            }
        }
        public int FrameRateIndex
        {
            get
            {
                return this.frameRateIndex;
            }
            set
            {
                this.frameRateIndex = value;
            }
        }
        public SampleRate FrameRate
        {
            get
            {
                return this.frameRate;
            }
            set
            {
                this.frameRate = value;
            }
        }
        public int PixelAspectRatioIndex
        {
            get
            {
                return this.pixelAspectRatioIndex;
            }
            set
            {
                this.pixelAspectRatioIndex = value;
            }
        }
        public int PixelAspectRatioNumerator
        {
            get
            {
                return this.pixelAspectRatioNumerator;
            }
            set
            {
                this.pixelAspectRatioNumerator = value;
            }
        }
        public int PixelAspectRatioDenominator
        {
            get
            {
                return this.pixelAspectRatioDenominator;
            }
            set
            {
                this.pixelAspectRatioDenominator = value;
            }
        }
        public int SignalRangeIndex
        {
            get
            {
                return this.signalRangeIndex;
            }
            set
            {
                this.signalRangeIndex = value;
            }
        }
        public int LumaOffset
        {
            get
            {
                return this.lumaOffset;
            }
            set
            {
                this.lumaOffset = value;
            }
        }
        public int LumaExcursion
        {
            get
            {
                return this.lumaExcursion;
            }
            set
            {
                this.lumaExcursion = value;
            }
        }
        public int ChromaOffset
        {
            get
            {
                return this.chromaOffset;
            }
            set
            {
                this.chromaOffset = value;
            }
        }
        public int ChromaExcursion
        {
            get
            {
                return this.chromaExcursion;
            }
            set
            {
                this.chromaExcursion = value;
            }
        }
        public DiracColorSpecification ColorSpecificationIndex
        {
            get
            {
                return this.colorSpecificationIndex;
            }
            set
            {
                this.colorSpecificationIndex = value;
            }
        }
        public DiracColorPrimaries ColorPrimariesIndex
        {
            get
            {
                return this.colorPrimariesIndex;
            }
            set
            {
                this.colorPrimariesIndex = value;
            }
        }
        public DiracColorMatrix ColorMatrixIndex
        {
            get
            {
                return this.colorMatrixIndex;
            }
            set
            {
                this.colorMatrixIndex = value;
            }
        }
        public DiracTransferFunction TransferFunctionIndex
        {
            get
            {
                return this.transferFunctionIndex;
            }
            set
            {
                this.transferFunctionIndex = value;
            }
        }
        #endregion
        #region Methods
        public DiracBaseVideoFormat Clone()
        {
            var clone = new DiracBaseVideoFormat();
            clone.chromaExcursion = this.chromaExcursion;
            clone.chromaOffset = this.chromaOffset;
            clone.chromaSamplingFormat = this.chromaSamplingFormat;
            clone.colorMatrixIndex = this.colorMatrixIndex;
            clone.colorPrimariesIndex = this.colorPrimariesIndex;
            clone.colorSpecificationIndex = this.colorSpecificationIndex;
            clone.dimensions = this.dimensions;
            clone.frameRateDenominator = this.frameRateDenominator;
            clone.frameRateIndex = this.frameRateIndex;
            clone.frameRateNumerator = this.frameRateNumerator;
            clone.lumaExcursion = this.lumaExcursion;
            clone.lumaOffset = this.lumaOffset;
            clone.name = this.name;
            clone.pixelAspectRatioDenominator = this.pixelAspectRatioDenominator;
            clone.pixelAspectRatioIndex = this.pixelAspectRatioIndex;
            clone.pixelAspectRatioNumerator = this.pixelAspectRatioNumerator;
            clone.signalRangeIndex = this.signalRangeIndex;
            clone.sourceSampling = this.sourceSampling;
            clone.topFieldFirst = this.topFieldFirst;
            clone.transferFunctionIndex = this.transferFunctionIndex;

            return clone;
        }
        #endregion
    }
}
