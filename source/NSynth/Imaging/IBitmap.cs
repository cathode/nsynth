/* NSynth - A Managed Multimedia API. http://nsynth.codeplex.com/
 * Copyright © 2009-2011 Will 'cathode' Shelley. All Rights Reserved. */
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
