/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2013 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace NSynth.Imaging
{
    public abstract class ImageEncoder : MediaEncoder
    {
        #region Constructors
        protected ImageEncoder()
        {
        }
        #endregion
        #region Methods
        public abstract void EncodeImage(Image image);

        public override void EncodeFrame(Frame frame)
        {
            ImageCodec codec = this.Codec as ImageCodec;

            var img = codec.CreateImage(frame.Video[0].Width, frame.Video[0].Height);
            //img.Background = frame.Video[0];

            this.EncodeImage(img);
        }
        #endregion
    }
}
