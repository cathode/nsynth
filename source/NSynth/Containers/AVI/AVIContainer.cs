/* NSynth - A Managed Multimedia API. http://nsynth.codeplex.com/
 * Copyright © 2009-2010 Will 'cathode' Shelley. All Rights Reserved. */
using System;
using System.Collections.Generic;

using System.Text;
using System.IO;

namespace NSynth.Containers.AVI
{
    /// <summary>
    /// Provides support for demultiplexing multimedia bitstreams contained in an AVI (Audio/Video-Interlaced) container.
    /// </summary>
    public class AVIContainer : ContainerCodec
    {
        #region Methods

        #endregion
        #region Properties
        public override bool CanDecode
        {
            get
            {
                return true; // Decoding support only for compatibility with older content and programs.
            }
        }

        public override bool CanEncode
        {
            get
            {
                return false; // AVI encoding is not supported and not planned for support.
            }
        }

        public override Version Version
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        #endregion

        public override bool SupportsFrameAccurateSeeking
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public override bool SupportsNonLinearAccess
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public override MediaEncoder CreateEncoder(Stream output)
        {
            throw new NotImplementedException();
        }

        public override MediaDecoder CreateDecoder(Stream input)
        {
            throw new NotImplementedException();
        }

        public override int MaxThreads
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
