/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2010 Will 'cathode' Shelley. All Rights Reserved.         *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSynth.Imaging.TIFF
{
    public sealed class TIFFEncoder : ImageEncoder
    {
        public TIFFEncoder(Stream bitstream)
            : base(bitstream)
        {
        }
        public override void EncodeImage(Image image)
        {
            throw new NotImplementedException();
        }

        public override bool CanSuspend
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override Codec Codec
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool Open()
        {
            throw new NotImplementedException();
        }

        public override bool Close()
        {
            throw new NotImplementedException();
        }
    }
}
