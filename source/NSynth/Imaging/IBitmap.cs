/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System.Collections.Generic;

using System.Text;

namespace NSynth.Imaging
{
    public interface IBitmap
    {
        #region Properties
        int Height
        {
            get;
        }
        int Width
        {
            get;
        }
        #endregion
        #region Indexers
        IColor this[int row, int col]
        {
            get;
            set;
        }
        #endregion
        #region Methods
        void Fill(IColor color);
        #endregion
    }
}
