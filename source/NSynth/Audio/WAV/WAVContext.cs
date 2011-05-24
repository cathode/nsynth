/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/

namespace NSynth.Audio.WAV
{
    public sealed class WAVContext
    {
        private WAVBitstreamHeader header = new WAVBitstreamHeader();


        public WAVContext()
        {
        }

        public WAVBitstreamHeader Header
        {
            get
            {
                return this.header;
            }
        }
    }
}
