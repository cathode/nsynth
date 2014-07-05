/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2013 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace NSynth.Containers.MKV
{
    public class MKVContainer : Container
    {
        public override bool CanContain(Clip clip)
        {
            throw new NotImplementedException();
        }

        public override Clip GetLayout()
        {
            throw new NotImplementedException();
        }

        public override ContainerStream GetStreamForTrack(int trackId)
        {
            throw new NotImplementedException();
        }
    }
}
