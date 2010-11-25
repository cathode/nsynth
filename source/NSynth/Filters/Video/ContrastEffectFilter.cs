using System;
using System.Collections.Generic;
using System.Text;
using NSynth;
using NSynth.Imaging;

namespace NSynth.Filters.Video
{
    public class ContrastEffectFilter : EffectFilter
    {
        #region Fields
        private float contrast;
     
        #endregion
        #region Properties
        public float Contrast
        {
            get
            {
                return this.contrast;
            }
            set
            {
                this.contrast = value;
            }
        }
        
        #endregion
        #region Methods
        protected override void OnInitializing(FilterInitializationEventArgs e)
        {
            base.OnInitializing(e);

            this.Clip = this.InputFrames.Filter.Clip;
        }
        public override Frame Render(long frameIndex)
        {
            Frame frame = this.InputFrames.GetValue(frameIndex);

            foreach (var bitmap in frame.Video)
                for (int row = 0; row < bitmap.Height; row++)
                    for (int col = 0; col < bitmap.Width; col++)
                    {
                        var px = bitmap[row, col];
                        px.Red = (px.Red - 0.5f) * this.contrast;
                        px.Green = (px.Green - 0.5f) * this.contrast;
                        px.Blue = (px.Blue - 0.5f) * this.contrast;
                        bitmap[row, col] = px;
                    }

            return frame;
        }

        private BitmapRGB24 ApplyEffectRGB24(BitmapRGB24 input)
        {
            ColorRGB24[] pix = new ColorRGB24[input.Size.Elements];

            var c = this.Contrast;

            for (int i = 0; i < pix.Length; i++)
            {
                pix[i].Red = (byte)((pix[i].Red - 127) * c);
                pix[i].Green = (byte)((pix[i].Green - 127) * c);
                pix[i].Blue = (byte)((pix[i].Blue - 127) * c);
            }

            return new BitmapRGB24(input.Size, pix);
        }

        private BitmapRGB32 ApplyEffectRGB32(BitmapRGB32 input)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
